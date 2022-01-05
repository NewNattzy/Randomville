using System;
using GameObjects;


namespace Events
{

    public class Fight
    {

        // TODO: Не оптимизировано, изменить логику подсчета урона (по юнитам)
        public static void ArmyFight(EnemyArmy blueArmy, EnemyArmy redArmy, ref List<EnemyArmy> armies)
        {

            if (blueArmy == null)
                throw new ArgumentNullException(nameof(blueArmy));
            else if (redArmy == null)
                throw new ArgumentNullException(nameof(redArmy));


            int[] blueStats = new int[3];
            int[] redStats = new int[3];
            double percent = 0.055;


            for (int i = 0; i < blueArmy.UnitCount; i++)
            {
                blueStats[0] += blueArmy[i].Health;
                blueStats[1] += blueArmy[i].Damage;
                blueStats[2] += blueArmy[i].Mana;
            }
            blueStats[1] += (int)(blueStats[2] * percent);


            for(int i = 0;i < redArmy.UnitCount; i++)
            {
                redStats[0] += redArmy[i].Health;
                redStats[1] += redArmy[i].Damage;
                redStats[2] += redArmy[i].Mana;
            }
            redStats[1] += (int)(redStats[2] * percent);


            while (blueStats[0] > 0 || redStats[0] > 0)
            {
                blueStats[0] -= redStats[1];
                redStats[0] -= blueStats[1];
            }


            if (blueStats[0] > redStats[0])
                armies.Remove(redArmy);
            else
                armies.Remove(blueArmy);

        }

    }

}