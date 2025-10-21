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

    private Random rand = new Random();
    public override void Update(List<Wall> walls, List<Enemy> allEnemies, Player player, List<LevelElement> _elements)
    {
      
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(' ');

      
        var directions = new List<(int dx, int dy)>
    {
        (0, -1), 
        (0, 1),  
        (-1, 0), 
        (1, 0)   
    };

        var validMoves = new List<(int x, int y)>();

        foreach (var (dx, dy) in directions)
        {
            int newX = PosX + dx;
            int newY = PosY + dy;

          
            bool withinBounds = newX >= 0 && newX < Console.BufferWidth &&
                                newY >= 0 && newY < Console.BufferHeight;

           
            bool hitsWall = walls.Any(w => w.PosX == newX && w.PosY == newY);
            bool hitsOtherEnemy = allEnemies.Any(e => e != this && e.PosX == newX && e.PosY == newY);

            if (withinBounds && !hitsWall && !hitsOtherEnemy)
            {
                validMoves.Add((newX, newY));
            }
        }

       
        if (validMoves.Count > 0)
        {
            var move = validMoves[rand.Next(validMoves.Count)];
            PosX = move.x;
            PosY = move.y;
        }

       
        Console.SetCursorPosition(PosX, PosY);
      // Console.Write('r'); 
    }

}
