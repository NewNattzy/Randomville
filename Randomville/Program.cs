using GameConfig;
using GameObjects;
using GameObjectManagment;

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
            
            // WorldMap worldMap = WorldMapManagment.CreateMap();
            int worldMap = 10;
            

        }

        static void Main(string[] args)
        {
            
            GamePreparation();
            //StartGame();
            City city = LocationManagment.CreateCity();

            //for (int i = 0; i < 100; i++)
            //{
            //    city = LocationManagment.CreateCity();
            //    Console.WriteLine($"Название: {city.Name}");
            //    Console.WriteLine($"Ландшафт: {city.Landscape}");
            //    Console.WriteLine($"Опасность: {city.Danger}");
            //    Console.WriteLine($"Население: {city.Population}");
            //    Console.WriteLine($"Погода: {city.Weather}\n");
            //}

            Player player = PlayerManagement.CreatePlayer();

            player.Gold = 1000;
            player.Exp = 1000;
            
            for (int i = 0; i < 2; i++)
            {
                PlayerManagement.ShowPlayerInfo(player);
                PlayerManagement.LevelUP(player);
            }
            
            Console.WriteLine("Конец игры");
            Console.ReadKey();

        }

    }

}