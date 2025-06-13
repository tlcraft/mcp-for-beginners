<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:32:50+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "hr"
}
-->
# Deployanje MCP servera

Deployanje vašeg MCP servera omogućuje drugima pristup njegovim alatima i resursima izvan vašeg lokalnog okruženja. Postoji nekoliko strategija za deployanje, ovisno o vašim zahtjevima za skalabilnošću, pouzdanošću i jednostavnošću upravljanja. Ispod ćete pronaći upute za deployanje MCP servera lokalno, u kontejnerima i u oblaku.

## Pregled

Ova lekcija objašnjava kako deployati vašu MCP Server aplikaciju.

## Ciljevi učenja

Na kraju ove lekcije moći ćete:

- Procijeniti različite pristupe deployanju.
- Deployati svoju aplikaciju.

## Lokalni razvoj i deployanje

Ako je vaš server namijenjen da ga korisnici pokreću na svojim računalima, slijedite sljedeće korake:

1. **Preuzmite server**. Ako niste vi pisali server, prvo ga preuzmite na svoje računalo.  
1. **Pokrenite server proces**: Pokrenite vašu MCP server aplikaciju.

Za SSE (nije potrebno za stdio tip servera):

1. **Konfigurirajte mrežu**: Provjerite da je server dostupan na očekivanom portu.  
1. **Povežite klijente**: Koristite lokalne URL-ove za povezivanje poput `http://localhost:3000`.

## Deployanje u oblak

MCP serveri mogu se deployati na različite cloud platforme:

- **Serverless funkcije**: Deployajte lagane MCP servere kao serverless funkcije  
- **Container servisi**: Koristite servise poput Azure Container Apps, AWS ECS ili Google Cloud Run  
- **Kubernetes**: Deployajte i upravljajte MCP serverima u Kubernetes klasterima za visoku dostupnost

### Primjer: Azure Container Apps

Azure Container Apps podržava deployanje MCP servera. Još je u razvoju i trenutno podržava SSE servere.

Evo kako to možete napraviti:

1. Klonirajte repozitorij:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Pokrenite lokalno za testiranje:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Za lokalno testiranje, kreirajte *mcp.json* datoteku u *.vscode* direktoriju i dodajte sljedeći sadržaj:

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

  Nakon što se SSE server pokrene, kliknite na ikonu za pokretanje u JSON datoteci; sada biste trebali vidjeti da alati na serveru budu prepoznati od strane GitHub Copilota, vidite ikonu Tool.

1. Za deployanje pokrenite sljedeću naredbu:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Eto, deployajte lokalno ili u Azure slijedeći ove korake.

## Dodatni resursi

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Članak o Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repozitorij](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Što slijedi

- Sljedeće: [Praktična implementacija](/04-PracticalImplementation/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne odgovaramo za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.