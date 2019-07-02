using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public static class CapturePointUtils
    {
        /// <summary>
        /// Gets all capture points. This list can be further filtered using Linq
        /// </summary>
        public static IAggregator<IEnumerable<CapturePointData>> GetAllCapturePoints()
        {
            return new Aggregator<IEnumerable<CapturePointData>>
            {
                getData = () =>
                {
                    var returned = GameObject.FindObjectsOfType(typeof(CapturePoint))
                        .Select(cp => cp as CapturePoint)
                        .Select(cp => cp.capturePointData);

                    return returned;
                }
            };
        }

        /// <summary>
        /// Gets an aggregator for this point's current capture point data
        /// </summary>
        public static IAggregator<CapturePointData> GetCurrentCapturePointData(this CapturePoint capturePoint)
        {
            return new Aggregator<CapturePointData>
            {
                getData = () => capturePoint.capturePointData
            };
        }
    }
}