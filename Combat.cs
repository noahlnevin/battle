using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Combat
    {
        public string CombatRound(Player hero, Player enemy, Boolean playerTurn)
        {
            Random rnd = new Random();
            string combatLog = "";

            if (playerTurn)
            {
                Console.WriteLine("You attack!");
                int r = rnd.Next(99);
                if (r < hero.Weapon.Accuracy)
                {
                    Console.WriteLine($"Your {hero.Weapon.Name} does {hero.Weapon.Damage} damage to the enemy!");
                    enemy.Health -= hero.Weapon.Damage;
                    combatLog += hero.Weapon.Damage.ToString() + ",";
                }
                else
                {
                    Console.WriteLine("You missed!");
                    combatLog += "0,";
                }
            }

            else
            {
                Console.WriteLine("The enemy attacks!");
                int r = rnd.Next(99);
                if (r < enemy.Weapon.Accuracy)
                {
                    Console.WriteLine($"The enemy's {enemy.Weapon.Name} does {enemy.Weapon.Damage} damage to you!");
                    hero.Health -= enemy.Weapon.Damage;
                    combatLog += enemy.Weapon.Damage.ToString() + ",";
                }
                else
                {
                    Console.WriteLine("The enemy missed!");
                    combatLog += "0,";
                }
            }

            return combatLog;

        }
    }
}
