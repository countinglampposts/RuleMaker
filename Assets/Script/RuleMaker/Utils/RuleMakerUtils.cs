using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public static class RuleMakerUtils
    {
        /// <summary>
        /// Logs the data being passed through a trigger
        /// </summary>
        /// <param name="prefix">The prefix to the log, defualts to empty</param>
        public static ITrigger<T> Debug<T>(this ITrigger<T> trigger, string prefix = "")
        {
            var returned = new Trigger<T>();

            trigger.AddListener(data => UnityEngine.Debug.Log(prefix + ": " + data));
            trigger.AddListener(returned.trigger);

            return returned;
        }

        /// <summary>
        /// Logs the data being passed through the aggregate
        /// </summary>
        /// <param name="prefix">The prefix to the log, defualts to empty</param>
        public static IAggregator<T> Debug<T>(this IAggregator<T> aggregator, string prefix = "")
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

        /// <summary>
        /// Draws an arrow with gizmos
        /// Copied and modified from here: https://wiki.unity3d.com/index.php/DrawArrow
        /// </summary>
        /// <param name="fromPosition">The position the arrow comes from</param>
        /// <param name="toPosition">The position the arrow goes to</param>
        /// <param name="arrowHeadLength">Arrow head length.</param>
        /// <param name="arrowHeadAngle">Arrow head angle.</param>
        public static void DrawArrow(Vector3 fromPosition, Vector3 toPosition, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f)
        {
            var direction = toPosition - fromPosition;

            Gizmos.DrawRay(fromPosition, direction);

            Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
            Gizmos.DrawRay(fromPosition + direction, right * arrowHeadLength);
            Gizmos.DrawRay(fromPosition + direction, left * arrowHeadLength);
        }
    }
}