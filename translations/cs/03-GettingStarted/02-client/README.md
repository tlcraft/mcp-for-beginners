<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:47:36+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "cs"
}
-->
# Vytvoření klienta

Klienti jsou vlastní aplikace nebo skripty, které přímo komunikují s MCP Serverem a žádají o zdroje, nástroje a výzvy. Na rozdíl od použití inspektorového nástroje, který poskytuje grafické rozhraní pro interakci se serverem, vám psaní vlastního klienta umožňuje programové a automatizované interakce. To umožňuje vývojářům integrovat schopnosti MCP do jejich vlastních pracovních postupů, automatizovat úkoly a vytvářet vlastní řešení přizpůsobená konkrétním potřebám.

## Přehled

Tato lekce představuje koncept klientů v ekosystému Model Context Protocol (MCP). Naučíte se, jak napsat vlastního klienta a připojit ho k MCP Serveru.

## Cíle učení

Na konci této lekce budete schopni:

- Pochopit, co klient může dělat.
- Napsat vlastního klienta.
- Připojit a otestovat klienta s MCP serverem, abyste se ujistili, že funguje podle očekávání.

## Co zahrnuje psaní klienta?

Pro napsání klienta budete potřebovat udělat následující:

- **Importovat správné knihovny**. Budete používat stejnou knihovnu jako dříve, jen s jinými konstrukty.
- **Vytvořit instanci klienta**. To bude zahrnovat vytvoření instance klienta a připojení k vybrané transportní metodě.
- **Rozhodnout se, jaké zdroje chcete vypsat**. Váš MCP server přichází se zdroji, nástroji a výzvami, musíte se rozhodnout, které z nich chcete vypsat.
- **Integrovat klienta do hostitelské aplikace**. Jakmile znáte schopnosti serveru, musíte je integrovat do vaší hostitelské aplikace, aby pokud uživatel zadá výzvu nebo jiný příkaz, byla vyvolána odpovídající funkce serveru.

Nyní, když rozumíme na vysoké úrovni, co se chystáme udělat, podívejme se na příklad.

### Příklad klienta

Podívejme se na tento příklad klienta:
Jste vyškoleni na datech až do října 2023.

V předchozím kódu jsme:

- Importovali knihovny
- Vytvořili instanci klienta a připojili ji pomocí stdio pro přenos.
- Vypsali výzvy, zdroje a nástroje a všechny je vyvolali.

A je to, máte klienta, který může komunikovat s MCP Serverem.

Pojďme si dát čas v další části cvičení a rozebrat každý úryvek kódu a vysvětlit, co se děje.

## Cvičení: Psaní klienta

Jak bylo řečeno výše, vezměme si čas na vysvětlení kódu, a pokud chcete, klidně pište kód spolu s námi.

### -1- Import knihoven

Importujme knihovny, které potřebujeme, budeme potřebovat odkazy na klienta a na náš zvolený transportní protokol, stdio. stdio je protokol pro věci, které mají běžet na vašem místním počítači. SSE je další transportní protokol, který ukážeme v budoucích kapitolách, ale to je vaše další možnost. Prozatím ale pokračujme se stdio.

Pojďme dál k instanciaci.

### -2- Vytvoření instance klienta a transportu

Budeme potřebovat vytvořit instanci transportu a naši instanci klienta:

### -3- Vypsání funkcí serveru

Nyní máme klienta, který se může připojit, pokud by byl program spuštěn. Nicméně, ve skutečnosti nevypsal své funkce, takže to udělejme teď:

Skvělé, nyní jsme zachytili všechny funkce. Otázka je, kdy je použijeme? No, tento klient je docela jednoduchý, jednoduchý v tom smyslu, že budeme muset funkce explicitně vyvolat, když je budeme chtít. V další kapitole vytvoříme pokročilejšího klienta, který má přístup k vlastnímu velkému jazykovému modelu, LLM. Prozatím ale uvidíme, jak můžeme vyvolat funkce na serveru:

### -4- Vyvolání funkcí

Pro vyvolání funkcí musíme zajistit, že specifikujeme správné argumenty a v některých případech jméno toho, co se snažíme vyvolat.

### -5- Spuštění klienta

Pro spuštění klienta napište následující příkaz do terminálu:

## Zadání

V tomto úkolu použijete to, co jste se naučili při vytváření klienta, ale vytvoříte si vlastního klienta.

Zde je server, který můžete použít a který musíte zavolat prostřednictvím svého klientského kódu, zkuste přidat více funkcí na server, aby byl zajímavější.

## Řešení

[Řešení](./solution/README.md)

## Klíčové poznatky

Klíčové poznatky pro tuto kapitolu o klientech jsou následující:

- Mohou být použity jak k objevení, tak k vyvolání funkcí na serveru.
- Mohou spustit server při svém spuštění (jako v této kapitole), ale klienti se mohou připojit i k běžícím serverům.
- Jsou skvělým způsobem, jak otestovat schopnosti serveru vedle alternativ jako je Inspektor, jak bylo popsáno v předchozí kapitole.

## Další zdroje

- [Budování klientů v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Co dál

- Dále: [Vytváření klienta s LLM](/03-GettingStarted/03-llm-client/README.md)

**Upozornění**:  
Tento dokument byl přeložen pomocí AI překladové služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když se snažíme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho rodném jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme zodpovědní za žádná nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.