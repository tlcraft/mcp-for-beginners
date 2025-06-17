<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "904b689eda5a68cbafe656d53f9787c7",
  "translation_date": "2025-06-17T18:48:35+00:00",
  "source_file": "03-GettingStarted/03-llm-client/README.md",
  "language_code": "it"
}
-->
Ottimo, per il nostro prossimo passo, elenchiamo le capacità sul server.

### -2 Elenca le capacità del server

Ora ci connetteremo al server e ne chiederemo le capacità:

### -3- Converti le capacità del server in strumenti per l'LLM

Il passo successivo dopo aver elencato le capacità del server è convertirle in un formato che l'LLM possa comprendere. Una volta fatto ciò, potremo fornire queste capacità come strumenti al nostro LLM.

Ottimo, ora siamo pronti per gestire le richieste degli utenti, quindi affrontiamo questo aspetto.

### -4- Gestisci la richiesta del prompt dell'utente

In questa parte del codice, gestiremo le richieste degli utenti.

Ottimo, ce l'hai fatta!

## Compito

Prendi il codice dall'esercizio e costruisci il server aggiungendo altri strumenti. Poi crea un client con un LLM, come nell'esercizio, e testalo con diversi prompt per assicurarti che tutti gli strumenti del server vengano chiamati dinamicamente. Questo modo di costruire un client garantisce all'utente finale un'esperienza ottimale, poiché può usare prompt in linguaggio naturale, invece di comandi client esatti, senza doversi preoccupare se viene chiamato un server MCP.

## Soluzione

[Soluzione](/03-GettingStarted/03-llm-client/solution/README.md)

## Punti Chiave

- Aggiungere un LLM al client offre un modo migliore per gli utenti di interagire con i server MCP.
- È necessario convertire la risposta del server MCP in qualcosa che l'LLM possa comprendere.

## Esempi

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python)

## Risorse Aggiuntive

## Cosa Fare Dopo

- Successivo: [Consumare un server usando Visual Studio Code](/03-GettingStarted/04-vscode/README.md)

**Avvertenza**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua originale deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un essere umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.