namespace SimpleRPG.GameEngine
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; } = 100;
        public int Experience { get; set; } = 0;
        public int Level { get; set; } = 1;
        public Inventory Inventory { get; set; } = new Inventory();
        public Player(string name)
        {
            Name = name;
        }

    }
}