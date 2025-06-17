<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:52:28+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "cs"
}
-->
Skvěle, pro náš další krok si vyjmenujme schopnosti na serveru.

### -2 Vyjmenování schopností serveru

Nyní se připojíme k serveru a zeptáme se na jeho schopnosti:

### -3 Převod schopností serveru na nástroje LLM

Dalším krokem po vyjmenování schopností serveru je jejich převod do formátu, kterému rozumí LLM. Jakmile to uděláme, můžeme tyto schopnosti poskytnout jako nástroje našemu LLM.

Skvěle, jsme připraveni zpracovat uživatelské požadavky, pojďme se do toho pustit.

### -4 Zpracování uživatelského požadavku

V této části kódu budeme zpracovávat uživatelské požadavky.

Skvěle, zvládl jste to!

## Zadání

Vezměte si kód z cvičení a rozšiřte server o další nástroje. Poté vytvořte klienta s LLM, jako v cvičení, a otestujte ho s různými výzvami, abyste se ujistili, že všechny nástroje serveru jsou dynamicky volány. Tento způsob tvorby klienta znamená, že koncový uživatel bude mít skvělý uživatelský zážitek, protože může používat přirozený jazyk místo přesných příkazů klienta a nebude si muset být vědom volání MCP serveru.

## Řešení

[Řešení](/03-GettingStarted/03-llm-client/solution/README.md)

## Hlavní poznatky

- Přidání LLM do vašeho klienta poskytuje lepší způsob, jak mohou uživatelé komunikovat s MCP servery.
- Je třeba převést odpověď MCP serveru do formátu, kterému LLM rozumí.

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Další zdroje

## Co dál

- Další: [Použití serveru ve Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné interpretace vyplývající z použití tohoto překladu.