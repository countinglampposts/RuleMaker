using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker.Example
{
    // This is a game type where the goal is to take a team's base capture point
    public class Domination : MonoBehaviour
    {
        [System.Serializable]
        public class TeamBaseData
        {
            public int teamId;
            public CapturePoint baseCapturePoint;
        }

        [System.Serializable]
        public class Settings
        {
            public TeamBaseData[] teamBaseData;
        }

        [SerializeField] Settings settings;

        private void Start()
        {
            // Add a listener on every base capture point to detect if the base is captured. If it is, log the team as losing the game
            foreach (var teamBase in settings.teamBaseData)
            {
                teamBase.baseCapturePoint.GetCurrentCapturePointData()
                    .OnDataChanged(cp => cp.teamId) // Only check for changes in who owns the point
                    .OnDo(team =>
                    {
                        if (team.teamId > 0 && team.teamId != teamBase.teamId) // Check if the team id is valid and if the team is not the one owned by the team
                            Debug.Log("Team " + teamBase.teamId + " loses!"); // Log a loss
                    });
            }
        }
    }
}