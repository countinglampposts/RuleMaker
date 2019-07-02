using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker.Example
{
    // This is a game type where every team gains score by controlling the majority of the points. 
    // First team to reach a winning score, wins
    public class ScoreCountdown : MonoBehaviour
    {
        [System.Serializable]
        public class Settings
        {
            public int winningScore;
            public float scoreGainRate;
        }

        [SerializeField] Settings settings;

        private void Start()
        {
            CapturePointUtils.GetAllCapturePoints() // Gets all points
                .MajorityTeamId()                   // Gets the majority team id. Note: 0 means unclaimed, -1 means contested
                .GetTeamFromId()                    // Gets the team using this id
                .OnDataChanged()                    // Triggers an event when the data has changed
                .OnTimer(new TimerParams            // Triggers a new timer 
                {
                    waitTime = settings.scoreGainRate,
                    repeat = true
                })
                .OnDo(winningTeam =>
                {
                    if (winningTeam != null)        // Do a null check as it is possible there is no winning team
                    {
                        var currentScore = winningTeam.dataCollection.GetData<int>("score");
                        currentScore++;
                        winningTeam.dataCollection.SetData("score", currentScore);

                        if (currentScore >= settings.winningScore) // Log a win if a team gets above the winning score
                            Debug.Log("Team " + winningTeam.teamId + " wins!");
                    }
                });
        }
    }
}