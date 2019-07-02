using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    /// <summary>
    /// This is used to get data
    /// </summary>
    public interface IAggregator<T>
    {
        /// <summary>
        /// Returns the aggregator's data. Generally for internal use
        /// </summary>
        /// <returns>The aggregator's data</returns>
        T GetData();
    }

    /// <summary>
    /// This is a concrete implementation of IAggregator
    /// </summary>
    public class Aggregator<T> : IAggregator<T>
    {
        public Func<T> getData;
        public T GetData()
        {
            return getData();
        }
    }
}