namespace BLN_OOP
{
internal class Program
{
    private enum GameState { MainMenu, Battle, City, Dead }
    private static void Main(string[] args)
    {
        List<Enemy> enemies = new List<Enemy>();
        Player player = new Player();
        GameState state = GameState.MainMenu;
        int score = 0;
        enemies.Add(new Enemy("Golblin"));
        enemies.Add(new Enemy("Troll"));
        enemies.Add(new Enemy("Dragon"));
        bool win = true;
        while (win)
        {
            switch (state)
            {
                case GameState.MainMenu:
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
                        Console.WriteLine("You have exited the game");
                    }
                    break;

                case GameState.Battle:
                    Console.WriteLine("You are in battle!");
                    int enemyIndex = new Random().Next(enemies.Count);
                    Enemy enemy = enemies[enemyIndex];
                    Console.WriteLine("You are fighting a " + enemy.name);
                    while (!player.IsDead() && !enemy.IsDead())
                    {
                        Console.WriteLine("Player health: " + player.health);
                        Console.WriteLine("Enemy health: " + enemy.health);
                        Console.WriteLine("1. Attack");
                        int attackChoice = int.Parse(Console.ReadLine());
                        if (attackChoice == 1)
                        {
                            player.Attack(enemy);
                            enemy.Attack(player);
                        }
                    }
                    if (player.IsDead())
                    {
                        state = GameState.Dead;
                    }
                    else if (enemyIndex == 2){
                        Console.WriteLine("You won the game!");
                        win = false;
                        SaveScore(score);
                    }
                    else
                    {
                        Console.WriteLine("You won the battle!");
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