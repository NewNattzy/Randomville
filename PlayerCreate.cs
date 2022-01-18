#nullable disable
// TODO: Допилить создание персонажа, завязать на БД
public static Player CreatePlayer()
{

    string name = "";
    string special = "";
    string[] specials = new string[] { "Воин", "Лучник", "Маг" };

    bool isValidName = false;
    bool isValidSpecial = false;


    while (!isValidName)
    {

        Console.WriteLine("Оракул: Введи свое имя, герой!");
        Console.Write("Ты: ");

        name = Console.ReadLine();
        Console.Clear();

        if (!string.IsNullOrEmpty(name) && name.Length >= 3)
        {

            name.ToUpperFirstChar();
            isValidName = true;

        }

    }


    while (!isValidSpecial)
    {

        Console.WriteLine($"Оракул: Отлично, {name}. Теперь выбери свою судьбу. Ты воин, лучник или маг?");
        Console.Write($"{name}: ");

        special = "Воин";
        special.ToUpperFirstChar();

        if (specials.Contains(special))
            isValidSpecial = true;

        Console.Clear();

    }


    int baseHealth = 0;
    int baseMana = 0;
    int gold = 0;


    switch (special)
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

    return new Player(name, baseHealth, baseMana, 10, 1, 10, gold, special);

}
