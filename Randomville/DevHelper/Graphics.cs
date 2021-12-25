using System;

namespace DevHelper
{
    public static class Graphics
    {

        // Пока так, потом поменяю
        public static readonly char wall = Convert.ToChar(8);
        public static readonly char emptyPlace = Convert.ToChar(193);
        public static readonly char enemyArmy = Convert.ToChar(2);
        public static readonly char player = Convert.ToChar(1);

        public static readonly char verticalWall = Convert.ToChar(205);
        public static readonly char horizontalWall = Convert.ToChar(186);

        public static readonly char upperLeftCorner = Convert.ToChar(201);
        public static readonly char upperRightCorner = Convert.ToChar(187);
        public static readonly char lowerLeftCorner = Convert.ToChar(200);
        public static readonly char lowerRightCorner = Convert.ToChar(188);

    }
}