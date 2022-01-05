using System;
using GameConfig;
using GameObjects;
using GameObjectManagment;
using DevHelper;


namespace ConsoleGame
{

    internal class Program
    {

        public static void GamePreparation()
        {

            Config.SetValues();
            Graphics.SetPicture();

        }


        private static void Main(string[] args)
        {

            if (args is null) throw new ArgumentNullException(nameof(args));


            GamePreparation();


            WorldMapManagment.CreateMap();
            Random random = new Random();


            List<EnemyArmy> enemyArmies = new List<EnemyArmy>();
            for (int i = 0; i < 20; i++)
            {

                enemyArmies.Add(EnemyManagment.CreateEnemyArmy("Нежить", random.Next(10, 99)));
                enemyArmies.Add(EnemyManagment.CreateEnemyArmy("Орда", random.Next(10, 99)));

            }


            List<City> cities = new List<City>();
            for (int i = 0; i < 10; i++)
                cities.Add(LocationManagment.CreateCity());


            while (true)
            {

                WorldMapManagment.MoveArmies(ref enemyArmies);

                EnemyManagment.CheckArmiesConflict(ref enemyArmies);
                LocationManagment.CheckCityConflict(ref enemyArmies, ref cities);

                WorldMapManagment.ShowMap();

            }

        }

    }

}