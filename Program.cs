namespace BLN_OOP
{
internal class Program
{
    private enum GameState { MainMenu, Battle, City, Dead }
    private static void Main(string[] args)
    {
        List<Enemy> enemies = new List<Enemy>();
        Player player = new Player(15);
        GameState state = GameState.MainMenu;
        int score = 0;
        enemies.Add(new Enemy("Golblin", 30, 5));
        enemies.Add(new Enemy("Troll", 60, 10));
        enemies.Add(new Enemy("Dragon", 120, 20));
        bool still = true;
        while (still)
        {
            switch (state)
            {
                case GameState.MainMenu:
                    player.health = 200;
                    player.slashDmg = 15;
                    Console.WriteLine("Welcome to the game!");
                    Console.WriteLine("1. Start");
                    Console.WriteLine("2. Exit");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        state = GameState.Battle;
                        score = 0;
                    }
                    else if (choice == 2)
                    {
                        Environment.Exit(1);

                    }
                    break;

                case GameState.Battle:
                    Console.WriteLine("You are in battle!");
                    int enemyIndex = new Random().Next(enemies.Count);
                    Enemy enemy = enemies[enemyIndex];
                    enemies[0].health = 30;
                    enemies[1].health = 60;
                    enemies[2].health = 120;
                    Console.WriteLine("You are fighting a " + enemy.name);
                    while (!player.IsDead() && !enemy.IsDead())
                    {
                        Console.WriteLine("Player health: " + player.health);
                        Console.WriteLine("Enemy health: " + enemy.health);
                        Console.WriteLine("1. Punch");
                        Console.WriteLine("2. Sword Slash");
                        int attackChoice = int.Parse(Console.ReadLine());
                        if (attackChoice == 1)
                        {
                            player.Punch(enemy);
                            enemy.Attack(player);
                        }
                        else if(attackChoice == 2){
                            player.Slash(enemy);
                            enemy.Attack(player);
                        }
                    }
                    if (player.IsDead())
                    {
                        state = GameState.Dead;
                    }
                    else
                    {
                        Console.WriteLine("You won the battle!");
                        Console.WriteLine("Your sword slash is upgraded!");
                        player.slashDmg += 5;
                        score += 1;
                        
                    }
                    break;

                case GameState.City:
                    Console.WriteLine("You are in the city!");
                    break;

                case GameState.Dead:
                    Console.WriteLine("You are dead!");
                    SaveScore(score);
                    state = GameState.MainMenu;
                    break;
            }
    }
    void SaveScore(int score)
{
    string fileName = "scores.txt";
    if (!File.Exists(fileName))
    {
        File.Create(fileName);
    }

    string[] lines = File.ReadAllLines(fileName);
    List<int> scores = new List<int>();
    foreach (string line in lines)
    {
        int parsedScore;
        if (int.TryParse(line, out parsedScore))
        {
            scores.Add(parsedScore);
        }
    }

    scores.Add(score);
    scores.Sort();
    scores.Reverse();
    if (scores.Count > 3)
    {
        scores.RemoveAt(3);
    }

    File.WriteAllLines(fileName, scores.Select(s => s.ToString()).ToArray());
}
}
}
}