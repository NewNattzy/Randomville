using System;
using GameConfig;
using DevHelper;
using GameObjects;
using Events;


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
                    mapMarkup[i, j] = Graphics.GetPicture("landscape");


            // Отрисовка стен
            for (int i = 0; i < horizontalLendth - 1; i++)
            {
                mapMarkup[0, i] = Graphics.GetPicture("horizontalWall");
                mapMarkup[verticalLendth - 1, i] = Graphics.GetPicture("horizontalWall");
            }

            for (int i = 0; i < verticalLendth - 1; i++)
            {
                mapMarkup[i, 0] = Graphics.GetPicture("verticalWall");
                mapMarkup[i, horizontalLendth - 1] = Graphics.GetPicture("verticalWall");
            }


            // Отрисовка углов
            mapMarkup[0, 0] = Graphics.GetPicture("upperLeftCorner");
            mapMarkup[0, horizontalLendth - 1] = Graphics.GetPicture("lowerLeftCorner");
            mapMarkup[verticalLendth - 1, 0] = Graphics.GetPicture("upperRightCorner");
            mapMarkup[verticalLendth - 1, horizontalLendth - 1] = Graphics.GetPicture("lowerRightCorner");

        }


        public static void PutObject(char objectLabel, out int x, out int y)
        {

            x = 0;
            y = 0;

            while (mapMarkup[y, x] != Graphics.GetPicture("landscape"))
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

                // Заменяем текущий символ по координате армии на стандартный
                mapMarkup[armies[i].YCord, armies[i].XCord] = Graphics.GetPicture("landscape");


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


                mapMarkup[armies[i].YCord, armies[i].XCord] = armies[i].Graphics;

            }

            return armies;

        }


        public static void RemoveObject(int x, int y)
        {
            mapMarkup[y, x] = Graphics.GetPicture("landscape");
        }


        public static void ShowMap()
        {
            Console.Clear();
            for (int i = 0; i < verticalLendth; i++)
            {
                for (int j = 0; j < horizontalLendth; j++)
                    Console.Write(mapMarkup[i, j]);
                Console.WriteLine();
            }

        }

    }

}