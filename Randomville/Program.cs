using System;
using GameConfig;
using GameObjects;
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


            EnemyArmy armyUndead = EnemyManagment.CreateArmyEnemy("Нежить", 70);
            EnemyManagment.ShowStructureArmy(armyUndead);


            EnemyArmy armyHorde = EnemyManagment.CreateArmyEnemy("Орда", 90);
            EnemyManagment.ShowStructureArmy(armyHorde);


            Console.WriteLine("\nКонец игры");
            Console.ReadKey();
        }

    }

}