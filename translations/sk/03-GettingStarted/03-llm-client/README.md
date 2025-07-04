<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-04T18:45:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sk"
}
-->
Skvelé, pre náš ďalší krok si vypíšme schopnosti na serveri.

### -2 Vypísať schopnosti servera

Teraz sa pripojíme k serveru a požiadame o jeho schopnosti:

### -3- Konvertovať schopnosti servera na nástroje LLM

Ďalším krokom po vypísaní schopností servera je ich prevod do formátu, ktorému LLM rozumie. Keď to urobíme, môžeme tieto schopnosti poskytnúť ako nástroje nášmu LLM.

Skvelé, teraz sme pripravení spracovať požiadavky používateľa, poďme na to.

### -4- Spracovať požiadavku používateľa

V tejto časti kódu budeme spracovávať požiadavky používateľa.

Skvelé, podarilo sa ti to!

## Zadanie

Použi kód z cvičenia a rozšír server o ďalšie nástroje. Potom vytvor klienta s LLM, ako v cvičení, a otestuj ho s rôznymi promptami, aby si sa uistil, že všetky nástroje servera sa volajú dynamicky. Tento spôsob vytvárania klienta znamená, že koncový používateľ bude mať skvelý používateľský zážitok, pretože môže používať prompty namiesto presných príkazov klienta a nebude si musieť všímať, že sa volá MCP server.

## Riešenie

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Kľúčové poznatky

- Pridanie LLM do klienta poskytuje lepší spôsob, ako môžu používatelia komunikovať s MCP servermi.
- Je potrebné previesť odpoveď MCP servera do formátu, ktorému LLM rozumie.

## Ukážky

- [Java kalkulačka](../samples/java/calculator/README.md)
- [.Net kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulačka](../samples/javascript/README.md)
- [TypeScript kalkulačka](../samples/typescript/README.md)
- [Python kalkulačka](../../../../03-GettingStarted/samples/python)

## Ďalšie zdroje

## Čo bude ďalej

- Ďalej: [Používanie servera vo Visual Studio Code](../04-vscode/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.