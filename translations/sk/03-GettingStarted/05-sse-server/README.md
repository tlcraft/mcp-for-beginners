<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:57:09+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sk"
}
-->
Teraz, keď už vieme trochu viac o SSE, poďme si vytvoriť SSE server.

## Cvičenie: Vytvorenie SSE Servera

Na vytvorenie nášho servera musíme mať na pamäti dve veci:

- Potrebujeme použiť webový server na sprístupnenie endpointov pre pripojenie a správy.
- Server postavíme tak, ako sme boli zvyknutí pri použití stdio, s nástrojmi, zdrojmi a promptami.

### -1- Vytvorenie inštancie servera

Na vytvorenie servera používame rovnaké typy ako pri stdio. Avšak pre transport si musíme zvoliť SSE.

### -2- Pridanie rout

Pridajme routy, ktoré budú spracovávať pripojenie a prichádzajúce správy:

### -3- Pridanie schopností servera

Keď už máme všetko špecifické pre SSE definované, pridajme schopnosti servera ako nástroje, prompt a zdroje.

Tvoj kompletný kód by mal vyzerať takto:

Skvelé, máme server používajúci SSE, poďme si ho vyskúšať.

## Cvičenie: Ladenie SSE Servera pomocou Inspector

Inspector je skvelý nástroj, ktorý sme videli v predchádzajúcej lekcii [Creating your first server](/03-GettingStarted/01-first-server/README.md). Pozrime sa, či ho môžeme použiť aj tu:

### -1- Spustenie Inspectoru

Na spustenie Inspectoru musí byť najprv spustený SSE server, tak to urobme:

1. Spusti server

1. Spusti Inspector

    > ![NOTE]
    > Tento príkaz spúšťaj v inom terminálovom okne, než kde beží server. Tiež nezabudni upraviť príkaz podľa URL, kde tvoj server beží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Spustenie Inspectoru vyzerá rovnako vo všetkých runtime. Všimni si, že namiesto zadania cesty k serveru a príkazu na jeho spustenie zadávame URL, kde server beží, a špecifikujeme routu `/sse`.

### -2- Vyskúšanie nástroja

Pripoj server výberom SSE v rozbaľovacom zozname a vyplň pole URL, kde tvoj server beží, napríklad http://localhost:4321/sse. Potom klikni na tlačidlo "Connect". Ako predtým, vyber si zoznam nástrojov, vyber nástroj a zadaj vstupné hodnoty. Mal by sa ti zobraziť výsledok ako na obrázku nižšie:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sk.png)

Skvelé, dokážeš pracovať s Inspectorom, poďme sa pozrieť, ako pracovať s Visual Studio Code.

## Zadanie

Skús rozšíriť svoj server o ďalšie schopnosti. Pozri si [túto stránku](https://api.chucknorris.io/), kde môžeš napríklad pridať nástroj, ktorý volá API. Rozhodni sa, ako by mal server vyzerať. Bav sa :)

## Riešenie

[Riešenie](./solution/README.md) Tu nájdeš možné riešenie s funkčným kódom.

## Kľúčové poznatky

Hlavné poznatky z tejto kapitoly sú:

- SSE je druhý podporovaný typ transportu vedľa stdio.
- Na podporu SSE musíš spravovať prichádzajúce pripojenia a správy cez webový framework.
- Môžeš použiť Inspector aj Visual Studio Code na prácu so SSE serverom, rovnako ako so stdio servermi. Všimni si však, že medzi stdio a SSE sú malé rozdiely. Pre SSE musíš server spustiť samostatne a potom spustiť Inspector. Pri Inspectori je tiež potrebné zadať URL.

## Ukážky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Čo ďalej

- Ďalej: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, majte na pamäti, že automatizované preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho rodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.