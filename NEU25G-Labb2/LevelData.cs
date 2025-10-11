
internal class LevelData
{
    public Player Player { get; private set; }
    
    private List<LevelElement> _elements = new List<LevelElement>();
    public List<LevelElement> Elements
	{
		get { return _elements; }
		
	}
    
    public void Load()
	{
       // Console.WriteLine("load");

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
                   //Console.WriteLine($"Char '{currentChar}' at coords; ({row}, {i})");
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
        Random rand = new Random();

        

        double hy;

        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == '#')
            {
                walls.Add((Wall)_elements[i]);
            }

            if (_elements[i].Sign == 's')
            {
                snakes.Add((Snake)_elements[i]);
            }
        }

      
        for (int i = 0; i < _elements.Count; i++)
        {
            if (_elements[i].Sign == 's')
            {
               
                double playerPosY = Player.PosY, playerPosX = Player.PosX;
                double snakePosY = _elements[i].PosY, snakePosX = _elements[i].PosX;

            

             

                
                    double deltaX = playerPosX - snakePosX;
                    double deltaY = snakePosY - playerPosY;
                double distance =  Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                  
                Console.SetCursorPosition(1, 1);
                Console.Write(distance);

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

   public void PlayerMoveUp()
    {
        Console.SetCursorPosition(Player.PosX, Player.PosY);
        Console.Write(' ');
        Player.PosY--;
        Player.Draw();

        ShuffleRats();
        ShuffleSnakes();
       for (int i = 0; i < _elements.Count; i++)
        {

          if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
            {
                Player.PosY = Player.PosY + 1;
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
        
        for (int i = 0; i < _elements.Count; i++)
        {

            if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
            {
                Player.PosY = Player.PosY - 1;
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
        
        for (int i = 0; i < _elements.Count; i++)
        {

            if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
            {
                Player.PosX = Player.PosX + 1;
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
       
        for (int i = 0; i < _elements.Count; i++)
        {

            if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
            {
                Player.PosX = Player.PosX - 1;
            }
        }
    }
}

