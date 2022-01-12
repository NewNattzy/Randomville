using System;


namespace GameObjects
{

    public class Army
    {

        public readonly string name;
        public readonly string fraction;

        private static readonly Random random = new Random();
        private static readonly int MAX_ARMY_COUNT = 100;

        private List<Enemy> Units = new List<Enemy>();


        public Army(string name, string fraction, int xCord, int yCord)
        {

            this.name = name;
            this.fraction = fraction;

            UnitCount = 0;
            Gold = random.Next(10, 200);

            XCord = xCord;
            YCord = yCord;

        }


        public int UnitCount { get; private set; }

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


        public void AddUnitInArmy(Enemy enemy)
        {

            CheckArgumentForNull(enemy);

            if (Units.Count < MAX_ARMY_COUNT)
            {
                Units.Add(enemy);
                UnitCount = Units.Count;
            }
                
        }

        public void RemoveUnitFromArmy(Enemy enemy)
        {

            CheckArgumentForNull(enemy);

            UnitCount--;
            Units.Remove(enemy);

        }

        private void CheckArgumentForNull(Enemy enemy)
        {
            if (enemy == null)
                throw new ArgumentNullException(nameof(enemy));
        }


        public void ShowStructure()
        {

            Console.WriteLine($"{name}: ");
            foreach (Enemy unit in Units)
            {

                Console.WriteLine($"{unit.type} {unit.rank} {unit.name}, характеристики: ");
                Console.WriteLine($"HP {unit.Health}, MP {unit.Mana}, Damage {unit.Damage}, Level {unit.Level}\n");

            }

        }

    }

}