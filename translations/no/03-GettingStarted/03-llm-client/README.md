<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:32:38+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "no"
}
-->
Flott, for neste steg la oss liste opp kapasitetene på serveren.

### -2 List serverkapasiteter

Nå skal vi koble til serveren og be om dens kapasiteter:

### -3- Konverter serverkapasiteter til LLM-verktøy

Neste steg etter å ha listet opp serverkapasitetene er å konvertere dem til et format som LLM forstår. Når vi gjør det, kan vi tilby disse kapasitetene som verktøy til LLM-en vår.

Flott, nå er vi klare til å håndtere brukerforespørsler, så la oss ta tak i det neste.

### -4- Håndter brukerprompt-forespørsel

I denne delen av koden skal vi håndtere brukerforespørsler.

Flott, du klarte det!

## Oppgave

Ta koden fra øvelsen og bygg ut serveren med flere verktøy. Lag deretter en klient med en LLM, som i øvelsen, og test det med ulike prompts for å sikre at alle serververktøyene dine blir kalt dynamisk. Denne måten å bygge en klient på gir sluttbrukeren en god brukeropplevelse, siden de kan bruke naturlige språk-prompt i stedet for eksakte klientkommandoer, og de trenger ikke være klar over at en MCP-server blir kalt.

## Løsning

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Viktige punkter

- Å legge til en LLM i klienten gir en bedre måte for brukere å interagere med MCP-servere på.
- Du må konvertere MCP-serverens respons til noe LLM-en kan forstå.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ekstra ressurser

## Hva nå

- Neste: [Bruke en server med Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket bør betraktes som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.