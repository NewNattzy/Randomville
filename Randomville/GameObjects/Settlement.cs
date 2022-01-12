using System;
using Interfaces;


namespace GameObjects
{

    public abstract class Settlement : ILocation
    {

        public readonly string name;
        public readonly string type;
        public readonly string landscape;

        internal static int locationCount = 0;
        private protected Random random = new Random();
        private protected Dictionary<char, int> cordOnMap = new Dictionary<char,int>();


        public Settlement(string name, string type, string landscape, int danger, int population, string weather, int xCord, int yCord)
        {

            locationCount++;
            Status = "В порядке";

            this.name = name;
            this.type = type;
            this.landscape = landscape;

            Weather = weather;
            Danger = danger;
            Population = population;

            XCord = xCord;
            YCord = yCord;

        }


        public string Weather { get; set; }
        public string Status { get; set; }

        public int Danger { get; set; }
        public int Population { get; set; }

        public int XCord { get; private set; }
        public int YCord { get; private set; }


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