using System.Runtime;
using System.Text.Json.Serialization;

namespace SimpleRPG.GameEngine
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public int Experience { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int Gold { get; set; } = 100; // Start with some gold

        [JsonInclude]
        public List<Quest> ActiveQuests { get; set; } = new List<Quest>();

        [JsonInclude]
        public List<Quest> CompletedQuests { get; set; } = new List<Quest>();

        [JsonInclude]
        public Inventory Inventory { get; set; } = new Inventory();
        public Player() { }
        public Player(string name)
        {
            Name = name;
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"{Name} gained {amount} XP!");

            if (Experience >= Level * 100)
            {
                LevelUp();
            }
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100)
            {
                Health = 100;
            }

            Console.WriteLine($"❤️ {Name} healed for {amount} HP. Current Health: {Health}");
        }

        private void LevelUp()
        {
            Level++;
            Experience = 0;
            Health += 20;

            Console.WriteLine($"🎉 {Name} leveled up to Level {Level}!");
            Console.WriteLine($"❤️ Health increased to {Health}.\n");
        }

        public void AcceptQuest(Quest quest)
        {
            ActiveQuests.Add(quest);
            Console.WriteLine($"\n📝 New Quest: {quest.Name} - {quest.Description}");
        }
    }
}