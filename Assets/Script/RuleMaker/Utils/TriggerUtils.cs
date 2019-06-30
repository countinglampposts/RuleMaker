using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public static class TriggerUtils
    {
        private class Disposable : IDisposable
        {
            public Action dispose;

            public void Dispose()
            {
                dispose();
            }
        }

        public static ITrigger<T> DataChanged<T>(this IAggregator<T> aggregator)
        {
            var previousData = aggregator.GetData();

            var returned = new Trigger<T>();

            StartCoroutine(EveryUpdate(() =>
            {
                var currentData = aggregator.GetData();
                if (!currentData.Equals(previousData))
                {
                    returned.action(currentData);
                    previousData = currentData;
                }
            }));

            return returned;
        }

        public static ITrigger<T> Timer<T>(this ITrigger<T> trigger, TimerParams timerParams)
        {
            var returned = new Trigger<T>();
            IDisposable disposable = null;

            trigger.AddListener(data =>
            {
                if (disposable != null)
                    disposable.Dispose();

                disposable = StartCoroutine(TimerCoroutine(() =>
                {
                    returned.action(data);
                }, timerParams));
            });

            return returned;
        }

        public static ITrigger<T> Do<T>(this ITrigger<T> trigger, Action<T> action)
        {
            var returned = new Trigger<T>();

            trigger.AddListener(action);
            trigger.AddListener(returned.action);

            return returned;
        }

        private static IDisposable StartCoroutine(IEnumerator coroutine)
        {
            var coroutineSurrogate = (new GameObject("CoroutineSurrogate")).AddComponent<Stub>();

            coroutineSurrogate.StartCoroutine(coroutine);

            return new Disposable
            {
                dispose = () => GameObject.Destroy(coroutineSurrogate.gameObject)
            };
        }

        private static IEnumerator TimerCoroutine(Action callback, TimerParams timerParams)
        {
            yield return new WaitForSeconds(timerParams.waitTime);
            callback();
        }

        private static IEnumerator EveryUpdate(Action callback)
        {
            while (true)
            {
                yield return null;
                callback();
            }
        }
    }
}