<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:29:48+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "sr"
}
-->
# Kreiranje klijenta sa LLM

Do sada ste videli kako da kreirate server i klijenta. Klijent je mogao eksplicitno da pozove server da navede njegove alate, resurse i upite. Međutim, to nije baš praktičan pristup. Vaš korisnik živi u agentskoj eri i očekuje da koristi upite i komunicira sa LLM-om da bi to učinio. Vašem korisniku nije važno da li koristite MCP ili ne za skladištenje vaših sposobnosti, ali očekuju da koriste prirodni jezik za interakciju. Kako to rešiti? Rešenje je dodavanje LLM-a klijentu.

## Pregled

U ovoj lekciji fokusiramo se na dodavanje LLM-a vašem klijentu i pokazujemo kako to pruža mnogo bolje iskustvo za vašeg korisnika.

## Ciljevi učenja

Na kraju ove lekcije, bićete u stanju da:

- Kreirate klijenta sa LLM-om.
- Bešavno komunicirate sa MCP serverom koristeći LLM.
- Pružite bolje korisničko iskustvo na strani klijenta.

## Pristup

Pokušajmo da razumemo pristup koji treba da preduzmemo. Dodavanje LLM-a zvuči jednostavno, ali kako to zapravo uraditi?

Evo kako će klijent komunicirati sa serverom:

1. Uspostavite vezu sa serverom.

2. Navedite sposobnosti, upite, resurse i alate, i sačuvajte njihovu šemu.

3. Dodajte LLM i prenesite sačuvane sposobnosti i njihovu šemu u formatu koji LLM razume.

4. Obradite korisnički upit tako što ćete ga proslediti LLM-u zajedno sa alatima koje je klijent naveo.

Odlično, sada razumemo kako to možemo uraditi na visokom nivou, hajde da probamo to u vežbi ispod.

## Vežba: Kreiranje klijenta sa LLM-om

U ovoj vežbi naučićemo kako da dodamo LLM našem klijentu.

### -1- Povezivanje sa serverom

Hajde prvo da kreiramo našeg klijenta:
Obučeni ste na podacima do oktobra 2023. godine.

Odlično, za naš sledeći korak, hajde da navedemo sposobnosti na serveru.

### -2 Navođenje sposobnosti servera

Sada ćemo se povezati sa serverom i zatražiti njegove sposobnosti.

### -3- Pretvaranje sposobnosti servera u alate za LLM

Sledeći korak nakon navođenja sposobnosti servera je njihovo pretvaranje u format koji LLM razume. Kada to uradimo, možemo pružiti te sposobnosti kao alate našem LLM-u.

Odlično, sada smo spremni da obradimo bilo kakve korisničke zahteve, pa hajde da se pozabavimo time sledeće.

### -4- Obrada korisničkog upita

U ovom delu koda, obradićemo korisničke zahteve.

Odlično, uspeli ste!

## Zadatak

Uzmi kod iz vežbe i izgradi server sa još nekim alatima. Zatim kreiraj klijenta sa LLM-om, kao u vežbi, i testiraj ga sa različitim upitima kako bi se uverio da se svi alati servera pozivaju dinamički. Ovaj način izgradnje klijenta znači da će krajnji korisnik imati odlično korisničko iskustvo jer će moći da koristi upite, umesto tačnih komandi klijenta, i biti nesvestan pozivanja MCP servera.

## Rešenje

[Rešenje](/03-GettingStarted/03-llm-client/solution/README.md)

## Ključne Tačke

- Dodavanje LLM-a vašem klijentu pruža bolji način za korisnike da komuniciraju sa MCP Serverima.
- Potrebno je konvertovati MCP Server odgovor u nešto što LLM može razumeti.

## Primeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Dodatni Resursi

## Šta Sledi

- Sledeće: [Korišćenje servera koristeći Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Одрицање од одговорности**:
Овај документ је преведен коришћењем AI услуге за превођење [Co-op Translator](https://github.com/Azure/co-op-translator). Иако тежимо тачности, молимо вас да будете свесни да аутоматски преводи могу садржати грешке или нетачности. Оригинални документ на његовом изворном језику треба сматрати ауторитативним извором. За критичне информације, препоручује се професионални људски превод. Нисмо одговорни за било каква погрешна схватања или погрешна тумачења која могу произаћи из коришћења овог превода.