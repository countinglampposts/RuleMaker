using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class CapturePointData : ITeamOwned
    {
        public int GetTeamId()
        {
            return teamId;
        }

        public int teamId = CapturePoint.UnclaimedId;

        public Dictionary<string, object> data;
    }

    public class CapturePoint : MonoBehaviour
    {
        [SerializeField] Renderer renderer;

        [SerializeField]
        public CapturePointData capturePointData;

        public const int UnclaimedId = 0;
        public const int ContestedId = -1;

        public void SetWinningTeamId(int teamId)
        {
            if (teamId == UnclaimedId) // Prevent the capture point from returning to an unclaimed state
                return;

            if (teamId > 0)
                renderer.material.color = TeamUtils.GetAllTeams().GetData()
                    .First(team => team.teamId == teamId).teamColor;
            else
                renderer.material.color = Color.white;

            capturePointData.teamId = teamId;
        }
    }
}