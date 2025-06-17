<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T16:08:44+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "cs"
}
-->
Ve výše uvedeném kódu jsme:

- Importovali knihovny
- Vytvořili instanci klienta a připojili ji pomocí stdio jako transportu.
- Vypsali prompty, zdroje a nástroje a všechny je vyvolali.

Máte tedy klienta, který dokáže komunikovat s MCP serverem.

V další cvičné části si kód podrobně rozebereme a vysvětlíme, co se děje.

## Cvičení: Psání klienta

Jak bylo řečeno výše, pojďme si na vysvětlení kódu dát čas, a klidně kódujte spolu s námi, pokud chcete.

### -1- Import knihoven

Naimportujme knihovny, které potřebujeme, budeme potřebovat reference na klienta a na zvolený transportní protokol, stdio. stdio je protokol určený pro věci, které mají běžet na vašem lokálním počítači. SSE je další transportní protokol, který ukážeme v budoucích kapitolách, ale to je vaše další možnost. Prozatím však pokračujme se stdio.

Přejděme k instanciaci.

### -2- Instanciace klienta a transportu

Budeme potřebovat vytvořit instanci transportu a také naši instanci klienta:

### -3- Výpis funkcí serveru

Nyní máme klienta, který se může připojit, pokud se program spustí. Nicméně zatím nevypisuje jeho funkce, pojďme to tedy udělat:

Skvělé, teď jsme zachytili všechny funkce. Otázka zní, kdy je použít? Tento klient je docela jednoduchý, jednoduchý v tom smyslu, že funkce musíme explicitně vyvolat, když je chceme použít. V další kapitole vytvoříme pokročilejšího klienta, který bude mít přístup ke svému vlastnímu velkému jazykovému modelu (LLM). Prozatím si ale ukažme, jak funkce na serveru vyvolat:

### -4- Vyvolání funkcí

Pro vyvolání funkcí musíme zajistit správné zadání argumentů a v některých případech i názvu toho, co se snažíme spustit.

### -5- Spuštění klienta

Pro spuštění klienta zadejte v terminálu následující příkaz:

## Zadání

V tomto zadání využijete to, co jste se naučili o tvorbě klienta, a vytvoříte si vlastního klienta.

Zde je server, který můžete použít a který musíte volat přes svůj klientský kód. Zkuste přidat na server více funkcí, aby byl zajímavější.

## Řešení

[Řešení](./solution/README.md)

## Hlavní poznatky

Hlavní poznatky této kapitoly o klientech jsou následující:

- Klienti lze použít jak k objevování, tak k vyvolávání funkcí na serveru.
- Klient může spustit server zároveň se svým spuštěním (jako v této kapitole), ale klienti se mohou připojit i k již běžícím serverům.
- Je to skvělý způsob, jak otestovat schopnosti serveru vedle alternativ, jako je Inspector, jak bylo popsáno v předchozí kapitole.

## Další zdroje

- [Tvorba klientů v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Co bude dál

- Další: [Vytvoření klienta s LLM](/03-GettingStarted/03-llm-client/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro zásadní informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vzniklé použitím tohoto překladu.