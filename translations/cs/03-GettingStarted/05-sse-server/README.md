<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:56:41+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "cs"
}
-->
Nyní, když už víme trochu více o SSE, pojďme si postavit SSE server.

## Cvičení: Vytvoření SSE serveru

Pro vytvoření našeho serveru je potřeba mít na paměti dvě věci:

- Potřebujeme použít webový server, který zpřístupní endpointy pro připojení a zprávy.
- Server postavíme stejně jako obvykle s nástroji, zdroji a výzvami, které jsme používali u stdio.

### -1- Vytvoření instance serveru

Pro vytvoření serveru použijeme stejné typy jako u stdio. Pro transport však musíme zvolit SSE.

---

Pojďme přidat potřebné routy.

### -2- Přidání rout

Přidejme routy, které budou zpracovávat připojení a příchozí zprávy:

---

Nyní přidáme schopnosti serveru.

### -3- Přidání schopností serveru

Jakmile máme definováno vše specifické pro SSE, přidáme schopnosti serveru, jako jsou nástroje, výzvy a zdroje.

---

Váš kompletní kód by měl vypadat takto:

---

Skvěle, máme server používající SSE, pojďme si ho vyzkoušet.

## Cvičení: Ladění SSE serveru pomocí Inspectoru

Inspector je skvělý nástroj, který jsme viděli v předchozí lekci [Creating your first server](/03-GettingStarted/01-first-server/README.md). Podívejme se, jestli ho můžeme použít i zde:

### -1- Spuštění Inspectoru

Pro spuštění Inspectoru musíte mít nejprve běžící SSE server, pojďme ho tedy spustit:

1. Spusťte server

1. Spusťte Inspector

    > ![NOTE]
    > Tento příkaz spusťte v samostatném terminálovém okně, než ve kterém běží server. Také nezapomeňte upravit příkaz podle URL, kde váš server běží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Spuštění Inspectoru vypadá stejně ve všech runtimech. Všimněte si, že místo předávání cesty k serveru a příkazu pro jeho spuštění předáváme URL, kde server běží, a také specifikujeme routu `/sse`.

### -2- Vyzkoušení nástroje

Připojte se k serveru výběrem SSE v rozbalovacím seznamu a vyplňte pole URL, kde váš server běží, například http://localhost:4321/sse. Poté klikněte na tlačítko "Connect". Stejně jako dříve vyberte nástroje, zadejte vstupní hodnoty a měli byste vidět výsledek jako na obrázku níže:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.cs.png)

Skvěle, můžete pracovat s Inspector nástrojem, pojďme se teď podívat, jak pracovat s Visual Studio Code.

## Zadání

Zkuste rozšířit váš server o další schopnosti. Podívejte se na [tuto stránku](https://api.chucknorris.io/), kde můžete například přidat nástroj, který volá API, rozhodněte sami, jak by měl server vypadat. Bavte se :)

## Řešení

[Řešení](./solution/README.md) Zde je možné řešení s funkčním kódem.

## Hlavní poznatky

Hlavní poznatky z této kapitoly jsou:

- SSE je druhý podporovaný typ transportu vedle stdio.
- Pro podporu SSE musíte spravovat příchozí připojení a zprávy pomocí webového frameworku.
- K práci se SSE serverem můžete použít jak Inspector, tak Visual Studio Code, stejně jako u stdio serverů. Všimněte si, že mezi stdio a SSE jsou malé rozdíly. U SSE musíte server spustit samostatně a poté spustit Inspector. U Inspectoru je také rozdíl v tom, že musíte specifikovat URL.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dál

- Další: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.