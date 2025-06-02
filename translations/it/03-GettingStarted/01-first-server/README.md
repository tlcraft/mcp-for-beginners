<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d730cbe43a8efc148677fdbc849a7d5e",
  "translation_date": "2025-06-02T17:00:13+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "it"
}
-->
### -2- Creare il progetto

Ora che hai installato l’SDK, passiamo a creare un progetto:

### -3- Creare i file del progetto

### -4- Scrivere il codice del server

### -5- Aggiungere uno strumento e una risorsa

Aggiungi uno strumento e una risorsa inserendo il seguente codice:

### -6- Codice finale

Aggiungiamo l’ultimo pezzo di codice necessario per avviare il server:

### -7- Testare il server

Avvia il server con il seguente comando:

### -8- Eseguire con l’inspector

L’inspector è uno strumento utile che può avviare il server e ti permette di interagire con esso per verificare che funzioni correttamente. Avviamolo:

> [!NOTE]
> il campo "command" potrebbe apparire diverso in quanto contiene il comando specifico per eseguire un server con il runtime che stai utilizzando

Dovresti vedere la seguente interfaccia utente:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.it.png)

1. Connettiti al server selezionando il pulsante Connect  
   Una volta connesso, dovresti vedere la schermata seguente:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.it.png)

2. Seleziona "Tools" e poi "listTools", vedrai comparire "Add", selezionalo e inserisci i valori dei parametri.

   Dovresti vedere questa risposta, ovvero il risultato dello strumento "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.it.png)

Complimenti, sei riuscito a creare e avviare il tuo primo server!

### SDK ufficiali

MCP offre SDK ufficiali per diversi linguaggi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenuto in collaborazione con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenuto in collaborazione con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementazione ufficiale TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementazione ufficiale Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementazione ufficiale Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenuto in collaborazione con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementazione ufficiale Rust

## Punti chiave

- Configurare un ambiente di sviluppo MCP è semplice grazie agli SDK specifici per linguaggio
- Costruire server MCP significa creare e registrare strumenti con schemi chiari
- Testare e fare debug sono fondamentali per implementazioni MCP affidabili

## Esempi

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## Compito

Crea un server MCP semplice con uno strumento a tua scelta:  
1. Implementa lo strumento nel linguaggio che preferisci (.NET, Java, Python o JavaScript).  
2. Definisci i parametri di input e i valori di ritorno.  
3. Avvia lo strumento inspector per assicurarti che il server funzioni correttamente.  
4. Testa l’implementazione con vari input.

## Soluzione

[Soluzione](./solution/README.md)

## Risorse aggiuntive

- [Repository MCP su GitHub](https://github.com/microsoft/mcp-for-beginners)

## Cosa fare dopo

Prossimo: [Getting Started with MCP Clients](/03-GettingStarted/02-client/README.md)

**Avvertenza**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per l’accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.