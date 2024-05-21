using System;

// Abstract Document class
public abstract class Document
{
    public abstract void Open();
    public abstract void Save();
}

// Concrete TextDocument class
public class TextDocument : Document
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

// Concrete PdfDocument class
public class PdfDocument : Document
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

// Concrete MarkdownDocument class
public class MarkdownDocument : Document
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

// Concrete WordDocument class
public class WordDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening Word Document...");
    }

    public override void Save()
    {
        Console.WriteLine("Saving Word Document...");
    }
}

// Concrete ExcelDocument class
public class ExcelDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening Excel Document...");
    }

    public override void Save()
    {
        Console.WriteLine("Saving Excel Document...");
    }
}

// DocumentFactory class
public class DocumentFactory
{
    public Document CreateDocument(string type)
    {
        switch (type.ToLower())
        {
            case "text":
                return new TextDocument();
            case "pdf":
                return new PdfDocument();
            case "markdown":
                return new MarkdownDocument();
            case "word":
                return new WordDocument();
            case "excel":
                return new ExcelDocument();
            default:
                throw new ArgumentException("Invalid document type");
        }
    }
}

// Client code
class Client
{
    public void Main()
    {
        DocumentFactory factory = new DocumentFactory();

        Document doc;

        doc = factory.CreateDocument("text");
        doc.Open();
        doc.Save();

        doc = factory.CreateDocument("pdf");
        doc.Open();
        doc.Save();

        doc = factory.CreateDocument("markdown");
        doc.Open();
        doc.Save();

        doc = factory.CreateDocument("word");
        doc.Open();
        doc.Save();

        doc = factory.CreateDocument("excel");
        doc.Open();
        doc.Save();
    }
}
