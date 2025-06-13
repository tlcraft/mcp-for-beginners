<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:47:09+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "da"
}
-->
I den foregående kode gjorde vi:

- Importerede bibliotekerne
- Oprettede en instans af en client og forbinder den ved hjælp af stdio som transport.
- Liste prompts, ressourcer og værktøjer og kalde dem alle.

Der har du det, en client der kan kommunikere med en MCP Server.

Lad os tage os god tid i næste øvelsesafsnit og gennemgå hver kodebid og forklare, hvad der sker.

## Øvelse: Skrive en client

Som nævnt ovenfor, lad os tage os tid til at forklare koden, og du er meget velkommen til at kode med, hvis du vil.

### -1- Importere bibliotekerne

Lad os importere de biblioteker, vi har brug for; vi skal bruge referencer til en client og til vores valgte transportprotokol, stdio. stdio er en protokol til ting, der skal køre på din lokale maskine. SSE er en anden transportprotokol, som vi vil vise i fremtidige kapitler, men det er dit andet valg. For nu, lad os fortsætte med stdio.

Lad os gå videre til instantiationen.

### -2- Instantiere client og transport

Vi skal oprette en instans af transporten og en af vores client:

### -3- Liste serverfunktionerne

Nu har vi en client, der kan forbinde til serveren, hvis programmet køres. Men den viser ikke faktisk sine funktioner, så lad os gøre det næste:

Fint, nu har vi fanget alle funktionerne. Nu er spørgsmålet, hvornår bruger vi dem? Denne client er ret simpel, simpel i den forstand, at vi eksplicit skal kalde funktionerne, når vi vil bruge dem. I næste kapitel vil vi skabe en mere avanceret client, der har adgang til sin egen store sprogmodel, LLM. For nu, lad os se, hvordan vi kan kalde funktionerne på serveren:

### -4- Kalde funktioner

For at kalde funktionerne skal vi sikre, at vi angiver de korrekte argumenter og i nogle tilfælde navnet på det, vi forsøger at kalde.

### -5- Køre clienten

For at køre clienten, skriv følgende kommando i terminalen:

## Opgave

I denne opgave skal du bruge det, du har lært om at skabe en client, men lave din egen client.

Her er en server, du kan bruge, som du skal kalde via din client-kode; se om du kan tilføje flere funktioner til serveren for at gøre den mere interessant.

## Løsning

[Løsning](./solution/README.md)

## Vigtige pointer

De vigtigste pointer i dette kapitel om clients er:

- Kan bruges både til at opdage og kalde funktioner på serveren.
- Kan starte en server, mens den selv starter (som i dette kapitel), men clients kan også forbinde til allerede kørende servere.
- Er en god måde at teste serverfunktioner på ved siden af alternativer som Inspector, som blev beskrevet i det foregående kapitel.

## Yderligere ressourcer

- [Bygning af clients i MCP](https://modelcontextprotocol.io/quickstart/client)

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Hvad er næste skridt

- Næste: [Oprette en client med en LLM](/03-GettingStarted/03-llm-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.