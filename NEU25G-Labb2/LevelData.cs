

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

        var path = @"C:\Users\erikj\Desktop\NEU25G-Labb2\NEU25G-Labb2\NEU25G-Labb2\bin\\Level1.txt";


        using (StreamReader reader = new StreamReader(path))
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
    public void PlayerMoveUp()
    {
        Console.SetCursorPosition(Player.PosX, Player.PosY);
        Console.Write(' ');
        Player.PosY--;
        Player.Draw();

        for (int i = 0; i < _elements.Count; i++)
        {
           //if(_elements[i].Sign == 'r') {
               
           //     _elements[i].PosX = _elements[i].PosX + 1;
           // }
            
            if (_elements[i].PosY == Player.PosY  && _elements[i].PosX == Player.PosX)
            {
                Player.PosY = Player.PosY + 1;
                //Console.SetCursorPosition(1, 1);
                //Console.WriteLine(_elements[i].Sign);
            }
        }
    }
    public void PlayerMoveDown()
    {
        Console.SetCursorPosition(Player.PosX, Player.PosY);
        Console.Write(' ');
        Player.PosY++;
        Player.Draw();

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

        for (int i = 0; i < _elements.Count; i++)
        {

            if (_elements[i].PosY == Player.PosY && _elements[i].PosX == Player.PosX)
            {
                Player.PosX = Player.PosX - 1;

                
            }
        }
    }

}
