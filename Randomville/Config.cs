namespace GameConfig
{
    public static class Config
    {
        public static int MaxMapSize { get; private set; }

        public static int GameObjectsLimit { get; private set; }

        public static int BaseLocationPopulation { get; private set; }

        public static int CreatureMaxLevel { get; private set; }

        public static int MaxActiveQuests { get; private set; }

        public static string? GameDifficulty { get; private set; }

        public static void SettingValues()
        {
            MaxMapSize = 200;
            GameObjectsLimit = 100;
            BaseLocationPopulation = 10;
            CreatureMaxLevel = 100;
            MaxActiveQuests = 10;
            GameDifficulty = "Normal";
        }

    }

}