﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class TeamData
    {
        public int teamId;
        public Color teamColor;
    }

    public abstract class TeamAggregator : MonoBehaviour
    {
        public abstract IEnumerable<TeamData> Aggregate();
    }
}