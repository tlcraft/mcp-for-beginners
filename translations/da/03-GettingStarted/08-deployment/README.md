<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:53:15+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "da"
}
-->
# Udrulning af MCP-servere

Udrulning af din MCP-server giver andre adgang til dens værktøjer og ressourcer ud over din lokale miljø. Der er flere udrulningsstrategier at overveje, afhængigt af dine krav til skalerbarhed, pålidelighed og nem administration. Nedenfor finder du vejledning til udrulning af MCP-servere lokalt, i containere og til skyen.

## Oversigt

Denne lektion dækker, hvordan du udruller din MCP-server-app.

## Læringsmål

Ved afslutningen af denne lektion vil du være i stand til at:

- Vurdere forskellige udrulningsmetoder.
- Udrulle din app.

## Lokal udvikling og udrulning

Hvis din server er beregnet til at blive brugt ved at køre på brugerens maskine, kan du følge følgende trin:

1. **Download serveren**. Hvis du ikke har skrevet serveren, skal du først downloade den til din maskine.
1. **Start serverprocessen**: Kør din MCP-serverapplikation

For SSE (ikke nødvendigt for stdio type server)

1. **Konfigurer netværk**: Sørg for, at serveren er tilgængelig på den forventede port
1. **Forbind klienter**: Brug lokale forbindelses-URLs som `http://localhost:3000`

## Skyudrulning

MCP-servere kan udrulles til forskellige skyplatforme:

- **Serverløse funktioner**: Udrul lette MCP-servere som serverløse funktioner
- **Containerservices**: Brug tjenester som Azure Container Apps, AWS ECS eller Google Cloud Run
- **Kubernetes**: Udrul og administrer MCP-servere i Kubernetes-klynger for høj tilgængelighed

### Eksempel: Azure Container Apps

Azure Container Apps understøtter udrulning af MCP-servere. Det er stadig under udvikling, og det understøtter i øjeblikket SSE-servere.

Sådan kan du gøre det:

1. Klon et repository:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Kør det lokalt for at teste tingene:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. For at prøve det lokalt, opret en *mcp.json* fil i en *.vscode* mappe og tilføj følgende indhold:

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

  Når SSE-serveren er startet, kan du klikke på play-ikonet i JSON-filen, og du bør nu se værktøjer på serveren blive opfanget af GitHub Copilot, se værktøjsikonet.

1. For at udrulle, kør følgende kommando:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Sådan er det, udrul det lokalt, udrul det til Azure gennem disse trin.

## Yderligere ressourcer

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps artikel](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Hvad er det næste

- Næste: [Praktisk Implementering](/04-PracticalImplementation/README.md)

**Ansvarsfraskrivelse**:  
Dette dokument er blevet oversat ved hjælp af AI-oversættelsestjenesten [Co-op Translator](https://github.com/Azure/co-op-translator). Selvom vi bestræber os på nøjagtighed, skal du være opmærksom på, at automatiserede oversættelser kan indeholde fejl eller unøjagtigheder. Det originale dokument på dets oprindelige sprog bør betragtes som den autoritative kilde. For kritisk information anbefales professionel menneskelig oversættelse. Vi er ikke ansvarlige for eventuelle misforståelser eller fejltolkninger, der opstår ved brugen af denne oversættelse.