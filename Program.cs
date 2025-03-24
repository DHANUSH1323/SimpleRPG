using System;
using SimpleRPG.GameEngine;

namespace SimpleRPG
{
    class Program
    {
        static void Main()
        {
            Player hero = new Player("Dhanush");
            Console.WriteLine($"Welcome, {hero.Name}!");

            Item sword = new Item("⚔️ Steel Sword");  // ✅ Creates a new Item
            hero.Inventory.AddItem(sword);  // ✅ Adds item to inventory

            hero.Inventory.ShowInventory();  // ✅ Shows all items
        }
    }
}