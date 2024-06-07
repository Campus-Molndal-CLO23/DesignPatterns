import java.util.ArrayList;
import java.util.List;

/* Gränssnitt för mediator */
interface IAirTrafficControl {
    void registerAircraft(Aircraft aircraft);
    void sendMessage(String message, Aircraft aircraft);
}

/* Konkret mediator för att hantera flygplanskommunikation */
class AirTrafficControl implements IAirTrafficControl {
    private List<Aircraft> aircrafts = new ArrayList<>();

    @Override
    public void registerAircraft(Aircraft aircraft) {
        aircrafts.add(aircraft);
    }

    @Override
    public void sendMessage(String message, Aircraft aircraft) {
        for (Aircraft a : aircrafts) {
            // Meddelandet ska inte skickas tillbaka till avsändaren
            if (a != aircraft) {
                a.receive(message);
            }
        }
    }
}

/* Abstrakt klass för flygplan */
abstract class Aircraft {
    protected IAirTrafficControl mediator;
    protected String name;

    public Aircraft(IAirTrafficControl mediator, String name) {
        this.mediator = mediator;
        this.name = name;
    }

    public abstract void send(String message);
    public abstract void receive(String message);
}

/* Konkret klass för ett flygplan */
class ConcreteAircraft extends Aircraft {

    public ConcreteAircraft(IAirTrafficControl mediator, String name) {
        super(mediator, name);
    }

    @Override
    public void send(String message) {
        System.out.println(name + " sends: " + message);
        mediator.sendMessage(message, this);
    }

    @Override
    public void receive(String message) {
        System.out.println(name + " receives: " + message);
    }
}

/* Programklass för att demonstrera flygtrafikledning med Mediator-mönstret */
public class Main {
    public static void main(String[] args) {
        IAirTrafficControl atc = new AirTrafficControl();

        Aircraft aircraft1 = new ConcreteAircraft(atc, "Flight A123");
        Aircraft aircraft2 = new ConcreteAircraft(atc, "Flight B456");
        Aircraft aircraft3 = new ConcreteAircraft(atc, "Flight C789");

        atc.registerAircraft(aircraft1);
        atc.registerAircraft(aircraft2);
        atc.registerAircraft(aircraft3);

        aircraft1.send("Requesting landing clearance.");
        aircraft2.send("Holding at 5000 feet.");
    }
}

/*
Förklaring
Gränssnitt för Mediator:

IAirTrafficControl definierar metoder för att registrera flygplan och skicka meddelanden.
Konkret Mediator:

AirTrafficControl implementerar IAirTrafficControl-gränssnittet.
Den hanterar en lista av registrerade flygplan och skickar meddelanden till alla flygplan förutom avsändaren.
Abstrakt Klass för Flygplan:

Aircraft definierar den gemensamma strukturen för flygplan, inklusive mediatorn och flygplanets namn.
Den deklarerar abstrakta metoder send och receive.
Konkret Klass för Ett Flygplan:

ConcreteAircraft utökar Aircraft och implementerar send och receive-metoderna.
När ett meddelande skickas, skrivs det ut på konsolen och mediatorns sendMessage-metod anropas.
Programklass:

Demonstrerar flygtrafikledning med hjälp av Mediator-mönstret.
Skapar instanser av AirTrafficControl och ConcreteAircraft, registrerar flygplanen hos mediatorn och skickar meddelanden mellan flygplanen.
*/