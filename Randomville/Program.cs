using System;
using GameConfig;
using GameObjects;
using Events;
using GameObjectManagment;
using DevHelper;


namespace ConsoleGame
{

    internal class Program
    {

        public static void GamePreparation()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Config.SettingValues();
            Graphics.SetPicture();     
        }


        private static void Main(string[] args)
        {

            if (args is null) throw new ArgumentNullException(nameof(args));
            GamePreparation();

            WorldMapManagment.CreateMap();
            WorldMapManagment.ShowMap();

            Random random = new Random();

            List<EnemyArmy> enemyArmies = new List<EnemyArmy>();
            for (int i = 0; i < 25; i++)
            {
                enemyArmies.Add(EnemyManagment.CreateEnemyArmy("Нежить", random.Next(10, 99)));
                enemyArmies.Add(EnemyManagment.CreateEnemyArmy("Орда", random.Next(10, 99)));
            }


            List<City> cities = new List<City>();
            for (int i = 0; i < 20; i++)
                cities.Add(LocationManagment.CreateCity());


            while (true)
            {
                Console.WriteLine("BEGINS");
                enemyArmies = WorldMapManagment.MoveArmies(enemyArmies);

                enemyArmies = EnemyManagment.CheckArmiesConflict(enemyArmies);
                cities = LocationManagment.CheckCityConflict(enemyArmies, cities);

                Thread.Sleep(1000);

                WorldMapManagment.ShowMap();



            }

        }

    }

}