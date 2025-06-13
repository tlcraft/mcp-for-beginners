<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:37:30+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sl"
}
-->
Super, za naš naslednji korak, naštejmo zmogljivosti na strežniku.

### -2 Naštejmo zmogljivosti strežnika

Zdaj se bomo povezali s strežnikom in povprašali po njegovih zmogljivostih:

### -3- Pretvori zmogljivosti strežnika v orodja za LLM

Naslednji korak po tem, ko smo našteli zmogljivosti strežnika, je, da jih pretvorimo v obliko, ki jo LLM razume. Ko to storimo, lahko te zmogljivosti ponudimo kot orodja našemu LLM-ju.

Super, zdaj smo pripravljeni obravnavati uporabniške zahteve, zato se tega lotimo naslednje.

### -4- Obdelava uporabniškega poziva

V tem delu kode bomo obravnavali uporabniške zahteve.

Super, uspelo ti je!

## Naloga

Vzemi kodo iz vaje in razširi strežnik z nekaj dodatnimi orodji. Nato ustvari klienta z LLM, kot v vaji, in ga preizkusi z različnimi pozivi, da se prepričaš, da se vsa orodja strežnika kličejo dinamično. Tak način izdelave klienta pomeni, da bo končni uporabnik imel odlično uporabniško izkušnjo, saj bo lahko uporabljal pozive namesto natančnih ukazov klienta in ne bo opazil, da se kliče MCP strežnik.

## Rešitev

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne ugotovitve

- Dodajanje LLM v tvojega klienta omogoča boljši način interakcije uporabnikov z MCP strežniki.
- Odgovor MCP strežnika je potrebno pretvoriti v nekaj, kar LLM lahko razume.

## Vzorci

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

## Kaj sledi

- Naslednje: [Uporaba strežnika z Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Izjava o omejitvi odgovornosti**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za kritične informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.