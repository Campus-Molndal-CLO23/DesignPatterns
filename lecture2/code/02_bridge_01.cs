using System;

namespace BridgePatternExample
{
    // Abstraction - defines the interface for the control part of the two class hierarchies
    public abstract class RemoteControl
    {
        protected IDevice _device;

        // Constructor takes an instance of IDevice
        protected RemoteControl(IDevice device)
        {
            _device = device;
        }

        public abstract void TogglePower();
        public abstract void VolumeUp();
        public abstract void VolumeDown();
    }

    // Refined Abstraction - extends the interface defined by Abstraction
    public class AdvancedRemoteControl : RemoteControl
    {
        // Constructor takes an instance of IDevice
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public override void TogglePower()
        {
            _device.Power = !_device.Power;
            Console.WriteLine($"Power status: {(_device.Power ? "On" : "Off")}");
        }

        public override void VolumeUp()
        {
            _device.Volume++;
            Console.WriteLine($"Volume level: {_device.Volume}");
        }

        public override void VolumeDown()
        {
            _device.Volume--;
            Console.WriteLine($"Volume level: {_device.Volume}");
        }

        public void Mute()
        {
            _device.Volume = 0;
            Console.WriteLine("Muted");
        }
    }

    // Implementor - defines the interface for the implementation class hierarchy
    public interface IDevice
    {
        bool Power { get; set; }
        int Volume { get; set; }
    }

    // Concrete Implementor - implements the Implementor interface
    public class TV : IDevice
    {
        public bool Power { get; set; }
        public int Volume { get; set; }

        public TV()
        {
            Power = false;
            Volume = 10;
        }
    }

    // Concrete Implementor - implements the Implementor interface
    public class Radio : IDevice
    {
        public bool Power { get; set; }
        public int Volume { get; set; }

        public Radio()
        {
            Power = false;
            Volume = 5;
        }
    }

    // Client - uses the Abstraction interface
    class Program
    {
        static void Main(string[] args)
        {
            // Control a TV using the remote control
            IDevice tv = new TV();
            RemoteControl tvRemote = new AdvancedRemoteControl(tv);
            tvRemote.TogglePower();
            tvRemote.VolumeUp();
            tvRemote.VolumeDown();
            ((AdvancedRemoteControl)tvRemote).Mute();

            // Control a Radio using the remote control
            IDevice radio = new Radio();
            RemoteControl radioRemote = new AdvancedRemoteControl(radio);
            radioRemote.TogglePower();
            radioRemote.VolumeUp();
            radioRemote.VolumeDown();
            ((AdvancedRemoteControl)radioRemote).Mute();
        }
    }
}

// Output:
// Power status: On
// Volume level: 11
// Volume level: 10
// Muted
// Power status: On
// Volume level: 6
// Volume level: 5
// Muted

// Förklaring:
// I detta exempel har vi två hierarkier: 
// en för fjärrkontrollen och en för enheterna som fjärrkontrollen kontrollerar.
// Abstraction definierar gränssnittet för kontrollen av enheterna.
// RemoteControl är en abstrakt klass som innehåller en instans av IDevice.
// AdvancedRemoteControl är en raffinerad abstraktion som utökar gränssnittet 
// definierat av Abstraction.
// IDevice definierar gränssnittet för enheterna som fjärrkontrollen kontrollerar.
// TV och Radio är konkreta implementeringar av IDevice.
// I huvudprogrammet skapas en instans av TV och en instans av 
// AdvancedRemoteControl som tar TV-instansen som argument.
// Fjärrkontrollen används för att slå på och av TV:n, öka och minska volymen,
// och sätta volymen till 0 (mute).
// Sedan skapas en instans av Radio och en instans av AdvancedRemoteControl som
// tar Radio-instansen som argument. Fjärrkontrollen används för att slå på och
// av radion, öka och minska volymen, och sätta volymen till 0 (mute).
// Observera att Mute funktionen inte finns i Abstraction-gränssnittet, utan
// endast i AdvancedRemoteControl-gränssnittet. Detta är en fördel med Bridge-mönstret,
// eftersom det möjligör att lägga till nya funktioner i den raffinerade abstraktionen
// utan att ändra i abstraktionen.
// Bridge-mönstret används för att separera abstraktionen från implementeringen.
// Det kan vara användbart när du vill kunna ändra eller byta ut implementeringen
// utan att behöva ändra i abstraktionen. Det kan också vara användbart när du vill
// lägga till nya funktioner i den raffinerade abstraktionen utan att ändra i abstraktionen.
