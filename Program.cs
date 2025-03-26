using System;
using SimpleRPG.GameEngine;

namespace SimpleRPG
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("🧙 Welcome to the Realm of Consolevania!");
            Console.Write("What is your name, brave adventurer? ");
            string playerName = Console.ReadLine();

            Player player = new Player(playerName);

            while (player.Health > 0)
            {
                Monster monster = MonsterFactory.GenerateMonster();
                BattleSystem.StartBattle(player, monster);

                Console.WriteLine("\n➡️ Do you want to fight again? (y/n)");
                string input = Console.ReadLine();
                if (input?.ToLower() != "y")
                    break;
            }

            Console.WriteLine("\n🛑 Game Over. Thanks for playing!");
        }
    }
}