<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:22:27+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "da"
}
-->
# Oprettelse af en klient med LLM

Indtil nu har du set, hvordan man opretter en server og en klient. Klienten har været i stand til at kalde serveren eksplicit for at liste dens værktøjer, ressourcer og prompts. Men det er ikke en særlig praktisk tilgang. Din bruger lever i den agentiske æra og forventer at bruge prompts og kommunikere med en LLM for at gøre dette. For din bruger er det ligegyldigt, om du bruger MCP eller ej til at gemme dine funktioner, men de forventer at bruge naturligt sprog til at interagere. Så hvordan løser vi dette? Løsningen handler om at tilføje en LLM til klienten.

## Oversigt

I denne lektion fokuserer vi på at tilføje en LLM til din klient og vise, hvordan dette giver en meget bedre oplevelse for din bruger.

## Læringsmål

Ved slutningen af denne lektion vil du kunne:

- Oprette en klient med en LLM.
- Interagere problemfrit med en MCP-server ved hjælp af en LLM.
- Give en bedre brugeroplevelse på klientsiden.

## Fremgangsmåde

Lad os prøve at forstå den fremgangsmåde, vi skal tage. At tilføje en LLM lyder simpelt, men hvordan gør vi egentlig dette?

Sådan vil klienten interagere med serveren:

1. Etabler forbindelse til serveren.

1. List kapabiliteter, prompts, ressourcer og værktøjer, og gem deres skema.

1. Tilføj en LLM og overfør de gemte kapabiliteter og deres skema i et format, som LLM'en forstår.

1. Håndter en brugerprompt ved at sende den til LLM'en sammen med de værktøjer, der er listet af klienten.

Godt, nu forstår vi, hvordan vi kan gøre dette på et højt niveau, lad os prøve dette i nedenstående øvelse.

## Øvelse: Oprettelse af en klient med en LLM

I denne øvelse vil vi lære at tilføje en LLM til vores klient.

### -1- Forbind til serveren

Lad os først oprette vores klient:
Du er trænet på data op til oktober 2023. 

### -2- List serverkapabiliteter

Nu vil vi oprette forbindelse til serveren og bede om dens kapabiliteter:

### -3- Konverter serverkapabiliteter til LLM-værktøjer

Næste trin efter at have listet serverkapabiliteter er at konvertere dem til et format, som LLM'en forstår. Når vi har gjort det, kan vi give disse kapabiliteter som værktøjer til vores LLM.

Godt, vi er ikke klar til at håndtere brugerforespørgsler, så lad os tage fat på det næste.

### -4- Håndter brugerpromptforespørgsel

I denne del af koden vil vi håndtere brugerforespørgsler.

Godt, du gjorde det!

## Opgave

Tag koden fra øvelsen og udbyg serveren med nogle flere værktøjer. Opret derefter en klient med en LLM, som i øvelsen, og test den med forskellige prompts for at sikre, at alle dine serverværktøjer bliver kaldt dynamisk. Denne måde at bygge en klient på betyder, at slutbrugeren vil have en fantastisk brugeroplevelse, da de kan bruge prompts i stedet for præcise klientkommandoer og være uvidende om, at en MCP-server bliver kaldt.

## Løsning 

[Løsning](/03-GettingStarted/03-llm-client/solution/README.md)

## Vigtige pointer

- At tilføje en LLM til din klient giver en bedre måde for brugere at interagere med MCP-servere.
- Du skal konvertere MCP-serverens svar til noget, som LLM'en kan forstå.

## Eksempler

- [Java Lommeregner](../samples/java/calculator/README.md)
- [.Net Lommeregner](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Lommeregner](../samples/javascript/README.md)
- [TypeScript Lommeregner](../samples/typescript/README.md)
- [Python Lommeregner](../../../../03-GettingStarted/samples/python)

## Yderligere ressourcer

## Hvad er det næste

- Næste: [Forbrug af en server ved hjælp af Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Mens vi bestræber os på at opnå nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der opstår ved brugen af denne oversættelse.