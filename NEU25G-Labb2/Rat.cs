class Rat : Enemy
{
    public Dice AttackDice { get; set; }
    public Dice DefendDice { get; set; }
    
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

    //Random rand = new Random();
    public override void Update(List<Wall> walls, List<Enemy> allEnemies, Player player, List<LevelElement> _elements)
    {

        //for (int i = 0; i < _elements.Count; i++)
        //{
        //    if (_elements[i].Sign == 'r')
        //    {
        //        Console.SetCursorPosition(_elements[i].PosX, _elements[i].PosY);
        //        Console.Write(' ');

        //        int direction = rand.Next(4);

        //        int newX = _elements[i].PosX;
        //        int newY = _elements[i].PosY;

        //        switch (direction)
        //        {
        //            case 0: newY -= 1; break;
        //            case 1: newY += 1; break;
        //            case 2: newX -= 1; break;
        //            case 3: newX += 1; break;
        //        }

        //        bool withinBounds = newX >= 0 && newX < Console.BufferWidth &&
        //                            newY >= 0 && newY < Console.BufferHeight;

        //        bool hitsWall = walls.Any(w => w.PosX == newX && w.PosY == newY);

        //        if (withinBounds && !hitsWall)
        //        {
        //            _elements[i].PosX = newX;
        //            _elements[i].PosY = newY;
        //        }

                
        //    }
        //}
    }
}