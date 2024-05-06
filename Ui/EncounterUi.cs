using ConsoleRpg.Backend;

namespace ConsoleRpg.Ui;

class EncounterUi
{
    public static Random rand = new();

    public static void Ui()
    {
        Console.Clear();

        var p = Program.CurrentPlayer.GetDmg();
        var hp = Program.CurrentPlayer.GetHp();
        var n = Enemy.GetName();

        Console.WriteLine("You encountered an enemy!");


        while (hp > 0)
        {
            Console.Clear();

            Console.WriteLine($"Monster Damage: {p}/Monster Hp: {hp}");
            Console.WriteLine("=====================================");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("A: Attack");
            Console.WriteLine("R: Run");
            Console.WriteLine("D: Defend");
            Console.WriteLine("H: Heal");
            Console.WriteLine($"Potions: {Program.CurrentPlayer.potions}/Health: {Program.CurrentPlayer.hp}");
            Console.WriteLine("=====================================");
            Console.Write("> ");

            var input = Console.ReadLine()!.ToLower();

            if (input == "a" || input == "attack")
            {
                Console.WriteLine($"You haste forwards with fury and strike the {n} in front of you!");
                var dmg = rand.Next(Program.CurrentPlayer.minDmg, Program.CurrentPlayer.maxDmg);
                Console.WriteLine($"You dealt {dmg} damage to the {n}!");
                hp -= dmg;
                var enemyDmg = p -= Program.CurrentPlayer.armor;
                if (enemyDmg <= 0) enemyDmg = 0;
                Console.WriteLine($"But when attack you also got hit and lost {enemyDmg} health");
                Program.CurrentPlayer.hp -= enemyDmg;

                Console.ReadLine();
            }

            else if (input == "r" || input == "run")
            {
                int num = rand.Next(0, 2);
                if (num == 0)
                {
                    Console.WriteLine("You use your crazy ninja skills and escape!");
                }
                else
                {
                    Console.WriteLine("You try to run but the enemy catches you!");
                    var enemyDmg = p -= Program.CurrentPlayer.armor;
                    if (enemyDmg <= 0) enemyDmg = 0;
                    Console.WriteLine($"The {n} hits you for {enemyDmg} damage!");
                    Program.CurrentPlayer.hp -= enemyDmg;
                }

                Console.ReadLine();
            }

            else if (input == "d" || input == "defend")
            {
                int attack = rand.Next((Program.CurrentPlayer.minDmg + Program.CurrentWeapon.damage) +
                                       (Program.CurrentPlayer.maxDmg + Program.CurrentWeapon.damage));
                int dmg = p - Program.CurrentPlayer.armor;
                if (dmg < 0) dmg = 0;

                Console.WriteLine(
                    $"You take your sword and block the attack. But the attempt was not successful so you still took {dmg} damage. But in the end you also dealt {attack} damage to the {n}!");
                hp -= attack;
                Program.CurrentPlayer.hp -= dmg;
                Console.ReadLine();
            }

            else if (input == "h" || input == "heal")
            {
                Console.WriteLine("You reach into your bag and pull out a glowing potion.");
                Console.WriteLine("You drink from it and gain " + 5 + " health!");

                Program.CurrentPlayer.hp += 5;
                if (Program.CurrentPlayer.hp > Program.CurrentPlayer.maxHp)
                    Program.CurrentPlayer.hp = Program.CurrentPlayer.maxHp;
                Program.CurrentPlayer.potions -= 1;
                Console.ReadKey();
            }

            if (Program.CurrentPlayer.hp <= 0)
            {
                Console.WriteLine($"You have been slain by the mighty {n}!!");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        int c = Program.CurrentPlayer.GetCoins();
        int xp = Program.CurrentPlayer.GetXp();
        Console.WriteLine("You have slain the mighty " + n +
                          ". And now that the foul creature is dead you gained " + c + " coins as a reward!");
        Console.WriteLine("You also gained " + xp + " xp!!");
        Program.CurrentPlayer.xp += xp;
        Program.CurrentPlayer.gold += c;
        if (Program.CurrentPlayer.CanLevelUp())
        {
            Program.CurrentPlayer.LevelUp();
        }
    }
}