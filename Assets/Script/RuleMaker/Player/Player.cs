using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
    [System.Serializable]
    public class PlayerData : ITeamOwned
    {
        public int teamId;

        [HideInInspector]
        public string id;
        [HideInInspector]
        public Vector3 postion;

        public Dictionary<string, object> data;

        public int GetTeamId()
        {
            return teamId;
        }
    }

    public class Player : MonoBehaviour
    {
        [SerializeField] Renderer renderer;
        [SerializeField] public PlayerData playerData;

        private void Awake()
        {
            playerData.id = gameObject.name;
        }

        private void Start()
        {
            var teamColor = TeamUtils.GetAllTeams().GetData()
                .First(team => team.teamId == playerData.teamId).teamColor;

            renderer.material.color = teamColor;
        }

        private void Update()
        {
            playerData.postion = transform.position;
        }
    }
}