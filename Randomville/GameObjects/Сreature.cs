using System.ComponentModel.DataAnnotations;

namespace GameObjects

{

    public abstract class Creature
    {
        public Creature(string name, int basehealth, int basemana, int damage, int level, int gold)
        {
            Name = name;
            Health = basehealth;
            Mana = basemana;
            Damage = damage;
            Level = level;
            Gold = gold;
        }


        [Required(ErrorMessage = "Оракул: Ты ввел недопустимое имя")]
        [StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }


    }

}