using System;
using GameObjects;
using Helper;
using Resources;


namespace GameObjects
{

    public class Player : Creature
    {

        public readonly string name;
        public readonly string special;


        public Coordinate cord;
        private Random random = new Random();


        public Player(string name, int basehealth, int basemana, int damage, int level, int exp, int gold, string special)
            : base(basehealth, basemana, damage, level, exp, gold)
        {

            this.name = name;
            this.special = special;


            WorldMap.PutObjectOnMap(Graphics.GetPicture("Player"), out cord);
            cord = new Coordinate(cord.X, cord.Y);

        }


        public int Resources { get; set; }

        public void ShowParameters()
        {

            Console.WriteLine("Характеристики персонажа:");
            Console.WriteLine($"Имя           : {name}");
            Console.WriteLine($"Класс         : {special}");
            Console.WriteLine($"Уровень       : {Level}");
            Console.WriteLine($"Здоровье      : {Health}");
            Console.WriteLine($"Мана          : {Mana}");
            Console.WriteLine($"Урон          : {Damage}");
            Console.WriteLine($"Опыт          : {Exp}");
            Console.WriteLine($"Золото        : {Gold}\n");

        }

    }

}