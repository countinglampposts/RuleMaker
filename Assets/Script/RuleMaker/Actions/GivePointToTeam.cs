using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public class GivePointToTeam : MonoBehaviour
    {
        [SerializeField] TriggerBase trigger;
        [SerializeField] IntAggregator winningTeamIdAggregator;
        [SerializeField] CapturePoint capturePoint;

        private void Start()
        {
            trigger.AddListener(() =>
            {
                var winningTeamId = winningTeamIdAggregator.Aggregate();

                if (winningTeamId >= 0)
                {
                    var winningTeamData = RulemakerUtils.GetAllTeams()
                        .First(team => team.teamId == winningTeamId);
                    capturePoint.SetWinner(winningTeamData);
                }
                else if (winningTeamId == MajorityTeamId.ContestedId)
                {
                    capturePoint.SetNeutral();
                }
            });
        }
    }
}