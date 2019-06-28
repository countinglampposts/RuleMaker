using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuleMaker
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] Game game;

        GameState gameState = new GameState();

        private void Update()
        {
            gameState = game.ApplyRules(gameState);
        }

        public string PrintGameState()
        {
            return gameState.ToString();
        }
    }
}