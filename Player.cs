using System;
using System.Collections.Generic;

namespace test
{

	class Player
	{
		public Weapon Weapon;
		public int Health = 20;
		public void AddWeapon(string weapon)
		{
			var weapons = new Weapons();
			for (int i=0; i < weapons.weaponList.Count; i++)
            {
				if (weapons.weaponList[i].Name == weapon)
                {
					Weapon = weapons.weaponList[i];
                }
            }
			Console.WriteLine($"Your weapon is a {Weapon.Name}.");
		}

		public void AddRandomWeapon()
        {
			var weapons = new Weapons();
			Random rnd = new Random();
			int r = rnd.Next(weapons.weaponList.Count);
			Weapon = weapons.weaponList[r];

			Console.WriteLine($"The enemy's weapon is a {Weapon.Name}.");
		}

		
	}
}
