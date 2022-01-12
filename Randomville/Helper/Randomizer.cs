using System;
using GameObjectManagment;


namespace Helper
{

    internal static class Randomizer
    {


        private static List<string> SideOfWorld = new List<string>() { "North", "South", "West", "East" };

        internal static Random random = new Random();


        internal static void RandMovingByOneCell(ref int xCord, ref int yCord)
        {

            xCord = random.Next(-1, 2);
            yCord = random.Next(-1, 2);

        }


        internal static void RandCordOnMap(ref int xCord, ref int yCord)
        {

            xCord = random.Next(1, WorldMap.horizontalLendth - 1);
            yCord = random.Next(1, WorldMap.verticalLendth - 1);

        }


        internal static void RandCordNextToBorder(ref int xCord, ref int yCord)
        {

            string Side = SideOfWorld[random.Next(0, SideOfWorld.Count)];

            if (Side == "North")
            {
                xCord = random.Next(1, WorldMap.horizontalLendth - 2);         
                yCord = 1;
            }
            else if (Side == "South")
            {
                xCord = random.Next(1, WorldMap.horizontalLendth - 1);         
                yCord = WorldMap.verticalLendth - 2;
            }
            else if (Side == "West")
            {
                xCord = 1;
                yCord = random.Next(1, WorldMap.verticalLendth - 1);    
            }
            else if (Side == "East")
            {
                xCord = WorldMap.horizontalLendth - 2;
                yCord = random.Next(1, WorldMap.verticalLendth - 1);
            }

        }

    }

}
