using System;

/* Gränssnitt för mediator */
public interface IFormMediator
{
    void Notify(object sender, string eventDetails);
}

/* Konkret mediator för att hantera formulärfältsinteraktion */
public class FormMediator : IFormMediator
{
    public TextBox NameTextBox { get; set; }
    public TextBox EmailTextBox { get; set; }
    public Button SubmitButton { get; set; }

    public void Notify(object sender, string eventDetails)
    {
        if (eventDetails == "NameChanged")
        {
            Console.WriteLine("Mediator reacts on NameChanged and triggers following operations:");
            EmailTextBox.Validate();
            SubmitButton.CheckState();
        }
        if (eventDetails == "EmailChanged")
        {
            Console.WriteLine("Mediator reacts on EmailChanged and triggers following operations:");
            NameTextBox.Validate();
            SubmitButton.CheckState();
        }
    }
}

/* Klass för formulärfält */
public class TextBox
{
    private IFormMediator _mediator;

    public string Text { get; set; }

    public TextBox(IFormMediator mediator)
    {
        _mediator = mediator;
    }

    public void ChangeText(string text)
    {
        Text = text;
        Console.WriteLine($"TextBox changed: {text}");
        _mediator.Notify(this, "NameChanged");
    }

    public void Validate()
    {
        Console.WriteLine("Validating TextBox.");
    }
}

/* Klass för knapp */
public class Button
{
    private IFormMediator _mediator;

    public Button(IFormMediator mediator)
    {
        _mediator = mediator;
    }

    public void Click()
    {
        Console.WriteLine("Button clicked.");
        _mediator.Notify(this, "SubmitClicked");
    }

    public void CheckState()
    {
        Console.WriteLine("Checking button state.");
    }
}

/* Programklass för att demonstrera formulärhantering med Mediator-mönstret */
class Program
{
    static void Main()
    {
        FormMediator mediator = new FormMediator();

        TextBox nameTextBox = new TextBox(mediator);
        TextBox emailTextBox = new TextBox(mediator);
        Button submitButton = new Button(mediator);

        mediator.NameTextBox = nameTextBox;
        mediator.EmailTextBox = emailTextBox;
        mediator.SubmitButton = submitButton;

        nameTextBox.ChangeText("John Doe");
        emailTextBox.ChangeText("john@example.com");
        submitButton.Click();
    }
}
