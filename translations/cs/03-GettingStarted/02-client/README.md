<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-27T16:23:53+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "cs"
}
-->
V předchozím kódu jsme:

- Importovali knihovny
- Vytvořili instanci klienta a připojili ji pomocí stdio jako transportu.
- Vypsali prompty, zdroje a nástroje a všechny je vyvolali.

A je to, klient, který umí komunikovat s MCP Serverem.

V další cvičné části si kód podrobně rozebere a vysvětlíme, co se děje.

## Cvičení: Psání klienta

Jak už bylo řečeno, pojďme si kód podrobně vysvětlit, a klidně si při tom i kódujte.

### -1- Import knihoven

Naimportujeme potřebné knihovny, budeme potřebovat odkazy na klienta a na zvolený transportní protokol, stdio. stdio je protokol určený pro aplikace běžící na lokálním počítači. SSE je další transportní protokol, který ukážeme v budoucích kapitolách, ale to je vaše další možnost. Prozatím pokračujme se stdio.

### -2- Vytvoření instance klienta a transportu

Budeme potřebovat vytvořit instanci transportu a instanci klienta:

### -3- Výpis funkcí serveru

Teď máme klienta, který se připojí, pokud se program spustí. Ale zatím nevypisuje funkce, které server nabízí, takže to uděláme teď:

Výborně, teď máme všechny funkce zachycené. Otázka zní, kdy je použít? Tento klient je celkem jednoduchý, v tom smyslu, že funkce musíme explicitně volat, když je chceme použít. V další kapitole vytvoříme pokročilejšího klienta, který bude mít přístup ke svému vlastnímu velkému jazykovému modelu (LLM). Prozatím si ale ukážeme, jak funkce na serveru vyvolat:

### -4- Vyvolání funkcí

Pro vyvolání funkcí musíme zajistit správné předání argumentů a v některých případech i jména toho, co chceme vyvolat.

### -5- Spuštění klienta

Pro spuštění klienta napište v terminálu následující příkaz:

## Zadání

V tomto zadání použijete to, co jste se naučili o vytváření klienta, ale vytvoříte si vlastního klienta.

Tady máte server, ke kterému se budete připojovat přes svůj klientský kód, zkuste přidat více funkcí na server, aby byl zajímavější.

## Řešení

[Řešení](./solution/README.md)

## Klíčové poznatky

Klíčové poznatky této kapitoly o klientech jsou:

- Lze je použít jak k objevování, tak k vyvolávání funkcí na serveru.
- Mohou spustit server, zatímco se sami spouští (jako v této kapitole), ale klienti se mohou také připojovat k již běžícím serverům.
- Jsou skvělým způsobem, jak otestovat schopnosti serveru vedle alternativ jako je Inspector, jak bylo popsáno v předchozí kapitole.

## Další zdroje

- [Vytváření klientů v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukázky

- [Java kalkulačka](../samples/java/calculator/README.md)
- [.Net kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulačka](../samples/javascript/README.md)
- [TypeScript kalkulačka](../samples/typescript/README.md)
- [Python kalkulačka](../../../../03-GettingStarted/samples/python)

## Co bude dál

- Dále: [Vytvoření klienta s LLM](/03-GettingStarted/03-llm-client/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Originální dokument v jeho původním jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje využít profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vyplývající z použití tohoto překladu.