/*
ProcessFile: Mallmetoden som utför stegen för filbearbetning.
OpenFile: Abstrakt metod för att öppna filen.
ReadFile: Abstrakt metod för att läsa filen.
ParseFile: Abstrakt metod för att tolka filen.
CloseFile: Abstrakt metod för att stänga filen.
*/

using System;
using System.IO;

/* Abstrakt klass som definierar mallmetoden för filbearbetning */
public abstract class FileProcessor
{
    public void ProcessFile(string path)
    {
        OpenFile(path);
        ReadFile();
        ParseFile();
        CloseFile();
    }

    protected abstract void OpenFile(string path);
    protected abstract void ReadFile();
    protected abstract void ParseFile();
    protected abstract void CloseFile();
}

/* Konkret klass som implementerar bearbetning av textfiler */
public class TextFileProcessor : FileProcessor
{
    private StreamReader _reader;

    protected override void OpenFile(string path)
    {
        _reader = new StreamReader(path);
        Console.WriteLine("Opening text file.");
    }

    protected override void ReadFile()
    {
        Console.WriteLine("Reading text file.");
    }

    protected override void ParseFile()
    {
        Console.WriteLine("Parsing text file.");
    }

    protected override void CloseFile()
    {
        _reader.Close();
        Console.WriteLine("Closing text file.");
    }
}

/* Konkret klass som implementerar bearbetning av CSV-filer */
public class CsvFileProcessor : FileProcessor
{
    private StreamReader _reader;

    protected override void OpenFile(string path)
    {
        _reader = new StreamReader(path);
        Console.WriteLine("Opening CSV file.");
    }

    protected override void ReadFile()
    {
        Console.WriteLine("Reading CSV file.");
    }

    protected override void ParseFile()
    {
        Console.WriteLine("Parsing CSV file.");
    }

    protected override void CloseFile()
    {
        _reader.Close();
        Console.WriteLine("Closing CSV file.");
    }
}

/* Programklass för att demonstrera filbearbetning med Template Method-mönstret */
class Program
{
    static void Main()
    {
        string textFilePath = "example.txt";
        string csvFilePath = "example.csv";

        FileProcessor textFileProcessor = new TextFileProcessor();
        textFileProcessor.ProcessFile(textFilePath);

        FileProcessor csvFileProcessor = new CsvFileProcessor();
        csvFileProcessor.ProcessFile(csvFilePath);
    }
}
