<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:32:39+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "sr"
}
-->
# Deployovanje MCP servera

Deployovanje vašeg MCP servera omogućava drugima pristup njegovim alatima i resursima van vašeg lokalnog okruženja. Postoji nekoliko strategija za deploy, u zavisnosti od vaših zahteva za skalabilnošću, pouzdanošću i jednostavnošću upravljanja. Ispod ćete pronaći smernice za deploy MCP servera lokalno, u kontejnerima i u oblaku.

## Pregled

Ova lekcija pokriva kako da deployujete vašu MCP Server aplikaciju.

## Ciljevi učenja

Do kraja ove lekcije, moći ćete da:

- Procijenite različite pristupe deploy-u.
- Deployujete vašu aplikaciju.

## Lokalni razvoj i deploy

Ako je vaš server namenjen da se koristi na korisničkom računaru, možete pratiti sledeće korake:

1. **Preuzmite server**. Ako niste vi pisali server, prvo ga preuzmite na svoj računar.  
1. **Pokrenite server proces**: Pokrenite vašu MCP server aplikaciju.

Za SSE (nije potrebno za stdio tip servera):

1. **Konfigurišite mrežu**: Osigurajte da je server dostupan na očekivanom portu.  
1. **Povežite klijente**: Koristite lokalne URL-ove za konekciju kao što je `http://localhost:3000`.

## Deploy u oblak

MCP serveri mogu biti deployovani na različite cloud platforme:

- **Serverless funkcije**: Deploy laganih MCP servera kao serverless funkcije  
- **Kontejnerske usluge**: Koristite usluge poput Azure Container Apps, AWS ECS ili Google Cloud Run  
- **Kubernetes**: Deploy i upravljanje MCP serverima u Kubernetes klasterima za visoku dostupnost

### Primer: Azure Container Apps

Azure Container Apps podržava deploy MCP servera. Još uvek je u razvoju i trenutno podržava SSE servere.

Evo kako to možete uraditi:

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

1. Da biste probali lokalno, kreirajte *mcp.json* fajl u *.vscode* direktorijumu i dodajte sledeći sadržaj:

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

  Kada se SSE server pokrene, možete kliknuti na ikonu za pokretanje u JSON fajlu, sada bi alati na serveru trebali biti prepoznati od strane GitHub Copilot-a, pogledajte ikonu alata.

1. Za deploy, pokrenite sledeću komandu:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

Eto, deployujte lokalno ili na Azure prateći ove korake.

## Dodatni resursi

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)  
- [Članak o Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)  
- [Azure Container Apps MCP repozitorijum](https://github.com/anthonychu/azure-container-apps-mcp-sample)  

## Šta sledi

- Sledeće: [Praktična implementacija](/04-PracticalImplementation/README.md)

**Ограничење одговорности**:  
Овај документ је преведен помоћу AI сервиса за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако се трудимо да превод буде прецизан, имајте у виду да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати коначним и ауторитетним извором. За критичне информације препоручује се професионални људски превод. Нисмо одговорни за било каква неспоразума или погрешне интерпретације настале коришћењем овог превода.