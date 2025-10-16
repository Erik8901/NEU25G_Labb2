
internal class LevelData
{
    public Player Player { get; private set; }

    private bool ratAttacksPlayer = false;

    private List<LevelElement> _elements = new List<LevelElement>();
    public List<LevelElement> Elements
    {
        get { return _elements; }

    }
    public void Load()
    {

        var path = "Levels/Level1.txt";

        using (StreamReader reader = new StreamReader(path))
        {

            int row = 0;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    char currentChar = line[i];
                    
                    if (currentChar == '#')
                    {
                        _elements.Add(new Wall(i, row));
                    }
                    if (currentChar == 's')
                    {
                        _elements.Add(new Snake(i, row));
                    }
                    if (currentChar == 'r')
                    {
                        _elements.Add(new Rat(i, row));
                    }
                    if (currentChar == '@')
                    {
                        Player = new Player(i, row);
                    }
                }
                row++;
            }
        }
     }
    public void ShuffleSnakes()
    {
        var walls = new List<Wall>();
        var snakes = new List<Snake>();
        var rats = new List<Rat>();
        Random rand = new Random();


        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == '#')
            {
                walls.Add((Wall)_elements[i]);
            }

            if (_elements[i].Sign == 'r')
            {
                rats.Add((Rat)_elements[i]);
            }

            if (_elements[i].Sign == 's')
            {
                snakes.Add((Snake)_elements[i]);
            }
        }

        for (int i = 0; i < snakes.Count; ++i)
        {
            int distanceX = Player.PosX - snakes[i].PosX;
            int distanceY = Player.PosY - snakes[i].PosY;

           
            if (Math.Abs(distanceX) <= 2 && Math.Abs(distanceY) <= 2)
            {
               
                Console.SetCursorPosition(snakes[i].PosX, snakes[i].PosY);
                Console.Write(' ');

                int currentDistance = Math.Abs(distanceX) + Math.Abs(distanceY);

                List<(int distanceX, int distanceY)> directions = new List<(int, int)>
                {
                    (0, -1), 
                    (0, 1), 
                    (-1, 0), 
                    (1, 0)  
                };

                List<(int newX, int newY)> validMoves = new List<(int, int)>();

                foreach (var dir in directions)
                {
                    int newX = snakes[i].PosX + dir.distanceX;
                    int newY = snakes[i].PosY + dir.distanceY;

                    int newDistance = Math.Abs(Player.PosX - newX) + Math.Abs(Player.PosY - newY);

                    bool withinBounds;

                    if (newX >= 0 && newX < Console.BufferWidth && newY >= 0 && newY < Console.BufferHeight)
                    {
                        withinBounds = true;
                    }
                    else
                    {
                        withinBounds = false;
                    }

                    bool hitsWall = walls.Any(w => w.PosX == newX && w.PosY == newY);

                    bool hitsSnake = false;

                    for (int j = 0; j < snakes.Count; ++j)
                    {
                        if (j != i && snakes[j].PosX == newX && snakes[j].PosY == newY)
                        {
                            hitsSnake = true;
                            break;
                        }
                    }

                    bool hitsRat = false;

                    for (int j = 0; j < rats.Count; ++j)
                    {
                        if (j != i && rats[j].PosX == newX && rats[j].PosY == newY)
                        {
                            hitsRat = true;
                            break;
                        }
                    }

                    if (withinBounds && !hitsWall && !hitsSnake && !hitsRat && newDistance > currentDistance)
                    {
                        validMoves.Add((newX, newY));
                    }
                }
                
                if (validMoves.Count > 0)
                {
                    var move = validMoves[rand.Next(validMoves.Count)];
                    snakes[i].PosX = move.newX;
                    snakes[i].PosY = move.newY;
                }
            }
        }

    }
    public void ShuffleRats()
    {
        var walls = new List<Wall>();
        var rats = new List<Rat>();
        Random rand = new Random();

        for (int i = _elements.Count - 1; i >= 0; i--)
        {
            if (_elements[i].Sign == '#')
            {
                walls.Add((Wall)_elements[i]);
            }

            if (_elements[i].Sign == 'r')
            {
                rats.Add((Rat)_elements[i]);
            }
        }

        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == 'r')
            {
                Console.SetCursorPosition(_elements[i].PosX, _elements[i].PosY);
                Console.Write(' ');

                int direction = rand.Next(4);

                int newX = _elements[i].PosX;
                int newY = _elements[i].PosY;

                switch (direction)
                {
                    case 0: newY -= 1; break;
                    case 1: newY += 1; break;
                    case 2: newX -= 1; break;
                    case 3: newX += 1; break;
                }

                bool withinBounds = newX >= 0 && newX < Console.BufferWidth &&
                                    newY >= 0 && newY < Console.BufferHeight;

                bool hitsWall = walls.Any(w => w.PosX == newX && w.PosY == newY);

                if (withinBounds && !hitsWall)
                {
                    _elements[i].PosX = newX;
                    _elements[i].PosY = newY;
                }

                if (newX == Player.PosX && newY == Player.PosY)
                {
                    ratAttacksPlayer = true;

                    Rat rat = _elements[i] as Rat;
                    if (rat != null)
                    {
                        RatAttacksPlayer(rat, i);
                    }

                    ratAttacksPlayer = false; 
                }
            }
        }
    }


    private void PlayerAttacksRat(Rat rat, int index)
    {
        List<int> ratsToRemove = new List<int>();

        int playerAttackDmg = Player.AttackDice.Throw();
        Console.SetCursorPosition(60, 14);
        Console.Write($"Player attacks with {playerAttackDmg}");
        
        int ratDefendDmg = rat.DefendDice.Throw();
        Console.SetCursorPosition(60, 15);
        Console.Write($"Rat Defends with {ratDefendDmg}");

        if (ratAttacksPlayer == false)
        {
           
            if (playerAttackDmg > ratDefendDmg)
            {
                int ratDmgToTake = playerAttackDmg - ratDefendDmg;
                rat.Health -= ratDmgToTake;

                Console.SetCursorPosition(60, 7);
                Console.Write($"Player Health: {Player.Health}  ");

                Console.SetCursorPosition(60, 9);
                Console.Write($"Rat Health:  {rat.Health}   "); 

                if (rat.Health <= 0)
                {
                    rat.Health = 0;
                    _elements.RemoveAt(index);
                    Console.SetCursorPosition(60, 6);
                    Console.Write("Enemy rat DEFEATED, Good Job!!");
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(60, 6);
                    Console.Write(new string(' ', "Enemy rat DEFEATED, Good Job!!".Length));
                    return;
                }
                else
                {
                    RatAttacksPlayer(rat, index);
                }
            }
        }
    }

    private void RatAttacksPlayer(Rat rat, int index)
    {
        int ratAttackDmg = rat.AttackDice.Throw();
        Console.SetCursorPosition(60, 17);
        Console.Write($"Rat attacks with {ratAttackDmg}");
        
        int playerDefendDmg = Player.DefendDice.Throw();
        Console.SetCursorPosition(60, 18);
        Console.Write($"Player defends with {playerDefendDmg}");

        if (ratAttackDmg > playerDefendDmg)
        {
            int playerDmgToTake = ratAttackDmg - playerDefendDmg;
            Player.Health -= playerDmgToTake;

            Console.SetCursorPosition(60, 7);
            Console.Write($"Player Health: {Player.Health}  ");
            
            Console.SetCursorPosition(60, 9);
            Console.Write($"Rat Health:  {rat.Health}");

           if (Player.Health <= 0)
            {
                Console.SetCursorPosition(60, 10);
                Console.Write("You were defeated by the rats...");
                Player.SignColor = ConsoleColor.Black;
            }
            else
            {
                PlayerAttacksRat(rat, index); 
            }
        }
    }


    public void TrackPlayerAndEnemiesPos()
    {
        var rats = new List<Rat>();
        var snakes = new List<Snake>();

        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == 'r')
            {
                rats.Add((Rat)_elements[i]);

                if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
                {
                    Rat rat = (Rat)_elements[i];
                    PlayerAttacksRat(rat, i);
                }
            }
        }
    }
    public void EnemiesWithinPlayerBounds()
    {
        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == 'r')
            {
                int distanceX = _elements[i].PosX - Player.PosX;
                int distanceY = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                if (distance <= 5)
                {
                    _elements[i].SignColor = ConsoleColor.Magenta;
                }
                if (distance > 5)
                {
                    _elements[i].SignColor = ConsoleColor.Black;
                }
            }
            if (_elements[i].Sign == 's')
            {
                int distanceX = _elements[i].PosX - Player.PosX;
                int distanceY = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                if (distance <= 5)
                {
                    _elements[i].SignColor = ConsoleColor.Blue;
                }
                if (distance > 5)
                {
                    _elements[i].SignColor = ConsoleColor.Black;
                }
            }
        }
    }
    public void PlayerMoveUp()
    {
        Console.SetCursorPosition(Player.PosX, Player.PosY);
        Console.Write(' ');
        Player.PosY--;
        Player.Draw();

        ShuffleRats();
        ShuffleSnakes();
        TrackPlayerAndEnemiesPos();

        EnemiesWithinPlayerBounds();
        for (int i = 0; i < _elements.Count; i++)
            {
                if (_elements[i].Sign == '#')
                {
                    int distanceX = _elements[i].PosX - Player.PosX;
                    int distanceY = _elements[i].PosY - Player.PosY;

                    double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                    if (distance <= 5)
                    {
                        _elements[i].SignColor = ConsoleColor.Yellow;
                    }
                
                    if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
                    {
                        Player.PosY = Player.PosY + 1;
                    }
                }
            }
    }
    public void PlayerMoveDown()
    {
        Console.SetCursorPosition(Player.PosX, Player.PosY);
        Console.Write(' ');
        Player.PosY++;
        Player.Draw();

        ShuffleRats();
        ShuffleSnakes();
        TrackPlayerAndEnemiesPos();

        EnemiesWithinPlayerBounds();
        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == '#')
            {
                int distanceX = _elements[i].PosX - Player.PosX;
                int distanceY = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                if (distance <= 5)
                {
                    _elements[i].SignColor = ConsoleColor.Yellow;
                }

                if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
                {
                    Player.PosY = Player.PosY - 1;
                }
            }
        }

    }
    public void PlayerMoveLeft()
    {
        Console.SetCursorPosition(Player.PosX, Player.PosY);
        Console.Write(' ');
        Player.PosX--;
        Player.Draw();
        
        ShuffleRats();
        ShuffleSnakes();
        TrackPlayerAndEnemiesPos();

        EnemiesWithinPlayerBounds();
        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == '#')
            {
                int distanceX = _elements[i].PosX - Player.PosX;
                int distanceY = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                if (distance <= 5)
                {
                    _elements[i].SignColor = ConsoleColor.Yellow;
                }

                if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
                {
                    Player.PosX = Player.PosX + 1;
                }
            }
        }

    }
    public void PlayerMoveRight()
    {
        Console.SetCursorPosition(Player.PosX, Player.PosY);
        Console.Write(' ');
        Player.PosX++;
        Player.Draw();
        
        ShuffleRats();
        ShuffleSnakes();
        TrackPlayerAndEnemiesPos();
        EnemiesWithinPlayerBounds();
        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == '#')
            {
                int distanceX = _elements[i].PosX - Player.PosX; 
                int distanceY = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                if (distance <= 5)
                {
                    _elements[i].SignColor = ConsoleColor.Yellow;
                }

                if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
                {
                    Player.PosX = Player.PosX - 1;
                }
            }
        }
    }
}