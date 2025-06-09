<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:29:39+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "da"
}
-->
Fantastisk, til vores næste trin, lad os liste kapabiliteterne på serveren.

### -2 Liste serverkapabiliteter

Nu vil vi forbinde til serveren og bede om dens kapabiliteter:

### -3- Konverter serverkapabiliteter til LLM-værktøjer

Næste skridt efter at have listet serverkapabiliteter er at konvertere dem til et format, som LLM forstår. Når vi gør det, kan vi tilbyde disse kapabiliteter som værktøjer til vores LLM.

Fantastisk, vi er nu klar til at håndtere brugerforespørgsler, så lad os tage fat på det næste.

### -4- Håndter brugerprompt-forespørgsel

I denne del af koden vil vi håndtere brugerforespørgsler.

Fantastisk, du klarede det!

## Opgave

Tag koden fra øvelsen og byg serveren ud med flere værktøjer. Opret derefter en klient med en LLM, som i øvelsen, og test den med forskellige prompts for at sikre, at alle dine serverværktøjer bliver kaldt dynamisk. Denne måde at bygge en klient på betyder, at slutbrugeren får en god brugeroplevelse, da de kan bruge prompts i stedet for præcise klientkommandoer og ikke behøver at være opmærksomme på, at en MCP-server bliver kaldt.

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

- Næste: [Brug af en server med Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.