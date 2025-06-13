<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-13T01:00:35+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sk"
}
-->
Teraz, keď už vieme trochu viac o SSE, postavme si ďalší SSE server.

## Cvičenie: Vytvorenie SSE servera

Na vytvorenie nášho servera musíme mať na pamäti dve veci:

- Potrebujeme použiť webový server na sprístupnenie endpointov pre pripojenie a správy.
- Server postavíme ako zvyčajne, s nástrojmi, zdrojmi a promptami, ako sme to robili pri stdio.

### -1- Vytvorenie inštancie servera

Na vytvorenie servera použijeme rovnaké typy ako pri stdio. Avšak pre transport musíme zvoliť SSE.

Pridajme teraz potrebné routy.

### -2- Pridanie rout

Pridajme routy, ktoré budú spracovávať pripojenie a prichádzajúce správy:

Pridajme teraz schopnosti servera.

### -3- Pridanie schopností serveru

Keď už máme všetko špecifické pre SSE definované, pridajme schopnosti servera ako nástroje, prompt a zdroje.

Celý kód by mal vyzerať takto:

Skvelé, máme server používajúci SSE, poďme si ho vyskúšať.

## Cvičenie: Ladenie SSE servera pomocou Inspector

Inspector je skvelý nástroj, ktorý sme videli v predchádzajúcej lekcii [Creating your first server](/03-GettingStarted/01-first-server/README.md). Pozrime sa, či ho môžeme použiť aj tu:

### -1- Spustenie inspektora

Na spustenie inspektora musíte mať najskôr spustený SSE server, tak to spravme:

1. Spustite server

1. Spustite inspektora

    > ![NOTE]
    > Spustite ho v inom terminálovom okne ako server. Tiež si všimnite, že príkaz nižšie musíte upraviť podľa URL, na ktorej váš server beží.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Spustenie inspektora vyzerá rovnako vo všetkých runtime prostrediach. Všimnite si, že namiesto zadania cesty k serveru a príkazu na jeho spustenie zadávame URL, kde server beží, a tiež špecifikujeme `/sse` routu.

### -2- Vyskúšanie nástroja

Pripojte sa k serveru výberom SSE v rozbaľovacom zozname a vyplňte pole URL, kde váš server beží, napríklad http://localhost:4321/sse. Potom kliknite na tlačidlo "Connect". Ako predtým, vyberte zoznam nástrojov, zvoľte nástroj a zadajte vstupné hodnoty. Mali by ste vidieť výsledok ako na obrázku nižšie:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sk.png)

Skvelé, dokážete pracovať s inspektorom, poďme sa pozrieť, ako pracovať s Visual Studio Code.

## Zadanie

Skúste rozšíriť svoj server o ďalšie schopnosti. Pozrite si [túto stránku](https://api.chucknorris.io/), kde napríklad môžete pridať nástroj, ktorý volá API, vy rozhodnete, ako bude server vyzerať. Bavte sa :)

## Riešenie

[Riešenie](./solution/README.md) Tu je možné riešenie s funkčným kódom.

## Kľúčové poznatky

Z tohto kapitolu si odnášame:

- SSE je druhý podporovaný typ transportu vedľa stdio.
- Na podporu SSE musíte spravovať prichádzajúce pripojenia a správy pomocou webového frameworku.
- Na konzumáciu SSE servera môžete použiť Inspector aj Visual Studio Code, rovnako ako pri stdio serveroch. Všimnite si, že sa trochu líši spôsob práce medzi stdio a SSE. Pri SSE musíte server spustiť samostatne a potom spustiť nástroj inspektora. Pre inspektora je tiež potrebné špecifikovať URL.

## Ukážky

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatočné zdroje

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Čo bude ďalej

- Ďalej: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Vyhlásenie o zodpovednosti**:  
Tento dokument bol preložený pomocou AI prekladateľskej služby [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, prosím, berte na vedomie, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Originálny dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre kritické informácie sa odporúča profesionálny ľudský preklad. Nie sme zodpovední za akékoľvek nedorozumenia alebo nesprávne výklady vyplývajúce z použitia tohto prekladu.