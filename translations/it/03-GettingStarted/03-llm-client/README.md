<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bc3ae5af5973160abba9976cb5a4704c",
  "translation_date": "2025-06-13T11:30:31+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "it"
}
-->
Ottimo, per il nostro prossimo passo, elenchiamo le capacità sul server.

### -2 Elenca le capacità del server

Ora ci connetteremo al server e ne chiederemo le capacità:

### -3- Converti le capacità del server in strumenti per l'LLM

Il passo successivo dopo aver elencato le capacità del server è convertirle in un formato che l'LLM possa comprendere. Una volta fatto ciò, possiamo fornire queste capacità come strumenti al nostro LLM.

Ottimo, ora siamo pronti per gestire le richieste degli utenti, quindi affrontiamo questo passaggio.

### -4- Gestisci la richiesta di prompt dell'utente

In questa parte del codice, gestiremo le richieste degli utenti.

Ottimo, ce l'hai fatta!

## Compito

Prendi il codice dell'esercizio e amplia il server aggiungendo altri strumenti. Poi crea un client con un LLM, come nell'esercizio, e testalo con diversi prompt per assicurarti che tutti gli strumenti del server vengano chiamati dinamicamente. Questo modo di costruire un client garantisce una grande esperienza utente finale, poiché possono utilizzare prompt in linguaggio naturale, invece di comandi client esatti, senza preoccuparsi del fatto che venga chiamato un server MCP.

## Soluzione

[Solution](/03-GettingStarted/03-llm-client/solution/README.md)

## Punti Chiave

- Aggiungere un LLM al tuo client offre un modo migliore per gli utenti di interagire con i server MCP.
- È necessario convertire la risposta del server MCP in un formato che l'LLM possa comprendere.

## Esempi

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Risorse Aggiuntive

## Cosa Viene Dopo

- Successivo: [Consuming a server using Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua madre deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall'uso di questa traduzione.