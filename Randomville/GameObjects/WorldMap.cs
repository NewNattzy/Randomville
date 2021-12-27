using GameConfig;
using DevHelper;

namespace GameObjects
{
    public class WorldMap
    {

        private static int maxLendthSide = Config.MaxMapSize / 10;
        private int auxiliaryLength = maxLendthSide - 1;
        private static char[,] mapMarkup = new char[maxLendthSide, maxLendthSide];

        public WorldMap()
        {

        }

        public void CreateMap()
        {
            for (var i = 0; i < maxLendthSide; i++)
                for (var j = 0; j < maxLendthSide; j++)
                    mapMarkup[i, j] = Convert.ToChar(500);

            // Отрисовка стен карты
            for (var i = 0; i < maxLendthSide; i++)
            {
                mapMarkup[0, i] = Graphics.verticalWall;
                mapMarkup[i, 0] = Graphics.verticalWall;
            }

            for (var i = 0; i < maxLendthSide; i++)
            {
                mapMarkup[auxiliaryLength, i] = Graphics.horizontalWall;
                mapMarkup[i, auxiliaryLength] = Graphics.horizontalWall;
            }

            // Отрисовка углов карты
            mapMarkup[0, 0] = Graphics.upperLeftCorner;
            mapMarkup[0, auxiliaryLength] = Graphics.lowerLeftCorner;
            mapMarkup[auxiliaryLength, 0] = Graphics.upperRightCorner;
            mapMarkup[auxiliaryLength, auxiliaryLength] = Graphics.lowerRightCorner;

        }

        public void ShowMap()
        {

            for (var i = 0; i < maxLendthSide; i++)
            {    
                for (var j = 0; j < maxLendthSide; j++)
                    Console.Write(mapMarkup[i, j]);
                Console.WriteLine();
            }
                
        }

    }

}