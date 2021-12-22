using System;
using GameConfig;
using GameObjects;
using GameObjectManagment;
using Storage;

namespace ConsoleGame
{

    class Program
    {

        public static void StartGame(Player player)
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

            Console.WriteLine("\nКонец игры");
            Console.ReadKey();
        }

    }

}