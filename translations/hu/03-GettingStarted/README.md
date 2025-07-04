<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T18:29:56+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hu"
}
-->
## Kezdés  

Ez a szakasz több leckéből áll:

- **1 Az első szervered**, ebben az első leckében megtanulod, hogyan hozd létre az első szerveredet, és hogyan vizsgáld meg az inspector eszközzel, ami egy értékes módja a szerver tesztelésének és hibakeresésének, [a leckéhez](/03-GettingStarted/01-first-server/README.md)

- **2 Ügyfél**, ebben a leckében megtanulod, hogyan írj egy klienst, amely képes kapcsolódni a szerveredhez, [a leckéhez](/03-GettingStarted/02-client/README.md)

- **3 Ügyfél LLM-mel**, egy még jobb módja a kliens írásának, ha hozzáadsz egy LLM-et, így az "tárgyalhat" a szervereddel arról, mit tegyen, [a leckéhez](/03-GettingStarted/03-llm-client/README.md)

- **4 Szerver használata GitHub Copilot Agent módban Visual Studio Code-ban**. Itt azt nézzük meg, hogyan futtathatjuk az MCP szerverünket közvetlenül a Visual Studio Code-ból, [a leckéhez](/03-GettingStarted/04-vscode/README.md)

- **5 Fogyasztás SSE-ből (Server Sent Events)** Az SSE egy szabvány a szerver-kliens streaminghez, amely lehetővé teszi a szerverek számára, hogy valós idejű frissítéseket küldjenek a klienseknek HTTP-n keresztül [a leckéhez](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP streaming MCP-vel (Streamable HTTP)**. Ismerd meg a modern HTTP streaminget, a folyamatjelző értesítéseket, és hogyan valósíthatsz meg skálázható, valós idejű MCP szervereket és klienseket Streamable HTTP segítségével. [a leckéhez](/03-GettingStarted/06-http-streaming/README.md)

- **7 AI Toolkit használata VSCode-hoz** az MCP kliensek és szerverek fogyasztásához és teszteléséhez [a leckéhez](/03-GettingStarted/07-aitk/README.md)

- **8 Tesztelés**. Itt különösen arra fókuszálunk, hogyan tesztelhetjük a szerverünket és kliensünket különböző módokon, [a leckéhez](/03-GettingStarted/08-testing/README.md)

- **9 Telepítés**. Ez a fejezet a különböző MCP megoldások telepítési módjait vizsgálja, [a leckéhez](/03-GettingStarted/09-deployment/README.md)


A Model Context Protocol (MCP) egy nyílt protokoll, amely szabványosítja, hogyan biztosítanak az alkalmazások kontextust az LLM-ek számára. Gondolj az MCP-re úgy, mint egy USB-C portra az AI alkalmazások számára – egy egységesített módot ad arra, hogy az AI modellek különböző adatforrásokhoz és eszközökhöz kapcsolódjanak.

## Tanulási célok

A lecke végére képes leszel:

- MCP fejlesztői környezetek beállítása C#, Java, Python, TypeScript és JavaScript nyelveken
- Alap MCP szerverek építése és telepítése egyedi funkciókkal (erőforrások, promptok és eszközök)
- Host alkalmazások létrehozása, amelyek kapcsolódnak MCP szerverekhez
- MCP implementációk tesztelése és hibakeresése
- A gyakori beállítási kihívások és megoldásaik megértése
- MCP implementációk csatlakoztatása népszerű LLM szolgáltatásokhoz

## MCP környezet beállítása

Mielőtt elkezdenéd az MCP-vel való munkát, fontos előkészíteni a fejlesztői környezetet és megérteni az alapvető munkafolyamatot. Ez a rész végigvezet az első beállítási lépéseken, hogy zökkenőmentesen indulhass az MCP-vel.

### Előfeltételek

Mielőtt belevágnál az MCP fejlesztésbe, győződj meg róla, hogy rendelkezel:

- **Fejlesztői környezet**: a választott nyelvhez (C#, Java, Python, TypeScript vagy JavaScript)
- **IDE/Szerkesztő**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm vagy bármilyen modern kódszerkesztő
- **Csomagkezelők**: NuGet, Maven/Gradle, pip vagy npm/yarn
- **API kulcsok**: bármilyen AI szolgáltatáshoz, amit a host alkalmazásaidban használni tervezel


### Hivatalos SDK-k

A következő fejezetekben Python, TypeScript, Java és .NET megoldásokat fogsz látni. Íme az összes hivatalosan támogatott SDK.

Az MCP hivatalos SDK-kat biztosít több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft együttműködésével karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI együttműködésével karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Hivatalos TypeScript implementáció
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Hivatalos Python implementáció
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Hivatalos Kotlin implementáció
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI együttműködésével karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Hivatalos Rust implementáció

## Főbb tanulságok

- Az MCP fejlesztői környezet beállítása egyszerű a nyelvspecifikus SDK-kkal
- MCP szerverek építése eszközök létrehozását és regisztrálását jelenti egyértelmű sémákkal
- MCP kliensek kapcsolódnak a szerverekhez és modellekhez, hogy kihasználják a kibővített képességeket
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP implementációkhoz
- A telepítési lehetőségek a helyi fejlesztéstől a felhőalapú megoldásokig terjednek

## Gyakorlás

Van egy mintakészletünk, amely kiegészíti az összes fejezetben található gyakorlatokat. Emellett minden fejezetnek megvannak a saját feladatai és házi feladatai is.

- [Java Számológép](./samples/java/calculator/README.md)
- [.Net Számológép](../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](./samples/javascript/README.md)
- [TypeScript Számológép](./samples/typescript/README.md)
- [Python Számológép](../../../03-GettingStarted/samples/python)

## További források

- [Agentek építése Model Context Protocol segítségével Azure-on](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Távoli MCP Azure Container Apps segítségével (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mi következik

Következő: [Az első MCP szerver létrehozása](./01-first-server/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.