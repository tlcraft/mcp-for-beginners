<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f74887f51a69d3f255cb83d0b517c623",
  "translation_date": "2025-07-13T18:57:04+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sl"
}
-->
Super, za naslednji korak pa naštejmo zmogljivosti na strežniku.

### -2 Naštejmo zmogljivosti strežnika

Sedaj se bomo povezali s strežnikom in povprašali po njegovih zmogljivostih:

### -3- Pretvorba zmogljivosti strežnika v orodja za LLM

Naslednji korak po naštetju zmogljivosti strežnika je, da jih pretvorimo v format, ki ga LLM razume. Ko to storimo, lahko te zmogljivosti ponudimo kot orodja našemu LLM.

Super, zdaj smo pripravljeni za obravnavo uporabniških zahtev, zato se lotimo tega.

### -4- Obravnava uporabniškega poziva

V tem delu kode bomo obravnavali uporabniške zahteve.

Super, uspelo ti je!

## Naloga

Vzemi kodo iz vaje in razširi strežnik z nekaj dodatnimi orodji. Nato ustvari klienta z LLM, kot v vaji, in ga preizkusi z različnimi pozivi, da se prepričaš, da se vsa orodja strežnika dinamično kličejo. Ta način gradnje klienta pomeni, da bo končni uporabnik imel odlično uporabniško izkušnjo, saj lahko uporablja pozive namesto natančnih ukazov klienta in ne bo opazil, da se kliče MCP strežnik.

## Rešitev

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne ugotovitve

- Dodajanje LLM k vašemu klientu omogoča boljši način interakcije uporabnikov z MCP strežniki.
- Odgovor MCP strežnika je treba pretvoriti v nekaj, kar LLM lahko razume.

## Primeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

## Kaj sledi

- Naslednje: [Uporaba strežnika v Visual Studio Code](../04-vscode/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za avtomatski prevod AI [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas opozarjamo, da lahko avtomatski prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za pomembne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne odgovarjamo.