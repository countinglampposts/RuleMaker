using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public static class RulemakerUtils
    {
        public static IEnumerable<TeamData> GetAllTeams()
        {
            return GameObject.FindObjectsOfType(typeof(Team))
                    .Select(o => o as Team)
                    .Select(t => t.teamData);
        }
    }
}