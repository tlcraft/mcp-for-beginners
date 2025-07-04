<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-04T19:13:11+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sl"
}
-->
V zgornji kodi smo:

- Uvozili knjižnice
- Ustvarili instanco klienta in jo povezali z uporabo stdio za prenos.
- Izpisali pozive, vire in orodja ter jih vse poklicali.

Tako, imate klienta, ki lahko komunicira z MCP strežnikom.

V naslednjem razdelku vaj si bomo vzeli čas, da razčlenimo vsak del kode in razložimo, kaj se dogaja.

## Vaja: Pisanje klienta

Kot smo že omenili, si bomo vzeli čas za razlago kode, in seveda, če želite, lahko kodo pišete skupaj z nami.

### -1- Uvoz knjižnic

Uvozimo potrebne knjižnice, potrebovali bomo reference na klienta in na izbrani prenosni protokol, stdio. stdio je protokol za stvari, ki naj bi tekle na vašem lokalnem računalniku. SSE je drug prenosni protokol, ki ga bomo predstavili v prihodnjih poglavjih, a to je vaša druga možnost. Za zdaj pa nadaljujmo s stdio.

Pojdimo naprej k instanciranju.

### -2- Instanciranje klienta in prenosa

Ustvariti bomo morali instanco prenosa in instanco našega klienta:

### -3- Izpis funkcij strežnika

Zdaj imamo klienta, ki se lahko poveže, če se program zažene. Vendar pa še ne izpiše njegovih funkcij, zato to naredimo naslednje:

Odlično, zdaj smo zajeli vse funkcije. Zdaj pa vprašanje, kdaj jih uporabimo? Ta klient je precej preprost, preprost v smislu, da bomo morali funkcije izrecno poklicati, ko jih želimo uporabiti. V naslednjem poglavju bomo ustvarili bolj naprednega klienta, ki bo imel dostop do lastnega velikega jezikovnega modela (LLM). Za zdaj pa poglejmo, kako lahko pokličemo funkcije na strežniku:

### -4- Klic funkcij

Za klic funkcij moramo zagotoviti, da podamo pravilne argumente in v nekaterih primerih ime tistega, kar želimo poklicati.

### -5- Zagon klienta

Za zagon klienta v terminal vpišite naslednji ukaz:

## Naloga

V tej nalogi boste uporabili naučeno o ustvarjanju klienta in ustvarili svojega.

Tukaj je strežnik, ki ga lahko uporabite in ga morate klicati preko svoje kode klienta, poskusite dodati več funkcij strežniku, da bo bolj zanimiv.

## Rešitev

[Rešitev](./solution/README.md)

## Ključne ugotovitve

Ključne ugotovitve tega poglavja o klientih so naslednje:

- Lahko se uporabljajo tako za odkrivanje kot za klic funkcij na strežniku.
- Lahko zaženete strežnik, medtem ko se klient sam zažene (kot v tem poglavju), a klienti se lahko povežejo tudi z že delujočimi strežniki.
- So odličen način za preizkušanje zmogljivosti strežnika poleg alternativ, kot je Inspector, kot je bilo opisano v prejšnjem poglavju.

## Dodatni viri

- [Gradnja klientov v MCP](https://modelcontextprotocol.io/quickstart/client)

## Primeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Kaj sledi

- Naslednje: [Ustvarjanje klienta z LLM](../03-llm-client/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.