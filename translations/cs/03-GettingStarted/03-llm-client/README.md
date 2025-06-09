<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:43:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "cs"
}
-->
Skvěle, v dalším kroku si vyjmenujme schopnosti na serveru.

### -2 Vyjmenování schopností serveru

Nyní se připojíme k serveru a požádáme o jeho schopnosti:

### -3 Převod schopností serveru na nástroje LLM

Dalším krokem po vyjmenování schopností serveru je převést je do formátu, kterému LLM rozumí. Jakmile to uděláme, můžeme tyto schopnosti poskytnout jako nástroje našemu LLM.

Skvěle, teď jsme připraveni zpracovávat požadavky uživatelů, pojďme se na to zaměřit.

### -4 Zpracování uživatelských požadavků

V této části kódu budeme zpracovávat požadavky uživatelů.

Výborně, zvládli jste to!

## Zadání

Vezměte kód z cvičení a rozšiřte server o další nástroje. Poté vytvořte klienta s LLM, stejně jako v cvičení, a otestujte ho s různými dotazy, abyste se ujistili, že všechny nástroje serveru jsou volány dynamicky. Tento způsob vytváření klienta znamená, že koncový uživatel bude mít skvělý uživatelský zážitek, protože může používat přirozené dotazy místo přesných příkazů klienta a nebude si muset všímat, že je volán nějaký MCP server.

## Řešení

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Hlavní poznatky

- Přidání LLM do klienta poskytuje lepší způsob, jak uživatelé mohou komunikovat s MCP servery.
- Je potřeba převést odpověď MCP serveru do formátu, kterému LLM rozumí.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

## Co dál

- Další: [Použití serveru ve Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.