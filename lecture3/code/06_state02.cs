using System;

// Gränssnitt för tillstånd
public interface IMoodState
{
    void Handle(Avatar avatar);
}

// Klass som representerar en avatar
public class Avatar
{
    private IMoodState _mood;

    public Avatar(IMoodState mood)
    {
        SetMood(mood);
    }

    public void SetMood(IMoodState mood)
    {
        _mood = mood;
        Console.WriteLine($"Mood: {_mood.GetType().Name}");
    }

    public void ChangeMood()
    {
        _mood.Handle(this);
    }
}

// Konkret tillstånd för glad humör
public class HappyState : IMoodState
{
    public void Handle(Avatar avatar)
    {
        Console.WriteLine("Avatar is happy!");
        avatar.SetMood(new SadState());
    }
}

// Konkret tillstånd för ledsen humör
public class SadState : IMoodState
{
    public void Handle(Avatar avatar)
    {
        Console.WriteLine("Avatar is sad.");
        avatar.SetMood(new AngryState());
    }
}

// Konkret tillstånd för arg humör
public class AngryState : IMoodState
{
    public void Handle(Avatar avatar)
    {
        Console.WriteLine("Avatar is angry!");
        avatar.SetMood(new HappyState());
    }
}

// Programklass för att demonstrera avatars humör med State-mönstret
class Program
{
    static void Main()
    {
        Avatar avatar = new Avatar(new HappyState());

        // Simulerar humörändringar
        avatar.ChangeMood(); // Glad -> Ledsen
        avatar.ChangeMood(); // Ledsen -> Arg
        avatar.ChangeMood(); // Arg -> Glad
        avatar.ChangeMood(); // Glad -> Ledsen
    }
}
