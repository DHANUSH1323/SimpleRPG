namespace SimpleRPG.GameEngine
{
    public class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int ExperienceReward { get; set; }

        public Monster(string name)
        {
            Name = name;
        }

        // ✅ Add this constructor
        public Monster(string name, int health, int experienceReward)
        {
            Name = name;
            Health = health;
            ExperienceReward = experienceReward;
        }
    }
}