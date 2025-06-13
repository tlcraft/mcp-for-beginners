<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a0acf3093691b1cfcc008a8c6648ea26",
  "translation_date": "2025-06-13T06:44:15+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "it"
}
-->
Nel codice precedente abbiamo:

- Importato le librerie
- Creato un'istanza di un client e connesso usando stdio come metodo di trasporto.
- Elencato prompt, risorse e strumenti e li abbiamo invocati tutti.

Ecco fatto, un client che può comunicare con un MCP Server.

Prendiamoci il tempo nella prossima sezione esercizi per analizzare ogni frammento di codice e spiegare cosa succede.

## Esercizio: Scrivere un client

Come detto sopra, prendiamoci il tempo per spiegare il codice, e ovviamente sentiti libero di seguire e scrivere codice insieme.

### -1- Importare le librerie

Importiamo le librerie di cui abbiamo bisogno, ci serviranno riferimenti a un client e al protocollo di trasporto scelto, stdio. stdio è un protocollo per cose destinate a girare sulla tua macchina locale. SSE è un altro protocollo di trasporto che mostreremo nei capitoli futuri, ma questa è un'altra opzione. Per ora, però, continuiamo con stdio.

Passiamo all'istanza.

### -2- Istanziare client e trasporto

Dobbiamo creare un'istanza del trasporto e una del nostro client:

### -3- Elencare le funzionalità del server

Ora abbiamo un client che può connettersi quando il programma viene eseguito. Tuttavia, non elenca ancora le sue funzionalità, quindi facciamolo ora:

Ottimo, ora abbiamo catturato tutte le funzionalità. Ora la domanda è: quando le usiamo? Beh, questo client è piuttosto semplice, nel senso che dobbiamo chiamare esplicitamente le funzionalità quando le vogliamo. Nel capitolo successivo creeremo un client più avanzato che avrà accesso a un proprio modello di linguaggio di grandi dimensioni (LLM). Per ora, però, vediamo come possiamo invocare le funzionalità sul server:

### -4- Invocare le funzionalità

Per invocare le funzionalità dobbiamo assicurarci di specificare gli argomenti corretti e, in alcuni casi, il nome di ciò che vogliamo invocare.

### -5- Eseguire il client

Per eseguire il client, digita il seguente comando nel terminale:

## Compito

In questo compito, utilizzerai ciò che hai imparato per creare un client, ma dovrai crearne uno tuo.

Ecco un server che puoi usare e che devi chiamare tramite il codice del tuo client, prova a vedere se riesci ad aggiungere più funzionalità al server per renderlo più interessante.

## Soluzione

[Soluzione](./solution/README.md)

## Punti Chiave

I punti chiave di questo capitolo riguardo ai client sono i seguenti:

- Possono essere usati sia per scoprire che per invocare funzionalità sul server.
- Possono avviare un server mentre si avviano (come in questo capitolo), ma i client possono anche connettersi a server già in esecuzione.
- Sono un ottimo modo per testare le capacità del server, oltre ad alternative come l’Inspector descritto nel capitolo precedente.

## Risorse Aggiuntive

- [Costruire client in MCP](https://modelcontextprotocol.io/quickstart/client)

## Esempi

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python)

## Cosa c’è dopo

- Successivo: [Creare un client con un LLM](/03-GettingStarted/03-llm-client/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.