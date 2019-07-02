using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class CapturePointData : ITeamOwned
    {
        public int teamId = CapturePoint.UnclaimedId;
        public List<int> lockedTeams;

        public DataCollection dataCollection = new DataCollection();

        public int GetTeamId()
        {
            return teamId;
        }
    }

    public class CapturePoint : MonoBehaviour
    {
        [SerializeField] Renderer renderer;

        [SerializeField]
        public CapturePointData capturePointData;

        /// <summary>
        /// The team id returned when the point has not been claimed by any team
        /// </summary>
        public const int UnclaimedId = 0;
        /// <summary>
        /// The team id returned when the point is contested
        /// </summary>
        public const int ContestedId = -1;

        private void Start()
        {
            Refresh();
        }

        /// <summary>
        /// Sets what team has won the point
        /// </summary>
        /// <param name="teamId">The winning team's id. NOTE: 0 is contested</param>
        public void SetWinningTeamId(int teamId)
        {
            if (teamId == UnclaimedId || capturePointData.lockedTeams.Contains(teamId)) // Prevent the capture point from returning to an unclaimed state
                return;

            capturePointData.teamId = teamId;

            Refresh();
        }

        /// <summary>
        /// Sets what teams are locked from capturing this point
        /// </summary>
        /// <param name="teamId">Team id to be locked or unlocked</param>
        /// <param name="isLocked">If set to <c>true</c> that team is locked.</param>
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