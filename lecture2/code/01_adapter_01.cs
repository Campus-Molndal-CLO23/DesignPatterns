using System;

namespace AdapterPatternExample
{
    // ITarget interface - this is the interface that clients expect to work with.
    public interface ITarget
    {
        void Request();
    }

    // Adaptee class - this is the existing class with a different interface.
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }

    // Adapter class - this class adapts the interface of Adaptee to the ITarget interface.
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        // The constructor takes an instance of Adaptee.
        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        // The Request method of the ITarget interface is implemented to call SpecificRequest on the Adaptee instance.
        public void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    // Client class - this class uses the ITarget interface.
    public class Client
    {
        private readonly ITarget _target;

        // The constructor takes an instance of ITarget.
        public Client(ITarget target)
        {
            _target = target;
        }

        // This method calls the Request method on the ITarget instance.
        public void MakeRequest()
        {
            _target.Request();
        }
    }

    // Main program to demonstrate the Adapter Pattern.
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of Adaptee.
            Adaptee adaptee = new Adaptee();
            
            // Creating an instance of Adapter, which wraps the Adaptee instance.
            ITarget target = new Adapter(adaptee);
            
            // Creating an instance of Client, which uses the ITarget interface.
            Client client = new Client(target);

            // Making a request using the Client, which internally calls SpecificRequest on the Adaptee.
            client.MakeRequest();
        }
    }
}

// Output:
// Called SpecificRequest()

// Förklaring:
// ITarget är den interface som klienter förväntas arbeta med. 
// Adaptee är den befintliga klassen med ett annat interface. 
// Adapter är klassen som anpassar Adaptee:s interface till ITarget:s interface.
// Adapter-klassen tar en instans av Adaptee i konstruktorn och implementerar Request-metoden
// från ITarget genom att anropa SpecificRequest på Adaptee-instansen.
// Client-klassen använder ITarget-interfacet och tar en instans av ITarget i konstruktorn.
// MakeRequest-metoden på Client anropar Request-metoden på ITarget-instansen.
// I huvudprogrammet skapas en instans av Adaptee, en instans av Adapter som 
// omsluter Adaptee-instansen
// och en instans av Client som använder ITarget-interfacet. 
// En förfrågan görs med Client, som internt anropar SpecificRequest på Adaptee.
// Adapter-mönstret används för att anpassa ett interfaces till ett annat.

// Adapter-mönstret kan användas för att anpassa ett interface till ett annat.
// Det kan vara användbart när du vill använda en klass som har ett interface som inte
// passar med det interface som en klient förväntar sig. Adapter-mönstret kan användas
// för att skapa en adapterklass som anpassar det befintliga interfacet till det önskade
// interfacet. Detta kan vara användbart när du vill använda en befintlig klass i en
// applikation utan att behöva ändra koden i den befintliga klassen. 

