using System;
using GameObjects;
using DevHelper;


namespace GameObjectManagment
{

    public static class LocationManagment
    {

        private static readonly Random random = new();

        // TODO: Завязать генерацию на БД, этот мусор удалить
        private static readonly string libraryName = "Library\\Name.txt";
        private static readonly string libraryLandscape = "Library\\Landscape.txt";
        private static readonly string libraryWeather = "Library\\Weather.txt";

        private static readonly int countLineInName = File.ReadAllLines(libraryName).Length;
        private static readonly int countLineInLandscape = File.ReadAllLines(libraryLandscape).Length;
        private static readonly int countLineInWeather = File.ReadAllLines(libraryWeather).Length;


        public static City CreateCity()
        {
            // TODO: Пофиксить убогость
            string type = "Город";

            string name = File.ReadLines(libraryName).Skip(random.Next(countLineInName)).First();
            string landscape = File.ReadLines(libraryLandscape).Skip(random.Next(countLineInLandscape)).First();
            string weather = File.ReadLines(libraryWeather).Skip(random.Next(countLineInWeather)).First();

            int danger = random.Next(0, 3);
            int population = random.Next(1000, 2500);


            WorldMapManagment.PutObject(Graphics.GetPicture("city"), out int xCord, out int yCord);

            return new City(name, type, landscape, danger, population, weather, xCord, yCord);

        }

        public static Village CreateVillage()
        {

            string name = "";
            string type = "";
            string landscape = "";
            string weather = "";

            int danger = 0;
            int population = 0;

            int xCord = 1;
            int yCord = 2;

            return new Village(name, type, landscape, danger, population, weather, xCord, yCord);

        }

        public static Wilderness CreateWilderness()
        {

            string name = "";
            string type = "";
            string landscape = "";
            string weather = "";
            string status = "";
            int danger = 0;

            return new Wilderness(name, type, landscape, status, danger, weather);

        }

    }

}