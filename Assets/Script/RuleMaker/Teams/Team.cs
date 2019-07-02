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

    /// <summary>
    /// This is used to represent a team
    /// </summary>
    public class Team : MonoBehaviour
    {
        [SerializeField] public TeamData teamData;
    }
}