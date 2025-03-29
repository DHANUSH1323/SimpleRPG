using System.Text.Json.Serialization;

namespace SimpleRPG.GameEngine
{
    public class Quest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int RewardXP { get; set; }
        public string TargetMonster { get; set; }
        public int KillGoal { get; set; }
        public int KillCount { get; set; } = 0;
        public int GoldReward { get; set; } = 0;
        public Item? ItemReward { get; set; }
        public Quest() { }  // Required for deserialization

        public Quest(string name, string description, int rewardXP)
        {
            Name = name;
            Description = description;
            RewardXP = rewardXP;
        }

        public void Complete(Player player)
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                Console.WriteLine($"\n🏆 Quest Complete: {Name}!");
                player.GainExperience(RewardXP);
            }
        }
    }
}