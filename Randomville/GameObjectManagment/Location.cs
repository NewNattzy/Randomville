using System;
using GameObjects;
using Resources;
using Helper;


namespace GameObjectManagment
{

    public static class Location
    {

        private static readonly Random random = new();

        // TODO: Завязать генерацию на БД, файлы подчистить
        private static readonly string libraryName = "Library\\Name.txt";
        private static readonly string libraryLandscape = "Library\\Landscape.txt";
        private static readonly string libraryWeather = "Library\\Weather.txt";

        private static readonly int countLineInName = File.ReadAllLines(libraryName).Length;
        private static readonly int countLineInLandscape = File.ReadAllLines(libraryLandscape).Length;
        private static readonly int countLineInWeather = File.ReadAllLines(libraryWeather).Length;


        public static City CreateCity()
        {
            
            string type = "Город";

            string name = File.ReadLines(libraryName).Skip(random.Next(countLineInName)).First();
            string landscape = File.ReadLines(libraryLandscape).Skip(random.Next(countLineInLandscape)).First();
            string weather = File.ReadLines(libraryWeather).Skip(random.Next(countLineInWeather)).First();

            int danger = random.Next(0, 3);
            int population = random.Next(1000, 2500);

            WorldMap.PutObjectOnMap(Graphics.GetPicture("City"), out Coordinate cord);

            return new City(name, type, landscape, danger, population, weather, cord.X, cord.Y);

        }


        public static void CheckCityConflict(ref List<Army> armies, ref List<City> cities)
        {

            for (int i = 0; i < armies.Count; i++)
                for (int j = 0; j < cities.Count; j++)
                    if (armies[i].cord.CompareTo(cities[j].cord) == 0)
                        BesiegeCity(armies[i], cities[j]);

            CheckCitiesStatus(cities);

        }


        public static List<City> CheckCitiesStatus(List<City> cities)
        {

            for (int i = 0; i < cities.Count; i++)
                if (cities[i].Status == "Уничтожен")
                {

                    WorldMap.RemoveObjectFromMap(cities[i].cord.X, cities[i].cord.Y);
                    cities.RemoveAt(i);

                }

            return cities;

        }

        public static void BesiegeCity(Army army, City city)
        {

            army.KillScore += city.Besiege();

            if (city.Status == "Уничтожен")
                army.DestroyScore++;
            army.Gold += city.Gold;

        }

    }

}