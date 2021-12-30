using System;


namespace DevHelper
{

    public static class Graphics
    {

        private static Dictionary<string, char> pictures = new Dictionary<string, char>();


        public static char GetPicture(string name)
        {
            foreach (string key in pictures.Keys)
                if (key == name)
                    return pictures[key];

            return '0';
        }


        // TODO: Поискать другие варианты для заполнения
        public static void SetPicture()
        {
            pictures.Add("wall", Convert.ToChar(8));
            pictures.Add("landscape", Convert.ToChar('.'));

            pictures.Add("Нежить", Convert.ToChar('O'));
            pictures.Add("Орда", Convert.ToChar('N'));
            pictures.Add("player", Convert.ToChar(1));

            pictures.Add("city", Convert.ToChar('\u2302'));

            pictures.Add("verticalWall", Convert.ToChar('\u2551'));
            pictures.Add("horizontalWall", Convert.ToChar('\u2550'));

            pictures.Add("upperLeftCorner", Convert.ToChar('\u2554'));
            pictures.Add("upperRightCorner", Convert.ToChar('\u255A'));
            pictures.Add("lowerLeftCorner", Convert.ToChar('\u2557'));
            pictures.Add("lowerRightCorner", Convert.ToChar('\u255D'));
        }

    }

}