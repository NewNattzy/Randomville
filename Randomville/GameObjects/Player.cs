using System;


namespace GameObjects
{

    public class Player : Creature
    {

        public string Special;

        internal static int newLevelExp = 500;

        public Player(string name, int basehealth, int basemana, int damage, int level, int exp, int gold, string special)
            : base(basehealth, basemana, damage, level, exp, gold)
        {

            Name = name;
            Special = special;

        }


        public string Name { get; set; }
        public int Resources { get; set; }


        public void ShowParameters()
        {

            Console.WriteLine("Характеристики персонажа:");
            Console.WriteLine($"Имя           : {Name}");
            Console.WriteLine($"Класс         : {Special}");
            Console.WriteLine($"Уровень       : {Level}");
            Console.WriteLine($"Здоровье      : {Health}");
            Console.WriteLine($"Мана          : {Mana}");
            Console.WriteLine($"Урон          : {Damage}");
            Console.WriteLine($"Опыт          : {Exp}");
            Console.WriteLine($"Золото        : {Gold}\n");

        }


        public void LevelUP()
        {

            GetReplicasWhenLevelUp("Begin");

            if (Console.ReadLine() == "Да" && CheckSolvency() == true)
            {
                PayForLevelUP();
                IncreasingParameters();
                GetReplicasWhenLevelUp("End");
            }
            else
            {
                Console.WriteLine("\nОракул: До встречи.\n");
            }
                

        }


        private bool CheckSolvency()
        {

            if (Exp >= newLevelExp && Gold >= Level * 50)
                return true;
            else
            {
                Console.WriteLine("\nОракул: У тебя недостаточно ресурсов. Приходи когда будешь готов!\n");
                return false;
            }

        }


        private void PayForLevelUP()
        {

            Gold -= Level * 50;
            Exp -= newLevelExp;

        }


        private void IncreasingParameters()
        {

            Level++;
            Health += Health;
            Mana += Mana;
            Damage += 5;
            newLevelExp += newLevelExp;

        }


        private void GetReplicasWhenLevelUp(string message)
        {

            if (message == "Begin")
            {
                Console.WriteLine($"Оракул: Сейчас у тебя {Exp} опыта и {Gold} золота.");
                Console.WriteLine($"Оракул: Для перехода на следующий уровень нужно {newLevelExp} опыта и {Level * 50} золота.");
                Console.WriteLine("Оракул: Ты точно хочешь поднять уровень? Враги тоже станут сильнее!\n");
                Console.Write($"{Name}: ");
            }
            else if (message == "End")
            {
                Console.WriteLine($"\nОракул: Твой уровень вырос! Теперь ты {Special} {Level} уровня.");
                Console.WriteLine($"Оракул: Текущий опыт {Exp}, остаток золота {Gold}.\n");
            }

        }


    }

}