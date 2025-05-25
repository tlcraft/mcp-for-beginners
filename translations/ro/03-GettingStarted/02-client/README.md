<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:48:56+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "ro"
}
-->
# Crearea unui client

Clienții sunt aplicații sau scripturi personalizate care comunică direct cu un server MCP pentru a solicita resurse, instrumente și solicitări. Spre deosebire de utilizarea instrumentului de inspector, care oferă o interfață grafică pentru interacțiunea cu serverul, scrierea propriului client permite interacțiuni programatice și automatizate. Acest lucru permite dezvoltatorilor să integreze capacitățile MCP în propriile fluxuri de lucru, să automatizeze sarcini și să construiască soluții personalizate adaptate nevoilor specifice.

## Prezentare generală

Această lecție introduce conceptul de clienți în cadrul ecosistemului Model Context Protocol (MCP). Veți învăța cum să scrieți propriul client și să îl conectați la un server MCP.

## Obiective de învățare

Până la sfârșitul acestei lecții, veți fi capabil să:

- Înțelegeți ce poate face un client.
- Scrieți propriul client.
- Conectați și testați clientul cu un server MCP pentru a vă asigura că acesta funcționează conform așteptărilor.

## Ce implică scrierea unui client?

Pentru a scrie un client, va trebui să faceți următoarele:

- **Importați bibliotecile corecte**. Veți folosi aceeași bibliotecă ca înainte, doar construcții diferite.
- **Instanțiați un client**. Acest lucru va implica crearea unei instanțe de client și conectarea acesteia la metoda de transport aleasă.
- **Decideți ce resurse să listați**. Serverul MCP vine cu resurse, instrumente și solicitări, trebuie să decideți pe care să le listați.
- **Integrați clientul într-o aplicație gazdă**. Odată ce cunoașteți capacitățile serverului, trebuie să integrați acest lucru în aplicația gazdă astfel încât, dacă un utilizator tastează o solicitare sau altă comandă, caracteristica corespunzătoare a serverului să fie invocată.

Acum că înțelegem la nivel înalt ce urmează să facem, să vedem un exemplu în continuare.

### Un exemplu de client

Să aruncăm o privire asupra acestui exemplu de client:
Ești antrenat pe date până în octombrie 2023.

În codul precedent noi:

- Importăm bibliotecile
- Creăm o instanță a unui client și o conectăm folosind stdio pentru transport.
- Listăm solicitările, resursele și instrumentele și le invocăm pe toate.

Iată-l, un client care poate comunica cu un server MCP.

Să ne acordăm timp în secțiunea următoare de exerciții și să descompunem fiecare fragment de cod și să explicăm ce se întâmplă.

## Exercițiu: Scrierea unui client

Așa cum am spus mai sus, să ne acordăm timp explicând codul și, cu siguranță, să codificăm dacă doriți.

### -1- Importați bibliotecile

Să importăm bibliotecile de care avem nevoie, vom avea nevoie de referințe la un client și la protocolul de transport ales, stdio. stdio este un protocol pentru lucruri menite să ruleze pe mașina ta locală. SSE este un alt protocol de transport pe care îl vom arăta în capitolele viitoare, dar aceasta este cealaltă opțiune a ta. Pentru moment însă, să continuăm cu stdio.

Să trecem la instanțiere.

### -2- Instanțierea clientului și transportului

Va trebui să creăm o instanță a transportului și a clientului nostru:

### -3- Listarea caracteristicilor serverului

Acum, avem un client care se poate conecta dacă programul este rulat. Totuși, nu listează de fapt caracteristicile sale, așa că să facem asta în continuare:

Grozav, acum am capturat toate caracteristicile. Acum întrebarea este când le folosim? Ei bine, acest client este destul de simplu, simplu în sensul că va trebui să apelăm explicit caracteristicile atunci când le dorim. În capitolul următor, vom crea un client mai avansat care are acces la propriul model de limbaj mare, LLM. Deocamdată însă, să vedem cum putem invoca caracteristicile pe server:

### -4- Invocarea caracteristicilor

Pentru a invoca caracteristicile, trebuie să ne asigurăm că specificăm argumentele corecte și, în unele cazuri, numele a ceea ce încercăm să invocăm.

### -5- Rularea clientului

Pentru a rula clientul, tastați următoarea comandă în terminal:

## Temă

În această temă, veți folosi ceea ce ați învățat în crearea unui client, dar veți crea un client al vostru.

Iată un server pe care îl puteți folosi și pe care trebuie să îl apelați prin codul clientului vostru, vedeți dacă puteți adăuga mai multe caracteristici serverului pentru a-l face mai interesant.

## Soluție

[Soluție](./solution/README.md)

## Concluzii cheie

Concluziile cheie pentru acest capitol sunt următoarele despre clienți:

- Pot fi folosiți atât pentru a descoperi, cât și pentru a invoca caracteristici pe server.
- Pot porni un server în timp ce se pornesc ei înșiși (ca în acest capitol), dar clienții se pot conecta și la servere în funcțiune.
- Este o modalitate excelentă de a testa capacitățile serverului pe lângă alternativele precum Inspectorul, așa cum a fost descris în capitolul anterior.

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

**Declinarea responsabilității**:  
Acest document a fost tradus folosind serviciul de traducere AI [Co-op Translator](https://github.com/Azure/co-op-translator). Deși ne străduim să asigurăm acuratețea, vă rugăm să fiți conștienți că traducerile automate pot conține erori sau inexactități. Documentul original în limba sa nativă ar trebui considerat sursa autoritară. Pentru informații critice, se recomandă traducerea profesională umană. Nu suntem responsabili pentru neînțelegerile sau interpretările greșite care pot apărea din utilizarea acestei traduceri.