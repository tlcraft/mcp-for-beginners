<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:54:06+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hr"
}
-->
U prethodnom kodu mi smo:

- Uvezli biblioteke
- Kreirali instancu klijenta i povezali je koristeći stdio za transport.
- Izlistali promptove, resurse i alate te ih sve pozvali.

Eto ga, klijent koji može komunicirati s MCP serverom.

U sledećem delu vežbe ćemo polako razložiti svaki deo koda i objasniti šta se tačno dešava.

## Vežba: Pisanje klijenta

Kao što je već rečeno, uzmimo vremena da objasnimo kod, i svakako slobodno kucajte kod zajedno sa nama ako želite.

### -1- Uvoz biblioteka

Uvezimo biblioteke koje su nam potrebne, biće nam potrebne reference na klijenta i na odabrani transportni protokol, stdio. stdio je protokol namenjen za stvari koje se izvršavaju na vašem lokalnom računaru. SSE je drugi transportni protokol koji ćemo prikazati u budućim poglavljima, ali to je vaša druga opcija. Za sada, nastavimo sa stdio. 

Krenimo dalje sa instanciranjem.

### -2- Instanciranje klijenta i transporta

Trebaće nam da kreiramo instancu transporta i instancu našeg klijenta:

### -3- Izlistavanje funkcionalnosti servera

Sada imamo klijenta koji se može povezati kada se program pokrene. Međutim, on zapravo ne izlistava svoje funkcionalnosti, pa hajde to sada da uradimo:

Odlično, sada smo uhvatili sve funkcionalnosti. Sada se postavlja pitanje kada ćemo ih koristiti? Pa, ovaj klijent je prilično jednostavan, u smislu da ćemo morati eksplicitno da pozovemo funkcionalnosti kada ih želimo koristiti. U sledećem poglavlju ćemo kreirati naprednijeg klijenta koji ima pristup sopstvenom velikom jezičkom modelu, LLM. Za sada, hajde da vidimo kako možemo pozvati funkcionalnosti na serveru:

### -4- Pozivanje funkcionalnosti

Da bismo pozvali funkcionalnosti, moramo biti sigurni da specificiramo ispravne argumente i u nekim slučajevima ime onoga što pokušavamo da pozovemo.

### -5- Pokretanje klijenta

Da biste pokrenuli klijenta, otkucajte sledeću komandu u terminalu:

## Zadatak

U ovom zadatku ćete iskoristiti ono što ste naučili o kreiranju klijenta, ali napraviti sopstvenog klijenta.

Evo servera koji možete koristiti, a kome treba pristupiti putem vašeg klijentskog koda, pokušajte da dodate još funkcionalnosti serveru kako bi bio zanimljiviji.

## Rešenje

[Rešenje](./solution/README.md)

## Ključne poruke

Ključne poruke ovog poglavlja u vezi sa klijentima su sledeće:

- Mogu se koristiti kako za otkrivanje, tako i za pozivanje funkcionalnosti na serveru.
- Mogu pokrenuti server dok se sami pokreću (kao u ovom poglavlju), ali klijenti se mogu povezivati i na već pokrenute servere.
- Izvrstan su način da se testiraju mogućnosti servera, pored alternativa kao što je Inspector, kako je opisano u prethodnom poglavlju.

## Dodatni resursi

- [Kreiranje klijenata u MCP](https://modelcontextprotocol.io/quickstart/client)

## Primeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Šta sledi

- Sledeće: [Kreiranje klijenta sa LLM](/03-GettingStarted/03-llm-client/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument preveden je pomoću AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.