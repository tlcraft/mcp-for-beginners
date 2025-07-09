<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "315ecce765d22639b60dbc41344c8533",
  "translation_date": "2025-07-09T23:13:23+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hu"
}
-->
### -2- Projekt létrehozása

Most, hogy telepítetted az SDK-t, hozzuk létre a projektet:

### -3- Projektfájlok létrehozása

### -4- Szerverkód írása

### -5- Eszköz és erőforrás hozzáadása

Adj hozzá egy eszközt és egy erőforrást az alábbi kód beillesztésével:

### -6- Végleges kód

Adjuk hozzá az utolsó szükséges kódot, hogy a szerver elindulhasson:

### -7- A szerver tesztelése

Indítsd el a szervert a következő paranccsal:

### -8- Futtatás az inspectorral

Az inspector egy nagyszerű eszköz, amely elindítja a szervert, és lehetővé teszi, hogy interakcióba lépj vele, így tesztelheted a működését. Indítsuk el:
> [!NOTE]
> a "command" mezőben eltérően jelenhet meg, mivel az adott futtatókörnyezethez tartozó szerverindító parancsot tartalmazza/
A következő felhasználói felületet kell látnod:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

1. Csatlakozz a szerverhez a Connect gomb kiválasztásával
  Miután csatlakoztál a szerverhez, a következőt kell látnod:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hu.png)

1. Válaszd ki a "Tools" menüt, majd a "listTools" opciót, ekkor meg kell jelennie az "Add" opciónak, válaszd ki az "Add"-ot, és töltsd ki a paraméterértékeket.

  A következő választ kell látnod, azaz az "add" eszköz eredményét:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hu.png)

Gratulálunk, sikeresen létrehoztad és futtattad az első szerveredet!

### Hivatalos SDK-k

Az MCP hivatalos SDK-kat biztosít több nyelvhez:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Microsoft együttműködésével karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Spring AI együttműködésével karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Hivatalos TypeScript megvalósítás
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Hivatalos Python megvalósítás
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Hivatalos Kotlin megvalósítás
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Loopwork AI együttműködésével karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Hivatalos Rust megvalósítás

## Főbb tanulságok

- Az MCP fejlesztői környezet beállítása egyszerű a nyelvspecifikus SDK-kkal
- MCP szerverek építése eszközök létrehozását és regisztrálását jelenti egyértelmű sémákkal
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP megvalósításokhoz

## Minták

- [Java Számológép](../samples/java/calculator/README.md)
- [.Net Számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Számológép](../samples/javascript/README.md)
- [TypeScript Számológép](../samples/typescript/README.md)
- [Python Számológép](../../../../03-GettingStarted/samples/python)

## Feladat

Hozz létre egy egyszerű MCP szervert egy általad választott eszközzel:

1. Valósítsd meg az eszközt a preferált nyelveden (.NET, Java, Python vagy JavaScript).
2. Határozd meg a bemeneti paramétereket és a visszatérési értékeket.
3. Futtasd az inspector eszközt, hogy megbizonyosodj róla, a szerver a vártnak megfelelően működik.
4. Teszteld a megvalósítást különböző bemenetekkel.

## Megoldás

[Megoldás](./solution/README.md)

## További források

- [Ügynökök építése Model Context Protocol segítségével Azure-on](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Távoli MCP Azure Container Apps segítségével (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Ügynök](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mi következik

Következő: [MCP kliensek használatának megkezdése](../02-client/README.md)

**Jogi nyilatkozat**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Fontos információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.