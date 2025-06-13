<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:29:14+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "it"
}
-->
# Distribuire server MCP

Distribuirea serverului MCP permite altora să acceseze uneltele și resursele sale dincolo de mediul local. Există mai multe strategii de implementare, în funcție de cerințele tale privind scalabilitatea, fiabilitatea și ușurința gestionării. Mai jos vei găsi indicații pentru a distribui servere MCP local, în containere și în cloud.

## Prezentare generală

Această lecție explică cum să distribui aplicația MCP Server.

## Obiective de învățare

La finalul acestei lecții, vei putea:

- Evalua diferite abordări de implementare.
- Distribui aplicația ta.

## Dezvoltare și implementare locală

Dacă serverul tău este destinat să fie folosit rulând pe calculatorul utilizatorului, poți urma pașii următori:

1. **Descarcă serverul**. Dacă nu ai scris serverul, descarcă-l mai întâi pe calculatorul tău.  
1. **Pornește procesul serverului**: Rulează aplicația MCP server.

Pentru SSE (nu este necesar pentru serverele de tip stdio)

1. **Configurează rețeaua**: Asigură-te că serverul este accesibil pe portul așteptat.  
1. **Conectează clienții**: Folosește URL-uri de conexiune locale precum `http://localhost:3000`.

## Implementare în cloud

Serverele MCP pot fi distribuite pe diverse platforme cloud:

- **Funcții serverless**: Distribuie servere MCP ușoare ca funcții serverless.  
- **Servicii de containere**: Folosește servicii precum Azure Container Apps, AWS ECS sau Google Cloud Run.  
- **Kubernetes**: Distribuie și gestionează servere MCP în clustere Kubernetes pentru disponibilitate ridicată.

### Exemplu: Azure Container Apps

Azure Container Apps suportă distribuirea serverelor MCP. Este încă în dezvoltare și momentan suportă servere SSE.

Iată cum poți proceda:

1. Clonează un repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Rulează-l local pentru a testa:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Pentru a-l testa local, creează un fișier *mcp.json* într-un director *.vscode* și adaugă următorul conținut:

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

  După ce serverul SSE pornește, poți da click pe iconița de play din fișierul JSON; acum uneltele de pe server ar trebui să fie recunoscute de GitHub Copilot, vezi iconița Tool.

1. Pentru a distribui, rulează comanda următoare:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Așa că, iată cum îl poți distribui local sau în Azure urmând acești pași.

## Resurse suplimentare

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Articol Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repo Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Ce urmează

- Următorul: [Implementare practică](/04-PracticalImplementation/README.md)

**Avvertenza**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali fraintendimenti o interpretazioni errate derivanti dall’uso di questa traduzione.