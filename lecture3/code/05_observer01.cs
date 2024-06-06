using System;
using System.Collections.Generic;

// Gränssnitt för observatörer
public interface ISubscriber
{
    void Update(string message);
}

// Konkret observatör
public class Subscriber : ISubscriber
{
    public string Name { get; private set; }

    public Subscriber(string name)
    {
        Name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{Name} received message: {message}");
    }
}

// Gränssnitt för ämnet
public interface INewsletter
{
    void Subscribe(ISubscriber subscriber);
    void Unsubscribe(ISubscriber subscriber);
    void NotifySubscribers(string message);
}

// Konkret ämne
public class Newsletter : INewsletter
{
    private List<ISubscriber> _subscribers = new List<ISubscriber>();

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
        Console.WriteLine($"{subscriber} subscribed.");
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
        Console.WriteLine($"{subscriber} unsubscribed.");
    }

    public void NotifySubscribers(string message)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(message);
        }
    }
}

// Programklass för att demonstrera nyhetsbrevprenumeration
class Program
{
    static void Main()
    {
        Newsletter newsletter = new Newsletter();

        Subscriber alice = new Subscriber("Alice");
        Subscriber bob = new Subscriber("Bob");

        newsletter.Subscribe(alice);
        newsletter.Subscribe(bob);

        newsletter.NotifySubscribers("This is the first newsletter!");

        newsletter.Unsubscribe(bob);

        newsletter.NotifySubscribers("This is the second newsletter!");
    }
}
