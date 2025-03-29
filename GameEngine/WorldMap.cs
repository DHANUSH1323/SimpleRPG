using System;
using System.Collections.Generic;

namespace SimpleRPG.GameEngine
{
    public static class WorldMap
    {
        public static List<string> Locations = new() { "Village", "Forest", "Cave", "Mountain" };

        public static string Travel(string currentLocation)
        {
            Console.WriteLine("\n🌍 Where do you want to go?");
            for (int i = 0; i < Locations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Locations[i]}");
            }

            Console.Write($"📍 Current location: {currentLocation}\n> ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= Locations.Count)
            {
                string newLocation = Locations[choice - 1];
                Console.WriteLine($"🚶 You travel to {newLocation}.");
                return newLocation;
            }

            Console.WriteLine("❌ Invalid location. Staying put.");
            return currentLocation;
        }
    }
}