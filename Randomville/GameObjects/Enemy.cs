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

        // TODO: Добавить модификаторы в зависимости от уровня сложности под врагов
        public override int Health
        {
            get => health;
            set => health = value;
        }

        public override int Mana
        {
            get => health;
            set => health = value;
        }

        // TODO: Реализовать механику фраз под врагов
        public override void Talk(string message)
        {
            Console.WriteLine($"{Name} say: Ррр!");
        }

    }

}