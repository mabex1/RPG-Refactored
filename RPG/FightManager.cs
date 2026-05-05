using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace RPG
{
    internal class FightManager
    {
        public void Fight(Player player, Enemy enemy, ConsoleUI consoleUI)
        {
            int iscritical = Random.Shared.Next(0, 6);
            if (iscritical == 5)
            {
                int randomgold = Random.Shared.Next(1, 10);
                player.TakeDamage(enemy.Attack);
                enemy.TakeDamage(player.weapon.Damage * 2);
            }
            else
            {
                int randomgold = Random.Shared.Next(1, 10);
                player.TakeDamage(enemy.Attack);
                enemy.TakeDamage(player.weapon.Damage);
            }

            if(enemy.HP <= 0)
            {
                int randomgold = Random.Shared.Next(3, 10);
                consoleUI.EnemyBeaten(randomgold);
                player.AddGold(randomgold);
                player.SetCurrentEnemyNull();
            }
        }
    }
}
