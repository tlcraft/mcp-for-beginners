<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-13T20:01:10+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sk"
}
-->
Teraz, keď už vieme trochu viac o SSE, poďme si vytvoriť SSE server.

## Cvičenie: Vytvorenie SSE servera

Pri vytváraní nášho servera musíme mať na pamäti dve veci:

- Potrebujeme použiť webový server na sprístupnenie endpointov pre pripojenie a správy.
- Server postavíme tak, ako sme zvyknutí s nástrojmi, zdrojmi a promptmi, keď sme používali stdio.

### -1- Vytvorenie inštancie servera

Na vytvorenie servera používame rovnaké typy ako pri stdio. Avšak pre transport musíme zvoliť SSE.

### -2- Pridanie rout

Pridajme routy, ktoré budú spracovávať pripojenie a prichádzajúce správy:

### -3- Pridanie schopností servera

Keď už máme definované všetko špecifické pre SSE, pridajme schopnosti servera ako nástroje, prompt a zdroje.

Celý váš kód by mal vyzerať takto:

Skvelé, máme server používajúci SSE, poďme ho teraz otestovať.

## Cvičenie: Ladenie SSE servera pomocou Inspector

Inspector je skvelý nástroj, ktorý sme videli v predchádzajúcej lekcii [Vytvorenie vášho prvého servera](/03-GettingStarted/01-first-server/README.md). Pozrime sa, či ho môžeme použiť aj tu:

### -1- Spustenie inspektora

Na spustenie inspektora musíte mať najprv bežiaci SSE server, tak ho spustime:

1. Spustite server

1. Spustite inspektora

    > ![NOTE]
    > Spustite to v samostatnom terminálovom okne, než v ktorom beží server. Tiež si všimnite, že musíte upraviť nižšie uvedený príkaz tak, aby zodpovedal URL, kde váš server beží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Spustenie inspektora vyzerá rovnako vo všetkých runtime prostrediach. Všimnite si, že namiesto zadania cesty k serveru a príkazu na jeho spustenie zadávame URL, kde server beží, a tiež špecifikujeme routu `/sse`.

### -2- Vyskúšanie nástroja

Pripojte sa k serveru výberom SSE v rozbaľovacom zozname a vyplňte pole URL, kde váš server beží, napríklad http://localhost:4321/sse. Potom kliknite na tlačidlo "Connect". Ako predtým, vyberte možnosť zobraziť nástroje, vyberte nástroj a zadajte vstupné hodnoty. Mali by ste vidieť výsledok ako na obrázku nižšie:

![SSE Server bežiaci v inspektore](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sk.png)

Skvelé, dokážete pracovať s inspektorom, poďme sa pozrieť, ako pracovať s Visual Studio Code.

## Zadanie

Skúste rozšíriť svoj server o ďalšie schopnosti. Pozrite si [túto stránku](https://api.chucknorris.io/), kde môžete napríklad pridať nástroj, ktorý volá API. Vy rozhodnete, ako má server vyzerať. Prajeme veľa zábavy :)

## Riešenie

[Riešenie](./solution/README.md) Tu je možné riešenie s funkčným kódom.

## Kľúčové poznatky

Hlavné poznatky z tejto kapitoly sú:

- SSE je druhý podporovaný transport vedľa stdio.
- Na podporu SSE musíte spravovať prichádzajúce pripojenia a správy pomocou webového frameworku.
- Na konzumáciu SSE servera môžete použiť Inspector aj Visual Studio Code, rovnako ako pri stdio serveroch. Všimnite si, že medzi stdio a SSE sú malé rozdiely. Pri SSE musíte server spustiť samostatne a potom spustiť nástroj inspektora. Pri inspektore je tiež potrebné špecifikovať URL.

## Ukážky

- [Java Kalkulačka](../samples/java/calculator/README.md)
- [.Net Kalkulačka](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulačka](../samples/javascript/README.md)
- [TypeScript Kalkulačka](../samples/typescript/README.md)
- [Python Kalkulačka](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Čo ďalej

- Ďalej: [HTTP Streaming s MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, berte prosím na vedomie, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.