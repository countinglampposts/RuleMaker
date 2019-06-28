using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class PlayerData
    {
        public int teamId;

        [HideInInspector]
        public string id;
        [HideInInspector]
        public Vector3 postion;
    }

    public abstract class PlayerListAggregator : MonoBehaviour, IAggregator
    {
        public object AggregateObject()
        {
            return Aggregate();
        }

        public abstract IEnumerable<PlayerData> Aggregate();
    }
}