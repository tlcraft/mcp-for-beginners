<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0a8086dc4bf89448f83e7936db972c42",
  "translation_date": "2025-05-27T16:22:51+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "cs"
}
-->
Teď, když už víme trochu víc o SSE, pojďme si vytvořit SSE server.

## Cvičení: Vytvoření SSE serveru

Při tvorbě serveru je třeba mít na paměti dvě věci:

- Musíme použít webový server, který zpřístupní endpointy pro připojení a zprávy.
- Server postavíme jako obvykle s nástroji, zdroji a výzvami, které jsme používali u stdio.

### -1- Vytvoření instance serveru

Pro vytvoření serveru použijeme stejné typy jako u stdio. Pro transport však musíme zvolit SSE.

---

Přidáme potřebné routy.

### -2- Přidání rout

Přidáme routy, které budou zpracovávat připojení a příchozí zprávy:

---

Přidáme schopnosti serveru.

### -3- Přidání schopností serveru

Nyní, když máme definováno vše specifické pro SSE, přidáme schopnosti serveru jako nástroje, výzvy a zdroje.

---

Celý kód by měl vypadat takto:

---

Skvěle, máme server používající SSE, pojďme si ho vyzkoušet.

## Cvičení: Ladění SSE serveru pomocí Inspectoru

Inspector je skvělý nástroj, který jsme viděli v předchozí lekci [Vytvoření prvního serveru](/03-GettingStarted/01-first-server/README.md). Podíváme se, jestli ho můžeme použít i zde:

### -1- Spuštění Inspectoru

Nejdříve musíte mít spuštěný SSE server, tak ho spusťme:

1. Spusťte server

2. Spusťte Inspector

    > ![NOTE]
    > Tento příkaz spusťte v jiném terminálovém okně než server. Také upravte příkaz podle URL, kde váš server běží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Spuštění Inspectoru je ve všech runtime stejné. Všimněte si, že místo cesty k serveru a příkazu ke spuštění předáváme URL, kde server běží, a také specifikujeme routu `/sse`.

### -2- Vyzkoušení nástroje

Připojte se k serveru výběrem SSE v rozbalovacím seznamu a vyplňte pole URL, kde server běží, například http://localhost:4321/sse. Klikněte na tlačítko "Connect". Stejně jako předtím vyberte nástroje, zadejte vstupní hodnoty. Výsledek by měl vypadat takto:

![SSE Server běžící v inspectoru](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.cs.png)

Skvělé, dokážete pracovat s Inspector, pojďme se podívat, jak pracovat s Visual Studio Code.

## Zadání

Zkuste rozšířit server o další schopnosti. Například na [této stránce](https://api.chucknorris.io/) můžete najít API, které můžete přidat jako nástroj. Rozhodněte, jak by server měl vypadat. Bavte se :)

## Řešení

[Řešení](./solution/README.md) Zde je možné řešení s funkčním kódem.

## Hlavní body

Hlavní body této kapitoly jsou:

- SSE je druhý podporovaný transport vedle stdio.
- Pro podporu SSE musíte spravovat příchozí připojení a zprávy pomocí webového frameworku.
- SSE server můžete konzumovat jak pomocí Inspectoru, tak Visual Studio Code, stejně jako stdio servery. Rozdíl je v tom, že u SSE musíte server spustit samostatně a potom spustit Inspector. U Inspectoru je také potřeba zadat URL.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../../../../03-GettingStarted/samples/javascript)
- [TypeScript Calculator](../../../../03-GettingStarted/samples/typescript)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Co dál

- Další: [Začínáme s AI Toolkit pro VSCode](/03-GettingStarted/06-aitk/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo mylné výklady vzniklé použitím tohoto překladu.