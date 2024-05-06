namespace ConsoleRpg.Backend;

public class Weapon(int id, string name, string rarity, int damage, int cost, int sellValue, bool currentWeapon)
{
    public int id { get; set; } = id;
    public string name { get; set; } = name;
    public string rarity { get; set; } = rarity;
    public int damage { get; set; } = damage;
    public int cost { get; set; } = cost;
    public int sellValue { get; set; } = sellValue;
    public bool currentWeapon { get; set; } = currentWeapon;

    public static int GetCost(string? rarity)
    {
        int cost = 0;
        switch (rarity)
        {
            case "common":
                cost = 100 * (1 + 3);
                break;
            case "uncommon":
                cost = 100 * (2 + 3);
                break;
            case "rare":
                cost = 100 * (3 + 3);
                break;
            case "epic":
                cost = 100 * (4 + 3);
                break;
            case "legendary":
                cost = 100 * (5 + 3);
                break;
        }

        return cost;
    }

    public static int GetSellValue(string? rarity)
    {
        int sellValue;
        sellValue = GetCost(rarity) / 2;
        return sellValue;
    }

    public static int GetDamage(string? rarity)
    {
        int damage = 0;
        switch (rarity)
        {
            case "common":
                damage = 1 * (1 + 3);
                break;
            case "uncommon":
                damage = 1 * (2 + 3);
                break;
            case "rare":
                damage = 1 * (3 + 3);
                break;
            case "epic":
                damage = 1 * (4 + 3);
                break;
            case "legendary":
                damage = 1 * (5 + 3);
                break;
        }

        return damage;
    }

    public static int GetStrReq(string rarity)
    {
        int strReq = rarity switch
        {
            "common" => 1,
            "uncommon" => 5,
            "rare" => 7,
            "epic" => 10,
            "legendary" => 15,
            _ => 0
        };

        return strReq;
    }

    public static string GetShopRarity()
    {
        string? rarity = "";

        int randNum = Random.Shared.Next(0, 101);
        rarity = randNum switch
        {
            <= 40 => "common",
            > 40 and <= 70 => "uncommon",
            > 70 and <= 80 => "rare",
            > 80 and <= 90 => "epic",
            > 90 and <= 100 => "legendary",
            _ => rarity
        };

        return rarity;
    }

    public static string GetRarity()
    {
        string? rarity = "";

        int randNum = Random.Shared.Next(0, 101);
        rarity = randNum switch
        {
            <= 60 => "common",
            > 60 and <= 85 => "uncommon",
            > 85 and <= 95 => "rare",
            > 95 and <= 99 => "epic",
            100 => "legendary",
            _ => rarity
        };

        return rarity;
    }
}