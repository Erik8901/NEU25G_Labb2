class Snake : Enemy
{
    public Dice AttackDice { get; set; }
    public Dice DefendDice { get; set; }

    public int Health { get; set; }
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

    private Random rand = new Random();
    public override void Update(List<Wall> walls,List<Enemy> allEnemies, Player player, List<LevelElement> _elements)
    {
        int distanceX = player.PosX - this.PosX;
        int distanceY = player.PosY - this.PosY;

        if (Math.Abs(distanceX) <= 2 && Math.Abs(distanceY) <= 2)
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(' ');

            int currentDistance = Math.Abs(distanceX) + Math.Abs(distanceY);

            var directions = new List<(int dx, int dy)>
            {
                (0, -1), (0, 1), (-1, 0), (1, 0)
            };

            var validMoves = new List<(int x, int y)>();

            foreach (var (dx, dy) in directions)
            {
                int newX = PosX + dx;
                int newY = PosY + dy;

                int newDistance = Math.Abs(player.PosX - newX) + Math.Abs(player.PosY - newY);

                bool withinBounds = newX >= 0 && newX < Console.BufferWidth &&
                                    newY >= 0 && newY < Console.BufferHeight;

                bool hitsWall = walls.Any(w => w.PosX == newX && w.PosY == newY);
                bool hitsOtherEnemy = allEnemies.Any(e => e != this && e.PosX == newX && e.PosY == newY);

                if (withinBounds && !hitsWall && !hitsOtherEnemy && newDistance > currentDistance)
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
        }


    }

}