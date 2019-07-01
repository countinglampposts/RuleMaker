using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class TeamData
    {
        public int teamId;
        public Color teamColor;

        public DataCollection dataCollection = new DataCollection();
    }

    public class Team : MonoBehaviour
    {
        [SerializeField] public TeamData teamData;
    }
}