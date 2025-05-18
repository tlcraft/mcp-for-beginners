<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:30:47+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sl"
}
-->
# Ustvarjanje klienta z LLM

Doslej ste videli, kako ustvariti strežnik in klienta. Klient je lahko izrecno poklical strežnik, da bi našteval njegove orodja, vire in pozive. Vendar pa to ni zelo praktičen pristop. Vaš uporabnik živi v agentni dobi in pričakuje, da bo uporabljal pozive in komuniciral z LLM za to. Za vašega uporabnika ni pomembno, ali uporabljate MCP ali ne za shranjevanje vaših zmogljivosti, pričakujejo pa, da bodo komunicirali v naravnem jeziku. Kako torej to rešimo? Rešitev je v dodajanju LLM klientu.

## Pregled

V tej lekciji se osredotočamo na dodajanje LLM vašemu klientu in prikazujemo, kako to zagotavlja veliko boljšo izkušnjo za vašega uporabnika.

## Cilji učenja

Do konca te lekcije boste lahko:

- Ustvarili klienta z LLM.
- Brez težav komunicirali z MCP strežnikom z uporabo LLM.
- Zagotovili boljšo uporabniško izkušnjo na strani klienta.

## Pristop

Poskusimo razumeti pristop, ki ga moramo sprejeti. Dodajanje LLM se sliši preprosto, a ali bomo to dejansko storili?

Tako bo klient komuniciral s strežnikom:

1. Vzpostavite povezavo s strežnikom.

1. Naštejte zmogljivosti, pozive, vire in orodja ter shranite njihovo shemo.

1. Dodajte LLM in posredujte shranjene zmogljivosti ter njihovo shemo v obliki, ki jo LLM razume.

1. Obdelajte uporabniški poziv tako, da ga posredujete LLM skupaj z orodji, ki jih je navedel klient.

Odlično, zdaj razumemo, kako to lahko storimo na visoki ravni, poskusimo to v spodnji vaji.

## Vaja: Ustvarjanje klienta z LLM

V tej vaji se bomo naučili dodati LLM našemu klientu.

### -1- Povežite se s strežnikom

Najprej ustvarimo našega klienta:
Usposobljeni ste na podatkih do oktobra 2023.

Odlično, za naš naslednji korak, naštejmo zmogljivosti na strežniku.

### -2 Naštejte zmogljivosti strežnika

Zdaj se bomo povezali s strežnikom in povprašali po njegovih zmogljivostih.

### -3- Pretvorite zmogljivosti strežnika v orodja LLM

Naslednji korak po naštevanju zmogljivosti strežnika je, da jih pretvorimo v obliko, ki jo LLM razume. Ko to storimo, lahko te zmogljivosti zagotovimo kot orodja našemu LLM.

Odlično, zdaj smo pripravljeni obdelati katero koli uporabniško zahtevo, zato se lotimo tega naslednjega.

### -4- Obdelajte uporabniško zahtevo

V tem delu kode bomo obdelali uporabniške zahteve.

Odlično, uspelo vam je!

## Naloga

Vzemite kodo iz vaje in razširite strežnik z nekaj več orodji. Nato ustvarite klienta z LLM, kot v vaji, in ga preizkusite z različnimi pozivi, da se prepričate, da se vsa orodja strežnika klicajo dinamično. Ta način gradnje klienta pomeni, da bo končni uporabnik imel odlično uporabniško izkušnjo, saj bo lahko uporabljal pozive, namesto natančnih ukazov klienta, in ne bo opazil, da se kliče MCP strežnik.

## Rešitev

[Rešitev](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključni zaključki

- Dodajanje LLM vašemu klientu zagotavlja boljši način za uporabnike, da komunicirajo z MCP strežniki.
- Odgovor MCP strežnika morate pretvoriti v nekaj, kar LLM lahko razume.

## Vzorci

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

## Kaj sledi

- Naslednje: [Uporaba strežnika z Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko samodejni prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za kritične informacije je priporočljivo profesionalno človeško prevajanje. Ne odgovarjamo za morebitna nesporazumevanja ali napačne razlage, ki izhajajo iz uporabe tega prevoda.