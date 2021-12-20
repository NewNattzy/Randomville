using GameConfig;

namespace GameObjects
{
    public class Village : Location
    {

        private static int maxPopulation = Config.BaseLocationPopulation * 40;

        public Village(string name, string type, string landscape, int danger, int population, string weather)
            : base(name, type, landscape, danger, population, weather)
        {

        }

        public override void Sieged()
        {
            Status = "Осажден";

            if (Population % 2 == 0 && Population != 0)
                Population /= 2;
            else if (Population < 10)
                Destroyed();
            else
            {
                Population++;
                Population /= 2;
            }

            Danger = 8;
        }

        public override void Cursed()
        {
            if (Status != "Проклят")
            {
                Status = "Проклят";
                Weather = "Туман";
            }    
           
            Population -= 10 * Danger;

            if (Population <= 0)
                Destroyed();
            if (Danger < 10)
                Danger++;
        }

        public override void Improved()
        {
            if (Population < maxPopulation)
                Population += 50;
            else if (Population > maxPopulation)
            {
                Population = maxPopulation;
                Status = "Процветает";
                Danger = 0;
            }
        }

    }

}