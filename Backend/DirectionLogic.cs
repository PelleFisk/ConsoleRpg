using ConsoleRpg.Ui;

namespace ConsoleRpg.Backend;

class DirectionLogic
{
    public static Random Rand = new Random();

    public static void GoNorth()
    {
        var num = Rand.Next(0, 10);

        Console.WriteLine("You went north!");
        Program.CurrentPlayer.yPos++;

        if (num <= 2)
        {
            EncounterUi.Ui();
        }
    }

    public static void GoSouth()
    {
        var num = Rand.Next(0, 10);

        Console.WriteLine("You went south!");
        Program.CurrentPlayer.yPos--;

        if (num <= 2)
        {
            EncounterUi.Ui();
        }
    }

    public static void GoEast()
    {
        var num = Rand.Next(0, 10);

        Console.WriteLine("You went east!");
        Program.CurrentPlayer.xPos++;

        if (num <= 2)
        {
            EncounterUi.Ui();
        }
    }

    public static void GoWest()
    {
        var num = Rand.Next(0, 10);

        Console.WriteLine("You went west!");
        Program.CurrentPlayer.xPos--;

        if (num <= 2)
        {
            EncounterUi.Ui();
        }
    }
}