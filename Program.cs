using System;
using System.Collections.Generic;
using System.IO;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Player newPlayer = new Player();
            Player enemy = new Player();

            var writer = File.AppendText("combatlog.txt");
            string[] combatLog = new string[50];
            Array.Fill(combatLog,"NA,");

            string weapon = "";
            Boolean flag = false;

            StartingText();

            //ValidateInput(ref weapon, ref flag);

            //newPlayer.AddWeapon(weapon);
            newPlayer.AddRandomWeapon();
            combatLog[0] = newPlayer.Weapon.Name + ",";

            Console.WriteLine("The enemy will now choose his weapon.");
            enemy.AddRandomWeapon();
            combatLog[1] = enemy.Weapon.Name + ",";

            bool firstTurn = DecideStartingPlayer();
            bool turn = firstTurn;
            
            EngageinCombat(newPlayer, enemy, turn, firstTurn, ref combatLog);

            if (newPlayer.Health <= 0) { Console.WriteLine("The enemy has won!"); }
            else { Console.WriteLine("You have won!"); }

            string combinedString = string.Join("",combatLog);
            writer.WriteLine(combinedString, "combatlog.txt");
            writer.Close();

        }

        private static void EngageinCombat(Player newPlayer, Player enemy, bool turn, bool firstTurn, ref string[] combatLog)
        {
            Combat combat = new Combat();
            int i = 2;

            while (newPlayer.Health > 0 && enemy.Health > 0)
            {
                combat.CombatRound(newPlayer, enemy, turn, firstTurn, ref combatLog, i);
                turn = !turn;
                i += 1;
                if (newPlayer.Health > 0 && enemy.Health > 0)
                {
                    var flag = false;
                    //CombatBreak(ref flag);
                }
            }
        }

        private static void ValidateInput(ref string weapon, ref bool flag)
        {
            while (!flag)
            {
                weapon = Console.ReadLine();
                Weapons weapons = new Weapons();
                for (int i = 0; i < weapons.weaponList.Count; i++)
                {
                    if (weapons.weaponList[i].Name == weapon)
                    {
                        flag = true;
                    }

                }
                if (!flag)
                {
                    Console.WriteLine("That is not a valid weapon. Please try again.");
                }
            }

            flag = false;
        }

        private static void StartingText()
        {
            Console.WriteLine("Hello! Please enter the weapon you'd like your player to have.");
            Console.WriteLine("Your options are:");
            Console.WriteLine("Dagger: Damage 2, Accuracy 100%");
            Console.WriteLine("Ice Pick: Damage 3, Accuracy 95%");
            Console.WriteLine("Wand: Damage 4, Accuracy 90%");
            Console.WriteLine("Pistol: Damage 5, Accuracy 85%");
            Console.WriteLine("Sword: Damage 6, Accuracy 80%");
            Console.WriteLine("Axe: Damage 7, Accuracy 75%");
            Console.WriteLine("Mace: Damage 8, Accuracy 70%");
            Console.WriteLine("Warhammer: Damage 9, Accuracy 65%");
        }

        private static void CombatBreak(ref bool flag)
        {
            while (!flag)
            {
                Console.WriteLine("Enter 'c' to continue.");
                var letter = Console.ReadLine();
                if (letter == "c")
                {
                    flag = true;
                }
                if (!flag)
                {
                    Console.WriteLine("That is not a valid option. Please try again.");
                }
            }

            flag = false;
        }
    
        private static bool DecideStartingPlayer() 
        {
            Random rnd = new Random();
            int r = rnd.Next(99);
            if (r < 50) 
            { 
                Console.WriteLine("Player will go first!");
                return true; 
            }
            else 
            { 
                Console.WriteLine("Enemy will go first");
                return false; 
            }
        }
    }
}
