<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:44:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sk"
}
-->
Skvelé, pre náš ďalší krok si vypíšme schopnosti na serveri.

### -2 Výpis schopností servera

Teraz sa pripojíme k serveru a požiadame o jeho schopnosti:

### -3 Prevod schopností servera na nástroje LLM

Ďalším krokom po výpise schopností servera je ich konverzia do formátu, ktorému rozumie LLM. Keď to urobíme, môžeme tieto schopnosti poskytnúť ako nástroje nášmu LLM.

Skvelé, sme pripravení spracovať požiadavky používateľa, tak sa do toho pustíme.

### -4 Spracovanie požiadavky používateľa

V tejto časti kódu budeme spracovávať požiadavky používateľa.

Výborne, zvládli ste to!

## Zadanie

Použite kód z cvičenia a rozšírte server o ďalšie nástroje. Potom vytvorte klienta s LLM, ako v cvičení, a otestujte ho s rôznymi promptmi, aby ste sa uistili, že všetky nástroje servera sa dynamicky volajú. Tento spôsob tvorby klienta znamená, že koncový používateľ bude mať skvelý zážitok, pretože môže používať prompt a nemusí poznať presné príkazy klienta ani vedieť o MCP serveri, ktorý sa volá.

## Riešenie

[Riešenie](/03-GettingStarted/03-llm-client/solution/README.md)

## Kľúčové poznatky

- Pridanie LLM do vášho klienta poskytuje lepší spôsob, ako môžu používatelia komunikovať s MCP servermi.
- Musíte previesť odpoveď MCP servera do formátu, ktorému rozumie LLM.

## Ukážky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

## Čo ďalej

- Ďalej: [Používanie servera vo Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.