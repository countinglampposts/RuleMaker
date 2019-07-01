using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker.Example
{
    public class ScoreCountdown : MonoBehaviour
    {
        [System.Serializable]
        public class Settings
        {
            public int winningScore;
            public float scoreDropRate;
        }

        [SerializeField] Settings settings;

        private void Start()
        {
            CapturePointUtils.GetAllCapturePoints()
                .MajorityTeamId()
                .GetTeamFromId()
                .OnDataChanged()
                .OnTimer(new TimerParams
                {
                    waitTime = settings.scoreDropRate,
                    repeat = true
                })
                .OnDo(winningTeam =>
                {
                    if (winningTeam != null)
                    {
                        var currentScore = winningTeam.dataCollection.GetData<int>("score");
                        currentScore++;
                        winningTeam.dataCollection.SetData("score", currentScore);

                        if (currentScore >= settings.winningScore)
                            Debug.Log("Team " + winningTeam.teamId + " wins!");
                    }
                });
        }
    }
}