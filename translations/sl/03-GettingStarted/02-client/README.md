<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:51:30+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sl"
}
-->
# Ustvarjanje odjemalca

Odjemalci so prilagojene aplikacije ali skripte, ki neposredno komunicirajo z MCP strežnikom za zahtevo virov, orodij in pozivov. V nasprotju z uporabo inšpektorskega orodja, ki zagotavlja grafični vmesnik za interakcijo s strežnikom, pisanje lastnega odjemalca omogoča programatične in avtomatizirane interakcije. To omogoča razvijalcem, da integrirajo zmogljivosti MCP v svoje delovne tokove, avtomatizirajo naloge in ustvarijo prilagojene rešitve, prilagojene specifičnim potrebam.

## Pregled

Ta lekcija uvaja koncept odjemalcev znotraj ekosistema Model Context Protocol (MCP). Naučili se boste, kako napisati svojega odjemalca in ga povezati z MCP strežnikom.

## Cilji učenja

Do konca te lekcije boste sposobni:

- Razumeti, kaj lahko odjemalec naredi.
- Napisati svojega odjemalca.
- Povezati in preizkusiti odjemalca z MCP strežnikom, da zagotovite, da slednji deluje po pričakovanjih.

## Kaj je potrebno za pisanje odjemalca?

Za pisanje odjemalca boste morali narediti naslednje:

- **Uvoziti ustrezne knjižnice**. Uporabili boste isto knjižnico kot prej, le z različnimi konstrukti.
- **Ustvariti instanco odjemalca**. To bo vključevalo ustvarjanje instance odjemalca in povezovanje z izbrano metodo prenosa.
- **Odločiti se, katere vire našteti**. Vaš MCP strežnik ima vire, orodja in pozive, vi pa se morate odločiti, katerega našteti.
- **Integrirati odjemalca v gostiteljsko aplikacijo**. Ko poznate zmogljivosti strežnika, morate to integrirati v vašo gostiteljsko aplikacijo, tako da če uporabnik vnese poziv ali drug ukaz, se sproži ustrezna funkcija strežnika.

Zdaj, ko na visoki ravni razumemo, kaj bomo naredili, si poglejmo primer.

### Primer odjemalca

Poglejmo si ta primer odjemalca:
Usposobljeni ste na podatkih do oktobra 2023.

V predhodni kodi smo:

- Uvozili knjižnice
- Ustvarili instanco odjemalca in ga povezali z uporabo stdio za prenos.
- Našteli pozive, vire in orodja ter jih vse priklicali.

In to je to, odjemalec, ki lahko komunicira z MCP strežnikom.

V naslednjem razdelku vaje si bomo vzeli čas in razčlenili vsak del kode ter pojasnili, kaj se dogaja.

## Vaja: Pisanje odjemalca

Kot je bilo rečeno zgoraj, si vzemimo čas za pojasnjevanje kode, in če želite, lahko kodirate zraven.

### -1- Uvoz knjižnic

Uvozimo knjižnice, ki jih potrebujemo, potrebovali bomo reference na odjemalca in na naš izbrani protokol prenosa, stdio. stdio je protokol za stvari, namenjene delovanju na vašem lokalnem računalniku. SSE je še en protokol prenosa, ki ga bomo prikazali v prihodnjih poglavjih, vendar je to vaša druga možnost. Za zdaj pa nadaljujmo s stdio.

Premaknimo se k instanciranju.

### -2- Instanciranje odjemalca in prenosa

Potrebovali bomo ustvariti instanco prenosa in tisto našega odjemalca:

### -3- Naštevanje funkcij strežnika

Zdaj imamo odjemalca, ki se lahko poveže, če program zaženemo. Vendar ne navaja svojih funkcij, zato to storimo naslednjič:

Odlično, zdaj smo zajeli vse funkcije. Zdaj je vprašanje, kdaj jih uporabimo? No, ta odjemalec je precej preprost, preprost v smislu, da bomo morali funkcije izrecno poklicati, ko jih želimo. V naslednjem poglavju bomo ustvarili bolj napreden odjemalec, ki ima dostop do svojega lastnega velikega jezikovnega modela, LLM. Za zdaj pa poglejmo, kako lahko prikličemo funkcije na strežniku:

### -4- Priklic funkcij

Za priklic funkcij moramo zagotoviti, da določimo pravilne argumente in v nekaterih primerih ime tistega, kar poskušamo priklicati.

### -5- Zagon odjemalca

Za zagon odjemalca vnesite naslednji ukaz v terminal:

## Naloga

V tej nalogi boste uporabili, kar ste se naučili pri ustvarjanju odjemalca, in ustvarili svojega odjemalca.

Tukaj je strežnik, ki ga lahko uporabite in ga morate poklicati prek vaše odjemalske kode, poglejte, če lahko dodate več funkcij strežniku, da bo bolj zanimiv.

## Rešitev

[Rešitev](./solution/README.md)

## Ključni poudarki

Ključni poudarki tega poglavja glede odjemalcev so:

- Lahko se uporabljajo tako za odkrivanje kot za priklic funkcij na strežniku.
- Lahko zaženejo strežnik, medtem ko se sami zaženejo (kot v tem poglavju), vendar se lahko odjemalci povežejo tudi z že delujočimi strežniki.
- Je odličen način za preizkušanje zmogljivosti strežnika poleg alternativ, kot je inšpektor, kot je bilo opisano v prejšnjem poglavju.

## Dodatni viri

- [Izdelava odjemalcev v MCP](https://modelcontextprotocol.io/quickstart/client)

## Vzorci

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Kaj sledi

- Naslednje: [Ustvarjanje odjemalca z LLM](/03-GettingStarted/03-llm-client/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve AI za prevajanje [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem maternem jeziku je treba obravnavati kot avtoritativni vir. Za ključne informacije je priporočljivo strokovno človeško prevajanje. Ne odgovarjamo za nesporazume ali napačne razlage, ki izhajajo iz uporabe tega prevoda.