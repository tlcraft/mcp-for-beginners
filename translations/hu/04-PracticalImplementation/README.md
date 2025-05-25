<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:59:37+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hu"
}
-->
# Gyakorlati Megvalósítás

A gyakorlati megvalósítás az a pont, ahol a Model Context Protocol (MCP) ereje kézzelfoghatóvá válik. Bár az MCP mögötti elmélet és architektúra megértése fontos, az igazi érték akkor jelenik meg, amikor ezeket a koncepciókat alkalmazva olyan megoldásokat építünk, tesztelünk és helyezünk üzembe, amelyek valós problémákat oldanak meg. Ez a fejezet hidat képez az elméleti tudás és a gyakorlati fejlesztés között, végigvezetve az MCP-alapú alkalmazások életre keltésének folyamatán.

Akár intelligens asszisztenseket fejlesztesz, akár az AI-t integrálod üzleti munkafolyamatokba, vagy egyedi eszközöket építesz adatfeldolgozásra, az MCP rugalmas alapot biztosít. Nyelvfüggetlen tervezése és hivatalos SDK-i a népszerű programozási nyelvekhez széles körben elérhetővé teszik a fejlesztők számára. Ezeket az SDK-kat kihasználva gyorsan prototípust készíthetsz, iterálhatsz és skálázhatod megoldásaidat különböző platformokon és környezetekben.

A következő szakaszokban gyakorlati példákat, mintakódokat és üzembe helyezési stratégiákat találsz, amelyek bemutatják, hogyan lehet az MCP-t megvalósítani C#, Java, TypeScript, JavaScript és Python nyelveken. Megtanulhatod továbbá, hogyan kell hibakeresni és tesztelni az MCP szervereket, kezelni az API-kat, és megoldásokat telepíteni a felhőbe az Azure használatával. Ezek a gyakorlati források célja, hogy felgyorsítsák a tanulási folyamatot, és segítsenek magabiztosan felépíteni robusztus, termelésre kész MCP alkalmazásokat.

## Áttekintés

Ez a lecke az MCP megvalósításának gyakorlati aspektusaira összpontosít több programozási nyelven. Megvizsgáljuk, hogyan használhatók az MCP SDK-k C#, Java, TypeScript, JavaScript és Python nyelveken, hogy robusztus alkalmazásokat építsünk, hibakeressünk és teszteljünk MCP szervereket, és újrahasznosítható erőforrásokat, utasításokat és eszközöket hozzunk létre.

## Tanulási Célok

A lecke végére képes leszel:
- MCP megoldásokat megvalósítani hivatalos SDK-k használatával különböző programozási nyelveken
- Rendszeresen hibakeresni és tesztelni MCP szervereket
- Szerver funkciókat létrehozni és használni (Erőforrások, Utasítások és Eszközök)
- Hatékony MCP munkafolyamatokat tervezni összetett feladatokhoz
- Optimalizálni MCP megvalósításokat a teljesítmény és megbízhatóság érdekében

## Hivatalos SDK Források

A Model Context Protocol hivatalos SDK-kat kínál több nyelvhez:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK-k Használata

Ez a szakasz gyakorlati példákat nyújt az MCP megvalósítására több programozási nyelven. Mintakódot találhatsz a `samples` könyvtárban, nyelvek szerint rendszerezve.

### Elérhető Minták

A tároló a következő nyelveken tartalmaz mintamegvalósításokat:

- C#
- Java
- TypeScript
- JavaScript
- Python

Mindegyik minta bemutatja az MCP alapvető fogalmait és megvalósítási mintáit az adott nyelv és ökoszisztéma számára.

## Alapvető Szerver Funkciók

Az MCP szerverek bármilyen kombinációját megvalósíthatják ezeknek a funkcióknak:

### Erőforrások
Az erőforrások kontextust és adatokat biztosítanak a felhasználó vagy az AI modell számára:
- Dokumentum tárolók
- Tudásbázisok
- Strukturált adatforrások
- Fájlrendszerek

### Utasítások
Az utasítások sablonüzenetek és munkafolyamatok a felhasználók számára:
- Előre definiált beszélgetési sablonok
- Irányított interakciós minták
- Speciális párbeszédszerkezetek

### Eszközök
Az eszközök olyan funkciók, amelyeket az AI modell hajt végre:
- Adatfeldolgozási segédprogramok
- Külső API integrációk
- Számítási képességek
- Keresési funkciók

## Mintamegvalósítások: C#

A hivatalos C# SDK tároló több mintamegvalósítást tartalmaz, amelyek bemutatják az MCP különböző aspektusait:

- **Alapvető MCP Kliens**: Egyszerű példa arra, hogyan lehet MCP klienst létrehozni és eszközöket hívni
- **Alapvető MCP Szerver**: Minimális szervermegvalósítás alapvető eszközregisztrációval
- **Haladó MCP Szerver**: Teljes funkcionalitású szerver eszközregisztrációval, hitelesítéssel és hibakezeléssel
- **ASP.NET Integráció**: Példák az ASP.NET Core integrációjára
- **Eszközmegvalósítási Minták**: Különböző minták eszközök megvalósítására különböző bonyolultsági szinteken

Az MCP C# SDK előzetes verzióban van, és az API-k változhatnak. Folyamatosan frissítjük ezt a blogot, ahogy az SDK fejlődik.

### Főbb Jellemzők 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Az első [MCP Szerver](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) felépítése.

A teljes C# megvalósítási mintákért látogasd meg a [hivatalos C# SDK minták tárolóját](https://github.com/modelcontextprotocol/csharp-sdk)

## Mintamegvalósítás: Java Megvalósítás

A Java SDK robusztus MCP megvalósítási lehetőségeket kínál vállalati szintű funkciókkal.

### Főbb Jellemzők

- Spring Framework integráció
- Erős típusbiztonság
- Reaktív programozási támogatás
- Átfogó hibakezelés

A teljes Java megvalósítási mintáért lásd a [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) fájlt a minták könyvtárában.

## Mintamegvalósítás: JavaScript Megvalósítás

A JavaScript SDK könnyű és rugalmas megközelítést kínál az MCP megvalósítására.

### Főbb Jellemzők

- Node.js és böngésző támogatás
- Ígéret alapú API
- Könnyű integráció az Express és más keretrendszerekkel
- WebSocket támogatás streaminghez

A teljes JavaScript megvalósítási mintáért lásd a [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) fájlt a minták könyvtárában.

## Mintamegvalósítás: Python Megvalósítás

A Python SDK Pythonos megközelítést kínál az MCP megvalósítására kiváló ML keretrendszer integrációkkal.

### Főbb Jellemzők

- Async/await támogatás az asyncio-val
- Flask és FastAPI integráció
- Egyszerű eszközregisztráció
- Natív integráció népszerű ML könyvtárakkal

A teljes Python megvalósítási mintáért lásd a [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) fájlt a minták könyvtárában.

## API kezelés

Az Azure API Management kiváló megoldás arra, hogyan biztosíthatjuk az MCP szervereket. Az ötlet az, hogy egy Azure API Management példányt helyezzünk el az MCP szerver elé, és hagyjuk, hogy kezelje azokat a funkciókat, amelyeket valószínűleg szeretnénk, mint például:

- sebességkorlátozás
- token kezelés
- monitorozás
- terheléselosztás
- biztonság

### Azure Minta

Itt van egy Azure Minta, amely pontosan ezt teszi, azaz [MCP Szerver létrehozása és biztosítása Azure API Management segítségével](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Lásd, hogyan történik a hitelesítési folyamat az alábbi képen:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Az előző képen a következő történik:

- A hitelesítés/engedélyezés a Microsoft Entra használatával történik.
- Az Azure API Management átjáróként működik, és politikákat használ a forgalom irányítására és kezelésére.
- Az Azure Monitor minden kérést naplóz további elemzés céljából.

#### Engedélyezési folyamat

Nézzük meg részletesebben az engedélyezési folyamatot:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP engedélyezési specifikáció

Tudj meg többet az [MCP Engedélyezési specifikációról](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Távoli MCP Szerver Telepítése Azure-ra

Nézzük meg, hogy telepíthetjük-e a korábban említett mintát:

1. Klónozd a tárolót

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Regisztráld `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` egy idő után, hogy ellenőrizd, hogy a regisztráció befejeződött-e.

2. Futtasd ezt az [azd](https://aka.ms/azd) parancsot az API kezelési szolgáltatás, a funkcióalkalmazás (kóddal) és minden más szükséges Azure erőforrás előkészítéséhez

    ```shell
    azd up
    ```

    Ez a parancs az összes felhőalapú erőforrást telepíti az Azure-ra

### Szerver tesztelése az MCP Inspectorral

1. Egy **új terminálablakban** telepítsd és futtasd az MCP Inspectort

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Látni fogsz egy hasonló felületet:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.hu.png)

1. CTRL kattintással töltsd be az MCP Inspector webalkalmazást az alkalmazás által megjelenített URL-ről (pl. http://127.0.0.1:6274/#resources)
1. Állítsd be a szállítási típust `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` és **Csatlakozás**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Eszközök Listázása**. Kattints egy eszközre és **Eszköz Futattása**.

Ha minden lépés sikeres volt, akkor most csatlakoztál az MCP szerverhez, és képes voltál meghívni egy eszközt.

## MCP szerverek az Azure számára

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ez a tárolókészlet gyorsindítási sablonokat tartalmaz egyedi távoli MCP (Model Context Protocol) szerverek építéséhez és telepítéséhez az Azure Functions segítségével Python, C# .NET vagy Node/TypeScript nyelveken.

A Minták teljes megoldást nyújtanak, amely lehetővé teszi a fejlesztők számára:

- Helyi építés és futtatás: MCP szerver fejlesztése és hibakeresése helyi gépen
- Telepítés Azure-ra: Könnyű telepítés a felhőbe egy egyszerű azd up paranccsal
- Csatlakozás ügyfelekről: Csatlakozás az MCP szerverhez különböző ügyfelekből, beleértve a VS Code Copilot ügynök módját és az MCP Inspector eszközt

### Főbb Jellemzők:

- Biztonság a tervezés során: Az MCP szerver kulcsok és HTTPS használatával van biztosítva
- Hitelesítési lehetőségek: Támogatja az OAuth-ot beépített hitelesítéssel és/vagy API Management segítségével
- Hálózati izoláció: Lehetővé teszi a hálózati izolációt az Azure Virtuális Hálózatok (VNET) használatával
- Szerver nélküli architektúra: Az Azure Functions-t használja skálázható, eseményvezérelt végrehajtáshoz
- Helyi fejlesztés: Átfogó helyi fejlesztési és hibakeresési támogatás
- Egyszerű telepítés: Egyszerűsített telepítési folyamat az Azure-ra

A tároló tartalmazza az összes szükséges konfigurációs fájlt, forráskódot és infrastruktúra-definíciót, hogy gyorsan el lehessen kezdeni egy termelésre kész MCP szerver megvalósítást.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - MCP mintamegvalósítás az Azure Functions segítségével Python nyelven

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - MCP mintamegvalósítás az Azure Functions segítségével C# .NET nyelven

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - MCP mintamegvalósítás az Azure Functions segítségével Node/TypeScript nyelven.

## Főbb Tanulságok

- Az MCP SDK-k nyelvspecifikus eszközöket biztosítanak robusztus MCP megoldások megvalósításához
- A hibakeresési és tesztelési folyamat kritikus a megbízható MCP alkalmazásokhoz
- Az újrahasznosítható utasítássablonok következetes AI interakciókat tesznek lehetővé
- A jól megtervezett munkafolyamatok több eszköz használatával összetett feladatokat tudnak összehangolni
- Az MCP megoldások megvalósítása megköveteli a biztonság, a teljesítmény és a hibakezelés figyelembevételét

## Gyakorlat

Tervezzen meg egy gyakorlati MCP munkafolyamatot, amely egy valós problémát kezel a saját területén:

1. Azonosíts 3-4 eszközt, amelyek hasznosak lennének a probléma megoldásához
2. Készíts egy munkafolyamat-diagramot, amely bemutatja, hogyan lépnek kapcsolatba ezek az eszközök
3. Valósítsd meg az egyik eszköz alapverzióját a választott nyelveden
4. Készíts egy utasítássablont, amely segíti a modellt az eszköz hatékony használatában

## További Források

---

Következő: [Haladó Témák](../05-AdvancedTopics/README.md)

**Felelősség kizárása**:  
Ezt a dokumentumot az AI fordítási szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.