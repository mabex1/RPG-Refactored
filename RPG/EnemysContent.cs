using System;
using System.Collections.Generic;
using System.Text;

namespace RPG
{
    internal class EnemysContent
    {
        private List<Enemy> enemys = new List<Enemy>();
        public IReadOnlyList<Enemy> Enemys => enemys;

        public EnemysContent()
        {
            enemys.Add(new Enemy(50, 50, 10, "Гоблин", 2));
            enemys.Add(new Enemy(30, 30, 15, "Скелет", 5));
            enemys.Add(new Ghost());
        }
    }
}
