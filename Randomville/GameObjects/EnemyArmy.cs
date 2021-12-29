using System;


namespace GameObjects
{

    [Serializable]
    public class EnemyArmy
    {

        [NonSerialized]
        private readonly Random random = new Random();

        private const int MAX_ARMY_COUNT = 100;

        private List<Enemy> MonsterArmy = new List<Enemy>();


        public EnemyArmy() {}


        public EnemyArmy(string name, int xCord, int yCord)
        {
            // TODO: Проверка входных параметров
            Name = name;
            UnitCount = 0;
            Gold = random.Next(10, 200);

            XCord = xCord;
            YCord = yCord;
        }


        public string? Name { get; set; }
        public int UnitCount { get; set; }
        public int Gold { get; set; }
        public int KillScore { get; set; }
        public int DestroyScore { get; set; }
        public int XCord { get; set; }
        public int YCord { get; set; }


        public Enemy this[int index]
        {
            get => MonsterArmy[index];
            set => MonsterArmy[index] = value;
        }


        public void Add(Enemy enemy)
        {

            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy));

            if (MonsterArmy.Count < MAX_ARMY_COUNT)
            {
                MonsterArmy.Add(enemy);
                UnitCount = MonsterArmy.Count;
            }
                
        }


        public void Remove(Enemy enemy)
        {
            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy));
            MonsterArmy.Remove(enemy);
        }

    }

}