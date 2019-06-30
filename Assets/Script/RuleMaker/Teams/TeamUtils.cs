using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public static class TeamUtils
    {
        public static IAggregator<IEnumerable<TeamData>> GetAllTeams()
        {
            return new Aggregator<IEnumerable<TeamData>>
            {
                getData = () => GameObject.FindObjectsOfType(typeof(Team))
                       .Select(o => o as Team)
                       .Select(t => t.teamData)
            };
        }
    }
}