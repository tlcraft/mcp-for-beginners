<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T17:07:06+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hu"
}
-->
### -2- Projekt létrehozása

Most, hogy telepítetted az SDK-t, hozzunk létre egy projektet: 

### -3- Projektfájlok létrehozása

### -4- Szerverkód létrehozása

### -5- Eszköz és erőforrás hozzáadása

Adj hozzá egy eszközt és egy erőforrást az alábbi kód beillesztésével:

### -6- Végleges kód

Adjuk hozzá a szükséges utolsó kódot, hogy a szerver el tudjon indulni:

### -7- A szerver tesztelése

Indítsd el a szervert a következő parancs segítségével:

### -8- Futtatás az inspectorral

Az inspector egy nagyszerű eszköz, amely elindítja a szerveredet, és lehetővé teszi az interakciót vele, hogy tesztelhesd a működését. Indítsuk el:

> [!NOTE]
> A "parancs" mezőben eltérő lehet a megjelenés, mivel az adott runtime-odnak megfelelő szerverindító parancsot tartalmazza.

A következő felhasználói felületet kell látnod:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

1. Csatlakozz a szerverhez a Connect gomb megnyomásával.  
   A csatlakozás után a következő képernyőt kell látnod:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hu.png)

2. Válaszd ki a "Tools" menüpontot, majd a "listTools"-t, meg kell jelennie az "Add" opciónak. Válaszd ki az "Add"-ot, és töltsd ki a paramétereket.

   A következő választ kell kapnod, vagyis az "add" eszköz eredményét:

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hu.png)

Gratulálunk, sikeresen létrehoztad és elindítottad az első szerveredet!

### Hivatalos SDK-k

Az MCP hivatalos SDK-kat kínál több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Microsoft-szal közösen karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Spring AI-vel közösen karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Hivatalos TypeScript megvalósítás
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Hivatalos Python megvalósítás
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Hivatalos Kotlin megvalósítás
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Loopwork AI-vel közösen karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Hivatalos Rust megvalósítás

## Főbb tanulságok

- Az MCP fejlesztői környezet beállítása egyszerű, nyelvspecifikus SDK-k segítségével
- MCP szerverek építése során eszközöket kell létrehozni és regisztrálni egyértelmű sémákkal
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP megvalósításhoz

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
3. Futtasd az inspector eszközt, hogy megbizonyosodj arról, hogy a szerver megfelelően működik.
4. Teszteld a megvalósítást különböző bemenetekkel.

## Megoldás

[Megoldás](./solution/README.md)

## További források

- [MCP GitHub tárhely](https://github.com/microsoft/mcp-for-beginners)

## Mi következik

Következő: [MCP kliensekkel való kezdés](/03-GettingStarted/02-client/README.md)

**Felelősségkizárás**:  
Ez a dokumentum az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével készült. Bár igyekszünk a pontosságra, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum a saját nyelvén tekintendő hiteles forrásnak. Fontos információk esetén javasolt szakmai, emberi fordítást igénybe venni. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy félreértelmezésekért.