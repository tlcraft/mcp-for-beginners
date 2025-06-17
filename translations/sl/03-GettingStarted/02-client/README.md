<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2342baa570312086fc19edcf41320250",
  "translation_date": "2025-06-17T16:18:21+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sl"
}
-->
V zgornji kodi smo:

- Uvozili knjižnice
- Ustvarili primerka klienta in ga povezali z uporabo stdio za prenos.
- Izpisali pozive, vire in orodja ter jih vse poklicali.

Tako, imate klienta, ki lahko komunicira z MCP strežnikom.

V naslednjem razdelku vaj si bomo vzeli čas in razčlenili vsak del kode ter razložili, kaj se dogaja.

## Vaja: Pisanje klienta

Kot je bilo rečeno zgoraj, si bomo vzeli čas za razlago kode, in seveda, če želite, lahko kodo pišete skupaj z nami.

### -1- Uvoz knjižnic

Uvozimo potrebne knjižnice, potrebovali bomo reference na klienta in na izbrani prenosni protokol, stdio. stdio je protokol za stvari, ki naj bi tekle na vašem lokalnem računalniku. SSE je drug prenosni protokol, ki ga bomo pokazali v prihodnjih poglavjih, a to je vaša druga možnost. Za zdaj pa nadaljujmo s stdio.

Pojdimo naprej k ustvarjanju primerka.

### -2- Ustvarjanje primerka klienta in prenosa

Ustvariti bomo morali primerka prenosa in našega klienta:

### -3- Izpis funkcij strežnika

Zdaj imamo klienta, ki se lahko poveže, če se program zažene. Vendar pa še ne izpiše svojih funkcij, zato to naredimo naslednje:

Odlično, zdaj smo zajeli vse funkcije. Zdaj pa vprašanje, kdaj jih uporabimo? Ta klient je precej preprost, preprost v smislu, da bomo morali funkcije izrecno poklicati, ko jih želimo uporabiti. V naslednjem poglavju bomo ustvarili bolj naprednega klienta, ki bo imel dostop do lastnega velikega jezikovnega modela, LLM. Za zdaj pa poglejmo, kako lahko pokličemo funkcije na strežniku:

### -4- Klic funkcij

Za klic funkcij moramo zagotoviti, da podamo pravilne argumente in v nekaterih primerih ime tistega, kar želimo poklicati.

### -5- Zagon klienta

Za zagon klienta v terminal vpišite naslednji ukaz:

## Naloga

V tej nalogi boste uporabili, kar ste se naučili o ustvarjanju klienta, in ustvarili svojega.

Tukaj je strežnik, ki ga lahko uporabite in ga morate klicati preko vaše kode klienta; poskusite dodati več funkcij strežniku, da bo bolj zanimiv.

## Rešitev

[Rešitev](./solution/README.md)

## Ključne ugotovitve

Ključne ugotovitve tega poglavja o klientih so naslednje:

- Lahko se uporabljajo tako za odkrivanje kot tudi za klic funkcij na strežniku.
- Lahko zaženejo strežnik, hkrati ko se sami zaženejo (kot v tem poglavju), vendar se klienti lahko povežejo tudi na že delujoče strežnike.
- So odličen način za testiranje zmožnosti strežnika poleg alternativ, kot je Inspector, kot je bilo opisano v prejšnjem poglavju.

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
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v izvorni jezik je treba obravnavati kot avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.