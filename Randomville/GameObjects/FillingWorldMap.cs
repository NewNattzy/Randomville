using System;
using GameConfig;
using GameObjectManagment;
using Helper;


namespace GameObjects
{
    public static class FillingWorldMap
    {

        public static List<Army> armies = new List<Army>();
        public static List<City> cities = new List<City>();

        private static readonly double maxArmiesCount = Config.GameObjectsLimit * 0.1;
        private static readonly double maxCitiesCount = Config.GameObjectsLimit * 0.05;

        public static void SimulationLife()
        {

            WorldMap.MoveArmies(ref armies);
            MilitaryActions.InitializationСonflictsArmiesOnMap(ref armies);

        }

        public static void CreateObjects()
        {

            FillingMapWithArmies();
            FillingMapWithCities();

        }



        private static void FillingMapWithArmies()
        {

            while (armies.Count < maxArmiesCount)
            {
                armies.Add(MilitaryActions.CreateArmy("Орда", Randomizer.RandArmyCount()));
                armies.Add(MilitaryActions.CreateArmy("Нежить", Randomizer.RandArmyCount()));
            }

        }

        private static void FillingMapWithCities()
        {

            while (cities.Count < maxCitiesCount)
            {
                cities.Add(Location.CreateCity());
            }

        }


    }

}
