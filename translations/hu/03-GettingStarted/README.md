<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:14:08+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "hu"
}
-->
## Első lépések

Ez a rész több leckét tartalmaz:

- **-1- Az első szervered**, ebben az első leckében megtanulod, hogyan hozd létre az első szervered, és hogyan vizsgáld meg az inspector eszközzel, ami értékes módja a szerver tesztelésének és hibakeresésének, [a leckére](/03-GettingStarted/01-first-server/README.md)

- **-2- Kliens**, ebben a leckében megtanulod, hogyan írj egy klienst, amely csatlakozni tud a szerveredhez, [a leckére](/03-GettingStarted/02-client/README.md)

- **-3- Kliens LLM-mel**, még jobb módja a kliens írásának, ha hozzáadunk egy LLM-et, így az "tárgyalhat" a szervereddel arról, hogy mit tegyen, [a leckére](/03-GettingStarted/03-llm-client/README.md)

- **-4- Szerver fogyasztása GitHub Copilot Agent módban a Visual Studio Code-ban**. Itt azt vizsgáljuk, hogyan futtassuk az MCP szerverünket a Visual Studio Code-ból, [a leckére](/03-GettingStarted/04-vscode/README.md)

- **-5- Fogyasztás SSE-ből (Server Sent Events)**. Az SSE egy szabvány a szerver-klienst streaminghez, amely lehetővé teszi a szerverek számára, hogy valós idejű frissítéseket küldjenek a klienseknek HTTP-n keresztül [a leckére](/03-GettingStarted/05-sse-server/README.md)

- **-6- AI Toolkit használata a VSCode-hoz** az MCP kliensek és szerverek fogyasztásához és teszteléséhez [a leckére](/03-GettingStarted/06-aitk/README.md)

- **-7- Tesztelés**. Itt különösen arra koncentrálunk, hogyan tesztelhetjük a szerverünket és kliensünket különböző módokon, [a leckére](/03-GettingStarted/07-testing/README.md)

- **-8- Telepítés**. Ez a fejezet különböző módokat vizsgál meg az MCP megoldások telepítésére, [a leckére](/03-GettingStarted/08-deployment/README.md)

A Model Context Protocol (MCP) egy nyílt protokoll, amely szabványosítja, hogyan biztosítanak az alkalmazások kontextust az LLM-eknek. Gondolj az MCP-re úgy, mint egy USB-C port az AI alkalmazások számára - szabványos módot biztosít az AI modellek csatlakoztatására különböző adatforrásokhoz és eszközökhöz.

## Tanulási célok

A lecke végére képes leszel:

- Fejlesztési környezeteket beállítani MCP-hez C#, Java, Python, TypeScript és JavaScript nyelven
- Alapvető MCP szervereket építeni és telepíteni egyedi funkciókkal (erőforrások, promptok és eszközök)
- Host alkalmazásokat létrehozni, amelyek csatlakoznak MCP szerverekhez
- MCP implementációkat tesztelni és hibakeresni
- Megérteni a gyakori beállítási kihívásokat és megoldásaikat
- MCP implementációkat csatlakoztatni népszerű LLM szolgáltatásokhoz

## MCP környezet beállítása

Mielőtt elkezdenéd az MCP-vel való munkát, fontos, hogy előkészítsd a fejlesztési környezetedet és megértsd az alapvető munkafolyamatot. Ez a rész segít az első lépésekben, hogy zökkenőmentesen kezdj az MCP-vel.

### Előfeltételek

Mielőtt belemerülnél az MCP fejlesztésbe, győződj meg róla, hogy rendelkezel:

- **Fejlesztési környezet**: A választott nyelvedhez (C#, Java, Python, TypeScript vagy JavaScript)
- **IDE/Szerkesztő**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm vagy bármely modern kódszerkesztő
- **Csomagkezelők**: NuGet, Maven/Gradle, pip vagy npm/yarn
- **API kulcsok**: Bármely AI szolgáltatáshoz, amit a host alkalmazásokban tervezel használni

### Hivatalos SDK-k

A következő fejezetekben megoldásokat látsz majd Python, TypeScript, Java és .NET használatával. Íme az összes hivatalosan támogatott SDK.

Az MCP hivatalos SDK-kat biztosít több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Karbantartva a Microsofttal együttműködésben
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Karbantartva a Spring AI-val együttműködésben
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - A hivatalos TypeScript implementáció
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - A hivatalos Python implementáció
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - A hivatalos Kotlin implementáció
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Karbantartva a Loopwork AI-val együttműködésben
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - A hivatalos Rust implementáció

## Főbb tanulságok

- Az MCP fejlesztési környezet beállítása egyszerű a nyelvspecifikus SDK-kkal
- Az MCP szerverek építése magában foglalja az eszközök létrehozását és regisztrálását világos sémákkal
- Az MCP kliensek csatlakoznak szerverekhez és modellekhez, hogy kihasználják a kibővített képességeket
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP implementációkhoz
- A telepítési lehetőségek a helyi fejlesztéstől a felhőalapú megoldásokig terjednek

## Gyakorlás

Van egy mintakészletünk, amely kiegészíti a gyakorlatokat, amelyeket az összes fejezetben látsz ebben a részben. Ezen kívül minden fejezetnek megvannak a saját gyakorlatai és feladatai

- [Java Kalkulátor](./samples/java/calculator/README.md)
- [.Net Kalkulátor](../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulátor](./samples/javascript/README.md)
- [TypeScript Kalkulátor](./samples/typescript/README.md)
- [Python Kalkulátor](../../../03-GettingStarted/samples/python)

## További források

- [MCP GitHub Repository](https://github.com/microsoft/mcp-for-beginners)

## Mi következik

Következő: [Az első MCP szerver létrehozása](/03-GettingStarted/01-first-server/README.md)

**Felelősség kizárása**:  
Ez a dokumentum AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) használatával készült fordítás. Bár törekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az eredeti nyelvén tekintendő hiteles forrásnak. Kritikus információk esetén javasolt a professzionális emberi fordítás. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félremagyarázásokért.