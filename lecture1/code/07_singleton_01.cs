using System;

// Singleton-klass för Logger
public class Logger
{
    // Privat statisk variabel som håller den enda instansen av Logger
    private static Logger instance;

    // Privat konstruktor för att förhindra instansiering utanför klassen
    private Logger() 
    {
        // Initieringskod om nödvändigt
    }

    // Statisk metod för att få tillgång till den enda instansen av Logger
    public static Logger GetInstance()
    {
        // Om instansen inte redan finns, skapa den
        if (instance == null)
        {
            instance = new Logger();
        }
        // Returnera den enda instansen
        return instance;
    }

    // Metod för att logga meddelanden
    public void Log(string message)
    {
        // Skriv ut loggmeddelandet till konsolen
        Console.WriteLine("Log: " + message);
    }
}

// Klientkod för att använda Singleton Logger
class Client
{
    static void Main(string[] args)
    {
        // Få instansen av Logger
        Logger logger = Logger.GetInstance();

        // Använd Logger för att logga ett meddelande
        logger.Log("Detta är en loggmeddelande.");

        // Försök att skapa en till instans (ska returnera samma instans)
        Logger anotherLogger = Logger.GetInstance();
        anotherLogger.Log("Ett till loggmeddelande.");

        // Kontrollera om båda variablerna pekar på samma instans
        if (logger == anotherLogger)
        {
            Console.WriteLine("Båda variablerna pekar på samma instans.");
        }
        else
        {
            Console.WriteLine("Variablerna pekar på olika instanser.");
        }
    }
}
