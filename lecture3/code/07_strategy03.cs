using System;
using System.Collections.Generic;

/* Gränssnitt för strategier */
public interface IApiStrategy
{
    void FetchData();
}

/* Konkret strategi för att hämta filmer */
public class MovieApiStrategy : IApiStrategy
{
    public void FetchData()
    {
        Console.WriteLine("Fetching movies from the Movie API...");
        // Simulerar API-anrop
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Movies fetched successfully.");
    }
}

/* Konkret strategi för att hämta musik */
public class MusicApiStrategy : IApiStrategy
{
    public void FetchData()
    {
        Console.WriteLine("Fetching music from the Music API...");
        // Simulerar API-anrop
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Music fetched successfully.");
    }
}

/* Konkret strategi för att hämta PDF-böcker */
public class PdfBookApiStrategy : IApiStrategy
{
    public void FetchData()
    {
        Console.WriteLine("Fetching PDF books from the PDF Book API...");
        // Simulerar API-anrop
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("PDF books fetched successfully.");
    }
}

/* Konkret strategi för att hämta talböcker */
public class AudiobookApiStrategy : IApiStrategy
{
    public void FetchData()
    {
        Console.WriteLine("Fetching audiobooks from the Audiobook API...");
        // Simulerar API-anrop
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Audiobooks fetched successfully.");
    }
}

/* Klass för att hantera API-anrop */
public class ApiFetcher
{
    private IApiStrategy _apiStrategy;

    public void SetStrategy(IApiStrategy apiStrategy)
    {
        _apiStrategy = apiStrategy;
    }

    public void Fetch()
    {
        _apiStrategy.FetchData();
    }
}

/* Programklass för att demonstrera strategimönstret med olika API-anrop */
class Program
{
    static void Main()
    {
        ApiFetcher apiFetcher = new ApiFetcher();

        string fileType = "mp4"; // Den här strängen kan ändras för att testa olika typer

        switch (fileType)
        {
            case "mp4":
            case "avi":
                apiFetcher.SetStrategy(new MovieApiStrategy());
                break;
            case "mp3":
                apiFetcher.SetStrategy(new MusicApiStrategy());
                break;
            case "pdf":
                apiFetcher.SetStrategy(new PdfBookApiStrategy());
                break;
            case "u3":
                apiFetcher.SetStrategy(new AudiobookApiStrategy());
                break;
            default:
                Console.WriteLine("Unsupported file type.");
                return;
        }

        // Anropa det valda API:t
        apiFetcher.Fetch();
    }
}

/*
IApiStrategy: Gränssnitt för strategier som definierar metoden FetchData.
MovieApiStrategy: Konkret strategi för att hämta filmer.
MusicApiStrategy: Konkret strategi för att hämta musik.
PdfBookApiStrategy: Konkret strategi för att hämta PDF-böcker.
AudiobookApiStrategy: Konkret strategi för att hämta talböcker.
ApiFetcher: Klass för att hantera API-anrop och sätta strategin.
Program: Huvudklassen som demonstrerar hur strategimönstret fungerar med olika API-anrop.
*/