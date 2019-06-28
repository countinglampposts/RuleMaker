using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public class Timer : TriggerBase
    {
        [System.Serializable]
        class Settings
        {
            public float time;
        }

        [SerializeField] TriggerBase trigger;
        [SerializeField] Settings settings;

        Action callback;

        public override void AddListener(Action callback)
        {
            this.callback = callback;
        }

        private void Start()
        {
            trigger.AddListener(() =>
            {
                StopAllCoroutines();
                StartCoroutine(TimerCoroutine());
            });
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(settings.time);
            callback();
        }
    }
}