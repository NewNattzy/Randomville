using System;
using GameConfig;
using Resources;
using GameObjects;
using Helper;


namespace GameObjects
{

    public static class WorldMap
    {

        internal static readonly int verticalLendth = Config.MaxMapSize / 5;
        internal static readonly int horizontalLendth = Config.MaxMapSize;
        private static readonly int[] restrictedArea = new int[3] { 0, horizontalLendth - 1, verticalLendth - 1};

        private static int x;
        private static int y;

        private static char[,] mapMarkup = new char[verticalLendth, horizontalLendth];
        private static char oldPlayerLocation = Graphics.GetPicture("Landscape");


        public static void CreateMap()
        {

            for (int i = 0; i < verticalLendth - 1; i++)
                for (int j = 0; j < horizontalLendth - 1; j++)
                    mapMarkup[i, j] = Graphics.GetPicture("Landscape");

            AddMapBorders();
            AddMapBorderCorners();
            AddStaticObjects();

        }

        private static void AddMapBorders()
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
        }

        private static void AddMapBorderCorners()
        {

            mapMarkup[0, 0] = Graphics.GetPicture("UpperLeftCorner");
            mapMarkup[0, horizontalLendth - 1] = Graphics.GetPicture("LowerLeftCorner");
            mapMarkup[verticalLendth - 1, 0] = Graphics.GetPicture("UpperRightCorner");
            mapMarkup[verticalLendth - 1, horizontalLendth - 1] = Graphics.GetPicture("LowerRightCorner");

        }


        private static void AddStaticObjects()
        {

            AddRiverOnMap();
            AddMountainsOnMap();

        }



        private static void AddMountainsOnMap()
        {
            
            for (int i = 0; i < 10; i++)
            {
                Randomizer.RandCordOnMap(ref x, ref y);
                mapMarkup[y, x] = Graphics.GetPicture("Mountain");
            }

            for (int i = 0; i < 40; i++)
            {
                Randomizer.RandCordNextToBorder(ref x, ref y);
                mapMarkup[y, x] = Graphics.GetPicture("Mountain");
            }

        }


        private static void AddRiverOnMap()
        {
            for (int i = 0; i < 10; i++)
            {
                Randomizer.RandCordNextToBorder(ref x, ref y);
                mapMarkup[y, x] = Graphics.GetPicture("River");
            }

        }


        public static void PutObjectOnMap(char objectLabel, out Coordinate cord)
        {

            do
            {
                x = Randomizer.random.Next(1, horizontalLendth - 1);
                y = Randomizer.random.Next(1, verticalLendth - 1);
                cord = new Coordinate(x, y);
            }
            while (mapMarkup[cord.Y, cord.X] != Graphics.GetPicture("Landscape"));
            {
                cord.X = Randomizer.random.Next(1, horizontalLendth - 1);
                cord.Y = Randomizer.random.Next(1, verticalLendth - 1);
            }

            mapMarkup[cord.Y, cord.X] = objectLabel;

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

                if (!Graphics.nonRewritableTiles.Contains(mapMarkup[armies[i].cord.Y, armies[i].cord.X]))
                    mapMarkup[armies[i].cord.Y, armies[i].cord.X] = Graphics.GetPicture("Landscape");


                Randomizer.RandMovingByOneCell(ref x, ref y);

                if (!restrictedArea.Contains(armies[i].cord.X + x) && !restrictedArea.Contains(armies[i].cord.Y + y))
                {
                    armies[i].cord.X += x;
                    armies[i].cord.Y += y;
                }


                if (!Graphics.nonRewritableTiles.Contains(mapMarkup[armies[i].cord.Y, armies[i].cord.X]))
                    mapMarkup[armies[i].cord.Y, armies[i].cord.X] = armies[i].Graphics;

            }

        }



        // TODO: Исправить, временная "реализация"
        public static void RemovePlayerFromOldPoint(int x, int y)
        {

            try
            {

                mapMarkup[y, x] = oldPlayerLocation;

            }
            catch (IndexOutOfRangeException ex)
            {

                Console.WriteLine("Выход игрока за границы карты");
                Console.WriteLine(ex.Message);

            }
            
        }

        public static void PlayerMove(int x, int y)
        {
            try
            {

                if (!restrictedArea.Contains(y) || !restrictedArea.Contains(x))
                {
                    oldPlayerLocation = mapMarkup[y, x];
                    mapMarkup[y, x] = Graphics.GetPicture("Player");
                }

            }
            catch (IndexOutOfRangeException ex)
            {

                Console.WriteLine("Выход игрока за границы карты");
                Console.WriteLine(ex.Message);

            }

        }

    }

}