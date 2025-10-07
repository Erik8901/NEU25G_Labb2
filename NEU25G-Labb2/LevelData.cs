


using System.Reflection.PortableExecutable;

internal class LevelData
{
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



                }
                row++;
            }
        }
    }

}
