using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RPG
{
    internal class ConsoleUI
    {
        public string SetNameUI()
        {
            Console.WriteLine("Назовите имя героя: ");
            string name = Console.ReadLine();
            if (name == null || name == "")
            {
                name = "Безымянный герой";
            }
            return name;
        }

        public string ConfirmationSetNameUI()
        {
            while (true)
            {
                string name = SetNameUI();

                Console.WriteLine("Вы уверенны в своем имени? д/н");

                if (Confirmation())
                {
                    return name;
                }
            }
        }

        public bool Confirmation()
        {
            while (true)
            {
                string confirmation = Console.ReadLine()?.ToLower();
                if (string.IsNullOrWhiteSpace(confirmation))
                {
                    Console.WriteLine("Введите д/н");
                    continue;
                }
                else
                {
                    if (confirmation == "д")
                    {
                        return true;
                    }

                    if (confirmation == "н")
                    {
                        return false;
                    }

                    Console.WriteLine("Введите д/н");
                }
            }
        }

        public bool IfDies(Player player)
        {
            Console.WriteLine($"Герой {player.Name} погиб!");
            Console.WriteLine($"Начать новую игру? д/н");
            if (Confirmation())
            {
                return true;
            }
            else return false;
        }

        public void ShowChoice()
        {
            Console.WriteLine();
            Console.WriteLine("=== ВЫБЕРИТЕ ДЕЙСТВИЕ: ===");
            Console.WriteLine("1.Сражение");
            Console.WriteLine("2.Восстановить здоровье");
            Console.WriteLine("3.Магазин");
            Console.WriteLine("4.Выход");
        }

        public void ShowValues(Player player)
        {
            Console.WriteLine();
            Console.WriteLine($"Имя: {player.Name}");
            Console.WriteLine($"Здоровье: {player.HP}");
            Console.WriteLine($"Золото: {player.gold}");
            Console.WriteLine($"Бинтов: {player.HealCount}");
            Console.WriteLine($"Оружие: {player.weapon.Name}");
        }

        public string Choice()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "1" && input != "2" && input != "3" && input != "4")
                {
                    Console.WriteLine("Введите число 1-4");
                    continue;
                }
                else
                {
                    return input;
                }
            }
        }

        public void NoHeal()
        {
            Console.WriteLine("Нет бинтов!");
        }

        public void HealMaxHP()
        {
            Console.WriteLine("Полное здоровье!");
        }

        public void HealSuccessful(Player player)
        {
            Console.WriteLine($"Вы успешно восстановили {player.healHeals} здоровья");
        }

        public void EnemyGhostDodge(Enemy enemy)
        {
            Console.WriteLine($"Призрак уклонился! вы не смогли нанести ему удар! У него осталось {enemy.HP} HP");
        }

        public void EnemyBeaten(int amount)
        {
            Console.WriteLine($"Враг побежден! +{amount} Золота!");
        }

        public void EnemySet(Enemy enemy)
        {
            Console.WriteLine();
            Console.WriteLine($"Появился новый враг! {enemy.Name}");
        }
        public void EnemyShow(Enemy enemy)
        {
            Console.WriteLine();
            Console.WriteLine($"Враг: {enemy.Name} ({enemy.HP}/{enemy.MaxHP} HP)");
        }

        public void TakeDamagePlayer(Enemy enemy)
        {
            Console.WriteLine($"Враг ударил тебя! -{enemy.Attack} HP");
        }
        
        public void TakeDamageEnemy(Enemy enemy)
        {
            Console.WriteLine();
            Console.WriteLine($"Вы ударили врага! У него осталось {enemy.HP} HP");
        }

        public void ShowShop()
        {
            Console.WriteLine();
            Console.WriteLine("=== МАГАЗИН ===");
            Console.WriteLine("1.Показать товары");
            Console.WriteLine("2.Поговорить");
            Console.WriteLine("3.Выйти из магазина");
        }
        
        public void ShowItemsChoice()
        {
            Console.WriteLine();
            Console.WriteLine("=== ТОВАРЫ ===");
            Console.WriteLine("1.Показать оружие");
            Console.WriteLine("2.Показать предметы");
            Console.WriteLine("3.Вернуться в магазин");
        }

        public void ShowWeapons(IReadOnlyList<Weapon> list)
        {
            Console.WriteLine();
            Console.WriteLine("=== ОРУЖИЕ ===");
            for (int i = 0;  i < list.Count; i++)
            {
                Weapon weapon = list[i];
                Console.WriteLine($"{i+1}. {weapon.Name} Урон: {weapon.Damage} Стоимость: {weapon.Price}");
            }
        }

        public void ShowItems(IReadOnlyList<Item> list)
        {
            Console.WriteLine();
            Console.WriteLine("=== ПРЕДМЕТЫ ===");
            for (int i = 0; i < list.Count; i++)
            {
                Item item = list[i];
                Console.WriteLine($"{i + 1}. {item.Name} Описание: {item.Description} Стоимость: {item.Price}");
            }
        }

        public Weapon SelectWeapon(IReadOnlyList<Weapon> list)
        {
            while (true)
            {
                Console.Write($"Выберите оружие 1-{list.Count}: ");
                string? input = Console.ReadLine();

                if(int.TryParse(input, out int index))
                {
                    if (index >= 0 && index <= list.Count)
                    {
                        return list[index - 1];
                    }
                }

                Console.WriteLine($"Введите число от 1-{list.Count}");
            }
        }

        public Item SelectItem(IReadOnlyList<Item> list)
        {
            while (true)
            {
                Console.Write($"Выберите оружие 1-{list.Count}: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int index))
                {
                    if (index >= 0 && index <= list.Count)
                    {
                        return list[index - 1];
                    }
                }

                Console.WriteLine($"Введите число от 1-{list.Count}");
            }
        }

        public string SelectAct()
        {
            while (true)
            {
                Console.WriteLine($"Выберите действие 1-3: ");
                string? input = Console.ReadLine();
                if (input == "1" || input == "2" || input == "3")
                {
                    return input;
                }
            }
        }

        public void WarnItemTypeNotExists()
        {
            Console.WriteLine("Не существует предмета с таким типом.");
        }

        public void WarnNoDialogues()
        {
            Console.WriteLine("Но здесь не о чем разговаривать.");
        }
        
        public void SuccesfulBuy(Item item)
        {
            Console.WriteLine();
            Console.WriteLine($"Вы успешно купили {item.Name}!");
            Console.WriteLine($"{item.Description}");
        }

        public void BadBuy(Item item)
        {
            Console.WriteLine();
            Console.WriteLine($"Вы успешно не купили {item.Name}!");
            Console.WriteLine($"не {item.Description}");
        }

        public void GameEnd(Player player)
        {
            Console.WriteLine();
            Console.WriteLine($"Герой {player.Name} окончил приключение с {player.gold} золота и оружием {player.weapon.Name}!");
        }
    }
}
