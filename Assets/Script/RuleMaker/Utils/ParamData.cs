using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class RadiusParams
    {
        public float radius;
        public Transform transform;
    }

    [System.Serializable]
    public class TimerParams
    {
        public float waitTime;
        public bool repeat;
    }

}