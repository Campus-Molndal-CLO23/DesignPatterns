using System;
using System.Collections;
using System.Collections.Generic;

// Klass som representerar en anställd
public class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }
}

// Gränssnitt för iterator
public interface IIterator
{
    bool HasNext();
    Employee Next();
}

// Gränssnitt för samling
public interface IEmployeeCollection
{
    IIterator CreateIterator();
}

// Konkret iterator för att iterera över en lista med anställda
public class EmployeeIterator : IIterator
{
    private List<Employee> _employees;
    private int _position = 0;

    public EmployeeIterator(List<Employee> employees)
    {
        _employees = employees;
    }

    public bool HasNext()
    {
        return _position < _employees.Count;
    }

    public Employee Next()
    {
        return _employees[_position++];
    }
}

// Konkret samling av anställda
public class EmployeeCollection : IEmployeeCollection
{
    private List<Employee> _employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public IIterator CreateIterator()
    {
        return new EmployeeIterator(_employees);
    }
}

// Programklass för att demonstrera iteration över en lista med anställda
class Program
{
    static void Main()
    {
        EmployeeCollection employees = new EmployeeCollection();
        employees.AddEmployee(new Employee("Alice"));
        employees.AddEmployee(new Employee("Bob"));
        employees.AddEmployee(new Employee("Charlie"));

        IIterator iterator = employees.CreateIterator();

        while (iterator.HasNext())
        {
            Employee employee = iterator.Next();
            Console.WriteLine("Employee: " + employee.Name);
        }
    }
}
