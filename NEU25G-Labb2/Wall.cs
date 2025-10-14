
class Wall : LevelElement
{
    public Wall(int x, int y)
    {
        Sign = '#';
        SignColor = ConsoleColor.Black;
        PosX = x; 
        PosY = y;
    }
}