/*
Förklaringar till koden
IGameObjectVisitor: Gränssnitt för besökare som definierar metoder för att besöka olika typer av spelobjekt.
IGameObject: Gränssnitt för element som kan acceptera en besökare.
Player: Konkret element för spelare.
Enemy: Konkret element för fiender.
Item: Konkret element för föremål.
GameObjectRenderVisitor: Konkret besökare som hanterar och renderar spelobjekt.
*/

using System;

/* Gränssnitt för besökare */
public interface IGameObjectVisitor
{
    void Visit(Player player);
    void Visit(Enemy enemy);
    void Visit(Item item);
}

/* Gränssnitt för element som kan acceptera en besökare */
public interface IGameObject
{
    void Accept(IGameObjectVisitor visitor);
}

/* Konkret element för spelare */
public class Player : IGameObject
{
    public string Name { get; set; }

    public Player(string name)
    {
        Name = name;
    }

    public void Accept(IGameObjectVisitor visitor)
    {
        visitor.Visit(this);
    }
}

/* Konkret element för fiender */
public class Enemy : IGameObject
{
    public string Type { get; set; }

    public Enemy(string type)
    {
        Type = type;
    }

    public void Accept(IGameObjectVisitor visitor)
    {
        visitor.Visit(this);
    }
}

/* Konkret element för föremål */
public class Item : IGameObject
{
    public string ItemType { get; set; }

    public Item(string itemType)
    {
        ItemType = itemType;
    }

    public void Accept(IGameObjectVisitor visitor)
    {
        visitor.Visit(this);
    }
}

/* Konkret besökare som hanterar spelobjekt */
public class GameObjectRenderVisitor : IGameObjectVisitor
{
    public void Visit(Player player)
    {
        Console.WriteLine($"Rendering Player: {player.Name}");
    }

    public void Visit(Enemy enemy)
    {
        Console.WriteLine($"Rendering Enemy: {enemy.Type}");
    }

    public void Visit(Item item)
    {
        Console.WriteLine($"Rendering Item: {item.ItemType}");
    }
}

/* Programklass för att demonstrera spel med Visitor-mönstret */
class Program
{
    static void Main()
    {
        IGameObject player = new Player("Hero");
        IGameObject enemy = new Enemy("Orc");
        IGameObject item = new Item("Sword");

        IGameObjectVisitor renderer = new GameObjectRenderVisitor();

        player.Accept(renderer);
        enemy.Accept(renderer);
        item.Accept(renderer);
    }
}
