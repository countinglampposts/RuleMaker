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

        public static void DrawArrow(Vector3 pos, Vector3 pos2, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
        {
            var direction = pos2 - pos;

            Gizmos.DrawRay(pos, direction);

            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            Gizmos.DrawRay(pos + direction, right * arrowHeadLength);
            Gizmos.DrawRay(pos + direction, left * arrowHeadLength);
        }
    }
}