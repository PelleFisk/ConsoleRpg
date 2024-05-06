namespace ConsoleRpg.Backend;

public class Player
{
    public string name { get; set; }
    public int xPos { get; set; }
    public int yPos { get; set; }
    public int hp { get; set; }
    public int maxHp { get; set; }
    public int level { get; set; }
    public int xp { get; set; }
    public int xpToLevel { get; set; }
    public int gold { get; set; }
    public int minDmg { get; set; }
    public int maxDmg { get; set; }
    public int armor { get; set; }
    public int potions { get; set; }
    public int statPoints { get; set; }
    public int skillPoints { get; set; }

    public void InitPlayer()
    {
        name = "";
        xPos = 0;
        yPos = 0;
        hp = 10;
        maxHp = 10;
        level = 1;
        xp = 0;
        xpToLevel = GetXp();
        gold = 0;
        minDmg = 2;
        maxDmg = 4;
        armor = 1;
        potions = 5;
        statPoints = 0;
        skillPoints = 0;
    }

    public int GetCoins()
    {
        int upper = (10 * 1 + 200);
        int lower = (10 * 1 + 50);
        return Random.Shared.Next(lower, upper);
    }

    public int GetDmg()
    {
        int upper = (2 * 1 + 4);
        int lower = (1 + 4);
        return Random.Shared.Next(lower, upper);
    }

    public int GetHp()
    {
        int upper = (1 * 2 + 5);
        int lower = (1 * 2 + 3);
        return Random.Shared.Next(lower, upper);
    }

    public int GetXp()
    {
        int upper = (20 * 2 + 100);
        int lower = (10 * 2 + 20);
        return Random.Shared.Next(lower, upper);
    }

    public int GetLevelValue()
    {
        return 100 * level + 400;
    }

    public bool CanLevelUp()
    {
        if (xp >= GetLevelValue())
            return true;
        else
            return false;
    }

    public void LevelUp()
    {
        while (CanLevelUp())
        {
            xp -= GetLevelValue();
            skillPoints++;
            maxHp += 5;
            minDmg += 2;
            maxDmg += 2;
            level++;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Congrats! You are now level " + level + "!!!");
        Console.ResetColor();
    }
}