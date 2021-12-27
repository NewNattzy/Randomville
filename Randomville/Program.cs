using System;
using GameConfig;
using GameObjects;
using GameObjectManagment;
using Storage;
using System.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

            //WorldMap worldMap = new WorldMap();
            //worldMap.CreateMap();
            //worldMap.ShowMap();


            EnemyArmy army = EnemyManagment.CreateArmyEnemy("Нежить", 100);

            var binFormatter = new BinaryFormatter();

            using(var file = new FileStream("Save.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, army);
            };

            using (var file = new FileStream("Save.bin", FileMode.OpenOrCreate))
            {
                var newArmy = binFormatter.Deserialize(file);
                army = (EnemyArmy)newArmy;
            };

            Console.WriteLine("\nКонец игры");
            Console.ReadKey();
        }

    }

}