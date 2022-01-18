#nullable disable
// TODO: �������� �������� ���������, �������� �� ��
public static Player CreatePlayer()
{

    string name = "";
    string special = "";
    string[] specials = new string[] { "����", "������", "���" };

    bool isValidName = false;
    bool isValidSpecial = false;


    while (!isValidName)
    {

        Console.WriteLine("������: ����� ���� ���, �����!");
        Console.Write("��: ");

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

        Console.WriteLine($"������: �������, {name}. ������ ������ ���� ������. �� ����, ������ ��� ���?");
        Console.Write($"{name}: ");

        special = "����";
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

        case "����":
            baseHealth = 200;
            baseMana = 50;
            gold = 0;
            break;

        case "������":
            baseHealth = 150;
            baseMana = 100;
            gold = 150;
            break;

        case "���":
            baseHealth = 75;
            baseMana = 200;
            gold = 50;
            break;

        default:
            break;

    }

    return new Player(name, baseHealth, baseMana, 10, 1, 10, gold, special);

}
