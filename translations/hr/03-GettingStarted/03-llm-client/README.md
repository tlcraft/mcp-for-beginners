<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:53:39+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hr"
}
-->
Odlično, za sljedeći korak, nabrojimo mogućnosti na serveru.

### -2 Nabrajanje mogućnosti servera

Sada ćemo se povezati sa serverom i zatražiti njegove mogućnosti:

### -3- Pretvaranje mogućnosti servera u LLM alate

Sljedeći korak nakon nabrajanja mogućnosti servera je njihova konverzija u format koji LLM razumije. Kada to napravimo, možemo te mogućnosti ponuditi kao alate našem LLM-u.

Odlično, sada smo spremni za rukovanje korisničkim zahtjevima, pa to riješimo sljedeće.

### -4- Rukovanje korisničkim upitom

U ovom dijelu koda ćemo obraditi korisničke zahtjeve.

Odlično, uspjeli ste!

## Zadatak

Uzmite kod iz vježbe i nadogradite server s još nekoliko alata. Zatim kreirajte klijenta s LLM-om, kao u vježbi, i testirajte ga s različitim upitima kako biste bili sigurni da se svi alati servera pozivaju dinamički. Ovaj način izrade klijenta omogućuje krajnjem korisniku izvrsno korisničko iskustvo jer može koristiti upite na prirodnom jeziku, umjesto točnih naredbi klijenta, te pritom ne mora biti svjestan poziva bilo kojeg MCP servera.

## Rješenje

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne spoznaje

- Dodavanje LLM-a vašem klijentu pruža bolji način interakcije korisnika s MCP serverima.
- Potrebno je pretvoriti odgovor MCP servera u nešto što LLM može razumjeti.

## Primjeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

## Što slijedi

- Sljedeće: [Korištenje servera u Visual Studio Code-u](/03-GettingStarted/04-vscode/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za važne informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakve nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.