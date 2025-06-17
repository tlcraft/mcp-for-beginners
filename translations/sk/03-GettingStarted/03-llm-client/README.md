<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:52:42+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sk"
}
-->
Skvelé, pre náš ďalší krok si zobrazme schopnosti na serveri.

### -2 Zobraziť schopnosti servera

Teraz sa pripojíme k serveru a požiadame o jeho schopnosti:

### -3- Konvertovať schopnosti servera na nástroje LLM

Ďalším krokom po zobrazení schopností servera je ich konverzia do formátu, ktorému LLM rozumie. Keď to urobíme, môžeme tieto schopnosti poskytnúť ako nástroje nášmu LLM.

Skvelé, sme pripravení spracovať požiadavky používateľa, tak sa do toho pustíme.

### -4- Spracovať požiadavku používateľa

V tejto časti kódu budeme spracovávať požiadavky používateľa.

Skvelé, podarilo sa vám to!

## Zadanie

Použite kód z cvičenia a rozšírte server o ďalšie nástroje. Potom vytvorte klienta s LLM, ako v cvičení, a otestujte ho s rôznymi promptami, aby ste sa uistili, že všetky nástroje servera sa dynamicky volajú. Tento spôsob tvorby klienta zabezpečí, že koncový používateľ bude mať skvelý používateľský zážitok, pretože bude môcť používať prompty namiesto presných príkazov klienta a nebude si musieť všímať volanie MCP servera.

## Riešenie

[Riešenie](/03-GettingStarted/03-llm-client/solution/README.md)

## Kľúčové poznatky

- Pridanie LLM do vášho klienta poskytuje lepší spôsob, ako môžu používatelia komunikovať s MCP servermi.
- Musíte konvertovať odpoveď MCP servera do formátu, ktorému LLM rozumie.

## Ukážky

- [Java kalkulačka](../samples/java/calculator/README.md)
- [.Net kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulačka](../samples/javascript/README.md)
- [TypeScript kalkulačka](../samples/typescript/README.md)
- [Python kalkulačka](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

## Čo bude ďalej

- Ďalej: [Použitie servera vo Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.