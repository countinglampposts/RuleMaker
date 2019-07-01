using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public static class RuleMakerUtils
    {
        public static ITrigger<T> Debug<T>(this ITrigger<T> trigger, string prefix)
        {
            var returned = new Trigger<T>();

            trigger.AddListener(data => UnityEngine.Debug.Log(prefix + ": " + data));
            trigger.AddListener(returned.trigger);

            return returned;
        }

        public static IAggregator<T> Debug<T>(this IAggregator<T> aggregator, string prefix)
        {
            return new Aggregator<T>
            {
                getData = () =>
                {
                    var data = aggregator.GetData();
                    UnityEngine.Debug.Log(prefix + ": " + data);
                    return data;
                }
            };
        }
    }
}