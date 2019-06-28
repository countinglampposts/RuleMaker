using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public abstract class IntAggregator : MonoBehaviour, IAggregator
    {
        public object AggregateObject()
        {
            return Aggregate();
        }

        public abstract int Aggregate();
    }
}