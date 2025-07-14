<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-13T20:02:44+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hr"
}
-->
Sada kada znamo malo više o SSE-u, izgradimo sljedeći SSE server.

## Vježba: Kreiranje SSE servera

Za kreiranje našeg servera, trebamo imati na umu dvije stvari:

- Moramo koristiti web server za izlaganje endpointa za konekciju i poruke.
- Izgraditi naš server kao i obično, koristeći alate, resurse i promptove kao što smo radili sa stdio.

### -1- Kreiranje instance servera

Za kreiranje servera koristimo iste tipove kao i sa stdio. Međutim, za transport trebamo odabrati SSE.

Dodajmo sljedeće potrebne rute.

### -2- Dodavanje ruta

Dodajmo rute koje upravljaju konekcijom i dolaznim porukama:

Dodajmo sada mogućnosti serveru.

### -3- Dodavanje mogućnosti serveru

Sada kada smo definirali sve što je specifično za SSE, dodajmo mogućnosti serveru poput alata, promptova i resursa.

Vaš kompletan kod trebao bi izgledati ovako:

Odlično, imamo server koji koristi SSE, idemo ga sada isprobati.

## Vježba: Debugiranje SSE servera pomoću Inspectora

Inspector je odličan alat koji smo vidjeli u prethodnoj lekciji [Kreiranje vašeg prvog servera](/03-GettingStarted/01-first-server/README.md). Pogledajmo možemo li koristiti Inspector i ovdje:

### -1- Pokretanje Inspectora

Da biste pokrenuli Inspector, prvo morate imati pokrenut SSE server, pa to učinimo sada:

1. Pokrenite server

1. Pokrenite Inspector

    > ![NOTE]
    > Pokrenite ovo u zasebnom terminalu od onog u kojem je server pokrenut. Također, imajte na umu da trebate prilagoditi donju naredbu URL-u na kojem vaš server radi.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Pokretanje Inspectora izgleda isto u svim runtime okruženjima. Primijetite kako umjesto da prosljeđujemo putanju do servera i naredbu za pokretanje servera, sada prosljeđujemo URL na kojem server radi i također specificiramo `/sse` rutu.

### -2- Isprobavanje alata

Povežite server odabirom SSE u padajućem izborniku i unesite URL na kojem vaš server radi, na primjer http:localhost:4321/sse. Zatim kliknite na gumb "Connect". Kao i prije, odaberite da prikažete alate, izaberite alat i unesite ulazne vrijednosti. Trebali biste vidjeti rezultat kao na slici ispod:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hr.png)

Odlično, možete raditi s Inspectorom, pogledajmo sada kako raditi s Visual Studio Codeom.

## Zadatak

Pokušajte proširiti svoj server s više mogućnosti. Pogledajte [ovu stranicu](https://api.chucknorris.io/) kako biste, na primjer, dodali alat koji poziva API. Vi odlučujete kako bi server trebao izgledati. Zabavite se :)

## Rješenje

[Rješenje](./solution/README.md) Evo mogućeg rješenja s radnim kodom.

## Ključne spoznaje

Ključne spoznaje iz ovog poglavlja su sljedeće:

- SSE je drugi podržani transport pored stdio.
- Za podršku SSE-u, morate upravljati dolaznim konekcijama i porukama koristeći web framework.
- Možete koristiti i Inspector i Visual Studio Code za korištenje SSE servera, baš kao i za stdio servere. Primijetite kako se malo razlikuje između stdio i SSE. Za SSE trebate zasebno pokrenuti server, a zatim pokrenuti alat Inspector. Također, za Inspector alat postoje razlike u tome da morate specificirati URL.

## Primjeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Što slijedi

- Sljedeće: [HTTP Streaming s MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo postići točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazume ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.