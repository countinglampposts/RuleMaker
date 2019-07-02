using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    /// <summary>
    /// Add this to any object that can be team owned
    /// </summary>
    public interface ITeamOwned
    {
        int GetTeamId();
    }

    public static class TeamUtils
    {
        /// <summary>
        /// Get all the teams
        /// </summary>
        public static IAggregator<IEnumerable<TeamData>> GetAllTeams()
        {
            return new Aggregator<IEnumerable<TeamData>>
            {
                getData = () => GameObject.FindObjectsOfType(typeof(Team))
                       .Select(o => o as Team)
                       .Select(t => t.teamData)
            };
        }

        /// <summary>
        /// Converts a team id to its TeamData object. If it is invalid, it will return null
        /// </summary>
        public static IAggregator<TeamData> GetTeamFromId(this IAggregator<int> teamId)
        {
            return new Aggregator<TeamData>()
            {
                getData = () => GetAllTeams().GetData()
                    .FirstOrDefault(team => team.teamId == teamId.GetData())
            };
        }

        /// <summary>
        /// Returns the majority team's id. 0 represents unclaimed and -1 represents contested
        /// </summary>
        /// <returns>The team identifier.</returns>
        public static IAggregator<int> MajorityTeamId<T>(this IAggregator<IEnumerable<T>> aggregator) where T : ITeamOwned
        {
            return new Aggregator<int>
            {
                getData = () =>
                {
                    var teamOwnedList = aggregator.GetData();

                    if (!teamOwnedList.Any())                       // If there is nothing in the of team owned objects, then it is unclaimed
                        return CapturePoint.UnclaimedId;

                    var teams = teamOwnedList                       // Gets the list of teams
                        .Select(teamOwned => teamOwned.GetTeamId())
                        .Distinct();

                    int winningTeamId = CapturePoint.UnclaimedId;
                    int winningCount = -1;

                    foreach (var team in teams)
                    {
                        if (team < 1)                               // Filter out contested and unclaimed team
                            continue;

                        int teamCount = teamOwnedList
                            .Count(teamOwned => teamOwned.GetTeamId() == team);

                        if (teamCount > winningCount)
                        {
                            winningTeamId = team;
                            winningCount = teamCount;
                        }
                        else if (teamCount == winningCount)         // If there are more than one objects with a winning count, then it is contested
                        {
                            winningTeamId = CapturePoint.ContestedId;
                            winningCount = teamCount;
                        }
                    }

                    return winningTeamId;
                }
            };
        }

        /// <summary>
        /// Use this to get the team color using the team is
        /// </summary>
        /// <returns>The team color.</returns>
        public static Color GetTeamColor(int teamId)
        {
            var returned = Color.white;

            var teamData = TeamUtils.GetAllTeams().GetData()
                .FirstOrDefault(team => team.teamId == teamId);
            if (teamData != null)
                returned = teamData.teamColor;

            return returned;
        }
    }
}