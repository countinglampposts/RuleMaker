using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public interface ITeamOwned
    {
        int GetTeamId();
    }

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

        public static IAggregator<TeamData> GetTeamFromId(this IAggregator<int> teamId)
        {
            return new Aggregator<TeamData>()
            {
                getData = () => GetAllTeams().GetData()
                    .FirstOrDefault(team => team.teamId == teamId.GetData())
            };
        }

        public static IAggregator<int> MajorityTeamId<T>(this IAggregator<IEnumerable<T>> aggregator) where T : ITeamOwned
        {
            return new Aggregator<int>
            {
                getData = () =>
                {
                    var teamOwnedList = aggregator.GetData();

                    if (!teamOwnedList.Any())
                        return CapturePoint.UnclaimedId;

                    var teams = teamOwnedList
                        .Select(teamOwned => teamOwned.GetTeamId())
                        .Distinct();

                    int winningTeamId = CapturePoint.UnclaimedId;
                    int winningCount = -1;

                    foreach (var team in teams)
                    {
                        if (team < 1) // Filter out contested and unclaimed team
                            continue;

                        int teamCount = teamOwnedList
                            .Count(teamOwned => teamOwned.GetTeamId() == team);

                        if (teamCount > winningCount)
                        {
                            winningTeamId = team;
                            winningCount = teamCount;
                        }
                        else if (teamCount == winningCount)
                        {
                            winningTeamId = CapturePoint.ContestedId;
                            winningCount = teamCount;
                        }
                    }

                    return winningTeamId;
                }
            };
        }
    }
}