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
