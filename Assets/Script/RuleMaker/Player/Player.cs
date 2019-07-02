using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class PlayerData : ITeamOwned, IPositoned
    {
        public int teamId;
        [HideInInspector]
        public Vector3 postion;

        public DataCollection dataCollection = new DataCollection();

        public Vector3 GetPosition()
        {
            return postion;
        }

        public int GetTeamId()
        {
            return teamId;
        }
    }

    /// <summary>
    /// This is used to track the player. It should be attached to the player.
    /// </summary>
    public class Player : MonoBehaviour
    {
        [SerializeField] Renderer renderer;
        [SerializeField] public PlayerData playerData;

        private void Start()
        {
            var teamColor = TeamUtils.GetTeamColor(playerData.teamId);

            renderer.material.color = teamColor;
        }

        private void Update()
        {
            playerData.postion = transform.position;
        }
    }
}