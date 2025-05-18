<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:40:51+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "da"
}
-->
# Oprettelse af en klient

Klienter er brugerdefinerede applikationer eller scripts, der kommunikerer direkte med en MCP-server for at anmode om ressourcer, værktøjer og prompts. I modsætning til brugen af inspektørværktøjet, der giver en grafisk grænseflade til interaktion med serveren, giver det at skrive din egen klient mulighed for programmatiske og automatiserede interaktioner. Dette gør det muligt for udviklere at integrere MCP-funktioner i deres egne arbejdsgange, automatisere opgaver og bygge skræddersyede løsninger til specifikke behov.

## Oversigt

Denne lektion introducerer konceptet klienter inden for Model Context Protocol (MCP) økosystemet. Du vil lære, hvordan du skriver din egen klient og får den til at forbinde til en MCP-server.

## Læringsmål

Ved slutningen af denne lektion vil du kunne:

- Forstå, hvad en klient kan gøre.
- Skrive din egen klient.
- Forbinde og teste klienten med en MCP-server for at sikre, at sidstnævnte fungerer som forventet.

## Hvad kræves der for at skrive en klient?

For at skrive en klient skal du gøre følgende:

- **Importere de korrekte biblioteker**. Du vil bruge det samme bibliotek som før, bare med forskellige konstruktioner.
- **Oprette en klient**. Dette vil involvere at skabe en klientinstans og forbinde den til den valgte transportmetode.
- **Beslutte, hvilke ressourcer der skal listes**. Din MCP-server kommer med ressourcer, værktøjer og prompts, du skal beslutte, hvilke der skal listes.
- **Integrere klienten til en værtsapplikation**. Når du kender serverens kapaciteter, skal du integrere dette i din værtsapplikation, så hvis en bruger skriver en prompt eller anden kommando, bliver den tilsvarende serverfunktion aktiveret.

Nu hvor vi forstår på et højt niveau, hvad vi er ved at gøre, lad os se på et eksempel næste.

### Et eksempel på en klient

Lad os se på denne eksempelklient:
Du er trænet på data op til oktober 2023.

I den foregående kode:

- Importerer vi bibliotekerne
- Opretter en instans af en klient og forbinder den ved hjælp af stdio til transport.
- Lister prompts, ressourcer og værktøjer og aktiverer dem alle.

Der har du det, en klient der kan kommunikere med en MCP-server.

Lad os tage os tid i det næste øvelsesafsnit og gennemgå hver kodebit og forklare, hvad der foregår.

## Øvelse: Skrive en klient

Som nævnt ovenfor, lad os tage os tid til at forklare koden, og føl dig fri til at kode med, hvis du vil.

### -1- Importere bibliotekerne

Lad os importere de nødvendige biblioteker, vi har brug for referencer til en klient og til vores valgte transportprotokol, stdio. stdio er en protokol til ting, der er beregnet til at køre på din lokale maskine. SSE er en anden transportprotokol, vi vil vise i fremtidige kapitler, men det er din anden mulighed. For nu, lad os fortsætte med stdio.

Lad os gå videre til instansiering.

### -2- Instansiering af klient og transport

Vi skal oprette en instans af transporten og en af vores klient:

### -3- Liste over serverfunktionerne

Nu har vi en klient, der kan forbinde, hvis programmet bliver kørt. Dog lister den ikke sine funktioner, så lad os gøre det næste:

Godt, nu har vi fanget alle funktionerne. Nu er spørgsmålet, hvornår bruger vi dem? Denne klient er ret simpel, simpel i den forstand, at vi vil skulle kalde funktionerne eksplicit, når vi vil have dem. I det næste kapitel vil vi skabe en mere avanceret klient, der har adgang til sin egen store sprogmodel, LLM. For nu, lad os se, hvordan vi kan aktivere funktionerne på serveren:

### -4- Aktivere funktioner

For at aktivere funktionerne skal vi sikre, at vi specificerer de korrekte argumenter og i nogle tilfælde navnet på det, vi prøver at aktivere.

### -5- Kør klienten

For at køre klienten, skriv følgende kommando i terminalen:

## Opgave

I denne opgave skal du bruge det, du har lært om at skabe en klient, men skabe din egen klient.

Her er en server, du kan bruge, som du skal kalde via din klientkode, se om du kan tilføje flere funktioner til serveren for at gøre den mere interessant.

## Løsning

[Løsning](./solution/README.md)

## Vigtige pointer

De vigtigste pointer for dette kapitel om klienter er:

- Kan bruges til både at opdage og aktivere funktioner på serveren.
- Kan starte en server, mens den starter sig selv (som i dette kapitel), men klienter kan også forbinde til kørende servere.
- Er en fantastisk måde at teste serverens kapaciteter på ved siden af alternativer som inspektøren, som blev beskrevet i det forrige kapitel.

## Yderligere ressourcer

- [Bygge klienter i MCP](https://modelcontextprotocol.io/quickstart/client)

## Eksempler

- [Java Lommeregner](../samples/java/calculator/README.md)
- [.Net Lommeregner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Lommeregner](../samples/javascript/README.md)
- [TypeScript Lommeregner](../samples/typescript/README.md)
- [Python Lommeregner](../../../../03-GettingStarted/samples/python)

## Hvad er det næste

- Næste: [Oprettelse af en klient med en LLM](/03-GettingStarted/03-llm-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der måtte opstå ved brugen af denne oversættelse.