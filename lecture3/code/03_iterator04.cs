// Exempel: Iteration över en samling av produkter med .Nets inbyggda 
// IEnumerator och IEnumerable

using System;
using System.Collections;
using System.Collections.Generic;

// Klass som representerar en produkt
public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

// Konkret samling av produkter som implementerar IEnumerable
public class ProductCollection : IEnumerable<Product>
{
    private List<Product> _products = new List<Product>();

    // Lägg till en produkt till samlingen
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Returnerar en enumerator för att iterera över samlingen
    public IEnumerator<Product> GetEnumerator()
    {
        // Varför skapa en egen när vi kan använda .Nets inbyggda?
        return new ProductEnumerator(_products);
    }

    // Implementerar den icke-generiska GetEnumerator metoden
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Vi använder den generiska metoden
        return GetEnumerator();
    }
}

// Konkret enumerator för att iterera över produktsamligen
public class ProductEnumerator : IEnumerator<Product>
{
    private List<Product> _products;
    private int _position = -1;

    public ProductEnumerator(List<Product> products)
    {
        _products = products;
    }

    // Flyttar till nästa element i samlingen
    public bool MoveNext()
    {
        _position++;
        return (_position < _products.Count);
    }

    // Återställer positionen till början av samlingen
    public void Reset()
    {
        _position = -1;
    }

    // Returnerar det aktuella elementet i samlingen
    public Product Current
    {
        get
        {
            try
            {
                return _products[_position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    // Implementerar den icke-generiska Current egenskapen
    object IEnumerator.Current => Current;

    // Frigör resurser
    public void Dispose()
    {
        // Om vi hade resurser att frigöra skulle vi göra det här
    }
}

// Programklass för att demonstrera iteration över en samling av produkter
class Program
{
    static void Main()
    {
        ProductCollection products = new ProductCollection();
        products.AddProduct(new Product("Laptop", 999.99));
        products.AddProduct(new Product("Smartphone", 499.99));
        products.AddProduct(new Product("Tablet", 299.99));

        // Itererar över samlingen med inbyggd iterator
        foreach (var product in products)
        {
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
        }
    }
}
