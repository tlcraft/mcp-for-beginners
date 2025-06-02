<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:43:38+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hu"
}
-->
## Első lépések  

Ez a szakasz több leckéből áll:

- **-1- Az első szervered**, ebben az első leckében megtanulod, hogyan hozd létre az első szerveredet, és hogyan vizsgáld meg az inspector eszközzel, ami egy értékes módja a szerver tesztelésének és hibakeresésének, [a leckéhez](/03-GettingStarted/01-first-server/README.md)

- **-2- Ügyfél**, ebben a leckében megtanulod, hogyan írj egy ügyfelet, amely képes kapcsolódni a szerveredhez, [a leckéhez](/03-GettingStarted/02-client/README.md)

- **-3- Ügyfél LLM-mel**, egy még jobb módja az ügyfél írásának, ha hozzáadsz egy LLM-et, így az "tárgyalhat" a szervereddel arról, hogy mit tegyen, [a leckéhez](/03-GettingStarted/03-llm-client/README.md)

- **-4- Egy szerver GitHub Copilot Agent módjának használata Visual Studio Code-ban**. Itt azt nézzük meg, hogyan futtathatjuk MCP szerverünket a Visual Studio Code-on belül, [a leckéhez](/03-GettingStarted/04-vscode/README.md)

- **-5- Fogyasztás SSE-ből (Server Sent Events)**. Az SSE egy szabvány a szerver-ügyfél közötti adatfolyamhoz, amely lehetővé teszi a szerverek számára, hogy valós idejű frissítéseket küldjenek az ügyfeleknek HTTP-n keresztül, [a leckéhez](/03-GettingStarted/05-sse-server/README.md)

- **-6- AI Toolkit használata VSCode-hoz**, hogy fogyaszthasd és tesztelhesd MCP ügyfeleidet és szervereidet, [a leckéhez](/03-GettingStarted/06-aitk/README.md)

- **-7 Tesztelés**. Itt különösen arra fókuszálunk, hogyan tesztelhetjük különböző módokon a szerverünket és ügyfelünket, [a leckéhez](/03-GettingStarted/07-testing/README.md)

- **-8- Telepítés**. Ez a fejezet különböző megoldásokat vizsgál az MCP megoldásaid telepítésére, [a leckéhez](/03-GettingStarted/08-deployment/README.md)


A Model Context Protocol (MCP) egy nyílt protokoll, amely szabványosítja, hogyan biztosítanak az alkalmazások kontextust az LLM-ek számára. Gondolj az MCP-re úgy, mint egy USB-C csatlakozóra az AI alkalmazások számára – egységes módot ad arra, hogy AI modelleket különböző adatforrásokhoz és eszközökhöz kapcsolj.

## Tanulási célok

A lecke végére képes leszel:

- Beállítani MCP fejlesztői környezeteket C#, Java, Python, TypeScript és JavaScript nyelveken
- Egyszerű MCP szervereket építeni és telepíteni egyedi funkciókkal (erőforrások, promptok és eszközök)
- Olyan host alkalmazásokat létrehozni, amelyek kapcsolódnak MCP szerverekhez
- Tesztelni és hibakeresni MCP implementációkat
- Megérteni a gyakori beállítási kihívásokat és azok megoldásait
- Kapcsolódni népszerű LLM szolgáltatásokhoz MCP implementációiddal

## MCP környezet beállítása

Mielőtt elkezdenéd az MCP-vel való munkát, fontos előkészíteni a fejlesztői környezetet és megérteni az alapvető munkafolyamatot. Ez a szakasz végigvezet az első beállítási lépéseken, hogy zökkenőmentesen indulhass az MCP-vel.

### Előfeltételek

Mielőtt belevágnál az MCP fejlesztésbe, győződj meg arról, hogy rendelkezel:

- **Fejlesztői környezettel**: a választott nyelvhez (C#, Java, Python, TypeScript vagy JavaScript)
- **IDE/Szerkesztő**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm vagy bármilyen modern kódszerkesztő
- **Csomagkezelők**: NuGet, Maven/Gradle, pip vagy npm/yarn
- **API kulcsok**: azokhoz az AI szolgáltatásokhoz, amelyeket használni tervezel a host alkalmazásaidban


### Hivatalos SDK-k

A következő fejezetekben Python, TypeScript, Java és .NET megoldásokat láthatsz. Íme a hivatalosan támogatott SDK-k.

Az MCP hivatalos SDK-kat kínál több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Microsoft együttműködéssel karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Spring AI együttműködéssel karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – hivatalos TypeScript implementáció
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – hivatalos Python implementáció
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – hivatalos Kotlin implementáció
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Loopwork AI együttműködéssel karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – hivatalos Rust implementáció

## Főbb tanulságok

- Az MCP fejlesztői környezet beállítása egyszerű a nyelvspecifikus SDK-kkal
- MCP szerverek építése eszközök létrehozását és regisztrálását jelenti világos sémákkal
- MCP ügyfelek kapcsolódnak szerverekhez és modellekhez a kiterjesztett képességek kihasználásához
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP implementációkhoz
- A telepítési lehetőségek a helyi fejlesztéstől a felhő alapú megoldásokig terjednek

## Gyakorlás

Van egy mintagyűjteményünk, amely kiegészíti az összes fejezetben található gyakorlatokat. Emellett minden fejezethez saját feladatok és házi feladatok is tartoznak.

- [Java Számológép](./samples/java/calculator/README.md)
- [.Net Számológép](../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](./samples/javascript/README.md)
- [TypeScript Számológép](./samples/typescript/README.md)
- [Python Számológép](../../../03-GettingStarted/samples/python)

## További források

- [Agentek építése Model Context Protocol segítségével Azure-on](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Távoli MCP Azure Container Apps használatával (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mi következik

Következő: [Az első MCP szerver létrehozása](/03-GettingStarted/01-first-server/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.