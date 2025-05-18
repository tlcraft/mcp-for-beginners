<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:56:31+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "hr"
}
-->
# Implementacija MCP Servera

Implementacija vašeg MCP servera omogućuje drugima pristup njegovim alatima i resursima izvan vašeg lokalnog okruženja. Postoji nekoliko strategija implementacije koje treba razmotriti, ovisno o vašim zahtjevima za skalabilnost, pouzdanost i jednostavnost upravljanja. U nastavku ćete pronaći smjernice za implementaciju MCP servera lokalno, u kontejnerima i u oblaku.

## Pregled

Ova lekcija pokriva kako implementirati vašu MCP Server aplikaciju.

## Ciljevi učenja

Na kraju ove lekcije, moći ćete:

- Procijeniti različite pristupe implementaciji.
- Implementirati vašu aplikaciju.

## Lokalni razvoj i implementacija

Ako je vaš server namijenjen za korištenje na korisnikovom računalu, možete slijediti sljedeće korake:

1. **Preuzmite server**. Ako niste napisali server, prvo ga preuzmite na svoje računalo.
1. **Pokrenite proces servera**: Pokrenite vašu MCP server aplikaciju

Za SSE (nije potrebno za server tipa stdio)

1. **Konfigurirajte mrežu**: Osigurajte da je server dostupan na očekivanom portu
1. **Povežite klijente**: Koristite lokalne URL-ove za povezivanje kao `http://localhost:3000`

## Implementacija u oblaku

MCP serveri mogu se implementirati na razne cloud platforme:

- **Funkcije bez servera**: Implementirajte lagane MCP servere kao funkcije bez servera
- **Usluge kontejnera**: Koristite usluge kao što su Azure Container Apps, AWS ECS ili Google Cloud Run
- **Kubernetes**: Implementirajte i upravljajte MCP serverima u Kubernetes klasterima za visoku dostupnost

### Primjer: Azure Container Apps

Azure Container Apps podržavaju implementaciju MCP servera. Još uvijek je u razvoju i trenutno podržava SSE servere.

Evo kako to možete učiniti:

1. Klonirajte repo:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Pokrenite ga lokalno da biste testirali:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Da biste ga isprobali lokalno, kreirajte datoteku *mcp.json* u direktoriju *.vscode* i dodajte sljedeći sadržaj:

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

  Kada se SSE server pokrene, možete kliknuti ikonu za reprodukciju u JSON datoteci, sada biste trebali vidjeti alate na serveru kako ih preuzima GitHub Copilot, pogledajte ikonu Alat.

1. Za implementaciju, pokrenite sljedeću naredbu:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Eto ga, implementirajte ga lokalno, implementirajte ga na Azure kroz ove korake.

## Dodatni resursi

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Članak o Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Što je sljedeće

- Sljedeće: [Praktična implementacija](/04-PracticalImplementation/README.md)

**Odricanje odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za kritične informacije preporučuje se profesionalni prijevod od strane čovjeka. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.