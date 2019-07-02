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

        private void OnDrawGizmos()
        {
            Gizmos.color = TeamUtils.GetTeamColor(capturePoint.capturePointData.teamId);
            Gizmos.DrawWireSphere(radiusParams.transform.position, radiusParams.radius);
            Gizmos.color = Color.white;
        }
    }
}