<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "bb1ab5c924f58cf75ef1732d474f008a",
  "translation_date": "2025-07-14T17:13:24+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "it"
}
-->
# Implementazione Pratica

L'implementazione pratica è il momento in cui la potenza del Model Context Protocol (MCP) diventa tangibile. Sebbene comprendere la teoria e l'architettura dietro MCP sia importante, il vero valore emerge quando applichi questi concetti per costruire, testare e distribuire soluzioni che risolvono problemi reali. Questo capitolo colma il divario tra conoscenza concettuale e sviluppo pratico, guidandoti nel processo di realizzazione di applicazioni basate su MCP.

Che tu stia sviluppando assistenti intelligenti, integrando l'IA nei flussi di lavoro aziendali o creando strumenti personalizzati per l'elaborazione dei dati, MCP offre una base flessibile. Il suo design indipendente dal linguaggio e gli SDK ufficiali per i linguaggi di programmazione più diffusi lo rendono accessibile a un ampio spettro di sviluppatori. Sfruttando questi SDK, puoi prototipare rapidamente, iterare e scalare le tue soluzioni su diverse piattaforme e ambienti.

Nelle sezioni seguenti troverai esempi pratici, codice di esempio e strategie di distribuzione che mostrano come implementare MCP in C#, Java, TypeScript, JavaScript e Python. Imparerai anche come eseguire il debug e testare i server MCP, gestire le API e distribuire soluzioni nel cloud usando Azure. Queste risorse pratiche sono pensate per accelerare il tuo apprendimento e aiutarti a costruire con sicurezza applicazioni MCP robuste e pronte per la produzione.

## Panoramica

Questa lezione si concentra sugli aspetti pratici dell'implementazione MCP in diversi linguaggi di programmazione. Esploreremo come utilizzare gli SDK MCP in C#, Java, TypeScript, JavaScript e Python per costruire applicazioni robuste, eseguire il debug e testare i server MCP, e creare risorse, prompt e strumenti riutilizzabili.

## Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:
- Implementare soluzioni MCP utilizzando gli SDK ufficiali in vari linguaggi di programmazione
- Eseguire il debug e testare sistematicamente i server MCP
- Creare e utilizzare funzionalità server (Risorse, Prompt e Strumenti)
- Progettare flussi di lavoro MCP efficaci per compiti complessi
- Ottimizzare le implementazioni MCP per prestazioni e affidabilità

## Risorse SDK Ufficiali

Il Model Context Protocol offre SDK ufficiali per diversi linguaggi:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Lavorare con gli SDK MCP

Questa sezione fornisce esempi pratici di implementazione MCP in diversi linguaggi di programmazione. Puoi trovare codice di esempio nella directory `samples` organizzata per linguaggio.

### Esempi Disponibili

Il repository include [implementazioni di esempio](../../../04-PracticalImplementation/samples) nei seguenti linguaggi:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Ogni esempio dimostra i concetti chiave di MCP e i modelli di implementazione specifici per quel linguaggio ed ecosistema.

## Funzionalità Core del Server

I server MCP possono implementare qualsiasi combinazione di queste funzionalità:

### Risorse
Le risorse forniscono contesto e dati da utilizzare per l'utente o il modello AI:
- Archivi di documenti
- Basi di conoscenza
- Fonti di dati strutturati
- Sistemi di file

### Prompt
I prompt sono messaggi e flussi di lavoro predefiniti per gli utenti:
- Template di conversazione predefiniti
- Modelli di interazione guidata
- Strutture di dialogo specializzate

### Strumenti
Gli strumenti sono funzioni che il modello AI può eseguire:
- Utilità per l'elaborazione dei dati
- Integrazioni con API esterne
- Capacità computazionali
- Funzionalità di ricerca

## Esempi di Implementazione: C#

Il repository ufficiale del C# SDK contiene diversi esempi che mostrano vari aspetti di MCP:

- **Basic MCP Client**: esempio semplice che mostra come creare un client MCP e chiamare strumenti
- **Basic MCP Server**: implementazione minima di un server con registrazione base degli strumenti
- **Advanced MCP Server**: server completo con registrazione strumenti, autenticazione e gestione degli errori
- **Integrazione ASP.NET**: esempi che mostrano l'integrazione con ASP.NET Core
- **Pattern di Implementazione degli Strumenti**: vari pattern per implementare strumenti con diversi livelli di complessità

L’SDK MCP per C# è in anteprima e le API potrebbero cambiare. Aggiorneremo continuamente questo blog man mano che l’SDK evolve.

### Funzionalità Chiave
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Costruisci il tuo [primo MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Per esempi completi di implementazione in C#, visita il [repository ufficiale degli esempi C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Esempio di implementazione: Java

Il Java SDK offre opzioni robuste per l’implementazione MCP con funzionalità di livello enterprise.

### Funzionalità Chiave

- Integrazione con Spring Framework
- Forte tipizzazione
- Supporto alla programmazione reattiva
- Gestione completa degli errori

Per un esempio completo di implementazione Java, consulta [Java sample](samples/java/containerapp/README.md) nella directory degli esempi.

## Esempio di implementazione: JavaScript

Il JavaScript SDK offre un approccio leggero e flessibile all’implementazione MCP.

### Funzionalità Chiave

- Supporto per Node.js e browser
- API basata su Promise
- Facile integrazione con Express e altri framework
- Supporto WebSocket per lo streaming

Per un esempio completo di implementazione JavaScript, consulta [JavaScript sample](samples/javascript/README.md) nella directory degli esempi.

## Esempio di implementazione: Python

Il Python SDK offre un approccio "pythonic" all’implementazione MCP con ottime integrazioni per framework ML.

### Funzionalità Chiave

- Supporto async/await con asyncio
- Integrazione con FastAPI
- Registrazione semplice degli strumenti
- Integrazione nativa con librerie ML popolari

Per un esempio completo di implementazione Python, consulta [Python sample](samples/python/README.md) nella directory degli esempi.

## Gestione API

Azure API Management è una soluzione efficace per proteggere i server MCP. L’idea è mettere un’istanza di Azure API Management davanti al tuo server MCP e lasciargli gestire funzionalità che probabilmente vorrai come:

- limitazione del traffico (rate limiting)
- gestione dei token
- monitoraggio
- bilanciamento del carico
- sicurezza

### Esempio Azure

Ecco un esempio Azure che fa esattamente questo, cioè [creare un MCP Server e proteggerlo con Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Guarda come avviene il flusso di autorizzazione nell’immagine sottostante:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Nell’immagine precedente, avvengono le seguenti operazioni:

- Autenticazione/Autorizzazione tramite Microsoft Entra.
- Azure API Management agisce come gateway e utilizza policy per indirizzare e gestire il traffico.
- Azure Monitor registra tutte le richieste per analisi successive.

#### Flusso di autorizzazione

Vediamo più nel dettaglio il flusso di autorizzazione:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specifica di autorizzazione MCP

Scopri di più sulla [specifica di autorizzazione MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Distribuire un Server MCP Remoto su Azure

Vediamo se riusciamo a distribuire l’esempio menzionato prima:

1. Clona il repository

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registra il provider di risorse `Microsoft.App`.
    * Se usi Azure CLI, esegui `az provider register --namespace Microsoft.App --wait`.
    * Se usi Azure PowerShell, esegui `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Poi esegui `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` dopo un po’ per verificare se la registrazione è completata.

2. Esegui questo comando [azd](https://aka.ms/azd) per predisporre il servizio di API Management, la function app (con codice) e tutte le altre risorse Azure necessarie

    ```shell
    azd up
    ```

    Questo comando dovrebbe distribuire tutte le risorse cloud su Azure

### Testare il server con MCP Inspector

1. In una **nuova finestra del terminale**, installa ed esegui MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Dovresti vedere un’interfaccia simile a:

    ![Connect to Node inspector](/03-GettingStarted/01-first-server/assets/connect.png) 

1. CTRL clicca per caricare l’app web MCP Inspector dall’URL mostrato dall’app (es. http://127.0.0.1:6274/#resources)
1. Imposta il tipo di trasporto su `SSE`
1. Imposta l’URL sul tuo endpoint SSE di API Management in esecuzione mostrato dopo `azd up` e **Connetti**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Elenca gli Strumenti**. Clicca su uno strumento e **Esegui Strumento**.

Se tutti i passaggi sono andati a buon fine, ora dovresti essere connesso al server MCP e aver potuto chiamare uno strumento.

## Server MCP per Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Questa serie di repository è un template quickstart per costruire e distribuire server MCP remoti personalizzati usando Azure Functions con Python, C# .NET o Node/TypeScript.

Gli esempi forniscono una soluzione completa che permette agli sviluppatori di:

- Costruire ed eseguire localmente: sviluppare e fare il debug di un server MCP su macchina locale
- Distribuire su Azure: distribuire facilmente nel cloud con un semplice comando azd up
- Connettersi dai client: connettersi al server MCP da vari client, incluso il modo agente Copilot di VS Code e lo strumento MCP Inspector

### Funzionalità Chiave:

- Sicurezza by design: il server MCP è protetto tramite chiavi e HTTPS
- Opzioni di autenticazione: supporta OAuth usando autenticazione integrata e/o API Management
- Isolamento di rete: permette isolamento di rete usando Azure Virtual Networks (VNET)
- Architettura serverless: sfrutta Azure Functions per esecuzione scalabile e basata su eventi
- Sviluppo locale: supporto completo per sviluppo e debug locale
- Distribuzione semplice: processo di distribuzione semplificato su Azure

Il repository include tutti i file di configurazione necessari, codice sorgente e definizioni infrastrutturali per iniziare rapidamente con un’implementazione MCP pronta per la produzione.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Esempio di implementazione MCP usando Azure Functions con Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Esempio di implementazione MCP usando Azure Functions con C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Esempio di implementazione MCP usando Azure Functions con Node/TypeScript.

## Punti Chiave

- Gli SDK MCP forniscono strumenti specifici per linguaggio per implementare soluzioni MCP robuste
- Il processo di debug e test è fondamentale per applicazioni MCP affidabili
- I template di prompt riutilizzabili permettono interazioni AI coerenti
- Flussi di lavoro ben progettati possono orchestrare compiti complessi usando più strumenti
- Implementare soluzioni MCP richiede attenzione a sicurezza, prestazioni e gestione degli errori

## Esercizio

Progetta un flusso di lavoro MCP pratico che affronti un problema reale nel tuo ambito:

1. Identifica 3-4 strumenti che sarebbero utili per risolvere questo problema
2. Crea un diagramma del flusso di lavoro che mostri come questi strumenti interagiscono
3. Implementa una versione base di uno degli strumenti usando il linguaggio che preferisci
4. Crea un template di prompt che aiuti il modello a usare efficacemente il tuo strumento

## Risorse Aggiuntive


---

Successivo: [Argomenti Avanzati](../05-AdvancedTopics/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.