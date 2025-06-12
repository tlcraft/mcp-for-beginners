<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:24:30+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hu"
}
-->
# Gyakorlati megvalósítás

A gyakorlati megvalósítás az a pont, ahol a Model Context Protocol (MCP) ereje kézzelfoghatóvá válik. Bár az MCP elméletének és architektúrájának megértése fontos, az igazi érték akkor bontakozik ki, amikor ezeket a fogalmakat alkalmazod, hogy valós problémákat megoldó megoldásokat építs, tesztelj és telepíts. Ez a fejezet hidat képez az elméleti tudás és a gyakorlati fejlesztés között, végigvezetve az MCP-alapú alkalmazások életre keltésének folyamatán.

Akár intelligens asszisztenseket fejlesztesz, AI-t integrálsz üzleti munkafolyamatokba, vagy egyedi eszközöket építesz adatfeldolgozáshoz, az MCP rugalmas alapot nyújt. Nyelvfüggetlen kialakítása és a népszerű programozási nyelvekhez készült hivatalos SDK-k széles fejlesztői kör számára elérhetővé teszik. Ezeket az SDK-kat kihasználva gyorsan készíthetsz prototípusokat, iterálhatsz és méretezheted megoldásaidat különböző platformokon és környezetekben.

A következő szakaszokban gyakorlati példákat, mintakódokat és telepítési stratégiákat találsz, amelyek bemutatják, hogyan valósítható meg az MCP C#, Java, TypeScript, JavaScript és Python nyelveken. Megtanulod továbbá, hogyan hibakeress és tesztelj MCP szervereket, hogyan kezeld az API-kat, és hogyan telepíts megoldásokat a felhőbe Azure használatával. Ezek a gyakorlati anyagok felgyorsítják a tanulást, és segítenek magabiztosan építeni megbízható, éles környezetbe szánt MCP alkalmazásokat.

## Áttekintés

Ez a lecke az MCP megvalósításának gyakorlati aspektusaira koncentrál több programozási nyelven keresztül. Megvizsgáljuk, hogyan használhatod az MCP SDK-kat C#, Java, TypeScript, JavaScript és Python nyelveken robusztus alkalmazások építéséhez, MCP szerverek hibakereséséhez és teszteléséhez, valamint újrahasznosítható erőforrások, promptok és eszközök létrehozásához.

## Tanulási célok

A lecke végére képes leszel:
- MCP megoldásokat megvalósítani a hivatalos SDK-k segítségével különböző programozási nyelveken
- Rendszeresen hibakeresni és tesztelni MCP szervereket
- Szerverfunkciókat létrehozni és használni (Erőforrások, Promotok és Eszközök)
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

Ez a szakasz gyakorlati példákat mutat be az MCP megvalósítására több programozási nyelven. A mintakódokat a `samples` könyvtárban, nyelvenként rendszerezve találod.

### Elérhető minták

A tároló az alábbi nyelveken tartalmaz mintamegvalósításokat:

- C#
- Java
- TypeScript
- JavaScript
- Python

Minden minta bemutatja az adott nyelv és ökoszisztéma kulcsfontosságú MCP fogalmait és megvalósítási mintáit.

## Alapszerver funkciók

Az MCP szerverek tetszőleges kombinációban megvalósíthatják az alábbi funkciókat:

### Erőforrások
Az erőforrások kontextust és adatot biztosítanak a felhasználó vagy az AI modell számára:
- Dokumentum tárak
- Tudásbázisok
- Strukturált adatforrások
- Fájlrendszerek

### Promotok
A promtok sablonosított üzenetek és munkafolyamatok a felhasználók számára:
- Előre definiált beszélgetési sablonok
- Irányított interakciós minták
- Speciális párbeszéd struktúrák

### Eszközök
Az eszközök olyan funkciók, amelyeket az AI modell végrehajthat:
- Adatfeldolgozó segédprogramok
- Külső API integrációk
- Számítási képességek
- Keresési funkciók

## Mintamegvalósítások: C#

A hivatalos C# SDK tároló több mintamegvalósítást tartalmaz, amelyek különböző MCP aspektusokat demonstrálnak:

- **Alap MCP kliens**: Egyszerű példa arra, hogyan hozz létre MCP klienst és hívd meg az eszközöket
- **Alap MCP szerver**: Minimális szerver megvalósítás alap eszközregisztrációval
- **Fejlett MCP szerver**: Teljes funkcionalitású szerver eszközregisztrációval, hitelesítéssel és hibakezeléssel
- **ASP.NET integráció**: Példák ASP.NET Core integrációra
- **Eszköz megvalósítási minták**: Különböző minták eszközök megvalósításához eltérő komplexitással

A MCP C# SDK előzetes verzióban van, az API-k változhatnak. A blogot folyamatosan frissítjük az SDK fejlődésével.

### Kulcsfunkciók
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Első [MCP szervered építése](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

A teljes C# megvalósítási mintákért látogass el a [hivatalos C# SDK minták tárolójába](https://github.com/modelcontextprotocol/csharp-sdk)

## Mintamegvalósítás: Java

A Java SDK erős MCP megvalósítási lehetőségeket kínál vállalati szintű funkciókkal.

### Kulcsfunkciók

- Spring Framework integráció
- Erős típusbiztonság
- Reaktív programozás támogatás
- Átfogó hibakezelés

A teljes Java megvalósítási mintáért lásd a [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) fájlt a minták könyvtárában.

## Mintamegvalósítás: JavaScript

A JavaScript SDK könnyű és rugalmas megközelítést kínál az MCP megvalósításához.

### Kulcsfunkciók

- Node.js és böngésző támogatás
- Promise-alapú API
- Egyszerű integráció Express és más keretrendszerekkel
- WebSocket támogatás streaminghez

A teljes JavaScript megvalósítási mintáért lásd a [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) fájlt a minták könyvtárában.

## Mintamegvalósítás: Python

A Python SDK pythonos megközelítést kínál az MCP megvalósításához kiváló ML keretrendszer integrációkkal.

### Kulcsfunkciók

- Async/await támogatás asyncio-val
- Flask és FastAPI integráció
- Egyszerű eszközregisztráció
- Natív integráció népszerű ML könyvtárakkal

A teljes Python megvalósítási mintáért lásd a [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) fájlt a minták könyvtárában.

## API kezelés

Az Azure API Management nagyszerű megoldás arra, hogyan biztosíthatjuk az MCP szervereket. Az ötlet, hogy egy Azure API Management példányt helyezel az MCP szerver elé, amely kezeli az olyan funkciókat, amikre valószínűleg szükséged lesz, mint például:

- korlátozások kezelése
- token menedzsment
- monitorozás
- terheléselosztás
- biztonság

### Azure példa

Itt egy Azure példa, ami pontosan ezt csinál, azaz [MCP szerver létrehozása és Azure API Management-tel való biztosítása](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Nézd meg, hogyan zajlik az engedélyezési folyamat az alábbi képen:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

A fenti képen a következők történnek:

- Hitelesítés/engedélyezés Microsoft Entra használatával.
- Az Azure API Management kapuként működik, és szabályokat alkalmaz a forgalom irányítására és kezelésére.
- Az Azure Monitor naplózza az összes kérést további elemzés céljából.

#### Engedélyezési folyamat

Nézzük meg részletesebben az engedélyezési folyamatot:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP engedélyezési specifikáció

Tudj meg többet a [MCP Authorization specifikációról](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Távoli MCP szerver telepítése Azure-ra

Nézzük meg, hogyan telepíthetjük az előzőleg említett mintát:

1. Klónozd a repót

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Regisztráld a `Microsoft.App` szolgáltatót:

    ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `

    vagy

    `. Then run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `

    Ezután egy idő múlva ellenőrizd a regisztráció állapotát:

    `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

2. Futtasd ezt az [azd](https://aka.ms/azd) parancsot az API Management szolgáltatás, a function app (kóddal) és az összes szükséges Azure erőforrás létrehozásához:

    ```shell
    azd up
    ```

    Ez a parancs telepíti az összes felhő erőforrást az Azure-ra.

### Szerver tesztelése MCP Inspectorral

1. Egy **új terminál ablakban** telepítsd és indítsd el az MCP Inspectort

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Egy hasonló felületet kell látnod:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

1. CTRL kattintással töltsd be az MCP Inspector webalkalmazást az app által megjelenített URL-ről (pl. http://127.0.0.1:6274/#resources)
1. Állítsd be a szállítási típust `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` értékre, majd **Csatlakozás**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Eszközök listázása**. Kattints egy eszközre, majd válaszd a **Run Tool** lehetőséget.

Ha minden lépés sikeres volt, most már csatlakozva vagy az MCP szerverhez, és képes voltál eszközt meghívni.

## MCP szerverek Azure-hoz

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ezek a tárolók gyorsindító sablonok egyedi távoli MCP (Model Context Protocol) szerverek építéséhez és telepítéséhez Azure Functions segítségével Python, C# .NET vagy Node/TypeScript nyelveken.

A minták egy teljes megoldást kínálnak, amely lehetővé teszi a fejlesztők számára, hogy:

- Helyileg építsenek és futtassanak: MCP szerver fejlesztése és hibakeresése helyi gépen
- Telepítsenek Azure-ra: Egyszerű telepítés a felhőbe egyetlen azd up paranccsal
- Kliens oldali kapcsolódás: Csatlakozás az MCP szerverhez különböző kliensekről, beleértve a VS Code Copilot agent módját és az MCP Inspector eszközt

### Kulcsfunkciók:

- Biztonság tervezésből: Az MCP szerver kulcsokkal és HTTPS-sel van biztosítva
- Hitelesítési lehetőségek: OAuth támogatás beépített hitelesítéssel és/vagy API Managementtel
- Hálózati izoláció: Azure Virtual Network (VNET) használatával
- Serverless architektúra: Azure Functions skálázható, eseményvezérelt futtatásához
- Helyi fejlesztés: Teljes körű helyi fejlesztési és hibakeresési támogatás
- Egyszerű telepítés: Egyszerűsített telepítési folyamat Azure-ra

A tároló tartalmaz minden szükséges konfigurációs fájlt, forráskódot és infrastruktúra definíciót, hogy gyorsan elindulhass egy éles MCP szerver megvalósítással.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) – MCP mintamegvalósítás Azure Functions segítségével Python nyelven

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) – MCP mintamegvalósítás Azure Functions segítségével C# .NET nyelven

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) – MCP mintamegvalósítás Azure Functions segítségével Node/TypeScript nyelven

## Főbb tanulságok

- Az MCP SDK-k nyelvspecifikus eszközöket biztosítanak robusztus MCP megoldások megvalósításához
- A hibakeresési és tesztelési folyamat kulcsfontosságú a megbízható MCP alkalmazásokhoz
- Az újrahasznosítható prompt sablonok következetes AI interakciókat tesznek lehetővé
- A jól megtervezett munkafolyamatok összetett feladatokat képesek több eszköz segítségével koordinálni
- Az MCP megoldások megvalósítása során figyelembe kell venni a biztonságot, teljesítményt és hibakezelést

## Gyakorlat

Tervezd meg egy gyakorlati MCP munkafolyamatot, amely a te területed valós problémáját oldja meg:

1. Azonosíts 3-4 eszközt, amelyek hasznosak lennének a probléma megoldásához
2. Készíts munkafolyamat-diagramot, amely bemutatja, hogyan lépnek kölcsönhatásba ezek az eszközök
3. Valósíts meg egy alap verziót az egyik eszközből a választott nyelveden
4. Készíts egy prompt sablont, amely segíti a modellt az eszköz hatékony használatában

## További erőforrások


---

Következő: [Haladó témák](../05-AdvancedTopics/README.md)

**Nyilatkozat:**  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.