using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rulemaker
{
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
            var teamColor = RulemakerUtils.GetAllTeams()
                .First(team => team.teamId == playerData.teamId).teamColor;

            renderer.material.color = teamColor;
        }

        private void Update()
        {
            playerData.postion = transform.position;
        }
    }
}