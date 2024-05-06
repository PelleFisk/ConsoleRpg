namespace ConsoleRpg.Backend;

public class Enemy()
{
    public static string GetName()
    {
        var num = Random.Shared.Next(0, 4);

        return num switch
        {
            0 => "Goblin",
            1 => "Wizard",
            2 => "Skeleton",
            3 => "Spider",
            _ => ""
        };
    }
}