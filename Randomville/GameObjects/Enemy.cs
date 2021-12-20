namespace GameObjects
{

    public class Enemy : Creature
    {

        public string type;
        static int index = 1;
        public Enemy[] ArrayEnemy;

        public Enemy(string name, int basehealth, int basemana, int damage, int level, int gold, string type)
            : base(name, basehealth, basemana, damage, level, gold)
        {
            this.type = type;
            ArrayEnemy = new Enemy[index];
            index++;
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

        public Enemy this[int index]
        {
            get => ArrayEnemy[index];
            set => ArrayEnemy[index] = value;
        }

        // TODO: Реализовать механику фраз под врагов
        public override void Talk(string message)
        {
            Console.WriteLine($"{Name} say: Ррр!");
        }

    }

}