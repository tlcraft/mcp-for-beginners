<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-27T16:19:51+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "cs"
}
-->
Skvěle, pro náš další krok vyjmenujme schopnosti na serveru.

### -2 Vyjmenování schopností serveru

Nyní se připojíme k serveru a požádáme o jeho schopnosti:

### -3 Převod schopností serveru na nástroje pro LLM

Dalším krokem po vyjmenování schopností serveru je jejich převod do formátu, kterému LLM rozumí. Jakmile to uděláme, můžeme tyto schopnosti předat jako nástroje našemu LLM.

Skvěle, nyní jsme připraveni zpracovávat uživatelské požadavky, pojďme se do toho pustit.

### -4 Zpracování uživatelských požadavků

V této části kódu budeme zpracovávat požadavky uživatele.

Skvěle, podařilo se ti to!

## Zadání

Vezmi kód z cvičení a rozšiř server o další nástroje. Pak vytvoř klienta s LLM, jako v cvičení, a otestuj ho s různými požadavky, aby se ujistil, že všechny nástroje serveru jsou volány dynamicky. Tento způsob tvorby klienta zajistí skvělý uživatelský zážitek, protože uživatelé mohou používat přirozený jazyk místo přesných příkazů klienta a nemusí přitom vědět, že je volán MCP server.

## Řešení

[Řešení](/03-GettingStarted/03-llm-client/solution/README.md)

## Klíčové poznatky

- Přidání LLM do klienta poskytuje uživatelům lepší způsob interakce s MCP servery.
- Je potřeba převést odpověď MCP serveru do formátu, kterému LLM rozumí.

## Ukázky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Další zdroje

## Co bude dál

- Další: [Použití serveru ve Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.