using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RuleMaker
{
    public class Game : MonoBehaviour
    {
        [SerializeField] Rule[] rules;

        public GameState ApplyRules(GameState gameState)
        {
            foreach (var r in rules)
            {
                gameState = r.ApplyRule(gameState);
            }

            return gameState;
        }
    }
}