using System;
using System.Collections.Generic;

/* 
 * Abstrakt klass som definierar gränssnittet för att hantera en förfrågan om romerska siffror.
 * Den har metoder för att sätta nästa handler i kedjan och för att hantera en förfrågan.
 */
public abstract class RomanNumeralHandler
{
    protected RomanNumeralHandler next;

    // Sätt nästa handler i kedjan
    public void SetNext(RomanNumeralHandler next)
    {
        this.next = next;
    }

    // Hantera förfrågan om konvertering av romerska siffror till heltal
    public int HandleRequest(string roman)
    {
        if (roman.StartsWith(GetSymbol()))
        {
            return GetValue() + (next != null ? next.HandleRequest(roman.Substring(GetSymbol().Length)) : 0);
        }
        else if (next != null)
        {
            return next.HandleRequest(roman);
        }
        else
        {
            return 0;
        }
    }

    // Abstrakta metoder för att få symbol och värde, implementeras i konkreta klasser
    protected abstract string GetSymbol();
    protected abstract int GetValue();
}

/*
 * Konkret klass som implementerar RomanNumeralHandler och representerar en specifik symbol och dess värde.
 */
public class SymbolHandler : RomanNumeralHandler
{
    private readonly string symbol;
    private readonly int value;

    public SymbolHandler(string symbol, int value)
    {
        this.symbol = symbol;
        this.value = value;
    }

    protected override string GetSymbol()
    {
        return symbol;
    }

    protected override int GetValue()
    {
        return value;
    }
}

/*
 * Klass som bygger en kedja av SymbolHandler-objekt för att hantera konvertering av romerska siffror till heltal.
 */
public class RomanNumeralChainBuilder
{
    public static RomanNumeralHandler BuildChain()
    {
        // Skapa en lista med handlers för varje romersk siffersymbol och dess värde
        List<SymbolHandler> handlers = new List<SymbolHandler>
        {
            new SymbolHandler("MMMMMMMMM", 9000),
            new SymbolHandler("MMMMMMMM", 8000),
            new SymbolHandler("MMMMMMM", 7000),
            new SymbolHandler("MMMMMM", 6000),
            new SymbolHandler("MMMMM", 5000),
            new SymbolHandler("MMMM", 4000),
            new SymbolHandler("MMM", 3000),
            new SymbolHandler("MM", 2000), // Marcus Medina :D
            new SymbolHandler("M", 1000),
            new SymbolHandler("CM", 900),
            new SymbolHandler("D", 500),
            new SymbolHandler("CD", 400),
            new SymbolHandler("C", 100),
            new SymbolHandler("XC", 90),
            new SymbolHandler("L", 50),
            new SymbolHandler("XL", 40),
            new SymbolHandler("X", 10),
            new SymbolHandler("IX", 9),
            new SymbolHandler("V", 5),
            new SymbolHandler("IV", 4),
            new SymbolHandler("I", 1)
        };

        // Bygg kedjan genom att länka varje handler till nästa
        for (int i = 0; i < handlers.Count - 1; i++)
        {
            handlers[i].SetNext(handlers[i + 1]);
        }

        // Returnera den första handlern i kedjan
        return handlers[0];
    }
}

/*
 * Klass som använder en kedja av RomanNumeralHandler-objekt för att konvertera en romersk siffra till ett heltal.
 */
public class RomanNumeralConverter
{
    private readonly RomanNumeralHandler chain;

    public RomanNumeralConverter()
    {
        this.chain = RomanNumeralChainBuilder.BuildChain();
    }

    public int Convert(string roman)
    {
        return chain.HandleRequest(roman);
    }
}

/*
 * Huvudklassen som demonstrerar hur man använder RomanNumeralConverter för att konvertera romerska siffror till heltal.
 */
class Program
{
    static void Main(string[] args)
    {
        RomanNumeralConverter converter = new RomanNumeralConverter();

        string roman = "MCMXCIV"; // 1994
        // 1994 = 1000 + 900 + 90 + 4 = M + CM + XC + IV
        // 1989 = 1000 + 900 + 80 + 9 = M + CM + LXXX + IX
        // 13 = 10 + 3 = X + III

        int result = converter.Convert(roman);
        Console.WriteLine($"The integer value of {roman} is {result}");
    }
}
