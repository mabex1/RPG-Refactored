using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    internal class ItemsContent
    {
        private List<Weapon> weapons = new List<Weapon>();
        public IReadOnlyList<Weapon> Weapons => weapons;
        private List<Item> items = new List<Item>();
        public IReadOnlyList<Item> Items => items;

        public ItemsContent()
        {
            //добавляем оружия
            weapons.Add(new Weapon(1, 15, "Железный меч", 15, "Вы его уже видели. В других играх. "));
            weapons.Add(new Weapon(2, 50, "Боевой топор", 25, "Медленный. но с удара мало не покажется."));
            weapons.Add(new Weapon(3, 100, "Клинок авантюриста", 40, "Оружие тех, кто прошёл слишком много боёв, чтобы останавливаться."));

            //добавляем предметы
            items.Add(new HealItem(1, 10, "Бинт", $"Восстанавливает 20 здоровья", 20));
        }
    }
}
