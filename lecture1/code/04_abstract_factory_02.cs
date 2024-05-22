using System;

namespace AbstractFactoryExample
{
    // Abstrakt basklass för alla personer
    public abstract class Person
    {
        public abstract string Name { get; }
        public abstract string Role { get; }
    }

    // User klass med specifika egenskaper
    public class User : Person
    {
        public override string Name { get; }
        public override string Role => "User";
        public string Email { get; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }

    // Customer klass med specifika egenskaper
    public class Customer : Person
    {
        public override string Name { get; }
        public override string Role => "Customer";
        public string CustomerId { get; }

        public Customer(string name, string customerId)
        {
            Name = name;
            CustomerId = customerId;
        }
    }

    // Consultant klass med specifika egenskaper
    public class Consultant : Person
    {
        public override string Name { get; }
        public override string Role => "Consultant";
        public string Specialty { get; }

        public Consultant(string name, string specialty)
        {
            Name = name;
            Specialty = specialty;
        }
    }

    // DirtyCopBribes klass med specifika egenskaper
    public class DirtyCopBribes : Person
    {
        public override string Name { get; }
        public override string Role => "DirtyCopBribes";
        public decimal BribeAmount { get; }

        public DirtyCopBribes(string name, decimal bribeAmount)
        {
            Name = name;
            BribeAmount = bribeAmount;
        }
    }

    // Lawyer klass med specifika egenskaper
    public class Lawyer : Person
    {
        public override string Name { get; }
        public override string Role => "Lawyer";
        public string LawFirm { get; }

        public Lawyer(string name, string lawFirm)
        {
            Name = name;
            LawFirm = lawFirm;
        }
    }

    // Hitman klass med specifika egenskaper
    public class Hitman : Person
    {
        public override string Name { get; }
        public override string Role => "Hitman";
        public int SuccessfulHits { get; }

        public Hitman(string name, int successfulHits)
        {
            Name = name;
            SuccessfulHits = successfulHits;
        }
    }

    // Abstrakt fabriksklass
    public abstract class PersonFactory
    {
        public abstract Person CreatePerson(string name, string specificProperty);
    }

    // Fabriksklass för att skapa User
    public class UserFactory : PersonFactory
    {
        public override Person CreatePerson(string name, string email)
        {
            return new User(name, email);
        }
    }

    // Fabriksklass för att skapa Customer
    public class CustomerFactory : PersonFactory
    {
        public override Person CreatePerson(string name, string customerId)
        {
            return new Customer(name, customerId);
        }
    }

    // Fabriksklass för att skapa Consultant
    public class ConsultantFactory : PersonFactory
    {
        public override Person CreatePerson(string name, string specialty)
        {
            return new Consultant(name, specialty);
        }
    }

    // Fabriksklass för att skapa DirtyCopBribes
    public class DirtyCopBribesFactory : PersonFactory
    {
        public override Person CreatePerson(string name, string bribeAmount)
        {
            return new DirtyCopBribes(name, decimal.Parse(bribeAmount));
        }
    }

    // Fabriksklass för att skapa Lawyer
    public class LawyerFactory : PersonFactory
    {
        public override Person CreatePerson(string name, string lawFirm)
        {
            return new Lawyer(name, lawFirm);
        }
    }

    // Fabriksklass för att skapa Hitman
    public class HitmanFactory : PersonFactory
    {
        public override Person CreatePerson(string name, string successfulHits)
        {
            return new Hitman(name, int.Parse(successfulHits));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Skapa fabriker för olika personklasser
            PersonFactory userFactory = new UserFactory();
            PersonFactory customerFactory = new CustomerFactory();
            PersonFactory consultantFactory = new ConsultantFactory();
            PersonFactory dirtyCopBribesFactory = new DirtyCopBribesFactory();
            PersonFactory lawyerFactory = new LawyerFactory();
            PersonFactory hitmanFactory = new HitmanFactory();

            // Skapa och visa personer
            Person user = userFactory.CreatePerson("Alice", "alice@example.com");
            Person customer = customerFactory.CreatePerson("Bob", "C12345");
            Person consultant = consultantFactory.CreatePerson("Charlie", "IT Security");
            Person dirtyCop = dirtyCopBribesFactory.CreatePerson("Dave", "5000");
            Person lawyer = lawyerFactory.CreatePerson("Eve", "Justice Law Firm");
            Person hitman = hitmanFactory.CreatePerson("Frank", "27");

            DisplayPerson(user);
            DisplayPerson(customer);
            DisplayPerson(consultant);
            DisplayPerson(dirtyCop);
            DisplayPerson(lawyer);
            DisplayPerson(hitman);
        }

        static void DisplayPerson(Person person)
        {
            Console.WriteLine($"Name: {person.Name}, Role: {person.Role}");
            if (person is User user)
            {
                Console.WriteLine($"Email: {user.Email}");
            }
            else if (person is Customer customer)
            {
                Console.WriteLine($"Customer ID: {customer.CustomerId}");
            }
            else if (person is Consultant consultant)
            {
                Console.WriteLine($"Specialty: {consultant.Specialty}");
            }
            else if (person is DirtyCopBribes dirtyCop)
            {
                Console.WriteLine($"Bribe Amount: {dirtyCop.BribeAmount}");
            }
            else if (person is Lawyer lawyer)
            {
                Console.WriteLine($"Law Firm: {lawyer.LawFirm}");
            }
            else if (person is Hitman hitman)
            {
                Console.WriteLine($"Successful Hits: {hitman.SuccessfulHits}");
            }
        }
    }
}

