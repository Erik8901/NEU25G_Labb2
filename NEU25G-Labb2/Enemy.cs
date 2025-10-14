abstract class Enemy : LevelElement
{
    public string Snake { get; set; }
    public string Rat { get; set; }

    public string Player { get; set; }

    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefendDice { get; set; }

   
}