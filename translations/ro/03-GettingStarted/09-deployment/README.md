<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:32:20+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "ro"
}
-->
# Deployarea serverelor MCP

Deployarea serverului MCP permite altora să acceseze uneltele și resursele acestuia dincolo de mediul local. Există mai multe strategii de deployare, în funcție de cerințele tale legate de scalabilitate, fiabilitate și ușurință în gestionare. Mai jos găsești recomandări pentru deployarea serverelor MCP local, în containere și în cloud.

## Prezentare generală

Această lecție explică cum să deployezi aplicația MCP Server.

## Obiective de învățare

La finalul acestei lecții vei putea:

- Evalua diferite metode de deployare.
- Deploya aplicația ta.

## Dezvoltare și deployare locală

Dacă serverul tău este destinat să fie folosit rulându-se pe mașina utilizatorului, poți urma pașii următori:

1. **Descarcă serverul**. Dacă nu ai scris serverul, descarcă-l mai întâi pe mașina ta.
1. **Pornește procesul serverului**: Rulează aplicația MCP server.

Pentru SSE (nu este necesar pentru serverele de tip stdio)

1. **Configurează rețeaua**: Asigură-te că serverul este accesibil pe portul așteptat.
1. **Conectează clienții**: Folosește URL-uri de conexiune locale precum `http://localhost:3000`.

## Deployare în cloud

Serverele MCP pot fi deployate pe diverse platforme cloud:

- **Serverless Functions**: Deployează servere MCP ușoare ca funcții serverless.
- **Container Services**: Folosește servicii precum Azure Container Apps, AWS ECS sau Google Cloud Run.
- **Kubernetes**: Deployează și gestionează servere MCP în clustere Kubernetes pentru disponibilitate ridicată.

### Exemplu: Azure Container Apps

Azure Container Apps suportă deployarea serverelor MCP. Este încă în dezvoltare și în prezent suportă serverele SSE.

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

  După ce serverul SSE este pornit, poți da click pe iconița de play din fișierul JSON, iar uneltele serverului ar trebui să fie preluate de GitHub Copilot, vezi iconița Tool.

1. Pentru deployare, rulează comanda următoare:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Așa că, deployează local sau în Azure urmând acești pași.

## Resurse suplimentare

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Articol Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repo Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Ce urmează

- Următorul: [Implementare practică](/04-PracticalImplementation/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.