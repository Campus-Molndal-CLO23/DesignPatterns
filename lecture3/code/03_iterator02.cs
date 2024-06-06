using System;
using System.Collections;
using System.Collections.Generic;

// Klass som representerar en bok
public class Book
{
    public string Title { get; set; }

    public Book(string title)
    {
        Title = title;
    }
}

// Gränssnitt för iterator
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Gränssnitt för samling
public interface IBookCollection
{
    IIterator<Book> CreateIterator();
}

// Konkret iterator för att iterera över en samling av böcker
public class BookIterator : IIterator<Book>
{
    private List<Book> _books;
    private int _position = 0;

    public BookIterator(List<Book> books)
    {
        _books = books;
    }

    public bool HasNext()
    {
        return _position < _books.Count;
    }

    public Book Next()
    {
        return _books[_position++];
    }
}

// Konkret samling av böcker
public class BookCollection : IBookCollection
{
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public IIterator<Book> CreateIterator()
    {
        return new BookIterator(_books);
    }
}

// Programklass för att demonstrera iteration över en samling av böcker
class Program
{
    static void Main()
    {
        BookCollection books = new BookCollection();
        books.AddBook(new Book("Vision in White"));
        books.AddBook(new Book("Where the Crawdads Sing"));
        books.AddBook(new Book("Dreams of Joy"));
        books.AddBook(new Book("The Nightingale"));
        
        IIterator<Book> iterator = books.CreateIterator();

        while (iterator.HasNext())
        {
            Book book = iterator.Next();
            Console.WriteLine("Book: " + book.Title);
        }
    }
}

// Output:
// Book: Vision in White
// Book: Where the Crawdads Sing
// Book: Dreams of Joy
// Book: The Nightingale


