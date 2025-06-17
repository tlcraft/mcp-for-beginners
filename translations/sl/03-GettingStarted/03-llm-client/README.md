<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:53:54+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sl"
}
-->
Odlično, za naslednji korak naštejmo zmogljivosti strežnika.

### -2 Naštejmo zmogljivosti strežnika

Zdaj se bomo povezali s strežnikom in zahtevali njegove zmogljivosti:

### -3- Pretvorba zmogljivosti strežnika v orodja za LLM

Naslednji korak po naštetju zmogljivosti strežnika je, da jih pretvorimo v obliko, ki jo razume LLM. Ko to naredimo, lahko te zmogljivosti ponudimo kot orodja našemu LLM.

Odlično, zdaj smo pripravljeni obravnavati uporabniške zahteve, zato se tega lotimo.

### -4- Obravnava uporabniškega poziva

V tem delu kode bomo obravnavali uporabniške zahteve.

Odlično, uspelo ti je!

## Naloga

Vzemi kodo iz vaje in razširi strežnik z nekaj dodatnimi orodji. Nato ustvari klienta z LLM, kot v vaji, in ga preizkusi z različnimi pozivi, da se prepričaš, da se vsa orodja strežnika dinamično kličejo. Tak način izdelave klienta pomeni, da bo končni uporabnik imel odlično uporabniško izkušnjo, saj lahko uporablja pozive namesto natančnih ukazov klienta in ne bo opazil, da se kliče kateri koli MCP strežnik.

## Rešitev

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne ugotovitve

- Dodajanje LLM klientu omogoča boljšo interakcijo uporabnikov z MCP strežniki.
- Odziv MCP strežnika je treba pretvoriti v nekaj, kar LLM razume.

## Vzorci

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

## Kaj sledi

- Naslednje: [Uporaba strežnika z Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.