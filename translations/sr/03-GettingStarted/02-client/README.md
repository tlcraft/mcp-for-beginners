<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:53:42+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "sr"
}
-->
U prethodnom kodu smo:

- Uvezli biblioteke
- Kreirali instancu klijenta i povezali je koristeći stdio kao transport.
- Izlistali promptove, resurse i alate i pozvali ih sve.

Eto, imate klijenta koji može da komunicira sa MCP Serverom.

U sledećem delu vežbe ćemo polako razložiti svaki deo koda i objasniti šta se dešava.

## Vežba: Pisanje klijenta

Kao što je rečeno, hajde da polako objasnimo kod, i slobodno kodirajte zajedno ako želite.

### -1- Uvoz biblioteka

Uvešćemo biblioteke koje su nam potrebne, biće nam potrebne reference na klijenta i na izabrani transportni protokol, stdio. stdio je protokol za stvari koje treba da rade na vašem lokalnom računaru. SSE je drugi transportni protokol koji ćemo pokazati u budućim poglavljima, ali to je vaša druga opcija. Za sada, nastavimo sa stdio.

Hajde da pređemo na instanciranje.

### -2- Instanciranje klijenta i transporta

Trebaće nam da kreiramo instancu transporta i instancu našeg klijenta:

### -3- Izlistavanje funkcija servera

Sada imamo klijenta koji može da se poveže ako se program pokrene. Međutim, on zapravo ne izlistava njegove funkcije, pa hajde to sada da uradimo:

Sjajno, sada smo uhvatili sve funkcije. Sada se postavlja pitanje kada ih koristimo? Pa, ovaj klijent je prilično jednostavan, u smislu da ćemo morati eksplicitno da pozovemo funkcije kada ih želimo. U sledećem poglavlju kreiraćemo naprednijeg klijenta koji ima pristup sopstvenom velikom jezičkom modelu, LLM. Za sada, hajde da vidimo kako možemo pozvati funkcije na serveru:

### -4- Pozivanje funkcija

Da bismo pozvali funkcije, moramo biti sigurni da navodimo ispravne argumente i u nekim slučajevima ime onoga što pokušavamo da pozovemo.

### -5- Pokretanje klijenta

Da biste pokrenuli klijenta, otkucajte sledeću komandu u terminalu:

## Zadatak

U ovom zadatku koristićete ono što ste naučili o kreiranju klijenta, ali napravite svog klijenta.

Evo servera koji možete koristiti, a koji treba da pozovete putem koda svog klijenta, vidite da li možete dodati više funkcija serveru da bi bio zanimljiviji.

## Rešenje

[Rešenje](./solution/README.md)

## Ključni zaključci

Ključni zaključci za ovo poglavlje u vezi sa klijentima su sledeći:

- Mogu se koristiti i za otkrivanje i za pozivanje funkcija na serveru.
- Mogu pokrenuti server dok sami počinju (kao u ovom poglavlju), ali klijenti se mogu povezati i na već pokrenute servere.
- Odličan su način da se testiraju mogućnosti servera pored alternativa kao što je Inspector, kako je opisano u prethodnom poglavlju.

## Dodatni resursi

- [Pravljenje klijenata u MCP](https://modelcontextprotocol.io/quickstart/client)

## Primeri

- [Java Kalkulator](../samples/java/calculator/README.md)
- [.Net Kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Kalkulator](../samples/javascript/README.md)
- [TypeScript Kalkulator](../samples/typescript/README.md)
- [Python Kalkulator](../../../../03-GettingStarted/samples/python)

## Šta sledi

- Sledeće: [Kreiranje klijenta sa LLM-om](/03-GettingStarted/03-llm-client/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korišćenjem AI prevodilačke usluge [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo tačnosti, imajte na umu da automatski prevodi mogu sadržati greške ili netačnosti. Originalni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja nastala korišćenjem ovog prevoda.