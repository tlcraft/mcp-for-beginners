<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4cc245e2f4ea5db5e2b8c2cd1dadc4b4",
  "translation_date": "2025-07-13T18:14:38+00:00",
  "source_file": "03-GettingStarted/02-client/README.md",
  "language_code": "it"
}
-->
Nel codice precedente abbiamo:

- Importato le librerie
- Creato un'istanza di un client e connesso utilizzando stdio come trasporto.
- Elencato prompt, risorse e strumenti e li abbiamo invocati tutti.

Ecco fatto, un client che può comunicare con un server MCP.

Prendiamoci il tempo nella prossima sezione esercizi per analizzare ogni frammento di codice e spiegare cosa succede.

## Esercizio: Scrivere un client

Come detto sopra, prendiamoci il tempo per spiegare il codice, e sentitevi liberi di scrivere il codice insieme a noi se volete.

### -1- Importare le librerie

Importiamo le librerie di cui abbiamo bisogno, ci serviranno riferimenti a un client e al protocollo di trasporto scelto, stdio. stdio è un protocollo pensato per esecuzioni sulla macchina locale. SSE è un altro protocollo di trasporto che mostreremo nei capitoli futuri, ma questa è la vostra altra opzione. Per ora, continuiamo con stdio.

Passiamo ora all'istanza.

### -2- Istanziare client e trasporto

Dobbiamo creare un'istanza del trasporto e una del nostro client:

### -3- Elencare le funzionalità del server

Ora abbiamo un client che può connettersi se il programma viene eseguito. Tuttavia, non elenca ancora le sue funzionalità, quindi facciamolo adesso:

Ottimo, ora abbiamo catturato tutte le funzionalità. La domanda è: quando le usiamo? Beh, questo client è piuttosto semplice, nel senso che dovremo chiamare esplicitamente le funzionalità quando le vogliamo. Nel capitolo successivo creeremo un client più avanzato che avrà accesso al proprio modello linguistico di grandi dimensioni, LLM. Per ora, vediamo come possiamo invocare le funzionalità sul server:

### -4- Invocare le funzionalità

Per invocare le funzionalità dobbiamo assicurarci di specificare gli argomenti corretti e, in alcuni casi, il nome di ciò che stiamo cercando di invocare.

### -5- Eseguire il client

Per eseguire il client, digitate il seguente comando nel terminale:

## Compito

In questo compito, utilizzerai ciò che hai imparato per creare un client, ma questa volta un client tutto tuo.

Ecco un server che puoi usare e che devi chiamare tramite il codice del tuo client, prova ad aggiungere più funzionalità al server per renderlo più interessante.

## Soluzione

[Soluzione](./solution/README.md)

## Punti Chiave

I punti chiave di questo capitolo riguardo ai client sono i seguenti:

- Possono essere usati sia per scoprire che per invocare funzionalità sul server.
- Possono avviare un server mentre si avviano da soli (come in questo capitolo), ma i client possono anche connettersi a server già in esecuzione.
- Sono un ottimo modo per testare le capacità del server accanto ad alternative come l'Inspector, come descritto nel capitolo precedente.

## Risorse Aggiuntive

- [Costruire client in MCP](https://modelcontextprotocol.io/quickstart/client)

## Esempi

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python)

## Cosa c'è dopo

- Successivo: [Creare un client con un LLM](../03-llm-client/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.