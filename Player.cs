namespace ConsoleRpg;

public class Player
{
    public string name { get; set; }
    public int hp { get; set; }
    public int maxHp { get; set; }
    public int level { get; set; }
    public int xp { get; set; }
    public int xpToLevel { get; set; }
    public int gold { get; set; }
    public int dmgMin { get; set; }
    public int dmgMax { get; set; }
    public int armor { get; set; }
    public int potions { get; set; }
    public int statPoints { get; set; }
    public int skillPoints { get; set; }

    public void InitPlayer()
    {
        name = "";
        hp = 10;
        maxHp = 10;
        level = 1;
        xp = 0;
        xpToLevel = GetExpForNextLevel();
        gold = 0;
        dmgMin = 2;
        dmgMax = 4;
        armor = 1;
        potions = 5;
        statPoints = 0;
        skillPoints = 0;
    }

    public static int GetGold()
    {
        return Random.Shared.Next(50, 100);
    }

    public static int GetExp()
    {
        return Random.Shared.Next(20, 100);
    }

    public static int GetPower()
    {
        return Random.Shared.Next(1, 5);
    }

    public static int GetHealth()
    {
        return Random.Shared.Next(2, 8);
    }

    private int GetExpForNextLevel()
    {
        return (level * 100) + Random.Shared.Next(50, 100);
    }
}