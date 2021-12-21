using GameConfig;

namespace GameObjects
{
    public class City : Location
    {

        private static int maxPopulation = Config.BaseLocationPopulation * 400;
        private double losses;

        public City(string name, string type, string landscape, int danger, int population, string weather)
            : base(name, type, landscape, danger, population, weather)
        {
            Gold = random.Next(1000, 3000);
        }

        public int Gold { get; set; }

        public void Robbery()
        {
            if (Status != "Разграблен")
                Status = "Разграблен";

            losses = Gold * 0.5;
            Gold = (int)losses;

            if (Gold < 500)
                Gold = 0;
        }

        public void Sieged()
        {
            if (Status != "Осажден")
                Status = "Осажден";

            losses = Population * 0.7;
            Population = (int)losses;

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
            if (Status != "В порядке")
                Status = "В порядке";

            if (Population < maxPopulation)
            {
                Population += 100;
                Gold += 500;
            }
            else if (Population > maxPopulation && Gold > 5000)
            {
                Gold += 500;
                Population = maxPopulation;
                Status = "Процветает";
                Danger = 0;
            }  
        }

    }

}