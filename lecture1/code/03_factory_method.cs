using System;

// Abstrakt klass för alla dokument
public abstract class Document
{
    // Abstrakt metod för att öppna ett dokument
    public abstract void Open();
    
    // Abstrakt metod för att spara ett dokument
    public abstract void Save();
}

// Konkreta klassen för textdokument som ärver från Document
public class TextDocument : Document
{
    // Implementerar metoden för att öppna textdokument
    public override void Open()
    {
        Console.WriteLine("Opening Text Document...");
    }

    // Implementerar metoden för att spara textdokument
    public override void Save()
    {
        Console.WriteLine("Saving Text Document...");
    }
}

// Konkreta klassen för Markdown-dokument som ärver från Document
public class MarkdownDocument : Document
{
    // Implementerar metoden för att öppna Markdown-dokument
    public override void Open()
    {
        Console.WriteLine("Opening Markdown Document...");
    }

    // Implementerar metoden för att spara Markdown-dokument
    public override void Save()
    {
        Console.WriteLine("Saving Markdown Document...");
    }
}

// Konkreta klassen för PDF-dokument som ärver från Document
public class PdfDocument : Document
{
    // Implementerar metoden för att öppna PDF-dokument
    public override void Open()
    {
        Console.WriteLine("Opening PDF Document...");
    }

    // Implementerar metoden för att spara PDF-dokument
    public override void Save()
    {
        Console.WriteLine("Saving PDF Document...");
    }
}

// Abstrakt Creator-klass som deklarerar Factory Method
public abstract class DocumentCreator
{
    // Factory Method som ska implementeras av underklasser
    public abstract Document CreateDocument();

    // Någon annan metod som använder produkten
    public void SomeOperation()
    {
        // Skapar ett dokument med Factory Method
        var document = CreateDocument();
        // Använder dokumentet
        document.Open();
        document.Save();
    }
}

// Konkreta Creator-klassen för att skapa TextDocument
public class TextDocumentCreator : DocumentCreator
{
    // Implementerar Factory Method för att skapa TextDocument
    public override Document CreateDocument()
    {
        return new TextDocument();
    }
}

// Konkreta Creator-klassen för att skapa MarkdownDocument
public class MarkdownDocumentCreator : DocumentCreator
{
    // Implementerar Factory Method för att skapa MarkdownDocument
    public override Document CreateDocument()
    {
        return new MarkdownDocument();
    }
}

// Konkreta Creator-klassen för att skapa PdfDocument
public class PdfDocumentCreator : DocumentCreator
{
    // Implementerar Factory Method för att skapa PdfDocument
    public override Document CreateDocument()
    {
        return new PdfDocument();
    }
}

// Klientkod som använder DocumentCreator-klasserna
class Client
{
    public void Main()
    {
        // Skapar instanser av olika Creator-klasser
        DocumentCreator creator;

        // Använder TextDocumentCreator för att skapa och använda TextDocument
        creator = new TextDocumentCreator();
        creator.SomeOperation();

        // Använder MarkdownDocumentCreator för att skapa och använda MarkdownDocument
        creator = new MarkdownDocumentCreator();
        creator.SomeOperation();

        // Använder PdfDocumentCreator för att skapa och använda PdfDocument
        creator = new PdfDocumentCreator();
        creator.SomeOperation();
    }
}
