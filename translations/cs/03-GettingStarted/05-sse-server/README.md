<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:26:32+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "cs"
}
-->
Teď, když už víme trochu víc o SSE, postavme si další server SSE.

## Cvičení: Vytvoření SSE serveru

Při tvorbě našeho serveru je potřeba mít na paměti dvě věci:

- Potřebujeme použít webový server, který zpřístupní endpointy pro připojení a zprávy.
- Server stavíme jako obvykle s nástroji, zdroji a promptami, tak jak jsme to dělali u stdio.

### -1- Vytvoření instance serveru

Pro vytvoření serveru použijeme stejné typy jako u stdio. Pro transport ale musíme zvolit SSE.

Přidejme teď potřebné routy.

### -2- Přidání rout

Přidáme routy, které budou zpracovávat připojení a příchozí zprávy:

Přidáme teď schopnosti serveru.

### -3- Přidání schopností serveru

Nyní, když máme definováno vše specifické pro SSE, přidáme schopnosti serveru jako jsou nástroje, prompt a zdroje.

Tvůj kompletní kód by měl vypadat takto:

Skvěle, máme server používající SSE, pojďme si ho teď vyzkoušet.

## Cvičení: Ladění SSE serveru pomocí Inspectoru

Inspector je skvělý nástroj, který jsme viděli v předchozí lekci [Vytvoření prvního serveru](/03-GettingStarted/01-first-server/README.md). Podíváme se, jestli ho můžeme použít i zde:

### -1- Spuštění inspectoru

Nejprve musí být spuštěný SSE server, tak ho nejdřív spusťme:

1. Spusť server

1. Spusť inspector

    > ![NOTE]
    > Spusť tento příkaz v samostatném terminálovém okně, než ve kterém běží server. Také si uprav níže uvedený příkaz podle URL, na které tvůj server běží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Spuštění inspectoru vypadá ve všech runtimech stejně. Všimni si, že místo předávání cesty k serveru a příkazu pro jeho spuštění předáváme URL, na které server běží, a také specifikujeme routu `/sse`.

### -2- Vyzkoušení nástroje

Připoj se k serveru výběrem SSE v rozbalovacím seznamu a vyplň pole URL, kde tvůj server běží, například http://localhost:4321/sse. Poté klikni na tlačítko "Connect". Stejně jako předtím vyber nástroj, zadej vstupní hodnoty a měl bys vidět výsledek jako níže:

![SSE Server běžící v inspectoru](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.cs.png)

Skvěle, dokážeš pracovat s inspector, pojďme se teď podívat, jak pracovat s Visual Studio Code.

## Zadání

Zkus rozšířit svůj server o další schopnosti. Podívej se na [tuto stránku](https://api.chucknorris.io/), kde můžeš například přidat nástroj, který volá API. Rozhodni se, jak by měl server vypadat. Hodně zábavy :)

## Řešení

[Řešení](./solution/README.md) Zde je možné řešení s funkčním kódem.

## Klíčové body

Hlavní poznatky z této kapitoly jsou:

- SSE je druhý podporovaný transport vedle stdio.
- Pro podporu SSE je potřeba spravovat příchozí připojení a zprávy pomocí webového frameworku.
- SSE server můžeš konzumovat jak pomocí Inspectoru, tak Visual Studio Code, stejně jako stdio servery. Všimni si ale drobných rozdílů mezi stdio a SSE. U SSE musíš server spustit zvlášť a pak spustit inspector nástroj. U inspectoru je také potřeba specifikovat URL.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dál

- Další: [HTTP Streaming s MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.