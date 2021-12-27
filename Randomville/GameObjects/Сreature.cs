namespace GameObjects

{
    [Serializable]
    public abstract class Creature
    {
        public Creature(int basehealth, int basemana, int damage, int level, int exp, int gold)
        {
            Health = basehealth;
            Mana = basemana;
            Damage = damage;
            Level = level;
            Exp = exp;
            Gold = gold;
        }

        public int Health { get; set; }
        public int Mana { get; set; }
        public int Damage { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int Gold { get; set; }

    }

}