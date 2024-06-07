import java.util.ArrayList;
import java.util.List;

/* Interface for mediator */
public interface ChatMediator {
    void sendMessage(String message, User user);
    void addUser(User user);
}

/* Concrete mediator to handle messages */
public class ChatMediatorImpl implements ChatMediator {
    private List<User> users = new ArrayList<>();

    @Override
    public void addUser(User user) {
        users.add(user);
    }

    @Override
    public void sendMessage(String message, User user) {
        for (User u : users) {
            // Do not send the message back to the sender
            if (u != user) {
                u.receive(message);
            }
        }
    }
}

/* Abstract class for user */
public abstract class User {
    protected ChatMediator mediator;
    protected String name;

    public User(ChatMediator mediator, String name) {
        this.mediator = mediator;
        this.name = name;
    }

    public abstract void send(String message);
    public abstract void receive(String message);
}
/* Concrete class for a user */
public class ConcreteUser extends User {

    public ConcreteUser(ChatMediator mediator, String name) {
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
public class Main {
    public static void main(String[] args) {
        ChatMediator mediator = new ChatMediatorImpl();

        User user1 = new ConcreteUser(mediator, "Alice");
        User user2 = new ConcreteUser(mediator, "Bob");
        User user3 = new ConcreteUser(mediator, "Charlie");

        mediator.addUser(user1);
        mediator.addUser(user2);
        mediator.addUser(user3);

        user1.send("Hello, everyone!");
        user2.send("Hi Alice!");
    }
}

/*
Explanation
Interface for Mediator:
ChatMediator defines methods for sending messages and adding users.

Concrete Mediator:
ChatMediatorImpl implements the ChatMediator interface.
It maintains a list of users and handles message sending by iterating over the list and calling the receive method on all users except the sender.

Abstract User Class:
User defines the common structure for users, including the mediator and the user's name.
It declares abstract methods send and receive.

Concrete User Class:
ConcreteUser extends User and provides implementations for the send and receive methods.
When a message is sent, it is printed to the console, and the mediator's sendMessage method is called.

Main Class:
Demonstrates the chat application using the Mediator pattern.
Creates instances of ChatMediator and ConcreteUser, adds users to the mediator, and sends messages between users.
*/
