using System;

// Produktklass som representerar ett monster
public class Monster : ICloneable
{
    // Egenskaper för monster
    public string Name { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }

    // Konstruktor för att initiera ett monster med namn, hälsa och attackvärde
    public Monster(string name, int health, int attack)
    {
        Name = name;
        Health = health;
        Attack = attack;
    }

    // Implementerar Clone-metoden från ICloneable-gränssnittet
    public object Clone()
    {
        // Skapar en ytlig kopia av monstret
        return this.MemberwiseClone();
    }

    // Överskriver ToString-metoden för att ge en strängrepresentation av monstret
    public override string ToString()
    {
        return $"Name: {Name}, Health: {Health}, Attack: {Attack}";
    }
}

// Klientkod för att använda Prototype-mönstret
class Client
{
    static void Main(string[] args)
    {
        // Skapa ett originalmonster
        Monster originalMonster = new Monster("Orc", 100, 15);

        // Klona originalmonstret
        Monster clonedMonster = (Monster)originalMonster.Clone();
        clonedMonster.Name = "Cloned Orc";
        
        // Visa original- och klonade monster
        Console.WriteLine("Original Monster:");
        Console.WriteLine(originalMonster);
        Console.WriteLine();

        Console.WriteLine("Cloned Monster:");
        Console.WriteLine(clonedMonster);
    }
}
