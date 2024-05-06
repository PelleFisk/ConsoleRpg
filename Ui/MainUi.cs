using ConsoleRpg.Backend;

namespace ConsoleRpg.Ui;

public class MainUi
{
    public static void Ui()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("Welcome to Console RPG");
        Console.WriteLine("Please enter in a choice");
        Console.WriteLine("N: Go North");
        Console.WriteLine("S: Go South");
        Console.WriteLine("E: Go East");
        Console.WriteLine("W: Go West");
        Console.WriteLine("Q: Quit");
        Console.WriteLine("=====================================");

        var input = Console.ReadLine()!.ToLower();

        switch (input)
        {
            case "n":
                DirectionLogic.GoNorth();
                break;
            case "s":
                DirectionLogic.GoSouth();
                break;
            case "e":
                DirectionLogic.GoEast();
                break;
            case "w":
                DirectionLogic.GoWest();
                break;
            case "q":
                Program.SavePlayer();
                Program.SaveWeapon();
                Environment.Exit(0);
                break;
        }
    }
}