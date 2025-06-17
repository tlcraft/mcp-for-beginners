<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1681ca3633aeb49ee03766abdbb94a93",
  "translation_date": "2025-06-17T22:31:51+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "hr"
}
-->
Sada kada znamo malo više o SSE-u, sljedeće ćemo izgraditi SSE server.

## Vježba: Kreiranje SSE Servera

Za kreiranje našeg servera, trebamo imati na umu dvije stvari:

- Moramo koristiti web server za izlaganje endpointa za vezu i poruke.
- Izgraditi naš server kao i obično, koristeći alate, resurse i upite kao kad smo koristili stdio.

### -1- Kreiranje instance servera

Za kreiranje servera koristimo iste tipove kao i kod stdio. Međutim, za transport trebamo odabrati SSE.

Dodajmo sada potrebne rute.

### -2- Dodavanje ruta

Dodajmo rute koje će upravljati vezom i dolaznim porukama:

Dodajmo sada mogućnosti serveru.

### -3- Dodavanje mogućnosti serveru

Sada kada smo definirali sve što je specifično za SSE, dodajmo mogućnosti serveru poput alata, upita i resursa.

Vaš kompletan kod trebao bi izgledati ovako:

Odlično, imamo server koji koristi SSE, idemo ga sada isprobati.

## Vježba: Debugiranje SSE Servera pomoću Inspectora

Inspector je sjajan alat koji smo vidjeli u prethodnoj lekciji [Kreiranje vašeg prvog servera](/03-GettingStarted/01-first-server/README.md). Pogledajmo možemo li ga koristiti i ovdje:

### -1- Pokretanje Inspectora

Da biste pokrenuli Inspectora, prvo morate imati pokrenut SSE server, pa to učinimo sada:

1. Pokrenite server

1. Pokrenite Inspectora

    > ![NOTE]
    > Pokrenite ovo u zasebnom terminal prozoru od onog u kojem je pokrenut server. Također, imajte na umu da trebate prilagoditi donju naredbu URL-u na kojem vaš server radi.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Pokretanje Inspectora izgleda isto u svim runtime okruženjima. Primijetite kako umjesto da prosljeđujemo putanju do našeg servera i naredbu za njegovo pokretanje, sada prosljeđujemo URL na kojem server radi i također specificiramo `/sse` rutu.

### -2- Isprobavanje alata

Povežite server odabirom SSE iz padajućeg izbornika i unesite URL na kojem vaš server radi, na primjer http:localhost:4321/sse. Sada kliknite na gumb "Connect". Kao i prije, odaberite da prikažete alate, izaberite alat i unesite ulazne vrijednosti. Trebali biste vidjeti rezultat kao na slici ispod:

![SSE Server running in inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.hr.png)

Odlično, možete raditi s Inspectorom, pogledajmo sada kako možemo raditi s Visual Studio Codeom.

## Zadatak

Pokušajte proširiti vaš server s više mogućnosti. Pogledajte [ovu stranicu](https://api.chucknorris.io/) kako biste, na primjer, dodali alat koji poziva API. Vi odlučujete kako bi server trebao izgledati. Zabavite se :)

## Rješenje

[Rješenje](./solution/README.md) Evo jednog mogućeg rješenja s funkcionalnim kodom.

## Ključne poruke

Ključne poruke iz ovog poglavlja su sljedeće:

- SSE je drugi podržani transport uz stdio.
- Da biste podržali SSE, morate upravljati dolaznim vezama i porukama koristeći web framework.
- Možete koristiti i Inspector i Visual Studio Code za konzumiranje SSE servera, kao i za stdio servere. Primijetite kako se malo razlikuje između stdio i SSE. Za SSE trebate posebno pokrenuti server, a zatim pokrenuti vaš Inspector alat. Za Inspector alat postoje i neke razlike u tome što morate specificirati URL.

## Primjeri

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Dodatni resursi

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Što slijedi

- Sljedeće: [HTTP Streaming s MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Odricanje od odgovornosti**:  
Ovaj je dokument preveden korištenjem AI usluge za prevođenje [Co-op Translator](https://github.com/Azure/co-op-translator). Iako težimo točnosti, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba se smatrati službenim i autoritativnim izvorom. Za kritične informacije preporučuje se profesionalni ljudski prijevod. Ne snosimo odgovornost za bilo kakva nesporazumevanja ili pogrešna tumačenja koja proizlaze iz korištenja ovog prijevoda.