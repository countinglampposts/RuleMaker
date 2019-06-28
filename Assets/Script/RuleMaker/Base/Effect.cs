using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RuleMaker
{
    public abstract class Effect : MonoBehaviour
    {
        public abstract GameState ApplyEffect(GameState gameState);
    }
}