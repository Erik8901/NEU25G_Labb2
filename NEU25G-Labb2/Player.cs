class Player : LevelElement
{
    public Dice AttackDice { get; set; }
    public Dice DefendDice { get; set; }

    public int Health { get; set; }
    public Player(int x, int y)
    {
        Sign = '@';
        SignColor = ConsoleColor.Green;
        PosX = x;
        PosY = y;
        AttackDice = new Dice(1, 6, 1);
        DefendDice = new Dice(1, 6, 1);
        Health = 100;
    }
}
