using System;

// Gränssnitt för kommandon
public interface ICommand
{
    void Execute();
    void Undo();
}

// Mottagarklassen som representerar en lampa
public class Light
{
    public void On()
    {
        Console.WriteLine("Light is On");
    }

    public void Off()
    {
        Console.WriteLine("Light is Off");
    }
}

// Konkret kommando för att slå på lampan
public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}

// Konkret kommando för att slå av lampan
public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }
}

// Invoker-klass som representerar fjärrkontrollen
public class RemoteControl
{
    private ICommand _onCommand;
    private ICommand _offCommand;

    public void SetCommands(ICommand onCommand, ICommand offCommand)
    {
        _onCommand = onCommand;
        _offCommand = offCommand;
    }

    public void PressOnButton()
    {
        _onCommand.Execute();
    }

    public void PressOffButton()
    {
        _offCommand.Execute();
    }

    public void PressUndoButton(ICommand command)
    {
        command.Undo();
    }
}

// Programklass för att demonstrera fjärrkontrollen
class Program
{
    static void Main()
    {
        Light livingRoomLight = new Light();
        ICommand lightOn = new LightOnCommand(livingRoomLight);
        ICommand lightOff = new LightOffCommand(livingRoomLight);

        RemoteControl remote = new RemoteControl();
        remote.SetCommands(lightOn, lightOff);

        // Slå på lampan och visa resultatet
        remote.PressOnButton();

        // Slå av lampan och visa resultatet
        remote.PressOffButton();

        // Ångra 
        remote.PressUndoButton(lightOn);
    }
}
