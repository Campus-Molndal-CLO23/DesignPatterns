/*
PaymentProcessor

ProcessPayment: Mallmetoden som utför stegen för betalningsbearbetning.
Authenticate: Abstrakt metod för att autentisera betalningen.
ValidatePaymentDetails: Abstrakt metod för att validera betalningsdetaljer.
ProcessTransaction: Abstrakt metod för att bearbeta transaktionen.
SendReceipt: Abstrakt metod för att skicka kvitto.
*/

using System;

/* Abstrakt klass som definierar mallmetoden för betalningsbearbetning */
public abstract class PaymentProcessor
{
    public void ProcessPayment()
    {
        Authenticate();
        ValidatePaymentDetails();
        ProcessTransaction();
        SendReceipt();
    }

    protected abstract void Authenticate();
    protected abstract void ValidatePaymentDetails();
    protected abstract void ProcessTransaction();
    protected abstract void SendReceipt();
}

/* Konkret klass som implementerar bearbetning av kreditkortsbetalningar */
public class CreditCardPaymentProcessor : PaymentProcessor
{
    protected override void Authenticate()
    {
        Console.WriteLine("Authenticating credit card payment.");
    }

    protected override void ValidatePaymentDetails()
    {
        Console.WriteLine("Validating credit card details.");
    }

    protected override void ProcessTransaction()
    {
        Console.WriteLine("Processing credit card transaction.");
    }

    protected override void SendReceipt()
    {
        Console.WriteLine("Sending receipt for credit card payment.");
    }
}

/* Konkret klass som implementerar bearbetning av PayPal-betalningar */
public class PayPalPaymentProcessor : PaymentProcessor
{
    protected override void Authenticate()
    {
        Console.WriteLine("Authenticating PayPal payment.");
    }

    protected override void ValidatePaymentDetails()
    {
        Console.WriteLine("Validating PayPal account details.");
    }

    protected override void ProcessTransaction()
    {
        Console.WriteLine("Processing PayPal transaction.");
    }

    protected override void SendReceipt()
    {
        Console.WriteLine("Sending receipt for PayPal payment.");
    }
}

/* Programklass för att demonstrera betalningsbearbetning med Template Method-mönstret */
class Program
{
    static void Main()
    {
        PaymentProcessor creditCardProcessor = new CreditCardPaymentProcessor();
        creditCardProcessor.ProcessPayment();

        PaymentProcessor payPalProcessor = new PayPalPaymentProcessor();
        payPalProcessor.ProcessPayment();
    }
}
