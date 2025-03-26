using System;
using System.Collections.Generic;

namespace SimpleRPG.GameEngine
{
    public static class MonsterFactory
    {
        private static readonly List<Monster> monsters = new()
        {
            new Monster("Goblin") { Health = 30, ExperienceReward = 10},
            new Monster("Orc") {Health = 50, ExperienceReward = 20},
            new Monster("Troll") {Health = 70, ExperienceReward = 30},
            new Monster("Dark Elf") {Health = 60, ExperienceReward = 25},
        };

        private static readonly Random rng = new();

        public static Monster GenerateMonster()
        {
            int index = rng.Next(monsters.Count);
            Monster baseMonster = monsters[index];

            return new Monster(baseMonster.Name)
            {
                Health = baseMonster.Health,
                ExperienceReward = baseMonster.ExperienceReward
            };
        }
    }
}