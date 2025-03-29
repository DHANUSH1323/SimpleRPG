using System;
using System.Collections.Generic;

namespace SimpleRPG.GameEngine
{
    public static class MonsterFactory
    {
        private static readonly List<Monster> monsters = new()
        {
            new Monster("Goblin") { Health = 30, ExperienceReward = 10 },
            new Monster("Orc") { Health = 50, ExperienceReward = 20 },
            new Monster("Troll") { Health = 70, ExperienceReward = 30 },
            new Monster("Dark Elf") { Health = 60, ExperienceReward = 25 },
        };

        private static readonly Random rng = new();

        public static Monster GenerateMonster(string location)
        {
            return location switch
            {
                "Forest" => new Monster("Goblin", 50, 15),
                "Cave" => new Monster("Orc", 70, 25),
                "Mountain" => new Monster("Troll", 90, 35),
                "Village" => new Monster("Drunk Villager", 30, 5),
                _ => new Monster("Slime", 40, 10),
            };
        }
    }
}