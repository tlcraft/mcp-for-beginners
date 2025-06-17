<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T15:53:49+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "no"
}
-->
La oss snakke mer om hvordan vi bruker det visuelle grensesnittet i de neste seksjonene.

## Tilnærming

Slik bør vi angripe dette på et overordnet nivå:

- Konfigurer en fil for å finne MCP-serveren vår.
- Start opp/ Koble til den nevnte serveren for å få den til å liste opp sine funksjoner.
- Bruk disse funksjonene gjennom GitHub Copilot Chat-grensesnittet.

Flott, nå som vi forstår flyten, la oss prøve å bruke en MCP-server gjennom Visual Studio Code i en øvelse.

## Øvelse: Bruke en server

I denne øvelsen skal vi konfigurere Visual Studio Code til å finne MCP-serveren din slik at den kan brukes fra GitHub Copilot Chat-grensesnittet.

### -0- Forberedelse, aktiver MCP Server discovery

Du må kanskje aktivere oppdagelse av MCP-servere.

1. Gå til `File -> Preferences -> Settings` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` i settings.json-filen.

### -1- Lag konfigurasjonsfil

Start med å lage en konfigurasjonsfil i prosjektets rotmappe. Du trenger en fil kalt MCP.json som skal plasseres i en mappe som heter .vscode. Den skal se slik ut:

```text
.vscode
|-- mcp.json
```

Neste steg er å se hvordan vi kan legge til en serveroppføring.

### -2- Konfigurer en server

Legg til følgende innhold i *mcp.json*:

```json
{
    "inputs": [],
    "servers": {
       "hello-mcp": {
           "command": "node",
           "args": [
               "build/index.js"
           ]
       }
    }
}
```

Her er et enkelt eksempel på hvordan du starter en server skrevet i Node.js. For andre kjøretidsmiljøer må du spesifisere riktig kommando for å starte serveren ved å bruke `command` and `args`.

### -3- Start serveren

Nå som du har lagt til en oppføring, la oss starte serveren:

1. Finn oppføringen din i *mcp.json* og sørg for at du ser "play"-ikonet:

  ![Starter server i Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.no.png)  

2. Klikk på "play"-ikonet. Du bør se at verktøyikonet i GitHub Copilot Chat øker antall tilgjengelige verktøy. Hvis du klikker på verktøyikonet, vil du se en liste over registrerte verktøy. Du kan krysse av eller fjerne avkrysning for hvert verktøy, avhengig av om du vil at GitHub Copilot skal bruke dem som kontekst:

  ![Verktøy i Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.no.png)

3. For å kjøre et verktøy, skriv inn en prompt som du vet vil matche beskrivelsen av et av verktøyene dine, for eksempel en prompt som "add 22 to 1":

  ![Kjøre et verktøy fra GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.no.png)

  Du bør se et svar som sier 23.

## Oppgave

Prøv å legge til en serveroppføring i *mcp.json*-filen din og sørg for at du kan starte og stoppe serveren. Sørg også for at du kan kommunisere med verktøyene på serveren via GitHub Copilot Chat-grensesnittet.

## Løsning

[Løsning](./solution/README.md)

## Viktige punkter

Hovedpunktene fra dette kapitlet er:

- Visual Studio Code er en flott klient som lar deg bruke flere MCP-servere og deres verktøy.
- GitHub Copilot Chat-grensesnittet er hvordan du samhandler med serverne.
- Du kan be brukeren om input som API-nøkler som kan sendes til MCP-serveren når du konfigurerer serveroppføringen i *mcp.json*-filen.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Ekstra ressurser

- [Visual Studio-dokumentasjon](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Hva skjer videre

- Neste: [Opprette en SSE Server](/03-GettingStarted/05-sse-server/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.