class Rat : Enemy
{

    public Rat(int x, int y)
    {
        Sign = 'r';
        SignColor = ConsoleColor.Magenta;
        PosX = x;
        PosY = y;
        AttackDice = new Dice(2, 6, 1);
    }
    public void Update()
    {
      //  Console.WriteLine("rats");

     
       
    }
}

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