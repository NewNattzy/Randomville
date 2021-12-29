using System;
using GameObjects;
using DataBase;
using DevHelper;


namespace GameObjectManagment
{

    public static class EnemyManagment
    {

        public static Enemy CreateSingleEnemy(string type, string rank)
        {

            // TODO: Такое себе, надо переписать
            if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(rank))
                throw new ArgumentNullException();


            string sqlQuery = $"SELECT * FROM Names WHERE Fraction='{type}' ORDER BY NEWID()";
            List<object> enemyName = SqlConnector.GetCollection(sqlQuery);
            string name = (string)enemyName[1] + " " + (string)enemyName[2];


            sqlQuery = $"SELECT * FROM Enemies WHERE Fraction = '{type}' AND Rank = '{rank}' ORDER BY NEWID()";
            List<object> param = SqlConnector.GetCollection(sqlQuery);


            return new Enemy(name, (string)param[1], (int)param[2], (int)param[3],
                (int)param[4], (int)param[5], (int)param[6], (int)param[7],
                (string)param[8], (string)param[9]);

        }


        public static EnemyArmy CreateArmyEnemy(string type, int count, ref WorldMap map)
        {

            if (string.IsNullOrEmpty(type))
                throw new ArgumentNullException(nameof(type));


            int xCord;
            int yCord;
            map.PutObject(Graphics.enemyArmy, out xCord, out yCord);


            string name = $"Армия: {type} ({count})";
            EnemyArmy army = new EnemyArmy(name, xCord, yCord);
            army.Add(CreateSingleEnemy(type, "Полководец"));


            // Изменяем процентное соотношение типов воиск в армии
            double[] rankCount = new double[3] {count*0.5, count*0.4, count*0.1};
            List<string> rankList = new List<string>() { "Рядовой", "Солдат", "Сержант"};


            for (int i = 0; i < rankCount.Length; i++)
            {
                for(int j = 0; j < rankCount[i]; j++)
                {
                    army.Add(CreateSingleEnemy(type, rankList[i]));
                }
            }

            return army;

        }


        // TODO: Должно ли это быть в классе EnemyArmy?
        public static void ShowStructureArmy(EnemyArmy army)
        {

            Console.WriteLine($"{army.Name}: ");

            for (int i = 0; i < army.UnitCount; i++)
            {
                Console.WriteLine($"{army[i].Type} {army[i].Rank} {army[i].Name}, характеристики: ");
                Console.WriteLine($"HP {army[i].Health}, MP {army[i].Mana}, Damage {army[i].Damage}, Level {army[i].Level}\n");
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