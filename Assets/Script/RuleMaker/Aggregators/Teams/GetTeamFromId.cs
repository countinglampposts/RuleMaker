using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public class GetTeamFromId : TeamAggregator
    {
        [SerializeField] TeamAggregator source;
        [SerializeField] IntAggregator idSource;

        public override IEnumerable<TeamData> Aggregate()
        {
            int teamId = idSource.Aggregate();
            return source.Aggregate()
                .Where(team => team.teamId == teamId);
        }
    }
}