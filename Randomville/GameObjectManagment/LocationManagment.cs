using GameObjects;

namespace GameObjectManagment
{

    public static class LocationManagment
    {

        static Random random = new Random();

        // TODO: Завязать генерацию на БД
        static string libraryName = "Library\\Name.txt";
        static string libraryLandscape = "Library\\Landscape.txt";
        static string libraryWeather = "Library\\Weather.txt";

        static int countLineInName = File.ReadAllLines(libraryName).Length;
        static int countLineInLandscape = File.ReadAllLines(libraryLandscape).Length;
        static int countLineInWeather = File.ReadAllLines(libraryWeather).Length;

        public static City CreateCity()
        {

            string type = "Город";
            string name = File.ReadLines(libraryName).Skip(random.Next(countLineInName)).First();
            string landscape = File.ReadLines(libraryLandscape).Skip(random.Next(countLineInLandscape)).First();
            string weather = File.ReadLines(libraryWeather).Skip(random.Next(countLineInWeather)).First();

            int danger = random.Next(0, 3);
            int population = random.Next(0, 2500);

            return new City(name, type, landscape, danger, population, weather);

        }

        public static Village CreateVillage()
        {

            string name = "";
            string type = "";
            string landscape = "";
            string weather = "";

            int danger = 0;
            int population = 0;



            return new Village(name, type, landscape, danger, population, weather);

        }

        public static Wilderness CreateWilderness()
        {

            string name = "";
            string type = "";
            string landscape = "";
            string weather = "";

            int danger = 0;
            int population = 0;



            return new Wilderness(name, type, landscape, danger, population, weather);

        }

    }

}