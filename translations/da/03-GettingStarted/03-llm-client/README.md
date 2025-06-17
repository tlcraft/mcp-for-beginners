<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:50:01+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "da"
}
-->
Fantastisk, til vores næste skridt, lad os liste kapabiliteterne på serveren.

### -2 List serverkapabiliteter

Nu vil vi oprette forbindelse til serveren og spørge efter dens kapabiliteter:

### -3- Konverter serverkapabiliteter til LLM-værktøjer

Næste skridt efter at have listet serverkapabiliteterne er at konvertere dem til et format, som LLM forstår. Når vi har gjort det, kan vi give disse kapabiliteter som værktøjer til vores LLM.

Fantastisk, vi er nu klar til at håndtere brugerforespørgsler, så lad os tage fat på det næste.

### -4- Håndter brugerprompt-forespørgsel

I denne del af koden vil vi håndtere brugerforespørgsler.

Fantastisk, du klarede det!

## Opgave

Tag koden fra øvelsen og udbyg serveren med flere værktøjer. Opret derefter en klient med en LLM, som i øvelsen, og test den med forskellige prompts for at sikre, at alle dine serverværktøjer bliver kaldt dynamisk. Denne måde at bygge en klient på betyder, at slutbrugeren får en fremragende brugeroplevelse, da de kan bruge prompts i stedet for præcise klientkommandoer og være uvidende om, at der kaldes en MCP-server.

## Løsning

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Vigtige pointer

- At tilføje en LLM til din klient giver en bedre måde for brugere at interagere med MCP-servere.
- Du skal konvertere MCP-serverens svar til noget, som LLM kan forstå.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Yderligere ressourcer

## Hvad er det næste

- Næste: [Forbrug en server ved hjælp af Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.