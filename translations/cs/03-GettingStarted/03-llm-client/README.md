<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:27:42+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "cs"
}
-->
# Vytvoření klienta s LLM

Doposud jste viděli, jak vytvořit server a klienta. Klient byl schopen explicitně volat server, aby vypsal jeho nástroje, zdroje a podněty. Nicméně, není to příliš praktický přístup. Váš uživatel žije v agentické éře a očekává, že bude používat podněty a komunikovat s LLM, aby toho dosáhl. Pro vašeho uživatele nezáleží na tom, zda používáte MCP nebo ne k ukládání vašich schopností, ale očekává, že bude používat přirozený jazyk k interakci. Jak to tedy vyřešíme? Řešení spočívá v přidání LLM do klienta.

## Přehled

V této lekci se zaměříme na přidání LLM do vašeho klienta a ukážeme, jak to poskytuje mnohem lepší zážitek pro vašeho uživatele.

## Cíle učení

Na konci této lekce budete schopni:

- Vytvořit klienta s LLM.
- Bezproblémově interagovat s MCP serverem pomocí LLM.
- Poskytnout lepší uživatelský zážitek na straně klienta.

## Přístup

Zkusme pochopit přístup, který musíme zvolit. Přidání LLM zní jednoduše, ale skutečně to uděláme?

Takto bude klient interagovat se serverem:

1. Navázat spojení se serverem.

1. Vypsat schopnosti, podněty, zdroje a nástroje a uložit jejich schéma.

1. Přidat LLM a předat uložené schopnosti a jejich schéma ve formátu, kterému LLM rozumí.

1. Zpracovat uživatelský podnět jeho předáním LLM spolu s nástroji uvedenými klientem.

Skvělé, nyní chápeme, jak to můžeme udělat na vysoké úrovni, zkusme si to vyzkoušet v následujícím cvičení.

## Cvičení: Vytvoření klienta s LLM

V tomto cvičení se naučíme přidat LLM do našeho klienta.

### -1- Připojení k serveru

Nejprve vytvořme našeho klienta:
Jste vyškoleni na datech do října 2023.

Skvělé, pro náš další krok, pojďme vypsat schopnosti na serveru.

### -2 Vypsání schopností serveru

Nyní se připojíme k serveru a požádáme o jeho schopnosti.

### -3- Převod schopností serveru na nástroje LLM

Dalším krokem po vypsání schopností serveru je jejich převod do formátu, kterému LLM rozumí. Jakmile to uděláme, můžeme tyto schopnosti poskytnout jako nástroje našemu LLM.

Skvělé, nyní jsme připraveni zpracovat jakékoli uživatelské požadavky, pojďme se tedy na to zaměřit.

### -4- Zpracování uživatelského podnětu

V této části kódu budeme zpracovávat uživatelské požadavky.

Skvělé, zvládli jste to!

## Úkol

Vezměte kód z cvičení a rozšiřte server o další nástroje. Poté vytvořte klienta s LLM, jako v cvičení, a otestujte ho s různými podněty, abyste se ujistili, že všechny vaše serverové nástroje jsou volány dynamicky. Tento způsob vytváření klienta znamená, že koncový uživatel bude mít skvělý uživatelský zážitek, protože bude schopen používat podněty, místo přesných klientských příkazů, a nebude mít povědomí o žádném volaném MCP serveru.

## Řešení

[Řešení](/03-GettingStarted/03-llm-client/solution/README.md)

## Klíčové poznatky

- Přidání LLM do vašeho klienta poskytuje lepší způsob, jak uživatelé mohou interagovat s MCP servery.
- Musíte převést odpověď MCP serveru na něco, čemu LLM rozumí.

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Další zdroje

## Co dál

- Dále: [Spotřeba serveru pomocí Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Upozornění**:  
Tento dokument byl přeložen pomocí služby pro překlad AI [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, uvědomte si prosím, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.