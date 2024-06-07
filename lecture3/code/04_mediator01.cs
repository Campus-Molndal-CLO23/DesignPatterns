using System;
using System.Collections.Generic;

/* Gränssnitt för mediator */
public interface IChatMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}

/* Konkret mediator för att hantera meddelanden */
public class ChatMediator : IChatMediator
{
    private List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in _users)
        {
            // Meddelandet ska inte skickas tillbaka till avsändaren
            if (u != user)
            {
                u.Receive(message);
            }
        }
    }
}

/* Abstrakt klass för användare */
public abstract class User
{
    protected IChatMediator _mediator;
    protected string _name;

    public User(IChatMediator mediator, string name)
    {
        _mediator = mediator;
        _name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

/* Konkret klass för en användare */
public class ConcreteUser : User
{
    public ConcreteUser(IChatMediator mediator, string name) : base(mediator, name)
    {
    }

    public override void Send(string message)
    {
        Console.WriteLine($"{_name} sends: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{_name} receives: {message}");
    }
}

/* Programklass för att demonstrera chattapplikation med Mediator-mönstret */
class Program
{
    static void Main()
    {
        IChatMediator mediator = new ChatMediator();

        User user1 = new ConcreteUser(mediator, "Alice");
        User user2 = new ConcreteUser(mediator, "Bob");
        User user3 = new ConcreteUser(mediator, "Charlie");

        mediator.AddUser(user1);
        mediator.AddUser(user2);
        mediator.AddUser(user3);

        user1.Send("Hello, everyone!");
        user2.Send("Hi Alice!");
    }
}
