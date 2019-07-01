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
    }
}