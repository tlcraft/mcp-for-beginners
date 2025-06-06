<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:52:51+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sl"
}
-->
Super, za naš naslednji korak pa naštejmo zmogljivosti na strežniku.

### -2 Naštejmo zmogljivosti strežnika

Zdaj se bomo povezali s strežnikom in povprašali po njegovih zmogljivostih:

### -3- Pretvori zmogljivosti strežnika v orodja za LLM

Naslednji korak po tem, ko smo našteli zmogljivosti strežnika, je, da jih pretvorimo v format, ki ga razume LLM. Ko to naredimo, lahko te zmogljivosti ponudimo kot orodja našemu LLM.

Super, zdaj smo pripravljeni za obravnavo uporabniških zahtev, zato se lotimo tega.

### -4- Obravnava uporabniškega poziva

V tem delu kode bomo obravnavali uporabniške zahteve.

Super, uspelo ti je!

## Domača naloga

Vzemi kodo iz vaje in razširi strežnik z dodatnimi orodji. Nato ustvari odjemalca z LLM, kot v vaji, in ga preizkusi z različnimi pozivi, da se prepričaš, da se vsa orodja strežnika kličejo dinamično. Tak način izdelave odjemalca omogoča odlično uporabniško izkušnjo, saj lahko uporabniki uporabljajo naravni jezik namesto natančnih ukazov odjemalca in so pri tem nepremišljeni glede klicev MCP strežnika.

## Rešitev

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne ugotovitve

- Dodajanje LLM k odjemalcu omogoča uporabnikom bolj naraven način interakcije z MCP strežniki.
- Odziv MCP strežnika je treba pretvoriti v obliko, ki jo LLM razume.

## Primeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni viri

## Kaj sledi

- Naslednje: [Uporaba strežnika z Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Opozorilo**:  
Ta dokument je bil preveden z uporabo AI prevajalske storitve [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, vas prosimo, da upoštevate, da avtomatizirani prevodi lahko vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Nismo odgovorni za morebitne nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda.