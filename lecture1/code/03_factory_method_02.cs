using System;

namespace SantasWorkshop
{
    /// <summary>
    /// Enum representing different toy types.
    /// </summary>
    public enum ToyType
    {
        Doll,
        Car,
        Train,
        Robot,
        Puzzle
    }

    /// <summary>
    /// Abstract base class for all toys.
    /// </summary>
    public abstract class Toy
    {
        public abstract string Name { get; }
    }

    /// <summary>
    /// Class representing a Doll toy.
    /// </summary>
    public class Doll : Toy
    {
        public override string Name => "Doll";
    }

    /// <summary>
    /// Class representing a Car toy.
    /// </summary>
    public class Car : Toy
    {
        public override string Name => "Car";
    }

    /// <summary>
    /// Class representing a Train toy.
    /// </summary>
    public class Train : Toy
    {
        public override string Name => "Train";
    }

    /// <summary>
    /// Class representing a Robot toy.
    /// </summary>
    public class Robot : Toy
    {
        public override string Name => "Robot";
    }

    /// <summary>
    /// Class representing a Puzzle toy.
    /// </summary>
    public class Puzzle : Toy
    {
        public override string Name => "Puzzle";
    }

    /// <summary>
    /// Abstract factory class for creating toys.
    /// Detta är en del av Factory Method designmönstret, som tillåter oss att skapa objekt utan att specificera den exakta klassen för objektet som ska skapas.
    /// </summary>
    public abstract class ToyFactory
    {
        public abstract Toy CreateToy();
    }

    /// <summary>
    /// Factory class for creating Doll toys.
    /// </summary>
    public class DollFactory : ToyFactory
    {
        public override Toy CreateToy() => new Doll();
    }

    /// <summary>
    /// Factory class for creating Car toys.
    /// </summary>
    public class CarFactory : ToyFactory
    {
        public override Toy CreateToy() => new Car();
    }

    /// <summary>
    /// Factory class for creating Train toys.
    /// </summary>
    public class TrainFactory : ToyFactory
    {
        public override Toy CreateToy() => new Train();
    }

    /// <summary>
    /// Factory class for creating Robot toys.
    /// </summary>
    public class RobotFactory : ToyFactory
    {
        public override Toy CreateToy() => new Robot();
    }

    /// <summary>
    /// Factory class for creating Puzzle toys.
    /// </summary>
    public class PuzzleFactory : ToyFactory
    {
        public override Toy CreateToy() => new Puzzle();
    }

    /// <summary>
    /// Utility class to calculate weekends until Christmas.
    /// Denna klass är ansvarig för att utföra en specifik beräkning, vilket följer principen om enkel ansvarighet (SRP).
    /// </summary>
    public static class ChristmasCountdown
    {
        public static int GetWeekendsUntilChristmas()
        {
            DateTime today = DateTime.Today;
            DateTime christmas = new DateTime(today.Year, 12, 25);
            if (today > christmas)
            {
                christmas = new DateTime(today.Year + 1, 12, 25);
            }

            int weekendsUntilChristmas = 0;
            for (DateTime date = today; date <= christmas; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    weekendsUntilChristmas++;
                }
            }

            return weekendsUntilChristmas / 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create toy factories
            // Vi använder Factory Method för att skapa olika typer av leksaker utan att specifikt behöva känna till deras exakta klasser.
            ToyFactory[] factories = new ToyFactory[]
            {
                new DollFactory(),
                new CarFactory(),
                new TrainFactory(),
                new RobotFactory(),
                new PuzzleFactory()
            };

            // Create and display toys
            // Vi itererar genom fabrikerna, skapar leksaker och visar deras namn. Detta demonstrerar hur Factory Method kan användas för att skapa objekt polymorfiskt.
            foreach (var factory in factories)
            {
                Toy toy = factory.CreateToy();
                Console.WriteLine($"Created toy: {toy.Name}");
            }

            // Display weekends until Christmas
            // Vi använder ChristmasCountdown-klassen för att beräkna och visa antalet helger kvar till jul.
            int weekendsUntilChristmas = ChristmasCountdown.GetWeekendsUntilChristmas();
            Console.WriteLine($"There are {weekendsUntilChristmas} weekends until Christmas.");
        }
    }
}
