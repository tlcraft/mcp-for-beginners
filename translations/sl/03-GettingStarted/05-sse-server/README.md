<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-13T01:24:49+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "sl"
}
-->
Zdaj, ko vemo nekaj več o SSE, zgradimo naslednji SSE strežnik.

## Vaja: Ustvarjanje SSE strežnika

Za ustvarjanje našega strežnika moramo upoštevati dve stvari:

- Potrebujemo spletni strežnik, ki bo izpostavil končne točke za povezavo in sporočila.
- Strežnik zgradimo kot običajno, z orodji, viri in pozivi, kot smo delali pri stdio.

### -1- Ustvarjanje instance strežnika

Za ustvarjanje strežnika uporabimo iste tipe kot pri stdio. Vendar moramo za transport izbrati SSE.

Dodajmo naslednje poti.

### -2- Dodajanje poti

Dodajmo poti, ki upravljajo povezavo in dohodna sporočila:

Dodajmo naslednje zmogljivosti strežniku.

### -3- Dodajanje zmogljivosti strežnika

Ko imamo definirano vse, kar je specifično za SSE, dodajmo zmogljivosti strežnika, kot so orodja, pozivi in viri.

Celotna koda naj izgleda takole:

Super, imamo strežnik, ki uporablja SSE, preizkusimo ga.

## Vaja: Razhroščevanje SSE strežnika z Inspectorjem

Inspector je odlično orodje, ki smo ga videli v prejšnji lekciji [Ustvarjanje vašega prvega strežnika](/03-GettingStarted/01-first-server/README.md). Poskusimo ga uporabiti tudi tukaj:

### -1- Zagon Inspectorja

Za zagon Inspectorja morate najprej imeti zagnan SSE strežnik, zato ga najprej zaženimo:

1. Zaženite strežnik

1. Zaženite Inspector

    > ![NOTE]
    > To zaženite v ločenem terminalskem oknu, ločeno od tistega, kjer teče strežnik. Prav tako prilagodite spodnji ukaz URL-ju, kjer vaš strežnik teče.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

Zagon Inspectorja je enak v vseh runtime okoljih. Opazite, da namesto poti do strežnika in ukaza za zagon strežnika podamo URL, kjer strežnik teče, ter navedemo pot `/sse`.

### -2- Preizkus orodja

Povežite se s strežnikom tako, da izberete SSE v spustnem seznamu in vnesete URL, kjer vaš strežnik teče, na primer http:localhost:4321/sse. Nato kliknite gumb "Connect". Kot prej, izberite seznam orodij, izberite orodje in vnesite vhodne vrednosti. Rezultat bo videti takole:

![SSE strežnik, ki teče v Inspectorju](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.sl.png)

Odlično, lahko delate z Inspectorjem, poglejmo, kako lahko delate z Visual Studio Code.

## Naloga

Poskusite razširiti svoj strežnik z več zmogljivostmi. Oglejte si [to stran](https://api.chucknorris.io/), da na primer dodate orodje, ki kliče API. Vi odločite, kako naj strežnik izgleda. Zabavajte se :)

## Rešitev

[Rešitev](./solution/README.md) Tukaj je ena možna rešitev z delujočo kodo.

## Ključne ugotovitve

Ključne ugotovitve iz tega poglavja so naslednje:

- SSE je drugi podprti transport poleg stdio.
- Za podporo SSE morate upravljati dohodne povezave in sporočila z uporabo spletnega ogrodja.
- SSE strežnik lahko uporabljate tako z Inspectorjem kot z Visual Studio Code, podobno kot stdio strežnike. Opazite, da se nekoliko razlikuje med stdio in SSE. Pri SSE morate strežnik najprej zagnati ločeno in nato zagnati orodje Inspector. Pri Inspectorju morate tudi navesti URL.

## Vzorec

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../../../../03-GettingStarted/samples/javascript)
- [TypeScript kalkulator](../../../../03-GettingStarted/samples/typescript)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Kaj sledi

- Naslednje: [HTTP Streaming z MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku naj velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.