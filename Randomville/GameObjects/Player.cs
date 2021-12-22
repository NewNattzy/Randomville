using System.ComponentModel.DataAnnotations;

namespace GameObjects
{

    public class Player : Creature
    {

        [Required(ErrorMessage = "Оракул: Ты все еще не выбрал класс")]
        public string Special;

        internal static int newLevelExp = 500;

        public Player(string name, int basehealth, int basemana, int damage, int level, int gold, string special)
            : base(name, basehealth, basemana, damage, level, gold)
        {
            Special = special;
        }
        public int Exp { get; set; }
        public int Resources { get; set; }

    }

}