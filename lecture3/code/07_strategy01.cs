/* Första exempel: Banklån */

using System;
using System.Collections.Generic;

/* Gränssnitt för strategier */
public interface ILoanStrategy
{
    void CalculateLoan(double amount, int years);
}

/* Konkret strategi för personlån */
public class PersonalLoanStrategy : ILoanStrategy
{
    public void CalculateLoan(double amount, int years)
    {
        double rate = 5.5; // Ränta i procent
        double interest = amount * rate * years / 100;
        double total = amount + interest;
        Console.WriteLine($"Personal Loan - Amount: {amount}, Years: {years}, Interest: {interest}, Total: {total}");
    }
}

/* Konkret strategi för bolån */
public class HomeLoanStrategy : ILoanStrategy
{
    public void CalculateLoan(double amount, int years)
    {
        double rate = 3.5; // Ränta i procent
        double interest = amount * rate * years / 100;
        double total = amount + interest;
        Console.WriteLine($"Home Loan - Amount: {amount}, Years: {years}, Interest: {interest}, Total: {total}");
    }
}

/* Klass för att hantera låneberäkningar */
public class LoanCalculator
{
    private ILoanStrategy _loanStrategy;

    public void SetStrategy(ILoanStrategy loanStrategy)
    {
        _loanStrategy = loanStrategy;
    }

    public void CalculateLoan(double amount, int years)
    {
        _loanStrategy.CalculateLoan(amount, years);
    }
}

/* Programklass för att demonstrera strategimönstret med banklån */
class Program
{
    static void Main()
    {
        LoanCalculator loanCalculator = new LoanCalculator();

        // Beräkning av personlån
        loanCalculator.SetStrategy(new PersonalLoanStrategy());
        loanCalculator.CalculateLoan(10000, 5);

        // Beräkning av bolån
        loanCalculator.SetStrategy(new HomeLoanStrategy());
        loanCalculator.CalculateLoan(100000, 30);
    }
}

/*
Förklaringar till koden
ILoanStrategy: Gränssnitt för strategier som definierar metoden CalculateLoan.
PersonalLoanStrategy: Konkret strategi för att beräkna personlån.
HomeLoanStrategy: Konkret strategi för att beräkna bolån.
LoanCalculator: Klass för att hantera låneberäkningar och sätta strategin.
Program: Huvudklassen som demonstrerar hur strategimönstret fungerar med banklån.
*/
