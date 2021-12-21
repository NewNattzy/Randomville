using GameObjects;

namespace GameObjectManagment
{

    public static class EnemyManagment
    {

        public static Enemy CreateEnemy()
        {

            string name = "Волк";
            int baseHealth = 100;
            int baseMana = 100;
            int gold = 100;
            string type = "Животное";

            return new Enemy(name, baseHealth, baseMana, 10, 1, gold, type);

        }

    }

}