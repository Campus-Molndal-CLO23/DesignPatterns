---
marp: true
theme: default
class: invert
paginate: true
backgroundColor: #1E1E1E
color: #FFFFFF
css: |
  img {
    max-width: 70%;
    max-height: 70%;
    height: auto;
    width: auto;
  }
---

# Mediator Design Pattern

---

## Introduktion

Mediator-mönstret används för att minska kopplingarna mellan klasser genom att introducera en mediator-objekt som hanterar kommunikationen mellan dem. Detta hjälper till att minska beroenden och ökar flexibiliteten.

---

## Användningsområden

- När du vill minska antalet beroenden mellan klasser som kommunicerar med varandra.
- När du vill centralisera kontrollen över kommunikationen mellan flera objekt.
- När flera objekt har komplexa kommunikationsmönster.

---

## Struktur

![h:550](04_mediator.png)

---

## Komponenter

- **Mediator**: Definierar ett gränssnitt för kommunikation mellan kollegor.
- **ConcreteMediator**: Implementerar `Mediator`-gränssnittet och koordinerar kommunikationen mellan konkreta kollegor.
- **Colleague**: Definierar ett gränssnitt för kollegor som kommunicerar via mediatoren.
- **ConcreteColleague**: Implementerar `Colleague`-gränssnittet och kommunicerar med andra kollegor via mediatoren.

---

## Exempel: Chat Room

Vi ska skapa ett exempel där vi använder Mediator-mönstret för att implementera en chattrum där flera användare kan kommunicera med varandra.

---

## Mediator Interface

Först definierar vi ett gränssnitt för mediatoren:

```csharp
public interface IChatRoomMediator
{
    void ShowMessage(User user, string message);
}
```

---

## ConcreteMediator

Vi skapar en konkret mediator som hanterar kommunikationen mellan användarna:

```csharp
public class ChatRoom : IChatRoomMediator
{
    public void ShowMessage(User user, string message)
    {
        Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} [{user.Name}]: {message}");
    }
}
```

---

## Colleague Class

Vi skapar en kollegaklass för användare som kommunicerar via mediatoren:

```csharp
public class User
{
    private IChatRoomMediator _chatRoom;
    public string Name { get; set; }

    public User(string name, IChatRoomMediator chatRoom)
    {
        Name = name;
        _chatRoom = chatRoom;
    }

    public void Send(string message)
    {
        _chatRoom.ShowMessage(this, message);
    }
}
```

---

## Användningsexempel

Nu ska vi sätta ihop allt och se hur det fungerar:

```csharp
class Program
{
    static void Main(string[] args)
    {
        IChatRoomMediator chatRoom = new ChatRoom();

        User user1 = new User("Alice", chatRoom);
        User user2 = new User("Bob", chatRoom);

        user1.Send("Hi Bob!");
        user2.Send("Hello Alice!");
    }
}
```

---

## Förklaringar till koden

1. **IChatRoomMediator (Mediator)**: Gränssnittet som definierar metoden för att visa meddelanden.
2. **ChatRoom (ConcreteMediator)**: Implementerar `IChatRoomMediator` och hanterar kommunikationen mellan användarna.
3. **User (Colleague)**: Klasser som representerar användarna och som kommunicerar via mediatoren.

---

## Fördelar med Mediator Pattern

- **Minskar beroenden**: Minskar antalet beroenden mellan klasser genom att introducera en mediator.
- **Centraliserad kontroll**: Centraliserar kontrollen över kommunikationen mellan flera objekt.
- **Ökad flexibilitet**: Gör det lättare att ändra kommunikationen mellan klasser utan att påverka de individuella klasserna.

---

## Jämförelse med Direkt Kommunikation

Låt oss jämföra Mediator-mönstret med direkt kommunikation mellan objekt.

### Direkt Kommunikation

```csharp
class User
{
    public string Name { get; set; }

    public void SendMessage(User toUser, string message)
    {
        Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} [{Name} to {toUser.Name}]: {message}");
    }
}
```

---

## Problem med Direkt Kommunikation

- **Hård koppling**: Användare måste känna till varandra och hur man kommunicerar direkt.
- **Komplexitet**: När antalet användare ökar, ökar komplexiteten och underhållet av kommunikationen exponentiellt.

---

## Mediator som Central Kommunikator

Genom att införa en mediator kan vi minska komplexiteten och underlätta kommunikationen.

### Mediator

```csharp
public interface IChatRoomMediator
{
    void ShowMessage(User user, string message);
}

public class ChatRoom : IChatRoomMediator
{
    public void ShowMessage(User user, string message)
    {
        Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")} [{user.Name}]: {message}");
    }
}
```

---

## Användningsexempel med Mediator

```csharp
class Program
{
    static void Main(string[] args)
    {
        IChatRoomMediator chatRoom = new ChatRoom();

        User user1 = new User("Alice", chatRoom);
        User user2 = new User("Bob", chatRoom);

        user1.Send("Hi Bob!");
        user2.Send("Hello Alice!");
    }
}
```

---

## Sammanfattning

Mediator-mönstret introducerar ett mediator-objekt som hanterar kommunikationen mellan flera klasser, vilket minskar beroenden och ökar flexibiliteten. Genom att centralisera kontrollen över kommunikationen kan vi enklare underhålla och ändra systemet.
