<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:41:35+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "no"
}
-->
# Opprette en klient

Klienter er tilpassede applikasjoner eller skript som kommuniserer direkte med en MCP-server for å be om ressurser, verktøy og meldinger. I motsetning til å bruke inspeksjonsverktøyet, som gir en grafisk grensesnitt for å samhandle med serveren, gir det å skrive din egen klient mulighet for programmatiske og automatiserte interaksjoner. Dette gjør det mulig for utviklere å integrere MCP-funksjonalitet i sine egne arbeidsflyter, automatisere oppgaver og bygge tilpassede løsninger tilpasset spesifikke behov.

## Oversikt

Denne leksjonen introduserer konseptet med klienter innenfor Model Context Protocol (MCP) økosystemet. Du vil lære hvordan du skriver din egen klient og får den til å koble seg til en MCP-server.

## Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Forstå hva en klient kan gjøre.
- Skrive din egen klient.
- Koble til og teste klienten med en MCP-server for å sikre at den fungerer som forventet.

## Hva kreves for å skrive en klient?

For å skrive en klient må du gjøre følgende:

- **Importer de riktige bibliotekene**. Du vil bruke det samme biblioteket som før, bare med forskjellige konstruksjoner.
- **Instansiere en klient**. Dette vil innebære å opprette en klientinstans og koble den til den valgte transportmetoden.
- **Bestemme hvilke ressurser som skal listes**. Din MCP-server kommer med ressurser, verktøy og meldinger, du må bestemme hvilke du skal liste.
- **Integrere klienten i en vertsapplikasjon**. Når du kjenner til serverens funksjoner, må du integrere dette i vertsapplikasjonen slik at hvis en bruker skriver en melding eller annen kommando, blir den tilsvarende serverfunksjonen aktivert.

Nå som vi forstår på et overordnet nivå hva vi skal gjøre, la oss se på et eksempel neste.

### Et eksempel på en klient

La oss se på dette eksempelet på en klient:
Du er trent på data frem til oktober 2023.

I den foregående koden:

- Importerer vi bibliotekene
- Oppretter en instans av en klient og kobler den ved hjelp av stdio for transport.
- Lister meldinger, ressurser og verktøy og aktiverer dem alle.

Der har du det, en klient som kan snakke med en MCP-server.

La oss ta oss tid i neste øvelse seksjon og bryte ned hver kodebit og forklare hva som skjer.

## Øvelse: Skrive en klient

Som nevnt ovenfor, la oss ta oss tid til å forklare koden, og for all del, koden med hvis du vil.

### -1- Importere bibliotekene

La oss importere de bibliotekene vi trenger, vi vil trenge referanser til en klient og til vår valgte transportprotokoll, stdio. stdio er en protokoll for ting ment å kjøre på din lokale maskin. SSE er en annen transportprotokoll vi vil vise i fremtidige kapitler, men det er ditt andre alternativ. For nå, la oss fortsette med stdio.

La oss gå videre til instansiering.

### -2- Instansiere klient og transport

Vi må opprette en instans av transporten og en av klienten vår:

### -3- Liste serverfunksjonene

Nå har vi en klient som kan koble seg til hvis programmet kjøres. Imidlertid lister den ikke faktisk sine funksjoner, så la oss gjøre det neste:

Flott, nå har vi fanget opp alle funksjonene. Nå er spørsmålet når bruker vi dem? Vel, denne klienten er ganske enkel, enkel i den forstand at vi må eksplisitt kalle funksjonene når vi vil ha dem. I neste kapittel vil vi lage en mer avansert klient som har tilgang til sin egen store språkmodell, LLM. For nå, la oss se hvordan vi kan aktivere funksjonene på serveren:

### -4- Aktivere funksjoner

For å aktivere funksjonene må vi sikre at vi spesifiserer de riktige argumentene og i noen tilfeller navnet på det vi prøver å aktivere.

### -5- Kjøre klienten

For å kjøre klienten, skriv følgende kommando i terminalen:

## Oppgave

I denne oppgaven vil du bruke det du har lært om å opprette en klient, men lage en egen klient.

Her er en server du kan bruke som du trenger å kalle via klientkoden din, se om du kan legge til flere funksjoner på serveren for å gjøre den mer interessant.

## Løsning

[Løsning](./solution/README.md)

## Viktige punkter

De viktigste punktene for dette kapittelet om klienter er:

- Kan brukes både til å oppdage og aktivere funksjoner på serveren.
- Kan starte en server mens den starter seg selv (som i dette kapittelet), men klienter kan også koble seg til kjørende servere.
- Er en flott måte å teste ut serverens funksjoner på ved siden av alternativer som Inspektøren, som beskrevet i forrige kapittel.

## Ytterligere ressurser

- [Bygge klienter i MCP](https://modelcontextprotocol.io/quickstart/client)

## Eksempler

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Hva er neste

- Neste: [Opprette en klient med en LLM](/03-GettingStarted/03-llm-client/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi tilstreber nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.