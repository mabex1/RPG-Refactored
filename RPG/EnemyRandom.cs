using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    internal class EnemyRandom
    {
        EnemysContent enemysContent = new EnemysContent();

        public Enemy Randomizer()
        {
            int randomenemy = Random.Shared.Next(0, enemysContent.Enemys.Count);
            return enemysContent.Enemys[randomenemy].Clone();
        }
    }
}
