

LevelData leveldata = new LevelData();
leveldata.Load();

Player player = leveldata.Player;

var rat = new Rat(0,0);
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
      //  rat.Update();
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





//    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
//    if (keyInfo.Key == ConsoleKey.W)
//    {
//        Console.SetCursorPosition(playerStartPosX, playerStartPosY);
//        Console.Write(' ');
//        playerStartPosY = Math.Max(0, playerStartPosY - 1);

//        Console.SetCursorPosition(playerStartPosX, playerStartPosY);
//        Console.Write(player);


//    }



//}

//while (true)
//{

//    //int playerStartPosX = 4;
//    //int playerStartPosY = 3;
//    char player = '@';

//    int startPosX = 4;
//    int startPosY = 3;

//    int previousPosX = startPosX;
//    int previousPosY = startPosY;

//    Console.SetCursorPosition(startPosX, startPosY);
//    Console.Write(player);

//    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

//    if (keyInfo.Key == ConsoleKey.W)
//    {
//        startPosY += -1;
//        //Console.SetCursorPosition(startPosX, startPosY);

//        //Console.Write(player);


//    }
//    else if (keyInfo.Key == ConsoleKey.Escape) {
//        break;
//    }
//}


// This example demonstrates the
//     Console.CursorLeft and
//     Console.CursorTop properties, and the
//     Console.SetCursorPosition and
//     Console.Clear methods.


//abstract class LevelElement
//{
//    //protected static int origRow;
//    //protected static int origCol;

//    //public int sPosX = 0;
//    //public int sPosY = 0;
//    //public char wall = '#';
//    ////Console.ForegroundColor = ConsoleColor.Green

//    //public int posX { get; set; }

//    //public virtual void Draw()
//    //    {
//    //       Console.WriteLine("hej");
//    //    }

//}


//abstract class Wall : LevelElement
//{

//}

//abstract class Enemy : LevelElement
//{
//    public string Snake { get; set; }
//    public string Rat { get; set; }

//    public double Health { get; set; }
//    public int AttackDice {  get; set; }
//    public int DefendDice { get; set; }
//}

//class Snake : Enemy
//{
//    public void Update()
//    {

//    }
//}

//class Rat : Enemy
//{
//    public void Update()
//    {

//    }
//}

//public static void WriteAt(string s, int x, int y)
//{

//        Console.SetCursorPosition(origCol + x, origRow + y);
//        Console.Write(s);

//    //catch (ArgumentOutOfRangeException e)
//    //{
//    //    Console.Clear();
//    //    Console.WriteLine(e.Message);
//    //}
//}

//    public static void Main()
//    {
//        // Clear the screen, then save the top and left coordinates.
//        Console.Clear();
//        origRow = Console.CursorTop;
//        origCol = Console.CursorLeft;

//        // Draw the left side of a 5x5 rectangle, from top to bottom.
//        WriteAt("+", 0, 0);
//        WriteAt("|", 0, 1);
//        WriteAt("|", 0, 2);
//        WriteAt("|", 0, 3);
//        WriteAt("+", 0, 4);

//        // Draw the bottom side, from left to right.
//        WriteAt("-", 1, 4); // shortcut: WriteAt("---", 1, 4)
//        WriteAt("-", 2, 4); // ...
//        WriteAt("-", 3, 4); // ...
//        WriteAt("+", 4, 4);

//        // Draw the right side, from bottom to top.
//        WriteAt("|", 4, 3);
//        WriteAt("|", 4, 2);
//        WriteAt("|", 4, 1);
//        WriteAt("+", 4, 0);

//        // Draw the top side, from right to left.
//        WriteAt("-", 3, 0); // shortcut: WriteAt("---", 1, 0)
//        WriteAt("-", 2, 0); // ...
//        WriteAt("-", 1, 0); // ...
//                            //


//        int startPosX = 20;
//        int startPosY = 20;

//        int previousPosX = startPosX;
//        int previousPosY = startPosY;

//        while (true)
//        {

//            WriteAt("@", startPosX, startPosY);

//            //Console.Clear();
//            if (Console.ReadKey().Key == ConsoleKey.UpArrow)
//            {
//                startPosY += -1;



//                Console.WriteLine(startPosY -1);


//              Console.ForegroundColor = ConsoleColor.Green;

//            }

//            //if (Console.ReadKey().Key == ConsoleKey.DownArrow)
//            //{
//            //    startPosY += +1;

//            //}

//            //if (Console.ReadKey().Key == ConsoleKey.RightArrow)
//            //{
//            //    startPosX += +1;

//            //}
//        }

//        //   while (Console.ReadKey().Key != ConsoleKey.UpArrow) { }


//        //WriteAt("All done!", 0, 6);
//        //Console.WriteLine();
//    }
//}


/*
This example produces the following results:

+---+
|   |
|   |
|   |
+---+

All done!

*/