using AdventDayOne;
using AdventDayTwo;
using AdventDayThree;
using AdventDayFour;
using AdventDayFive;
using AdventDaySix;

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
        Console.WriteLine($"The password to the safe is { dayOne.FindPassword() }");
        break;
    case 2:
        inputs = GetInstructions("../../../data/dayTwoInput.txt");
        DayTwo dayTwo = new(inputs[0]);
        Console.WriteLine($"The total of the invalid Ids are { dayTwo.AddInvalidIds() }");
        break;
    case 3:
        inputs = GetInstructions("../../../data/dayThreeBatteries.txt");
        DayThree dayThree = new(inputs);
        Console.WriteLine($"The total joltage is { dayThree.GetTotalJoltage(12) }");
        break;
    case 4:
        inputs = GetInstructions("../../../data/dayFourGrid.txt");
        DayFour dayFour = new(inputs);
        Console.WriteLine($"The number of accessible rolls is {dayFour.GetTotalPossibleRemovals(['@'], 4, 1) }");
        break;
    case 5:
        inputs = GetInstructions("../../../data/dayFiveIds.txt");
        DayFive dayFive = new(inputs);
        Console.WriteLine($"The number of fresh ingredients is {dayFive.GetTotalFreshCount()}");
        break;
    case 6:
        inputs = GetInstructions("../../../data/daySixProblems.txt");
        DaySix daySix = new(inputs);
        Console.WriteLine($"The total value of the homework problems is {daySix.SolveHomework()}");
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