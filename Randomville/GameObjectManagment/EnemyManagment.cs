using GameObjects;

namespace GameObjectManagment
{

    public static class EnemyManagment
    {

        private static Random random = new Random();

        public static Enemy CreateSingleEnemy(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            int baseHealth = random.Next(100, 1000);
            int baseMana = 100;
            int gold = 100;
            string rank = "";
            string fraction = "Нежить";
            if (baseHealth < 300)
                rank = "Рядовой";
            else if (baseHealth > 300)
                rank = "Солдат";

                return new Enemy(type, baseHealth, baseMana, 10, 1, 10, gold, fraction, rank);
        }

        public static EnemyArmy CreateArmyEnemy(string type, int count)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            EnemyArmy army = new EnemyArmy($"Армия: {type} ({count})");

            for (int i = 0; i < count; i++)
                army.Add(CreateSingleEnemy($"{type}"));

            return army;
        }

        // TODO: Должно ли это быть в классе EnemyArmy?
        public static void ShowStructureArmy(EnemyArmy army)
        {
            for (int i = 0; i < army.UnitCount; i++)
            {
                Console.WriteLine($"{army[i].Rank} армии {army.Name}, здоровье: {army[i].Health}");
            }
        }

        public static void BesiegeCity(EnemyArmy army, City city)
        {
            army.KillScore += city.Besiege();

            if (city.Status == "Уничтожен")
                army.DestroyScore++;
                army.Gold += city.Gold;
        }

    }

}