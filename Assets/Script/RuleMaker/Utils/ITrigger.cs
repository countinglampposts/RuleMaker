using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    /// <summary>
    /// This is used to trigger an aggregation and send async events
    /// </summary>
    public interface ITrigger<T>
    {
        /// <summary>
        /// Adds a listener for when trigger is called. Generally for internal use
        /// </summary>
        /// <param name="action">The listener even</param>
        void AddListener(Action<T> action);
    }

    /// <summary>
    /// This is a concrete implementation of ITrigger
    /// </summary>
    public class Trigger<T> : ITrigger<T>
    {
        public Action<T> trigger = data => { };

        public void AddListener(Action<T> action)
        {
            this.trigger += action;
        }
    }
}