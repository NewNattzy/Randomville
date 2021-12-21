using System;
using GameConfig;
using GameObjects;
using GameObjectManagment;
using Storage;
using Items;

namespace ConsoleGame
{

    class Program
    {

        public static void StartGame(Player player, int worldMap)
        {
            PlayerManagement.ShowPlayerInfo(player);
        }

        public static void GamePreparation()
        {
            // TODO: Методы необходимые для старта игры, подготовка конфигов, карты, первых объектов
            Config.SettingValues();
        }

        static void Main(string[] args)
        {

            GamePreparation();
            Player player = PlayerManagement.CreatePlayer();

            EnemyArmy army  = new EnemyArmy("Волчья стая");

            for (int i = 0; i < 10; i++)
            {
                army.Add(EnemyManagment.CreateEnemy());
            }

            Console.WriteLine($"Армия {army.Name} на подоходе!\n");
            Console.Write("Список монстров: ");

            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                {
                    Console.Write($"{army[i].Name}!\n");
                    break;
                }
                Console.Write($"{army[i].Name}, ");
            }

            City city = LocationManagment.CreateCity();
            Console.WriteLine($"\nАрмия {army.Name} нападает на {city.Name}!");

            while (city.Status != "Уничтожен")
            {
                Console.WriteLine($"\nСтатус {city.Name}: {city.Status}");
                Console.WriteLine($"Популяция {city.Name}: {city.Population}");
                Console.WriteLine($"Опасность {city.Name}: {city.Danger}");

                EnemyManagment.EnemyArmyAttack(army, city);
            }

            Console.WriteLine($"\nСтатус {city.Name}: {city.Status}");
            Console.WriteLine($"Популяция {city.Name}: {city.Population}");
            Console.WriteLine($"Опасность {city.Name}: {city.Danger}");


            Console.WriteLine("\nКонец игры");
            Console.ReadKey();
         
        }

    }

}