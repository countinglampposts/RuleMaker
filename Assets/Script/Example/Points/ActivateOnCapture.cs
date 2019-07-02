using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker.Example
{
    public class ActivateOnCapture : MonoBehaviour
    {
        [System.Serializable]
        private class Settings
        {
            public int teamId;
            public CapturePoint[] nextPoints;
        }

        [SerializeField] CapturePoint capturePoint;
        [SerializeField] Settings settings;

        private void Start()
        {
            capturePoint.GetCurrentCapturePointData()
                .OnDataChanged(capturePoint => capturePoint.teamId)
                .OnDo(cpData =>
                {
                    if (cpData.teamId == settings.teamId)
                    {
                        foreach (var a in settings.nextPoints)
                        {
                            a.SetLocked(settings.teamId, false);
                        }
                        capturePoint.SetLocked(settings.teamId, true);
                    }
                });
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = TeamUtils.GetTeamColor(settings.teamId);
            if (capturePoint != null)
            {
                foreach (var a in settings.nextPoints)
                {
                    if (a != null)
                        RuleMakerUtils.DrawArrow(capturePoint.transform.position, a.transform.position, 3);
                }
            }

            Gizmos.color = Color.white;
        }
    }
}