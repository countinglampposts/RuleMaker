using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public class GivePointToTeam : MonoBehaviour
    {
        [System.Serializable]
        class Settings
        {
            public bool returnToNeutral;
        }

        [SerializeField] TeamAggregator winningTeamAggregator;
        [SerializeField] CapturePoint capturePoint;

        [SerializeField] Settings settings;

        private void Update()
        {
            var winningTeam = winningTeamAggregator.Aggregate();
            if (winningTeam.Any())
                capturePoint.SetWinner(winningTeam.First());
            else if (settings.returnToNeutral)
                capturePoint.SetNeutral();
        }
    }
}