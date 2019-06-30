using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public interface IAggregator<T>
    {
        T GetData();
    }

    public class Aggregator<T> : IAggregator<T>
    {
        public Func<T> getData;
        public T GetData()
        {
            return getData();
        }
    }
}