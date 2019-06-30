using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public class CapturePoint : MonoBehaviour
    {
        [SerializeField] Renderer renderer;

        public const int UnclaimedId = -1;
        public const int ContestedId = -2;

        public void SetWinningTeamId(int teamId)
        {
            if (teamId > 0)
                renderer.material.color = TeamUtils.GetAllTeams().GetData()
                    .First(team => team.teamId == teamId).teamColor;
            else if (teamId == ContestedId)
                renderer.material.color = Color.white;

        }
    }
}