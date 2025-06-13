<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:51:51+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "cs"
}
-->
V předchozím kódu jsme:

- Importovali knihovny
- Vytvořili instanci klienta a připojili ji pomocí stdio jako transportu.
- Vypsali výzvy, zdroje a nástroje a všechny je vyvolali.

A máte to, klient, který dokáže komunikovat s MCP Serverem.

V další cvičné části si dáme čas a rozebereme každý kódový úryvek a vysvětlíme, co se děje.

## Cvičení: Psání klienta

Jak už bylo řečeno, pojďme si kód podrobně vysvětlit a klidně kódujte s námi.

### -1- Import knihoven

Naimportujeme knihovny, které potřebujeme, budeme potřebovat odkazy na klienta a na náš zvolený transportní protokol, stdio. stdio je protokol pro věci, které mají běžet na vašem lokálním počítači. SSE je další transportní protokol, který ukážeme v budoucích kapitolách, ale to je vaše další možnost. Prozatím ale pokračujeme se stdio.

Přejděme k instanciaci.

### -2- Instanciace klienta a transportu

Budeme potřebovat vytvořit instanci transportu a také instanci našeho klienta:

### -3- Výpis funkcí serveru

Teď máme klienta, který se může připojit, pokud se program spustí. Nicméně zatím nevypisuje své funkce, tak to udělejme:

Výborně, teď jsme zachytili všechny funkce. Otázka je, kdy je použijeme? Tento klient je docela jednoduchý, jednoduchý v tom smyslu, že funkce musíme explicitně volat, když je chceme použít. V další kapitole vytvoříme pokročilejšího klienta, který bude mít přístup ke svému vlastnímu velkému jazykovému modelu (LLM). Prozatím si ale ukážeme, jak můžeme funkce na serveru vyvolat:

### -4- Vyvolání funkcí

K vyvolání funkcí musíme zajistit, že zadáme správné argumenty a v některých případech i název toho, co chceme vyvolat.

### -5- Spuštění klienta

Pro spuštění klienta napište v terminálu následující příkaz:

## Zadání

V tomto zadání použijete to, co jste se naučili při vytváření klienta, a vytvoříte si vlastního klienta.

Zde je server, který můžete použít a ke kterému se musíte připojit pomocí svého klientského kódu. Zkuste přidat více funkcí na server, aby byl zajímavější.

## Řešení

[Řešení](./solution/README.md)

## Hlavní poznatky

Hlavní poznatky této kapitoly o klientech jsou:

- Lze je použít jak k objevování, tak k vyvolávání funkcí na serveru.
- Mohou spustit server současně se svým startem (jako v této kapitole), ale klienti se mohou také připojovat k již běžícím serverům.
- Jsou skvělým způsobem, jak otestovat schopnosti serveru vedle alternativ jako Inspector, jak bylo popsáno v předchozí kapitole.

## Další zdroje

- [Vytváření klientů v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukázky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Co dál

- Další: [Vytváření klienta s LLM](/03-GettingStarted/03-llm-client/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo nesprávné výklady vyplývající z použití tohoto překladu.