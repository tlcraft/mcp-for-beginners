<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:32:43+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sl"
}
-->
Zdaj, ko vemo malo več o SSE, zgradimo naslednji SSE strežnik.

## Vaja: Ustvarjanje SSE strežnika

Za ustvarjanje našega strežnika moramo upoštevati dve stvari:

- Potrebujemo spletni strežnik, ki bo razkril končne točke za povezavo in sporočila.
- Strežnik zgradimo kot običajno z orodji, viri in pozivi, kot smo to počeli pri stdio.

### -1- Ustvarjanje primerka strežnika

Za ustvarjanje strežnika uporabimo enake tipe kot pri stdio. Vendar pa moramo za transport izbrati SSE.

Dodajmo naslednje poti.

### -2- Dodajanje poti

Dodajmo poti, ki obravnavajo povezavo in dohodna sporočila:

Dodajmo strežniške zmogljivosti.

### -3- Dodajanje zmogljivosti strežnika

Zdaj, ko smo definirali vse, kar je specifično za SSE, dodajmo strežniške zmogljivosti, kot so orodja, pozivi in viri.

Vaša celotna koda bi morala izgledati takole:

Odlično, imamo strežnik, ki uporablja SSE, preizkusimo ga.

## Vaja: Odpravljanje napak SSE strežnika z Inspectorjem

Inspector je odlično orodje, ki smo ga videli v prejšnji lekciji [Ustvarjanje vašega prvega strežnika](/03-GettingStarted/01-first-server/README.md). Preverimo, ali ga lahko uporabimo tudi tukaj:

### -1- Zagon inspectorja

Za zagon inspectorja morate najprej imeti zagnan SSE strežnik, zato to naredimo najprej:

1. Zaženite strežnik

1. Zaženite inspector

    > ![NOTE]
    > To zaženite v ločenem terminalskem oknu, kot je tisto, kjer teče strežnik. Prav tako prilagodite spodnji ukaz tako, da ustreza URL-ju, kjer vaš strežnik teče.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Zagon inspectorja je enak v vseh runtime okoljih. Opazite, da namesto podajanja poti do strežnika in ukaza za zagon strežnika podamo URL, kjer strežnik teče, ter določimo pot `/sse`.

### -2- Preizkušanje orodja

Povežite strežnik tako, da v spustnem seznamu izberete SSE in vnesete URL, kjer vaš strežnik teče, na primer http:localhost:4321/sse. Nato kliknite gumb "Connect". Tako kot prej izberite orodja, izberite orodje in vnesite vrednosti. Rezultat bi moral izgledati tako:

![SSE strežnik, ki teče v inspectorju](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sl.png)

Odlično, lahko delate z inspectorjem, poglejmo, kako delati z Visual Studio Code.

## Naloga

Poskusite razširiti svoj strežnik z več zmogljivostmi. Oglejte si [to stran](https://api.chucknorris.io/), da na primer dodate orodje, ki kliče API. Vi odločite, kako naj strežnik izgleda. Uživajte :)

## Rešitev

[Rešitev](./solution/README.md) Tukaj je možna rešitev z delujočo kodo.

## Ključne ugotovitve

Ključne ugotovitve tega poglavja so naslednje:

- SSE je drugi podprti transport poleg stdio.
- Za podporo SSE morate upravljati dohodne povezave in sporočila z uporabo spletnega ogrodja.
- Za uporabo SSE strežnika lahko uporabite tako Inspector kot Visual Studio Code, podobno kot pri stdio strežnikih. Opazite, da se nekoliko razlikuje med stdio in SSE. Pri SSE morate strežnik zagnati ločeno in nato zagnati orodje inspector. Pri inspectorju je tudi razlika, saj morate navesti URL.

## Vzorci

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Kaj sledi

- Naslednje: [HTTP pretakanje z MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Ne odgovarjamo za morebitna nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.