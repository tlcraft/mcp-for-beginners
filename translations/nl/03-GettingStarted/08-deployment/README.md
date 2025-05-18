<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:53:54+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "nl"
}
-->
# Het implementeren van MCP-servers

Het implementeren van je MCP-server stelt anderen in staat om toegang te krijgen tot de tools en middelen buiten je lokale omgeving. Er zijn verschillende implementatiestrategieën om te overwegen, afhankelijk van je eisen voor schaalbaarheid, betrouwbaarheid en gebruiksgemak. Hieronder vind je richtlijnen voor het implementeren van MCP-servers lokaal, in containers en naar de cloud.

## Overzicht

Deze les behandelt hoe je je MCP Server-app kunt implementeren.

## Leerdoelen

Aan het einde van deze les kun je:

- Verschillende implementatiebenaderingen evalueren.
- Je app implementeren.

## Lokale ontwikkeling en implementatie

Als je server bedoeld is om op de computer van de gebruiker te draaien, kun je de volgende stappen volgen:

1. **Download de server**. Als je de server niet zelf hebt geschreven, download deze dan eerst naar je machine.
1. **Start het serverproces**: Voer je MCP-serverapplicatie uit.

Voor SSE (niet nodig voor stdio type server)

1. **Netwerkconfiguratie**: Zorg ervoor dat de server toegankelijk is op de verwachte poort.
1. **Verbind clients**: Gebruik lokale verbindings-URL's zoals `http://localhost:3000`

## Cloudimplementatie

MCP-servers kunnen op verschillende cloudplatforms worden geïmplementeerd:

- **Serverloze Functies**: Implementeer lichte MCP-servers als serverloze functies.
- **Containerdiensten**: Gebruik diensten zoals Azure Container Apps, AWS ECS, of Google Cloud Run.
- **Kubernetes**: Implementeer en beheer MCP-servers in Kubernetes-clusters voor hoge beschikbaarheid.

### Voorbeeld: Azure Container Apps

Azure Container Apps ondersteunen de implementatie van MCP Servers. Het is nog in ontwikkeling en ondersteunt momenteel SSE-servers.

Hier is hoe je het kunt aanpakken:

1. Clone een repository:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Voer het lokaal uit om dingen uit te testen:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Om het lokaal te proberen, maak een *mcp.json* bestand in een *.vscode* directory en voeg de volgende inhoud toe:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  Zodra de SSE-server is gestart, kun je op het afspeelicoon in het JSON-bestand klikken, je zou nu moeten zien dat tools op de server worden opgepikt door GitHub Copilot, zie het Tool-icoon.

1. Om te implementeren, voer je het volgende commando uit:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Daar heb je het, implementeer het lokaal, implementeer het naar Azure via deze stappen.

## Aanvullende bronnen

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps artikel](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Wat volgt

- Volgende: [Praktische Implementatie](/04-PracticalImplementation/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u zich ervan bewust te zijn dat geautomatiseerde vertalingen fouten of onnauwkeurigheden kunnen bevatten. Het oorspronkelijke document in zijn oorspronkelijke taal moet worden beschouwd als de gezaghebbende bron. Voor kritieke informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor eventuele misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.