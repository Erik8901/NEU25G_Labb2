
internal class LevelData
{
    public Player Player { get; private set; }

    private bool inCombat = false;

    //Enemy Enemy = new Enemy(Rat);
    Rat rat = new Rat(0, 0); // Only once!
    public int playerHp = 100;

    private List<LevelElement> _elements = new List<LevelElement>();
    public List<LevelElement> Elements
    {
        get { return _elements; }

    }
    public void Load()
    {
        

        // var path = @"C:\Users\erikj\Desktop\NEU25G-Labb2\NEU25G-Labb2\NEU25G-Labb2\bin\\Level1.txt";

        var pathHome = @"C:\Users\erikj\source\repos\NEU25G_Labb2\NEU25G-Labb2\bin\\Level1.txt";


        using (StreamReader reader = new StreamReader(pathHome))
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
        //Console.SetCursorPosition(60, 4);
        //Console.Write($"Player Health is: {playerHp}");
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

                if (withinBounds && !hitsWall)
                {
                    _elements[i].PosX = newX;
                    _elements[i].PosY = newY;
                }
            }
          }
    }

    public void TrackPlayerAndEnemiesPos()
    {
       
        var rats = new List<Rat>();

        for (int i = 0; i < _elements.Count; i++)
        {
           if (_elements[i].Sign == 'r')
            {
                rats.Add((Rat)_elements[i]);
                
                if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
                {

                    if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
                       {

                        Rat rat = _elements[i] as Rat;
                        if (rat == null) return;

                        int playerAttackDmg = Player.AttackDice.Throw();
                        int ratDefendDmg = rat.DefendDice.Throw();

                        if (playerAttackDmg > ratDefendDmg)
                        {
                            int ratDmgToTake = playerAttackDmg - ratDefendDmg;
                            rat.Health -= ratDmgToTake;
                            Console.SetCursorPosition(1, 3);
                            Console.Write($"af: {rat.Health}  ");

                           
                            if (rat.Health <= 0)
                            {
                                int index = _elements.IndexOf(_elements[i]);
                                _elements.RemoveAt(index);
                                Console.SetCursorPosition(60, 6);
                                Console.Write($"Enemy rat DEFEATED, Good Job!!");
                            }
                        }
                        else
                        {
                             int playerDmgToTake = ratDefendDmg - playerAttackDmg;
                             Player.Health -= playerDmgToTake;

                            //Console.SetCursorPosition(1, 4);
                            //Console.Write($"PH: {Player.Health}  ");
                            if (Player.Health <= 0)
                            {
                                Console.SetCursorPosition(60, 7);
                                Console.Write("You were defeated by the rats...");
                                Player.SignColor = ConsoleColor.Black;
                            }
                        }
                    }
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
                int dx = _elements[i].PosX - Player.PosX;
                int dy = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(dx * dx + dy * dy);

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
                int dx = _elements[i].PosX - Player.PosX;
                int dy = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(dx * dx + dy * dy);

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
                    int dx = _elements[i].PosX - Player.PosX;
                    int dy = _elements[i].PosY - Player.PosY;

                    double distance = Math.Sqrt(dx * dx + dy * dy);

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
                int dx = _elements[i].PosX - Player.PosX;
                int dy = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(dx * dx + dy * dy);

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
                int dx = _elements[i].PosX - Player.PosX;
                int dy = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(dx * dx + dy * dy);

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
                int dx = _elements[i].PosX - Player.PosX;
                int dy = _elements[i].PosY - Player.PosY;

                double distance = Math.Sqrt(dx * dx + dy * dy);

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

