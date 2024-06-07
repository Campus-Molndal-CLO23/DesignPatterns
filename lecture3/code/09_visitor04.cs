// Exempel på Class Extension

// Regler:
// 1. Extension methods måste vara i en statisk klass
// 2. Extension methods måste vara statiska
// 3. Extension methods måste ha en första parameter som 
//    är av typen som metoden ska vara en extension för
// 4. Extension methods måste ha this nyckelordet före
//    typen som metoden ska vara en extension för
// 5. Extension methods kan inte användas för att ändra
//    en klass, bara för att lägga till metoder 

public static class StringExtensions
{
    // Extension method för att avgöra om en sträng innehåller svenska tecken
    // this nyckelordet används för att ange att metoden är en extension method
    // för strängar, då string den typen som följer efter this
    // anropas såhär:
    // string str = "Hej, Världen!";
    // bool isSwedish = str.containsSwedishChars();
    // Så det ser ut som att metoden är en del av strängen
    public static bool containsSwedishChars(this string str)
    {
        return str.Any(c => "åäöÅÄÖ".Contains(c));
    }

    // Extension method för att hämta en del av en sträng
    // this nyckelordet används för att ange att metoden är en extension method
    // för strängar, då string den typen som följer efter this
    // anropas såhär:
    // string str = "Hello, World!";
    // string left = str.Left(5); // "Hello"
    // Så det ser ut som att metoden är en del av strängen
    public static string Left(this string str, int length)
    {
        if (str.Length < length)
        {
            return str;
        }
        return str.Substring(0, length);
    }

    // Extension method för att hämta en del av en sträng
    // this nyckelordet används för att ange att metoden är en extension method
    // för strängar, då string den typen som följer efter this
    // anropas såhär:
    // string str = "Hello, World!";
    // string right = str.Right(5); // "World"
    // Så det ser ut som att metoden är en del av strängen
    public static string Right(this string str, int length)
    {
        if (str.Length < length)
        {
            return str;
        }
        return str.Substring(str.Length - length, length);
    }
}

public class Program
{
    static void Main()
    {
        string str = "Hello, World!";
        Console.WriteLine(str.containsSwedishChars()); // False

        str = "Hej, Världen!";
        Console.WriteLine(str.containsSwedishChars()); // True

        str = "Hello, World!";
        Console.WriteLine(str.Left(5, "Hello")); // True
    }
}

// Extension metoder beter sig som om de tillhörde den klassen de
// är en extension för. Detta gör att koden blir mer lättare att läsa.
// Extension metoder kan användas för att lägga till metoder
// till en klass utan att ändra koden i klassen. Detta är
// rätt så användbart för att specialisera en klass för den uppgift
// som den ska utföra. 
//
// Det är som att vi på sätt och vis anpassar C# till att fungera enligt
// våra behov. Om vi skriver ett ekonomisystem så kan vi skapa extension
// metoder för att hantera ekonomi relaterade operationer. Om vi skriver
// ett spel så kan vi skapa extension metoder för att hantera spelrelaterade
// operationer.
