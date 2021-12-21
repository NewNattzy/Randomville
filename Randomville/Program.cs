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

            EnemyArmy WolfArmy = new EnemyArmy("Волчья стая");

            for (int i = 0; i < 10; i++)
            {
                WolfArmy.Add(EnemyManagment.CreateEnemy());
            }
            Console.WriteLine($"Армия {WolfArmy.Name} на подоходе!");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(WolfArmy[i].Name);
            }

            Console.WriteLine("Конец игры");
            Console.ReadKey();
         
        }

    }

}