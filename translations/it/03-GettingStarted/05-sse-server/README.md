<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d90ca3d326c48fab2ac0ebd3a9876f59",
  "translation_date": "2025-07-04T17:06:49+00:00",
  "source_file": "03-GettingStarted/05-sse-server/README.md",
  "language_code": "it"
}
-->
Ora che sappiamo qualcosa in più su SSE, costruiamo un server SSE.

## Esercizio: Creare un server SSE

Per creare il nostro server, dobbiamo tenere a mente due cose:

- Dobbiamo usare un web server per esporre gli endpoint per la connessione e i messaggi.
- Costruire il nostro server come facciamo normalmente con strumenti, risorse e prompt quando usavamo stdio.

### -1- Creare un'istanza del server

Per creare il nostro server, usiamo gli stessi tipi di stdio. Tuttavia, per il trasporto, dobbiamo scegliere SSE.

Aggiungiamo ora le rotte necessarie.

### -2- Aggiungere le rotte

Aggiungiamo le rotte che gestiscono la connessione e i messaggi in arrivo:

Aggiungiamo ora le funzionalità al server.

### -3- Aggiungere funzionalità al server

Ora che abbiamo definito tutto ciò che riguarda SSE, aggiungiamo funzionalità al server come strumenti, prompt e risorse.

Il tuo codice completo dovrebbe essere così:

Ottimo, abbiamo un server che usa SSE, proviamolo subito.

## Esercizio: Debuggare un server SSE con Inspector

Inspector è uno strumento fantastico che abbiamo visto in una lezione precedente [Creare il tuo primo server](/03-GettingStarted/01-first-server/README.md). Vediamo se possiamo usarlo anche qui:

### -1- Avviare l'inspector

Per avviare l'inspector, devi prima avere un server SSE in esecuzione, quindi facciamolo subito:

1. Avvia il server

1. Avvia l'inspector

    > ![NOTE]
    > Esegui questo in una finestra del terminale separata rispetto a quella in cui gira il server. Nota anche che devi adattare il comando qui sotto all'URL dove il tuo server è in esecuzione.

    ```sh
    npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
    ```

L'esecuzione dell'inspector è uguale in tutti gli ambienti di runtime. Nota come invece di passare un percorso al nostro server e un comando per avviarlo, passiamo l'URL dove il server è in esecuzione e specifichiamo anche la rotta `/sse`.

### -2- Provare lo strumento

Connetti il server selezionando SSE nel menu a tendina e inserisci l'URL dove il tuo server è in esecuzione, per esempio http://localhost:4321/sse. Ora clicca sul pulsante "Connect". Come prima, seleziona di elencare gli strumenti, scegli uno strumento e fornisci i valori di input. Dovresti vedere un risultato simile a questo:

![Server SSE in esecuzione nell'inspector](../../../../translated_images/sse-inspector.d86628cc597b8fae807a31d3d6837842f5f9ee1bcc6101013fa0c709c96029ad.it.png)

Ottimo, riesci a lavorare con l'inspector, vediamo ora come lavorare con Visual Studio Code.

## Compito

Prova a sviluppare il tuo server con più funzionalità. Consulta [questa pagina](https://api.chucknorris.io/) per esempio per aggiungere uno strumento che chiama un'API. Decidi tu come deve essere il server. Divertiti :)

## Soluzione

[Soluzione](./solution/README.md) Ecco una possibile soluzione con codice funzionante.

## Punti chiave

I punti chiave di questo capitolo sono i seguenti:

- SSE è il secondo tipo di trasporto supportato dopo stdio.
- Per supportare SSE, devi gestire le connessioni in arrivo e i messaggi usando un framework web.
- Puoi usare sia Inspector che Visual Studio Code per consumare un server SSE, proprio come per i server stdio. Nota come ci siano alcune differenze tra stdio e SSE. Per SSE, devi avviare il server separatamente e poi eseguire lo strumento inspector. Per l'inspector ci sono anche differenze nel dover specificare l'URL.

## Esempi

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python)

## Risorse aggiuntive

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## Cosa c'è dopo

- Prossimo: [HTTP Streaming con MCP (Streamable HTTP)](../06-http-streaming/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.