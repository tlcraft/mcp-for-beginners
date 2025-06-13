<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:37:13+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hr"
}
-->
Odlično, za naš sljedeći korak, nabrojimo mogućnosti na serveru.

### -2 Nabrojavanje mogućnosti servera

Sada ćemo se povezati sa serverom i zatražiti njegove mogućnosti:

### -3- Pretvaranje mogućnosti servera u LLM alate

Sljedeći korak nakon nabrajanja mogućnosti servera je pretvoriti ih u format koji LLM razumije. Kada to napravimo, možemo te mogućnosti ponuditi kao alate našem LLM-u.

Odlično, sada smo spremni za rukovanje korisničkim zahtjevima, pa to riješimo sljedeće.

### -4- Rukovanje korisničkim upitom

U ovom dijelu koda ćemo obraditi korisničke zahtjeve.

Odlično, uspjeli ste!

## Zadatak

Uzmi kod iz vježbe i nadogradi server s još nekoliko alata. Zatim napravi klijenta s LLM-om, kao u vježbi, i testiraj ga s različitim upitima kako bi se uvjerio da se svi alati na serveru dinamički pozivaju. Ovakav način izrade klijenta omogućava korisnicima izvrsno iskustvo jer mogu koristiti upite na prirodnom jeziku, umjesto točnih klijentskih naredbi, i pritom nisu svjesni poziva MCP servera.

## Rješenje

[Rješenje](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne spoznaje

- Dodavanje LLM-a u klijenta pruža bolje korisničko iskustvo za interakciju s MCP serverima.
- Potrebno je pretvoriti odgovor MCP servera u oblik koji LLM može razumjeti.

## Primjeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

## Što slijedi

- Sljedeće: [Korištenje servera u Visual Studio Code-u](/03-GettingStarted/04-vscode/README.md)

**Odricanje od odgovornosti**:  
Ovaj je dokument preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.