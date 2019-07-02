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
        public List<int> lockedTeams;

        public DataCollection dataCollection = new DataCollection();
    }

    public class CapturePoint : MonoBehaviour
    {
        [SerializeField] Renderer renderer;

        [SerializeField]
        public CapturePointData capturePointData;

        public const int UnclaimedId = 0;
        public const int ContestedId = -1;

        public void Start()
        {
            Refresh();
        }

        public void SetWinningTeamId(int teamId)
        {
            if (teamId == UnclaimedId || capturePointData.lockedTeams.Contains(teamId)) // Prevent the capture point from returning to an unclaimed state
                return;

            capturePointData.teamId = teamId;

            Refresh();
        }

        public void SetLocked(int teamId, bool isLocked)
        {
            if (isLocked)
            {
                if (!capturePointData.lockedTeams.Contains(teamId))
                {
                    capturePointData.lockedTeams.Add(teamId);
                }
            }
            else
            {
                capturePointData.lockedTeams.Remove(teamId);
            }


            Refresh();
        }

        private void Refresh()
        {
            bool isLocked = capturePointData.lockedTeams.Count >= TeamUtils.GetAllTeams().GetData().Count();

            Color color;
            var teamId = capturePointData.teamId;

            if (teamId > 0)
                color = TeamUtils.GetAllTeams().GetData()
                    .First(team => team.teamId == teamId).teamColor;
            else
                color = Color.white;

            float colorMultiplier = (isLocked) ? .5f : 1f;
            renderer.material.color = new Color(color.r * colorMultiplier, color.g * colorMultiplier, color.b * colorMultiplier);
        }
    }
}