<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:56:21+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "sr"
}
-->
# Postavljanje MCP servera

Postavljanje vašeg MCP servera omogućava drugim korisnicima pristup njegovim alatima i resursima izvan vaše lokalne sredine. Postoji nekoliko strategija postavljanja koje možete razmotriti, u zavisnosti od vaših zahteva za skalabilnost, pouzdanost i jednostavnost upravljanja. U nastavku ćete pronaći smernice za postavljanje MCP servera lokalno, u kontejnerima i u oblaku.

## Pregled

Ova lekcija pokriva kako da postavite vašu MCP Server aplikaciju.

## Ciljevi učenja

Do kraja ove lekcije, moći ćete da:

- Procijenite različite pristupe postavljanju.
- Postavite vašu aplikaciju.

## Lokalni razvoj i postavljanje

Ako je vaš server namenjen za korišćenje na korisnikovom računaru, možete pratiti sledeće korake:

1. **Preuzmite server**. Ako niste napisali server, prvo ga preuzmite na svoj računar.
1. **Pokrenite proces servera**: Pokrenite vašu MCP server aplikaciju.

Za SSE (nije potrebno za stdio tip servera)

1. **Konfigurišite mrežu**: Osigurajte da je server dostupan na očekivanom portu.
1. **Povežite klijente**: Koristite lokalne URL-ove za povezivanje kao `http://localhost:3000`.

## Postavljanje u oblaku

MCP serveri mogu biti postavljeni na različite platforme u oblaku:

- **Funkcije bez servera**: Postavite lagane MCP servere kao funkcije bez servera.
- **Usluge kontejnera**: Koristite usluge kao što su Azure Container Apps, AWS ECS ili Google Cloud Run.
- **Kubernetes**: Postavite i upravljajte MCP serverima u Kubernetes klasterima za visoku dostupnost.

### Primer: Azure Container Apps

Azure Container Apps podržava postavljanje MCP servera. Još uvek je u fazi razvoja i trenutno podržava SSE servere.

Evo kako možete postupiti:

1. Klonirajte repozitorijum:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Pokrenite ga lokalno da testirate:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Da biste ga isprobali lokalno, kreirajte *mcp.json* datoteku u *.vscode* direktorijumu i dodajte sledeći sadržaj:

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

  Kada se SSE server pokrene, možete kliknuti na ikonu za pokretanje u JSON datoteci, sada biste trebali videti kako alati na serveru budu prepoznati od strane GitHub Copilot-a, pogledajte ikonu alata.

1. Da biste postavili, pokrenite sledeću komandu:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Eto ga, postavite ga lokalno, postavite ga na Azure kroz ove korake.

## Dodatni resursi

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Članak o Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Šta dalje

- Sledeće: [Praktična implementacija](/04-PracticalImplementation/README.md)

**Одрицање од одговорности**:  
Овај документ је преведен користећи AI услугу за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо ка тачности, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитативним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква погрешна разумевања или погрешна тумачења која произилазе из употребе овог превода.