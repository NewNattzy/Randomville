using System;
using DataBase;


namespace DevHelper
{

    public static class Graphics
    {

        private static Dictionary<string, char> pictures = new Dictionary<string, char>();
        private static Dictionary<char, ConsoleColor> colors = new Dictionary<char, ConsoleColor>();


        public static char GetPicture(string name)
        {
            foreach (string key in pictures.Keys)
                if (key == name)
                    return pictures[key];

            return '0';
        }


        // TODO: Переписать вместе с запросами к БД. Уже лучше, но все еще мрак.
        public static void SetPicture()
        {

            for (int i = 1; i < 12; i++)
            {
                string sqlQuery = $"SELECT Name, Symbol, Color FROM Graphics WHERE ID={i}";

                List<object> graphics = SqlConnector.GetCollection(sqlQuery);

                pictures.Add((string)graphics[0], Convert.ToChar(graphics[1]));
                colors.Add(Convert.ToChar(graphics[1]), (ConsoleColor)graphics[2]);
            }

        }


        public static ConsoleColor SetColor(char mapObject)
        {

            foreach (char key in colors.Keys)
                if (key == mapObject)
                    return colors[key];

            return ConsoleColor.White;

        }

    }

}

