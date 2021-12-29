using System;
using Interfaces;


namespace GameObjects
{

    public abstract class Settlement : ILocation
    {

        internal static int locationCount = 0;
        private protected Random random = new Random();
        private protected Dictionary<char, int> cordOnMap = new Dictionary<char,int>();

        public Settlement(string name, string type, string landscape, int danger, int population, string weather, int xCord, int yCord)
        {
            locationCount++;
            Status = "В порядке";

            Name = name;
            Type = type;
            Landscape = landscape;
            Weather = weather;
            Danger = danger;
            Population = population;

            XCord = xCord;
            YCord = yCord;
        }


        public string Name { get; set; }
        public string Type { get; set; }
        public string Landscape { get; set; }
        public string Weather { get; set; }
        public string Status { get; set; }
        public int Danger { get; set; }
        public int Population { get; set; }
        public int XCord { get; set; }
        public int YCord { get; set; }



        public void Destroy()
        {
            Status = "Уничтожен";
            Population = 0;
            Danger = 10;
        }

        public abstract void Curse();

        public abstract void Improve();
      
    }

}