<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:53:05+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "no"
}
-->
Flott, for vårt neste steg, la oss liste opp kapabilitetene på serveren.

### -2 List serverkapabiliteter

Nå skal vi koble til serveren og spørre om dens kapabiliteter:

### -3- Konverter serverkapabiliteter til LLM-verktøy

Neste steg etter å ha listet opp serverkapabiliteter er å konvertere dem til et format som LLM forstår. Når vi har gjort det, kan vi tilby disse kapabilitetene som verktøy til vår LLM.

Flott, nå er vi klare til å håndtere brukerforespørsler, så la oss ta tak i det neste.

### -4- Håndter brukerprompt-forespørsel

I denne delen av koden skal vi håndtere brukerforespørsler.

Flott, du klarte det!

## Oppgave

Ta koden fra øvelsen og bygg ut serveren med flere verktøy. Deretter lager du en klient med en LLM, som i øvelsen, og tester den med forskjellige prompts for å sikre at alle serververktøyene dine blir kalt dynamisk. Denne måten å bygge en klient på gir sluttbrukeren en god brukeropplevelse, siden de kan bruke naturlige språk-prompt i stedet for eksakte klientkommandoer, og de trenger ikke å vite at en MCP-server blir kalt.

## Løsning

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Viktige punkter

- Å legge til en LLM i klienten din gir en bedre måte for brukere å samhandle med MCP-servere på.
- Du må konvertere MCP-serverens respons til noe LLM kan forstå.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ytterligere ressurser

## Hva er neste

- Neste: [Bruke en server med Visual Studio Code](../04-vscode/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.