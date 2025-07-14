<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-13T17:15:27+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "it"
}
-->
## Iniziare  

Questa sezione è composta da diverse lezioni:

- **1 Il tuo primo server**, in questa prima lezione imparerai come creare il tuo primo server e ispezionarlo con lo strumento inspector, un modo prezioso per testare e fare il debug del tuo server, [alla lezione](01-first-server/README.md)

- **2 Client**, in questa lezione imparerai come scrivere un client che può connettersi al tuo server, [alla lezione](02-client/README.md)

- **3 Client con LLM**, un modo ancora migliore di scrivere un client è aggiungendo un LLM così da poter "negoziare" con il tuo server cosa fare, [alla lezione](03-llm-client/README.md)

- **4 Utilizzo di un server in modalità GitHub Copilot Agent in Visual Studio Code**. Qui vediamo come eseguire il nostro MCP Server direttamente da Visual Studio Code, [alla lezione](04-vscode/README.md)

- **5 Consumo da SSE (Server Sent Events)** SSE è uno standard per lo streaming server-to-client, che permette ai server di inviare aggiornamenti in tempo reale ai client tramite HTTP [alla lezione](05-sse-server/README.md)

- **6 Streaming HTTP con MCP (Streamable HTTP)**. Scopri lo streaming HTTP moderno, le notifiche di progresso e come implementare server e client MCP scalabili e in tempo reale usando Streamable HTTP. [alla lezione](06-http-streaming/README.md)

- **7 Utilizzo di AI Toolkit per VSCode** per consumare e testare i tuoi MCP Client e Server [alla lezione](07-aitk/README.md)

- **8 Testing**. Qui ci concentreremo soprattutto su come testare il nostro server e client in modi diversi, [alla lezione](08-testing/README.md)

- **9 Deployment**. Questo capitolo esaminerà diversi modi per distribuire le tue soluzioni MCP, [alla lezione](09-deployment/README.md)


Il Model Context Protocol (MCP) è un protocollo aperto che standardizza il modo in cui le applicazioni forniscono contesto agli LLM. Pensa a MCP come a una porta USB-C per le applicazioni AI: offre un modo standardizzato per collegare modelli AI a diverse fonti di dati e strumenti.

## Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Configurare ambienti di sviluppo per MCP in C#, Java, Python, TypeScript e JavaScript
- Costruire e distribuire server MCP di base con funzionalità personalizzate (risorse, prompt e strumenti)
- Creare applicazioni host che si connettono ai server MCP
- Testare e fare il debug delle implementazioni MCP
- Comprendere le sfide comuni di configurazione e le loro soluzioni
- Collegare le tue implementazioni MCP ai servizi LLM più diffusi

## Configurare il tuo ambiente MCP

Prima di iniziare a lavorare con MCP, è importante preparare il tuo ambiente di sviluppo e comprendere il flusso di lavoro di base. Questa sezione ti guiderà attraverso i passaggi iniziali per assicurarti un avvio senza intoppi con MCP.

### Prerequisiti

Prima di immergerti nello sviluppo MCP, assicurati di avere:

- **Ambiente di sviluppo**: per il linguaggio scelto (C#, Java, Python, TypeScript o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm o qualsiasi editor di codice moderno
- **Package Manager**: NuGet, Maven/Gradle, pip o npm/yarn
- **API Key**: per qualsiasi servizio AI che intendi utilizzare nelle tue applicazioni host


### SDK Ufficiali

Nei prossimi capitoli vedrai soluzioni costruite usando Python, TypeScript, Java e .NET. Ecco tutti gli SDK ufficialmente supportati.

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
- I client MCP si connettono a server e modelli per sfruttare capacità estese
- Testare e fare il debug sono fondamentali per implementazioni MCP affidabili
- Le opzioni di deployment vanno dallo sviluppo locale a soluzioni basate su cloud

## Esercitarsi

Abbiamo una serie di esempi che completano gli esercizi che vedrai in tutti i capitoli di questa sezione. Inoltre, ogni capitolo ha i propri esercizi e compiti.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Risorse Aggiuntive

- [Costruire agenti usando Model Context Protocol su Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP remoto con Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agente MCP OpenAI per .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## Cosa c’è dopo

Prossimo: [Creare il tuo primo MCP Server](01-first-server/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.