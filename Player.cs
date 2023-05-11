namespace BLN_OOP
{
class Player
{
    public int health;
    public int slashDmg;

    public Player(int slashDmg)
    {
        health = 200;
        this.slashDmg = slashDmg;
    }

    public void Punch(Enemy enemy)
    {
        enemy.health -= 5;
    }
    public void Slash(Enemy enemy)
    {
        enemy.health -= slashDmg;
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