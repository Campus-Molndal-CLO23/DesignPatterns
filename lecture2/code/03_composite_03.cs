using System;
using System.Collections.Generic;

namespace CompositePatternComplexExample2
{
    // Component - defines an interface for all objects in the composition
    public interface IGraphic
    {
        void Draw();
    }

    // Leaf - represents leaf objects in the composition
    public class Circle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }

    // Leaf - represents leaf objects in the composition
    public class Rectangle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }
    }

    // Leaf - represents leaf objects in the composition
    public class Line : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Line");
        }
    }

    // Composite - represents a composite node that can have children
    public class GraphicGroup : IGraphic
    {
        private List<IGraphic> _graphics = new List<IGraphic>();

        public void AddGraphic(IGraphic graphic)
        {
            _graphics.Add(graphic);
        }

        public void RemoveGraphic(IGraphic graphic)
        {
            _graphics.Remove(graphic);
        }

        public void Draw()
        {
            foreach (var graphic in _graphics)
            {
                graphic.Draw();
            }
        }
    }

    // Client - uses the composition of graphics
    class Program
    {
        static void Main(string[] args)
        {
            // Create individual graphics
            IGraphic circle = new Circle();
            IGraphic rectangle = new Rectangle();
            IGraphic line = new Line();

            // Create a graphic group and add graphics to it
            GraphicGroup group1 = new GraphicGroup();
            group1.AddGraphic(circle);
            group1.AddGraphic(rectangle);

            // Create another graphic group and add graphics to it
            GraphicGroup group2 = new GraphicGroup();
            group2.AddGraphic(line);
            group2.AddGraphic(group1);

            // Draw all graphics in the composite structure
            group2.Draw();
        }
    }
}

// Output:
// Drawing Line
// Drawing Circle
// Drawing Rectangle
