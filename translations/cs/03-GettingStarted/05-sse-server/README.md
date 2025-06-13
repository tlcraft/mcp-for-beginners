<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-13T00:56:13+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "cs"
}
-->
Teď, když už o SSE víme trochu víc, pojďme si vytvořit SSE server.

## Cvičení: Vytvoření SSE serveru

Při tvorbě serveru je potřeba mít na paměti dvě věci:

- Potřebujeme použít webový server, který vystaví endpointy pro připojení a zprávy.
- Server postavíme stejně jako obvykle s nástroji, zdroji a výzvami, jak jsme to dělali se stdio.

### -1- Vytvoření instance serveru

Pro vytvoření serveru použijeme stejné typy jako u stdio. Pro transport však musíme zvolit SSE.

Pojďme teď přidat potřebné routy.

### -2- Přidání rout

Přidáme routy, které budou zpracovávat připojení a příchozí zprávy:

Dále přidáme schopnosti serveru.

### -3- Přidání schopností serveru

Teď, když máme definované vše specifické pro SSE, přidáme schopnosti serveru jako nástroje, výzvy a zdroje.

Celý kód by měl vypadat takto:

Skvěle, máme server používající SSE, pojďme si ho teď vyzkoušet.

## Cvičení: Ladění SSE serveru pomocí Inspectoru

Inspector je skvělý nástroj, který jsme viděli v předchozí lekci [Creating your first server](/03-GettingStarted/01-first-server/README.md). Podíváme se, jestli ho můžeme použít i tady:

### -1- Spuštění inspectoru

Nejdříve musíte mít spuštěný SSE server, takže to uděláme:

1. Spusťte server

1. Spusťte inspector

    > [!NOTE]
    > Tento příkaz spusťte v jiném terminálu, než kde běží server. Také si upravte příkaz tak, aby odpovídal URL, kde váš server běží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Spuštění inspectoru vypadá stejně ve všech runtimech. Všimněte si, že místo předání cesty k serveru a příkazu pro jeho spuštění předáváme URL, kde server běží, a specifikujeme routu `/sse`.

### -2- Vyzkoušení nástroje

Připojte se k serveru výběrem SSE v rozbalovacím seznamu a vyplňte URL, kde váš server běží, například http://localhost:4321/sse. Pak klikněte na tlačítko „Connect“. Stejně jako dříve vyberte seznam nástrojů, vyberte nástroj a zadejte vstupní hodnoty. Výsledek by měl vypadat takto:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.cs.png)

Skvěle, umíte pracovat s inspector, pojďme se podívat, jak pracovat s Visual Studio Code.

## Zadání

Zkuste rozšířit server o další schopnosti. Podívejte se na [tuto stránku](https://api.chucknorris.io/) a například přidejte nástroj, který volá API, jak si server představíte, je na vás. Bavte se :)

## Řešení

[Řešení](./solution/README.md) Zde je možné řešení s funkčním kódem.

## Klíčové body

Z této kapitoly si odnesete následující:

- SSE je druhý podporovaný transport vedle stdio.
- Pro podporu SSE musíte spravovat příchozí připojení a zprávy pomocí webového frameworku.
- SSE server můžete spotřebovávat jak pomocí Inspectoru, tak Visual Studio Code, stejně jako stdio servery. Všimněte si ale rozdílů mezi stdio a SSE. U SSE je potřeba server spustit zvlášť a pak spustit inspector. U inspectoru je také rozdíl v tom, že musíte specifikovat URL.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co bude dál

- Další: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.