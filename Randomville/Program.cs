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


            List<EnemyArmy> enemyArmies = new List<EnemyArmy>();
            for (int i = 0; i < 25; i++)
            {
                enemyArmies.Add(EnemyManagment.CreateArmyEnemy("Нежить", 99));
                enemyArmies.Add(EnemyManagment.CreateArmyEnemy("Орда", 99));
            }


            while (true)
            {

                enemyArmies = WorldMapManagment.MoveArmies(enemyArmies);
                enemyArmies = EnemyManagment.CheckArmyConflict(enemyArmies);

                Thread.Sleep(1000);

                WorldMapManagment.ShowMap();

            }

        }

    }

}

























//City orcCity = LocationManagment.CreateCity(ref map);
//City necroCity = LocationManagment.CreateCity(ref map);


//EnemyArmy orcArmy = EnemyManagment.CreateArmyEnemy("Орда", 60, ref map);
//EnemyArmy necroArmy = EnemyManagment.CreateArmyEnemy("Нежить", 90, ref map);


//map.ShowMap();


//Console.WriteLine($"Город Орков {orcCity.Name} X CORD: {orcCity.XCord} | Y CORD: {orcCity.YCord}");
//Console.WriteLine($"Город Нежити {necroCity.Name} X CORD: {necroCity.XCord} | Y CORD: {necroCity.YCord}");

//Console.WriteLine($"{orcArmy.Name} X CORD: {orcArmy.XCord} | Y CORD: {orcArmy.YCord}");
//Console.WriteLine($"{necroArmy.Name} X CORD: {necroArmy.XCord} | Y CORD: {necroArmy.YCord}");



//}