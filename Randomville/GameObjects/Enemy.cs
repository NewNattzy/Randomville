using System;


namespace GameObjects
{

    public class Enemy : Creature
    {

        public readonly string name;
        public readonly string fraction;
        public readonly string type;
        public readonly string rank;

        public Enemy(string name, string type, int basehealth, int basemana, int damage, int level, int exp, int gold, string fraction, string rank)
            : base(basehealth, basemana, damage, level, exp, gold)
        {

            this.name = name;
            this.type = type;
            this.fraction = fraction;
            this.rank = rank;

        }

    }

}