<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-04T19:07:40+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "hr"
}
-->
U prethodnom kodu smo:

- Uvezli biblioteke
- Kreirali instancu klijenta i povezali je koristeći stdio kao transport.
- Izlistali promptove, resurse i alate te ih sve pozvali.

Eto ga, klijent koji može komunicirati s MCP Serverom.

U sljedećem dijelu vježbe ćemo polako razložiti svaki dio koda i objasniti što se događa.

## Vježba: Pisanje klijenta

Kao što je rečeno, uzet ćemo si vremena za objašnjenje koda, i svakako slobodno kodirajte zajedno ako želite.

### -1- Uvoz biblioteka

Uvezimo potrebne biblioteke, trebat će nam reference na klijenta i na odabrani transportni protokol, stdio. stdio je protokol za stvari koje se izvode na vašem lokalnom računalu. SSE je drugi transportni protokol koji ćemo pokazati u budućim poglavljima, ali to je vaša druga opcija. Za sada nastavljamo sa stdio.

Krenimo na instanciranje.

### -2- Instanciranje klijenta i transporta

Trebat ćemo kreirati instancu transporta i instancu našeg klijenta:

### -3- Izlistavanje značajki servera

Sada imamo klijenta koji se može povezati ako se program pokrene. Međutim, on zapravo ne izlistava svoje značajke, pa to napravimo sada:

Odlično, sada smo dohvatili sve značajke. Sad se postavlja pitanje – kada ih koristimo? Ovaj klijent je prilično jednostavan, u smislu da ćemo morati eksplicitno pozvati značajke kad ih želimo koristiti. U sljedećem poglavlju ćemo napraviti naprednijeg klijenta koji ima pristup vlastitom velikom jezičnom modelu (LLM). Za sada, pogledajmo kako možemo pozvati značajke na serveru:

### -4- Pozivanje značajki

Da bismo pozvali značajke, moramo osigurati da navedemo ispravne argumente i u nekim slučajevima ime onoga što želimo pozvati.

### -5- Pokretanje klijenta

Da biste pokrenuli klijenta, upišite sljedeću naredbu u terminal:

## Zadatak

U ovom zadatku iskoristit ćete ono što ste naučili o stvaranju klijenta, ali napravite vlastitog klijenta.

Evo servera kojeg možete koristiti i kojem trebate pristupiti putem svog klijentskog koda, pokušajte dodati više značajki serveru kako bi bio zanimljiviji.

## Rješenje

[Rješenje](./solution/README.md)

## Ključne spoznaje

Ključne spoznaje za ovo poglavlje o klijentima su sljedeće:

- Mogu se koristiti i za otkrivanje i za pozivanje značajki na serveru.
- Mogu pokrenuti server dok se sami pokreću (kao u ovom poglavlju), ali klijenti se mogu povezati i na već pokrenute servere.
- Izvrsni su za testiranje mogućnosti servera uz alternative poput Inspektora, kako je opisano u prethodnom poglavlju.

## Dodatni resursi

- [Izrada klijenata u MCP-u](https://modelcontextprotocol.io/quickstart/client)

## Primjeri

- [Java kalkulator](../samples/java/calculator/README.md)
- [.Net kalkulator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript kalkulator](../samples/javascript/README.md)
- [TypeScript kalkulator](../samples/typescript/README.md)
- [Python kalkulator](../../../../03-GettingStarted/samples/python)

## Što slijedi

- Sljedeće: [Izrada klijenta s LLM-om](../03-llm-client/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazuma ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.