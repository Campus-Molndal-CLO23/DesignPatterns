using System;

// interface for all documents
public interface IDocument
{
    void Open();
    void Save();
}

// concrete class for text documents
public class TextDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Text Document...");
    }

    public void Save()
    {
        Console.WriteLine("Saving Text Document...");
    }
}

// concrete class for PDF documents
public class PdfDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening PDF Document...");
    }

    public void Save()
    {
        Console.WriteLine("Saving PDF Document...");
    }
}

// concrete class for Markdown documents
public class MarkdownDocument : IDocument
{
    public void Open()
    {
        Console.WriteLine("Opening Markdown Document...");
    }

    public void Save()
    {
        Console.WriteLine("Saving Markdown Document...");
    }
}

// simple factory class
public class DocumentFactory
{
    public IDocument CreateDocument(string documentType)
    {
        switch (documentType)
        {
            case "text":
                return new TextDocument();
            case "pdf":
                return new PdfDocument();
            case "markdown":
                return new MarkdownDocument();
            default:
                throw new ArgumentException("Invalid document type");
        }
    }
}