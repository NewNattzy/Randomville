using System;
using DataBase;


namespace DevHelper
{

    public static class Graphics
    {

        private static Dictionary<string, char> pictures = new Dictionary<string, char>();
        private static Dictionary<char, ConsoleColor> colors = new Dictionary<char, ConsoleColor>();

        public static readonly List<char> nonRewritableTiles = new List<char>();


        public static char GetPicture(string name)
        {

            return pictures.ContainsKey(name) ? pictures[name] : '0';

        }


        public static void SetPicture()
        {

            for (int i = 1; i < 14; i++)
            {

                string sqlQuery = $"SELECT Name, Symbol, Color, Overwriting FROM Graphics WHERE ID={i}";

                List<object> graphics = DataBaseConnector.GetCollection(sqlQuery);

                pictures.Add((string)graphics[0], Convert.ToChar(graphics[1]));
                colors.Add(Convert.ToChar(graphics[1]), (ConsoleColor)graphics[2]);


                if ((bool)graphics[3] == false)
                {

                    nonRewritableTiles.Add(Convert.ToChar(graphics[1]));

                }

            }

        }


        public static ConsoleColor SetColor(char mapObject)
        {

            if (colors.ContainsKey(mapObject))
                return colors[mapObject];
            else
                return ConsoleColor.White;

        }

    }

}

