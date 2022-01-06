using System;


namespace GameObjects
{

    public class Army
    {

        [NonSerialized]
        private readonly Random random = new Random();

        private const int MAX_ARMY_COUNT = 100;

        private List<Enemy> Units = new List<Enemy>();


        public Army(string name, string fraction, int xCord, int yCord)
        {

            // TODO: Проверка входных параметров
            Name = name;
            Fraction = fraction;

            UnitCount = 0;
            Gold = random.Next(10, 200);

            XCord = xCord;
            YCord = yCord;

        }


        public string? Name { get; set; }
        public string Fraction { get; set; }

        public int UnitCount { get; set; }
        public int Gold { get; set; }
        public int KillScore { get; set; }
        public int DestroyScore { get; set; }

        public int XCord { get; set; }
        public int YCord { get; set; }

        public char Graphics { get; set; }


        public Enemy this[int index]
        {

            get => Units[index];
            set => Units[index] = value;

        }


        public void Add(Enemy enemy)
        {

            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy));

            if (Units.Count < MAX_ARMY_COUNT)
            {

                Units.Add(enemy);
                UnitCount = Units.Count;

            }
                
        }


        public void Remove(Enemy enemy)
        {

            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy));
            Units.Remove(enemy);

        }


        public void ShowStructure()
        {

            Console.WriteLine($"{Name}: ");
            foreach (Enemy enemy in Units)
            {

                Console.WriteLine($"{enemy.Type} {enemy.Rank} {enemy.Name}, характеристики: ");
                Console.WriteLine($"HP {enemy.Health}, MP {enemy.Mana}, Damage {enemy.Damage}, Level {enemy.Level}\n");

            }

        }

    }

}