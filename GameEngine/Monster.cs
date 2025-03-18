namespace SimpleRPG.GameEngine
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; } = 50;
        public int ExperienceReward { get; set; } = 10;

        public Monster(string name)
        {
            Name = name;
        }
    }
}