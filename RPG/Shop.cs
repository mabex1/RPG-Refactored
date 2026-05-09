using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    internal class Shop
    {
        public bool InShop = true;
        private readonly Player _player;

        public Shop(Player player)
        {
            _player = player;
        }

        public void ShowShop(ConsoleUI consoleUI, IReadOnlyList<Weapon> weapons, IReadOnlyList<Item> items)
        {
            while (InShop)
            {
                consoleUI.ShowValues(_player);
                consoleUI.ShowShop();

                switch (consoleUI.SelectAct())
                {
                    case "1":
                        ShowItemsChoice(consoleUI, weapons, items);
                        break;
                    case "2":
                        consoleUI.WarnNoDialogues(); // <- ЛЕНЬ ДЕЛАТЬ ДИАЛОГИ
                        break;
                    case "3":
                        InShop = false;
                        break;
                }

            }
        }

        public void ShowItemsChoice(ConsoleUI consoleUI, IReadOnlyList<Weapon> weapons, IReadOnlyList<Item> items)
        {
            consoleUI.ShowValues(_player);
            consoleUI.ShowItemsChoice();
            switch (consoleUI.SelectAct())
            {
                case "1":
                    ShowWeapons(consoleUI, weapons); break;
                case "2":
                    ShowItems(consoleUI, items); break;
                case "3":
                    break;
            }
        }

        private void ShowWeapons(ConsoleUI consoleUI, IReadOnlyList<Weapon> weapons)
        {
            consoleUI.ShowValues(_player);
            consoleUI.ShowWeapons(weapons);
            Weapon select = consoleUI.SelectWeapon(weapons);
            if (_player.CanBuy(select.Price))
            {
                _player.Buy(select.Price);
                _player.SetWeapon(select);
                consoleUI.SuccesfulBuy(select);
            }
            else
            {
                consoleUI.BadBuy(select);
            }

        }

        private void ShowItems(ConsoleUI consoleUI, IReadOnlyList<Item> items)
        {
            consoleUI.ShowValues(_player);
            consoleUI.ShowItems (items);
            Item select = consoleUI.SelectItem(items);
            if (_player.CanBuy(select.Price))
            {
                _player.Buy(select.Price);
                consoleUI.SuccesfulBuy(select);
                if (select.GetType() == typeof(HealItem))
                {
                    _player.AddHeal(select.Price);
                }
                else if (select.GetType() == typeof(ItemEndGame))
                {
                    consoleUI.GameEnd(_player);
                    Environment.Exit(0);
                }
                else
                {
                    consoleUI.WarnItemTypeNotExists();
                    consoleUI.BadBuy(select);
                }
            }

        }
    }
}
