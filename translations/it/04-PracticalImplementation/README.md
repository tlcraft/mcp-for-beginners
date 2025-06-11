<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:12:22+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "it"
}
-->
# Implementazione Pratica

L'implementazione pratica è il momento in cui la potenza del Model Context Protocol (MCP) diventa concreta. Sebbene comprendere la teoria e l'architettura dietro MCP sia importante, il vero valore emerge quando applichi questi concetti per costruire, testare e distribuire soluzioni che risolvono problemi reali. Questo capitolo colma il divario tra conoscenza concettuale e sviluppo pratico, guidandoti nel processo di realizzazione di applicazioni basate su MCP.

Che tu stia sviluppando assistenti intelligenti, integrando l'AI nei flussi di lavoro aziendali o costruendo strumenti personalizzati per l'elaborazione dati, MCP offre una base flessibile. Il suo design indipendente dal linguaggio e gli SDK ufficiali per i linguaggi di programmazione più diffusi lo rendono accessibile a un ampio spettro di sviluppatori. Sfruttando questi SDK, puoi prototipare rapidamente, iterare e scalare le tue soluzioni su diverse piattaforme e ambienti.

Nelle sezioni seguenti troverai esempi pratici, codice di esempio e strategie di distribuzione che mostrano come implementare MCP in C#, Java, TypeScript, JavaScript e Python. Imparerai anche come fare il debug e testare i server MCP, gestire le API e distribuire soluzioni nel cloud usando Azure. Queste risorse pratiche sono pensate per accelerare il tuo apprendimento e aiutarti a costruire con sicurezza applicazioni MCP robuste e pronte per la produzione.

## Panoramica

Questa lezione si concentra sugli aspetti pratici dell'implementazione MCP in diversi linguaggi di programmazione. Esploreremo come utilizzare gli SDK MCP in C#, Java, TypeScript, JavaScript e Python per costruire applicazioni robuste, fare debug e testare i server MCP, e creare risorse, prompt e strumenti riutilizzabili.

## Obiettivi di Apprendimento

Al termine di questa lezione sarai in grado di:
- Implementare soluzioni MCP usando gli SDK ufficiali in vari linguaggi di programmazione
- Effettuare debug e test sistematici dei server MCP
- Creare e utilizzare funzionalità server (Resources, Prompts e Tools)
- Progettare workflow MCP efficaci per compiti complessi
- Ottimizzare le implementazioni MCP per prestazioni e affidabilità

## Risorse SDK Ufficiali

Il Model Context Protocol offre SDK ufficiali per diversi linguaggi:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Lavorare con gli SDK MCP

Questa sezione fornisce esempi pratici di implementazione MCP in più linguaggi di programmazione. Puoi trovare codice di esempio nella directory `samples` organizzata per linguaggio.

### Esempi Disponibili

Il repository include implementazioni di esempio nei seguenti linguaggi:

- C#
- Java
- TypeScript
- JavaScript
- Python

Ogni esempio dimostra i concetti chiave di MCP e i pattern di implementazione specifici per quel linguaggio e ecosistema.

## Funzionalità Core del Server

I server MCP possono implementare qualsiasi combinazione di queste funzionalità:

### Resources
Le risorse forniscono contesto e dati da utilizzare per l'utente o il modello AI:
- Repositori di documenti
- Basi di conoscenza
- Fonti di dati strutturati
- Sistemi di file

### Prompts
I prompt sono messaggi e workflow template per gli utenti:
- Template di conversazione predefiniti
- Schemi di interazione guidata
- Strutture di dialogo specializzate

### Tools
Gli strumenti sono funzioni eseguibili dal modello AI:
- Utility per l'elaborazione dati
- Integrazioni con API esterne
- Capacità computazionali
- Funzionalità di ricerca

## Implementazioni di esempio: C#

Il repository ufficiale C# SDK contiene diversi esempi che mostrano vari aspetti di MCP:

- **Basic MCP Client**: esempio semplice che mostra come creare un client MCP e chiamare gli strumenti
- **Basic MCP Server**: implementazione minima del server con registrazione base degli strumenti
- **Advanced MCP Server**: server completo con registrazione degli strumenti, autenticazione e gestione degli errori
- **ASP.NET Integration**: esempi di integrazione con ASP.NET Core
- **Tool Implementation Patterns**: diversi pattern per implementare strumenti con vari livelli di complessità

L'SDK MCP per C# è in preview e le API potrebbero cambiare. Aggiorneremo continuamente questo blog man mano che l'SDK si evolve.

### Funzionalità Chiave
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Costruire il tuo [primo MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Per esempi completi di implementazione in C#, visita il [repository ufficiale degli esempi C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementazione di esempio: Java

L'SDK Java offre opzioni robuste per l'implementazione MCP con funzionalità di livello enterprise.

### Funzionalità Chiave

- Integrazione con Spring Framework
- Forte sicurezza dei tipi
- Supporto per programmazione reattiva
- Gestione completa degli errori

Per un esempio completo di implementazione Java, vedi [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) nella directory degli esempi.

## Implementazione di esempio: JavaScript

L'SDK JavaScript offre un approccio leggero e flessibile per l'implementazione MCP.

### Funzionalità Chiave

- Supporto per Node.js e browser
- API basata su Promise
- Integrazione semplice con Express e altri framework
- Supporto WebSocket per streaming

Per un esempio completo di implementazione JavaScript, vedi [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) nella directory degli esempi.

## Implementazione di esempio: Python

L'SDK Python propone un approccio "Pythonic" all'implementazione MCP con ottime integrazioni per framework ML.

### Funzionalità Chiave

- Supporto async/await con asyncio
- Integrazione con Flask e FastAPI
- Registrazione strumenti semplice
- Integrazione nativa con librerie ML popolari

Per un esempio completo di implementazione Python, vedi [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) nella directory degli esempi.

## Gestione API

Azure API Management è una soluzione efficace per mettere in sicurezza i server MCP. L'idea è posizionare un'istanza di Azure API Management davanti al tuo server MCP e lasciare che gestisca funzionalità che potresti voler avere come:

- limitazione delle richieste
- gestione dei token
- monitoraggio
- bilanciamento del carico
- sicurezza

### Esempio Azure

Ecco un esempio Azure che fa proprio questo, cioè [creare un MCP Server e metterlo in sicurezza con Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Guarda come avviene il flusso di autorizzazione nell'immagine seguente:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Nell'immagine sopra accade quanto segue:

- L'autenticazione/autorizzazione avviene tramite Microsoft Entra.
- Azure API Management funge da gateway e utilizza policy per dirigere e gestire il traffico.
- Azure Monitor registra tutte le richieste per analisi successive.

#### Flusso di autorizzazione

Esaminiamo il flusso di autorizzazione più nel dettaglio:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specifica autorizzazione MCP

Scopri di più sulla [specifica MCP Authorization](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Distribuire un Remote MCP Server su Azure

Vediamo se riusciamo a distribuire l'esempio menzionato prima:

1. Clona il repository

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registra `Microsoft.App` con il comando `az provider register --namespace Microsoft.App --wait` oppure `Register-AzResourceProvider -ProviderNamespace Microsoft.App` e dopo un po' verifica lo stato con `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`.

3. Esegui questo comando [azd](https://aka.ms/azd) per creare il servizio di API Management, la function app (con codice) e tutte le altre risorse Azure necessarie

    ```shell
    azd up
    ```

    Questo comando dovrebbe distribuire tutte le risorse cloud su Azure

### Testare il server con MCP Inspector

1. In una **nuova finestra del terminale**, installa e avvia MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Dovresti vedere un'interfaccia simile a questa:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.it.png)

2. CTRL clicca per caricare la web app MCP Inspector dall'URL mostrato dall'app (es. http://127.0.0.1:6274/#resources)
3. Imposta il tipo di trasporto su `SSE` e clicca su **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Lista degli strumenti**. Clicca su uno strumento e seleziona **Run Tool**.

Se tutti i passaggi sono andati a buon fine, ora sei connesso al server MCP e sei riuscito a chiamare uno strumento.

## Server MCP per Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Questa serie di repository è un template quickstart per costruire e distribuire server MCP remoti personalizzati usando Azure Functions con Python, C# .NET o Node/TypeScript.

I sample offrono una soluzione completa che permette agli sviluppatori di:

- Costruire ed eseguire in locale: sviluppare e fare debug di un server MCP sulla propria macchina
- Distribuire su Azure: distribuire facilmente nel cloud con un semplice comando azd up
- Connettersi dai client: connettersi al server MCP da vari client, incluso il Copilot agent mode di VS Code e lo strumento MCP Inspector

### Funzionalità Chiave:

- Sicurezza by design: il server MCP è protetto tramite chiavi e HTTPS
- Opzioni di autenticazione: supporta OAuth tramite autenticazione integrata e/o API Management
- Isolamento di rete: permette l'isolamento di rete usando Azure Virtual Networks (VNET)
- Architettura serverless: sfrutta Azure Functions per un'esecuzione scalabile e basata su eventi
- Sviluppo locale: supporto completo per sviluppo e debug in locale
- Distribuzione semplice: processo di distribuzione semplificato su Azure

Il repository include tutti i file di configurazione necessari, il codice sorgente e le definizioni infrastrutturali per iniziare rapidamente con un'implementazione MCP pronta per la produzione.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementazione di esempio MCP usando Azure Functions con Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementazione di esempio MCP usando Azure Functions con C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementazione di esempio MCP usando Azure Functions con Node/TypeScript.

## Punti Chiave

- Gli SDK MCP forniscono strumenti specifici per linguaggio per implementare soluzioni MCP robuste
- Il processo di debug e test è fondamentale per applicazioni MCP affidabili
- I template di prompt riutilizzabili permettono interazioni AI coerenti
- Workflow ben progettati possono orchestrare compiti complessi usando più strumenti
- Implementare soluzioni MCP richiede attenzione a sicurezza, prestazioni e gestione degli errori

## Esercizio

Progetta un workflow MCP pratico che risolva un problema reale nel tuo ambito:

1. Identifica 3-4 strumenti utili per risolvere questo problema
2. Crea un diagramma del workflow che mostri come questi strumenti interagiscono
3. Implementa una versione base di uno degli strumenti usando il linguaggio che preferisci
4. Crea un template di prompt che aiuti il modello a usare efficacemente il tuo strumento

## Risorse Aggiuntive


---

Successivo: [Argomenti Avanzati](../05-AdvancedTopics/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per l'accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.