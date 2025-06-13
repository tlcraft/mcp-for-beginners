<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-13T00:10:11+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "no"
}
-->
Nå som vi vet litt mer om SSE, la oss bygge en SSE-server neste.

## Øvelse: Lage en SSE-server

For å lage serveren vår må vi huske på to ting:

- Vi må bruke en webserver for å eksponere endepunkter for tilkobling og meldinger.
- Bygg serveren vår som vi vanligvis gjør med verktøy, ressurser og prompts når vi brukte stdio.

### -1- Lag en serverinstans

For å lage serveren bruker vi de samme typene som med stdio. Men for transporten må vi velge SSE.

La oss legge til de nødvendige rutene neste.

### -2- Legg til ruter

La oss legge til ruter som håndterer tilkoblingen og innkommende meldinger:

La oss legge til funksjonalitet til serveren neste.

### -3- Legge til serverfunksjoner

Nå som vi har definert alt som er spesifikt for SSE, la oss legge til serverfunksjoner som verktøy, prompts og ressurser.

Din komplette kode skal se slik ut:

Flott, vi har en server som bruker SSE, la oss prøve den ut neste.

## Øvelse: Feilsøke en SSE-server med Inspector

Inspector er et flott verktøy som vi så i en tidligere leksjon [Creating your first server](/03-GettingStarted/01-first-server/README.md). La oss se om vi kan bruke Inspector også her:

### -1- Kjøre inspector

For å kjøre inspector må du først ha en SSE-server kjørende, så la oss gjøre det nå:

1. Kjør serveren

1. Kjør inspector

    > ![NOTE]
    > Kjør dette i et eget terminalvindu enn der serveren kjører. Merk også at du må tilpasse kommandoen under til URL-en hvor serveren din kjører.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Å kjøre inspector ser likt ut i alle runtime-miljøer. Legg merke til at i stedet for å sende inn en bane til serveren og en kommando for å starte serveren, sender vi inn URL-en hvor serveren kjører og spesifiserer også `/sse`-ruten.

### -2- Prøve ut verktøyet

Koble til serveren ved å velge SSE i nedtrekksmenyen og fyll inn URL-feltet med hvor serveren din kjører, for eksempel http://localhost:4321/sse. Klikk deretter på "Connect"-knappen. Som før, velg å liste opp verktøy, velg et verktøy og gi inputverdier. Du skal se et resultat som under:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.no.png)

Flott, du kan jobbe med inspector, la oss se hvordan vi kan jobbe med Visual Studio Code neste.

## Oppgave

Prøv å bygge ut serveren din med flere funksjoner. Se [denne siden](https://api.chucknorris.io/) for eksempel for å legge til et verktøy som kaller en API, du bestemmer hvordan serveren skal se ut. Ha det gøy :)

## Løsning

[Løsning](./solution/README.md) Her er en mulig løsning med fungerende kode.

## Viktige punkter

Viktige punkter fra dette kapitlet er:

- SSE er den andre støttede transporttypen ved siden av stdio.
- For å støtte SSE må du håndtere innkommende tilkoblinger og meldinger ved hjelp av et web-rammeverk.
- Du kan bruke både Inspector og Visual Studio Code for å konsumere SSE-servere, akkurat som stdio-servere. Merk at det er noen små forskjeller mellom stdio og SSE. For SSE må du starte serveren separat og deretter kjøre inspector-verktøyet. For inspector-verktøyet må du også spesifisere URL-en.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ekstra ressurser

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Hva kommer nå

- Neste: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.