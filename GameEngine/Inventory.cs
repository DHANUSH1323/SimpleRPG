using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace SimpleRPG.GameEngine
{
    public class Inventory
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public void AddItem(Item item)
        {
            Items.Add(item);
            Console.WriteLine($"{item.Name} added to inventory");
        }

        public void ShowInventory()
        {
            Console.WriteLine("🎒 Inventory:");
            if (Items.Count == 0)
            {
                Console.WriteLine(" - (Empty)");
                return;
            }

            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i].Name} ({Items[i].Type})");
            }
        }

        public void UseItem(int index, Player player)
        {
            if (index < 0 || index >= Items.Count)
            {
                Console.WriteLine("❌ Invalid item number.");
                return;
            }

            Item item = Items[index];
            if (item.Type == ItemType.Healing)
            {
                player.Heal(item.Value);
                Items.RemoveAt(index);
                Console.WriteLine($"🧪 Used {item.Name}. You now have {player.Health} HP.");
            }
            else
            {
                Console.WriteLine("❌ This item can’t be used.");
            }
        }
    }
}