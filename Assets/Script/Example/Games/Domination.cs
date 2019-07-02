using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker.Example
{
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
            foreach (var teamBase in settings.teamBaseData)
            {
                teamBase.baseCapturePoint.GetCurrentCapturePointData()
                    .OnDataChanged(cp => cp.teamId)
                    .OnDo(team =>
                    {
                        if (team.teamId > 0 && team.teamId != teamBase.teamId)
                            Debug.Log("Team " + teamBase.teamId + " loses!");
                    });
            }
        }
    }
}