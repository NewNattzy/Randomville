using GameObjects;

namespace GameObjectManagment
{

    public static class EnemyManagment
    {

        private static readonly Random random = new Random();

        public static Enemy CreateSingleEnemy(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException(nameof(type));
            }

            string[] names = { "Волк", "Ворона", "Крокодил" };
            int baseHealth = 100;
            int baseMana = 100;
            int gold = 100;

            return new Enemy(names[random.Next(0, names.Length)], baseHealth, baseMana, 10, 1, gold, type);
        }

        // TODO: Валидация входящих параметров
        public static EnemyArmy CreatyEnemyArmy(string type, int count)
        {
                EnemyArmy army = new EnemyArmy($"Армия: {type} ({count})");

                for (int i = 0; i < count; i++)
                    army.Add(CreateSingleEnemy($"{type}"));

                return army;
        }

        public static void SiegeCity(EnemyArmy army, City city)
        {
            city.Sieged();
            army.Gold += city.Robbery();

            if (city.Population < army.UnitCount * 10)
            {
                army.Gold += city.Gold;
                city.Destroyed();
            }
        }

    }

}