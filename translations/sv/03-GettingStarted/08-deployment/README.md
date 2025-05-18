<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:53:05+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "sv"
}
-->
# Distribuera MCP-servrar

Att distribuera din MCP-server gör det möjligt för andra att få tillgång till dess verktyg och resurser utanför din lokala miljö. Det finns flera distributionsstrategier att överväga, beroende på dina krav på skalbarhet, tillförlitlighet och enkel hantering. Nedan hittar du vägledning för att distribuera MCP-servrar lokalt, i containrar och till molnet.

## Översikt

Denna lektion handlar om hur du distribuerar din MCP Server-app.

## Lärandemål

I slutet av denna lektion kommer du att kunna:

- Utvärdera olika distributionsmetoder.
- Distribuera din app.

## Lokal utveckling och distribution

Om din server är avsedd att användas genom att köras på användarnas datorer kan du följa dessa steg:

1. **Ladda ner servern**. Om du inte har skrivit servern själv, ladda ner den först till din dator.
1. **Starta serverprocessen**: Kör din MCP-serverapplikation

För SSE (inte nödvändigt för stdio-typ server)

1. **Konfigurera nätverk**: Se till att servern är tillgänglig på den förväntade porten
1. **Anslut klienter**: Använd lokala anslutnings-URL:er som `http://localhost:3000`

## Molndistribution

MCP-servrar kan distribueras till olika molnplattformar:

- **Serverlösa funktioner**: Distribuera lättviktiga MCP-servrar som serverlösa funktioner
- **Container Services**: Använd tjänster som Azure Container Apps, AWS ECS eller Google Cloud Run
- **Kubernetes**: Distribuera och hantera MCP-servrar i Kubernetes-kluster för hög tillgänglighet

### Exempel: Azure Container Apps

Azure Container Apps stöder distribution av MCP-servrar. Det är fortfarande under utveckling och stöder för närvarande SSE-servrar.

Så här kan du gå tillväga:

1. Klona ett repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Kör det lokalt för att testa saker:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. För att prova det lokalt, skapa en *mcp.json* fil i en *.vscode* katalog och lägg till följande innehåll:

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

  När SSE-servern är startad kan du klicka på spela-ikonen i JSON-filen, du bör nu se verktyg på servern tas upp av GitHub Copilot, se verktygsikonen.

1. För att distribuera, kör följande kommando:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Där har du det, distribuera det lokalt, distribuera det till Azure genom dessa steg.

## Ytterligare resurser

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Artikel om Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP-repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Vad händer härnäst

- Nästa: [Praktisk implementering](/04-PracticalImplementation/README.md)

**Ansvarsfriskrivning**:  
Detta dokument har översatts med hjälp av AI-översättningstjänsten [Co-op Translator](https://github.com/Azure/co-op-translator). Även om vi strävar efter noggrannhet, var medveten om att automatiska översättningar kan innehålla fel eller oriktigheter. Det ursprungliga dokumentet på dess modersmål bör betraktas som den auktoritativa källan. För kritisk information rekommenderas professionell mänsklig översättning. Vi ansvarar inte för eventuella missförstånd eller feltolkningar som uppstår vid användning av denna översättning.