using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Combat
    {
        public void CombatRound(Player hero, Player enemy, Boolean playerTurn, Boolean firstTurn, ref string[] combatLog, int i)
        {
            Random rnd = new Random();

            if (playerTurn)
            {
                Console.WriteLine("You attack!");
                int r = rnd.Next(99);
                if (r < hero.Weapon.Accuracy)
                {
                    Console.WriteLine($"Your {hero.Weapon.Name} does {hero.Weapon.Damage} damage to the enemy!");
                    enemy.Health -= hero.Weapon.Damage;
                    if (firstTurn == true) 
                    {
                        combatLog[i] = hero.Weapon.Damage.ToString() + ",";
                    }
                    else 
                    {
                        combatLog[i-1] = hero.Weapon.Damage.ToString() + ",";
                    }
                }
                else
                {
                    Console.WriteLine("You missed!");
                    if (firstTurn == true) 
                    {
                        combatLog[i] = "0,";
                    }
                    else 
                    {
                        combatLog[i-1] = "0,";
                    }
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
                    if (firstTurn == false) 
                    {
                        combatLog[i+1] = enemy.Weapon.Damage.ToString() + ",";
                    }
                    else 
                    {
                        combatLog[i] = enemy.Weapon.Damage.ToString() + ",";
                    }
                }
                else
                {
                    Console.WriteLine("The enemy missed!");
                    if (firstTurn == false) 
                    {
                        combatLog[i+1] = "0,";
                    }
                    else 
                    {
                        combatLog[i] = "0,";
                    }
                }
            }
        }
    }
}
