<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:28:12+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sk"
}
-->
# Vytvorenie klienta s LLM

Doteraz ste videli, ako vytvoriť server a klienta. Klient bol schopný explicitne volať server, aby zobrazil jeho nástroje, zdroje a výzvy. Avšak, to nie je veľmi praktický prístup. Vaši používatelia žijú v agentickej ére a očakávajú, že budú používať výzvy a komunikovať s LLM, aby to dosiahli. Pre vašich používateľov nezáleží na tom, či používate MCP alebo nie na uloženie vašich schopností, ale očakávajú, že budú používať prirodzený jazyk na interakciu. Takže ako to vyriešime? Riešenie spočíva v pridaní LLM do klienta.

## Prehľad

V tejto lekcii sa zameriame na pridanie LLM do vášho klienta a ukážeme, ako to poskytuje oveľa lepší zážitok pre vašich používateľov.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Vytvoriť klienta s LLM.
- Bezproblémovo komunikovať s MCP serverom pomocou LLM.
- Poskytnúť lepší zážitok pre koncového používateľa na strane klienta.

## Prístup

Skúsme pochopiť prístup, ktorý musíme zvoliť. Pridanie LLM znie jednoducho, ale ako to vlastne urobíme?

Takto bude klient komunikovať so serverom:

1. Nastaviť spojenie so serverom.

1. Zoznam schopností, výziev, zdrojov a nástrojov a uložiť ich schému.

1. Pridať LLM a odovzdať uložené schopnosti a ich schému vo formáte, ktorému LLM rozumie.

1. Spracovať používateľskú výzvu tým, že ju odovzdáme LLM spolu s nástrojmi uvedenými klientom.

Skvelé, teraz rozumieme, ako to môžeme urobiť na vysokej úrovni, skúsme to v nižšie uvedenom cvičení.

## Cvičenie: Vytvorenie klienta s LLM

V tomto cvičení sa naučíme pridať LLM do nášho klienta.

### -1- Pripojenie k serveru

Najprv vytvoríme nášho klienta:
Ste vyškolení na údaje do októbra 2023.

Skvelé, pre náš ďalší krok, poďme zoznam schopností na serveri.

### -2 Zoznam schopností servera

Teraz sa pripojíme k serveru a opýtame sa na jeho schopnosti:

### -3- Konverzia schopností servera na nástroje LLM

Ďalším krokom po zozname schopností servera je ich konverzia do formátu, ktorému LLM rozumie. Keď to urobíme, môžeme tieto schopnosti poskytnúť ako nástroje pre naše LLM.

Skvelé, nie sme pripravení spracovať žiadosti používateľov, takže sa na to pozrieme ďalej.

### -4- Spracovanie požiadavky používateľskej výzvy

V tejto časti kódu budeme spracovávať požiadavky používateľov.

Skvelé, zvládli ste to!

## Úloha

Vezmite kód z cvičenia a rozšírte server o ďalšie nástroje. Potom vytvorte klienta s LLM, ako v cvičení, a otestujte ho s rôznymi výzvami, aby ste sa uistili, že všetky nástroje servera sú dynamicky volané. Tento spôsob budovania klienta znamená, že koncový používateľ bude mať skvelý zážitok, pretože bude môcť používať výzvy namiesto presných príkazov klienta a bude nevedomý, že sa volá akýkoľvek MCP server.

## Riešenie

[Riešenie](/03-GettingStarted/03-llm-client/solution/README.md)

## Kľúčové poznatky

- Pridanie LLM do vášho klienta poskytuje lepší spôsob interakcie používateľov s MCP servermi.
- Musíte konvertovať odpoveď MCP servera na niečo, čomu LLM rozumie.

## Príklady

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Ďalšie zdroje

## Čo ďalej

- Ďalej: [Spotrebovanie servera pomocou Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou služby pre automatizovaný preklad [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.