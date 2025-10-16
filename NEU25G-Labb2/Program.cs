

LevelData leveldata = new LevelData();
leveldata.Load();

Player player = leveldata.Player;

string startGameText = "Game Started! GLHF!!";
string IntroText = "Find and defeat the rats and chase away the snakes!";

ConsoleKey key;

do
{
    Console.SetCursorPosition(60,1);
    Console.Write(startGameText);
    Console.SetCursorPosition(60, 3);
    Console.Write(IntroText);

    Console.CursorVisible = false;
    
    foreach (var element in leveldata.Elements)
    {
        element.Draw();
    }

    player.Draw();
   
    key = Console.ReadKey(true).Key;
    
    if(key == ConsoleKey.W)
    {
       leveldata.PlayerMoveUp();
    }

    if(key == ConsoleKey.S)
    {
       leveldata.PlayerMoveDown();
    }
    
    if (key == ConsoleKey.A)
    {
       leveldata.PlayerMoveLeft();
    }
    
    if (key == ConsoleKey.D)
    {
      leveldata.PlayerMoveRight();
    }

} while(key != ConsoleKey.Escape);
