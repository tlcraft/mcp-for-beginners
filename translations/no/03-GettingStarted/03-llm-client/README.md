<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:31:08+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "no"
}
-->
Flott, for vårt neste steg, la oss liste opp kapasitetene på serveren.

### -2 List serverkapasiteter

Nå skal vi koble til serveren og spørre om dens kapasiteter:

### -3- Konverter serverkapasiteter til LLM-verktøy

Neste steg etter å ha listet serverkapasitetene er å konvertere dem til et format som LLM forstår. Når vi har gjort det, kan vi tilby disse kapasitetene som verktøy til vår LLM.

Flott, nå er vi klare til å håndtere brukerforespørsler, så la oss ta for oss det neste.

### -4- Håndter brukerforespørsel

I denne delen av koden skal vi håndtere brukerforespørsler.

Flott, du klarte det!

## Oppgave

Ta koden fra øvelsen og bygg ut serveren med flere verktøy. Deretter lager du en klient med en LLM, som i øvelsen, og tester den med ulike prompt for å sikre at alle serververktøyene dine blir kalt dynamisk. Denne måten å bygge en klient på gir sluttbrukeren en god brukeropplevelse, siden de kan bruke naturlige språk-prompt i stedet for eksakte klientkommandoer, uten å være klar over at en MCP-server blir kalt.

## Løsning

[Løsning](/03-GettingStarted/03-llm-client/solution/README.md)

## Viktige punkter

- Å legge til en LLM i klienten din gir en bedre måte for brukere å samhandle med MCP-servere på.
- Du må konvertere MCP-serverens respons til noe LLM kan forstå.

## Eksempler

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Ekstra ressurser

## Hva kommer nå

- Neste: [Konsumere en server med Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på dets opprinnelige språk skal betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår fra bruk av denne oversettelsen.