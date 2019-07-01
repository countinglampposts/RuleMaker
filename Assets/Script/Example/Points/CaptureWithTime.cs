using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker.Example
{
    public class CaptureWithTime : MonoBehaviour
    {
        [SerializeField] RadiusParams radiusParams;
        [SerializeField] TimerParams timerParams;
        [SerializeField] CapturePoint capturePoint;

        void Start()
        {
            PlayerUtils.GetAllPlayers()
                .PlayersWithinRadius(radiusParams)
                .MajorityTeamId()
                .OnDataChanged()
                .OnTimer(timerParams)
                .OnDo(capturePoint.SetWinningTeamId);
        }
    }
}