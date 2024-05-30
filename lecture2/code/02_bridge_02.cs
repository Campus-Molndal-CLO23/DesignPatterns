using System;

namespace BridgePatternExample2
{
    // Abstraction - defines the interface for the control part of the two class hierarchies
    public abstract class Notification
    {
        protected IMessageSender _messageSender;

        // Constructor takes an instance of IMessageSender
        protected Notification(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public abstract void Send(string message);
    }

    // Refined Abstraction - extends the interface defined by Abstraction
    public class UrgentNotification : Notification
    {
        // Constructor takes an instance of IMessageSender
        public UrgentNotification(IMessageSender messageSender) : base(messageSender) { }

        public override void Send(string message)
        {
            Console.WriteLine("Sending urgent notification...");
            _messageSender.SendMessage(message);
        }
    }

    // Refined Abstraction - another type of notification
    public class RegularNotification : Notification
    {
        // Constructor takes an instance of IMessageSender
        public RegularNotification(IMessageSender messageSender) : base(messageSender) { }

        public override void Send(string message)
        {
            Console.WriteLine("Sending regular notification...");
            _messageSender.SendMessage(message);
        }
    }

    // Implementor - defines the interface for the implementation class hierarchy
    public interface IMessageSender
    {
        void SendMessage(string message);
    }

    // Concrete Implementor - implements the Implementor interface for SMS
    public class SmsSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    // Concrete Implementor - implements the Implementor interface for Email
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    // Client - uses the Abstraction interface
    class Program
    {
        static void Main(string[] args)
        {
            // Sending urgent notification via SMS
            IMessageSender smsSender = new SmsSender();
            Notification urgentNotification = new UrgentNotification(smsSender);
            urgentNotification.Send("This is an urgent message!");

            // Sending regular notification via Email
            IMessageSender emailSender = new EmailSender();
            Notification regularNotification = new RegularNotification(emailSender);
            regularNotification.Send("This is a regular message.");
        }
    }
}

// Output:
// Sending urgent notification...
// SMS sent: This is an urgent message!
// Sending regular notification...
// Email sent: This is a regular message.

// Förklaring:
// Bridge Pattern används för att separera abstraktionen från dess implementering 
// så att de kan ändras oberoende av varandra. I det här exemplet har vi två hierarkier,
// en för meddelanden och en för meddelandesändare. Abstraktionen är Notification-klassen,
// som har en IMessageSender-instans. IMessageSender är implementeringsgränssnittet för
// meddelandesändare. UrgentNotification och RegularNotification är raffinerade abstraktioner
// som skickar meddelanden via IMessageSender-instansen. SmsSender och EmailSender är konkreta
// implementeringar av IMessageSender som skickar meddelanden via SMS respektive e-post.
// I huvudprogrammet skapas en instans av SmsSender och en instans av UrgentNotification
// som tar SmsSender-instansen som argument. En brådskande notifikation skickas via SMS.
// En instans av EmailSender och en instans av RegularNotification skapas och en vanlig notifikation
// skickas via e-post.
// Bridge-mönstret används för att separera abstraktionen från implementeringen.
// Detta möjliggör att de kan ändras oberoende av varandra.
// I det här fallet kan vi enkelt byta ut meddelandesändare utan att ändra i Notification-klassen.
