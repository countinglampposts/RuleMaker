using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public static class TriggerUtils
    {
        private static GameObject coroutineSurrogateGameObject;

        private class Disposable : IDisposable
        {
            public Action dispose;

            public void Dispose()
            {
                dispose();
            }
        }

        public static ITrigger<T> OnDataChanged<T, I>(this IAggregator<T> aggregator, Func<T, I> select)
        {
            var previousData = select(aggregator.GetData());

            var returned = new Trigger<T>();

            StartCoroutine(EveryUpdate(() =>
            {
                var originalCurrentData = aggregator.GetData();
                var currentData = select(originalCurrentData);

                if ((currentData == null && previousData == null) || !currentData.Equals(previousData))
                {
                    returned.trigger(originalCurrentData);
                }

                previousData = currentData;
            }));

            return returned;
        }

        // TODO: find a way to do a valueEquals check
        public static ITrigger<T> OnDataChanged<T>(this IAggregator<T> aggregator)
        {
            var previousData = aggregator.GetData();

            var returned = new Trigger<T>();

            StartCoroutine(EveryUpdate(() =>
            {
                var currentData = aggregator.GetData();

                if ((currentData == null && previousData == null) || (currentData != null && !currentData.Equals(previousData)))
                {
                    returned.trigger(currentData);
                }

                previousData = currentData;
            }));

            return returned;
        }

        public static ITrigger<T> OnTimer<T>(this ITrigger<T> trigger, TimerParams timerParams)
        {
            var returned = new Trigger<T>();
            IDisposable disposable = null;

            trigger.AddListener(data =>
            {
                if (disposable != null)
                    disposable.Dispose();

                Action startTimer = null;

                startTimer = () =>
                {
                    disposable = StartCoroutine(TimerCoroutine(() =>
                    {
                        returned.trigger(data);
                        if (timerParams.repeat)
                            startTimer();
                    }, timerParams));
                };

                startTimer();
            });

            return returned;
        }

        public static ITrigger<T> OnDo<T>(this ITrigger<T> trigger, Action<T> action)
        {
            var returned = new Trigger<T>();

            trigger.AddListener(action);
            trigger.AddListener(returned.trigger);

            return returned;
        }

        private static IDisposable StartCoroutine(IEnumerator coroutine)
        {
            if (coroutineSurrogateGameObject == null) coroutineSurrogateGameObject = new GameObject("CoroutineSurrogate");

            var coroutineSurrogate = coroutineSurrogateGameObject.AddComponent<Stub>();

            coroutineSurrogate.StartCoroutine(coroutine);

            return new Disposable
            {
                dispose = () => GameObject.Destroy(coroutineSurrogate)
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