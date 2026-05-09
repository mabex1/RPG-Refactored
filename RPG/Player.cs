using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    internal class Player
    {
        public int HP { get; private set; }
        public int MaxHP { get; private set; }
        public Weapon weapon { get; set; }
        public string? Name { get; private set; }
        public int gold { get; private set; }
        public int HealCount { get; private set; }
        public int healHeals = 20;
        private int DefaultHealCount = 5;
        //private ConsoleUI consoleUI = new ConsoleUI();
        private ConsoleUI consoleUI;
        public Enemy CurrentEnemy {  get; private set; }


        private List<Item> inventory = new List<Item>();

        public Player(string name, ConsoleUI ui)
        {
            Name = name;
            HP = 100;
            MaxHP = 100;
            gold = 99999;
            consoleUI = ui;
            weapon = new Weapon(0, 0, "Ржавый кинжал", 10, "Всё легенды откуда-то начинали.");
        }

        public void TakeDamage(int damage)
        {
            HP -= damage;
            consoleUI.TakeDamagePlayer(CurrentEnemy);
        }

        public void AddGold(int amount)
        {
            gold += amount;
        }

        public void AddHeal(int amount)
        {
            HealCount++;
        }

        public bool CanBuy(int price)
        {
            if (gold >= price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsAlive()
        {
            if (HP <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Heal(int currentHeal)
        {
            if (HealCount > 0)
            {
                if (HP == MaxHP)
                {
                    consoleUI.HealMaxHP();
                    return false;
                }
                else
                {
                    HP = Math.Min(HP + currentHeal, MaxHP);
                    HealCount--;
                    consoleUI.HealSuccessful(this);
                    return true;
                }
            }
            else
            {
                consoleUI.NoHeal();
                return false;
            }
        }

        public void SetDefaultHeals()
        {
            HealCount = DefaultHealCount;
        }

        public void SetEnemy(EnemyRandom enemyRandom)
        {
            if (CurrentEnemy == null || CurrentEnemy.HP <= 0)
            {
                CurrentEnemy = enemyRandom.Randomizer();
                consoleUI.EnemySet(CurrentEnemy);
                //Здесь будет вызов рандомзатора монстров из списка. 
            }
        }

        public void EnemyShow()
        {
            consoleUI.EnemyShow(CurrentEnemy);
        }

        public void Buy(int price)
        {
            gold -= price;
        }

        public void SetWeapon(Weapon buyedweapon)
        {
            weapon = buyedweapon;
        }

        public void SetCurrentEnemyNull()
        {
            CurrentEnemy = null;
        }
    }
}
