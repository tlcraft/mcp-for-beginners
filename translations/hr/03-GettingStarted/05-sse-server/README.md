<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-13T01:20:20+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hr"
}
-->
Sad kad znamo malo više o SSE-u, idemo sada izgraditi SSE server.

## Vježba: Kreiranje SSE servera

Da bismo napravili naš server, moramo imati na umu dvije stvari:

- Potrebno je koristiti web server za izlaganje endpointa za konekciju i poruke.
- Izgraditi server kao i obično, koristeći alate, resurse i promptove kao što smo radili sa stdio.

### -1- Kreiranje instance servera

Za kreiranje servera koristimo iste tipove kao kod stdio. Međutim, za transport moramo odabrati SSE.

Dodajmo sada potrebne rute.

### -2- Dodavanje ruta

Dodajmo rute koje upravljaju konekcijom i dolaznim porukama:

Dodajmo sada mogućnosti serveru.

### -3- Dodavanje mogućnosti serveru

Sada kada smo definirali sve što je specifično za SSE, dodajmo mogućnosti serveru poput alata, promptova i resursa.

Vaš kompletan kod trebao bi izgledati ovako:

Odlično, imamo server koji koristi SSE, idemo ga sada isprobati.

## Vježba: Debugiranje SSE servera pomoću Inspectora

Inspector je odličan alat koji smo vidjeli u prethodnoj lekciji [Kreiranje vašeg prvog servera](/03-GettingStarted/01-first-server/README.md). Pogledajmo možemo li ga koristiti i ovdje:

### -1- Pokretanje Inspectora

Da biste pokrenuli Inspector, prvo morate imati pokrenut SSE server, pa učinimo to sada:

1. Pokrenite server

1. Pokrenite Inspector

    > ![NOTE]
    > Pokrenite ovaj naredbeni redak u zasebnom terminalu od onog u kojem se pokreće server. Također, imajte na umu da trebate prilagoditi naredbu ispod kako bi odgovarala URL-u na kojem vaš server radi.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Pokretanje Inspectora izgleda isto u svim runtime okruženjima. Primijetite da umjesto da prosljeđujemo putanju do servera i naredbu za pokretanje servera, prosljeđujemo URL na kojem server radi i također specificiramo `/sse` rutu.

### -2- Isprobavanje alata

Povežite server odabirom SSE iz padajućeg izbornika i upišite URL na kojem vaš server radi, na primjer http:localhost:4321/sse. Sada kliknite na gumb "Connect". Kao i prije, odaberite da listate alate, odaberite alat i unesite ulazne vrijednosti. Trebali biste vidjeti rezultat kao na slici ispod:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hr.png)

Super, možete raditi s Inspectorom, pogledajmo sada kako raditi s Visual Studio Code.

## Zadatak

Pokušajte proširiti svoj server s više mogućnosti. Pogledajte [ovu stranicu](https://api.chucknorris.io/) kako biste, na primjer, dodali alat koji poziva API, vi odlučujete kako server treba izgledati. Zabavite se :)

## Rješenje

[Rješenje](./solution/README.md) Evo jednog mogućeg rješenja s radnim kodom.

## Ključni zaključci

Zaključci iz ovog poglavlja su sljedeći:

- SSE je drugi podržani transport pored stdio.
- Za podršku SSE-u, morate upravljati dolaznim konekcijama i porukama koristeći web framework.
- Možete koristiti i Inspector i Visual Studio Code za korištenje SSE servera, baš kao i stdio servera. Primijetite da postoji mala razlika između stdio i SSE. Za SSE trebate posebno pokrenuti server, a zatim pokrenuti alat Inspector. Za Inspector alat postoje i razlike u tome što morate specificirati URL.

## Primjeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Što slijedi

- Sljedeće: [HTTP Streaming with MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI prevoditeljskog servisa [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba se smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Nismo odgovorni za bilo kakve nesporazume ili kriva tumačenja koja proizlaze iz korištenja ovog prijevoda.