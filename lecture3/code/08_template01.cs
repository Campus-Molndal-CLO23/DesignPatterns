/*

DataValidator

Validate: Mallmetoden som utför stegen för datavalidering.
ReadData: Abstrakt metod för att läsa data.
ValidateData: Abstrakt metod för att validera data.
ProcessData: Abstrakt metod för att bearbeta data.

*/

using System;

/* Abstrakt klass som definierar mallmetoden för datavalidering */
public abstract class DataValidator
{
    public void Validate()
    {
        ReadData();
        if (ValidateData())
        {
            ProcessData();
        }
        else
        {
            Console.WriteLine("Data validation failed.");
        }
    }

    protected abstract void ReadData();
    protected abstract bool ValidateData();
    protected abstract void ProcessData();
}

/* Konkret klass som implementerar validering av användardata */
public class UserDataValidator : DataValidator
{
    private string _data;

    protected override void ReadData()
    {
        _data = "User data";
        Console.WriteLine("Reading user data.");
    }

    protected override bool ValidateData()
    {
        Console.WriteLine("Validating user data.");
        return !string.IsNullOrEmpty(_data);
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Processing user data.");
    }
}

/* Konkret klass som implementerar validering av produktdata */
public class ProductDataValidator : DataValidator
{
    private string _data;

    protected override void ReadData()
    {
        _data = "Product data";
        Console.WriteLine("Reading product data.");
    }

    protected override bool ValidateData()
    {
        Console.WriteLine("Validating product data.");
        return !string.IsNullOrEmpty(_data);
    }

    protected override void ProcessData()
    {
        Console.WriteLine("Processing product data.");
    }
}

/* Programklass för att demonstrera datavalidering med Template Method-mönstret */
class Program
{
    static void Main()
    {
        DataValidator userDataValidator = new UserDataValidator();
        userDataValidator.Validate();

        DataValidator productDataValidator = new ProductDataValidator();
        productDataValidator.Validate();
    }
}
