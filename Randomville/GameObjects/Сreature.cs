using System.ComponentModel.DataAnnotations;

namespace GameObjects

{

    public abstract class Creature
    {

        private protected string name;

        private protected int health;
        private protected int mana;

        private int damage;
        private int level;
        private int gold;

        public Creature(string name, int basehealth, int basemana, int damage, int level, int gold)
        {
            this.name = name;
            this.level = level;
            this.health = basehealth * level;
            this.mana = basemana * level;
            this.damage = damage;
            this.gold = gold;
        }

        [Required(ErrorMessage = "Оракул: Ты ввел недопустимое имя")]
        [StringLength(10, MinimumLength = 3)]
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

        public int Level
        {
            get => level;
            set => level = value;
        }

        public int Gold
        {
            get => gold;
            set => gold = value;
        }

        public abstract int Health { get; set; }

        public abstract int Mana { get; set; }

        public abstract void Talk(string message);

    }

}