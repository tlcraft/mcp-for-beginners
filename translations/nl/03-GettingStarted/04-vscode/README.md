<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "54e9ffc5dba01afcb8880a9949fd1881",
  "translation_date": "2025-07-13T19:31:57+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "nl"
}
-->
Laten we in de volgende secties dieper ingaan op het gebruik van de visuele interface.

## Aanpak

Dit is hoe we het op hoofdlijnen moeten aanpakken:

- Een bestand configureren om onze MCP Server te vinden.
- De server opstarten/verbinden zodat deze zijn mogelijkheden kan tonen.
- Deze mogelijkheden gebruiken via de GitHub Copilot Chat interface.

Geweldig, nu we de flow begrijpen, laten we proberen een MCP Server te gebruiken via Visual Studio Code met een oefening.

## Oefening: Een server gebruiken

In deze oefening configureren we Visual Studio Code zodat het jouw MCP server kan vinden en gebruiken via de GitHub Copilot Chat interface.

### -0- Voorbereiding, MCP Server ontdekking inschakelen

Je moet mogelijk de ontdekking van MCP Servers inschakelen.

1. Ga naar `Bestand -> Voorkeuren -> Instellingen` in Visual Studio Code.

1. Zoek op "MCP" en schakel `chat.mcp.discovery.enabled` in in het settings.json bestand.

### -1- Configuratiebestand aanmaken

Begin met het aanmaken van een configuratiebestand in de root van je project. Je hebt een bestand nodig genaamd MCP.json dat je plaatst in een map genaamd .vscode. Het zou er als volgt uit moeten zien:

```text
.vscode
|-- mcp.json
```

Laten we nu zien hoe we een server kunnen toevoegen.

### -2- Server configureren

Voeg de volgende inhoud toe aan *mcp.json*:

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

Hierboven zie je een eenvoudig voorbeeld van het starten van een server geschreven in Node.js. Voor andere runtimes geef je het juiste commando op om de server te starten met `command` en `args`.

### -3- Server starten

Nu je een entry hebt toegevoegd, starten we de server:

1. Zoek je entry in *mcp.json* en zorg dat je het "play" icoon ziet:

  ![Server starten in Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.nl.png)  

1. Klik op het "play" icoon, je zou moeten zien dat het tools-icoon in GitHub Copilot Chat het aantal beschikbare tools verhoogt. Als je op dat tools-icoon klikt, zie je een lijst met geregistreerde tools. Je kunt elke tool aan- of uitvinken afhankelijk van of je wilt dat GitHub Copilot deze als context gebruikt:

  ![Server starten in Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.nl.png)

1. Om een tool te gebruiken, typ je een prompt waarvan je weet dat die overeenkomt met de beschrijving van een van je tools, bijvoorbeeld een prompt als "add 22 to 1":

  ![Een tool gebruiken vanuit GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.nl.png)

  Je zou een antwoord moeten zien met het getal 23.

## Opdracht

Probeer een server entry toe te voegen aan je *mcp.json* bestand en zorg dat je de server kunt starten en stoppen. Zorg er ook voor dat je via de GitHub Copilot Chat interface kunt communiceren met de tools op je server.

## Oplossing

[Oplossing](./solution/README.md)

## Belangrijkste punten

De belangrijkste punten uit dit hoofdstuk zijn:

- Visual Studio Code is een uitstekende client waarmee je meerdere MCP Servers en hun tools kunt gebruiken.
- De GitHub Copilot Chat interface is hoe je met de servers communiceert.
- Je kunt de gebruiker om invoer vragen, zoals API-sleutels, die je kunt doorgeven aan de MCP Server bij het configureren van de server entry in het *mcp.json* bestand.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Extra bronnen

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Wat volgt

- Volgende: [Een SSE Server maken](../05-sse-server/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal moet als de gezaghebbende bron worden beschouwd. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.