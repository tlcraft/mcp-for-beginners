<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:20:26+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sk"
}
-->
V predchádzajúcom kóde sme:

- Importovali knižnice
- Vytvorili inštanciu klienta a pripojili ju pomocou stdio ako transportu.
- Vypísali prompt, zdroje a nástroje a všetky ich vyvolali.

Máte tu teda klienta, ktorý dokáže komunikovať s MCP Serverom.

V ďalšej časti cvičenia si na to dáme čas a rozoberieme každý útržok kódu a vysvetlíme, čo sa deje.

## Cvičenie: Písanie klienta

Ako bolo povedané vyššie, venujme čas vysvetleniu kódu a pokojne kódujte spolu, ak chcete.

### -1- Import knižníc

Importujme knižnice, ktoré potrebujeme, budeme potrebovať referencie na klienta a na náš zvolený transportný protokol, stdio. stdio je protokol určený pre veci, ktoré majú bežať na vašom lokálnom počítači. SSE je ďalší transportný protokol, ktorý ukážeme v budúcich kapitolách, ale to je vaša ďalšia možnosť. Pre teraz však pokračujme so stdio.

Poďme na inštanciu.

### -2- Inštancovanie klienta a transportu

Budeme potrebovať vytvoriť inštanciu transportu a tiež nášho klienta:

### -3- Výpis funkcií servera

Teraz máme klienta, ktorý sa môže pripojiť, ak sa program spustí. Avšak, zatiaľ nevypisuje jeho funkcie, tak to spravme teraz:

Skvelé, teraz sme zachytili všetky funkcie. Otázka znie, kedy ich použijeme? Tento klient je dosť jednoduchý, jednoduchý v tom zmysle, že budeme musieť explicitne volať funkcie, keď ich chceme použiť. V ďalšej kapitole vytvoríme pokročilejšieho klienta, ktorý bude mať prístup k vlastnému veľkému jazykovému modelu, LLM. Pre teraz však uvidíme, ako môžeme vyvolať funkcie na serveri:

### -4- Vyvolanie funkcií

Na vyvolanie funkcií musíme zabezpečiť, že zadáme správne argumenty a v niektorých prípadoch aj názov toho, čo sa snažíme vyvolať.

### -5- Spustenie klienta

Na spustenie klienta zadajte nasledujúci príkaz v termináli:

## Zadanie

V tomto zadaní použijete to, čo ste sa naučili o vytváraní klienta, ale vytvoríte si vlastného klienta.

Tu je server, ktorý môžete použiť a ktorý musíte volať cez svoj klientsky kód, skúste pridať viac funkcií na server, aby bol zaujímavejší.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Kľúčové poznatky z tejto kapitoly o klientoch sú:

- Môžu sa použiť na objavovanie aj vyvolávanie funkcií na serveri.
- Môžu spustiť server, zatiaľ čo sa sami spúšťajú (ako v tejto kapitole), ale klienti sa môžu pripojiť aj k už bežiacim serverom.
- Sú skvelým spôsobom, ako otestovať schopnosti servera vedľa alternatív ako Inspector, ako bolo popísané v predchádzajúcej kapitole.

## Dodatočné zdroje

- [Budovanie klientov v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukážky

- [Java kalkulačka](../samples/java/calculator/README.md)
- [.Net kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulačka](../samples/javascript/README.md)
- [TypeScript kalkulačka](../samples/typescript/README.md)
- [Python kalkulačka](../../../../03-GettingStarted/samples/python)

## Čo ďalej

- Ďalej: [Vytvorenie klienta s LLM](../03-llm-client/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.