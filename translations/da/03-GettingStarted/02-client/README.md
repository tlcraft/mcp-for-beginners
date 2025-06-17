<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T15:52:08+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "da"
}
-->
I den foregående kode gjorde vi:

- Importerede bibliotekerne
- Oprettede en instans af en client og forbinder den ved hjælp af stdio som transport.
- Listede prompts, ressourcer og værktøjer og kaldte dem alle.

Der har du det, en client der kan kommunikere med en MCP Server.

Lad os tage os god tid i næste øvelsesafsnit og gennemgå hver kodebid og forklare, hvad der sker.

## Øvelse: Skrive en client

Som nævnt ovenfor, lad os tage os tid til at forklare koden, og du er selvfølgelig velkommen til at kode med, hvis du vil.

### -1- Importere bibliotekerne

Lad os importere de biblioteker, vi har brug for; vi skal bruge referencer til en client og til vores valgte transportprotokol, stdio. stdio er en protokol til ting, der skal køre på din lokale maskine. SSE er en anden transportprotokol, som vi vil vise i kommende kapitler, men det er dit andet valg. For nu, lad os fortsætte med stdio.

Lad os gå videre til instantiationen.

### -2- Instantiere client og transport

Vi skal oprette en instans af transporten og en af vores client:

### -3- Liste serverens funktioner

Nu har vi en client, der kan forbinde til serveren, hvis programmet køres. Men den viser ikke faktisk sine funktioner endnu, så lad os gøre det næste:

Fint, nu har vi fanget alle funktionerne. Nu er spørgsmålet, hvornår bruger vi dem? Denne client er ret simpel, simpel i den forstand, at vi skal kalde funktionerne eksplicit, når vi vil bruge dem. I næste kapitel vil vi lave en mere avanceret client, som har adgang til sin egen store sprogmodel, LLM. For nu, lad os se, hvordan vi kan kalde funktionerne på serveren:

### -4- Kald funktioner

For at kalde funktionerne skal vi sikre os, at vi angiver de korrekte argumenter og i nogle tilfælde navnet på det, vi prøver at kalde.

### -5- Kør clienten

For at køre clienten, skriv følgende kommando i terminalen:

## Opgave

I denne opgave skal du bruge det, du har lært om at skabe en client, men lave din egen client.

Her er en server, du kan bruge, som du skal kalde via din client-kode. Se, om du kan tilføje flere funktioner til serveren for at gøre den mere interessant.

## Løsning

[Løsning](./solution/README.md)

## Vigtige pointer

De vigtigste pointer for dette kapitel om clients er:

- Kan bruges både til at opdage og kalde funktioner på serveren.
- Kan starte en server, mens den selv starter (som i dette kapitel), men clients kan også forbinde til kørende servere.
- Er en god måde at teste serverens funktioner på ved siden af alternativer som Inspector, som blev beskrevet i det foregående kapitel.

## Yderligere ressourcer

- [Bygning af clients i MCP](https://modelcontextprotocol.io/quickstart/client)

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Hvad er det næste

- Næste: [Oprette en client med en LLM](/03-GettingStarted/03-llm-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der måtte opstå som følge af brugen af denne oversættelse.