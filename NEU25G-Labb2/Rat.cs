class Rat : Enemy
{

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
    public void Update()
    {
        //  Console.WriteLine("rats");
    }
}