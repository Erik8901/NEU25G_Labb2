
abstract class LevelElement
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public char Sign { get; set; }

    public ConsoleColor SignColor { get; set; }
    public void Draw()
    {
        Console.ForegroundColor = SignColor;
        Console.SetCursorPosition(PosX, PosY);
        Console.WriteLine(Sign);
        Console.ResetColor();
    }
}

