using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RuleMaker
{
    public abstract class Cause : MonoBehaviour
    {
        public abstract bool CausePredicate(GameState gameState);
    }
}