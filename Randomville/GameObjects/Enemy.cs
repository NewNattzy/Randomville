using System.ComponentModel.DataAnnotations;

namespace GameObjects
{
    [Serializable]
    public class Enemy : Creature
    {

        public Enemy(string name, string type, int basehealth, int basemana, int damage, int level, int exp, int gold, string fraction, string rank)
            : base(basehealth, basemana, damage, level, exp, gold)
        {
            // TODO: Проверка входных параметров
            Name = name;
            Type = type;
            Fraction = fraction;
            Rank = rank;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Fraction { get; set; }
        public string Rank { get; set; }

    }

}