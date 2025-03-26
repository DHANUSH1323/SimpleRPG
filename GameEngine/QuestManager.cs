using System.Collections.Generic;

namespace SimpleRPG.GameEngine
{
    public static class QuestManager
    {
        public static List<Quest> GetAvailableQuests()
        {
            return new List<Quest>
            {
                new Quest("First Blood", "Win your first battle", 30),
                new Quest("Monster Hunter", "Defeat 3 monsters", 60)
            };
        }
    }
}