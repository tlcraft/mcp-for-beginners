<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:31:32+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "it"
}
-->
### -2- Crea il progetto

Ora che hai installato l’SDK, creiamo il progetto: 

### -3- Crea i file del progetto

### -4- Scrivi il codice del server

### -5- Aggiungi uno strumento e una risorsa

Aggiungi uno strumento e una risorsa inserendo il seguente codice:

### -6 Codice finale

Aggiungiamo l’ultimo codice necessario per avviare il server:

### -7- Testa il server

Avvia il server con il seguente comando:

### -8- Avvia con l’inspector

L’inspector è uno strumento utile che avvia il server e ti permette di interagire con esso per verificare che funzioni correttamente. Avviamolo:

> [!NOTE]
> potrebbe apparire diverso nel campo "command" perché contiene il comando specifico per eseguire il server con il runtime che stai usando.

Dovresti vedere la seguente interfaccia utente:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.it.png)

1. Connettiti al server selezionando il pulsante Connect  
   Una volta connesso, vedrai quanto segue:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.it.png)

2. Seleziona "Tools" e "listTools", dovrebbe comparire "Add", seleziona "Add" e inserisci i valori dei parametri.

   Vedrai la seguente risposta, cioè il risultato dello strumento "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.it.png)

Complimenti, hai creato e avviato il tuo primo server!

### SDK ufficiali

MCP offre SDK ufficiali per diversi linguaggi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenuto in collaborazione con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenuto in collaborazione con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementazione ufficiale in TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementazione ufficiale in Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementazione ufficiale in Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenuto in collaborazione con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementazione ufficiale in Rust

## Punti chiave

- Configurare un ambiente di sviluppo MCP è semplice grazie agli SDK specifici per ogni linguaggio
- Costruire server MCP significa creare e registrare strumenti con schemi chiari
- Testare e fare debug è fondamentale per implementazioni MCP affidabili

## Esempi

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Esercizio

Crea un semplice server MCP con uno strumento a tua scelta:
1. Implementa lo strumento nel linguaggio che preferisci (.NET, Java, Python o JavaScript).
2. Definisci i parametri di input e i valori di ritorno.
3. Avvia lo strumento inspector per verificare che il server funzioni correttamente.
4. Testa l’implementazione con vari input.

## Soluzione

[Soluzione](./solution/README.md)

## Risorse aggiuntive

- [Costruire agenti usando Model Context Protocol su Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP remoto con Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agente MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Cosa fare dopo

Prossimo: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Avvertenza**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali fraintendimenti o interpretazioni errate derivanti dall’uso di questa traduzione.