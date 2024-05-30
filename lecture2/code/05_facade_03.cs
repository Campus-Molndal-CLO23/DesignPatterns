using System;

namespace FacadePatternExample4
{
    // Subsystem classes
    public class PaymentProcessor
    {
        public bool ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing payment of ${amount}");
            // Simulate payment processing
            return true;
        }
    }

    public class ShippingService
    {
        public void ShipProduct(string productName, string address)
        {
            Console.WriteLine($"Shipping {productName} to {address}");
        }
    }

    // Facade class
    public class OrderFacade
    {
        private PaymentProcessor _paymentProcessor;
        private ShippingService _shippingService;

        public OrderFacade()
        {
            _paymentProcessor = new PaymentProcessor();
            _shippingService = new ShippingService();
        }

        public void PlaceOrder(string productName, double amount, string address)
        {
            Console.WriteLine("Starting order placement process...");

            if (_paymentProcessor.ProcessPayment(amount))
            {
                _shippingService.ShipProduct(productName, address);
                Console.WriteLine("Order placed successfully!");
            }
            else
            {
                Console.WriteLine("Payment failed. Order could not be placed.");
            }
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            OrderFacade orderFacade = new OrderFacade();
            orderFacade.PlaceOrder("Laptop", 1200.00, "1234 Elm Street");
        }
    }
}

// Output:
// Starting order placement process...
// Processing payment of $1200
// Shipping Laptop to 1234 Elm Street
// Order placed successfully!


// Förklaring:
// I detta exempel har vi tre klasser: PaymentProcessor, ShippingService och OrderFacade.
// OrderFacade är en fasadklass som samordnar interaktionen mellan PaymentProcessor och ShippingService.
// OrderFacade har en metod PlaceOrder som hanterar hela processen för att placera en order.
// Genom att använda OrderFacade kan klienten placera en order med en enkel metodanrop.
// Detta möjliggör en enkel och tydlig gränssnitt för att interagera med de underliggande systemen.
