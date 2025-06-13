<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90651bcd1df019768921d531653638a",
  "translation_date": "2025-06-13T00:50:09+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "hu"
}
-->
### -2- Projekt létrehozása

Most, hogy telepítetted az SDK-t, hozzuk létre a projektet: 

### -3- Projektfájlok létrehozása

### -4- Szerverkód megírása

### -5- Eszköz és erőforrás hozzáadása

Adj hozzá egy eszközt és egy erőforrást a következő kóddal: 

### -6 Végleges kód

Adjuk hozzá az utolsó szükséges kódrészletet, hogy a szerver el tudjon indulni: 

### -7- A szerver tesztelése

Indítsd el a szervert a következő paranccsal: 

### -8- Futtatás az Inspector segítségével

Az Inspector egy nagyszerű eszköz, amely elindítja a szervered, és lehetőséget ad az interakcióra, így tesztelheted, hogy működik-e. Indítsuk el:

> [!NOTE]
> a "command" mezőben eltérő lehet a megjelenés, mivel az adott futtatókörnyezethez tartozó szerverindító parancsot tartalmazza

A következő felhasználói felületet kell látnod:

![Csatlakozás](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.hu.png)

1. Csatlakozz a szerverhez a Csatlakozás gomb megnyomásával  
  A csatlakozás után a következőt kell látnod:

  ![Csatlakoztatva](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.hu.png)

2. Válaszd ki a "Tools" menüt, majd a "listTools" opciót, meg kell jelennie az "Add" gombnak, kattints rá, és töltsd ki a paramétereket.

  A következő választ kell kapnod, azaz az "add" eszköz eredményét:

  ![Add eszköz futtatásának eredménye](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.hu.png)

Gratulálunk, sikeresen létrehoztad és elindítottad az első szervered!

### Hivatalos SDK-k

Az MCP hivatalos SDK-kat kínál több nyelvhez:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) – Microsoft együttműködésével karbantartva
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) – Spring AI együttműködésével karbantartva
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) – Hivatalos TypeScript megvalósítás
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) – Hivatalos Python megvalósítás
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) – Hivatalos Kotlin megvalósítás
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) – Loopwork AI együttműködésével karbantartva
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) – Hivatalos Rust megvalósítás

## Főbb tanulságok

- Az MCP fejlesztői környezet egyszerűen beállítható nyelvspecifikus SDK-kkal
- MCP szerverek építése során eszközöket kell létrehozni és regisztrálni jól definiált sémákkal
- A tesztelés és hibakeresés elengedhetetlen a megbízható MCP megvalósításokhoz

## Példák

- [Java kalkulátor](../samples/java/calculator/README.md)
- [.Net kalkulátor](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulátor](../samples/javascript/README.md)
- [TypeScript kalkulátor](../samples/typescript/README.md)
- [Python kalkulátor](../../../../03-GettingStarted/samples/python)

## Feladat

Hozz létre egy egyszerű MCP szervert egy általad választott eszközzel:
1. Valósítsd meg az eszközt a preferált nyelveden (.NET, Java, Python vagy JavaScript).
2. Határozd meg a bemeneti paramétereket és a visszatérési értékeket.
3. Futtasd az Inspector eszközt, hogy megbizonyosodj róla, a szerver a vártnak megfelelően működik.
4. Teszteld a megvalósítást különböző bemenetekkel.

## Megoldás

[Megoldás](./solution/README.md)

## További források

- [Ügynökök építése Model Context Protocol segítségével az Azure-on](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Távoli MCP Azure Container Apps használatával (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP ügynök](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Mi következik

Következő: [MCP kliensek használata](/03-GettingStarted/02-client/README.md)

**Felelősségkizárás**:  
Ezt a dokumentumot az AI fordító szolgáltatás, a [Co-op Translator](https://github.com/Azure/co-op-translator) segítségével fordítottuk le. Bár az pontosságra törekszünk, kérjük, vegye figyelembe, hogy az automatikus fordítások hibákat vagy pontatlanságokat tartalmazhatnak. Az eredeti dokumentum az anyanyelvén tekintendő hiteles forrásnak. Kritikus információk esetén szakmai, emberi fordítást javaslunk. Nem vállalunk felelősséget az ebből a fordításból eredő félreértésekért vagy téves értelmezésekért.