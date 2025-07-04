<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-04T17:46:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "no"
}
-->
Nå som vi vet litt mer om SSE, la oss bygge en SSE-server neste.

## Øvelse: Lage en SSE-server

For å lage serveren vår må vi ha to ting i tankene:

- Vi må bruke en webserver for å eksponere endepunkter for tilkobling og meldinger.
- Bygge serveren vår som vi vanligvis gjør med verktøy, ressurser og prompts når vi brukte stdio.

### -1- Opprett en serverinstans

For å lage serveren bruker vi de samme typene som med stdio. Men for transporten må vi velge SSE.

La oss legge til nødvendige ruter neste.

### -2- Legg til ruter

La oss legge til ruter som håndterer tilkoblingen og innkommende meldinger:

La oss legge til funksjonalitet til serveren neste.

### -3- Legge til serverfunksjoner

Nå som vi har definert alt som er spesifikt for SSE, la oss legge til serverfunksjoner som verktøy, prompts og ressurser.

Din fullstendige kode skal se slik ut:

Flott, vi har en server som bruker SSE, la oss prøve den ut neste.

## Øvelse: Feilsøke en SSE-server med Inspector

Inspector er et flott verktøy som vi så i en tidligere leksjon [Opprette din første server](/03-GettingStarted/01-first-server/README.md). La oss se om vi kan bruke Inspector også her:

### -1- Kjøre Inspector

For å kjøre Inspector må du først ha en SSE-server som kjører, så la oss gjøre det nå:

1. Start serveren

1. Kjør Inspector

    > ![NOTE]
    > Kjør dette i et eget terminalvindu enn der serveren kjører. Merk også at du må tilpasse kommandoen under til URL-en der serveren din kjører.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Å kjøre Inspector ser likt ut i alle runtime-miljøer. Legg merke til at i stedet for å sende inn en sti til serveren vår og en kommando for å starte serveren, sender vi i stedet URL-en der serveren kjører, og vi spesifiserer også `/sse`-ruten.

### -2- Prøve ut verktøyet

Koble til serveren ved å velge SSE i nedtrekksmenyen og fyll inn URL-feltet der serveren din kjører, for eksempel http:localhost:4321/sse. Klikk deretter på "Connect"-knappen. Som før, velg å liste opp verktøy, velg et verktøy og gi inputverdier. Du bør se et resultat som under:

![SSE Server kjører i Inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.no.png)

Flott, du kan jobbe med Inspector, la oss se hvordan vi kan jobbe med Visual Studio Code neste.

## Oppgave

Prøv å bygge ut serveren din med flere funksjoner. Se [denne siden](https://api.chucknorris.io/) for eksempel for å legge til et verktøy som kaller et API. Du bestemmer hvordan serveren skal se ut. Lykke til :)

## Løsning

[Løsning](./solution/README.md) Her er en mulig løsning med fungerende kode.

## Viktige punkter

De viktigste punktene fra dette kapitlet er:

- SSE er den andre støttede transporttypen ved siden av stdio.
- For å støtte SSE må du håndtere innkommende tilkoblinger og meldinger ved hjelp av et web-rammeverk.
- Du kan bruke både Inspector og Visual Studio Code for å konsumere en SSE-server, akkurat som stdio-servere. Merk hvordan det er noen forskjeller mellom stdio og SSE. For SSE må du starte serveren separat og deretter kjøre Inspector-verktøyet. For Inspector-verktøyet er det også noen forskjeller ved at du må spesifisere URL-en.

## Eksempler

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Ekstra ressurser

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Hva kommer nå

- Neste: [HTTP Streaming med MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.