namespace BLN_OOP
{
class Player
{
    public int health;
    public int damage;

    public Player()
    {
        health = 100;
        damage = 10;
    }

    public void Attack(Enemy enemy)
    {
        enemy.health -= damage;
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