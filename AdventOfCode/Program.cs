using AdventDayOne;

Console.WriteLine("Welcome to the Advent of Code 2025!");
Console.Write("Please enter the day you would like to see the solution for (1-12): ");
int.TryParse(Console.ReadLine(), out int selection);

string[] GetInstructions(string filePath)
{
    List<string> output = new();

    StreamReader reader = new StreamReader(filePath);
    string? line = reader.ReadLine();
    while (line != null)
    {
        output.Add(line);
        line = reader.ReadLine();
    }

    return output.ToArray();
}

switch (selection)
{
    case 1:
        string[] inputs = GetInstructions("../../../data/dayOneCombo.txt");
        DayOne dayOne = new(inputs, 50, 100);
        Console.WriteLine($"The password to the safe is {dayOne.FindPassword()}");
        break;
    case 2:
        Console.WriteLine("Day not yet released");
        break;
    case 3:
        Console.WriteLine("Day not yet released");
        break;
    case 4:
        Console.WriteLine("Day not yet released");
        break;
    case 5:
        Console.WriteLine("Day not yet released");
        break;
    case 6:
        Console.WriteLine("Day not yet released");
        break;
    case 7:
        Console.WriteLine("Day not yet released");
        break;
    case 8:
        Console.WriteLine("Day not yet released");
        break;
    case 9:
        Console.WriteLine("Day not yet released");
        break;
    case 10:
        Console.WriteLine("Day not yet released");
        break;
    case 11:
        Console.WriteLine("Day not yet released");
        break;
    case 12:
        Console.WriteLine("Day not yet released");
        break;
    default:
        Console.WriteLine("Input not recognized.");
        break;
}