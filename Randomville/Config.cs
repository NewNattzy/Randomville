using System;


namespace GameConfig
{

    // TODO: Перенести в текстовый файл
    public static class Config
    {

        public static int MaxMapSize { get; private set; }
        public static int MaxMapStructures { get; private set; }
        public static int GameObjectsLimit { get; private set; }
        public static int BaseLocationPopulation { get; private set; }
        public static int CreatureMaxLevel { get; private set; }
        public static int MaxActiveQuests { get; private set; }

        public static string? GameDifficulty { get; private set; }


        public static void SetValues()
        {

            MaxMapSize = 100;
            MaxMapStructures = 20;
            GameObjectsLimit = 100;
            BaseLocationPopulation = 10;
            CreatureMaxLevel = 100;
            MaxActiveQuests = 10;
            GameDifficulty = "Normal";
            Console.CursorVisible = false;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

        }

    }

}