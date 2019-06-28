using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    public class AllTeams : TeamAggregator
    {
        public override IEnumerable<TeamData> Aggregate()
        {
            return RulemakerUtils.GetAllTeams();
        }
    }
}