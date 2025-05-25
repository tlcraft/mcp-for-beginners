<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:55:20+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "hu"
}
-->
# MCP szerverek telepítése

Az MCP szerver telepítése lehetővé teszi, hogy mások hozzáférjenek az eszközeihez és erőforrásaihoz a helyi környezeten túl. Számos telepítési stratégia közül választhat, attól függően, hogy milyen követelményeket támaszt a skálázhatóság, megbízhatóság és könnyű kezelhetőség terén. Az alábbiakban útmutatást talál az MCP szerverek helyi, konténeres és felhőbe való telepítéséhez.

## Áttekintés

Ez a lecke az MCP szerver alkalmazás telepítését mutatja be.

## Tanulási célok

A lecke végére képes lesz:

- Különböző telepítési megközelítések értékelésére.
- Az alkalmazás telepítésére.

## Helyi fejlesztés és telepítés

Ha a szerver célja, hogy a felhasználók gépén fusson, kövesse az alábbi lépéseket:

1. **Töltse le a szervert**. Ha nem Ön írta a szervert, először töltse le a gépére.
1. **Indítsa el a szerver folyamatot**: Futtassa az MCP szerver alkalmazást.

SSE esetén (nem szükséges stdio típusú szerverhez)

1. **Hálózat konfigurálása**: Győződjön meg róla, hogy a szerver elérhető a várt porton.
1. **Kliensek csatlakoztatása**: Használjon helyi csatlakozási URL-eket, mint például `http://localhost:3000`.

## Felhőbeli telepítés

Az MCP szerverek különböző felhőplatformokra telepíthetők:

- **Serverless funkciók**: Könnyű MCP szerverek telepítése serverless funkcióként.
- **Konténer szolgáltatások**: Használjon olyan szolgáltatásokat, mint az Azure Container Apps, AWS ECS vagy Google Cloud Run.
- **Kubernetes**: MCP szerverek telepítése és kezelése Kubernetes klaszterekben a magas rendelkezésre állás érdekében.

### Példa: Azure Container Apps

Az Azure Container Apps támogatja az MCP szerverek telepítését. Még folyamatban van, és jelenleg az SSE szervereket támogatja.

Így teheti meg:

1. Klónozzon egy repót:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. Futtassa helyileg a teszteléshez:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. Hogy helyben próbálja ki, hozzon létre egy *mcp.json* fájlt a *.vscode* könyvtárban, és adja hozzá a következő tartalmat:

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

  Miután az SSE szerver elindult, kattintson a JSON fájl lejátszás ikonra, most már látnia kell, hogy a szerveren lévő eszközöket a GitHub Copilot felveszi, látni fogja az Eszköz ikont.

1. A telepítéshez futtassa a következő parancsot:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

És kész, telepítse helyileg, telepítse az Azure-ra ezekkel a lépésekkel.

## További források

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps cikk](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## Hogyan tovább

- Következő: [Gyakorlati megvalósítás](/04-PracticalImplementation/README.md)

**Felelősség kizárása**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás használatával készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.