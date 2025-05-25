<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a9c3ca25df37dbb4c1518174fc415ce1",
  "translation_date": "2025-05-17T09:37:22+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "it"
}
-->
# Creare un client

I client sono applicazioni personalizzate o script che comunicano direttamente con un server MCP per richiedere risorse, strumenti e prompt. A differenza dell'utilizzo dello strumento inspector, che fornisce un'interfaccia grafica per interagire con il server, scrivere il proprio client consente interazioni programmatiche e automatizzate. Questo permette agli sviluppatori di integrare le capacità di MCP nei propri flussi di lavoro, automatizzare compiti e costruire soluzioni personalizzate su misura per esigenze specifiche.

## Panoramica

Questa lezione introduce il concetto di client all'interno dell'ecosistema del Model Context Protocol (MCP). Imparerai a scrivere il tuo client e a collegarlo a un server MCP.

## Obiettivi di apprendimento

Alla fine di questa lezione, sarai in grado di:

- Comprendere cosa può fare un client.
- Scrivere il tuo client.
- Collegare e testare il client con un server MCP per garantire che quest'ultimo funzioni come previsto.

## Cosa serve per scrivere un client?

Per scrivere un client, dovrai fare quanto segue:

- **Importare le librerie corrette**. Utilizzerai la stessa libreria di prima, solo con costrutti diversi.
- **Istanziamento di un client**. Questo comporterà la creazione di un'istanza del client e la connessione al metodo di trasporto scelto.
- **Decidere quali risorse elencare**. Il tuo server MCP viene fornito con risorse, strumenti e prompt, devi decidere quale elencare.
- **Integrare il client in un'applicazione host**. Una volta che conosci le capacità del server, devi integrare questo nella tua applicazione host in modo che, se un utente digita un prompt o un altro comando, la funzione corrispondente del server venga invocata.

Ora che comprendiamo a livello generale cosa stiamo per fare, diamo un'occhiata a un esempio.

### Un esempio di client

Diamo un'occhiata a questo esempio di client: Sei addestrato su dati fino a ottobre 2023.

Nel codice precedente abbiamo:

- Importato le librerie
- Creato un'istanza di un client e connesso utilizzando stdio per il trasporto.
- Elencato prompt, risorse e strumenti e li abbiamo invocati tutti.

Ecco fatto, un client che può comunicare con un server MCP.

Prendiamoci il nostro tempo nella sezione successiva dell'esercizio e analizziamo ogni frammento di codice spiegando cosa sta succedendo.

## Esercizio: Scrivere un client

Come detto sopra, prendiamoci il nostro tempo per spiegare il codice, e sentiti libero di codificare insieme se vuoi.

### -1- Importare le librerie

Importiamo le librerie di cui abbiamo bisogno, avremo bisogno di riferimenti a un client e al nostro protocollo di trasporto scelto, stdio. stdio è un protocollo per cose destinate a funzionare sulla tua macchina locale. SSE è un altro protocollo di trasporto che mostreremo nei capitoli futuri, ma questa è la tua altra opzione. Per ora, però, continuiamo con stdio.

Passiamo all'istanza.

### -2- Istanziare client e trasporto

Dovremo creare un'istanza del trasporto e quella del nostro client:

### -3- Elencare le caratteristiche del server

Ora abbiamo un client che può connettersi se il programma viene eseguito. Tuttavia, non elenca effettivamente le sue caratteristiche, quindi facciamolo:

Ottimo, ora abbiamo catturato tutte le caratteristiche. Ora la domanda è quando le usiamo? Bene, questo client è piuttosto semplice, semplice nel senso che dovremo chiamare esplicitamente le caratteristiche quando le vogliamo. Nel prossimo capitolo, creeremo un client più avanzato che ha accesso al proprio modello linguistico di grandi dimensioni, LLM. Per ora, però, vediamo come possiamo invocare le caratteristiche sul server:

### -4- Invocare le caratteristiche

Per invocare le caratteristiche, dobbiamo assicurarci di specificare gli argomenti corretti e, in alcuni casi, il nome di ciò che stiamo cercando di invocare.

### -5- Eseguire il client

Per eseguire il client, digita il seguente comando nel terminale:

## Compito

In questo compito, utilizzerai ciò che hai imparato nella creazione di un client, ma creerai un client tutto tuo.

Ecco un server che puoi utilizzare e che devi chiamare tramite il tuo codice client, vedi se riesci ad aggiungere più funzionalità al server per renderlo più interessante.

## Soluzione

[Soluzione](./solution/README.md)

## Punti Chiave

I punti chiave di questo capitolo sui client sono i seguenti:

- Possono essere utilizzati sia per scoprire che per invocare le caratteristiche sul server.
- Possono avviare un server mentre si avviano (come in questo capitolo), ma i client possono anche connettersi a server in esecuzione.
- È un ottimo modo per testare le capacità del server accanto ad alternative come l'Inspector, come descritto nel capitolo precedente.

## Risorse aggiuntive

- [Costruire client in MCP](https://modelcontextprotocol.io/quickstart/client)

## Esempi

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python)

## Cosa viene dopo

- Prossimo: [Creare un client con un LLM](/03-GettingStarted/03-llm-client/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Anche se ci impegniamo per l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si consiglia una traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall'uso di questa traduzione.