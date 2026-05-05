using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    internal class Item
    {
        public int ID { get; private set; }
        public int Price { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Item(int thisID, int thisPrice, string thisName, string description)
        {
            ID = thisID;
            Price = thisPrice;
            Name = thisName;
            Description = description;
        }


    }
}
