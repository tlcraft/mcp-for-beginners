<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c7fbf0cdaa44b3245daff0c8bb4f439e",
  "translation_date": "2025-06-11T15:29:18+00:00",
  "source_file": "README.md",
  "language_code": "it"
}
-->
![MCP-per-principianti](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.it.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Segui questi passaggi per iniziare a usare queste risorse:
1. **Forka il Repository**: Clicca su [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clona il Repository**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Unisciti al Discord di Azure AI Foundry per incontrare esperti e altri sviluppatori**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Supporto Multilingue

#### Supportato tramite GitHub Action (Automatizzato e Sempre Aggiornato)

# 🚀 Curriculum Protocollo Model Context (MCP) per Principianti

## **Impara MCP con esempi pratici in C#, Java, JavaScript, Python e TypeScript**

## 🧠 Panoramica del Curriculum Protocollo Model Context

Il **Model Context Protocol (MCP)** è un framework all'avanguardia progettato per standardizzare le interazioni tra modelli AI e applicazioni client. Questo curriculum open-source offre un percorso di apprendimento strutturato, completo di esempi di codice pratici e casi d'uso reali, in diversi linguaggi di programmazione popolari come C#, Java, JavaScript, TypeScript e Python.

Che tu sia uno sviluppatore AI, un architetto di sistema o un ingegnere software, questa guida è la tua risorsa completa per padroneggiare i fondamenti e le strategie di implementazione di MCP.

## 🔗 Risorse Ufficiali MCP

- 📘 [MCP Documentation](https://modelcontextprotocol.io/) – Tutorial dettagliati e guide per l’utente  
- 📜 [MCP Specification](https://spec.modelcontextprotocol.io/) – Architettura del protocollo e riferimenti tecnici  
- 🧑‍💻 [MCP GitHub Repository](https://github.com/modelcontextprotocol) – SDK open-source, strumenti ed esempi di codice  

## 🧭 Struttura Completa del Curriculum MCP

| Ch | Titolo | Descrizione | Link |
|--|--|--|--|
| 00 | **Introduzione a MCP** | Panoramica del Model Context Protocol e della sua importanza nelle pipeline AI, inclusi cosa è il Model Context Protocol, perché la standardizzazione è importante e casi d’uso pratici e benefici | [Introduction](./00-Introduction/README.md) |
| 01 | **Concetti Fondamentali Spiegati** | Esplorazione approfondita dei concetti base di MCP, inclusa l’architettura client-server, componenti chiave del protocollo e modelli di messaggistica | [Core Concepts](./01-CoreConcepts/README.md) |
| 02 | **Sicurezza in MCP** | Identificazione delle minacce alla sicurezza nei sistemi basati su MCP, tecniche e best practice per proteggere le implementazioni | [Security](/02-Security/README.md) |
| 03 | **Primi Passi con MCP** | Configurazione dell’ambiente, creazione di server e client MCP base, integrazione di MCP con applicazioni esistenti | [Getting Started](./03-GettingStarted/README.md) |
| 3.1 | **Primo server** | Configurazione di un server base usando il protocollo MCP, comprensione dell’interazione server-client e test del server | [First Server](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Primo client**  | Configurazione di un client base usando il protocollo MCP, comprensione dell’interazione client-server e test del client | [First Client](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Client con LLM**  | Configurazione di un client MCP con un Large Language Model (LLM) | [Client with LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Consumare un server con Visual Studio Code** | Configurazione di Visual Studio Code per consumare server usando il protocollo MCP | [Consuming a server with Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Creare un server usando SSE** | SSE ci aiuta a esporre un server su internet. Questa sezione ti guiderà nella creazione di un server usando SSE | [Creating a server using SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Usare AI Toolkit** | AI Toolkit è uno strumento utile per gestire il tuo flusso di lavoro AI e MCP | [Use AI Toolkit](./03-GettingStarted/06-aitk/README.md) |
| 3.7 | **Testare il tuo server** | Il testing è una parte fondamentale del processo di sviluppo. Questa sezione ti aiuterà a testare usando diversi strumenti | [Testing your server](./03-GettingStarted/07-testing/README.md) |
| 3.8 | **Distribuire il tuo server** | Come passare dallo sviluppo locale alla produzione? Questa sezione ti guiderà nello sviluppo e nella distribuzione del server | [Deploy your server](./03-GettingStarted/08-deployment/README.md) |
| 04 | **Implementazione Pratica** | Uso degli SDK in diversi linguaggi, debugging, testing e validazione, creazione di template di prompt e workflow riutilizzabili | [Practical Implementation](./04-PracticalImplementation/README.md) |
| 05 | **Argomenti Avanzati in MCP** | Workflow AI multimodali ed estendibilità, strategie di scaling sicuro, MCP negli ecosistemi enterprise | [Advanced Topics](./05-AdvancedTopics/README.md) |
| 5.1 | **Integrazione MCP con Azure** | Mostra l’integrazione con Azure | [MCP Azure integration](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalità** | Come lavorare con diverse modalità come immagini e altro | [Multi modality](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demo MCP OAuth2** | Applicazione Spring Boot minimale che mostra OAuth2 con MCP, sia come Authorization che Resource Server. Dimostra emissione sicura di token, endpoint protetti, deployment su Azure Container Apps e integrazione con API Management | [MCP OAuth2 Demo](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Root Contexts** | Approfondisci i root context e come implementarli | [Root Contexts](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Routing** | Scopri i diversi tipi di routing | [Routing](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Sampling** | Impara a lavorare con il sampling | [Sampling](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Scaling** | Scopri come scalare i server MCP, incluse strategie di scaling orizzontale e verticale, ottimizzazione delle risorse e tuning delle prestazioni | [Scaling](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Sicurezza** | Metti in sicurezza il tuo MCP Server, inclusi strategie di autenticazione, autorizzazione e protezione dei dati | [Security](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Web Search MCP** | Server e client MCP in Python integrati con SerpAPI per ricerca web, news, prodotti e Q&A in tempo reale. Dimostra orchestrazione multi-tool, integrazione API esterne e gestione robusta degli errori | [Web Search MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Streaming in tempo reale** | Lo streaming dati in tempo reale è diventato essenziale nel mondo guidato dai dati di oggi, dove aziende e applicazioni necessitano accesso immediato alle informazioni per decisioni tempestive | [Realtime Streaming](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 06 | **Contributi della Comunità** | Come contribuire con codice e documentazione, collaborare tramite GitHub, miglioramenti e feedback guidati dalla comunità | [Community Contributions](./06-CommunityContributions/README.md) |
| 07 | **Lezioni dall’adozione precoce** | Implementazioni reali e cosa ha funzionato, costruzione e distribuzione di soluzioni basate su MCP, tendenze e roadmap futura | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Best Practice per MCP** | Ottimizzazione delle prestazioni, progettazione di sistemi MCP tolleranti ai guasti, strategie di testing e resilienza | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Studi di Caso MCP** | Approfondimenti sulle architetture delle soluzioni MCP, blueprint di deployment e suggerimenti per l'integrazione, diagrammi annotati e walkthrough di progetti | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Snellire i Flussi di Lavoro AI: Costruire un Server MCP con AI Toolkit** | Workshop pratico completo che combina MCP con l'AI Toolkit di Microsoft per VS Code. Impara a creare applicazioni intelligenti che collegano modelli AI a strumenti reali attraverso moduli pratici che coprono i fondamenti, lo sviluppo di server personalizzati e strategie di deployment in produzione. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Progetti di Esempio

### 🧮 Progetti di Esempio MCP Calculator:
<details>
  <summary><strong>Esplora Implementazioni di Codice per Linguaggio</strong></summary>

  - [Esempio Server MCP in C#](./03-GettingStarted/samples/csharp/README.md)
  - [Calcolatrice MCP in Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demo MCP in JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Server MCP in Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Esempio MCP in TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Progetti Avanzati MCP Calculator:
<details>
  <summary><strong>Esplora Esempi Avanzati</strong></summary>

  - [Esempio Avanzato in C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Esempio App Container in Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Esempio Avanzato in JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Implementazione Complessa in Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Esempio Container in TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Prerequisiti per Imparare MCP

Per ottenere il massimo da questo percorso formativo, dovresti avere:

- Conoscenze di base di C#, Java o Python
- Comprensione del modello client-server e delle API
- (Opzionale) Familiarità con i concetti di machine learning

## 📚 Guida allo Studio

È disponibile una [Guida allo Studio](./study_guide.md) completa per aiutarti a orientarti efficacemente in questo repository. La guida include:

- Una mappa visiva del curriculum che mostra tutti gli argomenti trattati
- Una suddivisione dettagliata di ogni sezione del repository
- Indicazioni su come utilizzare i progetti di esempio
- Percorsi di apprendimento consigliati per diversi livelli di competenza
- Risorse aggiuntive per arricchire il tuo percorso di apprendimento

## 🛠️ Come Usare Questo Curriculum in Modo Efficace

Ogni lezione in questa guida include:

1. Spiegazioni chiare dei concetti MCP  
2. Esempi di codice live in più linguaggi  
3. Esercizi per costruire vere applicazioni MCP  
4. Risorse extra per chi vuole approfondire  

## 📜 Informazioni sulla Licenza

Questo contenuto è rilasciato sotto la **MIT License**. Per termini e condizioni, consulta il [LICENSE](../../LICENSE).

## 🤝 Linee Guida per il Contributo

Questo progetto accoglie contributi e suggerimenti. La maggior parte dei contributi richiede di accettare un
Contributor License Agreement (CLA) che dichiara che hai il diritto e effettivamente concedi
i diritti per utilizzare il tuo contributo. Per dettagli, visita <https://cla.opensource.microsoft.com>.

Quando invii una pull request, un bot CLA determinerà automaticamente se devi fornire
un CLA e decorerà la PR di conseguenza (es. controllo stato, commento). Segui semplicemente le istruzioni
fornite dal bot. Dovrai farlo una sola volta per tutti i repository che usano il nostro CLA.

Questo progetto ha adottato il [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
Per maggiori informazioni consulta il [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) o
contatta [opencode@microsoft.com](mailto:opencode@microsoft.com) per domande o commenti aggiuntivi.

## 🎒 Altri Corsi
Il nostro team produce altri corsi! Dai un’occhiata a:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for AI Paired Programming](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Mastering GitHub Copilot for C#/.NET Developers](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Scegli la tua avventura con Copilot](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Avviso di Marchio

Questo progetto potrebbe contenere marchi o loghi di progetti, prodotti o servizi. L'uso autorizzato dei marchi o loghi Microsoft è soggetto e deve seguire le [Linee Guida sui Marchi e Brand di Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
L'uso di marchi o loghi Microsoft in versioni modificate di questo progetto non deve creare confusione né implicare sponsorizzazione da parte di Microsoft.
Qualsiasi uso di marchi o loghi di terze parti è soggetto alle politiche di tali terze parti.

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica AI [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di considerare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali incomprensioni o interpretazioni errate derivanti dall’uso di questa traduzione.