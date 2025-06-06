<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9d80e2a99a9aea8d8226253e6baf4c8c",
  "translation_date": "2025-06-06T18:51:15+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hr"
}
-->
Odlično, za naš sljedeći korak, navedimo mogućnosti na serveru.

### -2 Navođenje mogućnosti servera

Sada ćemo se povezati sa serverom i zatražiti njegove mogućnosti:

### -3- Pretvaranje mogućnosti servera u LLM alate

Sljedeći korak nakon navođenja mogućnosti servera je pretvoriti ih u format koji LLM razumije. Kad to učinimo, možemo te mogućnosti pružiti kao alate našem LLM-u.

Odlično, sada smo spremni za rukovanje korisničkim zahtjevima, pa to riješimo sljedeće.

### -4- Rukovanje korisničkim upitom

U ovom dijelu koda ćemo obrađivati korisničke zahtjeve.

Odlično, uspjeli ste!

## Zadatak

Uzmite kod iz vježbe i nadogradite server s još nekoliko alata. Zatim kreirajte klijenta s LLM-om, kao u vježbi, i testirajte ga s različitim upitima kako biste bili sigurni da se svi alati servera dinamički pozivaju. Ovakav način izrade klijenta omogućuje izvrsno korisničko iskustvo jer korisnici mogu koristiti upite na prirodnom jeziku, umjesto točnih naredbi klijenta, i ne moraju znati da se poziva MCP server.

## Rješenje

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključni zaključci

- Dodavanje LLM-a vašem klijentu pruža bolji način interakcije korisnika s MCP serverima.
- Potrebno je pretvoriti odgovor MCP servera u nešto što LLM može razumjeti.

## Primjeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

## Što slijedi

- Sljedeće: [Korištenje servera u Visual Studio Code-u](/03-GettingStarted/04-vscode/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden pomoću AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.