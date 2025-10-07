
abstract class LevelElement
{
    public int PosX { get; set; }
    public int PosY { get; set; }

    public char Sign { get; set; }

   public ConsoleColor SignColor { get; set; }

    //public LevelElement(char sign, int x, int y)
    //{
    //    Sign = sign;
    //    PosX = x; 
    //    PosY = y;
    //}
    
    public void Draw()
    {

        //Console.CursorVisible = false;
        Console.ForegroundColor = SignColor;
        Console.SetCursorPosition(PosX, PosY);
        Console.WriteLine(Sign);
        Console.ResetColor();


    }
}

