public abstract class RomanNumeralHandler {
    protected RomanNumeralHandler next;

    public void setNext(RomanNumeralHandler next) {
        this.next = next;
    }

    public int handleRequest(String roman) {
        if (roman.startsWith(getSymbol())) {
            return getValue() + next.handleRequest(roman.substring(getSymbol().length()));
        } else if (next != null) {
            return next.handleRequest(roman);
        } else {
            return 0;
        }
    }

    protected abstract String getSymbol();
    protected abstract int getValue();
}

import java.util.List;

public class RomanNumeralChainBuilder {
    public static RomanNumeralHandler buildChain() {
        List<SymbolHandler> handlers = List.of(
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
        );

        for (int i = 0; i < handlers.size() - 1; i++) {
            handlers.get(i).setNext(handlers.get(i + 1));
        }
        return handlers.get(0);
    }
}

public class RomanNumeralConverter {
    private final RomanNumeralHandler chain;

    public RomanNumeralConverter() {
        this.chain = RomanNumeralChainBuilder.buildChain();
    }

    public int convert(String roman) {
        return chain.handleRequest(roman);
    }

    public static void main(String[] args) {
        RomanNumeralConverter converter = new RomanNumeralConverter();
        String roman = "MCMXCIV"; // 1994
        // 1994 = 1000 + 900 + 90 + 4 = M + CM + XC + IV
        // 1989 = 1000 + 900 + 80 + 9 = M + CM + LXXX + IX
        // 13 = 10 + 3 = X + III
        int result = converter.convert(roman);
        System.out.println("The integer value of " + roman + " is " + result);
    }
}
