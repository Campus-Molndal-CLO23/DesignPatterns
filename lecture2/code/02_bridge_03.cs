using System;

namespace BridgePatternExample3
{
    // Abstraction - defines the interface for the control part of the two class hierarchies
    public abstract class Payment
    {
        protected IPaymentProcessor _paymentProcessor;

        // Constructor takes an instance of IPaymentProcessor
        protected Payment(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public abstract void MakePayment(decimal amount);
    }

    // Refined Abstraction - extends the interface defined by Abstraction
    public class OnlinePayment : Payment
    {
        // Constructor takes an instance of IPaymentProcessor
        public OnlinePayment(IPaymentProcessor paymentProcessor) : base(paymentProcessor) { }

        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Processing online payment...");
            _paymentProcessor.ProcessPayment(amount);
        }
    }

    // Refined Abstraction - another type of payment
    public class InStorePayment : Payment
    {
        // Constructor takes an instance of IPaymentProcessor
        public InStorePayment(IPaymentProcessor paymentProcessor) : base(paymentProcessor) { }

        public override void MakePayment(decimal amount)
        {
            Console.WriteLine("Processing in-store payment...");
            _paymentProcessor.ProcessPayment(amount);
        }
    }

    // Implementor - defines the interface for the implementation class hierarchy
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    // Concrete Implementor - implements the Implementor interface for credit card payments
    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Credit card payment processed: ${amount}");
        }
    }

    // Concrete Implementor - implements the Implementor interface for PayPal payments
    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"PayPal payment processed: ${amount}");
        }
    }

    // Client - uses the Abstraction interface
    class Program
    {
        static void Main(string[] args)
        {
            // Processing an online payment with a credit card
            IPaymentProcessor creditCardProcessor = new CreditCardProcessor();
            Payment onlinePayment = new OnlinePayment(creditCardProcessor);
            onlinePayment.MakePayment(150.00m);

            // Processing an in-store payment with PayPal
            IPaymentProcessor payPalProcessor = new PayPalProcessor();
            Payment inStorePayment = new InStorePayment(payPalProcessor);
            inStorePayment.MakePayment(75.00m);
        }
    }
}

// Output:
// Processing online payment...
// Credit card payment processed: $150.00
// Processing in-store payment...
// PayPal payment processed: $75.00
