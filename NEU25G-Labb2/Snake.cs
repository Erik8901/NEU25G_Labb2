class Snake : Enemy
{

    public Snake(int x, int y)
    {
        Sign = 's';
        SignColor = ConsoleColor.Black;
        PosX = x;
        PosY = y;
        AttackDice = new Dice(1, 6, 1);
        DefendDice = new Dice(1, 6, 1);
        Health = 20;
    }

    public void Update()
    {
        Console.WriteLine("snake");
    }
}