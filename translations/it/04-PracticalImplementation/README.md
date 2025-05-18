<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:50:35+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "it"
}
-->
# Implementazione Pratica

L'implementazione pratica è dove il potere del Model Context Protocol (MCP) diventa tangibile. Sebbene comprendere la teoria e l'architettura dietro MCP sia importante, il vero valore emerge quando si applicano questi concetti per costruire, testare e distribuire soluzioni che risolvono problemi reali. Questo capitolo colma il divario tra conoscenza concettuale e sviluppo pratico, guidandoti nel processo di realizzazione delle applicazioni basate su MCP.

Che tu stia sviluppando assistenti intelligenti, integrando l'IA nei flussi di lavoro aziendali o costruendo strumenti personalizzati per l'elaborazione dei dati, MCP fornisce una base flessibile. Il suo design indipendente dal linguaggio e gli SDK ufficiali per i linguaggi di programmazione più popolari lo rendono accessibile a una vasta gamma di sviluppatori. Sfruttando questi SDK, puoi rapidamente prototipare, iterare e scalare le tue soluzioni su diverse piattaforme e ambienti.

Nelle sezioni seguenti troverai esempi pratici, codice di esempio e strategie di distribuzione che dimostrano come implementare MCP in C#, Java, TypeScript, JavaScript e Python. Imparerai anche come eseguire il debug e testare i server MCP, gestire le API e distribuire soluzioni nel cloud utilizzando Azure. Queste risorse pratiche sono progettate per accelerare il tuo apprendimento e aiutarti a costruire applicazioni MCP robuste e pronte per la produzione con fiducia.

## Panoramica

Questa lezione si concentra sugli aspetti pratici dell'implementazione di MCP in diversi linguaggi di programmazione. Esploreremo come utilizzare gli SDK MCP in C#, Java, TypeScript, JavaScript e Python per costruire applicazioni robuste, eseguire il debug e testare i server MCP e creare risorse, prompt e strumenti riutilizzabili.

## Obiettivi di Apprendimento

Alla fine di questa lezione, sarai in grado di:
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

Questa sezione fornisce esempi pratici di implementazione di MCP in diversi linguaggi di programmazione. Puoi trovare il codice di esempio nella directory `samples` organizzata per linguaggio.

### Esempi Disponibili

Il repository include implementazioni di esempio nei seguenti linguaggi:

- C#
- Java
- TypeScript
- JavaScript
- Python

Ogni esempio dimostra i concetti chiave di MCP e i modelli di implementazione per quel linguaggio ed ecosistema specifico.

## Funzionalità Principali del Server

I server MCP possono implementare qualsiasi combinazione di queste funzionalità:

### Risorse
Le risorse forniscono contesto e dati per l'utente o il modello AI da utilizzare:
- Repository di documenti
- Basi di conoscenza
- Fonti di dati strutturati
- Sistemi di file

### Prompt
I prompt sono messaggi e flussi di lavoro predefiniti per gli utenti:
- Modelli di conversazione predefiniti
- Modelli di interazione guidata
- Strutture di dialogo specializzate

### Strumenti
Gli strumenti sono funzioni che il modello AI può eseguire:
- Utilità di elaborazione dati
- Integrazioni API esterne
- Capacità computazionali
- Funzionalità di ricerca

## Implementazioni di Esempio: C#

Il repository ufficiale dell'SDK C# contiene diverse implementazioni di esempio che dimostrano diversi aspetti di MCP:

- **Client MCP di base**: Esempio semplice che mostra come creare un client MCP e chiamare strumenti
- **Server MCP di base**: Implementazione minima del server con registrazione di strumenti di base
- **Server MCP avanzato**: Server completo con registrazione di strumenti, autenticazione e gestione degli errori
- **Integrazione ASP.NET**: Esempi che dimostrano l'integrazione con ASP.NET Core
- **Modelli di Implementazione degli Strumenti**: Vari modelli per implementare strumenti con diversi livelli di complessità

L'SDK C# MCP è in anteprima e le API potrebbero cambiare. Aggiorneremo continuamente questo blog man mano che l'SDK evolve.

### Funzionalità Chiave
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Costruire il tuo [primo Server MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Per esempi completi di implementazione in C#, visita il [repository ufficiale degli esempi SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementazione di Esempio: Implementazione Java

L'SDK Java offre opzioni di implementazione MCP robuste con funzionalità di livello enterprise.

### Funzionalità Chiave

- Integrazione Spring Framework
- Forte sicurezza dei tipi
- Supporto alla programmazione reattiva
- Gestione completa degli errori

Per un esempio completo di implementazione Java, vedi [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) nella directory degli esempi.

## Implementazione di Esempio: Implementazione JavaScript

L'SDK JavaScript fornisce un approccio leggero e flessibile all'implementazione di MCP.

### Funzionalità Chiave

- Supporto per Node.js e browser
- API basata su Promise
- Facile integrazione con Express e altri framework
- Supporto WebSocket per lo streaming

Per un esempio completo di implementazione JavaScript, vedi [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) nella directory degli esempi.

## Implementazione di Esempio: Implementazione Python

L'SDK Python offre un approccio Pythonico all'implementazione di MCP con eccellenti integrazioni ai framework ML.

### Funzionalità Chiave

- Supporto Async/await con asyncio
- Integrazione con Flask e FastAPI
- Registrazione semplice degli strumenti
- Integrazione nativa con librerie ML popolari

Per un esempio completo di implementazione Python, vedi [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) nella directory degli esempi.

## Gestione delle API

Azure API Management è una grande risposta a come possiamo proteggere i server MCP. L'idea è di posizionare un'istanza di Azure API Management davanti al tuo server MCP e lasciare che gestisca le funzionalità che probabilmente desideri come:

- limitazione della velocità
- gestione dei token
- monitoraggio
- bilanciamento del carico
- sicurezza

### Esempio Azure

Ecco un esempio Azure che fa esattamente questo, cioè [creare un server MCP e proteggerlo con Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Guarda come avviene il flusso di autorizzazione nell'immagine seguente:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

Nell'immagine precedente, avviene quanto segue:

- L'autenticazione/autorizzazione avviene utilizzando Microsoft Entra.
- Azure API Management agisce come gateway e utilizza politiche per dirigere e gestire il traffico.
- Azure Monitor registra tutte le richieste per ulteriori analisi.

#### Flusso di autorizzazione

Diamo uno sguardo più dettagliato al flusso di autorizzazione:

![Diagramma di Sequenza](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Specifica di autorizzazione MCP

Scopri di più sulla [specifica di autorizzazione MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Distribuire il Server MCP Remoto su Azure

Vediamo se possiamo distribuire l'esempio menzionato in precedenza:

1. Clona il repository

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registra `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` dopo un po' di tempo per verificare se la registrazione è completa.

2. Esegui questo comando [azd](https://aka.ms/azd) per fornire il servizio di gestione delle API, l'applicazione delle funzioni (con codice) e tutte le altre risorse Azure richieste

    ```shell
    azd up
    ```

    Questo comando dovrebbe distribuire tutte le risorse cloud su Azure

### Testare il tuo server con MCP Inspector

1. In una **nuova finestra del terminale**, installa ed esegui MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Dovresti vedere un'interfaccia simile a:

    ![Connetti al nodo inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.it.png)

1. CTRL clicca per caricare l'app web MCP Inspector dall'URL visualizzato dall'app (es. http://127.0.0.1:6274/#resources)
1. Imposta il tipo di trasporto su `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` e **Connetti**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Elenca Strumenti**. Clicca su uno strumento e **Esegui Strumento**.

Se tutti i passaggi hanno funzionato, dovresti ora essere connesso al server MCP e hai potuto chiamare uno strumento.

## Server MCP per Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Questo set di repository sono modelli di avvio rapido per costruire e distribuire server MCP (Model Context Protocol) remoti personalizzati utilizzando Azure Functions con Python, C# .NET o Node/TypeScript.

I campioni forniscono una soluzione completa che consente agli sviluppatori di:

- Costruire ed eseguire localmente: Sviluppare e eseguire il debug di un server MCP su una macchina locale
- Distribuire su Azure: Distribuire facilmente nel cloud con un semplice comando azd up
- Connettersi dai client: Connettersi al server MCP da vari client inclusa la modalità agente Copilot di VS Code e lo strumento MCP Inspector

### Funzionalità Chiave:

- Sicurezza per design: Il server MCP è protetto utilizzando chiavi e HTTPS
- Opzioni di autenticazione: Supporta OAuth utilizzando autenticazione integrata e/o gestione API
- Isolamento della rete: Consente l'isolamento della rete utilizzando Azure Virtual Networks (VNET)
- Architettura serverless: Sfrutta Azure Functions per esecuzioni scalabili e guidate dagli eventi
- Sviluppo locale: Supporto completo per lo sviluppo e il debug locale
- Distribuzione semplice: Processo di distribuzione semplificato su Azure

Il repository include tutti i file di configurazione necessari, il codice sorgente e le definizioni dell'infrastruttura per iniziare rapidamente con un'implementazione del server MCP pronta per la produzione.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementazione di esempio di MCP utilizzando Azure Functions con Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementazione di esempio di MCP utilizzando Azure Functions con C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementazione di esempio di MCP utilizzando Azure Functions con Node/TypeScript.

## Punti Chiave

- Gli SDK MCP forniscono strumenti specifici per linguaggio per implementare soluzioni MCP robuste
- Il processo di debug e test è critico per applicazioni MCP affidabili
- I modelli di prompt riutilizzabili consentono interazioni AI coerenti
- I flussi di lavoro ben progettati possono orchestrare compiti complessi utilizzando più strumenti
- Implementare soluzioni MCP richiede considerazione di sicurezza, prestazioni e gestione degli errori

## Esercizio

Progetta un flusso di lavoro MCP pratico che affronti un problema reale nel tuo dominio:

1. Identifica 3-4 strumenti che sarebbero utili per risolvere questo problema
2. Crea un diagramma di flusso che mostri come questi strumenti interagiscono
3. Implementa una versione base di uno degli strumenti utilizzando il tuo linguaggio preferito
4. Crea un modello di prompt che aiuterebbe il modello a utilizzare efficacemente il tuo strumento

## Risorse Aggiuntive

---

Prossimo: [Argomenti Avanzati](../05-AdvancedTopics/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.