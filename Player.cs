namespace BLN_OOP
{
class Player
{
    public int health;

    public Player()
    {
        health = 200;
    }

    public void Punch(Enemy enemy)
    {
        enemy.health -= 5;
    }
    public void Slash(Enemy enemy)
    {
        enemy.health -= 15;
        health -= 5;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
}