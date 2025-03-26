using System;

namespace SimpleRPG.GameEngine
{
    public static class BattleSystem
    {
        public static void StartBattle(Player player, Monster monster)
        {
            Console.WriteLine($"\n {player.Name} vs {monster.Name} begins!");

            while (player.Health > 0 && monster.Health > 0)
            {
                Console.WriteLine("\n Press Enter to attack");
                Console.ReadLine();

                monster.Health -= 10;
                Console.WriteLine($"{player.Name} hits {monster.Name} for damage 10");

                if (monster.Health > 0)
                {
                    player.Health -= 5;
                    Console.WriteLine($"{monster.Name} bites back for 5 damage");
                }
                Console.WriteLine($"{player.Name}: {player.Health} HP\n {monster.Name}:{monster.Health} HP");
            }

            if (monster.Health <= 0)
            {
                Console.WriteLine($"\n {monster.Name} defeated! you gained{monster.ExperienceReward} XP!");
                player.GainExperience(monster.ExperienceReward);
            }
            else
            {
                Console.WriteLine($"\n You were defeated by {monster.Name} ...");
            }
        }
    }
}