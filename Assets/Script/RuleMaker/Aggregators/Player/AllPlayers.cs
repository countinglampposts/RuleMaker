using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Rulemaker
{
    public class AllPlayers : PlayerListAggregator
    {
        public override IEnumerable<PlayerData> Aggregate()
        {
            return FindObjectsOfType(typeof(Player))
                    .Select(o => o as Player)
                    .Select(p => p.playerData);
        }
    }
}