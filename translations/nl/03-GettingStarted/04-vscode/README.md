<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0eb9557780cd0a2551cdb8a16c886b51",
  "translation_date": "2025-06-17T15:56:51+00:00",
  "source_file": "03-GettingStarted/04-vscode/README.md",
  "language_code": "nl"
}
-->
Laten we in de volgende secties dieper ingaan op het gebruik van de visuele interface.

## Aanpak

Dit is hoe we dit op hoofdlijnen moeten aanpakken:

- Configureer een bestand om onze MCP Server te vinden.
- Start/maak verbinding met de genoemde server om een lijst met mogelijkheden te krijgen.
- Gebruik deze mogelijkheden via de GitHub Copilot Chat interface.

Goed, nu we de flow begrijpen, laten we een MCP Server proberen te gebruiken via Visual Studio Code met een oefening.

## Oefening: Een server gebruiken

In deze oefening configureren we Visual Studio Code om jouw MCP server te vinden zodat deze gebruikt kan worden vanuit de GitHub Copilot Chat interface.

### -0- Voorbereiding, MCP Server ontdekking inschakelen

Het kan zijn dat je het ontdekken van MCP Servers moet inschakelen.

1. Ga naar `File -> Preferences -> Settings` en zoek naar `` in Visual Studio Code.

1. Search for "MCP" and enable `chat.mcp.discovery.enabled` in het settings.json bestand.

### -1- Configuratiebestand aanmaken

Begin met het aanmaken van een configuratiebestand in de root van je project. Je hebt een bestand nodig genaamd MCP.json dat je plaatst in een map genaamd .vscode. Het zou er ongeveer zo uit moeten zien:

```text
.vscode
|-- mcp.json
```

Vervolgens bekijken we hoe je een server kunt toevoegen.

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

Hierboven zie je een eenvoudig voorbeeld van hoe je een server start die in Node.js is geschreven. Voor andere runtimes geef je het juiste commando aan om de server te starten met `command` and `args`.

### -3- Server starten

Nu je een invoer hebt toegevoegd, starten we de server:

1. Zoek je invoer in *mcp.json* en zorg dat je het "play"-icoon ziet:

  ![Server starten in Visual Studio Code](../../../../translated_images/vscode-start-server.8e3c986612e3555de47e5b1e37b2f3020457eeb6a206568570fd74a17e3796ad.nl.png)  

2. Klik op het "play"-icoon, je zou moeten zien dat het tools-icoon in GitHub Copilot Chat het aantal beschikbare tools vergroot. Klik je op dit tools-icoon, dan zie je een lijst met geregistreerde tools. Je kunt per tool aanvinken of afvinken of je wilt dat GitHub Copilot deze gebruikt als context:

  ![Server starten in Visual Studio Code](../../../../translated_images/vscode-tool.0b3bbea2fb7d8c26ddf573cad15ef654e55302a323267d8ee6bd742fe7df7fed.nl.png)

3. Om een tool te gebruiken, typ je een prompt waarvan je weet dat die overeenkomt met de beschrijving van een van je tools, bijvoorbeeld een prompt als "add 22 to 1":

  ![Een tool gebruiken vanuit GitHub Copilot](../../../../translated_images/vscode-agent.d5a0e0b897331060518fe3f13907677ef52b879db98c64d68a38338608f3751e.nl.png)

  Je zou een antwoord moeten zien met het getal 23.

## Opdracht

Probeer een serverinvoer toe te voegen aan je *mcp.json* bestand en zorg dat je de server kunt starten en stoppen. Zorg er ook voor dat je via de GitHub Copilot Chat interface kunt communiceren met de tools op je server.

## Oplossing

[Oplossing](./solution/README.md)

## Belangrijkste punten

De belangrijkste punten uit dit hoofdstuk zijn:

- Visual Studio Code is een uitstekende client waarmee je meerdere MCP Servers en hun tools kunt gebruiken.
- De GitHub Copilot Chat interface is de manier waarop je met de servers communiceert.
- Je kunt gebruikers om invoer vragen, zoals API-sleutels, die meegegeven kunnen worden aan de MCP Server bij het configureren van de serverinvoer in het *mcp.json* bestand.

## Voorbeelden

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Extra bronnen

- [Visual Studio docs](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)

## Wat volgt hierna

- Volgende: [Een SSE Server maken](/03-GettingStarted/05-sse-server/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel wij streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het originele document in de oorspronkelijke taal geldt als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.