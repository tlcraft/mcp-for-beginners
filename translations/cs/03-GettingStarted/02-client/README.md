<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:20:04+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "cs"
}
-->
V předchozím kódu jsme:

- Importovali knihovny
- Vytvořili instanci klienta a připojili ji pomocí stdio jako transportu.
- Vypsali prompty, zdroje a nástroje a všechny je vyvolali.

Máte tedy klienta, který může komunikovat s MCP Serverem.

V další cvičné části si kód podrobně rozebere a vysvětlíme, co se děje.

## Cvičení: Psání klienta

Jak bylo řečeno výše, pojďme si kód podrobně vysvětlit a klidně si ho i sami napište.

### -1- Import knihoven

Naimportujme knihovny, které potřebujeme, budeme potřebovat reference na klienta a na náš zvolený transportní protokol, stdio. stdio je protokol určený pro věci, které běží na vašem lokálním počítači. SSE je další transportní protokol, který ukážeme v budoucích kapitolách, ale to je vaše další možnost. Prozatím však pokračujme se stdio.

Přejděme k instanciaci.

### -2- Instanciace klienta a transportu

Budeme potřebovat vytvořit instanci transportu a také naši instanci klienta:

### -3- Výpis funkcí serveru

Nyní máme klienta, který se může připojit, pokud se program spustí. Nicméně zatím nevypisuje jeho funkce, pojďme to tedy udělat:

Skvěle, nyní jsme zachytili všechny funkce. Otázka zní, kdy je použijeme? Tento klient je poměrně jednoduchý, v tom smyslu, že funkce budeme muset explicitně volat, když je chceme použít. V další kapitole vytvoříme pokročilejšího klienta, který bude mít přístup ke svému vlastnímu velkému jazykovému modelu (LLM). Prozatím si ale ukážeme, jak můžeme funkce na serveru vyvolat:

### -4- Vyvolání funkcí

Pro vyvolání funkcí musíme zajistit, že zadáme správné argumenty a v některých případech i název toho, co se snažíme vyvolat.

### -5- Spuštění klienta

Pro spuštění klienta zadejte v terminálu následující příkaz:

## Zadání

V tomto úkolu použijete to, co jste se naučili o vytváření klienta, ale vytvoříte si vlastního klienta.

Zde je server, který můžete použít a ke kterému se musíte připojit přes svůj klientský kód. Zkuste přidat na server více funkcí, aby byl zajímavější.

## Řešení

[Řešení](./solution/README.md)

## Hlavní poznatky

Hlavní poznatky z této kapitoly o klientech jsou:

- Lze je použít jak k objevování, tak k vyvolávání funkcí na serveru.
- Mohou spustit server současně s tím, jak se sami spouštějí (jako v této kapitole), ale klienti se mohou také připojit k již běžícím serverům.
- Jsou skvělým způsobem, jak otestovat schopnosti serveru vedle alternativ jako je Inspector, jak bylo popsáno v předchozí kapitole.

## Další zdroje

- [Vytváření klientů v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Co dál

- Dále: [Vytváření klienta s LLM](../03-llm-client/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.