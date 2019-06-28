using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuleMaker
{
    public class Distance : Cause
    {
        [SerializeField] Transform distanceObject;
        [SerializeField] ComparativeOperations comparative;
        [SerializeField] float comparativeDistance;

        bool previouslyMet;

        private void Awake()
        {
            previouslyMet = GetPredicateMet();
        }

        private bool GetPredicateMet()
        {
            float distance = Vector3.Distance(transform.position, distanceObject.position);

            if (comparative == ComparativeOperations.lessThan)
                return distance < comparativeDistance;
            else if (comparative == ComparativeOperations.moreThan)
                return distance > comparativeDistance;

            return false;
        }

        public override bool CausePredicate(GameState gameState)
        {
            var returned = false;
            var predicateMet = GetPredicateMet();

            if (predicateMet && predicateMet != previouslyMet)
                returned = true;
            previouslyMet = predicateMet;

            return returned;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, comparativeDistance);
            Gizmos.color = Color.white;
        }
    }
}