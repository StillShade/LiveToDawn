using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Character
{
    public class CharacterStatsUI : MonoBehaviour
    {
        [System.Serializable]
        public class StatUIEntry
        {
            public CharacterStatType stat;
            public Text valueText;
        }

        [SerializeField] private CharacterStats characterStats;
        [SerializeField] private List<StatUIEntry> statUIEntries;

        private Dictionary<CharacterStatType, Text> statTextMap = new();

        private void Start()
        {
            foreach (var entry in statUIEntries)
            {
                statTextMap[entry.stat] = entry.valueText;
                UpdateStatUI(entry.stat, characterStats.GetStatValue(entry.stat));
            }

            characterStats.OnStatChanged += UpdateStatUI;
        }

        private void UpdateStatUI(CharacterStatType stat, int newValue)
        {
            if (statTextMap.TryGetValue(stat, out Text text))
            {
                text.text = newValue.ToString();
            }
        }
    }
}