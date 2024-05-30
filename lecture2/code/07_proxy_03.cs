using System;
using System.Collections.Generic;

namespace ProxyPatternExample3
{
    // Subject interface
    public interface IImage
    {
        void Display();
    }

    // RealSubject - the actual image class
    public class RealImage : IImage
    {
        private string _fileName;

        public RealImage(string fileName)
        {
            _fileName = fileName;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($"Loading {_fileName} from disk...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {_fileName}");
        }
    }

    // Proxy - controls access to the RealImage
    public class ProxyImage : IImage
    {
        private RealImage _realImage;
        private string _fileName;

        public ProxyImage(string fileName)
        {
            _fileName = fileName;
        }

        public void Display()
        {
            if (_realImage == null)
            {
                _realImage = new RealImage(_fileName);
            }
            _realImage.Display();
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            List<IImage> images = new List<IImage>
            {
                new ProxyImage("image1.jpg"),
                new ProxyImage("image2.jpg"),
                new ProxyImage("image3.jpg")
            };

            foreach (var image in images)
            {
                image.Display();
            }

            // Displaying again to show that images are not loaded again from disk
            foreach (var image in images)
            {
                image.Display();
            }
        }
    }
}

// Output:
// Loading image1.jpg from disk...
// Displaying image1.jpg
// Loading image2.jpg from disk...
// Displaying image2.jpg
// Loading image3.jpg from disk...
// Displaying image3.jpg
// Displaying image1.jpg
// Displaying image2.jpg
// Displaying image3.jpg

// OBS! I denna version av Proxy-mönstret så laddas bilderna från disk 
// först när de ska visas. Om samma bild ska visas igen så laddas den
// inte från disk igen. Detta är en fördel jämfört med att ladda alla
// bilder från disk direkt när programmet startar. Detta kan vara
// användbart om det finns många bilder och det inte är säkert att alla
// bilder kommer att visas.

// Proxy-mönstret används för att kontrollera åtkomst till ett objekt.
// Det kan användas för att skjuta upp skapandet av ett objekt tills det
// behövs, för att begränsa åtkomst till resurser eller för att lägga
// till extra funktionalitet till ett objekt. I exemplet ovan används
// Proxy-mönstret för att skjuta upp laddningen av bilder från disk tills
// de ska visas. Detta kan vara användbart om det finns många bilder och
// det inte är säkert att alla bilder kommer att visas. Genom att använda
// en Proxy-klass kan vi undvika att ladda onödiga bilder från disk.


