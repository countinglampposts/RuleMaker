using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rulemaker;
using UnityEngine;

namespace Rulemaker
{
    public class MajorityTeamId : IntAggregator
    {
        public PlayerListAggregator source;

        public override int Aggregate()
        {
            var playerList = source.Aggregate();

            if (!playerList.Any())
                return -1;

            var teams = playerList
                .Select(player => player.teamId)
                .Distinct();

            int winningTeam = -1;
            int winningCount = -1;

            foreach (var team in teams)
            {
                int teamCount = playerList
                    .Count(player => player.teamId == team);
                if (teamCount > winningCount)
                {
                    winningTeam = team;
                    winningCount = teamCount;
                }
                else if (teamCount == winningCount)
                {
                    winningTeam = -1;
                    winningCount = teamCount;
                }
            }

            return winningTeam;
        }
    }
}