using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuleMaker
{
    public class Log : Effect
    {
        [SerializeField] string prefix;
        public override GameState ApplyEffect(GameState gameState)
        {
            Debug.Log(prefix + " effect has been triggered");

            return gameState;
        }
    }
}