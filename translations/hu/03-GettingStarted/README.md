<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:15:17+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hu"
}
-->
## Kezdés  

Ez a rész több leckéből áll:

- **1 Az első szervered**, ebben az első leckében megtanulod, hogyan készítsd el az első szervered, és hogyan vizsgáld meg az inspector eszközzel, ami egy hasznos módszer a szerver tesztelésére és hibakeresésére, [a leckéhez](/03-GettingStarted/01-first-server/README.md)

- **2 Ügyfél**, ebben a leckében megtanulod, hogyan írj olyan ügyfelet, amely csatlakozni tud a szerveredhez, [a leckéhez](/03-GettingStarted/02-client/README.md)

- **3 Ügyfél LLM-mel**, egy még jobb módja az ügyfél írásának, ha hozzáadsz egy LLM-et, hogy „tárgyaljon” a szervereddel arról, mit kell tenni, [a leckéhez](/03-GettingStarted/03-llm-client/README.md)

- **4 Egy szerver GitHub Copilot Agent módjának használata Visual Studio Code-ban**. Itt azt nézzük meg, hogyan futtathatjuk az MCP szerverünket közvetlenül a Visual Studio Code-ból, [a leckéhez](/03-GettingStarted/04-vscode/README.md)

- **5 Fogyasztás SSE-ből (Server Sent Events)** SSE egy szabvány a szerver-ügyfél adatfolyamra, amely lehetővé teszi a szerverek számára, hogy valós idejű frissítéseket küldjenek az ügyfeleknek HTTP-n keresztül, [a leckéhez](/03-GettingStarted/05-sse-server/README.md)

- **6 AI Toolkit használata VSCode-hoz** az MCP ügyfelek és szerverek fogyasztásához és teszteléséhez, [a leckéhez](/03-GettingStarted/06-aitk/README.md)

- **7 Tesztelés**. Ebben a részben különösen arra koncentrálunk, hogyan tesztelhetjük a szerverünket és ügyfelünket különböző módokon, [a leckéhez](/03-GettingStarted/07-testing/README.md)

- **8 Telepítés**. Ez a fejezet a MCP megoldások különböző telepítési módjait mutatja be, [a leckéhez](/03-GettingStarted/08-deployment/README.md)


A Model Context Protocol (MCP) egy nyílt protokoll, amely szabványosítja, hogyan biztosítanak az alkalmazások kontextust az LLM-ek számára. Gondolj az MCP-re úgy, mint egy USB-C portra az AI alkalmazásokhoz – egységes módot ad arra, hogy az AI modellek különböző adatforrásokhoz és eszközökhöz csatlakozzanak.

## Tanulási célok

A lecke végére képes leszel:

- Beállítani MCP fejlesztői környezeteket C#, Java, Python, TypeScript és JavaScript nyelveken
- Egyszerű MCP szervereket építeni és telepíteni egyedi funkciókkal (erőforrások, promptok és eszközök)
- Host alkalmazásokat készíteni, amelyek csatlakoznak MCP szerverekhez
- Tesztelni és hibakeresni MCP implementációkat
- Megérteni a gyakori beállítási kihívásokat és azok megoldásait
- Kapcsolódni népszerű LLM szolgáltatásokhoz MCP implementációiddal

## MCP környezet beállítása

Mielőtt elkezdenéd az MCP-vel való munkát, fontos előkészíteni a fejlesztői környezetet és megérteni az alapvető munkafolyamatot. Ez a rész végigvezet az első lépéseken, hogy zökkenőmentesen indulhass az MCP-vel.

### Előfeltételek

Mielőtt belevágnál az MCP fejlesztésbe, győződj meg róla, hogy rendelkezel:

- **Fejlesztői környezettel**: az általad választott nyelvhez (C#, Java, Python, TypeScript vagy JavaScript)
- **IDE/Szerkesztő**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm vagy bármilyen modern kódszerkesztő
- **Csomagkezelők**: NuGet, Maven/Gradle, pip vagy npm/yarn
- **API kulcsok**: bármilyen AI szolgáltatáshoz, amit a host alkalmazásaidban használni szeretnél


### Hivatalos SDK-k

A következő fejezetekben Python, TypeScript, Java és .NET alapú megoldásokat fogsz látni. Íme a hivatalosan támogatott SDK-k.

Az MCP hivatalos SDK-kat kínál több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft együttműködésben karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI-val közösen karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Hivatalos TypeScript megvalósítás
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Hivatalos Python megvalósítás
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Hivatalos Kotlin megvalósítás
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI-val közösen karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Hivatalos Rust megvalósítás

## Főbb tanulságok

- Az MCP fejlesztői környezet beállítása egyszerű, nyelvspecifikus SDK-kkal
- MCP szerverek építése eszközök létrehozását és regisztrálását jelenti jól definiált sémákkal
- MCP ügyfelek csatlakoznak a szerverekhez és modellekhez, hogy kihasználják a kibővített képességeket
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP implementációkhoz
- A telepítési lehetőségek a helyi fejlesztéstől a felhő alapú megoldásokig terjednek

## Gyakorlás

Van egy mintakészletünk, amely kiegészíti az összes fejezetben található gyakorlatokat. Emellett minden fejezethez saját feladatok és házi feladatok is tartoznak.

- [Java Számológép](./samples/java/calculator/README.md)
- [.Net Számológép](../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](./samples/javascript/README.md)
- [TypeScript Számológép](./samples/typescript/README.md)
- [Python Számológép](../../../03-GettingStarted/samples/python)

## További források

- [Agentek építése a Model Context Protocol segítségével Azure-on](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Távoli MCP Azure Container Apps segítségével (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mi következik

Következő: [Az első MCP szerver létrehozása](/03-GettingStarted/01-first-server/README.md)

**Nyilatkozat:**  
Ezt a dokumentumot az AI fordító szolgáltatás [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hivatalos forrásnak. Kritikus információk esetén szakmai emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből eredő félreértésekért vagy téves értelmezésekért.