<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8ea28e5e566edd5969337fd0b191ba3f",
  "translation_date": "2025-07-17T06:45:12+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "no"
}
-->
# Bruke en server fra GitHub Copilot Agent-modus

Visual Studio Code og GitHub Copilot kan fungere som en klient og bruke en MCP-server. Du lurer kanskje på hvorfor vi skulle ønske å gjøre det? Vel, det betyr at alle funksjonene MCP-serveren har nå kan brukes direkte i IDE-en din. Tenk deg for eksempel at du legger til GitHubs MCP-server, dette vil gjøre det mulig å styre GitHub via tekstkommandoer i stedet for å skrive spesifikke kommandoer i terminalen. Eller tenk på alt mulig som kan forbedre utvikleropplevelsen din, alt styrt med naturlig språk. Nå begynner du å se fordelen, ikke sant?

## Oversikt

Denne leksjonen viser hvordan du bruker Visual Studio Code og GitHub Copilot sin Agent-modus som klient for din MCP-server.

## Læringsmål

Etter denne leksjonen skal du kunne:

- Bruke en MCP-server via Visual Studio Code.
- Kjøre funksjoner som verktøy via GitHub Copilot.
- Konfigurere Visual Studio Code til å finne og administrere din MCP-server.

## Bruk

Du kan styre MCP-serveren din på to forskjellige måter:

- Brukergrensesnitt, du vil se hvordan dette gjøres senere i dette kapitlet.
- Terminal, det er mulig å styre ting fra terminalen ved å bruke `code`-kommandoen:

  For å legge til en MCP-server i brukerprofilen din, bruk kommandolinjealternativet --add-mcp, og oppgi JSON-serverkonfigurasjonen i formen {\"name\":\"server-navn\",\"command\":...}.

  ```
  code --add-mcp "{\"name\":\"my-server\",\"command\": \"uvx\",\"args\": [\"mcp-server-fetch\"]}"
  ```

### Skjermbilder

![Veiledet MCP-serverkonfigurasjon i Visual Studio Code](../../../../translated_images/chat-mode-agent.729a22473f822216dd1e723aaee1f7d4a2ede571ee0948037a2d9357a63b9d0b.no.png)
![Verktøyvalg per agentøkt](../../../../translated_images/agent-mode-select-tools.522c7ba5df0848f8f0d1e439c2e96159431bc620cb39ccf3f5dc611412fd0006.no.png)
![Enkel feilsøking under MCP-utvikling](../../../../translated_images/mcp-list-servers.fce89eefe3f30032bed8952e110ab9d82fadf043fcfa071f7d40cf93fb1ea9e9.no.png)

La oss snakke mer om hvordan vi bruker det visuelle grensesnittet i de neste seksjonene.

## Tilnærming

Slik bør vi gå frem på et overordnet nivå:

- Konfigurer en fil for å finne MCP-serveren vår.
- Start/tilknytt deg serveren for å få den til å liste sine funksjoner.
- Bruk disse funksjonene gjennom GitHub Copilot Chat-grensesnittet.

Flott, nå som vi forstår flyten, la oss prøve å bruke en MCP-server gjennom Visual Studio Code i en øvelse.

## Øvelse: Bruke en server

I denne øvelsen skal vi konfigurere Visual Studio Code til å finne MCP-serveren din slik at den kan brukes fra GitHub Copilot Chat-grensesnittet.

### -0- Forberedelse, aktiver MCP Server discovery

Du må kanskje aktivere oppdagelse av MCP-servere.

1. Gå til `File -> Preferences -> Settings` i Visual Studio Code.

1. Søk etter "MCP" og aktiver `chat.mcp.discovery.enabled` i settings.json-filen.

### -1- Lag konfigurasjonsfil

Start med å lage en konfigurasjonsfil i prosjektets rotmappe, du trenger en fil som heter MCP.json og den må plasseres i en mappe som heter .vscode. Den skal se slik ut:

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

Her er et enkelt eksempel på hvordan du starter en server skrevet i Node.js, for andre kjøretidsmiljøer må du angi riktig kommando for å starte serveren ved å bruke `command` og `args`.

### -3- Start serveren

Nå som du har lagt til en oppføring, la oss starte serveren:

1. Finn oppføringen din i *mcp.json* og sørg for at du ser "play"-ikonet:

  ![Starter server i Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.no.png)  

1. Klikk på "play"-ikonet, du skal se at verktøyikonet i GitHub Copilot Chat øker antallet tilgjengelige verktøy. Hvis du klikker på verktøyikonet, vil du se en liste over registrerte verktøy. Du kan krysse av eller fjerne avkrysning for hvert verktøy avhengig av om du vil at GitHub Copilot skal bruke dem som kontekst:

  ![Starter server i Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.no.png)

1. For å kjøre et verktøy, skriv en prompt som du vet vil matche beskrivelsen av ett av verktøyene dine, for eksempel en prompt som "add 22 to 1":

  ![Kjører et verktøy fra GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.no.png)

  Du skal få et svar som sier 23.

## Oppgave

Prøv å legge til en serveroppføring i *mcp.json*-filen din og sørg for at du kan starte og stoppe serveren. Sørg også for at du kan kommunisere med verktøyene på serveren via GitHub Copilot Chat-grensesnittet.

## Løsning

[Solution](./solution/README.md)

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

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Hva nå

- Neste: [Creating an SSE Server](../05-sse-server/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiske oversettelser kan inneholde feil eller unøyaktigheter. Det opprinnelige dokumentet på originalspråket skal anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.