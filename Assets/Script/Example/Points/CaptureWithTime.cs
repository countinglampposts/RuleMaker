using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker.Example
{
    // This will capture a point after a majority of players spend a certain amount of time
    public class CaptureWithTime : MonoBehaviour
    {
        [SerializeField] RadiusParams radiusParams;
        [SerializeField] TimerParams timerParams;
        [SerializeField] CapturePoint capturePoint;

        void Start()
        {
            PlayerUtils.GetAllPlayers()                 // Gets all the players
                .WithinRadius(radiusParams)             // Filters players based on radius
                .MajorityTeamId()                       // Gets the majority team id. Note 0 means unclaimed, -1 means constested
                .OnDataChanged()                        // Trigger when the majority changes
                .OnTimer(timerParams)                   // Wait for the designated time
                .OnDo(capturePoint.SetWinningTeamId);   // Set the winning team
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = TeamUtils.GetTeamColor(capturePoint.capturePointData.teamId);
            Gizmos.DrawWireSphere(radiusParams.transform.position, radiusParams.radius);
            Gizmos.color = Color.white;
        }
    }
}