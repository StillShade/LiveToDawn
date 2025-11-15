using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Character
{
    public static class CharacterStatsSaver
    {
        private static string SaveFilePath => Path.Combine(Application.persistentDataPath, "character_stats.json");

        public static void Save(Dictionary<CharacterStatType, int> stats)
        {
            CharacterStatsData data = new CharacterStatsData
            {
                stats = new Dictionary<CharacterStatType, int>(stats)
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(SaveFilePath, json, Encoding.UTF8);

            Debug.Log($"[CharacterStatsSaver] Сохранено в: {SaveFilePath}");
        }

        public static Dictionary<CharacterStatType, int> Load()
        {
            if (!File.Exists(SaveFilePath))
            {
                Debug.Log("[CharacterStatsSaver] Файл не найден.");
                return null;
            }

            string json = File.ReadAllText(SaveFilePath, Encoding.UTF8);
            CharacterStatsData data = JsonConvert.DeserializeObject<CharacterStatsData>(json);

            Debug.Log("[CharacterStatsSaver] Загружено из файла.");
            return data?.stats;
        }
    }
}