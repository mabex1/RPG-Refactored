using System;
using System.Collections.Generic;
using System.Text;


namespace RPG
{
    internal class Game
    {
        public bool IsGame;
        public void Play()
        {
            EnemysContent enemysContent = new EnemysContent();
            EnemyRandom enemyRandom = new EnemyRandom();
            ItemsContent itemsContent = new ItemsContent();
            ConsoleUI consoleUI = new ConsoleUI();
            FightManager manager = new FightManager();
            Player player = new Player(consoleUI.ConfirmationSetNameUI(), consoleUI);
            Shop shop = new Shop(player);
            player.SetDefaultHeals();
            IsGame = true;
            while (IsGame)
            {
                if (!player.IsAlive())
                {
                    IsGame = consoleUI.IfDies(player);

                    if (IsGame)
                    {
                        player = new Player(consoleUI.ConfirmationSetNameUI(), consoleUI);
                    }

                    continue;
                }

                player.SetEnemy(enemyRandom);
                player.EnemyShow();
                consoleUI.ShowValues(player);
                consoleUI.ShowChoice();
                string input = consoleUI.Choice();
                switch (input)
                {
                    case "1":
                        //fight
                        manager.Fight(player, player.CurrentEnemy, consoleUI);
                        break;
                    case "2":
                        player.Heal(player.healHeals);
                        //heal
                        break;
                    case "3":
                        //shop
                        shop.ShowShop(consoleUI, itemsContent.Weapons, itemsContent.Items);
                        break;
                    case "4":
                        //exit
                        IsGame = false;
                        break;
                }
            }
            return;
        }
    }
}
