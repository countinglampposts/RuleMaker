using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public abstract class TriggerBase : MonoBehaviour
    {
        public abstract void AddListener(Action callback);
    }
}