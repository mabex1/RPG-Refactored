using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace RPG
{
    internal class Enemy
    {
        public int HP { get; protected set; }
        public int MaxHP { get; private set; }
        public int Attack {  get; private set; }
        public string Name { get; private set; }
        public int ArmorIgnoring {  get; private set; } /*задел на будущее*/
        protected ConsoleUI consoleUI = new ConsoleUI();

        virtual public void TakeDamage(int damage)
        {
            HP -= damage;
            consoleUI.TakeDamageEnemy(this);
        }

        public Enemy(int thisHP, int thismaxHP, int thisattack, string thisname, int thisarmorignoring)
        {
            HP = thisHP;
            MaxHP = thismaxHP;
            Attack = thisattack;
            Name = thisname;
            ArmorIgnoring = thisarmorignoring;
        }

        public Enemy Clone()
        {
            return new Enemy(MaxHP, HP, Attack, Name, ArmorIgnoring);
        }
    }

    class Ghost : Enemy
    {
        override public void TakeDamage(int damage)
        {
            int Rand = Random.Shared.Next(0, 11);
            if (Rand >= 3)
            {
                //логика уклонения в будущем
                consoleUI.EnemyGhostDodge(this); 
            }
            else
            {
                HP -= damage;
                consoleUI.TakeDamageEnemy(this); //в будущем уберу полностью consoleui из всех классов кроме Game.cs. чтобы как бы эти классы просто отдавали файлы не знали про ui.
            }
        }

        public Ghost()
            : base(40, 40, 12, "Теневой призрак", 10)
        {

        }
    }
}
