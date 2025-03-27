namespace SimpleRPG.GameEngine
{
    public enum ItemType
    {
        Healing,
        Weapon,
        Armor
    }

    public class Item
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }  // ✅ For potion vs weapon
        public int Value { get; set; }      // ✅ For gold cost (in shop) or effect amount (in inventory)

        public Item() { }

        public Item(string name, ItemType type, int value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}