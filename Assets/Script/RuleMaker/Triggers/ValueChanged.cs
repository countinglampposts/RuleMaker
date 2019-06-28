using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public class ValueChanged : TriggerBase
    {
        [SerializeField] UnityEngine.Object aggregator;

        Action callback;
        object lastValue;

        public override void AddListener(Action callback)
        {
            this.callback = callback;
        }

        private void Start()
        {
            lastValue = (aggregator as IAggregator).AggregateObject();
        }

        private void Update()
        {
            var newValue = (aggregator as IAggregator).AggregateObject();
            if (!lastValue.Equals(newValue))
            {
                callback();
                lastValue = newValue;
            }
        }
    }
}