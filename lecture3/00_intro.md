---
marp: true
theme: default
class: invert
paginate: true
backgroundColor: #1E1E1E
color: #FFFFFF
css: |
  img {
    max-width: 70%;
    max-height: 70%;
    height: auto;
    width: auto;
  }
---

# Behavioral Design Patterns

---

## Introduktion

Behavioral Design Patterns är en kategori av designmönster som handlar om algoritmer och ansvarsområden mellan objekt. De hjälper till att definiera hur objekt kommunicerar och interagerar med varandra, samt hur de ansvarar för olika funktioner inom ett program.

---

## Huvudsyften

- **Kommunikation**: Underlättar kommunikation mellan objekt.
- **Lös koppling**: Främjar lös koppling mellan objekt.
- **Delade ansvarsområden**: Hanterar hur ansvarsområden och uppgifter fördelas mellan olika objekt.

---

## Vanliga Behavioral Design Patterns

- **Chain of Responsibility**: Skapar en kedja av objekt där varje objekt får en chans att hantera en begäran.
- **Command**: Kapslar in en begäran som ett objekt, vilket gör det möjligt att parametrera klienter med olika begäranden och stödja köer eller loggning av begäranden.
- **Iterator**: Ger ett sätt att sekventiellt komma åt elementen i en samling utan att avslöja dess underliggande representation.
- **Mediator**: Definierar ett objekt som inkapslar hur en mängd objekt interagerar. Mediatormönstret främjar lös koppling genom att förhindra att objekt refererar till varandra direkt.

--- 
## Vanliga Behavioral Design Patterns forts.

- **Observer**: Definierar ett en-till-många beroende mellan objekt så att när ett objekt ändrar tillstånd, blir alla dess beroenden notifierade och uppdaterade automatiskt.
- **State**: Tillåter ett objekt att ändra sitt beteende när dess interna tillstånd ändras.
- **Strategy**: Definierar en familj av algoritmer, kapslar in dem och gör dem utbytbara.
- **Template Method**: Definierar skelettet av en algoritm i en metod, och låter subklasser överrida vissa steg i algoritmen utan att ändra dess struktur.
- **Visitor**: Representerar en operation som ska utföras på elementen i en objektstruktur. Det låter dig definiera en ny operation utan att ändra klasserna för elementen som bearbetas.

---

## Varför Behavioral Design Patterns?

Behavioral Design Patterns hjälper till att:

- **Förbättra kommunikationen mellan objekt**: Genom att strukturera interaktionen på ett klart och definierat sätt.
- **Minska komplexiteten**: Genom att hantera ansvarsområden och interaktioner mellan objekt på ett strukturerat sätt.
- **Främja återanvändbarhet**: Genom att separera algoritmer och logik från objektstrukturer och göra dem utbytbara och återanvändbara.

---

## Exempel på Användningsfall

- **UI-komponenter**: När olika UI-komponenter behöver kommunicera och uppdateras baserat på användarinteraktioner.
- **Spelutveckling**: För att hantera spelobjektens tillstånd och beteenden.
- **Observera tillstånd**: För att observera och reagera på förändringar i applikationens data.

---

## Sammanfattning

Behavioral Design Patterns erbjuder lösningar för att hantera hur objekt interagerar och kommunicerar inom ett system. De hjälper till att skapa lös koppling, förbättra kodens flexibilitet och underhållbarhet samt stödja delning och återanvändning av beteendemönster inom applikationer.
