import java.util.*;

/* Gränssnitt för mediator */
interface IFormMediator {
    void notify(Object sender, String eventDetails);
}

/* Konkret mediator för att hantera formulärfältsinteraktion */
class FormMediator implements IFormMediator {
    public TextBox nameTextBox;
    public TextBox emailTextBox;
    public Button submitButton;

    @Override
    public void notify(Object sender, String eventDetails) {
        if (eventDetails.equals("NameChanged")) {
            System.out.println("Mediator reacts on NameChanged and triggers following operations:");
            emailTextBox.validate();
            submitButton.checkState();
        }
        if (eventDetails.equals("EmailChanged")) {
            System.out.println("Mediator reacts on EmailChanged and triggers following operations:");
            nameTextBox.validate();
            submitButton.checkState();
        }
    }
}

/* Klass för formulärfält */
class TextBox {
    private IFormMediator mediator;
    private String text;

    public TextBox(IFormMediator mediator) {
        this.mediator = mediator;
    }

    public void changeText(String text) {
        this.text = text;
        System.out.println("TextBox changed: " + text);
        mediator.notify(this, "NameChanged");
    }

    public void validate() {
        System.out.println("Validating TextBox.");
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }
}

/* Klass för knapp */
class Button {
    private IFormMediator mediator;

    public Button(IFormMediator mediator) {
        this.mediator = mediator;
    }

    public void click() {
        System.out.println("Button clicked.");
        mediator.notify(this, "SubmitClicked");
    }

    public void checkState() {
        System.out.println("Checking button state.");
    }
}

/* Programklass för att demonstrera formulärhantering med Mediator-mönstret */
public class Main {
    public static void main(String[] args) {
        FormMediator mediator = new FormMediator();

        TextBox nameTextBox = new TextBox(mediator);
        TextBox emailTextBox = new TextBox(mediator);
        Button submitButton = new Button(mediator);

        mediator.nameTextBox = nameTextBox;
        mediator.emailTextBox = emailTextBox;
        mediator.submitButton = submitButton;

        nameTextBox.changeText("John Doe");
        emailTextBox.changeText("john@example.com");
        submitButton.click();
    }
}

/*
Förklaring
Gränssnitt för Mediator:
IFormMediator definierar metoden notify för att meddela händelser.

Konkret Mediator:
FormMediator implementerar IFormMediator-gränssnittet.
Den hanterar interaktioner mellan formulärets fält och knappar.

Klass för Formulärfält (TextBox):
TextBox har en referens till IFormMediator och en metod för att ändra text (changeText).
När texten ändras, meddelar den mediatorn om ändringen.
Metoden validate används för att validera texten.

Klass för Knapp (Button):
Button har en referens till IFormMediator och en metod för att hantera klickhändelser (click).
Metoden checkState används för att kontrollera knappens tillstånd.

Programklass:
Demonstrerar formulärhantering med Mediator-mönstret.
Skapar instanser av FormMediator, TextBox, och Button.
Registrerar komponenterna hos mediatorn och simulerar användarinteraktioner.
*/