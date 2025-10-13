using System;

public class Dice
{
    public int NumberOfDice { get; set; }
    public int SidesPerDice { get; set; }
    public int Modifier { get; set; }

    private static readonly Random random = new Random();

    public Dice(int numberOfDice, int sidesPerDice, int modifier)
    {
        NumberOfDice = numberOfDice;
        SidesPerDice = sidesPerDice;
        Modifier = modifier;
    }

    public int Throw()
    {
        int total = 0;
        
        for (int i = 0; i < NumberOfDice; i++)
        {
            total += random.Next(1, SidesPerDice + 1);
        }
        //Console.SetCursorPosition(1, 1);
        //Console.Write(total + Modifier);
        return total + Modifier;
    }



    public override string ToString()
    {
        string mod = Modifier >= 0 ? $"+{Modifier}" : $"{Modifier}";
        return $"{NumberOfDice}d{SidesPerDice}{mod}";
    }
}
