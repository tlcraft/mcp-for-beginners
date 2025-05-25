<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:48:18+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sk"
}
-->
# Vytvorenie klienta

Klienti sú vlastné aplikácie alebo skripty, ktoré komunikujú priamo s MCP Serverom, aby požiadali o zdroje, nástroje a výzvy. Na rozdiel od používania nástroja inspector, ktorý poskytuje grafické rozhranie na interakciu so serverom, písanie vlastného klienta umožňuje programové a automatizované interakcie. To umožňuje vývojárom integrovať schopnosti MCP do ich vlastných pracovných postupov, automatizovať úlohy a vytvárať vlastné riešenia prispôsobené špecifickým potrebám.

## Prehľad

Táto lekcia predstavuje koncept klientov v rámci ekosystému Model Context Protocol (MCP). Naučíte sa, ako napísať vlastného klienta a pripojiť ho k MCP Serveru.

## Ciele učenia

Na konci tejto lekcie budete schopní:

- Pochopiť, čo klient môže robiť.
- Napísať vlastného klienta.
- Pripojiť a otestovať klienta s MCP serverom, aby ste sa uistili, že funguje podľa očakávania.

## Čo je potrebné na napísanie klienta?

Na napísanie klienta budete musieť urobiť nasledovné:

- **Importovať správne knižnice**. Budete používať tú istú knižnicu ako predtým, len s inými konštruktmi.
- **Vytvoriť inštanciu klienta**. To bude zahŕňať vytvorenie inštancie klienta a pripojenie ho k zvolenému transportnému spôsobu.
- **Rozhodnúť sa, ktoré zdroje zoznamovať**. Váš MCP server obsahuje zdroje, nástroje a výzvy, musíte sa rozhodnúť, ktoré z nich zoznamovať.
- **Integrovať klienta do hostiteľskej aplikácie**. Keď poznáte schopnosti servera, musíte ho integrovať do vašej hostiteľskej aplikácie tak, aby keď používateľ zadá výzvu alebo iný príkaz, bola vyvolaná príslušná funkcia servera.

Teraz, keď rozumieme na vysokej úrovni, čo sa chystáme urobiť, pozrime sa na príklad.

### Príklad klienta

Pozrime sa na tento príklad klienta:
Ste vytrénovaní na dátach do októbra 2023.

V predchádzajúcom kóde sme:

- Importovali knižnice
- Vytvorili inštanciu klienta a pripojili ho pomocou stdio na transport.
- Zoznamovali výzvy, zdroje a nástroje a vyvolali ich všetky.

A je to, máte klienta, ktorý dokáže komunikovať s MCP Serverom.

V ďalšej sekcii cvičenia si dáme čas a rozoberieme každý kódový úryvok a vysvetlíme, čo sa deje.

## Cvičenie: Písanie klienta

Ako sme už povedali, dáme si čas na vysvetlenie kódu a určite kódujte spolu, ak chcete.

### -1- Importovanie knižníc

Importujme knižnice, ktoré potrebujeme, budeme potrebovať odkazy na klienta a na zvolený transportný protokol, stdio. stdio je protokol pre veci určené na beh na vašom lokálnom počítači. SSE je ďalší transportný protokol, ktorý ukážeme v budúcich kapitolách, ale to je vaša ďalšia možnosť. Zatiaľ však pokračujme so stdio.

Prejdime na vytváranie inštancií.

### -2- Vytváranie inštancií klienta a transportu

Budeme potrebovať vytvoriť inštanciu transportu a našu klientskú inštanciu:

### -3- Zoznamovanie funkcií servera

Teraz máme klienta, ktorý sa môže pripojiť, ak sa program spustí. Avšak, zatiaľ nezobrazuje svoje funkcie, takže to urobme teraz:

Výborne, teraz sme zachytili všetky funkcie. Teraz je otázka, kedy ich použijeme? Tento klient je dosť jednoduchý, jednoduchý v tom zmysle, že budeme musieť explicitne vyvolať funkcie, keď ich chceme. V ďalšej kapitole vytvoríme pokročilejšieho klienta, ktorý bude mať prístup k vlastnému veľkému jazykovému modelu, LLM. Zatiaľ však, pozrime sa, ako môžeme vyvolať funkcie na serveri:

### -4- Vyvolanie funkcií

Na vyvolanie funkcií musíme zabezpečiť, že zadáme správne argumenty a v niektorých prípadoch názov toho, čo sa snažíme vyvolať.

### -5- Spustenie klienta

Na spustenie klienta zadajte nasledujúci príkaz do terminálu:

## Úloha

V tejto úlohe použijete, čo ste sa naučili pri vytváraní klienta, ale vytvoríte si vlastného klienta.

Tu je server, ktorý môžete použiť, ktorý potrebujete zavolať prostredníctvom vášho klientského kódu, skúste pridať viac funkcií na server, aby bol zaujímavejší.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Kľúčové poznatky z tejto kapitoly o klientoch sú:

- Môžu byť použité na objavovanie a vyvolávanie funkcií na serveri.
- Môžu spustiť server, zatiaľ čo sa sami spúšťajú (ako v tejto kapitole), ale klienti sa môžu pripojiť aj k bežiacim serverom.
- Sú skvelým spôsobom, ako otestovať schopnosti servera vedľa alternatív ako Inspector, ako bolo popísané v predchádzajúcej kapitole.

## Ďalšie zdroje

- [Vytváranie klientov v MCP](https://modelcontextprotocol.io/quickstart/client)

## Príklady

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Čo bude ďalej

- Ďalej: [Vytvorenie klienta s LLM](/03-GettingStarted/03-llm-client/README.md)

**Upozornenie**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, vezmite prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.