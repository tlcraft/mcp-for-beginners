<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:30:39+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "nl"
}
-->
# MCP-servers implementeren

Het implementeren van je MCP-server maakt het mogelijk voor anderen om toegang te krijgen tot de tools en resources, ook buiten je lokale omgeving. Er zijn verschillende strategieën om te implementeren, afhankelijk van je wensen op het gebied van schaalbaarheid, betrouwbaarheid en gebruiksgemak. Hieronder vind je richtlijnen voor het lokaal implementeren van MCP-servers, in containers en in de cloud.

## Overzicht

Deze les behandelt hoe je je MCP Server-app kunt implementeren.

## Leerdoelen

Aan het einde van deze les kun je:

- Verschillende implementatie-aanpakken beoordelen.
- Je app implementeren.

## Lokale ontwikkeling en implementatie

Als je server bedoeld is om gebruikt te worden op de machine van de gebruiker, kun je de volgende stappen volgen:

1. **Download de server**. Als je de server niet zelf hebt geschreven, download deze dan eerst naar je machine.  
1. **Start het serverproces**: Start je MCP-serverapplicatie.

Voor SSE (niet nodig voor een stdio-type server)

1. **Configureer netwerk**: Zorg dat de server bereikbaar is op de verwachte poort.  
1. **Verbind clients**: Gebruik lokale verbindings-URL's zoals `http://localhost:3000`.

## Cloud-implementatie

MCP-servers kunnen op verschillende cloudplatformen worden geïmplementeerd:

- **Serverless Functions**: Implementeer lichte MCP-servers als serverless functies.  
- **Container Services**: Gebruik diensten zoals Azure Container Apps, AWS ECS of Google Cloud Run.  
- **Kubernetes**: Implementeer en beheer MCP-servers in Kubernetes-clusters voor hoge beschikbaarheid.

### Voorbeeld: Azure Container Apps

Azure Container Apps ondersteunen de implementatie van MCP-servers. Dit is nog in ontwikkeling en momenteel worden SSE-servers ondersteund.

Zo kun je te werk gaan:

1. Clone een repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Start het lokaal om het te testen:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Om het lokaal te proberen, maak een *mcp.json*-bestand aan in een *.vscode*-map en voeg de volgende inhoud toe:

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

  Zodra de SSE-server is gestart, kun je op het afspeel-icoon in het JSON-bestand klikken. Je zou nu de tools op de server moeten zien die door GitHub Copilot worden opgepikt, zie het Tool-icoon.

1. Om te implementeren, voer je het volgende commando uit:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Zo simpel is het: implementeer lokaal, of implementeer op Azure via deze stappen.

## Aanvullende bronnen

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Artikel over Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Wat is de volgende stap

- Volgende: [Praktische Implementatie](/04-PracticalImplementation/README.md)

**Disclaimer**:  
Dit document is vertaald met behulp van de AI-vertalingsdienst [Co-op Translator](https://github.com/Azure/co-op-translator). Hoewel we streven naar nauwkeurigheid, dient u er rekening mee te houden dat automatische vertalingen fouten of onjuistheden kunnen bevatten. Het oorspronkelijke document in de oorspronkelijke taal geldt als de gezaghebbende bron. Voor cruciale informatie wordt professionele menselijke vertaling aanbevolen. Wij zijn niet aansprakelijk voor misverstanden of verkeerde interpretaties die voortvloeien uit het gebruik van deze vertaling.