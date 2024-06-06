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

// Gränssnitt för iterator
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

// Gränssnitt för samling
public interface IProductCollection
{
    IIterator<Product> CreateIterator();
}

// Konkret iterator för att iterera över en samling av produkter
public class ProductIterator : IIterator<Product>
{
    private List<Product> _products;
    private int _position = 0;

    public ProductIterator(List<Product> products)
    {
        _products = products;
    }

    public bool HasNext()
    {
        return _position < _products.Count;
    }

    public Product Next()
    {
        return _products[_position++];
    }
}

// Konkret samling av produkter
public class ProductCollection : IProductCollection
{
    private List<Product> _products = new List<Product>();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public IIterator<Product> CreateIterator()
    {
        return new ProductIterator(_products);
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

        IIterator<Product> iterator = products.CreateIterator();

        while (iterator.HasNext())
        {
            Product product = iterator.Next();
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
        }
    }
}

// Output:
// Product: Laptop, Price: 999.99
// Product: Smartphone, Price: 499.99
// Product: Tablet, Price: 299.99
