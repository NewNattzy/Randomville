using System;
using Interfaces;


namespace GameObjects
{

    public class Wilderness : ILocation
    {

        private double calcPersent;
        private const int MAX_RESOURCES = 100;

        public Wilderness(string name, string type, string landscape, string status, int danger, string weather)
        {

            Name = name;
            Type = type;
            Landscape = landscape;
            Danger = danger;
            Status = status;
            Weather = weather;

        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Landscape { get; set; }
        public string Weather { get; set; }
        public string Status { get; set; }

        public int Danger { get; set; }
        public int Resources { get; set; }


        public void Curse()
        {

            if (Status != "Проклят")
            {

                Status = "Проклят";
                Weather = "Густой туман";

            }

            calcPersent = Resources * 0.2;
            Resources -= (int)calcPersent;

        }


        public void Improve()
        {

            if (Resources <= 0)
                Resources = 10;

            if (Status != "В порядке")
                Status = "В порядке";


            if (Resources > 0 && Resources < MAX_RESOURCES)
                calcPersent = Resources * 0.2;
            else if (Resources >= MAX_RESOURCES)
            {

                Resources = MAX_RESOURCES;
                Status = "Процветает";

            }

        }


        public void Destroy()
        {

            throw new NotImplementedException();

        }

    }

}