using System.Text.Json;

namespace ConsoleRpg;

public class Program
{
    private static string _savePath = $@"{Environment.CurrentDirectory}\Saves\";
    public static Player currentPlayer = new Player();
    private static bool newPlayer = true;
    public static bool mainGamePlay = false;
    private static string playerSavePath = _savePath + @"Player\";

    public static void Main()
    {
        if (!Directory.Exists(playerSavePath))
        {
            Directory.CreateDirectory(playerSavePath);
        }

        currentPlayer = LoadPlayer();
    }

    private static Player StartNewPlayer()
    {
        while (newPlayer)
        {
            string? name;
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
            currentPlayer.InitPlayer();
            currentPlayer.name = name!;

            newPlayer = false;
            mainGamePlay = true;

            Savelayer();
        }

        return currentPlayer;
    }

    public static void Savelayer()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(currentPlayer, options);
        string path = playerSavePath + $"{currentPlayer.name}.json";
        File.WriteAllText(path, json);
    }

    public static Player LoadPlayer()
    {
        string[] paths = Directory.GetFiles(playerSavePath);
        List<Player> players = new List<Player>();
        foreach (var p in paths)
        {
            string loadedJson = File.ReadAllText(p);
            Player player = JsonSerializer.Deserialize<Player>(loadedJson)!;
            players.Add(player);
        }

        while (true)
        {
            foreach (var p in players)
            {
                Console.WriteLine(p.name);
            }

            Console.WriteLine("Please enter the name of the character you want to play as: ");
            Console.WriteLine("Other wise you can start a new character with 'create'");
            string? input;
            input = Console.ReadLine();

            if (input == "create")
            {
                Player newPlayer = StartNewPlayer();
                return newPlayer;
            }
            else
            {
                foreach (var p in players)
                {
                    if (p.name == input)
                    {
                        return p;
                    }
                }
            }

            Console.WriteLine("There is no player with that name!!");
            Console.ReadKey();
        }
    }
}