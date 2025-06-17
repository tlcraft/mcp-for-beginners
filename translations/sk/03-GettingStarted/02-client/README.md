<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T16:10:20+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sk"
}
-->
V predchádzajúcom kóde sme:

- Importovali knižnice
- Vytvorili inštanciu klienta a pripojili ju pomocou stdio ako transportu.
- Zobrazili promptovacie príkazy, zdroje a nástroje a všetky ich vyvolali.

Máte teda klienta, ktorý dokáže komunikovať s MCP serverom.

V ďalšej časti cvičenia si na čas rozoberieme každý kódový úryvok a vysvetlíme, čo sa deje.

## Cvičenie: Písanie klienta

Ako sme už povedali, vezmime si čas na vysvetlenie kódu a pokojne aj kódujte spolu s nami, ak chcete.

### -1- Import knižníc

Importujme knižnice, ktoré potrebujeme, budeme potrebovať referencie na klienta a na náš vybraný transportný protokol, stdio. stdio je protokol určený na spúšťanie na vašom lokálnom počítači. SSE je ďalší transportný protokol, ktorý ukážeme v budúcich kapitolách, ale to je vaša ďalšia možnosť. Pre teraz však pokračujme so stdio.

---

Poďme na inštancovanie.

### -2- Inštancovanie klienta a transportu

Budeme potrebovať vytvoriť inštanciu transportu a inštanciu nášho klienta:

---

### -3- Výpis funkcií servera

Teraz máme klienta, ktorý sa môže pripojiť, keď sa program spustí. Avšak, zatiaľ nevypisuje jeho funkcie, poďme to teda urobiť teraz:

---

Skvelé, teraz sme zachytili všetky funkcie. Otázka znie, kedy ich použijeme? Tento klient je dosť jednoduchý, jednoduchý v tom zmysle, že funkcie budeme musieť explicitne volať, keď ich budeme chcieť použiť. V ďalšej kapitole vytvoríme pokročilejšieho klienta, ktorý bude mať prístup k vlastnému veľkému jazykovému modelu (LLM). Pre teraz si však ukážeme, ako môžeme vyvolať funkcie na serveri:

### -4- Vyvolanie funkcií

Na vyvolanie funkcií musíme zabezpečiť správne zadanie argumentov a v niektorých prípadoch aj názvu toho, čo sa snažíme vyvolať.

---

### -5- Spustenie klienta

Na spustenie klienta zadajte v termináli nasledujúci príkaz:

---

## Zadanie

V tomto zadaní použijete to, čo ste sa naučili o tvorbe klienta, ale vytvoríte si vlastného klienta.

Tu je server, ktorý môžete použiť a ku ktorému sa musíte pripojiť cez váš klientsky kód. Skúste pridať ďalšie funkcie na server, aby bol zaujímavejší.

---

## Riešenie

[Riešenie](./solution/README.md)

## Kľúčové body

Kľúčové body tejto kapitoly o klientoch sú:

- Môžu sa použiť na objavovanie a vyvolávanie funkcií na serveri.
- Môžu spustiť server pri svojom štarte (ako v tejto kapitole), ale klienti sa môžu pripojiť aj k už bežiacim serverom.
- Sú skvelým spôsobom, ako otestovať schopnosti servera, vedľa alternatív ako Inspector, ktorý bol popísaný v predchádzajúcej kapitole.

## Dodatočné zdroje

- [Tvorba klientov v MCP](https://modelcontextprotocol.io/quickstart/client)

## Ukážky

- [Java kalkulačka](../samples/java/calculator/README.md)
- [.Net kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulačka](../samples/javascript/README.md)
- [TypeScript kalkulačka](../samples/typescript/README.md)
- [Python kalkulačka](../../../../03-GettingStarted/samples/python)

## Čo nasleduje

- Ďalej: [Vytvorenie klienta s LLM](/03-GettingStarted/03-llm-client/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Hoci sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za žiadne nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.