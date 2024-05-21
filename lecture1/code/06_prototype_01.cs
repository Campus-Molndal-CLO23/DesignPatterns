using System;

// Produktklass som representerar ett dokument
// ICloneable-gränssnittet används för att möjliggöra kloning av dokument

public class Document : ICloneable
{
    // Egenskap för dokumentets titel
    public string Title { get; set; }
    
    // Egenskap för dokumentets innehåll
    public string Content { get; set; }

    // Konstruktor för att initiera ett dokument med titel och innehåll
    public Document(string title, string content)
    {
        Title = title;
        Content = content;
    }

    // Implementerar Clone-metoden från ICloneable-gränssnittet
    public object Clone()
    {
        // Skapar en ytlig kopia av dokumentet
        return this.MemberwiseClone();
        // MemberwiseClone() skapar en ytlig kopia av objektet, 
        // dvs. en kopia av alla värden i objektet
        // Om objektet innehåller referenstyper kopieras referenserna, 
        // inte objekten de refererar till (dvs. referenserna pekar på samma objekt)
                
    }

    // Överskriver ToString-metoden för att ge en strängrepresentation av dokumentet
    public override string ToString()
    {
        return $"Title: {Title}, Content: {Content}";
    }
}

// Klientkod för att använda Prototype-mönstret
class Client
{
    static void Main(string[] args)
    {
        // Skapa ett originaldokument
        Document originalDocument = new Document("Prototype Pattern", "This is an example of the Prototype design pattern.");

        // Klona originaldokumentet
        Document clonedDocument = (Document)originalDocument.Clone();

        // Visa original- och klonade dokument
        Console.WriteLine("Original Document:");
        Console.WriteLine(originalDocument);
        Console.WriteLine();

        Console.WriteLine("Cloned Document:");
        Console.WriteLine(clonedDocument);
    }
}
