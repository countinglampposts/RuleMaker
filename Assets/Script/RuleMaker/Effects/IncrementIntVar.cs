using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuleMaker
{
    public class IncrementIntVar : Effect
    {
        [SerializeField] string varName;
        [SerializeField] IncrementOperation incrementOperation;
        [SerializeField] int increment;

        public override GameState ApplyEffect(GameState gameState)
        {
            var currentValue = gameState.GetGameVar(varName);
            int outInt = 0;

            int.TryParse(currentValue, out outInt);

            if (incrementOperation == IncrementOperation.add)
                outInt += increment;
            else if (incrementOperation == IncrementOperation.subtract)
                outInt -= increment;
            else if (incrementOperation == IncrementOperation.multiply)
                outInt *= increment;
            else if (incrementOperation == IncrementOperation.divide)
                outInt /= increment;

            gameState.SetGameVar(varName, outInt.ToString());

            return gameState;
        }
    }
}