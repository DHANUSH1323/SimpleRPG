using System;
using System.Collections.Generic;

namespace SimpleRPG.GameEngine
{
    public class NPC
    {
        public string Name { get; set; }
        public string Dialog { get; set; }
        public List<Item> ShopInventory { get; set; } = new List<Item>();

        public NPC(string name, string dialog)
        {
            Name = name;
            Dialog = dialog;
        }

        public void Talk()
        {
            Console.WriteLine($"\n🧙 {Name}: \"{Dialog}\"");
        }

        public void OpenShop(Player player)
        {
            if (ShopInventory.Count == 0)
            {
                Console.WriteLine("🛒 Sorry, I have nothing to sell right now.");
                return;
            }

            Console.WriteLine($"\n🛒 {Name}'s Shop - What would you like to buy?");
            for (int i = 0; i < ShopInventory.Count; i++)
            {
                var item = ShopInventory[i];
                Console.WriteLine($"{i + 1}. {item.Name} ({item.Type}) - {item.Value} gold");
            }

            Console.WriteLine($"💰 Your gold: {player.Gold}");
            Console.Write("Enter item number to buy or press Enter to cancel: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) &&
                choice >= 1 && choice <= ShopInventory.Count)
            {
                Item itemToBuy = ShopInventory[choice - 1];
                if (player.Gold >= itemToBuy.Value)
                {
                    player.Gold -= itemToBuy.Value;
                    player.Inventory.AddItem(itemToBuy);
                    Console.WriteLine($"✅ You bought {itemToBuy.Name}!");
                }
                else
                {
                    Console.WriteLine("❌ You don't have enough gold.");
                }
            }
            else
            {
                Console.WriteLine("❌ Cancelled or invalid input.");
            }
        }
    }
}