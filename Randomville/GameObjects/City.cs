using System;
using GameConfig;


namespace GameObjects
{

    public class City : Settlement
    {


        private readonly int maxPopulation;
        private double calcPercent;


        public City(string name, string type, string landscape, int danger, int population, string weather, int xCord, int yCord)
            : base(name, type, landscape, danger, population, weather, xCord, yCord)
        {

            Gold = random.Next(1000, 3000);
            maxPopulation = Config.BaseLocationPopulation * (random.Next(250, 500));

        }


        public int Gold { get; set; }


        public int Robbery()
        {

            if (Status != "Разграблен")
                Status = "Разграблен";

            calcPercent = Gold * 0.25;
            Gold = (int)calcPercent;

            return Gold;

        }


        public int Besiege()
        {

            if (Status != "Осажден")
                Status = "Осажден";

            calcPercent = Population * 0.3;
            Population = (int)calcPercent;

            if (Population < 100)
                Destroy();

            Danger = 8;

            return (int)calcPercent;

        }


        public override void Curse()
        {

            if (Status != "Проклят")
            {

                Status = "Проклят";
                Weather = "Туман";

            }

            Population -= 50 * Danger;

            if (Population < 100)
                Destroy();
            if (Danger < 10)
                Danger++;

        }


        public override void Improve()
        {

            if (Population == 0)
                Population = 500;

            calcPercent = Population * 0.1;

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

        public void ShowParameters()
        {
            Console.WriteLine($"Перед вами великий город {name}!");
            Console.WriteLine($"В данный момент {name} {Status}.");
            Console.WriteLine($"Его население составляет {Population}.");
            Console.WriteLine($"А в казне находится {Gold} золота.\n");
        }

    }

}