using System;
using GameObjects;
using DataBase;
using DevHelper;
using Events;


namespace GameObjectManagment
{

    public static class EnemyManagment
    {

        public static Enemy CreateSingleEnemy(string fraction, string rank)
        {

            // TODO: Проблемы с запросами к БД, подумать над переносом в класс Enemy
            if (string.IsNullOrEmpty(fraction) || string.IsNullOrEmpty(rank))
                throw new ArgumentNullException(fraction);


            string sqlQuery = $"SELECT * FROM Names WHERE Fraction='{fraction}' ORDER BY NEWID()";
            List<object> enemyName = SqlConnector.GetCollection(sqlQuery);
            string name = (string)enemyName[1] + " " + (string)enemyName[2];


            sqlQuery = $"SELECT * FROM Enemies WHERE Fraction = '{fraction}' AND Rank = '{rank}' ORDER BY NEWID()";
            List<object> param = SqlConnector.GetCollection(sqlQuery);


            return new Enemy(name, (string)param[1], (int)param[2], (int)param[3],
                (int)param[4], (int)param[5], (int)param[6], (int)param[7],
                (string)param[8], (string)param[9]);

        }


        // TODO: Подумать над переносом в класс EnemyArmy, допилить логику добавления юнита в лист
        public static EnemyArmy CreateEnemyArmy(string fraction, int count)
        {

            if (string.IsNullOrEmpty(fraction))
                throw new ArgumentNullException(nameof(fraction));


            WorldMapManagment.PutObject(Graphics.GetPicture(fraction), out int xCord, out int yCord);


            EnemyArmy army = new EnemyArmy($"Армия: {fraction} ({count})", fraction, xCord, yCord);
            army.Graphics = Graphics.GetPicture(fraction);
            
            
            double[] rankRatio = new double[4] { 1, count * 0.1, count * 0.4, count * 0.5 };
            List<string> rank = new List<string>() { "Полководец", "Сержант", "Солдат", "Рядовой"};


            for (int i = 0; i < rankRatio.Length; i++)
            {
                for (int j = 0; j < rankRatio[i]; j++)
                {

                    army.Add(CreateSingleEnemy(fraction, rank[i]));

                }
            }
            
            return army;

        }


        public static void CheckArmiesConflict(ref List<EnemyArmy> armies)
        {

            for (int i = 0; i < armies.Count; i++)
                for (int j = 1; j < armies.Count; j++)
                    if (armies[i].XCord == armies[j].XCord && armies[i].YCord == armies[j].YCord && armies[i].Fraction != armies[j].Fraction)
                    {

                        Fight.ArmyFight(armies[i], armies[j], ref armies);

                    }       

        }

    }

}