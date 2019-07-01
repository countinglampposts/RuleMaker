using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public interface ITrigger<T>
    {
        void AddListener(Action<T> action);
    }

    public class Trigger<T> : ITrigger<T>
    {
        public Action<T> trigger = data => { };

        public void AddListener(Action<T> action)
        {
            this.trigger += action;
        }
    }
}