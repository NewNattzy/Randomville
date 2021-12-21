using GameObjects;

namespace GameObjectManagment
{

    public static class EnemyManagment
    {

        public static Enemy CreateEnemy()
        {
            Random random = new Random();

            string[] names = { "Волк", "Ворона", "Крокодил" };
            // string name = "Волк";
            int baseHealth = 100;
            int baseMana = 100;
            int gold = 100;
            string type = "Животное";

            return new Enemy(names[random.Next(0, names.Length)], baseHealth, baseMana, 10, 1, gold, type);
        }

        public static void EnemyArmyAttack(EnemyArmy army, City city)
        {
            city.Sieged();
            if (city.Population < army.GetArmyCount(army) * 10)
            {
                city.Destroyed();
            }
        }

    }

}