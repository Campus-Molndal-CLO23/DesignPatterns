---
marp: true
theme: rose-pine
class: invert
paginate: true
---

# Gang of Four & Design Patterns
### För C#-programmerare

---

# Introduktion till Gang of Four (GoF)

- **Författare**: Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides
- **Bok**: "Design Patterns: Elements of Reusable Object-Oriented Software" (1994)
- **Syfte**: Introducera återanvändbara designlösningar

---

# Vad är design patterns?

- **Definition**: Återkommande lösningar på vanliga designproblem inom mjukvaruutveckling
- **Fördelar**:
  - Förbättrad kodkvalitet
  - Underlättar underhåll och vidareutveckling
  - Främjar återanvändbarhet

---

# Kategorier av design patterns

1. **Skapande mönster (Creational)**
2. **Strukturmönster (Structural)**
3. **Beteendemönster (Behavioral)**

---

# Skapande mönster

- **Abstract Factory**: Skapar familjer av relaterade objekt utan att specificera deras konkreta klasser.
- **Builder**: Separar konstruktionen av ett komplext objekt från dess representation.
- **Factory Method**: Definierar en metod för att skapa objekt, men låter subklasser bestämma vilken klass som ska instansieras.
- **Prototype**: Skapar nya objekt genom att kopiera en befintlig instans.
- **Singleton**: Ser till att en klass har endast en instans och ger ett globalt tillträde till den instansen.

---

# Strukturmönster

- **Adapter**: Gör så att klasser med inkompatibla gränssnitt kan samarbeta.
- **Bridge**: Separar abstraktion från implementering så att de båda kan variera oberoende av varandra.
- **Composite**: Behandlar en grupp av objekt på samma sätt som ett enskilt objekt.
- **Decorator**: Dynamiskt lägger till ansvar till objekt utan att ändra deras kod.
- **Facade**: Ger ett förenklat gränssnitt till ett komplext subsystem.
- **Flyweight**: Använder delning för att stödja ett stort antal små objekt på ett effektivt sätt.
- **Proxy**: Ger ett ställföreträdande eller substitut för ett annat objekt för att kontrollera tillgången till det.

---

# Beteendemönster

- **Chain of Responsibility**: Undviker kopplingen mellan avsändare och mottagare genom att ge fler än ett objekt möjlighet att hantera en begäran.
- **Command**: Innesluter en begäran som ett objekt, vilket gör det möjligt att parametrisera klienter med olika begäranden.
- **Interpreter**: Tolkar representationen av ett språkets grammatik och utvärderar meningar i språket.
- **Iterator**: Tillhandahåller ett sätt att sekventiellt få tillgång till elementen i en aggregerad objekt utan att avslöja dess underliggande representation.
- **Mediator**: Definierar ett objekt som kapslar in hur en uppsättning objekt interagerar.

---

# Beteendemönster
- **Memento**: Tillåter att man kan spara och återställa ett objekts tidigare tillstånd utan att bryta inkapsling.
- **Observer**: Definierar ett en-till-många beroende mellan objekt så att när ett objekt ändrar tillstånd, notifieras och uppdateras alla beroende objekt automatiskt.
- **State**: Tillåter ett objekt att ändra sitt beteende när dess interna tillstånd ändras.
- **Strategy**: Definierar en familj av algoritmer, kapslar in varje algoritm, och gör dem utbytbara.
- **Template Method**: Definierar skelettet av en algoritm i en operation och låter subklasser definiera vissa steg i algoritmen.
- **Visitor**: Representerar en operation som ska utföras på elementen i en objektstruktur.

---

# Sammanfattning

- **Gang of Four**: Pionjärer inom objektorienterad design med deras bok från 1994.
- **Design patterns**: Återanvändbara lösningar på vanliga problem i mjukvarudesign.
- **Tre kategorier**: Skapande, Struktur, Beteende.
- **Fördelar**: Underlättar förvaltning, ökar återanvändbarhet, och förbättrar kodkvalitet.

---

# Kodexempel

https://github.com/Campus-Molndal-CLO23/DesignPatterns/blob/main/lecture1/code/