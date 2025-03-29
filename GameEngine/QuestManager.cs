using System.Collections.Generic;

namespace SimpleRPG.GameEngine
{
    public static class QuestManager
    {
        public static List<Quest> GetAvailableQuests()
        {
            return new List<Quest>
            {
                new Quest
                {
                    Name = "Goblin Slayer",
                    Description = "Defeat 3 Goblins in the Forest.",
                    TargetMonster = "Goblin",
                    KillGoal = 3,
                    GoldReward = 50,
                    ItemReward = new Item("Greater Healing Potion", ItemType.Healing, 50)
                },
                new Quest
                {
                    Name = "Orc Basher",
                    Description = "Defeat 2 Orcs in the Cave.",
                    TargetMonster = "Orc",
                    KillGoal = 2,
                    GoldReward = 75
                }
            };
        }
    }
}