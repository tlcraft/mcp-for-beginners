<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:35:41+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "cs"
}
-->
Skvěle, pro náš další krok vyjmenujme schopnosti na serveru.

### -2 Vyjmenování schopností serveru

Nyní se připojíme k serveru a požádáme o jeho schopnosti:

### -3- Převod schopností serveru na nástroje LLM

Dalším krokem po vyjmenování schopností serveru je jejich převod do formátu, kterému LLM rozumí. Jakmile to uděláme, můžeme tyto schopnosti poskytnout jako nástroje našemu LLM.

Skvěle, nyní jsme připraveni zpracovat požadavky uživatele, pojďme se na to zaměřit.

### -4- Zpracování požadavků uživatele

V této části kódu budeme zpracovávat požadavky uživatele.

Výborně, podařilo se vám to!

## Zadání

Vezměte kód z cvičení a rozšiřte server o další nástroje. Poté vytvořte klienta s LLM, jako v cvičení, a otestujte ho s různými dotazy, abyste se ujistili, že všechny nástroje serveru jsou volány dynamicky. Tento způsob vytváření klienta znamená, že koncový uživatel bude mít skvělý uživatelský zážitek, protože může používat přirozené dotazy místo přesných klientských příkazů a nebude si muset být vědom volání jakéhokoliv MCP serveru.

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

- Další: [Používání serveru ve Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo chybné interpretace vyplývající z použití tohoto překladu.