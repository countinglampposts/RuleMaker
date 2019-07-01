using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public static class AggregatorUtils
    {
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