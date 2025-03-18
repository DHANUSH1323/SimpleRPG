using System.Collections.Generic;

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
            Console.WriteLine("Inventory");
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
    }
}