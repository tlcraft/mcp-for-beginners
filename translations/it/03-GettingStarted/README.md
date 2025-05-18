<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:09:13+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "it"
}
-->
## Introduzione

Questa sezione è composta da diverse lezioni:

- **-1- Il tuo primo server**, in questa prima lezione, imparerai come creare il tuo primo server e ispezionarlo con lo strumento di ispezione, un modo prezioso per testare e fare debug del tuo server, [alla lezione](/03-GettingStarted/01-first-server/README.md)

- **-2- Client**, in questa lezione, imparerai come scrivere un client che possa connettersi al tuo server, [alla lezione](/03-GettingStarted/02-client/README.md)

- **-3- Client con LLM**, un modo ancora migliore di scrivere un client è aggiungendo un LLM in modo che possa "negoziare" con il tuo server su cosa fare, [alla lezione](/03-GettingStarted/03-llm-client/README.md)

- **-4- Utilizzo di un server in modalità Agente GitHub Copilot in Visual Studio Code**. Qui vediamo come eseguire il nostro server MCP all'interno di Visual Studio Code, [alla lezione](/03-GettingStarted/04-vscode/README.md)

- **-5- Consumo da un SSE (Server Sent Events)** SSE è uno standard per lo streaming server-to-client, permettendo ai server di inviare aggiornamenti in tempo reale ai client tramite HTTP [alla lezione](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utilizzo dell'AI Toolkit per VSCode** per consumare e testare i tuoi Client e Server MCP [alla lezione](/03-GettingStarted/06-aitk/README.md)

- **-7 Test**. Qui ci concentreremo soprattutto su come possiamo testare il nostro server e client in modi diversi, [alla lezione](/03-GettingStarted/07-testing/README.md)

- **-8- Distribuzione**. Questo capitolo esaminerà i diversi modi di distribuire le tue soluzioni MCP, [alla lezione](/03-GettingStarted/08-deployment/README.md)

Il Model Context Protocol (MCP) è un protocollo aperto che standardizza come le applicazioni forniscono contesto agli LLM. Pensa a MCP come a una porta USB-C per le applicazioni AI: fornisce un modo standardizzato per connettere i modelli AI a diverse fonti di dati e strumenti.

## Obiettivi di apprendimento

Alla fine di questa lezione, sarai in grado di:

- Configurare ambienti di sviluppo per MCP in C#, Java, Python, TypeScript e JavaScript
- Costruire e distribuire server MCP di base con funzionalità personalizzate (risorse, prompt e strumenti)
- Creare applicazioni host che si connettono ai server MCP
- Testare e fare debug delle implementazioni MCP
- Comprendere le sfide comuni di configurazione e le loro soluzioni
- Connettere le tue implementazioni MCP ai servizi LLM più popolari

## Configurazione del tuo ambiente MCP

Prima di iniziare a lavorare con MCP, è importante preparare il tuo ambiente di sviluppo e comprendere il flusso di lavoro di base. Questa sezione ti guiderà attraverso i passaggi iniziali di configurazione per garantire un avvio senza problemi con MCP.

### Prerequisiti

Prima di immergerti nello sviluppo MCP, assicurati di avere:

- **Ambiente di sviluppo**: Per il linguaggio scelto (C#, Java, Python, TypeScript o JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm o qualsiasi editor di codice moderno
- **Gestori di pacchetti**: NuGet, Maven/Gradle, pip o npm/yarn
- **Chiavi API**: Per qualsiasi servizio AI che intendi utilizzare nelle tue applicazioni host

### SDK ufficiali

Nei capitoli successivi vedrai soluzioni costruite utilizzando Python, TypeScript, Java e .NET. Ecco tutti gli SDK ufficialmente supportati.

MCP fornisce SDK ufficiali per più linguaggi:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantenuto in collaborazione con Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantenuto in collaborazione con Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - L'implementazione ufficiale TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - L'implementazione ufficiale Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - L'implementazione ufficiale Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantenuto in collaborazione con Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - L'implementazione ufficiale Rust

## Punti chiave

- Configurare un ambiente di sviluppo MCP è semplice con gli SDK specifici per linguaggio
- Costruire server MCP implica creare e registrare strumenti con schemi chiari
- I client MCP si connettono a server e modelli per sfruttare capacità estese
- Testare e fare debug sono essenziali per implementazioni MCP affidabili
- Le opzioni di distribuzione variano dallo sviluppo locale a soluzioni basate su cloud

## Pratica

Abbiamo una serie di esempi che completano gli esercizi che vedrai in tutti i capitoli di questa sezione. Inoltre, ogni capitolo ha anche i propri esercizi e compiti

- [Calcolatrice Java](./samples/java/calculator/README.md)
- [Calcolatrice .Net](../../../03-GettingStarted/samples/csharp)
- [Calcolatrice JavaScript](./samples/javascript/README.md)
- [Calcolatrice TypeScript](./samples/typescript/README.md)
- [Calcolatrice Python](../../../03-GettingStarted/samples/python)

## Risorse aggiuntive

- [Repository GitHub MCP](https://github.com/microsoft/mcp-for-beginners)

## Cosa c'è dopo

Prossimo: [Creare il tuo primo server MCP](/03-GettingStarted/01-first-server/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatizzate possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.