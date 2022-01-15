using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Weapon
    {
        public Weapon(string name, int damage, int accuracy)
        {
            this.Name = name;
            this.Damage = damage;
            this.Accuracy = accuracy;
        }

        public string Name;
        public int Damage;
        public int Accuracy;
    }
}
