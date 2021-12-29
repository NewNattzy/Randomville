using System;
using GameConfig;
using DevHelper;


namespace GameObjects
{

    public class WorldMap
    {

        private static int verticalLendth = Config.MaxMapSize / 5;
        private static int horizontalLendth = Config.MaxMapSize;
        private static char[,] mapMarkup = new char[verticalLendth, horizontalLendth];

        public WorldMap() { }

        public void CreateMap()
        {

            // Отрисовка карты
            for (var i = 0; i < verticalLendth - 1; i++)
                for (var j = 0; j < horizontalLendth - 1; j++)
                    mapMarkup[i, j] = Graphics.landscape;
                    

            // Отрисовка стен
            for (var i = 0; i < horizontalLendth - 1; i++)
            {
                mapMarkup[0, i] = Graphics.horizontalWall;
                mapMarkup[verticalLendth - 1, i] = Graphics.horizontalWall;
            }

            for (var i = 0; i < verticalLendth - 1; i++)
            {
                mapMarkup[i, 0] = Graphics.verticalWall;
                mapMarkup[i, horizontalLendth - 1] = Graphics.verticalWall;
            }


            // Отрисовка углов
            mapMarkup[0, 0] = Graphics.upperLeftCorner;
            mapMarkup[0, horizontalLendth - 1] = Graphics.lowerLeftCorner;
            mapMarkup[verticalLendth - 1, 0] = Graphics.upperRightCorner;
            mapMarkup[verticalLendth - 1, horizontalLendth - 1] = Graphics.lowerRightCorner;

        }


        public void PutObject(char objectLabel, out int x, out int y)
        {
            Random random = new Random();

            // Тут бы что-нибудь придумать..
            x = random.Next(1, horizontalLendth-1);
            y = random.Next(1, verticalLendth-1);

            // Поиск свободного места на карте
            while (mapMarkup[y, x] != Graphics.landscape)
            {
                x = random.Next(1, horizontalLendth-1);
                y = random.Next(1, verticalLendth-1);
            }

            mapMarkup[y, x] = objectLabel;

        }


        public void ShowMap()
        {
            Console.Clear();
            for (var i = 0; i < verticalLendth; i++)
            {    
                for (var j = 0; j < horizontalLendth; j++)
                    Console.Write(mapMarkup[i, j]);
                Console.WriteLine();
            }
                
        }

    }

}


