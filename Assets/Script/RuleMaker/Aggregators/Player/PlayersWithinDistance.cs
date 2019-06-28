using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public class PlayersWithinDistance : PlayerListAggregator
    {
        [System.Serializable]
        private class Settings
        {
            public float distance;
        }

        [SerializeField] Settings settings;
        [SerializeField] PlayerListAggregator source;

        public override IEnumerable<PlayerData> Aggregate()
        {
            return source.Aggregate()
                .Where(data => Vector3.Distance(data.postion, transform.position) < settings.distance);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, settings.distance);
        }
    }
}