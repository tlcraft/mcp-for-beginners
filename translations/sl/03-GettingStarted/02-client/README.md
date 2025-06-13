<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:54:30+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sl"
}
-->
V zgornji kodi smo:

- Uvozili knjižnice
- Ustvarili instanco klienta in jo povezali z uporabo stdio kot transporta.
- Izpisali sezname pozivov, virov in orodij ter jih vse poklicali.

Tako, imate klienta, ki lahko komunicira z MCP strežnikom.

V naslednjem delu vaje si bomo vzeli čas in podrobno razložili vsak del kode.

## Vaja: Pisanje klienta

Kot smo že omenili, si bomo vzeli čas za razlago kode, in seveda, če želite, lahko hkrati tudi programirate.

### -1- Uvoz knjižnic

Uvozimo potrebne knjižnice, potrebovali bomo reference na klienta in na izbrani transportni protokol, stdio. stdio je protokol za stvari, ki naj bi tekle na lokalnem računalniku. SSE je drug transportni protokol, ki ga bomo pokazali v prihodnjih poglavjih, a to je vaša druga možnost. Za zdaj pa nadaljujmo s stdio.

### -2- Ustvarjanje instanc klienta in transporta

Potrebovali bomo ustvariti instanco transporta in instanco našega klienta:

### -3- Izpis funkcij strežnika

Sedaj imamo klienta, ki se lahko poveže, če se program zažene. Vendar pa še ne izpiše njegovih funkcij, zato to naredimo zdaj:

Odlično, zdaj smo zajeli vse funkcije. Zdaj pa vprašanje, kdaj jih uporabimo? Ta klient je precej preprost, kar pomeni, da moramo funkcije eksplicitno poklicati, ko jih želimo uporabiti. V naslednjem poglavju bomo ustvarili bolj naprednega klienta, ki bo imel dostop do lastnega velikega jezikovnega modela, LLM. Za zdaj pa poglejmo, kako lahko pokličemo funkcije na strežniku:

### -4- Klic funkcij

Za klic funkcij moramo zagotoviti, da določimo pravilne argumente in v nekaterih primerih tudi ime tistega, kar želimo poklicati.

### -5- Zagon klienta

Za zagon klienta v terminal vpišite naslednji ukaz:

## Naloga

V tej nalogi boste uporabili znanje o ustvarjanju klienta in napisali svojega.

Tu je strežnik, ki ga lahko uporabite in ga morate poklicati preko vaše klient kode. Poskusite dodati več funkcij strežniku, da bo bolj zanimiv.

## Rešitev

[Rešitev](./solution/README.md)

## Ključne ugotovitve

Ključne ugotovitve tega poglavja o klientih so naslednje:

- Lahko se uporabljajo tako za odkrivanje kot za klic funkcij na strežniku.
- Lahko zaženejo strežnik hkrati s sabo (kot v tem poglavju), vendar se klienti lahko povežejo tudi na že delujoče strežnike.
- So odličen način za testiranje zmogljivosti strežnika poleg alternativ, kot je Inspector, kot je bilo opisano v prejšnjem poglavju.

## Dodatni viri

- [Gradnja klientov v MCP](https://modelcontextprotocol.io/quickstart/client)

## Primeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Kaj sledi

- Naslednje: [Ustvarjanje klienta z LLM](/03-GettingStarted/03-llm-client/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvorni jezik velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.