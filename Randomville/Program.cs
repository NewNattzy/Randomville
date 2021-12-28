using System;
using GameConfig;
using GameObjects;
using Events;
using GameObjectManagment;

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
            EnemyArmy armyUndead = new EnemyArmy();
            EnemyArmy armyHorde = new EnemyArmy();

            for (int i = 0; i < 100; i++)
            {
                armyUndead = EnemyManagment.CreateArmyEnemy("Нежить", 90);
                armyHorde = EnemyManagment.CreateArmyEnemy("Орда", 90);
                Fight.ArmyFight(armyHorde, armyUndead);
            }

            Console.WriteLine("\nКонец игры");
            Console.ReadKey();
        }

    }

}