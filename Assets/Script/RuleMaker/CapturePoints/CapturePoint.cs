using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rulemaker
{
    public class CapturePoint : MonoBehaviour
    {
        [SerializeField] Renderer renderer;

        public void SetWinner(TeamData teamData)
        {
            renderer.material.color = teamData.teamColor;
        }

        public void SetNeutral()
        {
            renderer.material.color = Color.white;
        }
    }
}