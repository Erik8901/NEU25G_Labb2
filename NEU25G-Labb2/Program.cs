

LevelData leveldata = new LevelData();
leveldata.Load();

Player player = leveldata.Player;


//var rat = new Rat(0,0);
//rat.AttackDice.Throw();
//foreach (var element in leveldata.Elements)
//{
//    element.Draw();
//    leveldata.Elements[2].SignColor = ConsoleColor.Green;
//}
string startGameText = "Game Started! GLHF!!";
ConsoleKey key;

do
{
    Console.SetCursorPosition(60,0);
    Console.Write(startGameText);

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
