using System;
using System.Collections.Generic;

namespace FlyweightPatternExample3
{
    // Flyweight interface
    public interface IGraphic
    {
        void Draw(int x, int y, int width, int height, string color);
    }

    // Concrete Flyweight
    public class Graphic : IGraphic
    {
        private string _shape;

        public Graphic(string shape)
        {
            _shape = shape;
        }

        public void Draw(int x, int y, int width, int height, string color)
        {
            Console.WriteLine($"Drawing {_shape} at ({x}, {y}), width: {width}, height: {height}, color: {color}");
        }
    }

    // Flyweight Factory
    public class GraphicFactory
    {
        private Dictionary<string, IGraphic> _graphics = new Dictionary<string, IGraphic>();

        public IGraphic GetGraphic(string shape)
        {
            if (!_graphics.ContainsKey(shape))
            {
                _graphics[shape] = new Graphic(shape);
            }
            return _graphics[shape];
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            GraphicFactory factory = new GraphicFactory();

            List<(string, int, int, int, int, string)> graphicData = new List<(string, int, int, int, int, string)>
            {
                ("Circle", 10, 10, 100, 100, "Red"),
                ("Rectangle", 20, 20, 200, 100, "Blue"),
                ("Circle", 30, 30, 100, 100, "Green"),
                ("Rectangle", 40, 40, 200, 100, "Yellow"),
                ("Circle", 50, 50, 100, 100, "Purple")
            };

            foreach (var (shape, x, y, width, height, color) in graphicData)
            {
                IGraphic graphic = factory.GetGraphic(shape);
                graphic.Draw(x, y, width, height, color);
            }
        }
    }
}

// Output:
// Drawing Circle at (10, 10), width: 100, height: 100, color: Red
// Drawing Rectangle at (20, 20), width: 200, height: 100, color: Blue
// Drawing Circle at (30, 30), width: 100, height: 100, color: Green
// Drawing Rectangle at (40, 40), width: 200, height: 100, color: Yellow
// Drawing Circle at (50, 50), width: 100, height: 100, color: Purple


// Förklaring:
// I detta exempel har vi tre klasser: Graphic, GraphicFactory och Program.
// Graphic är en konkret flyweight-klass som implementerar IGraphic-gränssnittet.
// GraphicFactory är en flyweight-fabrik som skapar och lagrar flyweight-objekt.
// Program är klienten som använder flyweight-objekten för att rita olika former på skärmen.
// När vi skapar en instans av GraphicFactory och använder den för att skapa och 
// rita olika former, kommer flyweight-objekten att återanvändas för att minimera 
// minnesanvändningen. Detta möjliggörs genom att dela gemensamma delar av objekt
// mellan flera objekt. I det här fallet delar vi form-objekten för att minska 
// minnesanvändningen.

