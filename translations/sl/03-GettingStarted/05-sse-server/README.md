<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:59:59+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sl"
}
-->
Zdaj, ko vemo malo več o SSE, zgradimo naslednji SSE strežnik.

## Vaja: Ustvarjanje SSE strežnika

Za ustvarjanje našega strežnika moramo upoštevati dve stvari:

- Potrebujemo spletni strežnik za izpostavitev končnih točk za povezavo in sporočila.
- Strežnik zgradimo kot običajno, z orodji, viri in pozivi, kot smo delali pri stdio.

### -1- Ustvarjanje instance strežnika

Za ustvarjanje strežnika uporabimo iste tipe kot pri stdio. Vendar moramo za transport izbrati SSE.

Dodajmo naslednje poti.

### -2- Dodajanje poti

Dodajmo poti, ki upravljajo povezavo in dohodna sporočila:

Dodajmo strežniku naslednje zmogljivosti.

### -3- Dodajanje zmogljivosti strežnika

Zdaj, ko imamo vse specifično za SSE definirano, dodajmo strežniku zmogljivosti, kot so orodja, pozivi in viri.

Vaša celotna koda naj izgleda takole:

Odlično, imamo strežnik, ki uporablja SSE, poglejmo ga v akciji.

## Vaja: Razhroščevanje SSE strežnika z Inspectorjem

Inspector je odlično orodje, ki smo ga videli v prejšnji lekciji [Ustvarjanje vašega prvega strežnika](/03-GettingStarted/01-first-server/README.md). Poglejmo, ali ga lahko uporabimo tudi tukaj:

### -1- Zagon Inspectorja

Za zagon Inspectorja morate najprej imeti zagnan SSE strežnik, zato to storimo najprej:

1. Zaženite strežnik

1. Zaženite Inspector

    > [!NOTE]
    > To zaženite v ločenem terminalskem oknu, kot je strežnik. Prav tako prilagodite spodnji ukaz glede na URL, kjer vaš strežnik teče.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Zagon Inspectorja je enak v vseh okoljih. Opazite, da namesto poti do strežnika in ukaza za zagon strežnika podamo URL, kjer strežnik teče, ter določimo pot `/sse`.

### -2- Preizkus orodja

Povežite se s strežnikom tako, da v spustnem seznamu izberete SSE in v polje za URL vpišete naslov, kjer vaš strežnik teče, na primer http:localhost:4321/sse. Nato kliknite gumb "Connect". Kot prej izberite seznam orodij, izberite orodje in vnesite vhodne vrednosti. Rezultat bi moral biti podoben spodnjemu:

![SSE strežnik teče v inspectorju](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sl.png)

Super, uspešno uporabljate Inspector, poglejmo, kako lahko delate z Visual Studio Code.

## Naloga

Poskusite razširiti vaš strežnik z več zmogljivostmi. Oglejte si [to stran](https://api.chucknorris.io/), da na primer dodate orodje, ki kliče API, vi pa odločite, kako naj strežnik izgleda. Zabavajte se :)

## Rešitev

[Rešitev](./solution/README.md) Tukaj je možna rešitev z delujočo kodo.

## Ključne ugotovitve

Ključne ugotovitve iz tega poglavja so naslednje:

- SSE je drugi podprti transport poleg stdio.
- Za podporo SSE morate upravljati dohodne povezave in sporočila z uporabo spletnega ogrodja.
- Za uporabo SSE strežnika lahko uporabljate tako Inspector kot Visual Studio Code, podobno kot pri stdio strežnikih. Opazite, da se nekoliko razlikuje med stdio in SSE. Pri SSE morate strežnik najprej zagnati ločeno in šele nato zagnati orodje Inspector. Pri Inspectorju morate tudi navesti URL.

## Vzorec

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Kaj sledi

- Naslednje: [HTTP pretakanje z MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v izvorni jezikovni različici velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.