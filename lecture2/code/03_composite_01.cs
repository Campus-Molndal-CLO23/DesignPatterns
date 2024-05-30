using System;
using System.Collections.Generic;

namespace CompositePatternExample
{
    // Component - defines an interface for all objects in the composition
    public interface IEmployee
    {
        void ShowDetails();
    }

    // Leaf - represents leaf objects in the composition
    public class Developer : IEmployee
    {
        private string _name;
        private long _empId;
        private string _position;

        public Developer(string name, long empId, string position)
        {
            _name = name;
            _empId = empId;
            _position = position;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Developer: {_name}, Id: {_empId}, Position: {_position}");
        }
    }

    // Leaf - represents leaf objects in the composition
    public class Manager : IEmployee
    {
        private string _name;
        private long _empId;
        private string _position;

        public Manager(string name, long empId, string position)
        {
            _name = name;
            _empId = empId;
            _position = position;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Manager: {_name}, Id: {_empId}, Position: {_position}");
        }
    }

    // Composite - represents a composite node that can have children
    public class Directory : IEmployee
    {
        private List<IEmployee> _employeeList = new List<IEmployee>();

        public void AddEmployee(IEmployee employee)
        {
            _employeeList.Add(employee);
        }

        public void RemoveEmployee(IEmployee employee)
        {
            _employeeList.Remove(employee);
        }

        public void ShowDetails()
        {
            foreach (var employee in _employeeList)
            {
                employee.ShowDetails();
            }
        }
    }

    // Client - uses the composition of employees
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev1 = new Developer("John", 100, "Senior Developer");
            Developer dev2 = new Developer("Doe", 101, "Junior Developer");
            Manager manager1 = new Manager("Anna", 200, "Manager");

            Directory engineeringDirectory = new Directory();
            engineeringDirectory.AddEmployee(dev1);
            engineeringDirectory.AddEmployee(dev2);
            
            Directory companyDirectory = new Directory();
            companyDirectory.AddEmployee(engineeringDirectory);
            companyDirectory.AddEmployee(manager1);

            companyDirectory.ShowDetails();
        }
    }
}

// Output:
// Developer: John, Id: 100, Position: Senior Developer
// Developer: Doe, Id: 101, Position: Junior Developer
// Manager: Anna, Id: 200, Position: Manager

// Förklaring:
// I detta exempel har vi tre klasser: Developer, Manager och Directory. 
// Developer och Manager är lövobjekt som representerar anställda i företaget. 
// Directory är en kompositnod som kan ha andra Directory-objekt eller lövobjekt 
// som barn. I Main-metoden skapas två Developer-objekt, ett Manager-objekt och 
// ett Directory-objekt. De två Developer-objekten läggs till i Directory-objektet. 
// Directory-objektet och Manager-objektet läggs sedan till i ett nytt Directory-objekt 
// som representerar hela företaget. När ShowDetails-metoden anropas på det sista 
// Directory-objektet skrivs detaljerna för alla anställda ut. Detta möjliggör en 
// hierarkisk struktur för att hantera anställda i företaget.