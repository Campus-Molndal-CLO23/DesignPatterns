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
