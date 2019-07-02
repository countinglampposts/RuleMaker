using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker.Example
{
    // This behavior will activate a number of next capture points for a team and deactivate the point for that team
    public class ActivateOnCapture : MonoBehaviour
    {
        [System.Serializable]
        private class Settings
        {
            public int teamId;
            public CapturePoint capturePoint;
            public CapturePoint[] nextPoints;
        }

        [SerializeField] Settings settings;

        private void Start()
        {
            settings.capturePoint.GetCurrentCapturePointData()                       // Gets the capture point's current state
                .OnDataChanged(capturePoint => capturePoint.teamId)         // Trigger when the capture point's team id is changed
                .OnDo(cpData =>
                {
                    if (cpData.teamId == settings.teamId)                   // Only proceed if the team that captured the point is the correct point
                    {
                        foreach (var a in settings.nextPoints)
                        {
                            a.SetLocked(settings.teamId, false);            // Unlock all the next points
                        }
                        settings.capturePoint.SetLocked(settings.teamId, true);      // Lock the current point
                    }
                });
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = TeamUtils.GetTeamColor(settings.teamId);

            if (settings.capturePoint != null)
            {
                foreach (var a in settings.nextPoints)
                {
                    if (a != null)
                        RuleMakerUtils.DrawArrow(settings.capturePoint.transform.position, a.transform.position, 3);
                }
            }

            Gizmos.color = Color.white;
        }
    }
}