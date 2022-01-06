using System;
using GameConfig;
using DevHelper;
using GameObjects;


namespace GameObjectManagment
{

    public static class WorldMap
    {

        private static Random random = new Random();
        private static readonly int verticalLendth = Config.MaxMapSize / 5;
        private static readonly int horizontalLendth = Config.MaxMapSize;
        private static readonly int[] restrictedArea = new int[3] { 0, horizontalLendth - 1, verticalLendth - 1 };

        // TODO: Переписать вместе с генерацией координат, много повторяющегося кода
        private static int x;
        private static int y;

        // TODO: Поправить координаты x, y. Часто путаюсь, что плохо
        private static char[,] mapMarkup = new char[verticalLendth, horizontalLendth];


        public static void RandomizeCord()
        {

            x = random.Next(1, horizontalLendth - 1);
            y = random.Next(1, verticalLendth - 1);

        }


        public static void CreateMap()
        {

            for (int i = 0; i < verticalLendth - 1; i++)
                for (int j = 0; j < horizontalLendth - 1; j++)
                    mapMarkup[i, j] = Graphics.GetPicture("Landscape");
                    
            AddBoundaries();
            AddStaticObjects();

        }


        public static void AddBoundaries()
        {

            // Отрисовка стен
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

            // Отрисовка углов
            mapMarkup[0, 0] = Graphics.GetPicture("UpperLeftCorner");
            mapMarkup[0, horizontalLendth - 1] = Graphics.GetPicture("LowerLeftCorner");
            mapMarkup[verticalLendth - 1, 0] = Graphics.GetPicture("UpperRightCorner");
            mapMarkup[verticalLendth - 1, horizontalLendth - 1] = Graphics.GetPicture("LowerRightCorner");

        }


        // TODO: Добавить логику "группировки" скал и отрисовки рек от края карты (не точечно)
        public static void AddStaticObjects()
        {

            RandomizeCord();

            for (int i = 0; i < 10; i++)
            {
                RandomizeCord();
                mapMarkup[y, x] = Graphics.GetPicture("Mountain");
            }

            for (int i = 0; i < 5; i++)
            {

                RandomizeCord();
                mapMarkup[y, x] = Graphics.GetPicture("River");

            }

        }


        public static void PutObject(char objectLabel, out int x, out int y)
        {

            x = random.Next(1, horizontalLendth - 1);
            y = random.Next(1, verticalLendth - 1);

            while (mapMarkup[y, x] != Graphics.GetPicture("Landscape"))
            {
                x = random.Next(1, horizontalLendth - 1);
                y = random.Next(1, verticalLendth - 1);
            }

            mapMarkup[y, x] = objectLabel;

        }


        public static void RemoveObject(int xCord, int yCord)
        {

            Console.WriteLine($"Удален объект: XCORD = {xCord}, YCORD = {yCord}");
            mapMarkup[yCord, xCord] = Graphics.GetPicture("Landscape");

        }


        public static void ShowMap()
        {

            Console.SetCursorPosition(0, 0);
            //Thread.Sleep(100);
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


                x = random.Next(-1, 2);
                y = random.Next(-1, 2);

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