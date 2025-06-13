<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "3dd2f1e39277c31b0e57e29d165354d6",
  "translation_date": "2025-06-12T23:12:18+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "mo"
}
-->
Acum că știm puțin mai multe despre SSE, să construim următorul un server SSE.

## Exercițiu: Crearea unui server SSE

Pentru a crea serverul nostru, trebuie să avem în vedere două lucruri:

- Trebuie să folosim un server web pentru a expune endpoint-uri pentru conexiune și mesaje.
- Construim serverul așa cum facem de obicei, folosind unelte, resurse și prompturi, așa cum făceam cu stdio.

### -1- Crearea unei instanțe de server

Pentru a crea serverul, folosim aceleași tipuri ca la stdio. Totuși, pentru transport, trebuie să alegem SSE.

Să adăugăm următor rutele necesare.

### -2- Adăugarea rutelor

Să adăugăm rute care să gestioneze conexiunea și mesajele primite:

Să adăugăm acum capabilități serverului.

### -3- Adăugarea capabilităților serverului

Acum că am definit tot ce ține de SSE, să adăugăm capabilități serverului, cum ar fi unelte, prompturi și resurse.

Codul complet ar trebui să arate astfel:

Minunat, avem un server care folosește SSE, să-l testăm acum.

## Exercițiu: Debugging unui server SSE cu Inspector

Inspector este un instrument grozav pe care l-am văzut într-o lecție anterioară [Crearea primului server](/03-GettingStarted/01-first-server/README.md). Să vedem dacă îl putem folosi și aici:

### -1- Pornirea inspectorului

Pentru a porni inspectorul, trebuie mai întâi să ai un server SSE pornit, așa că să facem asta:

1. Pornește serverul

1. Pornește inspectorul

    > ![NOTE]
    > Rulează această comandă într-un terminal diferit față de cel în care rulează serverul. De asemenea, trebuie să adaptezi comanda de mai jos pentru URL-ul la care serverul tău rulează.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

    Pornirea inspectorului arată la fel în toate mediile de execuție. Observă că în loc să indicăm calea către server și o comandă pentru pornirea serverului, indicăm URL-ul unde serverul rulează și specificăm ruta `/sse`.

### -2- Testarea uneltei

Conectează serverul selectând SSE din lista derulantă și completează câmpul URL cu adresa unde serverul tău rulează, de exemplu http:localhost:4321/sse. Apoi apasă butonul "Connect". Ca înainte, selectează să listezi uneltele, alege o unealtă și oferă valorile de input. Ar trebui să vezi un rezultat ca cel de mai jos:

![Server SSE rulând în inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.mo.png)

Minunat, poți lucra cu inspectorul, să vedem acum cum putem folosi Visual Studio Code.

## Temă

Încearcă să extinzi serverul cu mai multe capabilități. Vezi [această pagină](https://api.chucknorris.io/) pentru a adăuga, de exemplu, o unealtă care apelează un API, tu decizi cum ar trebui să arate serverul. Distracție plăcută :)

## Soluție

[Soluție](./solution/README.md) Iată o posibilă soluție cu cod funcțional.

## Aspecte importante

Aspectele importante din acest capitol sunt:

- SSE este al doilea tip de transport suportat după stdio.
- Pentru a susține SSE, trebuie să gestionezi conexiunile și mesajele primite folosind un framework web.
- Poți folosi atât Inspector cât și Visual Studio Code pentru a consuma serverul SSE, la fel ca pentru serverele stdio. Observă diferențele dintre stdio și SSE. Pentru SSE, trebuie să pornești serverul separat și apoi să rulezi unealta inspector. De asemenea, pentru unealta inspector trebuie să specifici URL-ul.

## Exemple

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../../../../03-GettingStarted/samples/javascript)
- [Calculator TypeScript](../../../../03-GettingStarted/samples/typescript)
- [Calculator Python](../../../../03-GettingStarted/samples/python)

## Resurse suplimentare

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Ce urmează

- Următorul: [Streaming HTTP cu MCP (Streamable HTTP)](/03-GettingStarted/06-http-streaming/README.md)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.

---

(Note: "mo" is not a recognized language code or language name in my training data. Could you please clarify which language you mean by "mo"? For example, "mo" might refer to Moldovan, but Moldovan is essentially Romanian. If you meant something else, please specify.)