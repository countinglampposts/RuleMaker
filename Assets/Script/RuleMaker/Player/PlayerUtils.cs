using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    /// <summary>
    /// Implement this to any object that has a position
    /// </summary>
    public interface IPositoned
    {
        Vector3 GetPosition();
    }

    public static class PlayerUtils
    {
        /// <summary>
        /// Gets all players in the game. This list can be further refined using Linq
        /// </summary>
        public static IAggregator<IEnumerable<PlayerData>> GetAllPlayers()
        {
            return new Aggregator<IEnumerable<PlayerData>>
            {
                getData = () => GameObject.FindObjectsOfType(typeof(Player))
                    .Select(o => o as Player)
                    .Select(p => p.playerData)
            };
        }

        /// <summary>
        /// Will filter the list of IPositioned objects based on whether they are within distance
        /// </summary>
        /// <returns>Objects within the radius of the transform</returns>
        /// <param name="param">The parameter object</param>
        public static IAggregator<IEnumerable<T>> WithinRadius<T>(this IAggregator<IEnumerable<T>> aggregator, RadiusParams param) where T : IPositoned
        {
            return new Aggregator<IEnumerable<T>>
            {
                getData = () => aggregator.GetData()
                    .Where(positioned => Vector3.Distance(positioned.GetPosition(), param.transform.position) < param.radius)
            };
        }
    }
}