<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:22:56+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "no"
}
-->
# Lage en klient med LLM

Så langt har du sett hvordan man lager en server og en klient. Klienten har vært i stand til å kalle serveren eksplisitt for å liste opp verktøyene, ressursene og promptene. Men dette er ikke en veldig praktisk tilnærming. Din bruker lever i den agentiske æraen og forventer å bruke prompts og kommunisere med en LLM for å gjøre dette. For brukeren din spiller det ingen rolle om du bruker MCP eller ikke for å lagre dine kapabiliteter, men de forventer å bruke naturlig språk for å interagere. Så hvordan løser vi dette? Løsningen er å legge til en LLM i klienten.

## Oversikt

I denne leksjonen fokuserer vi på å legge til en LLM til klienten din og viser hvordan dette gir en mye bedre opplevelse for brukeren din.

## Læringsmål

Ved slutten av denne leksjonen vil du kunne:

- Lage en klient med en LLM.
- Sømløst interagere med en MCP-server ved bruk av en LLM.
- Gi en bedre sluttbrukeropplevelse på klientsiden.

## Tilnærming

La oss prøve å forstå tilnærmingen vi må ta. Å legge til en LLM høres enkelt ut, men hvordan gjør vi egentlig dette?

Slik vil klienten interagere med serveren:

1. Etablere forbindelse med serveren.

2. Liste opp kapabiliteter, prompts, ressurser og verktøy, og lagre deres skjema.

3. Legge til en LLM og sende de lagrede kapabilitetene og deres skjema i et format LLM-en forstår.

4. Håndtere en brukerprompt ved å sende den til LLM-en sammen med verktøyene som er listet av klienten.

Flott, nå forstår vi hvordan vi kan gjøre dette på et overordnet nivå, la oss prøve dette i øvelsen nedenfor.

## Øvelse: Lage en klient med en LLM

I denne øvelsen skal vi lære å legge til en LLM til klienten vår.

### -1- Koble til serveren

La oss lage klienten vår først:
Du er trent på data frem til oktober 2023.

Flott, for neste steg, la oss liste opp kapabilitetene på serveren.

### -2 Liste serverkapabiliteter

Nå vil vi koble til serveren og be om dens kapabiliteter:

### -3- Konvertere serverkapabiliteter til LLM-verktøy

Neste steg etter å ha listet serverkapabiliteter er å konvertere dem til et format som LLM-en forstår. Når vi gjør det, kan vi gi disse kapabilitetene som verktøy til vår LLM.

Flott, vi er nå satt opp til å håndtere alle brukerforespørsler, så la oss takle det neste.

### -4- Håndtere brukerpromptforespørsel

I denne delen av koden vil vi håndtere brukerforespørsler.

Flott, du klarte det!

## Oppgave

Ta koden fra øvelsen og bygg ut serveren med noen flere verktøy. Lag deretter en klient med en LLM, som i øvelsen, og test den ut med forskjellige prompts for å sikre at alle serververktøyene dine blir kalt dynamisk. Denne måten å bygge en klient på betyr at sluttbrukeren vil ha en flott brukeropplevelse, da de kan bruke prompts i stedet for eksakte klientkommandoer, og være uvitende om at en MCP-server blir kalt.

## Løsning

[Løsning](/03-GettingStarted/03-llm-client/solution/README.md)

## Viktige punkter

- Å legge til en LLM til klienten din gir en bedre måte for brukere å interagere med MCP-servere.
- Du må konvertere MCP-serverens svar til noe LLM-en kan forstå.

## Eksempler

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Tilleggsressurser

## Hva er neste

- Neste: [Konsumere en server ved bruk av Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår fra bruken av denne oversettelsen.