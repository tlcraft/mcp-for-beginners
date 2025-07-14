<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:36:00+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "hu"
}
-->
# Esettanulmány: REST API közzététele API Management-ben MCP szerverként

Az Azure API Management egy olyan szolgáltatás, amely egy átjárót biztosít az API végpontjaid fölött. Az Azure API Management úgy működik, hogy proxyként áll az API-jaid előtt, és eldönti, hogyan kezelje a bejövő kéréseket.

Használatával számos funkciót adhatsz hozzá, például:

- **Biztonság**, használhatsz API kulcsokat, JWT-t vagy kezelt identitást.
- **Hívásszám korlátozás**, nagyszerű funkció, hogy meghatározhatod, hány hívás engedélyezett egy adott időegység alatt. Ez segít abban, hogy minden felhasználó jó élményt kapjon, és a szolgáltatásod ne legyen túlterhelve.
- **Skálázás és terheléselosztás**. Több végpontot állíthatsz be a terhelés kiegyensúlyozására, és eldöntheted, hogyan történjen a terheléselosztás.
- **AI funkciók, mint a szemantikus gyorsítótárazás**, token limit és token monitorozás, és még sok más. Ezek a funkciók javítják a válaszidőt, és segítenek nyomon követni a token felhasználást. [További információ itt](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Miért MCP + Azure API Management?

A Model Context Protocol gyorsan szabvánnyá válik az ügynöki AI alkalmazásoknál, és az eszközök, adatok egységes megjelenítésénél. Az Azure API Management természetes választás, ha API-kat kell "kezelni". Az MCP szerverek gyakran integrálódnak más API-kkal, hogy például eszközökhöz irányítsák a kéréseket. Ezért az Azure API Management és az MCP kombinációja logikus megoldás.

## Áttekintés

Ebben a konkrét esetben megtanuljuk, hogyan tegyünk elérhetővé API végpontokat MCP szerverként. Ezzel könnyen beilleszthetjük ezeket az ügynöki alkalmazásba, miközben kihasználjuk az Azure API Management funkcióit.

## Főbb jellemzők

- Kiválaszthatod, mely végpont metódusokat szeretnéd eszközként elérhetővé tenni.
- A további funkciók attól függnek, mit állítasz be az API policy szekciójában. Itt megmutatjuk, hogyan adhatsz hozzá hívásszám korlátozást.

## Előfeltétel: API importálása

Ha már van API-d az Azure API Management-ben, akkor ezt a lépést kihagyhatod. Ha nincs, nézd meg ezt a linket: [API importálása Azure API Management-be](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## API közzététele MCP szerverként

Az API végpontok közzétételéhez kövesd az alábbi lépéseket:

1. Lépj be az Azure Portalra a következő címen: <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Navigálj az API Management példányodhoz.

1. A bal oldali menüben válaszd az APIs > MCP Servers > + Create new MCP Server menüpontot.

1. Az API-nál válassz egy REST API-t, amit MCP szerverként szeretnél közzétenni.

1. Válassz ki egy vagy több API műveletet, amelyeket eszközként szeretnél elérhetővé tenni. Kiválaszthatod az összes műveletet vagy csak bizonyosakat.

    ![Válaszd ki a közzétenni kívánt metódusokat](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Kattints a **Create** gombra.

1. Navigálj az **APIs** és **MCP Servers** menüpontokhoz, ahol a következőt kell látnod:

    ![Az MCP szerver megjelenik a fő nézetben](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    Az MCP szerver létrejött, és az API műveletek eszközként elérhetővé váltak. Az MCP szerver megjelenik az MCP Servers panelen. Az URL oszlop mutatja az MCP szerver végpontját, amit tesztelésre vagy kliens alkalmazásból hívhatsz.

## Opcionális: Policy-k konfigurálása

Az Azure API Management alapvető fogalma a policy, ahol különböző szabályokat állíthatsz be a végpontjaidra, például hívásszám korlátozást vagy szemantikus gyorsítótárazást. Ezek a policy-k XML formátumban készülnek.

Így állíthatsz be hívásszám korlátozó policy-t az MCP szerveredhez:

1. A portálon, az APIs alatt válaszd az **MCP Servers** menüpontot.

1. Válaszd ki a létrehozott MCP szervert.

1. A bal oldali menüben, az MCP alatt válaszd a **Policies** opciót.

1. A policy szerkesztőben add hozzá vagy szerkeszd a kívánt policy-ket, amelyeket az MCP szerver eszközeire szeretnél alkalmazni. A policy-k XML formátumban vannak megadva. Például hozzáadhatsz egy olyan policy-t, amely korlátozza a hívásokat az MCP szerver eszközeihez (ebben a példában 5 hívás 30 másodpercenként kliens IP címenként). Íme az XML, amely ezt megvalósítja:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Íme egy kép a policy szerkesztőről:

    ![Policy szerkesztő](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Próbáld ki

Győződjünk meg róla, hogy az MCP szerverünk a várakozásoknak megfelelően működik.

Ehhez a Visual Studio Code-ot és a GitHub Copilot Agent módját fogjuk használni. Hozzáadjuk az MCP szervert egy *mcp.json* fájlhoz. Így a Visual Studio Code kliensként fog működni ügynöki képességekkel, és a végfelhasználók beírhatnak egy promptot, amivel kommunikálhatnak a szerverrel.

Nézzük, hogyan adhatod hozzá az MCP szervert a Visual Studio Code-ban:

1. Használd az MCP: **Add Server parancsot a Command Palette-ből**.

1. Amikor kéri, válaszd ki a szerver típusát: **HTTP (HTTP vagy Server Sent Events)**.

1. Add meg az MCP szerver URL-jét az API Management-ben. Például: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (SSE végpont esetén) vagy **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (MCP végpont esetén), vedd észre, hogy a különbség a szállítási mód között a `/sse` vagy `/mcp`.

1. Adj meg egy tetszőleges szerver azonosítót. Ez nem kritikus érték, de segít emlékezni, hogy melyik szerver példányról van szó.

1. Válaszd ki, hogy a konfigurációt a workspace vagy a user beállításokba mented.

  - **Workspace beállítások** - A szerver konfiguráció egy .vscode/mcp.json fájlba kerül, amely csak az aktuális munkaterületen érhető el.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    vagy ha streaming HTTP-t választasz szállítási módként, akkor kissé eltérő lesz:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **User beállítások** - A szerver konfiguráció a globális *settings.json* fájlba kerül, és minden munkaterületen elérhető. A konfiguráció hasonlóan néz ki, mint az alábbi:

    ![User beállítás](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Hozzá kell adnod egy konfigurációs fejlécet is, hogy az Azure API Management felé megfelelően hitelesítsen. Ehhez egy **Ocp-Apim-Subscription-Key** nevű fejlécet használ.

    - Így adhatod hozzá a beállításokhoz:

    ![Hitelesítési fejléc hozzáadása](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), ez megjelenít egy promptot, ahol megadhatod az API kulcs értékét, amit az Azure Portalban találsz az Azure API Management példányodhoz.

   - Ha inkább a *mcp.json*-hez szeretnéd hozzáadni, így teheted meg:

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

### Ügynök mód használata

Most, hogy beállítottuk a konfigurációt akár a beállításokban, akár a *.vscode/mcp.json* fájlban, próbáljuk ki.

Meg kell jelennie egy Eszközök ikonnek, ahol a szerver által közzétett eszközök listája látható:

![Szerver eszközei](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Kattints az eszközök ikonra, és meg kell jelennie az eszközök listájának:

    ![Eszközök](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Írj be egy promptot a csevegőbe az eszköz meghívásához. Például, ha kiválasztottál egy eszközt, amely rendelés információt ad, megkérdezheted az ügynököt egy rendelésről. Íme egy példa prompt:

    ```text
    get information from order 2
    ```

    Most megjelenik egy eszköz ikon, amely megkérdezi, hogy folytatod-e az eszköz hívását. Válaszd a folytatást, és az alábbihoz hasonló eredményt kell látnod:

    ![Eredmény a promptból](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **A fent látott eredmény attól függ, milyen eszközöket állítottál be, de az ötlet az, hogy szöveges választ kapj.**


## Hivatkozások

Így tudsz többet megtudni:

- [Útmutató az Azure API Management és MCP használatához](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python példa: Távoli MCP szerverek biztonságos kezelése Azure API Management segítségével (kísérleti)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP kliens jogosultság labor](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Használd az Azure API Management bővítményt VS Code-hoz API-k importálásához és kezeléséhez](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Távoli MCP szerverek regisztrálása és felfedezése az Azure API Centerben](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Kiváló repó, amely számos AI képességet mutat be az Azure API Management segítségével
- [AI Gateway workshopok](https://azure-samples.github.io/AI-Gateway/) Workshopokat tartalmaz az Azure Portal használatával, ami nagyszerű módja az AI képességek kipróbálásának.

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.