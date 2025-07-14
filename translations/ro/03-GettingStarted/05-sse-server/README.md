<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-13T20:01:34+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ro"
}
-->
Acum că știm puțin mai multe despre SSE, să construim următor un server SSE.

## Exercițiu: Crearea unui server SSE

Pentru a crea serverul nostru, trebuie să ținem cont de două lucruri:

- Trebuie să folosim un server web pentru a expune endpoint-uri pentru conexiune și mesaje.
- Construim serverul așa cum facem de obicei, cu unelte, resurse și prompturi, așa cum am făcut când foloseam stdio.

### -1- Crearea unei instanțe de server

Pentru a crea serverul, folosim aceleași tipuri ca la stdio. Totuși, pentru transport, trebuie să alegem SSE.

Să adăugăm acum rutele necesare.

### -2- Adăugarea rutelor

Să adăugăm rute care să gestioneze conexiunea și mesajele primite:

Să adăugăm acum capabilități serverului.

### -3- Adăugarea capabilităților serverului

Acum că am definit tot ce ține de SSE, să adăugăm capabilități serverului, cum ar fi unelte, prompturi și resurse.

Codul complet ar trebui să arate astfel:

Minunat, avem un server care folosește SSE, să-l testăm acum.

## Exercițiu: Debugging unui server SSE cu Inspector

Inspector este un instrument grozav pe care l-am văzut într-o lecție anterioară [Crearea primului tău server](/03-GettingStarted/01-first-server/README.md). Să vedem dacă putem folosi Inspector și aici:

### -1- Pornirea inspectorului

Pentru a porni inspectorul, trebuie mai întâi să ai un server SSE pornit, așa că să facem asta acum:

1. Pornește serverul

1. Pornește inspectorul

    > ![NOTE]
    > Rulează acest lucru într-o fereastră de terminal separată față de cea în care rulează serverul. De asemenea, reține că trebuie să ajustezi comanda de mai jos pentru a se potrivi cu URL-ul unde rulează serverul tău.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Pornirea inspectorului arată la fel în toate mediile de rulare. Observă cum, în loc să trecem un path către server și o comandă pentru pornirea serverului, trecem URL-ul unde serverul rulează și specificăm ruta `/sse`.

### -2- Testarea uneltei

Conectează serverul selectând SSE din lista derulantă și completează câmpul URL cu adresa unde rulează serverul tău, de exemplu http://localhost:4321/sse. Acum apasă butonul „Connect”. Ca înainte, selectează să listezi uneltele, alege o unealtă și oferă valorile de intrare. Ar trebui să vezi un rezultat ca în imaginea de mai jos:

![Server SSE rulând în inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ro.png)

Minunat, poți lucra cu inspectorul, să vedem acum cum putem lucra cu Visual Studio Code.

## Tema

Încearcă să extinzi serverul cu mai multe capabilități. Vezi [această pagină](https://api.chucknorris.io/) pentru a adăuga, de exemplu, o unealtă care apelează un API. Tu decizi cum ar trebui să arate serverul. Distracție plăcută :)

## Soluție

[Soluție](./solution/README.md) Iată o posibilă soluție cu cod funcțional.

## Concluzii cheie

Concluziile cheie din acest capitol sunt următoarele:

- SSE este al doilea tip de transport suportat, pe lângă stdio.
- Pentru a suporta SSE, trebuie să gestionezi conexiunile și mesajele primite folosind un framework web.
- Poți folosi atât Inspector, cât și Visual Studio Code pentru a consuma un server SSE, la fel ca serverele stdio. Observă cum diferă puțin între stdio și SSE. Pentru SSE, trebuie să pornești serverul separat și apoi să rulezi unealta inspector. Pentru unealta inspector, există și diferențe în sensul că trebuie să specifici URL-ul.

## Exemple

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../samples/javascript/README.md)
- [Calculator TypeScript](../samples/typescript/README.md)
- [Calculator Python](../../../../03-GettingStarted/samples/python)

## Resurse suplimentare

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ce urmează

- Următorul: [HTTP Streaming cu MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Declinare de responsabilitate**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm răspunderea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.