using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public static class PlayerUtils
    {
        public static IAggregator<IEnumerable<PlayerData>> GetAllPlayers()
        {
            return new Aggregator<IEnumerable<PlayerData>>
            {
                getData = () => GameObject.FindObjectsOfType(typeof(Player))
                    .Select(o => o as Player)
                    .Select(p => p.playerData)
            };
        }

        public static IAggregator<IEnumerable<PlayerData>> PlayersWithinRadius(this IAggregator<IEnumerable<PlayerData>> aggregator, RadiusParams param)
        {
            return new Aggregator<IEnumerable<PlayerData>>
            {
                getData = () => aggregator.GetData()
                    .Where(player => Vector3.Distance(player.postion, param.transform.position) < param.radius)
            };
        }

        public static IAggregator<int> MajorityTeamId(this IAggregator<IEnumerable<PlayerData>> aggregator)
        {
            return new Aggregator<int>
            {
                getData = () =>
                {
                    var playerList = aggregator.GetData();

                    if (!playerList.Any())
                        return CapturePoint.UnclaimedId;

                    var teams = playerList
                        .Select(player => player.teamId)
                        .Distinct();

                    int winningTeamId = CapturePoint.UnclaimedId;
                    int winningCount = -1;

                    foreach (var team in teams)
                    {
                        int teamCount = playerList
                            .Count(player => player.teamId == team);
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

                    //Debug.Log("Winning: " + winningTeamId);
                    return winningTeamId;
                }
            };
        }
    }
}