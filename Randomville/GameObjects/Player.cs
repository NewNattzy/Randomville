using System.ComponentModel.DataAnnotations;

namespace GameObjects
{

    public class Player : Creature
    {

        [Required(ErrorMessage = "Оракул: Ты все еще не выбрал класс")]
        public string Special;

        internal static int newLevelExp = 500;
        private int exp = 0;
        
        public Player(string name, int basehealth, int basemana, int damage, int level, int gold, string special)
            : base(name, basehealth, basemana, damage, level, gold)
        {
            Special = special;
        }

        // TODO: Добавить модификаторы в зависимости от уровня сложности под игрока
        public override int Health
        {
            get => health;
            set => health = value;
        }

        public override int Mana
        {
            get => mana; 
            set => mana = value; 
        }

        public int Exp
        {
            get => exp;
            set => exp = value;
        }

        // TODO: Реализовать механику разговоров под игрока
        public override void Talk(string message)
        {
            Console.Write($"{Name} say: ");
            Console.ReadLine();
        }

    }

}