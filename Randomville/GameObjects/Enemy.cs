namespace GameObjects
{

    public class Enemy : Creature
    {

        public string type;

        public Enemy(string name, int basehealth, int basemana, int damage, int level, int gold, string type)
            : base(name, basehealth, basemana, damage, level, gold)
        {
            this.type = type;
        }

    }

}