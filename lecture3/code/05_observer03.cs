using System;
using System.Collections.Generic;

// Gränssnitt för observatörer
public interface IInventoryObserver
{
    void Update(string product, int quantity);
}

// Konkret observatör för att visa lagernivåer
public class InventoryDisplay : IInventoryObserver
{
    private string _name;

    public InventoryDisplay(string name)
    {
        _name = name;
    }

    public void Update(string product, int quantity)
    {
        Console.WriteLine($"{_name} - Product: {product}, Quantity: {quantity}");
    }
}

// Gränssnitt för ämnet
public interface IInventorySystem
{
    void RegisterObserver(IInventoryObserver observer);
    void RemoveObserver(IInventoryObserver observer);
    void NotifyObservers(string product);
}

// Konkret ämne
public class InventorySystem : IInventorySystem
{
    private List<IInventoryObserver> _observers = new List<IInventoryObserver>();
    private Dictionary<string, int> _inventory = new Dictionary<string, int>();

    public void RegisterObserver(IInventoryObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IInventoryObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(string product)
    {
        if (_inventory.ContainsKey(product))
        {
            int quantity = _inventory[product];
            foreach (var observer in _observers)
            {
                observer.Update(product, quantity);
            }
        }
    }

    // Metoder för att hantera lagernivåer
    public void UpdateInventory(string product, int quantity)
    {
        if (_inventory.ContainsKey(product))
        {
            _inventory[product] = quantity;
        }
        else
        {
            _inventory.Add(product, quantity);
        }
        NotifyObservers(product);
    }
}

// Programklass för att demonstrera lagerhanteringssystemet
class Program
{
    static void Main()
    {
        InventorySystem inventorySystem = new InventorySystem();

        InventoryDisplay warehouseDisplay = new InventoryDisplay("Warehouse");
        InventoryDisplay storeDisplay = new InventoryDisplay("Store");

        inventorySystem.RegisterObserver(warehouseDisplay);
        inventorySystem.RegisterObserver(storeDisplay);

        inventorySystem.UpdateInventory("Laptop", 50);
        inventorySystem.UpdateInventory("Smartphone", 200);

        inventorySystem.RemoveObserver(storeDisplay);

        inventorySystem.UpdateInventory("Tablet", 30);
    }
}
