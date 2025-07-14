<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:55:34+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "cs"
}
-->
Skvěle, pro náš další krok si vyjmenujme schopnosti na serveru.

### -2 Vyjmenování schopností serveru

Nyní se připojíme k serveru a požádáme o jeho schopnosti:

### -3 Převod schopností serveru na nástroje LLM

Dalším krokem po vyjmenování schopností serveru je jejich převod do formátu, kterému LLM rozumí. Jakmile to uděláme, můžeme tyto schopnosti poskytnout jako nástroje našemu LLM.

Skvěle, nyní jsme připraveni zpracovávat uživatelské požadavky, pojďme se do toho pustit.

### -4 Zpracování uživatelského požadavku

V této části kódu budeme zpracovávat uživatelské požadavky.

Skvěle, zvládl jste to!

## Zadání

Vezměte kód z cvičení a rozšiřte server o další nástroje. Poté vytvořte klienta s LLM, jako v cvičení, a otestujte ho s různými promptami, abyste se ujistili, že všechny nástroje serveru jsou volány dynamicky. Tento způsob vytváření klienta znamená, že koncový uživatel bude mít skvělý uživatelský zážitek, protože může používat prompty místo přesných příkazů klienta a nebude si muset všímat, že je volán nějaký MCP server.

## Řešení

[Řešení](/03-GettingStarted/03-llm-client/solution/README.md)

## Hlavní poznatky

- Přidání LLM do vašeho klienta poskytuje lepší způsob, jak uživatelé mohou komunikovat s MCP servery.
- Je potřeba převést odpověď MCP serveru do formátu, kterému LLM rozumí.

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Další zdroje

## Co bude dál

- Další: [Používání serveru ve Visual Studio Code](../04-vscode/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.