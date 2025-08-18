<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "83efa75a69bc831277263a6f1ae53669",
  "translation_date": "2025-08-18T19:19:01+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "hu"
}
-->
# Gyakorlati Megvalósítás

[![Hogyan építsünk, teszteljünk és telepítsünk MCP alkalmazásokat valódi eszközökkel és munkafolyamatokkal](../../../translated_images/05.64bea204e25ca891e3dd8b8f960d2170b9a000d8364305f57db3ec4a2c049a9a.hu.png)](https://youtu.be/vCN9-mKBDfQ)

_(Kattints a fenti képre a videó megtekintéséhez ebben a leckében)_

A gyakorlati megvalósítás az a pont, ahol a Model Context Protocol (MCP) ereje kézzelfoghatóvá válik. Bár az MCP mögötti elmélet és architektúra megértése fontos, az igazi érték akkor jelenik meg, amikor ezeket a koncepciókat alkalmazva olyan megoldásokat hozunk létre, tesztelünk és telepítünk, amelyek valós problémákat oldanak meg. Ez a fejezet áthidalja a koncepcionális tudás és a gyakorlati fejlesztés közötti szakadékot, és végigvezet az MCP-alapú alkalmazások életre keltésének folyamatán.

Akár intelligens asszisztenseket fejlesztesz, mesterséges intelligenciát integrálsz üzleti munkafolyamatokba, vagy egyedi adatfeldolgozó eszközöket építesz, az MCP rugalmas alapot biztosít. Nyelvfüggetlen tervezése és hivatalos SDK-i a népszerű programozási nyelvekhez széles körben elérhetővé teszik a fejlesztők számára. Ezeket az SDK-kat használva gyorsan prototípust készíthetsz, iterálhatsz, és skálázhatod megoldásaidat különböző platformokon és környezetekben.

A következő szakaszokban gyakorlati példákat, mintakódokat és telepítési stratégiákat találsz, amelyek bemutatják, hogyan valósítható meg az MCP C#, Java Spring, TypeScript, JavaScript és Python nyelveken. Emellett megtanulhatod, hogyan hibakeresd és teszteld MCP szervereidet, kezeld az API-kat, és telepítsd megoldásaidat a felhőbe az Azure segítségével. Ezek a gyakorlati erőforrások célja, hogy felgyorsítsák a tanulást, és magabiztosan építhess robusztus, éles környezetre kész MCP alkalmazásokat.

## Áttekintés

Ez a lecke az MCP megvalósításának gyakorlati aspektusaira összpontosít több programozási nyelven. Megvizsgáljuk, hogyan használhatók az MCP SDK-k C#, Java Spring, TypeScript, JavaScript és Python nyelveken robusztus alkalmazások építésére, MCP szerverek hibakeresésére és tesztelésére, valamint újrahasználható erőforrások, promptok és eszközök létrehozására.

## Tanulási Célok

A lecke végére képes leszel:

- MCP megoldásokat megvalósítani hivatalos SDK-k segítségével különböző programozási nyelveken
- MCP szervereket rendszerszerűen hibakeresni és tesztelni
- Szerverfunkciókat létrehozni és használni (Erőforrások, Promptok és Eszközök)
- Hatékony MCP munkafolyamatokat tervezni összetett feladatokhoz
- MCP megvalósításokat optimalizálni teljesítmény és megbízhatóság szempontjából

## Hivatalos SDK Erőforrások

A Model Context Protocol több nyelvhez kínál hivatalos SDK-kat:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java Spring SDK](https://github.com/modelcontextprotocol/java-sdk) **Megjegyzés:** függőséget igényel a [Project Reactor](https://projectreactor.io) projekttől. (Lásd [246-os vita](https://github.com/orgs/modelcontextprotocol/discussions/246).)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## MCP SDK-k használata

Ez a szakasz gyakorlati példákat nyújt az MCP megvalósítására több programozási nyelven. Mintakódokat találhatsz a `samples` könyvtárban, nyelv szerint rendezve.

### Elérhető Minták

A repó [mintamegvalósításokat](../../../04-PracticalImplementation/samples) tartalmaz az alábbi nyelveken:

- [C#](./samples/csharp/README.md)
- [Java Spring](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Minden minta bemutatja az adott nyelvhez és ökoszisztémához kapcsolódó kulcsfontosságú MCP koncepciókat és megvalósítási mintákat.

## Alapvető Szerverfunkciók

Az MCP szerverek az alábbi funkciók bármely kombinációját megvalósíthatják:

### Erőforrások

Az erőforrások kontextust és adatokat biztosítanak a felhasználó vagy az AI modell számára:

- Dokumentumtárak
- Tudásbázisok
- Strukturált adatforrások
- Fájlrendszerek

### Promptok

A promptok sablonüzenetek és munkafolyamatok a felhasználók számára:

- Előre definiált beszélgetési sablonok
- Irányított interakciós minták
- Speciális párbeszédstruktúrák

### Eszközök

Az eszközök olyan funkciók, amelyeket az AI modell végrehajthat:

- Adatfeldolgozó segédprogramok
- Külső API integrációk
- Számítási képességek
- Keresési funkciók

## Mintamegvalósítás: C# Megvalósítás

A hivatalos C# SDK repó több mintamegvalósítást tartalmaz, amelyek az MCP különböző aspektusait mutatják be:

- **Egyszerű MCP kliens**: Egyszerű példa, amely bemutatja, hogyan hozható létre MCP kliens és hogyan hívhatók meg eszközök
- **Egyszerű MCP szerver**: Minimális szervermegvalósítás alapvető eszközregisztrációval
- **Haladó MCP szerver**: Teljes funkcionalitású szerver eszközregisztrációval, hitelesítéssel és hibakezeléssel
- **ASP.NET integráció**: Példák az ASP.NET Core integrációjára
- **Eszközmegvalósítási minták**: Különböző minták eszközök különböző komplexitási szinteken történő megvalósítására

A C# MCP SDK előzetes verzióban van, és az API-k változhatnak. Folyamatosan frissítjük ezt a blogot, ahogy az SDK fejlődik.

### Kulcsfontosságú Funkciók

- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)
- Az első [MCP szerver](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/) építése.

A teljes C# megvalósítási mintákért látogass el a [hivatalos C# SDK minták repójába](https://github.com/modelcontextprotocol/csharp-sdk).

## Mintamegvalósítás: Java Spring Megvalósítás

A Java Spring SDK robusztus MCP megvalósítási lehetőségeket kínál vállalati szintű funkciókkal.

### Kulcsfontosságú Funkciók

- Spring Framework integráció
- Erős típusbiztonság
- Reaktív programozási támogatás
- Átfogó hibakezelés

A teljes Java Spring megvalósítási mintáért lásd a [Java Spring mintát](samples/java/containerapp/README.md) a minták könyvtárában.

## Mintamegvalósítás: JavaScript Megvalósítás

A JavaScript SDK könnyű és rugalmas megközelítést kínál az MCP megvalósítására.

### Kulcsfontosságú Funkciók

- Node.js és böngésző támogatás
- Promise-alapú API
- Könnyű integráció Express-szel és más keretrendszerekkel
- WebSocket támogatás streaminghez

A teljes JavaScript megvalósítási mintáért lásd a [JavaScript mintát](samples/javascript/README.md) a minták könyvtárában.

## Mintamegvalósítás: Python Megvalósítás

A Python SDK Python-barát megközelítést kínál az MCP megvalósítására, kiváló ML keretrendszer integrációkkal.

### Kulcsfontosságú Funkciók

- Async/await támogatás asyncio-val
- FastAPI integráció
- Egyszerű eszközregisztráció
- Natív integráció népszerű ML könyvtárakkal

A teljes Python megvalósítási mintáért lásd a [Python mintát](samples/python/README.md) a minták könyvtárában.

## API kezelés

Az Azure API Management kiváló megoldás arra, hogyan biztosíthatjuk MCP szervereinket. Az ötlet az, hogy egy Azure API Management példányt helyezünk az MCP szerver elé, és hagyjuk, hogy kezelje azokat a funkciókat, amelyeket valószínűleg szeretnénk, mint például:

- sebességkorlátozás
- tokenkezelés
- monitorozás
- terheléselosztás
- biztonság

### Azure Minta

Itt van egy Azure minta, amely pontosan ezt teszi, azaz [MCP szerver létrehozása és biztosítása Azure API Management segítségével](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Nézd meg, hogyan zajlik az autorizációs folyamat az alábbi képen:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

A fenti képen a következő történik:

- Hitelesítés/autorizáció Microsoft Entra segítségével történik.
- Az Azure API Management átjáróként működik, és politikákat használ a forgalom irányítására és kezelésére.
- Az Azure Monitor minden kérést naplóz további elemzés céljából.

#### Autorizációs folyamat

Nézzük meg részletesebben az autorizációs folyamatot:

![Szekvencia Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### MCP autorizációs specifikáció

További információ az [MCP autorizációs specifikációról](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow).

## Távoli MCP Szerver Telepítése Azure-ra

Nézzük meg, hogyan telepíthetjük az előbb említett mintát:

1. Klónozd a repót

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Regisztráld a `Microsoft.App` erőforrás-szolgáltatót.

   - Ha az Azure CLI-t használod, futtasd: `az provider register --namespace Microsoft.App --wait`.
   - Ha az Azure PowerShell-t használod, futtasd: `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Ezután futtasd `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` egy idő után, hogy ellenőrizd, befejeződött-e a regisztráció.

1. Futtasd ezt az [azd](https://aka.ms/azd) parancsot az API Management szolgáltatás, a funkcióalkalmazás (kóddal) és minden más szükséges Azure erőforrás előkészítéséhez:

    ```shell
    azd up
    ```

    Ez a parancs telepíti az összes felhőalapú erőforrást az Azure-ra.

### Szerver tesztelése MCP Inspectorral

1. Egy **új terminálablakban** telepítsd és futtasd az MCP Inspectort

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Egy hasonló felületet kell látnod:

    ![Csatlakozás Node Inspectorhoz](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

1. CTRL kattintással töltsd be az MCP Inspector webalkalmazást az alkalmazás által megjelenített URL-ről (pl. [http://127.0.0.1:6274/#resources](http://127.0.0.1:6274/#resources)).
1. Állítsd be a transport típust `SSE`-re.
1. Állítsd be az URL-t a futó API Management SSE végpontra, amelyet az `azd up` után látsz, és **Csatlakozz**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

1. **Eszközök listázása**. Kattints egy eszközre, majd **Eszköz futtatása**.

Ha minden lépés sikeres volt, most csatlakozva kell lenned az MCP szerverhez, és képesnek kell lenned eszközök meghívására.

## MCP szerverek Azure-ra

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Ez a repókészlet gyorsindítási sablonokat kínál egyedi távoli MCP (Model Context Protocol) szerverek építéséhez és telepítéséhez Azure Functions segítségével Python, C# .NET vagy Node/TypeScript nyelveken.

A minták teljes megoldást kínálnak, amely lehetővé teszi a fejlesztők számára:

- Helyi futtatás: MCP szerver fejlesztése és hibakeresése helyi gépen
- Telepítés Azure-ra: Egyszerűen telepíthető a felhőbe egy egyszerű azd up paranccsal
- Kapcsolódás kliensekről: Kapcsolódás az MCP szerverhez különböző kliensekről, beleértve a VS Code Copilot ügynök módját és az MCP Inspector eszközt

### Kulcsfontosságú Funkciók

- Biztonság tervezés szerint: Az MCP szerver kulcsokkal és HTTPS-sel van biztosítva
- Hitelesítési opciók: Támogatja az OAuth-ot beépített hitelesítéssel és/vagy API Managementtel
- Hálózati izoláció: Lehetővé teszi a hálózati izolációt Azure Virtual Networks (VNET) használatával
- Szerver nélküli architektúra: Az Azure Functions-t használja skálázható, eseményvezérelt végrehajtáshoz
- Helyi fejlesztés: Átfogó helyi fejlesztési és hibakeresési támogatás
- Egyszerű telepítés: Egyszerűsített telepítési folyamat Azure-ra

A repó tartalmazza az összes szükséges konfigurációs fájlt, forráskódot és infrastruktúra-definíciót, hogy gyorsan elkezdhesd egy éles környezetre kész MCP szerver megvalósítását.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - MCP mintamegvalósítás Azure Functions segítségével Python nyelven

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - MCP mintamegvalósítás Azure Functions segítségével C# .NET nyelven

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - MCP mintamegvalósítás Azure Functions segítségével Node/TypeScript nyelven.

## Kulcsfontosságú Tanulságok

- Az MCP SDK-k nyelvspecifikus eszközöket kínálnak robusztus MCP megoldások megvalósításához
- A hibakeresési és tesztelési folyamat kritikus a megbízható MCP alkalmazásokhoz
- Újrahasználható prompt sablonok következetes AI interakciókat tesznek lehetővé
- Jól megtervezett munkafolyamatok összetett feladatokat tudnak összehangolni több eszköz használatával
- Az MCP megoldások megvalósítása biztonsági, teljesítmény- és hibakezelési szempontok figyelembevételét igényli

## Gyakorlat

Tervezd meg egy gyakorlati MCP munkafolyamatot, amely egy valós problémát old meg a saját területeden:

1. Azonosíts 3-4 eszközt, amelyek hasznosak lennének a probléma megoldásához
2. Készíts egy munkafolyamat-diagramot, amely bemutatja, hogyan működnek együtt ezek az eszközök
3. Valósítsd meg az egyik eszköz alapverzióját a preferált nyelveden
4. Készíts egy prompt sablont, amely segíti a modellt az eszköz hatékony használatában

## További Erőforrások

---

Követ

**Felelősségkizárás**:  
Ez a dokumentum az [Co-op Translator](https://github.com/Azure/co-op-translator) AI fordítási szolgáltatás segítségével készült. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális, emberi fordítás igénybevétele. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.