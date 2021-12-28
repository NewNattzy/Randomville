using System;
using System.ComponentModel.DataAnnotations;


namespace GameObjects
{

    public class Player : Creature
    {

        [Required(ErrorMessage = "Оракул: Ты все еще не выбрал класс")]
        public string Special;


        internal static int newLevelExp = 500;

        public Player(string name, int basehealth, int basemana, int damage, int level, int exp, int gold, string special)
            : base(basehealth, basemana, damage, level, exp, gold)
        {
            // TODO: Проверка входных параметров
            Name = name;
            Special = special;
        }


        [Required(ErrorMessage = "Оракул: Ты ввел недопустимое имя")]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }
        public int Resources { get; set; }

    }

}