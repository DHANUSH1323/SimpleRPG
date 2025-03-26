using System;
using System.Collections.Generic;
using SimpleRPG.GameEngine;

namespace SimpleRPG
{
    class Program
    {
        static void Main()
        {
            Player? player = null;

            // 🧙 Start Menu
            while (player == null)
            {
                Console.WriteLine("🧙 Welcome to the Realm of Consolevania!");
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Load Game");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("What is your name, brave adventurer? ");
                    string playerName = Console.ReadLine();
                    player = new Player(playerName);

                    // Assign starter quests
                    foreach (var quest in QuestManager.GetAvailableQuests())
                    {
                        player.AcceptQuest(quest);
                    }
                }
                else if (choice == "2")
                {
                    player = SaveLoad.LoadGame();

                    if (player == null)
                    {
                        Console.WriteLine("⚠️ No saved game found.");
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("👋 Farewell, traveler.");
                    return;
                }
                else
                {
                    Console.WriteLine("❌ Invalid choice. Try again.");
                }
            }

            // 🎮 Main Game Loop
            while (player.Health > 0)
            {
                Console.WriteLine("\n🧭 What would you like to do?");
                Console.WriteLine("1. Fight a monster");
                Console.WriteLine("2. View quests");
                Console.WriteLine("3. Save game");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    Monster monster = MonsterFactory.GenerateMonster();
                    BattleSystem.StartBattle(player, monster);
                }
                else if (input == "2")
                {
                    Console.WriteLine("\n📜 Active Quests:");
                    if (player.ActiveQuests.Count == 0)
                        Console.WriteLine(" - None");

                    foreach (var quest in player.ActiveQuests)
                    {
                        Console.WriteLine($"- {quest.Name}: {quest.Description}");
                    }

                    Console.WriteLine("\n✅ Completed Quests:");
                    if (player.CompletedQuests.Count == 0)
                        Console.WriteLine(" - None");

                    foreach (var quest in player.CompletedQuests)
                    {
                        Console.WriteLine($"- {quest.Name}");
                    }
                }
                else if (input == "3")
                {
                    SaveLoad.SaveGame(player);
                }
                else if (input == "4")
                {
                    Console.WriteLine("👋 Exiting game...");
                    break;
                }
                else
                {
                    Console.WriteLine("❌ Invalid option. Try again.");
                }
            }

            Console.WriteLine("\n🛑 Game Over. Thanks for playing!");
        }
    }
}