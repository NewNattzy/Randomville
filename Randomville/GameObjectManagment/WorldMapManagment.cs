using System;
using GameConfig;
using DevHelper;
using GameObjects;
using Events;
using GameObjectManagment;


namespace GameObjectManagment
{

    public static class WorldMapManagment
    {

        private static Random random = new Random();
        private static readonly int verticalLendth = Config.MaxMapSize / 5;
        private static readonly int horizontalLendth = Config.MaxMapSize;
        // TODO: Сделать X и Y по нормальному, все время путаюсь
        private static char[,] mapMarkup = new char[verticalLendth, horizontalLendth];


        public static void CreateMap()
        {

            // Отрисовка карты
            for (int i = 0; i < verticalLendth - 1; i++)
                for (int j = 0; j < horizontalLendth - 1; j++)
                    mapMarkup[i, j] = Graphics.GetPicture("Landscape");


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


        public static void PutObject(char objectLabel, out int x, out int y)
        {

            x = 0;
            y = 0;

            while (mapMarkup[y, x] != Graphics.GetPicture("Landscape"))
            {
                x = random.Next(1, horizontalLendth-1);
                y = random.Next(1, verticalLendth-1);
            }

            mapMarkup[y, x] = objectLabel;

        }


        public static List<EnemyArmy> MoveArmies(List<EnemyArmy> armies)
        {

            for(int i = 0; i < armies.Count; i++)
            {

                if (mapMarkup[armies[i].YCord, armies[i].XCord] != Graphics.GetPicture("City"))
                    mapMarkup[armies[i].YCord, armies[i].XCord] = Graphics.GetPicture("Landscape");


                armies[i].XCord += random.Next(-1, 2);
                armies[i].YCord += random.Next(-1, 2);


                // TODO: Придумать решение получше
                if (armies[i].XCord == horizontalLendth - 1)
                    armies[i].XCord = horizontalLendth - 2;

                if (armies[i].YCord == verticalLendth - 1)
                    armies[i].YCord = verticalLendth - 2;

                if (armies[i].XCord == 0)
                    armies[i].XCord = 1;

                if (armies[i].YCord == 0)
                    armies[i].YCord = 1;


                if (mapMarkup[armies[i].YCord, armies[i].XCord] != Graphics.GetPicture("City"))
                    mapMarkup[armies[i].YCord, armies[i].XCord] = armies[i].Graphics;

            }

            return armies;

        }


        public static void RemoveObject(int x, int y)
        {
            mapMarkup[y, x] = Graphics.GetPicture("Landscape");
        }


        public static void ShowMap()
        {

            Console.Clear();
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

    }

}