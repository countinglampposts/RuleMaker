using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace RuleMaker
{
    [CustomEditor(typeof(GameController))]
    public class GameEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var printedString = (target as GameController).PrintGameState();
            GUILayout.Label(printedString);
        }
    }
}