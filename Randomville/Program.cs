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

            Console.WriteLine("\nКонец игры");
            Console.ReadKey();
        }

    }

}