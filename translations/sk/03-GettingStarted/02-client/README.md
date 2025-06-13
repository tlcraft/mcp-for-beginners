<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:52:15+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sk"
}
-->
V predchádzajúcom kóde sme:

- Naimportovali knižnice
- Vytvorili inštanciu klienta a pripojili ju pomocou stdio ako transportu.
- Vypísali výzvy, zdroje a nástroje a všetky ich vyvolali.

Takže máte klienta, ktorý dokáže komunikovať s MCP Serverom.

V nasledujúcej cvičnej časti si pokojne rozoberieme každý útržok kódu a vysvetlíme, čo sa deje.

## Cvičenie: Písanie klienta

Ako sme už povedali, poďme si na vysvetlenie kódu dať čas a samozrejme, kľudne si kód píšte spolu s nami.

### -1- Import knižníc

Naimportujeme knižnice, ktoré potrebujeme, budeme potrebovať odkazy na klienta a na zvolený transportný protokol, stdio. stdio je protokol určený pre veci, ktoré bežia na vašom lokálnom stroji. SSE je ďalší transportný protokol, ktorý ukážeme v budúcich kapitolách, ale to je vaša ďalšia možnosť. Na teraz však pokračujme so stdio.

### -2- Inštancia klienta a transportu

Budeme potrebovať vytvoriť inštanciu transportu a tiež nášho klienta:

### -3- Výpis funkcií servera

Teraz máme klienta, ktorý sa môže pripojiť, ak sa program spustí. Avšak, zatiaľ nevypisuje jeho funkcie, takže to spravme teraz:

Výborne, teraz sme zachytili všetky funkcie. Otázka znie, kedy ich použijeme? Tento klient je dosť jednoduchý, jednoduchý v tom zmysle, že funkcie musíme explicitne volať, keď ich chceme použiť. V ďalšej kapitole vytvoríme pokročilejšieho klienta, ktorý bude mať prístup k vlastnému veľkému jazykovému modelu, LLM. Na teraz si však ukážeme, ako môžeme funkcie na serveri vyvolať:

### -4- Vyvolanie funkcií

Na vyvolanie funkcií musíme zabezpečiť, že špecifikujeme správne argumenty a v niektorých prípadoch aj názov toho, čo sa snažíme vyvolať.

### -5- Spustenie klienta

Na spustenie klienta zadajte v termináli nasledujúci príkaz:

## Zadanie

V tomto zadaní využijete to, čo ste sa naučili o tvorbe klienta, ale vytvoríte si vlastného klienta.

Tu je server, ktorý môžete použiť a ku ktorému sa musíte pripojiť cez váš klientsky kód, skúste pridať viac funkcií na server, aby bol zaujímavejší.

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové poznatky

Kľúčové poznatky z tejto kapitoly o klientoch sú:

- Môžu sa použiť na objavovanie aj vyvolávanie funkcií na serveri.
- Môžu spustiť server zároveň so sebou (ako v tejto kapitole), ale klienti sa môžu pripojiť aj k bežiacim serverom.
- Sú skvelým spôsobom, ako otestovať schopnosti servera vedľa alternatív ako Inspector, ktorý bol popísaný v predchádzajúcej kapitole.

## Dodatočné zdroje

- [Tvorba klientov v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukážky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Čo ďalej

- Ďalej: [Tvorba klienta s LLM](/03-GettingStarted/03-llm-client/README.md)

**Vyhlásenie o vylúčení zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, vezmite prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.