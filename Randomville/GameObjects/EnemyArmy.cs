using System;


namespace GameObjects
{
    public class EnemyArmy
    {
        public const int MAX_ARMY_COUNT = 100;
        private List<Enemy> MonsterArmy = new List<Enemy>();

        public EnemyArmy(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public Enemy this[int index]
        {
            get => MonsterArmy[index];
            set => MonsterArmy[index] = value;
        }

        public void Add(Enemy enemy)
        {
            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy) + "Enemy is null");

            if (MonsterArmy.Count < MAX_ARMY_COUNT)
                MonsterArmy.Add(enemy);
        }

        public void Remove(Enemy enemy)
        {
            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy) + "Enemy is null");

            if (MonsterArmy.Count <= MAX_ARMY_COUNT)
                MonsterArmy.Remove(enemy);
        }

    }

}