<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "704c94da1dde019de2d8eb1d671f418f",
  "translation_date": "2025-09-26T18:18:11+00:00",
  "source_file": "changelog.md",
  "language_code": "it"
}
-->
# Changelog: Curriculum MCP per Principianti

Questo documento funge da registro di tutte le modifiche significative apportate al curriculum del Model Context Protocol (MCP) per principianti. Le modifiche sono documentate in ordine cronologico inverso (le modifiche più recenti per prime).

## 26 settembre 2025

### Miglioramento dei Case Study - Integrazione del Registro MCP di GitHub

#### Case Study (09-CaseStudy/) - Focus sullo sviluppo dell'ecosistema
- **README.md**: Espansione significativa con un case study completo sul Registro MCP di GitHub
  - **Case Study sul Registro MCP di GitHub**: Nuovo case study completo sull'avvio del Registro MCP di GitHub a settembre 2025
    - **Analisi del problema**: Esame dettagliato delle sfide legate alla scoperta e al deployment frammentato dei server MCP
    - **Architettura della soluzione**: Approccio centralizzato di GitHub con installazione in un clic su VS Code
    - **Impatto aziendale**: Miglioramenti misurabili nell'onboarding degli sviluppatori e nella produttività
    - **Valore strategico**: Focus sul deployment modulare degli agenti e sull'interoperabilità tra strumenti
    - **Sviluppo dell'ecosistema**: Posizionamento come piattaforma fondamentale per l'integrazione agentica
  - **Struttura migliorata dei Case Study**: Aggiornati tutti e sette i case study con formattazione coerente e descrizioni complete
    - Azure AI Travel Agents: Enfasi sull'orchestrazione multi-agente
    - Integrazione Azure DevOps: Focus sull'automazione dei flussi di lavoro
    - Recupero documentazione in tempo reale: Implementazione client console Python
    - Generatore di piani di studio interattivo: Web app conversazionale Chainlit
    - Documentazione in-editor: Integrazione VS Code e GitHub Copilot
    - Gestione API Azure: Modelli di integrazione API aziendali
    - Registro MCP di GitHub: Sviluppo dell'ecosistema e piattaforma comunitaria
  - **Conclusione completa**: Riscritta la sezione conclusiva evidenziando sette case study che coprono diverse dimensioni di implementazione MCP
    - Integrazione aziendale, orchestrazione multi-agente, produttività degli sviluppatori
    - Sviluppo dell'ecosistema, applicazioni educative
    - Approfondimenti migliorati su modelli architetturali, strategie di implementazione e best practice
    - Enfasi su MCP come protocollo maturo e pronto per la produzione

#### Aggiornamenti della guida di studio (study_guide.md)
- **Mappa visiva del curriculum**: Aggiornata la mappa mentale per includere il Registro MCP di GitHub nella sezione Case Study
- **Descrizione dei Case Study**: Migliorata da descrizioni generiche a una suddivisione dettagliata dei sette case study completi
- **Struttura del repository**: Aggiornata la sezione 10 per riflettere la copertura completa dei case study con dettagli specifici di implementazione
- **Integrazione del changelog**: Aggiunta voce del 26 settembre 2025 che documenta l'aggiunta del Registro MCP di GitHub e i miglioramenti ai case study
- **Aggiornamenti delle date**: Aggiornato il timestamp del footer per riflettere l'ultima revisione (26 settembre 2025)

### Miglioramenti alla qualità della documentazione
- **Miglioramento della coerenza**: Standardizzata la formattazione e la struttura dei case study in tutti e sette gli esempi
- **Copertura completa**: I case study ora coprono scenari aziendali, di produttività degli sviluppatori e di sviluppo dell'ecosistema
- **Posizionamento strategico**: Maggiore enfasi su MCP come piattaforma fondamentale per il deployment di sistemi agentici
- **Integrazione delle risorse**: Aggiornate le risorse aggiuntive per includere il link al Registro MCP di GitHub

## 15 settembre 2025

### Espansione degli argomenti avanzati - Trasporti personalizzati e ingegneria del contesto

#### Trasporti personalizzati MCP (05-AdvancedTopics/mcp-transport/) - Nuova guida avanzata all'implementazione
- **README.md**: Guida completa all'implementazione di meccanismi di trasporto personalizzati MCP
  - **Trasporto Azure Event Grid**: Implementazione serverless basata su eventi
    - Esempi in C#, TypeScript e Python con integrazione Azure Functions
    - Modelli architetturali basati su eventi per soluzioni MCP scalabili
    - Ricevitori webhook e gestione dei messaggi push
  - **Trasporto Azure Event Hubs**: Implementazione di trasporto streaming ad alta velocità
    - Capacità di streaming in tempo reale per scenari a bassa latenza
    - Strategie di partizionamento e gestione dei checkpoint
    - Ottimizzazione delle prestazioni e batching dei messaggi
  - **Modelli di integrazione aziendale**: Esempi architetturali pronti per la produzione
    - Elaborazione MCP distribuita su più Azure Functions
    - Architetture di trasporto ibride che combinano più tipi di trasporto
    - Strategie di durabilità, affidabilità e gestione degli errori dei messaggi
  - **Sicurezza e monitoraggio**: Integrazione con Azure Key Vault e modelli di osservabilità
    - Autenticazione con identità gestite e accesso con privilegi minimi
    - Telemetria Application Insights e monitoraggio delle prestazioni
    - Modelli di tolleranza ai guasti e circuit breaker
  - **Framework di test**: Strategie di test complete per trasporti personalizzati
    - Test unitari con doppioni di test e framework di mocking
    - Test di integrazione con Azure Test Containers
    - Considerazioni su test di prestazioni e carico

#### Ingegneria del contesto (05-AdvancedTopics/mcp-contextengineering/) - Disciplina emergente dell'IA
- **README.md**: Esplorazione completa dell'ingegneria del contesto come campo emergente
  - **Principi fondamentali**: Condivisione completa del contesto, consapevolezza delle decisioni di azione e gestione della finestra di contesto
  - **Allineamento al protocollo MCP**: Come il design MCP affronta le sfide dell'ingegneria del contesto
    - Limitazioni della finestra di contesto e strategie di caricamento progressivo
    - Determinazione della rilevanza e recupero dinamico del contesto
    - Gestione multi-modale del contesto e considerazioni sulla sicurezza
  - **Approcci di implementazione**: Architetture single-threaded vs. multi-agente
    - Tecniche di suddivisione e prioritizzazione del contesto
    - Caricamento progressivo del contesto e strategie di compressione
    - Approcci stratificati al contesto e ottimizzazione del recupero
  - **Framework di misurazione**: Metriche emergenti per la valutazione dell'efficacia del contesto
    - Efficienza degli input, prestazioni, qualità e considerazioni sull'esperienza utente
    - Approcci sperimentali per l'ottimizzazione del contesto
    - Analisi dei fallimenti e metodologie di miglioramento

#### Aggiornamenti alla navigazione del curriculum (README.md)
- **Struttura migliorata dei moduli**: Aggiornata la tabella del curriculum per includere nuovi argomenti avanzati
  - Aggiunti Ingegneria del contesto (5.14) e Trasporti personalizzati (5.15)
  - Formattazione coerente e link di navigazione in tutti i moduli
  - Descrizioni aggiornate per riflettere l'attuale ambito dei contenuti

### Miglioramenti alla struttura delle directory
- **Standardizzazione dei nomi**: Rinominato "mcp transport" in "mcp-transport" per coerenza con altre cartelle di argomenti avanzati
- **Organizzazione dei contenuti**: Tutte le cartelle 05-AdvancedTopics ora seguono un modello di denominazione coerente (mcp-[argomento])

### Miglioramenti alla qualità della documentazione
- **Allineamento alla specifica MCP**: Tutti i nuovi contenuti fanno riferimento alla specifica MCP corrente 2025-06-18
- **Esempi multi-lingua**: Esempi di codice completi in C#, TypeScript e Python
- **Focus aziendale**: Modelli pronti per la produzione e integrazione cloud Azure in tutto il documento
- **Documentazione visiva**: Diagrammi Mermaid per visualizzazione di architettura e flussi

## 18 agosto 2025

### Aggiornamento completo della documentazione - Standard MCP 2025-06-18

#### Best practice di sicurezza MCP (02-Security/) - Modernizzazione completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Riscrittura completa allineata alla specifica MCP 2025-06-18
  - **Requisiti obbligatori**: Aggiunti requisiti espliciti MUST/MUST NOT dalla specifica ufficiale con indicatori visivi chiari
  - **12 pratiche di sicurezza fondamentali**: Ristrutturato da un elenco di 15 elementi a domini di sicurezza completi
    - Sicurezza dei token e autenticazione con integrazione di provider di identità esterni
    - Gestione delle sessioni e sicurezza del trasporto con requisiti crittografici
    - Protezione dalle minacce specifiche dell'IA con integrazione Microsoft Prompt Shields
    - Controllo degli accessi e permessi con il principio del privilegio minimo
    - Sicurezza dei contenuti e monitoraggio con integrazione Azure Content Safety
    - Sicurezza della supply chain con verifica completa dei componenti
    - Sicurezza OAuth e prevenzione degli attacchi Confused Deputy con implementazione PKCE
    - Risposta agli incidenti e recupero con capacità automatizzate
    - Conformità e governance con allineamento normativo
    - Controlli di sicurezza avanzati con architettura zero trust
    - Integrazione dell'ecosistema di sicurezza Microsoft con soluzioni complete
    - Evoluzione continua della sicurezza con pratiche adattive
  - **Soluzioni di sicurezza Microsoft**: Guida migliorata all'integrazione per Prompt Shields, Azure Content Safety, Entra ID e GitHub Advanced Security
  - **Risorse di implementazione**: Link alle risorse categorizzati per Documentazione ufficiale MCP, Soluzioni di sicurezza Microsoft, Standard di sicurezza e Guide all'implementazione

#### Controlli di sicurezza avanzati (02-Security/) - Implementazione aziendale
- **MCP-SECURITY-CONTROLS-2025.md**: Revisione completa con framework di sicurezza aziendale
  - **9 domini di sicurezza completi**: Espanso da controlli di base a framework aziendale dettagliato
    - Autenticazione e autorizzazione avanzata con integrazione Microsoft Entra ID
    - Sicurezza dei token e controlli anti-passthrough con validazione completa
    - Controlli di sicurezza delle sessioni con prevenzione di hijacking
    - Controlli di sicurezza specifici per l'IA con prevenzione di injection e avvelenamento degli strumenti
    - Prevenzione degli attacchi Confused Deputy con sicurezza proxy OAuth
    - Sicurezza dell'esecuzione degli strumenti con sandboxing e isolamento
    - Controlli di sicurezza della supply chain con verifica delle dipendenze
    - Controlli di monitoraggio e rilevamento con integrazione SIEM
    - Risposta agli incidenti e recupero con capacità automatizzate
  - **Esempi di implementazione**: Aggiunti blocchi di configurazione YAML dettagliati ed esempi di codice
  - **Integrazione delle soluzioni Microsoft**: Copertura completa dei servizi di sicurezza Azure, GitHub Advanced Security e gestione delle identità aziendali

#### Sicurezza avanzata degli argomenti (05-AdvancedTopics/mcp-security/) - Implementazione pronta per la produzione
- **README.md**: Riscrittura completa per l'implementazione della sicurezza aziendale
  - **Allineamento alla specifica corrente**: Aggiornato alla specifica MCP 2025-06-18 con requisiti di sicurezza obbligatori
  - **Autenticazione migliorata**: Integrazione Microsoft Entra ID con esempi completi in .NET e Java Spring Security
  - **Integrazione della sicurezza IA**: Implementazione Microsoft Prompt Shields e Azure Content Safety con esempi dettagliati in Python
  - **Mitigazione avanzata delle minacce**: Esempi di implementazione completi per
    - Prevenzione degli attacchi Confused Deputy con PKCE e validazione del consenso dell'utente
    - Prevenzione del passaggio dei token con validazione dell'audience e gestione sicura dei token
    - Prevenzione del hijacking delle sessioni con binding crittografico e analisi comportamentale
  - **Integrazione della sicurezza aziendale**: Monitoraggio Application Insights di Azure, pipeline di rilevamento delle minacce e sicurezza della supply chain
  - **Checklist di implementazione**: Controlli di sicurezza obbligatori vs. raccomandati con vantaggi dell'ecosistema di sicurezza Microsoft

### Miglioramenti alla qualità e agli standard della documentazione
- **Riferimenti alla specifica**: Aggiornati tutti i riferimenti alla specifica MCP corrente 2025-06-18
- **Ecosistema di sicurezza Microsoft**: Guida migliorata all'integrazione in tutta la documentazione sulla sicurezza
- **Implementazione pratica**: Aggiunti esempi di codice dettagliati in .NET, Java e Python con modelli aziendali
- **Organizzazione delle risorse**: Categorizzazione completa della documentazione ufficiale, standard di sicurezza e guide all'implementazione
- **Indicatori visivi**: Marcatura chiara dei requisiti obbligatori vs. pratiche raccomandate

#### Concetti fondamentali (01-CoreConcepts/) - Modernizzazione completa
- **Aggiornamento della versione del protocollo**: Aggiornato per fare riferimento alla specifica MCP corrente 2025-06-18 con versionamento basato sulla data (formato YYYY-MM-DD)
- **Raffinamento dell'architettura**: Descrizioni migliorate di Host, Client e Server per riflettere i modelli architetturali MCP correnti
  - Gli Host ora definiti chiaramente come applicazioni IA che coordinano più connessioni client MCP
  - I Client descritti come connettori di protocollo che mantengono relazioni uno-a-uno con i server
  - I Server migliorati con scenari di deployment locale vs. remoto
- **Ristrutturazione delle primitive**: Revisione completa delle primitive server e client
  - Primitive server: Risorse (fonti di dati), Prompt (modelli), Strumenti (funzioni eseguibili) con spiegazioni ed esempi dettagliati
  - Primitive client: Campionamento (completamenti LLM), Elicitazione (input utente), Logging (debug/monitoraggio)
  - Aggiornato con i modelli correnti di scoperta (`*/list`), recupero (`*/get`) ed esecuzione (`*/call`)
- **Architettura del protocollo**: Introdotto modello architetturale a due livelli
  - Livello dati: Fondazione JSON-RPC 2.0 con gestione del ciclo di vita e primitive
  - Livello trasporto: STDIO (locale) e HTTP streamable con SSE (remoto)
- **Framework di sicurezza**: Principi di sicurezza completi inclusi consenso esplicito dell'utente, protezione della privacy dei dati, sicurezza dell'esecuzione degli strumenti e sicurezza del livello di trasporto
- **Modelli di comunicazione**: Messaggi del protocollo aggiornati per mostrare flussi di inizializzazione, scoperta, esecuzione e notifica
- **Esempi di codice**: Esempi multi-lingua aggiornati (.NET, Java, Python, JavaScript) per riflettere i modelli SDK MCP correnti

#### Sicurezza (02-Security/) - Revisione completa della sicurezza  
- **Allineamento agli standard**: Allineamento completo ai requisiti di sicurezza della specifica MCP 2025-06-18
- **Evoluzione dell'autenticazione**: Documentata l'evoluzione dai server OAuth personalizzati alla delega dei provider di identità esterni (Microsoft Entra ID)
- **Analisi delle minacce specifiche per l'IA**: Copertura migliorata dei moderni vettori di attacco IA
  - Scenari dettagliati di attacchi di injection nei prompt con esempi reali
  - Meccanismi di avvelenamento degli strumenti e modelli di attacco "rug pull"
  - Avvelenamento della finestra di contesto e attacchi di confusione del modello
- **Soluzioni di sicurezza IA Microsoft**: Copertura completa dell'ecosistema di sicurezza Microsoft
  - Prompt Shields IA con tecniche avanzate di rilevamento, spotlighting e delimitazione
  - Modelli di integrazione Azure Content Safety
  - GitHub Advanced Security per la protezione della supply chain
- **Mitigazione avanzata delle minacce**: Controlli di sicurezza dettagliati per
  - Hijacking delle sessioni con scenari di attacco specifici MCP e requisiti crittografici per ID di sessione
  - Problemi di Confused Deputy negli scenari proxy MCP con requisiti di consenso espliciti
  - Vulnerabilità del passaggio dei token con controlli di validazione obbligatori
- **Sicurezza della supply chain**: Copertura ampliata della supply chain IA inclusi modelli di base, servizi di embedding, fornitori di contesto e API di terze parti
- **Sicurezza di base**: Integrazione migliorata con modelli di sicurezza aziendali inclusa l'architettura zero trust e l'ecosistema di sicurezza Microsoft
- **Organizzazione delle risorse**: Link alle risorse categorizzati per tipo (Documenti ufficiali, Standard, Ricerca, Soluzioni Microsoft, Guide all'implementazione)

### Miglioramenti alla qualità della documentazione
- **Obiettivi di apprendimento strutturati**: Obiettivi di apprendimento migliorati con risultati specific
- Sostituiti i tag `<details>` con un formato basato su tabelle più accessibile
- Creata una cartella "alternative_layouts" con opzioni di layout alternative
- Aggiunti esempi di navigazione basati su schede, stile a schede e stile fisarmonica
- Aggiornata la sezione sulla struttura del repository per includere tutti i file più recenti
- Migliorata la sezione "Come utilizzare questo curriculum" con raccomandazioni chiare
- Aggiornati i link alle specifiche MCP per puntare agli URL corretti
- Aggiunta la sezione di Context Engineering (5.14) alla struttura del curriculum

### Aggiornamenti alla Guida di Studio
- Guida di studio completamente rivista per allinearsi alla struttura attuale del repository
- Aggiunte nuove sezioni per Client e Strumenti MCP e Server MCP popolari
- Aggiornata la Mappa Visiva del Curriculum per riflettere accuratamente tutti gli argomenti
- Migliorate le descrizioni degli Argomenti Avanzati per coprire tutte le aree specializzate
- Aggiornata la sezione Studi di Caso per riflettere esempi reali
- Aggiunto questo changelog completo

### Contributi della Comunità (06-CommunityContributions/)
- Aggiunte informazioni dettagliate sui server MCP per la generazione di immagini
- Inserita una sezione completa sull'utilizzo di Claude in VSCode
- Aggiunte istruzioni per la configurazione e l'uso del client terminale Cline
- Aggiornata la sezione sui client MCP per includere tutte le opzioni popolari
- Migliorati gli esempi di contributo con campioni di codice più accurati

### Argomenti Avanzati (05-AdvancedTopics/)
- Organizzati tutti i folder degli argomenti specializzati con una nomenclatura coerente
- Aggiunti materiali ed esempi di Context Engineering
- Inserita documentazione sull'integrazione degli agenti Foundry
- Migliorata la documentazione sull'integrazione della sicurezza Entra ID

## 11 Giugno 2025

### Creazione Iniziale
- Rilasciata la prima versione del curriculum MCP per Principianti
- Creata la struttura di base per tutte le 10 sezioni principali
- Implementata la Mappa Visiva del Curriculum per la navigazione
- Aggiunti progetti di esempio iniziali in diversi linguaggi di programmazione

### Per Iniziare (03-GettingStarted/)
- Creati i primi esempi di implementazione del server
- Aggiunte linee guida per lo sviluppo del client
- Inclusa documentazione sull'integrazione del client LLM
- Aggiunta documentazione sull'integrazione con VS Code
- Implementati esempi di server con Server-Sent Events (SSE)

### Concetti Fondamentali (01-CoreConcepts/)
- Aggiunta una spiegazione dettagliata dell'architettura client-server
- Creata documentazione sui componenti chiave del protocollo
- Documentati i pattern di messaggistica in MCP

## 23 Maggio 2025

### Struttura del Repository
- Inizializzato il repository con una struttura di folder di base
- Creati file README per ogni sezione principale
- Configurata l'infrastruttura per le traduzioni
- Aggiunti asset grafici e diagrammi

### Documentazione
- Creato README.md iniziale con una panoramica del curriculum
- Aggiunti CODE_OF_CONDUCT.md e SECURITY.md
- Configurato SUPPORT.md con indicazioni per ottenere supporto
- Creata una struttura preliminare per la guida di studio

## 15 Aprile 2025

### Pianificazione e Framework
- Pianificazione iniziale del curriculum MCP per Principianti
- Definiti obiettivi di apprendimento e pubblico target
- Delineata la struttura in 10 sezioni del curriculum
- Sviluppato un framework concettuale per esempi e studi di caso
- Creati prototipi iniziali di esempi per concetti chiave

---

