<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:27:09+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hu"
}
-->
# Gyakorlati megvalósítás

A gyakorlati megvalósítás az a pont, ahol a Model Context Protocol (MCP) ereje kézzelfoghatóvá válik. Bár fontos megérteni az MCP mögötti elméletet és architektúrát, az igazi érték akkor jön elő, amikor ezeket a fogalmakat alkalmazod a valódi problémák megoldására szolgáló megoldások építésében, tesztelésében és üzembe helyezésében. Ez a fejezet hidat képez az elméleti tudás és a gyakorlati fejlesztés között, és végigvezet a MCP-alapú alkalmazások életre keltésének folyamatán.

Legyen szó intelligens asszisztensek fejlesztéséről, AI üzleti munkafolyamatokba való integrálásáról vagy egyedi eszközök készítéséről adatfeldolgozáshoz, az MCP rugalmas alapot nyújt. Nyelvfüggetlen kialakítása és a népszerű programozási nyelvekhez készült hivatalos SDK-k révén széles fejlesztői kör számára elérhető. Ezeknek az SDK-knak a segítségével gyorsan prototípust készíthetsz, iterálhatsz, és skálázhatod megoldásaidat különböző platformokon és környezetekben.

A következő szakaszokban gyakorlati példákat, mintakódokat és telepítési stratégiákat találsz, amelyek bemutatják, hogyan valósíthatod meg az MCP-t C#, Java, TypeScript, JavaScript és Python nyelveken. Megtanulod, hogyan hibakeresd és teszteld az MCP szervereket, kezeld az API-kat, és hogyan telepíts megoldásokat a felhőbe Azure segítségével. Ezek a gyakorlati anyagok arra szolgálnak, hogy felgyorsítsák a tanulásodat, és magabiztosan építhess robosztus, éles környezetbe szánt MCP alkalmazásokat.

## Áttekintés

Ez a lecke az MCP megvalósításának gyakorlati aspektusaira koncentrál több programozási nyelven keresztül. Megvizsgáljuk, hogyan használhatod az MCP SDK-kat C#, Java, TypeScript, JavaScript és Python nyelveken, hogy robusztus alkalmazásokat építs, hibakeress és tesztelj MCP szervereket, valamint újrahasznosítható erőforrásokat, promptokat és eszközöket hozz létre.

## Tanulási célok

A lecke végére képes leszel:
- MCP megoldásokat megvalósítani hivatalos SDK-k segítségével különböző programozási nyelveken
- Rendszeresen hibakeresni és tesztelni MCP szervereket
- Szerverfunkciókat létrehozni és használni (Erőforrások, Promptok és Eszközök)
- Hatékony MCP munkafolyamatokat tervezni összetett feladatokra
- Optimalizálni az MCP megvalósításokat teljesítmény és megbízhatóság szempontjából

## Hivatalos SDK erőforrások

A Model Context Protocol hivatalos SDK-kat kínál több nyelvhez:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK-k használata

Ebben a részben gyakorlati példákat találsz az MCP megvalósítására több programozási nyelven. A mintakódok a `samples` könyvtárban nyelv szerint rendezve érhetők el.

### Elérhető minták

A tárház a következő nyelveken tartalmaz [mintamegvalósításokat](../../../04-PracticalImplementation/samples):

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Minden minta bemutatja az adott nyelv és ökoszisztéma kulcsfontosságú MCP fogalmait és megvalósítási mintáit.

## Alapszerver funkciók

Az MCP szerverek bármilyen kombinációban megvalósíthatják az alábbi funkciókat:

### Erőforrások
Az erőforrások kontextust és adatokat szolgáltatnak a felhasználónak vagy az AI modellnek:
- Dokumentumtárak
- Tudásbázisok
- Strukturált adatforrások
- Fájlrendszerek

### Promptok
A promptok sablonos üzenetek és munkafolyamatok a felhasználók számára:
- Előre definiált beszélgetési sablonok
- Irányított interakciós minták
- Specializált párbeszédstruktúrák

### Eszközök
Az eszközök olyan funkciók, amelyeket az AI modell végrehajthat:
- Adatfeldolgozó segédprogramok
- Külső API integrációk
- Számítási képességek
- Keresési funkciók

## Mintamegvalósítások: C#

A hivatalos C# SDK tárház több mintamegvalósítást tartalmaz, amelyek az MCP különböző aspektusait mutatják be:

- **Alap MCP kliens**: Egyszerű példa arra, hogyan hozhatsz létre MCP klienst és hívhatsz meg eszközöket
- **Alap MCP szerver**: Minimális szervermegvalósítás alapvető eszközregisztrációval
- **Fejlett MCP szerver**: Teljes funkcionalitású szerver eszközregisztrációval, hitelesítéssel és hibakezeléssel
- **ASP.NET integráció**: Példák az ASP.NET Core integrációjára
- **Eszköz megvalósítási minták**: Különféle minták az eszközök különböző komplexitási szinteken történő megvalósításához

A MCP C# SDK előnézet alatt áll, és az API-k változhatnak. A blogot folyamatosan frissítjük az SDK fejlődésével.

### Főbb funkciók
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Első [MCP szervered építése](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

A teljes C# megvalósítási mintákért látogass el a [hivatalos C# SDK minták tárházába](https://github.com/modelcontextprotocol/csharp-sdk)

## Mintamegvalósítás: Java

A Java SDK vállalati szintű funkciókat kínál az MCP megbízható megvalósításához.

### Főbb funkciók

- Spring Framework integráció
- Erős típusbiztonság
- Reaktív programozás támogatása
- Átfogó hibakezelés

A teljes Java megvalósítási mintáért lásd a [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) fájlt a mintakönyvtárban.

## Mintamegvalósítás: JavaScript

A JavaScript SDK könnyű és rugalmas megközelítést nyújt az MCP megvalósításához.

### Főbb funkciók

- Node.js és böngésző támogatás
- Promise-alapú API
- Egyszerű integráció Express és más keretrendszerekkel
- WebSocket támogatás streaminghez

A teljes JavaScript megvalósítási mintáért lásd a [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) fájlt a mintakönyvtárban.

## Mintamegvalósítás: Python

A Python SDK pythonos megközelítést kínál az MCP megvalósításához, kiváló ML keretrendszer integrációkkal.

### Főbb funkciók

- Async/await támogatás asyncio-val
- Flask és FastAPI integráció
- Egyszerű eszközregisztráció
- Natív integráció népszerű ML könyvtárakkal

A teljes Python megvalósítási mintáért lásd a [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) fájlt a mintakönyvtárban.

## API-kezelés

Az Azure API Management remek megoldás arra, hogyan biztosíthatjuk az MCP szervereket. Az ötlet, hogy egy Azure API Management példányt helyezünk az MCP szerver elé, és hagyjuk, hogy kezelje az olyan funkciókat, amelyeket valószínűleg szeretnénk, mint például:

- sebességkorlátozás
- tokenkezelés
- monitorozás
- terheléselosztás
- biztonság

### Azure minta

Íme egy Azure minta, amely pontosan ezt csinálja, azaz [MCP szerver létrehozása és biztosítása Azure API Management segítségével](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Nézd meg, hogyan zajlik az engedélyezési folyamat az alábbi képen:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

A fenti képen a következők történnek:

- Hitelesítés/engedélyezés Microsoft Entra segítségével történik.
- Az Azure API Management kapuként működik, és szabályokat alkalmaz a forgalom irányítására és kezelésére.
- Az Azure Monitor minden kérést naplóz további elemzés céljából.

#### Engedélyezési folyamat

Nézzük meg részletesebben az engedélyezési folyamatot:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP engedélyezési specifikáció

További információkért olvasd el az [MCP Engedélyezési specifikációt](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Távoli MCP szerver telepítése Azure-ra

Nézzük meg, hogyan telepíthetjük a korábban említett mintát:

1. Klónozd a tárházat

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Regisztráld a `Microsoft.App` szolgáltatót:

    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `

    majd ellenőrizd néhány perc múlva a regisztráció állapotát:

    `. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState

3. Futtasd ezt az [azd](https://aka.ms/azd) parancsot az API Management szolgáltatás, a function app (kóddal) és minden egyéb szükséges Azure erőforrás létrehozásához:

    ```shell
    azd up
    ```

    Ez a parancs telepíti az összes felhő erőforrást Azure-on.

### Szerver tesztelése MCP Inspectorral

1. Egy **új terminál ablakban** telepítsd és futtasd az MCP Inspectort:

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Olyan felületet kell látnod, mint:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

2. CTRL kattintással töltsd be az MCP Inspector webalkalmazást az alkalmazás által megjelenített URL-ről (pl. http://127.0.0.1:6274/#resources)
3. Állítsd a szállítási típust `SSE`-re `
1. Set the URL to your running API Management SSE endpoint displayed after `azd up`
1. Set the URL to your running API Management SSE endpoint displayed after ` és **Csatlakozás**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Eszközök listázása**. Kattints egy eszközre, majd **Futtasd az eszközt**.

Ha minden lépés sikeres volt, most már kapcsolódva vagy az MCP szerverhez, és sikerült meghívnod egy eszközt.

## MCP szerverek Azure-hoz

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ezek a tárházak gyorsindító sablonok egyedi távoli MCP (Model Context Protocol) szerverek építéséhez és telepítéséhez Azure Functions segítségével Python, C# .NET vagy Node/TypeScript nyelveken.

A minták teljes megoldást kínálnak, amely lehetővé teszi a fejlesztők számára, hogy:

- Helyben fejlesszenek és futtassanak: MCP szerver fejlesztése és hibakeresése helyi gépen
- Telepítsenek Azure-ra: Egyszerű `azd up` paranccsal telepíthető a felhőbe
- Különböző kliensekről kapcsolódjanak: Kapcsolódás az MCP szerverhez különböző kliensekről, beleértve a VS Code Copilot ügynök módját és az MCP Inspector eszközt

### Főbb jellemzők:

- Biztonság tervezésből: Az MCP szerver kulcsokkal és HTTPS-sel védett
- Hitelesítési lehetőségek: OAuth támogatás beépített hitelesítéssel és/vagy API Managementtel
- Hálózati izoláció: Azure Virtuális Hálózatok (VNET) használatával
- Szerver nélküli architektúra: Azure Functions használata skálázható, eseményvezérelt végrehajtáshoz
- Helyi fejlesztés: Átfogó helyi fejlesztési és hibakeresési támogatás
- Egyszerű telepítés: Egyszerűsített telepítési folyamat Azure-ra

A tárház tartalmaz minden szükséges konfigurációs fájlt, forráskódot és infrastruktúra definíciót, hogy gyorsan elindulhass egy éles környezetbe szánt MCP szerver megvalósítással.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - MCP minta megvalósítás Azure Functions használatával Python nyelven

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - MCP minta megvalósítás Azure Functions használatával C# .NET nyelven

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - MCP minta megvalósítás Azure Functions használatával Node/TypeScript nyelveken.

## Fontos tanulságok

- Az MCP SDK-k nyelvspecifikus eszközöket biztosítanak robosztus MCP megoldások megvalósításához
- A hibakeresés és tesztelés kritikus a megbízható MCP alkalmazásokhoz
- Az újrahasznosítható prompt sablonok következetes AI interakciókat tesznek lehetővé
- A jól megtervezett munkafolyamatok összetett feladatokat képesek koordinálni több eszköz használatával
- Az MCP megvalósításakor figyelembe kell venni a biztonságot, teljesítményt és hibakezelést

## Gyakorlat

Tervezzen egy gyakorlati MCP munkafolyamatot, amely egy valós problémát old meg az Ön szakterületén:

1. Azonosítson 3-4 olyan eszközt, amelyek hasznosak lehetnek a probléma megoldásához
2. Készítsen munkafolyamat-diagramot, amely bemutatja, hogyan lépnek interakcióba ezek az eszközök
3. Valósítson meg egy alapverziót az egyik eszközből a választott nyelvén
4. Készítsen egy prompt sablont, amely segíti a modellt az eszköz hatékony használatában

## További erőforrások


---

Következő: [Haladó témák](../05-AdvancedTopics/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum a saját nyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy félreértelmezésekért.