using System;
using GameConfig;
using GameObjects;
using Events;
using GameObjectManagment;
using System.Diagnostics;

namespace ConsoleGame
{

    internal class Program
    {

        public static void StartGame(Player player)
        {
            PlayerManagement.ShowPlayerInfo(player);
        }


        public static void GamePreparation()
        {
            // TODO: Методы необходимые для старта игры, подготовка конфигов, карты, первых объектов
            Config.SettingValues();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }


        private static void Main(string[] args)
        {
            
            if (args is null) throw new ArgumentNullException(nameof(args));
            

            GamePreparation();


            WorldMap map = new WorldMap();
            map.CreateMap();


            City orcCity = LocationManagment.CreateCity(ref map);
            City necroCity = LocationManagment.CreateCity(ref map);


            EnemyArmy orcArmy = EnemyManagment.CreateArmyEnemy("Орда", 60, ref map);
            EnemyArmy necroArmy = EnemyManagment.CreateArmyEnemy("Нежить", 90, ref map);


            map.ShowMap();


            Console.WriteLine($"Город Орков {orcCity.Name} X CORD: {orcCity.XCord} | Y CORD: {orcCity.YCord}");
            Console.WriteLine($"Город Нежити {necroCity.Name} X CORD: {necroCity.XCord} | Y CORD: {necroCity.YCord}");

            Console.WriteLine($"{orcArmy.Name} X CORD: {orcArmy.XCord} | Y CORD: {orcArmy.YCord}");
            Console.WriteLine($"{necroArmy.Name} X CORD: {necroArmy.XCord} | Y CORD: {necroArmy.YCord}");


            Console.WriteLine("\nКонец игры");
            Console.ReadKey();

        }

    }

}