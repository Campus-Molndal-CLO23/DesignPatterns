using System;
using System.Collections.Generic;

/* Gränssnitt för mediator */
public interface IAirTrafficControl
{
    void RegisterAircraft(Aircraft aircraft);
    void SendMessage(string message, Aircraft aircraft);
}

/* Konkret mediator för att hantera flygplanskommunikation */
public class AirTrafficControl : IAirTrafficControl
{
    private List<Aircraft> _aircrafts = new List<Aircraft>();

    public void RegisterAircraft(Aircraft aircraft)
    {
        _aircrafts.Add(aircraft);
    }

    public void SendMessage(string message, Aircraft aircraft)
    {
        foreach (var a in _aircrafts)
        {
            // Meddelandet ska inte skickas tillbaka till avsändaren
            if (a != aircraft)
            {
                a.Receive(message);
            }
        }
    }
}

/* Abstrakt klass för flygplan */
public abstract class Aircraft
{
    protected IAirTrafficControl _mediator;
    protected string _name;

    public Aircraft(IAirTrafficControl mediator, string name)
    {
        _mediator = mediator;
        _name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

/* Konkret klass för ett flygplan */
public class ConcreteAircraft : Aircraft
{
    public ConcreteAircraft(IAirTrafficControl mediator, string name) : base(mediator, name)
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

/* Programklass för att demonstrera flygtrafikledning med Mediator-mönstret */
class Program
{
    static void Main()
    {
        IAirTrafficControl atc = new AirTrafficControl();

        Aircraft aircraft1 = new ConcreteAircraft(atc, "Flight A123");
        Aircraft aircraft2 = new ConcreteAircraft(atc, "Flight B456");
        Aircraft aircraft3 = new ConcreteAircraft(atc, "Flight C789");

        atc.RegisterAircraft(aircraft1);
        atc.RegisterAircraft(aircraft2);
        atc.RegisterAircraft(aircraft3);

        aircraft1.Send("Requesting landing clearance.");
        aircraft2.Send("Holding at 5000 feet.");
    }
}
