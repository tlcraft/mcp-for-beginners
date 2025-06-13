<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9191921de355cd9c8f46ebe21bdd52fd",
  "translation_date": "2025-06-12T23:41:31+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "it"
}
-->
## Iniziare  

Questa sezione comprende diverse lezioni:

- **1 Il tuo primo server**, in questa prima lezione imparerai come creare il tuo primo server e ispezionarlo con lo strumento inspector, un modo prezioso per testare e fare il debug del tuo server, [alla lezione](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, in questa lezione imparerai come scrivere un client che può connettersi al tuo server, [alla lezione](/03-GettingStarted/02-client/README.md)

- **3 Client con LLM**, un modo ancora migliore di scrivere un client è aggiungendo un LLM così può "negoziare" con il tuo server su cosa fare, [alla lezione](/03-GettingStarted/03-llm-client/README.md)

- **4 Utilizzo di un server in modalità GitHub Copilot Agent in Visual Studio Code**. Qui vediamo come eseguire il nostro MCP Server direttamente da Visual Studio Code, [alla lezione](/03-GettingStarted/04-vscode/README.md)

- **5 Consumo da SSE (Server Sent Events)** SSE è uno standard per lo streaming server-to-client, che permette ai server di inviare aggiornamenti in tempo reale ai client tramite HTTP [alla lezione](/03-GettingStarted/05-sse-server/README.md)

- **6 Streaming HTTP con MCP (Streamable HTTP)**. Scopri lo streaming HTTP moderno, le notifiche di progresso e come implementare server e client MCP scalabili e in tempo reale usando Streamable HTTP. [alla lezione](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilizzo di AI Toolkit per VSCode** per consumare e testare i tuoi MCP Client e Server [alla lezione](/03-GettingStarted/07-aitk/README.md)

- **8 Testing**. Qui ci concentreremo in particolare su come testare il nostro server e client in modi diversi, [alla lezione](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**. Questo capitolo esaminerà diversi modi per distribuire le tue soluzioni MCP, [alla lezione](/03-GettingStarted/09-deployment/README.md)


Il Model Context Protocol (MCP) è un protocollo aperto che standardizza il modo in cui le applicazioni forniscono contesto agli LLM. Pensa a MCP come a una porta USB-C per le applicazioni AI: offre un modo standardizzato per collegare modelli AI a diverse fonti di dati e strumenti.

## Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Configurare ambienti di sviluppo per MCP in C#, Java, Python, TypeScript e JavaScript
- Costruire e distribuire server MCP base con funzionalità personalizzate (risorse, prompt e strumenti)
- Creare applicazioni host che si connettono ai server MCP
- Testare e fare il debug delle implementazioni MCP
- Comprendere le sfide comuni di configurazione e le relative soluzioni
- Collegare le tue implementazioni MCP ai servizi LLM più diffusi

## Configurare il tuo ambiente MCP

Prima di iniziare a lavorare con MCP, è importante preparare il tuo ambiente di sviluppo e comprendere il flusso di lavoro di base. Questa sezione ti guiderà nei primi passaggi per assicurarti un avvio senza intoppi con MCP.

### Prerequisiti

Prima di addentrarti nello sviluppo MCP, assicurati di avere:

- **Ambiente di sviluppo**: per il linguaggio scelto (C#, Java, Python, TypeScript o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm o qualsiasi editor di codice moderno
- **Package Manager**: NuGet, Maven/Gradle, pip o npm/yarn
- **API Keys**: per i servizi AI che intendi utilizzare nelle tue applicazioni host


### SDK Ufficiali

Nei capitoli successivi vedrai soluzioni costruite usando Python, TypeScript, Java e .NET. Ecco tutti gli SDK ufficialmente supportati.

MCP fornisce SDK ufficiali per più linguaggi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenuto in collaborazione con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenuto in collaborazione con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementazione ufficiale TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementazione ufficiale Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementazione ufficiale Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenuto in collaborazione con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementazione ufficiale Rust

## Punti Chiave

- Configurare un ambiente di sviluppo MCP è semplice con SDK specifici per linguaggio
- Costruire server MCP implica creare e registrare strumenti con schemi chiari
- I client MCP si connettono a server e modelli per sfruttare funzionalità estese
- Testare e fare il debug è essenziale per implementazioni MCP affidabili
- Le opzioni di distribuzione vanno dallo sviluppo locale a soluzioni cloud

## Esercitarsi

Abbiamo una serie di esempi che completano gli esercizi che vedrai in tutti i capitoli di questa sezione. Inoltre, ogni capitolo ha i propri esercizi e compiti

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Risorse Aggiuntive

- [Build Agents using Model Context Protocol on Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [Remote MCP with Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Cosa c’è dopo

Prossimo: [Creare il tuo primo MCP Server](/03-GettingStarted/01-first-server/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.