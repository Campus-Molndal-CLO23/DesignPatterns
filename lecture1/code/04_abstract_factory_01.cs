using System;

// Abstrakt produktgränssnitt för Text-dokument
public abstract class TextDocument
{
    public abstract void Open();
    public abstract void Save();
}

// Abstrakt produktgränssnitt för Markdown-dokument
public abstract class MarkdownDocument
{
    public abstract void Open();
    public abstract void Save();
}

// Abstrakt produktgränssnitt för PDF-dokument
public abstract class PdfDocument
{
    public abstract void Open();
    public abstract void Save();
}

// Abstrakt fabrikgränssnitt som deklarerar metoder för att skapa varje typ av dokument
public abstract class DocumentFactory
{
    public abstract TextDocument CreateTextDocument();
    public abstract MarkdownDocument CreateMarkdownDocument();
    public abstract PdfDocument CreatePdfDocument();
}

// Konkret klass för Text-dokument som implementerar TextDocument
public class ConcreteTextDocument : TextDocument
{
    public override void Open()
    {
        Console.WriteLine("Opening Text Document...");
    }

    public override void Save()
    {
        Console.WriteLine("Saving Text Document...");
    }
}

// Konkret klass för Markdown-dokument som implementerar MarkdownDocument
public class ConcreteMarkdownDocument : MarkdownDocument
{
    public override void Open()
    {
        Console.WriteLine("Opening Markdown Document...");
    }

    public override void Save()
    {
        Console.WriteLine("Saving Markdown Document...");
    }
}

// Konkret klass för PDF-dokument som implementerar PdfDocument
public class ConcretePdfDocument : PdfDocument
{
    public override void Open()
    {
        Console.WriteLine("Opening PDF Document...");
    }

    public override void Save()
    {
        Console.WriteLine("Saving PDF Document...");
    }
}

// Konkret fabrikklass som implementerar DocumentFactory och skapar konkreta dokument
public class ConcreteDocumentFactory : DocumentFactory
{
    public override TextDocument CreateTextDocument()
    {
        return new ConcreteTextDocument(); // Skapa och returnera en instans av ConcreteTextDocument
    }

    public override MarkdownDocument CreateMarkdownDocument()
    {
        return new ConcreteMarkdownDocument(); // Skapa och returnera en instans av ConcreteMarkdownDocument
    }

    public override PdfDocument CreatePdfDocument()
    {
        return new ConcretePdfDocument(); // Skapa och returnera en instans av ConcretePdfDocument
    }
}

// Klientkod som använder DocumentFactory för att skapa och använda olika typer av dokument
class Client
{
    static void Main(string[] args)
    {
        // Skapa en instans av den konkreta fabriken
        DocumentFactory factory = new ConcreteDocumentFactory();

        // Skapa och använd ett textdokument
        TextDocument textDoc = factory.CreateTextDocument();
        textDoc.Open(); // Öppna textdokument
        textDoc.Save(); // Spara textdokument

        // Skapa och använd ett Markdown-dokument
        MarkdownDocument markdownDoc = factory.CreateMarkdownDocument();
        markdownDoc.Open(); // Öppna Markdown-dokument
        markdownDoc.Save(); // Spara Markdown-dokument

        // Skapa och använd ett PDF-dokument
        PdfDocument pdfDoc = factory.CreatePdfDocument();
        pdfDoc.Open(); // Öppna PDF-dokument
        pdfDoc.Save(); // Spara PDF-dokument
    }
}
