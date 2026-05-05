using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    internal class HealItem : Item
    {
        public int Heals { get; private set; }

        public HealItem(int id, int price, string name, string description, int heals)
            : base(id, price, name, description)
        {
            Heals = heals;
        }
    }
}
