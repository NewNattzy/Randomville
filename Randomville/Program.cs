using System;
using GameConfig;
using GameObjects;
using GameObjectManagment;
using Resources;


namespace ConsoleGame
{

    internal class Program
    {

        public static void GamePreparation()
        {

            Config.SetValues();
            Graphics.SetPicture();

        }


        private static void Main(string[] args)
        {

            if (args is null) throw new ArgumentNullException(nameof(args));


            GamePreparation();

            WorldMap.CreateMap();
            Random random = new Random();


            List<Army> armies = new List<Army>();
            for (int i = 0; i < 18; i++)
            {

                armies.Add(MilitaryActions.CreateArmy("Нежить", random.Next(10, 99)));
                armies.Add(MilitaryActions.CreateArmy("Орда", random.Next(10, 99)));

            }


            List<City> cities = new List<City>();
            for (int i = 0; i < 5; i++)
                cities.Add(Location.CreateCity());


            while (true)
            {

                WorldMap.MoveArmies(ref armies);


                if (MilitaryActions.CheckСonflictsArmiesOnMap(armies) == true)
                {
                    MilitaryActions.StartArmyBattle(ref armies);
                }


                Location.CheckCityConflict(ref armies, ref cities);


                WorldMap.ShowMap();

            }

        }

    }

}