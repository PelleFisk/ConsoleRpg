using System.Text.Json;
using ConsoleRpg.Backend;
using ConsoleRpg.Ui;

namespace ConsoleRpg;

public class Program
{
    private static string _savePath = $@"{Environment.CurrentDirectory}\Saves\";
    public static Player CurrentPlayer = new Player();
    private static bool newPlayer = true;
    public static bool MainGamePlay = false;
    private static readonly string PlayerSavePath = _savePath + @"Player\";
    private static readonly string WeaponSavePath = _savePath + @"Weapons\";

    public static Weapon CurrentWeapon = new Weapon(0, "", "", 0, 0, 0, false);

    public static List<Weapon> Weapons = new();

    public static void Main()
    {
        if (!Directory.Exists(PlayerSavePath) && !Directory.Exists(WeaponSavePath))
        {
            Directory.CreateDirectory(PlayerSavePath);
            Directory.CreateDirectory(WeaponSavePath);
        }

        CurrentPlayer = LoadPlayer();
        LoadWeapons(CurrentPlayer.name);

        while (MainGamePlay)
        {
            MainUi.Ui();
        }
    }

    private static Player StartNewPlayer()
    {
        while (newPlayer)
        {
            string? name;
            Console.WriteLine("Enter your name: ");
            name = Console.ReadLine();
            CurrentPlayer.InitPlayer();
            CurrentPlayer.name = name!;

            SavePlayer();
            SaveWeapon();
            
            newPlayer = false;
            MainGamePlay = true;
        }

        return CurrentPlayer;
    }

    public static void SavePlayer()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(CurrentPlayer, options);
        string path = PlayerSavePath + $"{CurrentPlayer.name}.json";
        File.WriteAllText(path, json);
    }

    public static void SaveWeapon()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string fileName = CurrentPlayer.name + ".json";
        string json = JsonSerializer.Serialize(Weapons, options);
        string path = WeaponSavePath + fileName;
        File.WriteAllText(path, json);
    }

    public static Player LoadPlayer()
    {
        string[] paths = Directory.GetFiles(PlayerSavePath);
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

    public static void LoadWeapons(string name)
    {
        var path = WeaponSavePath + $"{name}.json";
        var json = File.ReadAllText(path);
        Weapons = JsonSerializer.Deserialize<List<Weapon>>(json)!;
        CurrentWeapon = Weapons.Find(w => w.currentWeapon)!;
    }

    public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
    {
        int dif = (int)(value * size);
        for (int i = 0; i < size; i++)
        {
            if (i < dif)
                Console.Write(fillerChar);
            else
                Console.Write(backgroundChar);
        }
    }
}