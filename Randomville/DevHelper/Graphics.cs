using Microsoft.VisualBasic;
using System;


namespace DevHelper
{

    public static class Graphics
    {

        // Пока так, потом поменяю
        public static readonly char wall = Convert.ToChar(8);
        public static readonly char landscape = Convert.ToChar('.'); //2591


        public static readonly char enemyArmy = Convert.ToChar('@');
        public static readonly char player = Convert.ToChar(1);
        public static readonly char city = Convert.ToChar('\u2302');


        public static readonly char verticalWall = Convert.ToChar('\u2551');
        public static readonly char horizontalWall = Convert.ToChar('\u2550');


        public static readonly char upperLeftCorner = Convert.ToChar('\u2554');
        public static readonly char upperRightCorner = Convert.ToChar('\u255A');
        public static readonly char lowerLeftCorner = Convert.ToChar('\u2557');
        public static readonly char lowerRightCorner = Convert.ToChar('\u255D');


    }
}