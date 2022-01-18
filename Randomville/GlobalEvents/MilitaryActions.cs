﻿using System;
using GameObjects;
using DataBase;
using Resources;
using GlobalEvents;


namespace GameObjectManagment
{

    public static class MilitaryActions
    {

        private static List<Army>? ParticipantBattle;

        public static void InitializationСonflictsArmiesOnMap(ref List<Army> armies)
        {

            ParticipantBattle = SearchOverlappingArmiesOnMap(armies);

            if (ParticipantBattle != null)
            {
                FillingWorldMap.armies.Remove(BattleOfArmies.GetLoserArmyThatBattle(ParticipantBattle));

            }

        }

        private static List<Army>? SearchOverlappingArmiesOnMap(List<Army> armies)
        {

            for (int i = 0; i < armies.Count; i++)
            {
                for (int j = 1; j < armies.Count; j++)
                {
                    if (armies[i].XCord == armies[j].XCord && armies[i].YCord == armies[j].YCord && armies[i].fraction != armies[j].fraction)
                    {
                        return new List<Army>() { armies[i], armies[j] };
                    }
                }
            }

            return null;

        }


        // TODO: Проблемы с запросами к БД, подумать над переносом в класс Enemy
        public static Enemy CreateSingleUnit(string fraction, string rank)
        {

            if (string.IsNullOrEmpty(fraction) || string.IsNullOrEmpty(rank))
                throw new ArgumentNullException(fraction);


            string sqlQuery = $"SELECT * FROM Names WHERE Fraction='{fraction}' ORDER BY NEWID()";
            List<object> enemyName = DataBaseConnector.GetCollection(sqlQuery);
            string name = (string)enemyName[1] + " " + (string)enemyName[2];


            sqlQuery = $"SELECT * FROM Enemies WHERE Fraction = '{fraction}' AND Rank = '{rank}' ORDER BY NEWID()";
            List<object> param = DataBaseConnector.GetCollection(sqlQuery);


            return new Enemy(name, (string)param[1], (int)param[2], (int)param[3],
                (int)param[4], (int)param[5], (int)param[6], (int)param[7],
                (string)param[8], (string)param[9]);

        }


        // TODO: Подумать над переносом в класс Army, допилить логику добавления юнита в лист
        public static Army CreateArmy(string fraction, int count)
        {

            if (string.IsNullOrEmpty(fraction))
                throw new ArgumentNullException(nameof(fraction));


            WorldMap.PutObjectOnMap(Graphics.GetPicture(fraction), out int xCord, out int yCord);


            Army army = new Army($"Армия: {fraction} ({count})", fraction, xCord, yCord);
            army.Graphics = Graphics.GetPicture(fraction);


            double[] rankRatio = new double[4] { 1, count * 0.1, count * 0.4, count * 0.5 };
            List<string> rank = new List<string>() { "Полководец", "Сержант", "Солдат", "Рядовой" };


            for (int i = 0; i < rankRatio.Length; i++)
            {
                for (int j = 0; j < rankRatio[i]; j++)
                {

                    army.AddUnitInArmy(CreateSingleUnit(fraction, rank[i]));

                }
            }

            return army;

        }


    }

}