<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "64645691bf0985f1760b948123edf269",
  "translation_date": "2025-06-13T10:57:44+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "ro"
}
-->
Acum că știm puțin mai multe despre SSE, să construim următorul un server SSE.

## Exercițiu: Crearea unui server SSE

Pentru a crea serverul nostru, trebuie să ținem cont de două lucruri:

- Trebuie să folosim un server web pentru a expune endpoint-uri pentru conexiune și mesaje.
- Construim serverul așa cum facem de obicei cu unelte, resurse și prompturi atunci când foloseam stdio.

### -1- Crearea unei instanțe de server

Pentru a crea serverul, folosim aceleași tipuri ca la stdio. Totuși, pentru transport, trebuie să alegem SSE.

---

Să adăugăm următoarele rute necesare.

### -2- Adăugarea rutelor

Să adăugăm rute care gestionează conexiunea și mesajele primite:

---

Acum să adăugăm capabilități serverului.

### -3- Adăugarea capabilităților serverului

Acum că am definit tot ce ține de SSE, să adăugăm capabilități serverului, cum ar fi unelte, prompturi și resurse.

---

Codul complet ar trebui să arate astfel:

---

Perfect, avem un server care folosește SSE, să-l testăm acum.

## Exercițiu: Debugging unui server SSE cu Inspector

Inspector este un instrument excelent pe care l-am văzut în lecția anterioară [Crearea primului server](/03-GettingStarted/01-first-server/README.md). Să vedem dacă îl putem folosi și aici:

### -1- Rularea inspectorului

Pentru a rula inspectorul, trebuie mai întâi să ai un server SSE pornit, așa că să facem asta:

1. Pornește serverul

---

1. Pornește inspectorul

    > ![NOTE]
    > Rulează acest lucru într-o fereastră de terminal separată față de cea în care rulează serverul. De asemenea, trebuie să ajustezi comanda de mai jos pentru a se potrivi cu URL-ul unde serverul tău este pornit.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Rularea inspectorului arată la fel în toate mediile de execuție. Observă cum în loc să transmitem o cale către server și o comandă pentru pornirea serverului, transmitem URL-ul unde serverul este pornit și specificăm ruta `/sse`.

### -2- Testarea uneltei

Conectează serverul selectând SSE din lista derulantă și completează câmpul URL cu adresa unde serverul tău este pornit, de exemplu http://localhost:4321/sse. Apasă butonul "Connect". Ca înainte, selectează să listezi uneltele, alege o unealtă și oferă valori de intrare. Ar trebui să vezi un rezultat ca în imaginea de mai jos:

![Server SSE rulând în inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.ro.png)

Perfect, poți lucra cu inspectorul, să vedem acum cum putem lucra cu Visual Studio Code.

## Temă

Încearcă să extinzi serverul cu mai multe capabilități. Vezi [această pagină](https://api.chucknorris.io/) pentru a adăuga, de exemplu, o unealtă care apelează un API; tu decizi cum ar trebui să arate serverul. Distracție plăcută :)

## Soluție

[Soluție](./solution/README.md) Iată o posibilă soluție cu cod funcțional.

## Concluzii cheie

Concluziile din acest capitol sunt următoarele:

- SSE este al doilea tip de transport suportat, după stdio.
- Pentru a suporta SSE, trebuie să gestionezi conexiunile și mesajele primite folosind un framework web.
- Poți folosi atât Inspector cât și Visual Studio Code pentru a consuma servere SSE, la fel ca pentru serverele stdio. Observă cum diferă puțin față de stdio. Pentru SSE, trebuie să pornești serverul separat și apoi să rulezi instrumentul inspector. Pentru inspector există și unele diferențe, deoarece trebuie să specifici URL-ul.

## Exemple 

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../../../../03-GettingStarted/samples/javascript)
- [Calculator TypeScript](../../../../03-GettingStarted/samples/typescript)
- [Calculator Python](../../../../03-GettingStarted/samples/python) 

## Resurse suplimentare

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ce urmează

- Următorul: [Streaming HTTP cu MCP (HTTP Streamabil)](/03-GettingStarted/06-http-streaming/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autorizată. Pentru informații critice, se recomandă traducerea profesională realizată de un specialist uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite rezultate din utilizarea acestei traduceri.