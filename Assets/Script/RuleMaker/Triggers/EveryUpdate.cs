using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public class EveryUpdate : TriggerBase
    {
        Action callback;

        public override void AddListener(Action callback)
        {
            this.callback = callback;
        }

        private void Update()
        {
            callback();
        }
    }
}