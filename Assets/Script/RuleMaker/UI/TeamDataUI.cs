using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Rulemaker
{
    public class TeamDataUI : MonoBehaviour
    {
        [System.Serializable]
        private class Settings
        {
            public string key;
            public int teamId;
        }

        [SerializeField] Text text;
        [SerializeField] Settings settings;

        public void Start()
        {
            text.color = TeamUtils.GetAllTeams().GetData()
                .First(team => team.teamId == settings.teamId)
                .teamColor;

            TeamUtils.GetAllTeams()
                .Select(teams => teams.First(team => team.teamId == settings.teamId).dataCollection.GetData(settings.key)?.ToString())
                .OnDataChanged()
                .OnDo(value => text.text = value);
        }
    }
}