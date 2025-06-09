<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:44:14+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hu"
}
-->
### -2- Projekt létrehozása

Miután telepítetted az SDK-t, hozzuk létre a projektet:

### -3- Projektfájlok létrehozása

### -4- Szerverkód írása

### -5- Eszköz és erőforrás hozzáadása

Adj hozzá egy eszközt és egy erőforrást az alábbi kód beillesztésével:

### -6- Végleges kód

Adjunk hozzá minden szükséges kódot, hogy a szerver elindulhasson:

### -7- A szerver tesztelése

Indítsd el a szervert az alábbi parancs segítségével:

### -8- Futtatás az Inspectorral

Az Inspector egy remek eszköz, amely elindítja a szervert és lehetővé teszi az interakciót vele, így tesztelheted, hogy működik-e. Indítsuk el:

> [!NOTE]
> A "parancs" mezőben eltérő lehet a megjelenés, mivel az adott futtatókörnyezethez tartozó szerverindító parancsot tartalmazza.

A következő felhasználói felületet kell látnod:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

1. Csatlakozz a szerverhez a Connect gombra kattintva.
   Miután csatlakoztál a szerverhez, a következőt kell látnod:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hu.png)

2. Válaszd ki a "Tools" menüpontot, majd a "listTools"-t, megjelenik az "Add" opció, válaszd ki az "Add"-ot és töltsd ki a paramétereket.

   A következő válasz jelenik meg, vagyis az "add" eszköz eredménye:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hu.png)

Gratulálunk, sikeresen létrehoztad és futtattad az első szerveredet!

### Hivatalos SDK-k

Az MCP hivatalos SDK-kat kínál több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Microsoft közreműködésével karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Spring AI-val együttműködésben karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – hivatalos TypeScript megvalósítás
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – hivatalos Python megvalósítás
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – hivatalos Kotlin megvalósítás
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Loopwork AI-val együttműködésben karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – hivatalos Rust megvalósítás

## Fontos tanulságok

- Az MCP fejlesztői környezet egyszerűen beállítható nyelvspecifikus SDK-kkal
- MCP szerverek építése eszközök létrehozását és regisztrálását jelenti egyértelmű sémákkal
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP megvalósításhoz

## Minták

- [Java számológép](../samples/java/calculator/README.md)
- [.Net számológép](../../../../03-GettingStarted/samples/csharp)
- [JavaScript számológép](../samples/javascript/README.md)
- [TypeScript számológép](../samples/typescript/README.md)
- [Python számológép](../../../../03-GettingStarted/samples/python)

## Feladat

Hozz létre egy egyszerű MCP szervert egy általad választott eszközzel:
1. Valósítsd meg az eszközt a kedvenc nyelveden (.NET, Java, Python vagy JavaScript).
2. Határozd meg a bemeneti paramétereket és visszatérési értékeket.
3. Futtasd az inspector eszközt, hogy megbizonyosodj arról, hogy a szerver megfelelően működik.
4. Teszteld a megvalósítást különböző bemenetekkel.

## Megoldás

[Megoldás](./solution/README.md)

## További források

- [Agentek építése Model Context Protocol segítségével Azure-on](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Távoli MCP Azure Container Apps használatával (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mi következik

Következő: [Kezdő lépések MCP klienssel](/03-GettingStarted/02-client/README.md)

**Nyilatkozat**:  
Ezt a dokumentumot az AI fordítószolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár a pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy téves értelmezésekért.