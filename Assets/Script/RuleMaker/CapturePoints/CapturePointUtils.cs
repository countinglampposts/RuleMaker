using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public static class CapturePointUtils
    {
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
    }
}