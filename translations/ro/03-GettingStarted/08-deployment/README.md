<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:55:56+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "ro"
}
-->
# Implementarea serverelor MCP

Implementarea serverului tău MCP permite altora să acceseze instrumentele și resursele sale dincolo de mediul tău local. Există mai multe strategii de implementare de luat în considerare, în funcție de cerințele tale de scalabilitate, fiabilitate și ușurință în gestionare. Mai jos vei găsi ghiduri pentru implementarea serverelor MCP local, în containere și în cloud.

## Prezentare generală

Această lecție acoperă modul de implementare a aplicației tale MCP Server.

## Obiective de învățare

Până la sfârșitul acestei lecții, vei putea:

- Evalua diferite abordări de implementare.
- Implementa aplicația ta.

## Dezvoltare și implementare locală

Dacă serverul tău este destinat să fie utilizat pe calculatorul utilizatorilor, poți urma pașii următori:

1. **Descarcă serverul**. Dacă nu ai scris serverul, atunci descarcă-l mai întâi pe calculatorul tău.
1. **Pornește procesul serverului**: Rulează aplicația ta MCP server

Pentru SSE (nu este necesar pentru server de tip stdio)

1. **Configurează rețeaua**: Asigură-te că serverul este accesibil pe portul așteptat
1. **Conectează clienții**: Folosește URL-uri de conexiune locală precum `http://localhost:3000`

## Implementare în cloud

Serverele MCP pot fi implementate pe diverse platforme cloud:

- **Funcții fără server**: Implementează servere MCP ușoare ca funcții fără server
- **Servicii de containere**: Folosește servicii precum Azure Container Apps, AWS ECS sau Google Cloud Run
- **Kubernetes**: Implementează și gestionează servere MCP în clustere Kubernetes pentru disponibilitate ridicată

### Exemplu: Azure Container Apps

Azure Container Apps suportă implementarea serverelor MCP. Este încă în dezvoltare și în prezent suportă servere SSE.

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

1. Pentru a-l încerca local, creează un fișier *mcp.json* într-un director *.vscode* și adaugă următorul conținut:

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

  Odată ce serverul SSE este pornit, poți apăsa pe pictograma de redare din fișierul JSON, ar trebui să vezi acum instrumentele de pe server recunoscute de GitHub Copilot, vezi pictograma Instrument.

1. Pentru a implementa, rulează următoarea comandă:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Asta e, implementează-l local, implementează-l pe Azure prin acești pași.

## Resurse suplimentare

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Articol despre Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Repo MCP Azure Container Apps](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Ce urmează

- Următorul: [Implementare practică](/04-PracticalImplementation/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa maternă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de oameni. Nu suntem responsabili pentru niciun fel de neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.