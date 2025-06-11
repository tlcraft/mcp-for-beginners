<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:08:17+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "it"
}
-->
## Iniziare  

Questa sezione è composta da diverse lezioni:

- **1 Il tuo primo server**, in questa prima lezione imparerai come creare il tuo primo server e come ispezionarlo con lo strumento inspector, un modo prezioso per testare e fare il debug del tuo server, [alla lezione](/03-GettingStarted/01-first-server/README.md)

- **2 Client**, in questa lezione imparerai come scrivere un client che può connettersi al tuo server, [alla lezione](/03-GettingStarted/02-client/README.md)

- **3 Client con LLM**, un modo ancora migliore di scrivere un client è aggiungendo un LLM così da poter "negoziare" con il tuo server cosa fare, [alla lezione](/03-GettingStarted/03-llm-client/README.md)

- **4 Utilizzare la modalità GitHub Copilot Agent di un server in Visual Studio Code**. Qui vediamo come eseguire il nostro MCP Server direttamente da Visual Studio Code, [alla lezione](/03-GettingStarted/04-vscode/README.md)

- **5 Consumo da SSE (Server Sent Events)** SSE è uno standard per lo streaming da server a client, che permette ai server di inviare aggiornamenti in tempo reale ai client tramite HTTP [alla lezione](/03-GettingStarted/05-sse-server/README.md)

- **6 Utilizzare AI Toolkit per VSCode** per consumare e testare i tuoi MCP Client e Server [alla lezione](/03-GettingStarted/06-aitk/README.md)

- **7 Testing**. Qui ci concentreremo in particolare su come testare il nostro server e client in modi diversi, [alla lezione](/03-GettingStarted/07-testing/README.md)

- **8 Deployment**. Questo capitolo esplorerà i diversi modi di distribuire le tue soluzioni MCP, [alla lezione](/03-GettingStarted/08-deployment/README.md)


Il Model Context Protocol (MCP) è un protocollo aperto che standardizza il modo in cui le applicazioni forniscono contesto agli LLM. Pensa a MCP come a una porta USB-C per le applicazioni AI - offre un modo standardizzato per collegare modelli AI a diverse fonti di dati e strumenti.

## Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Configurare ambienti di sviluppo per MCP in C#, Java, Python, TypeScript e JavaScript
- Costruire e distribuire server MCP di base con funzionalità personalizzate (risorse, prompt e strumenti)
- Creare applicazioni host che si connettono ai server MCP
- Testare e fare il debug delle implementazioni MCP
- Comprendere le sfide comuni nella configurazione e le loro soluzioni
- Collegare le tue implementazioni MCP ai servizi LLM più diffusi

## Configurare il tuo ambiente MCP

Prima di iniziare a lavorare con MCP, è importante preparare il tuo ambiente di sviluppo e comprendere il flusso di lavoro di base. Questa sezione ti guiderà attraverso i passaggi iniziali per assicurarti un avvio senza intoppi con MCP.

### Prerequisiti

Prima di immergerti nello sviluppo MCP, assicurati di avere:

- **Ambiente di sviluppo**: per il linguaggio scelto (C#, Java, Python, TypeScript o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm o qualsiasi editor di codice moderno
- **Package Manager**: NuGet, Maven/Gradle, pip o npm/yarn
- **API Key**: per i servizi AI che intendi usare nelle tue applicazioni host


### SDK Ufficiali

Nei capitoli successivi vedrai soluzioni costruite usando Python, TypeScript, Java e .NET. Ecco tutti gli SDK ufficialmente supportati.

MCP fornisce SDK ufficiali per diversi linguaggi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenuto in collaborazione con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenuto in collaborazione con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - L’implementazione ufficiale in TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - L’implementazione ufficiale in Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - L’implementazione ufficiale in Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenuto in collaborazione con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - L’implementazione ufficiale in Rust

## Punti Chiave

- Configurare un ambiente di sviluppo MCP è semplice con SDK specifici per linguaggio
- Costruire server MCP significa creare e registrare strumenti con schemi chiari
- I client MCP si connettono a server e modelli per sfruttare funzionalità estese
- Testare e fare il debug sono essenziali per implementazioni MCP affidabili
- Le opzioni di deployment variano dallo sviluppo locale a soluzioni basate su cloud

## Esercitarsi

Abbiamo una serie di esempi che completano gli esercizi che vedrai in tutti i capitoli di questa sezione. Inoltre ogni capitolo ha i propri esercizi e compiti

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

Successivo: [Creare il tuo primo MCP Server](/03-GettingStarted/01-first-server/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non siamo responsabili per eventuali fraintendimenti o interpretazioni errate derivanti dall'uso di questa traduzione.