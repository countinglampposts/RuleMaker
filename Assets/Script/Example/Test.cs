using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public class Test : MonoBehaviour
    {
        [SerializeField] RadiusParams radiusParams;
        [SerializeField] TimerParams timerParams;
        [SerializeField] CapturePoint capturePoint;
        void Start()
        {
            PlayerUtils.GetAllPlayers()
                .PlayersWithinRadius(radiusParams)
                .MajorityTeamId()
                .DataChanged()
                .Timer(timerParams)
                .Do(capturePoint.SetWinningTeamId);
        }
    }
}