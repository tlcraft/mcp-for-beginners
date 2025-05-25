<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:50:52+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hr"
}
-->
# Kreiranje klijenta

Klijenti su prilagođene aplikacije ili skripte koje direktno komuniciraju s MCP Serverom kako bi zatražili resurse, alate i upite. Za razliku od korištenja alata za inspekciju, koji pruža grafičko sučelje za interakciju sa serverom, pisanje vlastitog klijenta omogućuje programske i automatizirane interakcije. To omogućuje programerima da integriraju MCP sposobnosti u vlastite tijekove rada, automatiziraju zadatke i izgrade prilagođena rješenja prilagođena specifičnim potrebama.

## Pregled

Ova lekcija uvodi koncept klijenata unutar ekosustava Model Context Protocol (MCP). Naučit ćete kako napisati vlastiti klijent i povezati ga s MCP Serverom.

## Ciljevi učenja

Na kraju ove lekcije, bit ćete sposobni:

- Razumjeti što klijent može učiniti.
- Napisati vlastiti klijent.
- Povezati i testirati klijenta s MCP serverom kako biste osigurali da radi kako se očekuje.

## Što je potrebno za pisanje klijenta?

Da biste napisali klijenta, trebate učiniti sljedeće:

- **Importirati odgovarajuće biblioteke**. Koristit ćete istu biblioteku kao prije, samo različite konstrukte.
- **Instancirati klijenta**. To će uključivati stvaranje instance klijenta i povezivanje s odabranom metodom prijenosa.
- **Odlučiti koje resurse navesti**. Vaš MCP server dolazi s resursima, alatima i upitima, morate odlučiti koji želite navesti.
- **Integrirati klijenta u host aplikaciju**. Kada znate sposobnosti servera, trebate ih integrirati u vašu host aplikaciju kako bi, kada korisnik unese upit ili drugu naredbu, odgovarajuća značajka servera bila pozvana.

Sada kada razumijemo na visokoj razini što ćemo učiniti, pogledajmo primjer.

### Primjer klijenta

Pogledajmo ovaj primjer klijenta:
Trenirani ste na podacima do listopada 2023.

U prethodnom kodu:

- Importiramo biblioteke
- Kreiramo instancu klijenta i povezujemo ga koristeći stdio za prijenos.
- Navodimo upite, resurse i alate i pozivamo ih sve.

Evo ga, klijent koji može komunicirati s MCP Serverom.

Uzmimo vremena u sljedećem dijelu vježbe i rastavimo svaki dio koda i objasnimo što se događa.

## Vježba: Pisanje klijenta

Kao što je rečeno gore, uzmimo vremena objašnjavajući kod, i svakako kodirajte uz nas ako želite.

### -1- Importiranje biblioteka

Importirajmo biblioteke koje trebamo, trebat će nam reference na klijenta i na odabrani protokol prijenosa, stdio. stdio je protokol za stvari koje se trebaju pokrenuti na vašem lokalnom računalu. SSE je drugi protokol prijenosa koji ćemo pokazati u budućim poglavljima, ali to je vaša druga opcija. Za sada, nastavimo s stdio.

Idemo na instanciranje.

### -2- Instanciranje klijenta i prijenosa

Trebat ćemo kreirati instancu prijenosa i našeg klijenta:

### -3- Popis značajki servera

Sada imamo klijenta koji se može povezati ako se program pokrene. Međutim, zapravo ne navodi svoje značajke pa to učinimo sljedeće:

Odlično, sada smo uhvatili sve značajke. Sada je pitanje kada ih koristimo? Pa, ovaj klijent je prilično jednostavan, jednostavan u smislu da ćemo trebati eksplicitno pozvati značajke kada ih želimo. U sljedećem poglavlju kreirat ćemo napredniji klijent koji ima pristup vlastitom velikom jezičnom modelu, LLM. Za sada, pogledajmo kako možemo pozvati značajke na serveru:

### -4- Pozivanje značajki

Da bismo pozvali značajke, trebamo osigurati da specificiramo točne argumente i u nekim slučajevima naziv onoga što pokušavamo pozvati.

### -5- Pokretanje klijenta

Da biste pokrenuli klijenta, upišite sljedeću naredbu u terminal:

## Zadatak

U ovom zadatku, koristit ćete ono što ste naučili u kreiranju klijenta, ali kreirati vlastiti klijent.

Evo servera kojeg možete koristiti i kojeg trebate pozvati putem vašeg klijentskog koda, vidite možete li dodati više značajki serveru da bude zanimljiviji.

## Rješenje

[Rješenje](./solution/README.md)

## Ključne točke

Ključne točke za ovo poglavlje o klijentima su:

- Mogu se koristiti za otkrivanje i pozivanje značajki na serveru.
- Mogu pokrenuti server dok se sami pokreću (kao u ovom poglavlju), ali klijenti se mogu povezati i s pokrenutim serverima.
- Sjajan su način za testiranje sposobnosti servera uz alternative poput Inspectora kao što je opisano u prethodnom poglavlju.

## Dodatni resursi

- [Izrada klijenata u MCP](https://modelcontextprotocol.io/quickstart/client)

## Primjeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Što je sljedeće

- Sljedeće: [Kreiranje klijenta s LLM](/03-GettingStarted/03-llm-client/README.md)

**Odricanje odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge prevođenja [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne odgovaramo za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.