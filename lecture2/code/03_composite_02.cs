using System;
using System.Collections.Generic;

namespace CompositePatternComplexExample
{
    // Component - defines an interface for all objects in the composition
    public interface IFileSystemItem
    {
        void Display(int depth);
    }

    // Leaf - represents leaf objects in the composition
    public class File : IFileSystemItem
    {
        private string _name;

        public File(string name)
        {
            _name = name;
        }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + _name);
        }
    }

    // Composite - represents a composite node that can have children
    public class Directory : IFileSystemItem
    {
        private string _name;
        private List<IFileSystemItem> _items = new List<IFileSystemItem>();

        public Directory(string name)
        {
            _name = name;
        }

        public void AddItem(IFileSystemItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(IFileSystemItem item)
        {
            _items.Remove(item);
        }

        public void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + _name);
            foreach (var item in _items)
            {
                item.Display(depth + 2);
            }
        }
    }

    // Client - uses the composition of file system items
    class Program
    {
        static void Main(string[] args)
        {
            // Create files
            File file1 = new File("File1.txt");
            File file2 = new File("File2.txt");
            File file3 = new File("File3.txt");
            File file4 = new File("File4.txt");

            // Create directories and add files to them
            Directory root = new Directory("Root");
            Directory subDir1 = new Directory("SubDirectory1");
            Directory subDir2 = new Directory("SubDirectory2");

            root.AddItem(subDir1);
            root.AddItem(file1);
            root.AddItem(file2);

            subDir1.AddItem(file3);
            subDir1.AddItem(subDir2);

            subDir2.AddItem(file4);

            // Display the structure
            root.Display(1);
        }
    }
}

// Output:
// -Root
// --SubDirectory1
// ----File3.txt
// ----SubDirectory2
// ------File4.txt
// --File1.txt
// --File2.txt

// Förklaring:
// I detta exempel har vi tre klasser: File, Directory och Program.
// File är en leaf-klass som representerar filer i ett filsystem.
// Directory är en composite-klass som representerar kataloger i ett filsystem.
// Program är en klient som skapar filer och kataloger och lägger till dem i en hierarki.
// När programmet körs skapas en hierarki av filer och kataloger och sedan visas strukturen.
// Composite pattern används för att skapa en hierarki av objekt där både lövobjekt och kompositobjekt
// kan behandlas på samma sätt. I det här fallet kan både filer och kataloger läggas till i en katalog,
// och hela strukturen kan visas rekursivt. Composite pattern används ofta för att skapa trädstrukturer
// av objekt där både individuella objekt och grupper av objekt kan behandlas på samma sätt. Detta möjliggör
// att klienten kan arbeta med komplexa strukturer av objekt på ett enhetligt sätt. Composite pattern används
// ofta i grafiska användargränssnitt, dokumentstrukturer och andra situationer där det finns en hierarki av objekt.
