<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:52:10+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "it"
}
-->
# Distribuzione dei server MCP

Distribuire il tuo server MCP consente ad altri di accedere ai suoi strumenti e risorse al di fuori del tuo ambiente locale. Esistono diverse strategie di distribuzione da considerare, a seconda delle tue esigenze di scalabilità, affidabilità e facilità di gestione. Di seguito troverai indicazioni per distribuire i server MCP localmente, in container e nel cloud.

## Panoramica

Questa lezione copre come distribuire la tua applicazione server MCP.

## Obiettivi di apprendimento

Alla fine di questa lezione, sarai in grado di:

- Valutare diversi approcci di distribuzione.
- Distribuire la tua applicazione.

## Sviluppo e distribuzione locale

Se il tuo server è destinato a essere utilizzato eseguendolo sul computer degli utenti, puoi seguire i seguenti passaggi:

1. **Scarica il server**. Se non hai scritto il server, scaricalo prima sul tuo computer.
1. **Avvia il processo del server**: Esegui la tua applicazione server MCP.

Per SSE (non necessario per il tipo di server stdio)

1. **Configura la rete**: Assicurati che il server sia accessibile sulla porta prevista.
1. **Connetti i client**: Utilizza URL di connessione locale come `http://localhost:3000`.

## Distribuzione nel cloud

I server MCP possono essere distribuiti su varie piattaforme cloud:

- **Funzioni Serverless**: Distribuisci server MCP leggeri come funzioni serverless.
- **Servizi Container**: Utilizza servizi come Azure Container Apps, AWS ECS o Google Cloud Run.
- **Kubernetes**: Distribuisci e gestisci server MCP in cluster Kubernetes per alta disponibilità.

### Esempio: Azure Container Apps

Azure Container Apps supporta la distribuzione di server MCP. È ancora in fase di sviluppo e attualmente supporta i server SSE.

Ecco come procedere:

1. Clona un repository:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Eseguilo localmente per testare:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Per provarlo localmente, crea un file *mcp.json* in una directory *.vscode* e aggiungi il seguente contenuto:

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

  Una volta avviato il server SSE, puoi cliccare sull'icona di riproduzione nel file JSON, dovresti ora vedere gli strumenti sul server essere rilevati da GitHub Copilot, vedi l'icona degli strumenti.

1. Per distribuire, esegui il seguente comando:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Ecco fatto, distribuiscilo localmente, distribuiscilo su Azure attraverso questi passaggi.

## Risorse aggiuntive

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Articolo Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repository MCP Azure Container Apps](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Cosa c'è dopo

- Successivo: [Implementazione pratica](/04-PracticalImplementation/README.md)

**Clausola di esclusione della responsabilità**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatizzate possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.