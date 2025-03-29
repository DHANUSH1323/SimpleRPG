using System;

namespace SimpleRPG.GameEngine
{
    public static class BattleSystem
    {
        public static void StartBattle(Player player, Monster monster)
        {
            Console.WriteLine($"\n⚔️  {player.Name} vs {monster.Name} begins!");
            Console.WriteLine($"🌍 The {monster.Name} appears from the {player.CurrentLocation}!");

            Random rng = new Random();

            while (player.Health > 0 && monster.Health > 0)
            {
                Console.WriteLine("\n🔁 Press Enter to attack...");
                Console.ReadLine();

                // ✅ Player Attack
                int baseDamage = 10 + (player.Level - 1) * 2;
                bool isCrit = rng.Next(100) < 25; // 25% crit chance
                int damageDealt = isCrit ? baseDamage * 2 : baseDamage;

                monster.Health -= damageDealt;
                if (monster.Health < 0) monster.Health = 0;

                Console.WriteLine(isCrit
                    ? $"💥 CRITICAL HIT! {player.Name} dealt {damageDealt} damage!"
                    : $"⚔️ {player.Name} hits {monster.Name} for {damageDealt} damage.");

                Console.WriteLine($"👹 {monster.Name} HP: {monster.Health}");

                // ✅ Monster counterattack
                if (monster.Health > 0)
                {
                    int monsterDamage = 5;
                    player.Health -= monsterDamage;
                    if (player.Health < 0) player.Health = 0;

                    Console.WriteLine($"😈 {monster.Name} strikes back for {monsterDamage} damage!");
                    Console.WriteLine($"🧍 {player.Name} HP: {player.Health}");
                }
            }

            // ✅ Battle outcome
            if (monster.Health <= 0)
            {
                Console.WriteLine($"\n✅ {monster.Name} defeated! You gained {monster.ExperienceReward} XP!");
                player.GainExperience(monster.ExperienceReward);

                int goldReward = rng.Next(10, 21);
                player.Gold += goldReward;
                Console.WriteLine($"💰 You looted {goldReward} gold! Total Gold: {player.Gold}");

                // ✅ Quest progression check
                foreach (var quest in player.ActiveQuests)
                {
                    if (!player.CompletedQuests.Contains(quest) && quest.TargetMonster == monster.Name)
                    {
                        quest.KillCount++;
                        Console.WriteLine($"📜 Quest progress: {quest.Name} ({quest.KillCount}/{quest.KillGoal})");

                        if (quest.KillCount >= quest.KillGoal)
                        {
                            player.CompletedQuests.Add(quest);
                            Console.WriteLine($"✅ Quest complete: {quest.Name}!");

                            player.Gold += quest.GoldReward;
                            Console.WriteLine($"💰 You received {quest.GoldReward} gold!");

                            if (quest.ItemReward != null)
                            {
                                player.Inventory.AddItem(quest.ItemReward);
                                Console.WriteLine($"🎁 You received item: {quest.ItemReward.Name}");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"\n☠️  You were defeated by {monster.Name}...");
            }
        }
    }
}
