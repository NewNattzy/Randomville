using System;
using GameObjects;


namespace GameObjectManagment
{
    public static class PlayerUpgrade
    {

        private static Player temp;

        private static int expToLevelUp = 500;


        public static void TryLevelUP(ref Player player)
        {

            temp = player;

            GetReplicasWhenLevelUp("Begin");

            if (Console.ReadLine() == "Да" && CheckSolvency() == true)
            {
                PayForLevelUP();
                IncreasingParameters();
                GetReplicasWhenLevelUp("End");
            }
            else
            {
                Console.WriteLine("Оракул: До встречи.\n");
            }

            player = temp;

        }

        private static bool CheckSolvency()
        {

            if (temp.Exp >= expToLevelUp && temp.Gold >= temp.Level * 50)
                return true;
            else
            {
                Console.WriteLine("\nОракул: У тебя недостаточно ресурсов. Приходи когда будешь готов!\n");
                return false;
            }

        }

        private static void PayForLevelUP()
        {

            temp.Gold -= temp.Level * 50;
            temp.Exp -= expToLevelUp;

        }

        private static void IncreasingParameters()
        {

            temp.Level++;
            temp.Health += temp.Health;
            temp.Mana += temp.Mana;
            temp.Damage += 5;
            expToLevelUp += expToLevelUp;

        }

        private static void GetReplicasWhenLevelUp(string message)
        {

            if (message == "Begin")
            {
                Console.WriteLine($"Оракул: Сейчас у тебя {temp.Exp} опыта и {temp.Gold} золота.");
                Console.WriteLine($"Оракул: Для перехода на следующий уровень нужно {expToLevelUp} опыта и {temp.Level * 50} золота.");
                Console.WriteLine("Оракул: Ты точно хочешь поднять уровень? Враги тоже станут сильнее!\n");
                Console.Write($"{temp.name}: ");
            }
            else if (message == "End")
            {
                Console.WriteLine($"\nОракул: Твой уровень вырос! Теперь ты {temp.special} {temp.Level} уровня.");
                Console.WriteLine($"Оракул: Текущий опыт {temp.Exp}, остаток золота {temp.Gold}.\n");
            }

        }
    }


}
