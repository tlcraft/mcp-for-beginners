<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:40:45+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hu"
}
-->
### -2- Projekt létrehozása

Most, hogy telepítetted az SDK-t, hozzuk létre a projektet:

### -3- Projektfájlok létrehozása

### -4- Szerverkód írása

### -5- Eszköz és erőforrás hozzáadása

Adjunk hozzá egy eszközt és egy erőforrást az alábbi kód beillesztésével:

### -6- Végleges kód

Adjuk hozzá az utolsó szükséges kódot, hogy a szerver elindulhasson:

### -7- Szerver tesztelése

Indítsd el a szervert a következő paranccsal:

### -8- Futás az inspectort használva

Az inspector egy nagyszerű eszköz, amely elindítja a szervert, és lehetővé teszi, hogy interaktívan teszteld a működését. Indítsuk el:

> [!NOTE]
> A "command" mezőben a parancs eltérő lehet, mert az a te specifikus runtime-od szerverindítási parancsát tartalmazza.

A következő felhasználói felületet kell látnod:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

1. Csatlakozz a szerverhez a Connect gombra kattintva.
  Ha csatlakoztál, a következőt kell látnod:

  ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hu.png)

2. Válaszd ki a "Tools" és "listTools" menüpontot, ekkor megjelenik az "Add" lehetőség. Válaszd ki az "Add"-ot és töltsd ki a paramétereket.

  A következő választ kell kapnod, vagyis az "add" eszköz eredményét:

  ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hu.png)

Gratulálunk, sikeresen létrehoztad és futtattad az első szerveredet!

### Hivatalos SDK-k

Az MCP hivatalos SDK-kat biztosít több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Microsoft együttműködésben karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Spring AI együttműködésben karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Hivatalos TypeScript megvalósítás
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Hivatalos Python megvalósítás
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Hivatalos Kotlin megvalósítás
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Loopwork AI együttműködésben karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Hivatalos Rust megvalósítás

## Főbb tanulságok

- Az MCP fejlesztői környezet beállítása egyszerű a nyelvspecifikus SDK-kkal
- Az MCP szerverek építése eszközök létrehozását és regisztrálását jelenti egyértelmű sémákkal
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP megvalósításhoz

## Példák

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Feladat

Készíts egy egyszerű MCP szervert egy általad választott eszközzel:
1. Valósítsd meg az eszközt a preferált nyelveden (.NET, Java, Python vagy JavaScript).
2. Határozd meg a bemeneti paramétereket és a visszatérési értékeket.
3. Futtasd az inspector eszközt, hogy megbizonyosodj a szerver helyes működéséről.
4. Teszteld a megvalósítást különböző bemenetekkel.

## Megoldás

[Megoldás](./solution/README.md)

## További források

- [MCP GitHub tároló](https://github.com/microsoft/mcp-for-beginners)

## Mi következik

Következő: [MCP kliensek használata](/03-GettingStarted/02-client/README.md)

**Nyilatkozat**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások tartalmazhatnak hibákat vagy pontatlanságokat. Az eredeti dokumentum a saját nyelvén tekintendő hiteles forrásnak. Fontos információk esetén professzionális emberi fordítást javaslunk. Nem vállalunk felelősséget a fordítás használatából eredő félreértésekért vagy félreértelmezésekért.