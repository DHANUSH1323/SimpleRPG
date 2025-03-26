using System.Runtime;

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

        public void GainExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"{Name} gained {amount} XP!");

            if (Experience >= Level * 100)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;
            Experience = 0;
            Health += 20;

            Console.WriteLine($"🎉 {Name} leveled up to Level {Level}!");
            Console.WriteLine($"❤️ Health increased to {Health}.\n");
        }

    }
}