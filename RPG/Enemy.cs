using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        private const int GHOST_MAX_DODGE_CHANCE = 11;
        private const int GHOST_MIN_DODGE_CHANCE = 0;
        private const int GHOST_SUCCESS_DODGE = 3;
        override public void TakeDamage(int damage)
        {
            int Rand = Random.Shared.Next(GHOST_MIN_DODGE_CHANCE, GHOST_MAX_DODGE_CHANCE);
            if (Rand >= GHOST_SUCCESS_DODGE)
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
