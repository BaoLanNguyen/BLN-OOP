namespace BLN_OOP{
class Enemy
{
    public int health;
    public int damage;
    public string name;

    public Enemy(string name, int health, int damage)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
    }

    public void Attack(Player player)
    {
        player.TakeDamage(damage);
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