<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:30:18+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "hr"
}
-->
# Stvaranje klijenta s LLM-om

Dosad ste vidjeli kako stvoriti server i klijenta. Klijent je mogao izričito pozvati server kako bi nabrojao njegove alate, resurse i upite. Međutim, to nije baš praktičan pristup. Vaš korisnik živi u agentičkoj eri i očekuje korištenje upita te komunikaciju s LLM-om kako bi to učinio. Vašem korisniku nije važno koristite li MCP ili ne za pohranu svojih sposobnosti, ali očekuju korištenje prirodnog jezika za interakciju. Pa kako to riješiti? Rješenje je dodavanje LLM-a klijentu.

## Pregled

U ovoj lekciji fokusiramo se na dodavanje LLM-a vašem klijentu i pokazujemo kako to pruža puno bolje iskustvo za vašeg korisnika.

## Ciljevi učenja

Na kraju ove lekcije, moći ćete:

- Stvoriti klijenta s LLM-om.
- Besprijekorno komunicirati s MCP serverom koristeći LLM.
- Pružiti bolje korisničko iskustvo na strani klijenta.

## Pristup

Pokušajmo razumjeti pristup koji trebamo poduzeti. Dodavanje LLM-a zvuči jednostavno, ali kako ćemo to zapravo učiniti?

Evo kako će klijent komunicirati sa serverom:

1. Uspostavite vezu sa serverom.

1. Nabrojite sposobnosti, upite, resurse i alate te spremite njihovu shemu.

1. Dodajte LLM i proslijedite spremljene sposobnosti i njihove sheme u formatu koji LLM razumije.

1. Obradite korisnički upit tako što ćete ga proslijediti LLM-u zajedno s alatima koje klijent navodi.

Odlično, sada razumijemo kako to možemo učiniti na visokoj razini, pokušajmo to u vježbi u nastavku.

## Vježba: Stvaranje klijenta s LLM-om

U ovoj vježbi naučit ćemo dodati LLM našem klijentu.

### -1- Povežite se sa serverom

Najprije stvorimo našeg klijenta:
Obučeni ste na podacima do listopada 2023.

Odlično, za naš sljedeći korak, navedimo sposobnosti na serveru.

### -2- Nabrojite sposobnosti servera

Sada ćemo se povezati sa serverom i zatražiti njegove sposobnosti:

### -3- Pretvorite sposobnosti servera u LLM alate

Sljedeći korak nakon nabrajanja sposobnosti servera je pretvaranje istih u format koji LLM razumije. Kada to učinimo, možemo te sposobnosti pružiti kao alate našem LLM-u.

Odlično, sada smo spremni za obradu bilo kakvih korisničkih zahtjeva, pa idemo to riješiti sljedeće.

### -4- Obradite korisnički zahtjev

U ovom dijelu koda obradit ćemo korisničke zahtjeve.

Odlično, uspjeli ste!

## Zadatak

Uzmite kod iz vježbe i izgradite server s još nekoliko alata. Zatim stvorite klijenta s LLM-om, kao u vježbi, i testirajte ga s različitim upitima kako biste bili sigurni da se svi alati vašeg servera dinamički pozivaju. Ovaj način izgradnje klijenta znači da će krajnji korisnik imati izvrsno korisničko iskustvo jer će moći koristiti upite, umjesto točnih klijentskih naredbi, i neće biti svjestan da se MCP server poziva.

## Rješenje

[Rješenje](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne točke

- Dodavanje LLM-a vašem klijentu pruža bolji način za korisnike da komuniciraju s MCP serverima.
- Potrebno je pretvoriti MCP server odgovor u nešto što LLM može razumjeti.

## Primjeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

## Što je sljedeće

- Sljedeće: [Korištenje servera koristeći Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Izjava o odricanju odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na njegovom izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne preuzimamo odgovornost za nesporazume ili pogrešne interpretacije koje proizlaze iz korištenja ovog prijevoda.