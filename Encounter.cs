namespace ConsoleRpg;

public class Encounter
{
    private static Random rand = new();

    public static void EncounterUi(Player player)
    {
        string n = GetName();
        int p = Player.GetPower();
        int h = Player.GetHealth();

        Console.Clear();
        Console.WriteLine("You turn around and see a creature lurking around the corner");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine($"Name: {n}");
        Console.WriteLine($"Power: {p}");
        Console.WriteLine($"Health: {h}");
        Console.WriteLine("| (A)ttack | (R)un| \n" +
                          "(H)eal | (D)efend |");
        Console.Write("> ");
        string input = Console.ReadLine()!.ToLower();

        switch (input)
        {
            case "a":
            case "attack":
                Attack(player);
                break;
            case "r":
            case "run":
                Run(player);
                break;
            case "h":
            case "heal":
                Heal(player);
                break;
            case "d":
            case "defend":
                Defend(player);
                break;
        }
    }

    public static void Attack(Player p)
    {
    }

    public static void Run(Player p)
    {
    }

    public static void Heal(Player p)
    {
    }

    public static void Defend(Player p)
    {
    }

    public static string GetName()
    {
        int num = rand.Next(0, 4);

        return num switch
        {
            0 => "Goblin",
            1 => "Wizard",
            2 => "Zombie",
            3 => "Spider",
            _ => "Unknown"
        };
    }
}