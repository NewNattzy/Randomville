using GameConfig;

namespace GameObjects
{
    public class City : Location
    {

        private int maxPopulation;
        private double calcPercent;

        public City(string name, string type, string landscape, int danger, int population, string weather)
            : base(name, type, landscape, danger, population, weather)
        {
            Gold = random.Next(1000, 3000);
            maxPopulation = Config.BaseLocationPopulation * (random.Next(250, 500));
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

        public void Sieged()
        {
            if (Status != "Осажден")
                Status = "Осажден";

            calcPercent = Population * 0.3;
            Population = (int)calcPercent;

            if (Population < 100)
                Destroyed();

            Danger = 8;
        }

        public override void Cursed()
        {
            if (Status != "Проклят")
            {
                Status = "Проклят";
                Weather = "Туман";
            }

            Population -= 50 * Danger;

            if (Population < 100)
                Destroyed();
            if (Danger < 10)
                Danger++;
        }


        public override void Improved()
        {
            calcPercent = Population * 0.05;

            if (Status != "В порядке")
                Status = "В порядке";

            if (Population >= maxPopulation)
            {
                Gold += (int)calcPercent;

                if (Status != "Процветает")
                {
                    Status = "Процветает";
                    Population = maxPopulation;
                    Danger = 0;
                }
            }
            else if (Population < maxPopulation)
            {
                Population += (int)calcPercent;
                Gold += (int)calcPercent;
            }
        }


    }

}