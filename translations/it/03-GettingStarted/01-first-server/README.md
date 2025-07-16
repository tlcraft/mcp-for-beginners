<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:42:57+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "it"
}
-->
### -2- Crea il progetto

Ora che hai installato l'SDK, creiamo il progetto.

### -3- Crea i file del progetto

### -4- Scrivi il codice del server

### -5- Aggiungere uno strumento e una risorsa

Aggiungi uno strumento e una risorsa inserendo il seguente codice:

### -6 Codice finale

Aggiungiamo l'ultimo pezzo di codice necessario per avviare il server:

### -7- Testa il server

Avvia il server con il seguente comando:

### -8- Esegui usando l'inspector

L'inspector è uno strumento eccellente che può avviare il tuo server e ti permette di interagire con esso per testarne il funzionamento. Avviamolo:
> [!NOTE]
> potrebbe apparire diverso nel campo "command" poiché contiene il comando per avviare un server con il tuo runtime specifico/
Dovresti vedere la seguente interfaccia utente:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. Connettiti al server selezionando il pulsante Connect
  Una volta connesso al server, dovresti vedere quanto segue:

  ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. Seleziona "Tools" e "listTools", dovresti vedere comparire "Add", seleziona "Add" e inserisci i valori dei parametri.

  Dovresti vedere la seguente risposta, cioè un risultato dallo strumento "add":

  ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

Congratulazioni, sei riuscito a creare ed eseguire il tuo primo server!

### SDK Ufficiali

MCP fornisce SDK ufficiali per diversi linguaggi:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenuto in collaborazione con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenuto in collaborazione con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - L'implementazione ufficiale in TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - L'implementazione ufficiale in Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - L'implementazione ufficiale in Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenuto in collaborazione con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - L'implementazione ufficiale in Rust

## Punti Chiave

- Configurare un ambiente di sviluppo MCP è semplice con SDK specifici per linguaggio
- Costruire server MCP implica creare e registrare strumenti con schemi chiari
- Testare e fare debug è essenziale per implementazioni MCP affidabili

## Esempi

- [Calcolatrice Java](../samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](../samples/javascript/README.md)
- [Calcolatrice TypeScript](../samples/typescript/README.md)
- [Calcolatrice Python](../../../../03-GettingStarted/samples/python)

## Compito

Crea un semplice server MCP con uno strumento a tua scelta:

1. Implementa lo strumento nel linguaggio che preferisci (.NET, Java, Python o JavaScript).
2. Definisci i parametri di input e i valori di ritorno.
3. Esegui lo strumento inspector per assicurarti che il server funzioni come previsto.
4. Testa l’implementazione con vari input.

## Soluzione

[Soluzione](./solution/README.md)

## Risorse Aggiuntive

- [Costruire agenti usando Model Context Protocol su Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP remoto con Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agente MCP OpenAI per .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Cosa c’è dopo

Prossimo: [Introduzione ai Client MCP](../02-client/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.