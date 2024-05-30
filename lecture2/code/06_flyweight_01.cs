using System;
using System.Collections.Generic;

namespace FlyweightPatternExample1
{
    // Flyweight interface
    public interface ICharacter
    {
        void Display();
    }

    // Concrete Flyweight
    public class Character : ICharacter
    {
        private char _symbol;

        public Character(char symbol)
        {
            _symbol = symbol;
        }

        public void Display()
        {
            Console.WriteLine($"Displaying character: {_symbol}");
        }
    }

    // Flyweight Factory
    public class CharacterFactory
    {
        private Dictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

        public ICharacter GetCharacter(char symbol)
        {
            if (!_characters.ContainsKey(symbol))
            {
                _characters[symbol] = new Character(symbol);
            }
            return _characters[symbol];
        }
    }

    // Client
    class Program
    {
        static void Main(string[] args)
        {
            string text = "HELLO";
            CharacterFactory factory = new CharacterFactory();

            foreach (char c in text)
            {
                ICharacter character = factory.GetCharacter(c);
                character.Display();
            }
        }
    }
}

// Output:
// Displaying character: H
// Displaying character: E
// Displaying character: L
// Displaying character: L
// Displaying character: O


// Förklaring:
// I detta exempel har vi tre klasser:
// - Character: Implementerar ICharacter och representerar en konkret flyweight-klass.
// - CharacterFactory: Implementerar en flyweight-fabrik som skapar och lagrar flyweight-objekt.
// - Program: Använder flyweight-fabriken för att skapa och visa flyweight-objekt för varje tecken i en sträng.
//
// Flyweight-mönstret används för att minska minnesanvändningen genom att dela gemensamma delar av objekt mellan flera objekt.
// I det här fallet skapas en Character-instans för varje tecken i strängen "HELLO". Eftersom tecknen "L" upprepas flera gånger
// kommer samma Character-instans att återanvändas för varje förekomst av "L". Detta minskar minnesanvändningen och förbättrar prestanda.
// Flyweight-mönstret används ofta i situationer där det finns många liknande objekt som kan delas mellan flera instanser.
// Det är särskilt användbart när det finns många objekt som delar samma data eller beteende, och det är inte nödvändigt att skapa en ny instans för varje objekt.
// Flyweight-mönstret kan användas för att minska minnesanvändningen och förbättra prestanda genom att dela gemensamma delar av objekt mellan flera instanser.
// Det kan vara användbart när det finns många objekt som delar samma data eller beteende, och det är inte nödvändigt att skapa en ny instans för varje objekt.