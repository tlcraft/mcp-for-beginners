<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-13T00:49:35+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hu"
}
-->
## Első lépések

Ez a szakasz több leckéből áll:

- **1 Az első szervered**, ebben az első leckében megtanulod, hogyan készítsd el az első szervered, és hogyan vizsgáld meg az inspector eszközzel, ami hasznos módja a szerver tesztelésének és hibakeresésének, [a leckéhez](/03-GettingStarted/01-first-server/README.md)

- **2 Ügyfél**, ebben a leckében megtanulod, hogyan írj olyan klienst, amely képes csatlakozni a szerveredhez, [a leckéhez](/03-GettingStarted/02-client/README.md)

- **3 Ügyfél LLM-mel**, egy még jobb módja a kliens írásának, ha hozzáadsz egy LLM-et, így "tárgyalhat" a szervereddel arról, hogy mit tegyen, [a leckéhez](/03-GettingStarted/03-llm-client/README.md)

- **4 GitHub Copilot Agent módú szerver használata Visual Studio Code-ban**. Itt azt nézzük meg, hogyan futtathatjuk az MCP szerverünket közvetlenül a Visual Studio Code-ból, [a leckéhez](/03-GettingStarted/04-vscode/README.md)

- **5 Fogyasztás SSE-ből (Server Sent Events)** Az SSE egy szabvány a szerver-ügyfél streamingre, amely lehetővé teszi a szerverek számára, hogy valós idejű frissítéseket küldjenek az ügyfeleknek HTTP-n keresztül, [a leckéhez](/03-GettingStarted/05-sse-server/README.md)

- **6 HTTP streaming MCP-vel (Streamable HTTP)**. Ismerd meg a modern HTTP streaminget, a folyamatjelző értesítéseket, és hogyan valósíthatsz meg skálázható, valós idejű MCP szervereket és klienseket Streamable HTTP segítségével. [a leckéhez](/03-GettingStarted/06-http-streaming/README.md)

- **7 AI Toolkit használata VSCode-hoz**, hogy fogyaszd és teszteld MCP klienseidet és szervereidet, [a leckéhez](/03-GettingStarted/07-aitk/README.md)

- **8 Tesztelés**. Ebben a részben különösen arra fókuszálunk, hogyan tudjuk különböző módokon tesztelni a szerverünket és kliensünket, [a leckéhez](/03-GettingStarted/08-testing/README.md)

- **9 Telepítés**. Ez a fejezet a MCP megoldások különböző telepítési módjait mutatja be, [a leckéhez](/03-GettingStarted/09-deployment/README.md)


A Model Context Protocol (MCP) egy nyílt protokoll, amely szabványosítja, hogyan biztosítanak az alkalmazások kontextust az LLM-ek számára. Gondolj az MCP-re úgy, mint egy USB-C portra az AI alkalmazások számára – egy szabványosított módot kínál az AI modellek összekapcsolására különböző adatforrásokkal és eszközökkel.

## Tanulási célok

A lecke végére képes leszel:

- Beállítani fejlesztői környezeteket MCP-hez C#, Java, Python, TypeScript és JavaScript nyelveken
- Egyszerű MCP szervereket építeni egyedi funkciókkal (erőforrások, promptok, eszközök)
- Olyan host alkalmazásokat létrehozni, amelyek csatlakoznak MCP szerverekhez
- Tesztelni és hibakeresni MCP megvalósításokat
- Megérteni a gyakori beállítási nehézségeket és azok megoldásait
- Csatlakoztatni MCP megvalósításaidat népszerű LLM szolgáltatásokhoz

## MCP környezet beállítása

Mielőtt elkezdenéd az MCP-vel való munkát, fontos előkészíteni a fejlesztői környezetet, és megérteni az alapvető munkafolyamatot. Ez a rész végigvezet az első beállítási lépéseken, hogy zökkenőmentesen indulhass az MCP-vel.

### Előfeltételek

Mielőtt belevágnál az MCP fejlesztésbe, győződj meg róla, hogy rendelkezel:

- **Fejlesztői környezet**: a választott nyelvhez (C#, Java, Python, TypeScript vagy JavaScript)
- **IDE/Szerkesztő**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm vagy bármilyen modern kódszerkesztő
- **Csomagkezelők**: NuGet, Maven/Gradle, pip vagy npm/yarn
- **API kulcsok**: azokhoz az AI szolgáltatásokhoz, amelyeket használni tervezel a host alkalmazásaidban


### Hivatalos SDK-k

A következő fejezetekben Python, TypeScript, Java és .NET megoldásokat fogsz látni. Íme az összes hivatalosan támogatott SDK.

Az MCP hivatalos SDK-kat kínál több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Microsoft együttműködésben karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Spring AI együttműködésben karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Hivatalos TypeScript megvalósítás
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Hivatalos Python megvalósítás
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Hivatalos Kotlin megvalósítás
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Loopwork AI együttműködésben karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Hivatalos Rust megvalósítás

## Főbb tanulságok

- Az MCP fejlesztői környezet beállítása egyszerű, nyelvspecifikus SDK-kkal
- MCP szerverek építése eszközök létrehozását és regisztrálását jelenti világos sémákkal
- MCP kliensek csatlakoznak a szerverekhez és modellekhez, hogy kihasználják a kiterjesztett képességeket
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP megvalósításokhoz
- A telepítési lehetőségek a helyi fejlesztéstől a felhőalapú megoldásokig terjednek

## Gyakorlás

Van egy mintagyűjteményünk, amely kiegészíti az összes fejezetben található gyakorlatokat. Emellett minden fejezethez saját feladatok és házi feladatok is tartoznak.

- [Java Számológép](./samples/java/calculator/README.md)
- [.Net Számológép](../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](./samples/javascript/README.md)
- [TypeScript Számológép](./samples/typescript/README.md)
- [Python Számológép](../../../03-GettingStarted/samples/python)

## További források

- [Ügynökök építése Model Context Protocol segítségével Azure-on](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Távoli MCP Azure Container Apps segítségével (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mi következik

Következő: [Első MCP szerver létrehozása](/03-GettingStarted/01-first-server/README.md)

**Felelősségkizárás**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum anyanyelvű változata tekintendő hiteles forrásnak. Kritikus információk esetén javasolt szakmai, emberi fordítást igénybe venni. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy félreértelmezésekért.