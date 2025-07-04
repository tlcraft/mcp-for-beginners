<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-04T17:40:12+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "da"
}
-->
Lad os tale mere om, hvordan vi bruger den visuelle grænseflade i de næste afsnit.

## Fremgangsmåde

Her er, hvordan vi skal gribe det an på et overordnet plan:

- Konfigurer en fil til at finde vores MCP Server.
- Start/opret forbindelse til den nævnte server for at få den til at liste sine funktioner.
- Brug disse funktioner gennem GitHub Copilot Chat-grænsefladen.

Fint, nu hvor vi forstår flowet, lad os prøve at bruge en MCP Server gennem Visual Studio Code via en øvelse.

## Øvelse: Forbruge en server

I denne øvelse vil vi konfigurere Visual Studio Code til at finde din MCP server, så den kan bruges fra GitHub Copilot Chat-grænsefladen.

### -0- Forberedelse, aktiver MCP Server-opdagelse

Du skal muligvis aktivere opdagelse af MCP Servere.

1. Gå til `File -> Preferences -> Settings` i Visual Studio Code.

1. Søg efter "MCP" og aktiver `chat.mcp.discovery.enabled` i settings.json-filen.

### -1- Opret konfigurationsfil

Start med at oprette en konfigurationsfil i dit projektrod, du skal bruge en fil kaldet MCP.json og placere den i en mappe kaldet .vscode. Den skal se sådan ud:

```text
.vscode
|-- mcp.json
```

Lad os nu se, hvordan vi kan tilføje en serverpost.

### -2- Konfigurer en server

Tilføj følgende indhold til *mcp.json*:

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

Her er et simpelt eksempel ovenfor på, hvordan man starter en server skrevet i Node.js. For andre runtime-miljøer angiv den korrekte kommando til at starte serveren ved hjælp af `command` og `args`.

### -3- Start serveren

Nu hvor du har tilføjet en post, lad os starte serveren:

1. Find din post i *mcp.json* og sørg for, at du kan se "play"-ikonet:

  ![Starting server in Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.da.png)  

1. Klik på "play"-ikonet, du skulle nu se, at værktøjsikonet i GitHub Copilot Chat øger antallet af tilgængelige værktøjer. Hvis du klikker på dette værktøjsikon, vil du se en liste over registrerede værktøjer. Du kan markere/afmarkere hvert værktøj afhængigt af, om du vil have GitHub Copilot til at bruge dem som kontekst:

  ![Starting server in Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.da.png)

1. For at køre et værktøj, skriv en prompt, som du ved vil matche beskrivelsen af et af dine værktøjer, for eksempel en prompt som "add 22 to 1":

  ![Running a tool from GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.da.png)

  Du skulle se et svar, der siger 23.

## Opgave

Prøv at tilføje en serverpost til din *mcp.json*-fil og sørg for, at du kan starte/stoppe serveren. Sørg også for, at du kan kommunikere med værktøjerne på din server via GitHub Copilot Chat-grænsefladen.

## Løsning

[Solution](./solution/README.md)

## Vigtige pointer

De vigtigste pointer fra dette kapitel er følgende:

- Visual Studio Code er en fremragende klient, der lader dig forbruge flere MCP Servere og deres værktøjer.
- GitHub Copilot Chat-grænsefladen er, hvordan du interagerer med serverne.
- Du kan bede brugeren om input som API-nøgler, der kan sendes til MCP Serveren, når du konfigurerer serverposten i *mcp.json*-filen.

## Eksempler

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Yderligere ressourcer

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Hvad er det næste

- Næste: [Creating an SSE Server](../05-sse-server/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, bedes du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det oprindelige dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi påtager os intet ansvar for misforståelser eller fejltolkninger, der opstår som følge af brugen af denne oversættelse.