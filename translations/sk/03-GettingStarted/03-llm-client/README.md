<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:35:59+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sk"
}
-->
Skvelé, v ďalšom kroku si vylistujeme schopnosti na serveri.

### -2 Zoznam schopností servera

Teraz sa pripojíme k serveru a vyžiadať jeho schopnosti:

### -3- Konvertovanie schopností servera na nástroje pre LLM

Ďalším krokom po vylistovaní schopností servera je ich prevod do formátu, ktorý LLM rozumie. Keď to urobíme, môžeme tieto schopnosti poskytnúť ako nástroje nášmu LLM.

Skvelé, teraz sme pripravení spracovávať požiadavky používateľa, tak sa do toho pustíme.

### -4- Spracovanie požiadavky používateľa

V tejto časti kódu budeme spracovávať požiadavky používateľa.

Skvelé, podarilo sa ti to!

## Zadanie

Použi kód z cvičenia a rozšír server o ďalšie nástroje. Potom vytvor klienta s LLM, ako v cvičení, a otestuj ho s rôznymi promptmi, aby si sa uistil, že všetky nástroje na serveri sa volajú dynamicky. Tento spôsob tvorby klienta znamená, že koncový používateľ bude mať skvelý zážitok, pretože môže používať prompty namiesto presných príkazov klienta a nebude si musieť všímať, že sa volá MCP server.

## Riešenie

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Kľúčové poznatky

- Pridanie LLM do klienta poskytuje lepší spôsob, ako môžu používatelia komunikovať s MCP servermi.
- Je potrebné previesť odpoveď MCP servera do formátu, ktorému LLM rozumie.

## Ukážky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

## Čo ďalej

- Ďalej: [Použitie servera vo Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Zrieknutie sa zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.