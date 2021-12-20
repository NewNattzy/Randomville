using GameConfig;

namespace GameObjects
{
    public class Wilderness : Location
    {

        private static int maxPopulation = Config.BaseLocationPopulation;

        public Wilderness(string name, string type, string landscape, int danger, int population, string weather)
            : base(name, type, landscape, danger, population, weather)
        {

        }

        public override void Sieged()
        {
            Status = "Засада";
            Danger = 8;

            if (Population > 0)
                Population--;
            else
                Destroyed();
        }

        public override void Cursed()
        {
            if (Status != "Проклят")
            {
                Status = "Проклят";
                Weather = "Густой туман";
            }
            
            Population -= Danger;

            if (Population <= 0)
                Destroyed();
            if (Danger < 10)
                Danger++;
        }

        public override void Improved()
        {
            if (Population < maxPopulation)
                Population++;
            else if (Population > maxPopulation)
            {
                Population = maxPopulation;
                Status = "В норме";
                Danger = 0;
            }
        }
    }

}