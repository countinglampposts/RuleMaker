using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RuleMaker
{
    public class Rule : MonoBehaviour
    {
        [SerializeField] Cause[] causes;
        [SerializeField] Effect[] effects;

        public GameState ApplyRule(GameState gameState)
        {
            foreach (var cause in causes)
            {
                if (!cause.CausePredicate(gameState))
                    return gameState;
            }

            foreach (var effect in effects)
            {
                gameState = effect.ApplyEffect(gameState);
            }

            return gameState;
        }
    }
}