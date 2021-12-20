using GameObjects;
using System.Text.RegularExpressions;

namespace GameObjectManagment
{
    public static class PlayerManagement
    {
        #nullable disable
        public static Player CreatePlayer()
        {   
            
            string playerName = "";
            string playerSpecial = "";
            string[] special = new string[] { "Воин", "Лучник", "Маг" };

            bool isValidName = false;
            bool isValidSpecial = false;

            while (!isValidName)
            {
                Console.WriteLine("Оракул: Введи свое имя, герой!");
                Console.Write("Ты: ");

                playerName = Console.ReadLine();
                Console.Clear();
                
                if (!String.IsNullOrEmpty(playerName) && playerName.Length >= 3)
                {
                    playerName = Regex.Replace(playerName.ToLower(), @"\b[a-zа-яё]", m => m.Value.ToUpper());
                    isValidName = true;
                }   
            }

            while (!isValidSpecial)
            {
                Console.WriteLine($"Оракул: Отлично, {playerName}. Теперь выбери свою судьбу. Ты воин, лучник или маг?");
                Console.Write($"{playerName}: ");

                playerSpecial = Console.ReadLine().ToLower();
                playerSpecial = Regex.Replace(playerSpecial.ToLower(), @"\b[a-zа-яё]", m => m.Value.ToUpper());

                if (special.Contains(playerSpecial))
                    isValidSpecial = true;

                Console.Clear();
            }

            int baseHealth = 0;
            int baseMana = 0;
            int gold = 0;
            
            switch (playerSpecial)
            {
                case "Воин":
                    baseHealth = 200;
                    baseMana = 50;
                    gold = 0;
                    break;

                case "Лучник":
                    baseHealth = 150;
                    baseMana = 100;
                    gold = 150;
                    break;

                case "Маг":
                    baseHealth = 75;
                    baseMana = 200;
                    gold = 50;
                    break;

                default:
                    break;
            }

            return new Player(playerName, baseHealth, baseMana, 10, 1, gold, playerSpecial);

        }

        public static void LevelUP(Player player)
        {

            string[] variants = new string[] { "да", "конечно", "ага", "само собой", "точно" };

            Console.WriteLine($"Оракул: Сейчас у тебя {player.Exp} опыта и {player.Gold} золота. Для перехода на следующий уровень нужно {Player.newLevelExp} опыта и {player.Level*50} золота.");
            Console.WriteLine("Оракул: Ты точно хочешь поднять уровень? Враги тоже станут сильнее!");
            Console.Write($"{player.Name}: ");
            string answer = Console.ReadLine();

            if (variants.Contains(answer.ToLower()))
            {

                if (player.Exp >= Player.newLevelExp && player.Gold >= player.Level*50)
                {
                    player.Exp -= Player.newLevelExp;
                    player.Gold -= player.Level*50;

                    player.Level++;
                    player.Health += player.Health;
                    player.Mana += player.Mana;
                    switch (player.Special)
                    {
                        case "Воин":
                            player.Damage += 3;
                            break;

                        case "Лучник":
                            player.Damage += 5;
                            break;

                        case "Маг":
                            player.Damage += 1;
                            break;

                        default:
                            break;
                    }
                    Player.newLevelExp += Player.newLevelExp;

                    Console.WriteLine($"\nОракул: Твой уровень вырос! Теперь ты {player.Special} {player.Level} уровня.");
                    Console.WriteLine($"Оракул: Текущий опыт {player.Exp}, остаток золота {player.Gold}.\n");
                }
                else
                {
                    Console.WriteLine("\nОракул: У тебя недостаточно ресурсов. Приходи когда будешь готов!\n");
                }

            }
            else
            { 
                Console.WriteLine("\nОракул: Так я и думал.\n");
            }

        }

        public static void ShowPlayerInfo(Player player)
        {
            Console.WriteLine("Характеристики персонажа:");
            Console.WriteLine($"Имя           : {player.Name}");
            Console.WriteLine($"Класс         : {player.Special}");
            Console.WriteLine($"Уровень       : {player.Level}");
            Console.WriteLine($"Здоровье      : {player.Health}");
            Console.WriteLine($"Мана          : {player.Mana}");
            Console.WriteLine($"Урон          : {player.Damage}");
            Console.WriteLine($"Опыт          : {player.Exp}");
            Console.WriteLine($"Золото        : {player.Gold}\n");
        }


    }

}