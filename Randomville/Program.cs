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
        }


        private static void Main(string[] args)
        {

            if (args is null) throw new ArgumentNullException(nameof(args));

            GamePreparation();


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            EnemyArmy armyUndead = EnemyManagment.CreateArmyEnemy("Нежить", 99);
            EnemyArmy armyHorde = EnemyManagment.CreateArmyEnemy("Орда", 99);

            Fight.ArmyFight(armyHorde, armyUndead);
            

            stopWatch.Stop(); // 00:00:00.5: SqlConnector надо исправлять, набыдлокодил


            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);


            Console.WriteLine("\nКонец игры");
            Console.ReadKey();

        }

    }

}