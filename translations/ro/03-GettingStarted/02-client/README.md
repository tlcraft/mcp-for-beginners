<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:52:48+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ro"
}
-->
În codul precedent am:

- Importat bibliotecile
- Creat o instanță a unui client și conectat-o folosind stdio pentru transport.
- Listat prompturi, resurse și unelte și le-am invocat pe toate.

Așadar, iată un client care poate comunica cu un MCP Server.

Să ne luăm timpul în secțiunea următoare de exerciții pentru a analiza fiecare fragment de cod și a explica ce se întâmplă.

## Exercițiu: Scrierea unui client

Așa cum am spus mai sus, să ne luăm timpul să explicăm codul, și, desigur, puteți să scrieți codul în paralel dacă doriți.

### -1- Importarea bibliotecilor

Să importăm bibliotecile de care avem nevoie; vom avea nevoie de referințe la un client și la protocolul de transport ales, stdio. stdio este un protocol pentru lucruri care rulează pe mașina locală. SSE este un alt protocol de transport pe care îl vom arăta în capitolele viitoare, dar acesta este cealaltă opțiune. Pentru moment, să continuăm cu stdio.

Să trecem la instanțiere.

### -2- Instanțierea clientului și a transportului

Va trebui să creăm o instanță a transportului și una a clientului nostru:

### -3- Listarea funcționalităților serverului

Acum avem un client care se poate conecta dacă programul este rulat. Totuși, acesta nu listează efectiv funcționalitățile, așa că să facem asta acum:

Perfect, acum am capturat toate funcționalitățile. Întrebarea este când le folosim? Ei bine, acest client este destul de simplu, în sensul că va trebui să apelăm explicit funcționalitățile atunci când le dorim. În capitolul următor vom crea un client mai avansat care are acces la propriul său model de limbaj mare, LLM. Pentru moment, să vedem cum putem invoca funcționalitățile de pe server:

### -4- Invocarea funcționalităților

Pentru a invoca funcționalitățile, trebuie să ne asigurăm că specificăm argumentele corecte și, în unele cazuri, numele a ceea ce încercăm să invocăm.

### -5- Rularea clientului

Pentru a rula clientul, tastați următoarea comandă în terminal:

## Tema

În această temă, vei folosi ceea ce ai învățat despre crearea unui client pentru a-ți crea propriul client.

Iată un server pe care îl poți folosi și pe care trebuie să îl apelezi prin codul clientului tău; vezi dacă poți adăuga mai multe funcționalități serverului pentru a-l face mai interesant.

## Soluție

[Soluție](./solution/README.md)

## Aspecte importante

Aspectele importante din acest capitol despre clienți sunt următoarele:

- Pot fi folosiți atât pentru a descoperi, cât și pentru a invoca funcționalități pe server.
- Pot porni un server în timp ce se pornesc singuri (ca în acest capitol), dar clienții se pot conecta și la servere deja în funcțiune.
- Sunt o modalitate excelentă de a testa capabilitățile serverului, alături de alternative precum Inspector, așa cum a fost descris în capitolul anterior.

## Resurse suplimentare

- [Construirea clienților în MCP](https://modelcontextprotocol.io/quickstart/client)

## Exemple

- [Calculator Java](../samples/java/calculator/README.md)
- [Calculator .Net](../../../../03-GettingStarted/samples/csharp)
- [Calculator JavaScript](../samples/javascript/README.md)
- [Calculator TypeScript](../samples/typescript/README.md)
- [Calculator Python](../../../../03-GettingStarted/samples/python)

## Ce urmează

- Următorul: [Crearea unui client cu un LLM](/03-GettingStarted/03-llm-client/README.md)

**Declinare a responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim pentru acuratețe, vă rugăm să rețineți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă trebuie considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională realizată de un traducător uman. Nu ne asumăm responsabilitatea pentru eventualele neînțelegeri sau interpretări greșite care pot apărea din utilizarea acestei traduceri.