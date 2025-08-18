<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2228721599c0c8673de83496b4d7d7a9",
  "translation_date": "2025-08-18T14:19:27+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "hu"
}
-->
# Esettanulmány: REST API kitettsége az API Management-ben MCP szerverként

Az Azure API Management egy olyan szolgáltatás, amely átjárót biztosít az API végpontjai fölött. Úgy működik, hogy az Azure API Management proxyként viselkedik az API-k előtt, és eldönti, mit tegyen a bejövő kérésekkel.

Használatával számos funkciót adhat hozzá, például:

- **Biztonság**, használhat API kulcsokat, JWT-t vagy kezelt identitást.
- **Sebességkorlátozás**, nagyszerű funkció, amely lehetővé teszi, hogy meghatározza, hány hívás engedélyezett egy adott időegység alatt. Ez segít biztosítani, hogy minden felhasználó nagyszerű élményt kapjon, és hogy a szolgáltatása ne legyen túlterhelve kérésekkel.
- **Skálázás és terheléselosztás**, beállíthat több végpontot a terhelés kiegyensúlyozására, és eldöntheti, hogyan történjen a "terheléselosztás".
- **AI funkciók, mint például szemantikus gyorsítótárazás**, token limit és token monitorozás, és még sok más. Ezek nagyszerű funkciók, amelyek javítják a válaszidőt, valamint segítenek nyomon követni a tokenek felhasználását. [További információ itt](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Miért MCP + Azure API Management?

A Model Context Protocol gyorsan szabvánnyá válik az ügynöki AI alkalmazások számára, és eszközök és adatok konzisztens módon történő kitettségére. Az Azure API Management természetes választás, ha API-kat kell "kezelni". Az MCP szerverek gyakran más API-kat integrálnak, hogy például egy eszköz kérését megoldják. Ezért az Azure API Management és MCP kombinációja logikus lépés.

## Áttekintés

Ebben a konkrét felhasználási esetben megtanuljuk, hogyan tegyük ki az API végpontokat MCP szerverként. Ezzel könnyen az ügynöki alkalmazás részévé tehetjük ezeket a végpontokat, miközben kihasználjuk az Azure API Management funkcióit.

## Főbb jellemzők

- Kiválaszthatja azokat a végpont-módszereket, amelyeket eszközként szeretne kitenni.
- Az extra funkciók attól függnek, hogy mit konfigurál az API politikai szekciójában. Itt például megmutatjuk, hogyan adhat hozzá sebességkorlátozást.

## Előzetes lépés: API importálása

Ha már van API-ja az Azure API Management-ben, nagyszerű, akkor ezt a lépést kihagyhatja. Ha nincs, nézze meg ezt a linket: [API importálása az Azure API Management-be](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## API kitettsége MCP szerverként

Az API végpontok kitettségéhez kövesse az alábbi lépéseket:

1. Nyissa meg az Azure Portált a következő címen: <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   Lépjen az API Management példányához.

1. A bal oldali menüben válassza az **APIs > MCP Servers > + Create new MCP Server** lehetőséget.

1. Az API-nál válasszon egy REST API-t, amelyet MCP szerverként szeretne kitenni.

1. Válasszon ki egy vagy több API műveletet, amelyet eszközként szeretne kitenni. Kiválaszthatja az összes műveletet, vagy csak bizonyos műveleteket.

    ![Kiválasztott módszerek kitettsége](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Válassza a **Create** lehetőséget.

1. Lépjen az **APIs** és **MCP Servers** menüpontra, ahol a következőt kell látnia:

    ![MCP szerver a fő panelen](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Az MCP szerver létrejött, és az API műveletek eszközként vannak kitéve. Az MCP szerver az MCP Servers panelen van felsorolva. Az URL oszlop mutatja az MCP szerver végpontját, amelyet teszteléshez vagy kliensalkalmazásban hívhat meg.

## Opcionális: Politika konfigurálása

Az Azure API Management alapvető koncepciója a politikák, ahol különböző szabályokat állíthat be a végpontjaihoz, például sebességkorlátozást vagy szemantikus gyorsítótárazást. Ezeket a politikákat XML-ben írják.

Így állíthat be politikát az MCP szerver sebességkorlátozására:

1. A portálon, az **APIs** alatt válassza az **MCP Servers** lehetőséget.

1. Válassza ki a létrehozott MCP szervert.

1. A bal oldali menüben, az MCP alatt válassza a **Policies** lehetőséget.

1. A politika szerkesztőben adja hozzá vagy szerkessze azokat a politikákat, amelyeket az MCP szerver eszközeire szeretne alkalmazni. A politikák XML formátumban vannak meghatározva. Például hozzáadhat egy politikát, amely korlátozza az MCP szerver eszközeinek hívásait (ebben a példában 5 hívás 30 másodperc alatt kliens IP-címenként). Íme egy XML, amely sebességkorlátozást okoz:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Íme a politika szerkesztő képe:

    ![Politika szerkesztő](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)

## Próbálja ki

Győződjön meg róla, hogy az MCP szerver megfelelően működik.

Ehhez használjuk a Visual Studio Code-ot és a GitHub Copilotot annak Agent módjában. Hozzáadjuk az MCP szervert egy *mcp.json* fájlhoz. Ezzel a Visual Studio Code kliensként fog működni ügynöki képességekkel, és a végfelhasználók képesek lesznek beírni egy promptot, és interakcióba lépni az adott szerverrel.

Így teheti meg, hogy hozzáadja az MCP szervert a Visual Studio Code-ban:

1. Használja az MCP: **Add Server parancsot a Command Palette-ből**.

1. Amikor megkérdezi, válassza ki a szerver típusát: **HTTP (HTTP vagy Server Sent Events)**.

1. Adja meg az MCP szerver URL-jét az API Management-ben. Példa: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE végpont esetén) vagy **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP végpont esetén), vegye figyelembe, hogy a különbség a szállítások között a `/sse` vagy `/mcp`.

1. Adjon meg egy szerverazonosítót saját választása szerint. Ez nem fontos érték, de segít emlékezni, hogy mi ez a szerver példány.

1. Válassza ki, hogy a konfigurációt a munkaterület beállításaihoz vagy a felhasználói beállításokhoz menti-e.

  - **Munkaterület beállításai** - A szerver konfigurációja egy .vscode/mcp.json fájlba kerül mentésre, amely csak az aktuális munkaterületen érhető el.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    vagy ha streaming HTTP-t választ szállításként, kissé eltérő lesz:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Felhasználói beállítások** - A szerver konfigurációja hozzáadódik a globális *settings.json* fájlhoz, és minden munkaterületen elérhető. A konfiguráció hasonlóan néz ki:

    ![Felhasználói beállítás](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Ezenkívül hozzá kell adnia egy konfigurációt, egy fejlécet, hogy biztosítsa a megfelelő hitelesítést az Azure API Management felé. Ez egy **Ocp-Apim-Subscription-Key** nevű fejlécet használ.

    - Így adhatja hozzá a beállításokhoz:

    ![Hitelesítési fejléc hozzáadása](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), ez megjeleníti egy promptot, amelyben meg kell adnia az API kulcs értékét, amelyet az Azure Portálon talál az Azure API Management példányához.

   - Ha inkább a *mcp.json*-hoz szeretné hozzáadni, így teheti meg:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Agent mód használata

Most már minden be van állítva, akár a beállításokban, akár a *.vscode/mcp.json*-ban. Próbáljuk ki.

Egy eszköz ikon jelenik meg, ahol a szerver által kitetett eszközök listázva vannak:

![Eszközök a szerverről](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Kattintson az eszköz ikonra, és látnia kell egy eszközlistát, mint például:

    ![Eszközök](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Írjon be egy promptot a csevegésbe, hogy meghívja az eszközt. Például, ha kiválasztott egy eszközt, amely információt ad egy rendelésről, kérdezheti az ügynököt a rendelésről. Íme egy példa prompt:

    ```text
    get information from order 2
    ```

    Most megjelenik egy eszköz ikon, amely arra kéri, hogy folytassa az eszköz hívását. Válassza ki, hogy folytatja az eszköz futtatását, és most egy ilyen kimenetet kell látnia:

    ![Eredmény a promptból](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **amit lát, az attól függ, hogy milyen eszközöket állított be, de az ötlet az, hogy szöveges választ kap, mint fent**

## Hivatkozások

Íme, hogyan tanulhat többet:

- [Azure API Management és MCP oktatóanyag](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python példa: Távoli MCP szerverek biztonságos használata Azure API Management segítségével (kísérleti)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP kliens hitelesítési labor](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Az Azure API Management kiterjesztés használata VS Code-ban API-k importálására és kezelésére](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Távoli MCP szerverek regisztrálása és felfedezése az Azure API Centerben](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Nagyszerű repó, amely számos AI képességet mutat be az Azure API Management segítségével
- [AI Gateway workshopok](https://azure-samples.github.io/AI-Gateway/) Workshopokat tartalmaz az Azure Portál használatával, ami nagyszerű módja az AI képességek értékelésének.

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.