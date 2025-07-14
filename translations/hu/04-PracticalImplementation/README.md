<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:21:24+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hu"
}
-->
# Gyakorlati megvalósítás

A gyakorlati megvalósítás az a pont, ahol a Model Context Protocol (MCP) ereje kézzelfoghatóvá válik. Bár fontos megérteni az MCP mögötti elméletet és architektúrát, az igazi érték akkor mutatkozik meg, amikor ezeket a fogalmakat alkalmazva valós problémákat megoldó megoldásokat építesz, tesztelsz és telepítesz. Ez a fejezet hidat képez az elméleti tudás és a gyakorlati fejlesztés között, és végigvezet a MCP-alapú alkalmazások életre keltésének folyamatán.

Akár intelligens asszisztenseket fejlesztesz, AI-t integrálsz üzleti munkafolyamatokba, vagy egyedi eszközöket építesz adatfeldolgozáshoz, az MCP rugalmas alapot biztosít. Nyelvfüggetlen kialakítása és a népszerű programozási nyelvekhez készült hivatalos SDK-k széles fejlesztői kör számára elérhetővé teszik. Ezeket az SDK-kat kihasználva gyorsan prototípust készíthetsz, iterálhatsz, és skálázhatod megoldásaidat különböző platformokon és környezetekben.

A következő szakaszokban gyakorlati példákat, mintakódokat és telepítési stratégiákat találsz, amelyek bemutatják, hogyan valósítható meg az MCP C#, Java, TypeScript, JavaScript és Python nyelveken. Megtanulod továbbá, hogyan hibakeress és tesztelj MCP szervereket, hogyan kezeld az API-kat, és hogyan telepíts megoldásokat az Azure felhőbe. Ezek a gyakorlati anyagok felgyorsítják a tanulásodat, és segítenek magabiztosan felépíteni robusztus, éles környezetbe szánt MCP alkalmazásokat.

## Áttekintés

Ez a lecke az MCP megvalósítás gyakorlati aspektusaira fókuszál több programozási nyelven keresztül. Megvizsgáljuk, hogyan használhatók az MCP SDK-k C#, Java, TypeScript, JavaScript és Python nyelveken robusztus alkalmazások építéséhez, MCP szerverek hibakereséséhez és teszteléséhez, valamint újrahasznosítható erőforrások, promptok és eszközök létrehozásához.

## Tanulási célok

A lecke végére képes leszel:
- MCP megoldásokat megvalósítani a hivatalos SDK-k segítségével különböző programozási nyelveken
- Rendszeresen hibakeresni és tesztelni MCP szervereket
- Szerverfunkciókat létrehozni és használni (Erőforrások, Promptok és Eszközök)
- Hatékony MCP munkafolyamatokat tervezni összetett feladatokhoz
- Optimalizálni az MCP megvalósításokat teljesítmény és megbízhatóság szempontjából

## Hivatalos SDK erőforrások

A Model Context Protocol több nyelvhez kínál hivatalos SDK-kat:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK-k használata

Ez a szakasz gyakorlati példákat mutat be az MCP megvalósítására több programozási nyelven. A `samples` könyvtárban nyelvenként rendezett mintakódokat találsz.

### Elérhető minták

A tároló a következő nyelveken tartalmaz [mintamegvalósításokat](../../../04-PracticalImplementation/samples):

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Minden minta bemutatja az adott nyelv és ökoszisztéma kulcsfontosságú MCP fogalmait és megvalósítási mintáit.

## Alapszerver funkciók

Az MCP szerverek bármilyen kombinációban megvalósíthatják az alábbi funkciókat:

### Erőforrások
Az erőforrások kontextust és adatokat biztosítanak a felhasználó vagy az AI modell számára:
- Dokumentumtárak
- Tudásbázisok
- Strukturált adatforrások
- Fájlrendszerek

### Promptok
A promptok sablonosított üzenetek és munkafolyamatok a felhasználók számára:
- Előre definiált beszélgetési sablonok
- Irányított interakciós minták
- Speciális párbeszédstruktúrák

### Eszközök
Az eszközök olyan funkciók, amelyeket az AI modell végrehajthat:
- Adatfeldolgozó segédprogramok
- Külső API integrációk
- Számítási képességek
- Keresési funkciók

## Mintamegvalósítások: C#

A hivatalos C# SDK tároló több mintamegvalósítást tartalmaz, amelyek az MCP különböző aspektusait mutatják be:

- **Alap MCP kliens**: Egyszerű példa arra, hogyan hozzunk létre MCP klienst és hívjunk meg eszközöket
- **Alap MCP szerver**: Minimális szervermegvalósítás alapvető eszközregisztrációval
- **Fejlett MCP szerver**: Teljes funkcionalitású szerver eszközregisztrációval, hitelesítéssel és hibakezeléssel
- **ASP.NET integráció**: Példák az ASP.NET Core integrációjára
- **Eszközmegvalósítási minták**: Különböző minták eszközök megvalósítására különböző bonyolultsági szinteken

A MCP C# SDK előzetes verzióban van, és az API-k változhatnak. A blogot folyamatosan frissítjük az SDK fejlődésével.

### Főbb jellemzők
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Az [első MCP szervered felépítése](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

A teljes C# megvalósítási mintákért látogass el a [hivatalos C# SDK minták tárolójába](https://github.com/modelcontextprotocol/csharp-sdk)

## Mintamegvalósítás: Java megvalósítás

A Java SDK robusztus MCP megvalósítási lehetőségeket kínál vállalati szintű funkciókkal.

### Főbb jellemzők

- Spring Framework integráció
- Erős típusbiztonság
- Reaktív programozás támogatása
- Átfogó hibakezelés

A teljes Java megvalósítási mintáért lásd a [Java mintát](samples/java/containerapp/README.md) a mintakönyvtárban.

## Mintamegvalósítás: JavaScript megvalósítás

A JavaScript SDK könnyű és rugalmas megközelítést kínál az MCP megvalósításához.

### Főbb jellemzők

- Node.js és böngésző támogatás
- Promise-alapú API
- Egyszerű integráció Express és más keretrendszerekkel
- WebSocket támogatás streaminghez

A teljes JavaScript megvalósítási mintáért lásd a [JavaScript mintát](samples/javascript/README.md) a mintakönyvtárban.

## Mintamegvalósítás: Python megvalósítás

A Python SDK pythonos megközelítést kínál az MCP megvalósításához, kiváló ML keretrendszer integrációkkal.

### Főbb jellemzők

- Async/await támogatás asyncio-val
- FastAPI integráció
- Egyszerű eszközregisztráció
- Natív integráció népszerű ML könyvtárakkal

A teljes Python megvalósítási mintáért lásd a [Python mintát](samples/python/README.md) a mintakönyvtárban.

## API kezelés

Az Azure API Management remek megoldás arra, hogyan biztosíthatjuk az MCP szervereket. Az ötlet, hogy egy Azure API Management példányt helyezünk az MCP szerver elé, amely kezeli az olyan funkciókat, amikre valószínűleg szükséged lesz, például:

- sebességkorlátozás
- tokenkezelés
- monitorozás
- terheléselosztás
- biztonság

### Azure minta

Itt egy Azure minta, amely pontosan ezt valósítja meg, azaz [MCP szerver létrehozása és Azure API Managementtel való biztosítása](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Nézd meg, hogyan zajlik az engedélyezési folyamat az alábbi képen:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

A fenti képen a következők történnek:

- Hitelesítés/engedélyezés Microsoft Entra segítségével zajlik.
- Az Azure API Management kapuként működik, és szabályzatokat használ a forgalom irányítására és kezelésére.
- Az Azure Monitor naplózza az összes kérést további elemzés céljából.

#### Engedélyezési folyamat

Nézzük meg részletesebben az engedélyezési folyamatot:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP engedélyezési specifikáció

Tudj meg többet az [MCP engedélyezési specifikációról](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Távoli MCP szerver telepítése Azure-ra

Nézzük meg, hogyan telepíthetjük az előbb említett mintát:

1. Klónozd a tárolót

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Regisztráld a `Microsoft.App` erőforrás szolgáltatót.
    * Ha Azure CLI-t használsz, futtasd az `az provider register --namespace Microsoft.App --wait` parancsot.
    * Ha Azure PowerShell-t használsz, futtasd a `Register-AzResourceProvider -ProviderNamespace Microsoft.App` parancsot. Ezután egy kis idő múlva ellenőrizd a regisztráció állapotát a `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` paranccsal.

2. Futtasd ezt az [azd](https://aka.ms/azd) parancsot az API Management szolgáltatás, a funkcióalkalmazás (kóddal) és az összes szükséges Azure erőforrás létrehozásához

    ```shell
    azd up
    ```

    Ez a parancs telepíti az összes felhő erőforrást az Azure-on.

### Szerver tesztelése MCP Inspectorral

1. Egy **új terminál ablakban** telepítsd és futtasd az MCP Inspectort

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Egy hasonló felületet kell látnod:

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png)

1. CTRL kattintással töltsd be az MCP Inspector webalkalmazást az alkalmazás által megjelenített URL-ről (pl. http://127.0.0.1:6274/#resources)
1. Állítsd a szállítási típust `SSE`-re
1. Állítsd be az URL-t az `azd up` parancs után megjelenő futó API Management SSE végpontra, majd kattints a **Connect** gombra:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Eszközök listázása**. Kattints egy eszközre, majd válaszd a **Run Tool** lehetőséget.

Ha minden lépés sikeres volt, most már csatlakozva vagy az MCP szerverhez, és sikeresen meghívtál egy eszközt.

## MCP szerverek Azure-hoz

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ezek a tárolók gyorsindító sablonokat kínálnak egyedi távoli MCP (Model Context Protocol) szerverek építéséhez és telepítéséhez Azure Functions segítségével Python, C# .NET vagy Node/TypeScript nyelveken.

A minták teljes megoldást nyújtanak, amely lehetővé teszi a fejlesztők számára, hogy:

- Helyben fejlesszenek és futtassanak: MCP szerver fejlesztése és hibakeresése helyi gépen
- Telepítsenek Azure-ra: Egyszerűen telepíthető a felhőbe egyetlen azd up paranccsal
- Csatlakozzanak kliensekről: Különböző kliensekről csatlakozhatnak az MCP szerverhez, beleértve a VS Code Copilot ügynök módját és az MCP Inspector eszközt

### Főbb jellemzők:

- Biztonság tervezésből: Az MCP szerver kulcsokkal és HTTPS-sel van védve
- Hitelesítési lehetőségek: OAuth támogatás beépített hitelesítéssel és/vagy API Managementtel
- Hálózati izoláció: Azure Virtuális Hálózatok (VNET) használata hálózati izolációhoz
- Serverless architektúra: Azure Functions használata skálázható, eseményvezérelt végrehajtáshoz
- Helyi fejlesztés: Átfogó helyi fejlesztési és hibakeresési támogatás
- Egyszerű telepítés: Egyszerűsített telepítési folyamat Azure-ra

A tároló tartalmaz minden szükséges konfigurációs fájlt, forráskódot és infrastruktúra definíciót, hogy gyorsan elindulhass egy éles környezetbe szánt MCP szerver megvalósítással.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - MCP mintamegvalósítás Azure Functions segítségével Python nyelven

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - MCP mintamegvalósítás Azure Functions segítségével C# .NET nyelven

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - MCP mintamegvalósítás Azure Functions segítségével Node/TypeScript nyelven

## Főbb tanulságok

- Az MCP SDK-k nyelvspecifikus eszközöket biztosítanak robusztus MCP megoldások megvalósításához
- A hibakeresési és tesztelési folyamat kritikus a megbízható MCP alkalmazásokhoz
- Az újrahasznosítható prompt sablonok egységes AI interakciókat tesznek lehetővé
- A jól megtervezett munkafolyamatok összetett feladatokat képesek több eszköz segítségével koordinálni
- Az MCP megoldások megvalósítása során figyelembe kell venni a biztonságot, teljesítményt és hibakezelést

## Gyakorlat

Tervezzen egy gyakorlati MCP munkafolyamatot, amely egy valós problémát old meg az Ön területén:

1. Azonosítson 3-4 eszközt, amelyek hasznosak lehetnek a probléma megoldásához
2. Készítsen egy munkafolyamat-diagramot, amely bemutatja, hogyan lépnek kölcsönhatásba ezek az eszközök
3. Valósítson meg egy alapverziót az egyik eszközből a választott nyelvén
4. Készítsen egy prompt sablont, amely segíti a modellt az eszköz hatékony használatában

## További források


---

Következő: [Haladó témák](../05-AdvancedTopics/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.