<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:03:40+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "it"
}
-->
# Implementazione Pratica

L'implementazione pratica è il momento in cui la potenza del Model Context Protocol (MCP) diventa tangibile. Sebbene sia importante comprendere la teoria e l'architettura dietro MCP, il vero valore emerge quando applichi questi concetti per costruire, testare e distribuire soluzioni che risolvono problemi reali. Questo capitolo colma il divario tra conoscenza concettuale e sviluppo pratico, guidandoti nel processo di creazione di applicazioni basate su MCP.

Che tu stia sviluppando assistenti intelligenti, integrando l'AI nei flussi di lavoro aziendali o costruendo strumenti personalizzati per l'elaborazione dei dati, MCP offre una base flessibile. Il suo design indipendente dal linguaggio e gli SDK ufficiali per i linguaggi di programmazione più diffusi lo rendono accessibile a un ampio spettro di sviluppatori. Sfruttando questi SDK, puoi prototipare rapidamente, iterare e scalare le tue soluzioni su diverse piattaforme e ambienti.

Nelle sezioni seguenti troverai esempi pratici, codice di esempio e strategie di distribuzione che mostrano come implementare MCP in C#, Java, TypeScript, JavaScript e Python. Imparerai anche come fare il debug e testare i server MCP, gestire le API e distribuire soluzioni sul cloud utilizzando Azure. Queste risorse pratiche sono pensate per accelerare il tuo apprendimento e aiutarti a costruire con sicurezza applicazioni MCP robuste e pronte per la produzione.

## Panoramica

Questa lezione si concentra sugli aspetti pratici dell'implementazione MCP in diversi linguaggi di programmazione. Esploreremo come usare gli SDK MCP in C#, Java, TypeScript, JavaScript e Python per costruire applicazioni robuste, fare il debug e testare i server MCP, e creare risorse, prompt e strumenti riutilizzabili.

## Obiettivi di Apprendimento

Al termine di questa lezione sarai in grado di:
- Implementare soluzioni MCP utilizzando gli SDK ufficiali in vari linguaggi di programmazione
- Effettuare debug e test sistematici dei server MCP
- Creare e utilizzare funzionalità del server (Risorse, Prompt e Strumenti)
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

Questa sezione fornisce esempi pratici di implementazione MCP in più linguaggi di programmazione. Puoi trovare codice di esempio nella directory `samples` organizzato per linguaggio.

### Esempi Disponibili

Il repository include [implementazioni di esempio](../../../04-PracticalImplementation/samples) nei seguenti linguaggi:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Ogni esempio dimostra i concetti chiave e i modelli di implementazione MCP specifici per quel linguaggio ed ecosistema.

## Funzionalità Core del Server

I server MCP possono implementare qualsiasi combinazione di queste funzionalità:

### Risorse  
Le risorse forniscono contesto e dati per l'utente o il modello AI da utilizzare:
- Archivi di documenti
- Basi di conoscenza
- Fonti di dati strutturati
- Sistemi di file

### Prompt  
I prompt sono messaggi e flussi di lavoro template per gli utenti:
- Template di conversazione predefiniti
- Modelli di interazione guidata
- Strutture di dialogo specializzate

### Strumenti  
Gli strumenti sono funzioni che il modello AI può eseguire:
- Utilità di elaborazione dati
- Integrazioni con API esterne
- Capacità computazionali
- Funzionalità di ricerca

## Implementazioni di Esempio: C#

Il repository ufficiale C# SDK contiene diverse implementazioni di esempio che mostrano vari aspetti di MCP:

- **Basic MCP Client**: esempio semplice che mostra come creare un client MCP e chiamare gli strumenti
- **Basic MCP Server**: implementazione minima del server con registrazione base degli strumenti
- **Advanced MCP Server**: server completo con registrazione strumenti, autenticazione e gestione degli errori
- **Integrazione ASP.NET**: esempi che dimostrano l'integrazione con ASP.NET Core
- **Pattern di Implementazione degli Strumenti**: vari pattern per implementare strumenti con diversi livelli di complessità

L’SDK MCP per C# è in anteprima e le API potrebbero cambiare. Aggiorneremo continuamente questo blog man mano che l’SDK evolve.

### Funzionalità Chiave  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Costruisci il tuo [primo MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Per esempi completi di implementazione C#, visita il [repository ufficiale degli esempi C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementazione di Esempio: Java

L’SDK Java offre opzioni robuste per l’implementazione MCP con funzionalità di livello enterprise.

### Funzionalità Chiave

- Integrazione con Spring Framework
- Forte tipizzazione
- Supporto per programmazione reattiva
- Gestione completa degli errori

Per un esempio completo di implementazione Java, consulta [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) nella directory degli esempi.

## Implementazione di Esempio: JavaScript

L’SDK JavaScript offre un approccio leggero e flessibile all’implementazione MCP.

### Funzionalità Chiave

- Supporto per Node.js e browser
- API basata su Promise
- Integrazione semplice con Express e altri framework
- Supporto WebSocket per streaming

Per un esempio completo di implementazione JavaScript, consulta [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) nella directory degli esempi.

## Implementazione di Esempio: Python

L’SDK Python offre un approccio pythonico all’implementazione MCP con ottime integrazioni per framework ML.

### Funzionalità Chiave

- Supporto async/await con asyncio
- Integrazione con Flask e FastAPI
- Registrazione semplice degli strumenti
- Integrazione nativa con librerie ML popolari

Per un esempio completo di implementazione Python, consulta [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) nella directory degli esempi.

## Gestione delle API

Azure API Management è una soluzione efficace per mettere in sicurezza i server MCP. L’idea è di posizionare un’istanza di Azure API Management davanti al tuo server MCP e lasciare che gestisca funzionalità che potresti voler avere come:

- limitazione del numero di richieste (rate limiting)
- gestione dei token
- monitoraggio
- bilanciamento del carico
- sicurezza

### Esempio Azure

Ecco un esempio Azure che fa proprio questo, cioè [creare un MCP Server e metterlo in sicurezza con Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Guarda come avviene il flusso di autorizzazione nell’immagine seguente:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Nell’immagine precedente avviene quanto segue:

- L’autenticazione/autorizzazione avviene tramite Microsoft Entra.
- Azure API Management agisce da gateway e usa policy per indirizzare e gestire il traffico.
- Azure Monitor registra tutte le richieste per analisi successive.

#### Flusso di autorizzazione

Vediamo il flusso di autorizzazione più in dettaglio:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specifica di autorizzazione MCP

Scopri di più sulla [specifica di autorizzazione MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Distribuire un Remote MCP Server su Azure

Vediamo se riusciamo a distribuire l’esempio menzionato prima:

1. Clona il repository

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registra `Microsoft.App`  
   ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
   `. Then run `Register-AzResourceProvider -ProviderNamespace Microsoft.App` after some time to check if the registration is complete.

2. Run this [azd](https://aka.ms/azd) command to provision the api management service, function app(with code) and all other required Azure resources

    `  
   (Dopo un po’, verifica che la registrazione sia completata con: (Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState

3. Esegui questo comando [azd](https://aka.ms/azd) per predisporre il servizio API Management, la function app (con il codice) e tutte le altre risorse Azure necessarie

    ```shell
    azd up
    ```

    Questo comando dovrebbe distribuire tutte le risorse cloud su Azure

### Testare il tuo server con MCP Inspector

1. In una **nuova finestra del terminale**, installa e avvia MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Dovresti vedere un’interfaccia simile a questa:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.it.png) 

2. CTRL clicca per caricare l’app web MCP Inspector dall’URL mostrato dall’app (es. http://127.0.0.1:6274/#resources)
3. Imposta il tipo di trasporto su `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` e **Connetti**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Elenca gli Strumenti**. Clicca su uno strumento e **Esegui Strumento**.

Se tutti i passaggi sono andati a buon fine, ora sei connesso al server MCP e sei riuscito a chiamare uno strumento.

## Server MCP per Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Questa serie di repository è un template quickstart per costruire e distribuire server MCP remoti personalizzati utilizzando Azure Functions con Python, C# .NET o Node/TypeScript.

Gli esempi forniscono una soluzione completa che permette agli sviluppatori di:

- Costruire ed eseguire localmente: sviluppare e fare debug di un server MCP su una macchina locale
- Distribuire su Azure: distribuire facilmente sul cloud con un semplice comando azd up
- Connettersi dai client: connettersi al server MCP da vari client, inclusi la modalità agente Copilot di VS Code e lo strumento MCP Inspector

### Funzionalità Chiave:

- Sicurezza by design: il server MCP è protetto usando chiavi e HTTPS
- Opzioni di autenticazione: supporta OAuth usando autenticazione integrata e/o API Management
- Isolamento di rete: permette isolamento di rete usando Azure Virtual Networks (VNET)
- Architettura serverless: sfrutta Azure Functions per un’esecuzione scalabile e basata su eventi
- Sviluppo locale: supporto completo per sviluppo e debug locale
- Distribuzione semplice: processo di distribuzione semplificato su Azure

Il repository include tutti i file di configurazione necessari, codice sorgente e definizioni infrastrutturali per iniziare rapidamente con un’implementazione MCP pronta per la produzione.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementazione di esempio MCP usando Azure Functions con Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementazione di esempio MCP usando Azure Functions con C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementazione di esempio MCP usando Azure Functions con Node/TypeScript.

## Punti Chiave

- Gli SDK MCP offrono strumenti specifici per linguaggio per implementare soluzioni MCP robuste
- Il processo di debug e test è fondamentale per applicazioni MCP affidabili
- I template di prompt riutilizzabili permettono interazioni AI coerenti
- Flussi di lavoro ben progettati possono orchestrare compiti complessi usando più strumenti
- Implementare soluzioni MCP richiede attenzione a sicurezza, prestazioni e gestione degli errori

## Esercizio

Progetta un flusso di lavoro MCP pratico che risolva un problema reale nel tuo ambito:

1. Identifica 3-4 strumenti che sarebbero utili per risolvere questo problema
2. Crea un diagramma di flusso che mostri come questi strumenti interagiscono
3. Implementa una versione base di uno degli strumenti usando il linguaggio che preferisci
4. Crea un template di prompt che aiuti il modello a usare efficacemente il tuo strumento

## Risorse Aggiuntive


---

Successivo: [Argomenti Avanzati](../05-AdvancedTopics/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali fraintendimenti o interpretazioni errate derivanti dall’uso di questa traduzione.