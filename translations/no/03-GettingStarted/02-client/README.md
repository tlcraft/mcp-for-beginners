<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-04T17:44:29+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "no"
}
-->
I den foregående koden gjorde vi følgende:

- Importerte bibliotekene
- Opprettet en instans av en klient og koblet den til ved hjelp av stdio som transport.
- Listet opp prompts, ressurser og verktøy, og kalte dem alle.

Der har du det, en klient som kan kommunisere med en MCP-server.

La oss ta oss god tid i neste øvelsesdel og gå gjennom hver kodebit for å forklare hva som skjer.

## Øvelse: Skrive en klient

Som nevnt over, la oss ta oss tid til å forklare koden, og føl deg fri til å kode sammen hvis du vil.

### -1- Importere bibliotekene

La oss importere bibliotekene vi trenger, vi vil trenge referanser til en klient og til vår valgte transportprotokoll, stdio. stdio er en protokoll for ting som skal kjøre på din lokale maskin. SSE er en annen transportprotokoll vi vil vise i fremtidige kapitler, men det er ditt andre alternativ. For nå, la oss fortsette med stdio.

La oss gå videre til instansiering.

### -2- Instansiere klient og transport

Vi må opprette en instans av transporten og en av klienten vår:

### -3- Liste opp serverfunksjonene

Nå har vi en klient som kan koble til når programmet kjøres. Men den lister ikke faktisk opp funksjonene sine, så la oss gjøre det nå:

Flott, nå har vi fanget opp alle funksjonene. Spørsmålet er når bruker vi dem? Vel, denne klienten er ganske enkel, enkel i den forstand at vi må eksplisitt kalle funksjonene når vi ønsker dem. I neste kapittel skal vi lage en mer avansert klient som har tilgang til sin egen store språkmodell, LLM. For nå, la oss se hvordan vi kan kalle funksjonene på serveren:

### -4- Kalle funksjoner

For å kalle funksjonene må vi sørge for å spesifisere riktige argumenter og i noen tilfeller navnet på det vi prøver å kalle.

### -5- Kjøre klienten

For å kjøre klienten, skriv følgende kommando i terminalen:

## Oppgave

I denne oppgaven skal du bruke det du har lært om å lage en klient, men lage din egen klient.

Her er en server du kan bruke som du må kalle via klientkoden din, se om du kan legge til flere funksjoner på serveren for å gjøre den mer interessant.

## Løsning

[Løsning](./solution/README.md)

## Viktige punkter

De viktigste punktene for dette kapittelet om klienter er:

- Kan brukes både til å oppdage og kalle funksjoner på serveren.
- Kan starte en server samtidig som den starter seg selv (som i dette kapittelet), men klienter kan også koble til kjørende servere.
- Er en flott måte å teste serverens funksjonalitet på, ved siden av alternativer som Inspector, som ble beskrevet i forrige kapittel.

## Ekstra ressurser

- [Bygge klienter i MCP](https://modelcontextprotocol.io/quickstart/client)

## Eksempler

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Hva kommer nå

- Neste: [Lage en klient med en LLM](../03-llm-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.