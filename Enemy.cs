namespace BLN_OOP{
class Enemy
{
    public int health;
    public int damage;
    public string name;

    public Enemy(string name)
    {
        this.name = name;
        health = 50;
        damage = 5;
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