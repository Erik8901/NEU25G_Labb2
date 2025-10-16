class Rat : Enemy
{
    private int _health;
    public int Health
    {
        get => _health;
        set => _health = Math.Min(value, 10); 
    }
    public Rat(int x, int y)
    {
        Sign = 'r';
        SignColor = ConsoleColor.Black;
        PosX = x;
        PosY = y;
        AttackDice = new Dice(1, 6, 1);
        DefendDice = new Dice(1, 6, 1);
        Health = 10;
    }
}