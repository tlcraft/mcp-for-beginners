<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "abbb199eb22fdffa44a0de4db6a5ea49",
  "translation_date": "2025-05-17T10:20:04+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "it"
}
-->
# Creare un client con LLM

Finora hai visto come creare un server e un client. Il client è stato in grado di chiamare il server esplicitamente per elencare i suoi strumenti, risorse e prompt. Tuttavia, non è un approccio molto pratico. Il tuo utente vive nell'era agentica e si aspetta di utilizzare i prompt e comunicare con un LLM per farlo. Per il tuo utente, non importa se utilizzi MCP o meno per memorizzare le tue capacità, ma si aspetta di interagire usando il linguaggio naturale. Quindi, come possiamo risolvere questo problema? La soluzione consiste nell'aggiungere un LLM al client.

## Panoramica

In questa lezione ci concentriamo sull'aggiunta di un LLM al tuo client e mostriamo come questo fornisca un'esperienza molto migliore per il tuo utente.

## Obiettivi di apprendimento

Alla fine di questa lezione, sarai in grado di:

- Creare un client con un LLM.
- Interagire senza problemi con un server MCP utilizzando un LLM.
- Fornire una migliore esperienza utente lato client.

## Approccio

Cerchiamo di capire l'approccio che dobbiamo adottare. Aggiungere un LLM sembra semplice, ma come lo faremo realmente?

Ecco come il client interagirà con il server:

1. Stabilire la connessione con il server.

1. Elencare capacità, prompt, risorse e strumenti, e salvare il loro schema.

1. Aggiungere un LLM e passare le capacità salvate e il loro schema in un formato che l'LLM comprende.

1. Gestire un prompt dell'utente passandolo all'LLM insieme agli strumenti elencati dal client.

Perfetto, ora che abbiamo capito come possiamo farlo a un livello alto, proviamo a farlo nell'esercizio qui sotto.

## Esercizio: Creare un client con un LLM

In questo esercizio, impareremo ad aggiungere un LLM al nostro client.

### -1- Collegarsi al server

Creiamo prima il nostro client: Sei addestrato su dati fino a ottobre 2023.

Ottimo, per il nostro prossimo passo, elenchiamo le capacità sul server.

### -2 Elencare le capacità del server

Ora ci collegheremo al server e chiederemo le sue capacità:

### -3- Convertire le capacità del server in strumenti LLM

Il passo successivo dopo aver elencato le capacità del server è convertirle in un formato che l'LLM comprende. Una volta fatto ciò, possiamo fornire queste capacità come strumenti al nostro LLM.

Ottimo, ora siamo pronti per gestire qualsiasi richiesta dell'utente, quindi affrontiamo questo prossimo passo.

### -4- Gestire la richiesta del prompt dell'utente

In questa parte del codice, gestiremo le richieste degli utenti.

Ottimo, ce l'hai fatta!

## Compito

Prendi il codice dall'esercizio e sviluppa il server con qualche altro strumento. Quindi crea un client con un LLM, come nell'esercizio, e testalo con diversi prompt per assicurarti che tutti i tuoi strumenti server vengano chiamati dinamicamente. Questo modo di costruire un client significa che l'utente finale avrà un'ottima esperienza utente poiché sarà in grado di utilizzare i prompt, invece dei comandi esatti del client, e sarà ignaro di qualsiasi server MCP chiamato.

## Soluzione 

[Soluzione](/03-GettingStarted/03-llm-client/solution/README.md)

## Punti Chiave

- Aggiungere un LLM al tuo client offre un modo migliore per gli utenti di interagire con i server MCP.
- È necessario convertire la risposta del server MCP in qualcosa che l'LLM possa comprendere.

## Esempi

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python)

## Risorse Aggiuntive

## Cosa c'è dopo

- Successivo: [Consumare un server usando Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua madre dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.