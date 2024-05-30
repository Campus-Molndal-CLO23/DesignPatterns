using System;
using System.IO;

namespace FacadePatternExample1
{
    // Subsystem classes
    public class FileReader
    {
        public string Read(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }

    public class FileWriter
    {
        public void Write(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }
    }

    public class FileDeleter
    {
        public void Delete(string filePath)
        {
            File.Delete(filePath);
        }
    }

    // Facade class
    public class FileManager
    {
        private FileReader _fileReader;
        private FileWriter _fileWriter;
        private FileDeleter _fileDeleter;

        public FileManager()
        {
            _fileReader = new FileReader();
            _fileWriter = new FileWriter();
            _fileDeleter = new FileDeleter();
        }

        public void CreateFile(string filePath, string content)
        {
            _fileWriter.Write(filePath, content);
            Console.WriteLine($"File created at {filePath}");
        }

        public void ReadFile(string filePath)
        {
            string content = _fileReader.Read(filePath);
            Console.WriteLine($"File content: {content}");
        }

        public void DeleteFile(string filePath)
        {
            _fileDeleter.Delete(filePath);
            Console.WriteLine($"File deleted at {filePath}");
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();

            string filePath = "test.txt";

            fileManager.CreateFile(filePath, "Hello, World!");
            fileManager.ReadFile(filePath);
            fileManager.DeleteFile(filePath);
        }
    }
}

// Output:
// File created at test.txt
// File content: Hello, World!
// File deleted at test.txt


// Förklaring:
// I detta exempel har vi fyra klasser: 
// FileReader, FileWriter, FileDeleter och FileManager.
// FileReader, FileWriter och FileDeleter är underordnade klasser som utför specifika 
// uppgifter.
// FileManager är en fasadklass som fungerar som ett enkelt gränssnitt för att
// interagera med de underliggande klasserna. Genom att använda FileManager kan
// klienten skapa, läsa och ta bort filer utan att behöva känna till de interna 
// detaljerna i varje underliggande klass.
// I huvudprogrammet skapas en instans av FileManager och sedan används den för att
// skapa en fil, läsa filinnehållet och ta bort filen. FileManager hanterar interaktionen
// med de underliggande klasserna och ger en enkel och enhetlig gränssnitt för att
// utföra filrelaterade operationer. Facade-mönstret används för att skapa ett enkelt
// gränssnitt för att interagera med ett komplext system.
