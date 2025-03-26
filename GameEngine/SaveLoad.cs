using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleRPG.GameEngine
{
    public static class SaveLoad
    {
        private static readonly string SavePath = "savegame.json";

        public static void SaveGame(Player player)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            string json = JsonSerializer.Serialize(player, options);
            File.WriteAllText(SavePath, json);
            Console.WriteLine("💾 Game saved successfully!");
        }

        public static Player? LoadGame()
        {
            if (!File.Exists(SavePath))
            {
                Console.WriteLine("❌ No saved game found.");
                return null;
            }

            var options = new JsonSerializerOptions
            {
                IncludeFields = true
            };

            string json = File.ReadAllText(SavePath);
            return JsonSerializer.Deserialize<Player>(json, options);
        }
    }
}