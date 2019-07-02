using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public static class AggregatorUtils
    {
        /// <summary>
        /// Use this to modify the data that is being sent through the aggregators
        /// </summary>
        /// <returns>The new aggregator</returns>
        /// <param name="select">A method used to change the data from one type to another</param>
        public static IAggregator<I> Select<T, I>(this IAggregator<T> aggregator, Func<T, I> select)
        {
            return new Aggregator<I>
            {
                getData = () =>
                {
                    return select(aggregator.GetData());
                }
            };
        }
    }
}