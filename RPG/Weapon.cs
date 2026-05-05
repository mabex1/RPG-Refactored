using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    internal class Weapon : Item
    {
        public int Damage { get; private set; }
        public string Description { get; private set; }

        public Weapon(int id, int price, string name, int damage, string description)
            :base(id, price, name, description)
        {
            Damage = damage;
            Description = description;
        }
    }
}
