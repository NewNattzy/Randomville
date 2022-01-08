using System;
using GameConfig;
using Resources;
using GameObjects;
using Helper;


namespace GameObjectManagment
{

    public static class WorldMap
    {

        internal static readonly int verticalLendth = Config.MaxMapSize / 5;
        internal static readonly int horizontalLendth = Config.MaxMapSize;
        private static readonly int[] restrictedArea = new int[3] { 0, horizontalLendth - 1, verticalLendth - 1 };

        private static int x;
        private static int y;

        private static char[,] mapMarkup = new char[verticalLendth, horizontalLendth];


        public static void CreateMap()
        {

            for (int i = 0; i < verticalLendth - 1; i++)
                for (int j = 0; j < horizontalLendth - 1; j++)
                    mapMarkup[i, j] = Graphics.GetPicture("Landscape");
                    
            AddBoundaries();
            AddStaticObjects();

        }


        private static void AddBoundaries()
        {

            for (int i = 0; i < horizontalLendth - 1; i++)
            {
                mapMarkup[0, i] = Graphics.GetPicture("HorizontalWall");
                mapMarkup[verticalLendth - 1, i] = Graphics.GetPicture("HorizontalWall");
            }

            for (int i = 0; i < verticalLendth - 1; i++)
            {
                mapMarkup[i, 0] = Graphics.GetPicture("VerticalWall");
                mapMarkup[i, horizontalLendth - 1] = Graphics.GetPicture("VerticalWall");
            }

            mapMarkup[0, 0] = Graphics.GetPicture("UpperLeftCorner");
            mapMarkup[0, horizontalLendth - 1] = Graphics.GetPicture("LowerLeftCorner");
            mapMarkup[verticalLendth - 1, 0] = Graphics.GetPicture("UpperRightCorner");
            mapMarkup[verticalLendth - 1, horizontalLendth - 1] = Graphics.GetPicture("LowerRightCorner");

        }


        private static void AddStaticObjects()
        {

            AddMountainsOnMap();
            AddRiverOnMap();

        }


        private static void AddMountainsOnMap()
        {

            for (int i = 0; i < 10; i++)
            {

                Randomizer.GetRandPointOnMap(ref x, ref y);
                mapMarkup[y, x] = Graphics.GetPicture("Mountain");

            }

            for (int i = 0; i < 90; i++)
            {

                Randomizer.RandCordNextToWall(ref x, ref y);
                mapMarkup[y, x] = Graphics.GetPicture("Mountain");

            }

        }


        private static void AddRiverOnMap()
        {

            for (int i = 0; i < 10; i++)
            {

                Randomizer.RandCordNextToWall(ref x, ref y);
                mapMarkup[y, x] = Graphics.GetPicture("River");

            }

        }


        public static void PutObjectOnMap(char objectLabel, out int xCord, out int yCord)
        {

            do
            {
                xCord = Randomizer.random.Next(1, horizontalLendth - 1);
                yCord = Randomizer.random.Next(1, verticalLendth - 1);
            }
            while (mapMarkup[yCord, xCord] != Graphics.GetPicture("Landscape"));
            {
                xCord = Randomizer.random.Next(1, horizontalLendth - 1);
                yCord = Randomizer.random.Next(1, verticalLendth - 1);
            }

            mapMarkup[yCord, xCord] = objectLabel;

        }


        public static void RemoveObjectFromMap(int xCord, int yCord)
        {

            Console.WriteLine($"Удален объект: XCORD = {xCord}, YCORD = {yCord}");
            mapMarkup[yCord, xCord] = Graphics.GetPicture("Landscape");

        }


        public static void ShowMap()
        {

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("КАРТА МИРА");

            for (int i = 0; i < verticalLendth; i++)
            {

                for (int j = 0; j < horizontalLendth; j++)
                {
                    Console.ForegroundColor = Graphics.SetColor(mapMarkup[i, j]);
                    Console.Write(mapMarkup[i, j]);
                }

                Console.WriteLine();

            }

        }


        public static void MoveArmies(ref List<Army> armies)
        {

            for (int i = 0; i < armies.Count; i++)
            {

                if (!Graphics.nonRewritableTiles.Contains(mapMarkup[armies[i].YCord, armies[i].XCord]))
                    mapMarkup[armies[i].YCord, armies[i].XCord] = Graphics.GetPicture("Landscape");


                Randomizer.RandMovingByOneCell(ref x, ref y);

                if (!restrictedArea.Contains(armies[i].XCord + x) && !restrictedArea.Contains(armies[i].YCord + y))
                {
                    armies[i].XCord += x;
                    armies[i].YCord += y;
                }


                if (!Graphics.nonRewritableTiles.Contains(mapMarkup[armies[i].YCord, armies[i].XCord]))
                    mapMarkup[armies[i].YCord, armies[i].XCord] = armies[i].Graphics;

            }

        }

    }

}