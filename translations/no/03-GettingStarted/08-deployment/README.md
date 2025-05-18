<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:53:26+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "no"
}
-->
# Distribuere MCP-servere

Distribuering av MCP-serveren din lar andre få tilgang til verktøyene og ressursene utenfor ditt lokale miljø. Det finnes flere distribueringsstrategier å vurdere, avhengig av dine krav til skalerbarhet, pålitelighet og enkel administrasjon. Nedenfor finner du veiledning for å distribuere MCP-servere lokalt, i containere og til skyen.

## Oversikt

Denne leksjonen dekker hvordan du distribuerer MCP Server-appen din.

## Læringsmål

På slutten av denne leksjonen vil du kunne:

- Vurdere forskjellige distribueringsmetoder.
- Distribuere appen din.

## Lokal utvikling og distribusjon

Hvis serveren din er ment å bli brukt ved å kjøre på brukernes maskin, kan du følge følgende trinn:

1. **Last ned serveren**. Hvis du ikke har skrevet serveren, last den først ned til maskinen din.
1. **Start serverprosessen**: Kjør MCP-serverapplikasjonen din.

For SSE (ikke nødvendig for stdio-type server)

1. **Konfigurer nettverk**: Sørg for at serveren er tilgjengelig på den forventede porten.
1. **Koble til klienter**: Bruk lokale tilkoblings-URLer som `http://localhost:3000`.

## Skydistribusjon

MCP-servere kan distribueres til forskjellige skyplattformer:

- **Serverløse funksjoner**: Distribuer lette MCP-servere som serverløse funksjoner.
- **Container-tjenester**: Bruk tjenester som Azure Container Apps, AWS ECS eller Google Cloud Run.
- **Kubernetes**: Distribuer og administrer MCP-servere i Kubernetes-klynger for høy tilgjengelighet.

### Eksempel: Azure Container Apps

Azure Container Apps støtter distribusjon av MCP-servere. Det er fortsatt under utvikling og støtter for øyeblikket SSE-servere.

Slik går du frem:

1. Klon et repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Kjør det lokalt for å teste ting ut:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. For å prøve det lokalt, opprett en *mcp.json* fil i en *.vscode* katalog og legg til følgende innhold:

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

  Når SSE-serveren er startet, kan du klikke på spilleikonet i JSON-filen, du bør nå se verktøyene på serveren bli plukket opp av GitHub Copilot, se verktøyikonet.

1. For å distribuere, kjør følgende kommando:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Der har du det, distribuer det lokalt, distribuer det til Azure gjennom disse trinnene.

## Ytterligere ressurser

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps-artikkel](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP-repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Hva er neste

- Neste: [Praktisk implementering](/04-PracticalImplementation/README.md)

**Ansvarsfraskrivelse**:  
Dette dokumentet er oversatt ved hjelp av AI-oversettelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selv om vi streber etter nøyaktighet, vennligst vær oppmerksom på at automatiserte oversettelser kan inneholde feil eller unøyaktigheter. Det originale dokumentet på sitt opprinnelige språk bør anses som den autoritative kilden. For kritisk informasjon anbefales profesjonell menneskelig oversettelse. Vi er ikke ansvarlige for eventuelle misforståelser eller feiltolkninger som oppstår ved bruk av denne oversettelsen.