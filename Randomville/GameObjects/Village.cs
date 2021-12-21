using GameConfig;

namespace GameObjects
{
    public class Village : Location
    {

        private static int maxPopulation = Config.BaseLocationPopulation * 40;
        private double losses;

        public Village(string name, string type, string landscape, int danger, int population, string weather)
            : base(name, type, landscape, danger, population, weather)
        {
            Gold = random.Next(100, 1000);
        }

        public int Gold { get; set; }

        public void Robbery()
        {
            if (Status != "Разграблен")
                Status = "Разграблен";

            losses = Gold * 0.5;
            Gold = (int)losses;

            if (Gold < 200)
                Gold = 0;
        }

        public override void Cursed()
        {
            if (Status != "Проклят")
            {
                Status = "Проклят";
                Weather = "Туман";
            }    
           
            Population -= 10 * Danger;

            if (Population < 20)
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
                Population += 50;
                Gold += 100;
            }
            else if (Population > maxPopulation && Gold > 1000)
            {
                Gold += 100;
                Population = maxPopulation;
                Status = "Процветает";
                Danger = 0;
            }
        }

    }

}