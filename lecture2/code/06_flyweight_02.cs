using System;
using System.Collections.Generic;

namespace FlyweightPatternExample2
{
    // Flyweight interface
    public interface ITree
    {
        void Display(int x, int y);
    }

    // Concrete Flyweight
    public class Tree : ITree
    {
        private string _type;

        public Tree(string type)
        {
            _type = type;
        }

        public void Display(int x, int y)
        {
            Console.WriteLine($"Displaying {_type} tree at ({x}, {y})");
        }
    }

    // Flyweight Factory
    public class TreeFactory
    {
        private Dictionary<string, ITree> _trees = new Dictionary<string, ITree>();

        public ITree GetTree(string type)
        {
            if (!_trees.ContainsKey(type))
            {
                _trees[type] = new Tree(type);
            }
            return _trees[type];
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            TreeFactory factory = new TreeFactory();

            List<(string, int, int)> treeData = new List<(string, int, int)>
            {
                ("Oak", 1, 1),
                ("Pine", 2, 2),
                ("Oak", 3, 3),
                ("Pine", 4, 4),
                ("Oak", 5, 5)
            };

            foreach (var (type, x, y) in treeData)
            {
                ITree tree = factory.GetTree(type);
                tree.Display(x, y);
            }
        }
    }
}

// Output:
// Displaying Oak tree at (1, 1)
// Displaying Pine tree at (2, 2)
// Displaying Oak tree at (3, 3)
// Displaying Pine tree at (4, 4)
// Displaying Oak tree at (5, 5)


// Förklaring:
// I detta exempel har vi tre klasser:
// - Tree: En klass som implementerar ITree-gränssnittet. Denna klass representer
//   en lövobjekt som innehåller information om trädetypen.
// - TreeFactory: En klass som fungerar som en flyweight-fabrik. Denna klass skapar
//   och lagrar flyweight-objekt.
// - Program: En klientklass som använder TreeFactory för att skapa och visa träd på
//   olika positioner. Genom att använda flyweight-mönstret kan vi minska minnesanvändningen
//   genom att dela gemensamma delar av objekt mellan flera objekt. I det här fallet
//   delar vi trädtyperna mellan flera trädobjekt för att minska minnesanvändningen.


