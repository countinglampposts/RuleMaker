using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RuleMaker
{
    public struct GameState
    {
        private Dictionary<string, string> vars;

        public string GetGameVar(string varName)
        {
            if (vars == null)
                vars = new Dictionary<string, string>();

            if (vars.ContainsKey(varName))
                return vars[varName];
            else
            {
                Debug.LogError("Could not find property with key " + varName);
                return string.Empty;
            }
        }

        public void SetGameVar(string varName, string varValue)
        {
            vars[varName] = varValue;
        }

        public override string ToString()
        {
            var returned = "GameState\n";

            if (vars == null)
                return string.Empty;

            foreach (var a in vars)
            {
                returned += "Key: " + a.Key + " Value: " + a.Value + "\n";
            }

            return returned;
        }
    }
}