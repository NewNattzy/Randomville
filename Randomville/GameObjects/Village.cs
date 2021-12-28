using System;
using GameConfig;


namespace GameObjects
{

    public class Village : Settlement
    {

        private int maxPopulation;
        private double calcPercent;

        public Village(string name, string type, string landscape, int danger, int population, string weather)
            : base(name, type, landscape, danger, population, weather)
        {
            // TODO: Проверка входных параметров
            Gold = random.Next(100, 1000);
            maxPopulation = Config.BaseLocationPopulation * (random.Next(10, 50));
        }

        public int Gold { get; set; }


        public int Robbery()
        {

            if (Status != "Разграблен")
                Status = "Разграблен";

            calcPercent = Gold * 0.5;
            Gold = (int)calcPercent;

            return Gold;

        }


        public override void Curse()
        {

            if (Status != "Проклят")
            {
                Status = "Проклят";
                Weather = "Туман";
            }    
           
            Population -= 10 * Danger;

            if (Population < 20)
                Destroy();
            if (Danger < 10)
                Danger++;

        }


        public override void Improve()
        {

            if (Population == 0)
                Population = 100;

            calcPercent = Population * 0.05;

            if (Status != "В порядке")
                Status = "В порядке";


            if (Population > maxPopulation && Gold > 5000)
            {
                Gold += (int)calcPercent;
                Population = maxPopulation;
                Status = "Процветает";
                Danger = 0;
            }
            else if (Population < maxPopulation)
            {
                Population += (int)calcPercent;
                Gold += (int)calcPercent;
            }

        }

    }

}