<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T22:08:56+00:00",
  "source_file": "changelog.md",
  "language_code": "it"
}
-->
# Registro delle modifiche: Curriculum MCP per principianti

Questo documento funge da registro di tutte le modifiche significative apportate al curriculum del Model Context Protocol (MCP) per principianti. Le modifiche sono documentate in ordine cronologico inverso (le modifiche più recenti per prime).

## 15 settembre 2025

### Espansione Argomenti Avanzati - Trasporti Personalizzati e Ingegneria del Contesto

#### Trasporti Personalizzati MCP (05-AdvancedTopics/mcp-transport/) - Nuova guida avanzata all'implementazione
- **README.md**: Guida completa all'implementazione di meccanismi di trasporto personalizzati MCP
  - **Trasporto Azure Event Grid**: Implementazione serverless basata su eventi
    - Esempi in C#, TypeScript e Python con integrazione Azure Functions
    - Pattern di architettura basati su eventi per soluzioni MCP scalabili
    - Ricevitori webhook e gestione dei messaggi push
  - **Trasporto Azure Event Hubs**: Implementazione di trasporto streaming ad alta velocità
    - Capacità di streaming in tempo reale per scenari a bassa latenza
    - Strategie di partizionamento e gestione dei checkpoint
    - Ottimizzazione delle prestazioni e batching dei messaggi
  - **Pattern di Integrazione Aziendale**: Esempi architetturali pronti per la produzione
    - Elaborazione MCP distribuita su più Azure Functions
    - Architetture di trasporto ibride che combinano diversi tipi di trasporto
    - Strategie di durabilità, affidabilità e gestione degli errori dei messaggi
  - **Sicurezza e Monitoraggio**: Integrazione con Azure Key Vault e pattern di osservabilità
    - Autenticazione con identità gestite e accesso con privilegi minimi
    - Telemetria con Application Insights e monitoraggio delle prestazioni
    - Pattern di tolleranza ai guasti e interruttori di circuito
  - **Framework di Test**: Strategie di test complete per trasporti personalizzati
    - Test unitari con doppioni e framework di mocking
    - Test di integrazione con Azure Test Containers
    - Considerazioni su test di prestazioni e carico

#### Ingegneria del Contesto (05-AdvancedTopics/mcp-contextengineering/) - Disciplina emergente dell'IA
- **README.md**: Esplorazione completa dell'ingegneria del contesto come campo emergente
  - **Principi Fondamentali**: Condivisione completa del contesto, consapevolezza delle decisioni d'azione e gestione della finestra di contesto
  - **Allineamento al Protocollo MCP**: Come il design MCP affronta le sfide dell'ingegneria del contesto
    - Limitazioni della finestra di contesto e strategie di caricamento progressivo
    - Determinazione della rilevanza e recupero dinamico del contesto
    - Gestione multi-modale del contesto e considerazioni sulla sicurezza
  - **Approcci di Implementazione**: Architetture a singolo thread vs. multi-agente
    - Tecniche di suddivisione e prioritizzazione del contesto
    - Caricamento progressivo e strategie di compressione del contesto
    - Approcci stratificati al contesto e ottimizzazione del recupero
  - **Framework di Misurazione**: Metriche emergenti per la valutazione dell'efficacia del contesto
    - Efficienza degli input, prestazioni, qualità e considerazioni sull'esperienza utente
    - Approcci sperimentali per l'ottimizzazione del contesto
    - Analisi dei fallimenti e metodologie di miglioramento

#### Aggiornamenti alla Navigazione del Curriculum (README.md)
- **Struttura del Modulo Migliorata**: Tabella del curriculum aggiornata per includere nuovi argomenti avanzati
  - Aggiunti Ingegneria del Contesto (5.14) e Trasporti Personalizzati (5.15)
  - Formattazione coerente e collegamenti di navigazione in tutti i moduli
  - Descrizioni aggiornate per riflettere l'ambito dei contenuti attuali

### Miglioramenti alla Struttura delle Directory
- **Standardizzazione dei Nomi**: Rinominato "mcp transport" in "mcp-transport" per coerenza con altre cartelle di argomenti avanzati
- **Organizzazione dei Contenuti**: Tutte le cartelle 05-AdvancedTopics ora seguono un pattern di denominazione coerente (mcp-[argomento])

### Miglioramenti alla Qualità della Documentazione
- **Allineamento alla Specifica MCP**: Tutti i nuovi contenuti fanno riferimento alla specifica MCP corrente 2025-06-18
- **Esempi Multi-Lingua**: Esempi di codice completi in C#, TypeScript e Python
- **Focus Aziendale**: Pattern pronti per la produzione e integrazione cloud Azure in tutto il curriculum
- **Documentazione Visiva**: Diagrammi Mermaid per visualizzazione di architettura e flussi

## 18 agosto 2025

### Aggiornamento Completo della Documentazione - Standard MCP 2025-06-18

#### Migliori Pratiche di Sicurezza MCP (02-Security/) - Modernizzazione Completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Riscrittura completa allineata alla specifica MCP 2025-06-18
  - **Requisiti Obbligatori**: Aggiunti requisiti espliciti MUST/MUST NOT dalla specifica ufficiale con indicatori visivi chiari
  - **12 Pratiche Fondamentali di Sicurezza**: Ristrutturato da una lista di 15 elementi a domini di sicurezza completi
    - Sicurezza dei Token e Autenticazione con integrazione di provider di identità esterni
    - Gestione delle Sessioni e Sicurezza del Trasporto con requisiti crittografici
    - Protezione da Minacce Specifiche dell'IA con integrazione Microsoft Prompt Shields
    - Controllo degli Accessi e Permessi con principio del privilegio minimo
    - Sicurezza dei Contenuti e Monitoraggio con integrazione Azure Content Safety
    - Sicurezza della Catena di Fornitura con verifica completa dei componenti
    - Sicurezza OAuth e Prevenzione degli Attacchi Confused Deputy con implementazione PKCE
    - Risposta agli Incidenti e Recupero con capacità automatizzate
    - Conformità e Governance con allineamento normativo
    - Controlli di Sicurezza Avanzati con architettura zero trust
    - Integrazione Ecosistema di Sicurezza Microsoft con soluzioni complete
    - Evoluzione Continua della Sicurezza con pratiche adattive
  - **Soluzioni di Sicurezza Microsoft**: Guida all'integrazione migliorata per Prompt Shields, Azure Content Safety, Entra ID e GitHub Advanced Security
  - **Risorse di Implementazione**: Collegamenti a risorse complete categorizzati per Documentazione MCP Ufficiale, Soluzioni di Sicurezza Microsoft, Standard di Sicurezza e Guide di Implementazione

#### Controlli di Sicurezza Avanzati (02-Security/) - Implementazione Aziendale
- **MCP-SECURITY-CONTROLS-2025.md**: Revisione completa con framework di sicurezza aziendale
  - **9 Domini di Sicurezza Completi**: Espanso da controlli di base a framework aziendale dettagliato
    - Autenticazione e Autorizzazione Avanzata con integrazione Microsoft Entra ID
    - Sicurezza dei Token e Controlli Anti-Passthrough con validazione completa
    - Controlli di Sicurezza delle Sessioni con prevenzione di dirottamenti
    - Controlli di Sicurezza Specifici dell'IA con prevenzione di iniezioni di prompt e avvelenamento degli strumenti
    - Prevenzione degli Attacchi Confused Deputy con sicurezza proxy OAuth
    - Sicurezza dell'Esecuzione degli Strumenti con sandboxing e isolamento
    - Controlli di Sicurezza della Catena di Fornitura con verifica delle dipendenze
    - Controlli di Monitoraggio e Rilevamento con integrazione SIEM
    - Risposta agli Incidenti e Recupero con capacità automatizzate
  - **Esempi di Implementazione**: Aggiunti blocchi di configurazione YAML dettagliati ed esempi di codice
  - **Integrazione Soluzioni Microsoft**: Copertura completa dei servizi di sicurezza Azure, GitHub Advanced Security e gestione delle identità aziendali

#### Sicurezza Argomenti Avanzati (05-AdvancedTopics/mcp-security/) - Implementazione Pronta per la Produzione
- **README.md**: Riscrittura completa per implementazione di sicurezza aziendale
  - **Allineamento alla Specifica Corrente**: Aggiornato alla specifica MCP 2025-06-18 con requisiti di sicurezza obbligatori
  - **Autenticazione Migliorata**: Integrazione Microsoft Entra ID con esempi completi in .NET e Java Spring Security
  - **Integrazione Sicurezza IA**: Implementazione Microsoft Prompt Shields e Azure Content Safety con esempi dettagliati in Python
  - **Mitigazione Avanzata delle Minacce**: Esempi di implementazione completi per
    - Prevenzione degli Attacchi Confused Deputy con PKCE e validazione del consenso dell'utente
    - Prevenzione del Passaggio dei Token con validazione dell'audience e gestione sicura dei token
    - Prevenzione del Dirottamento delle Sessioni con binding crittografico e analisi comportamentale
  - **Integrazione Sicurezza Aziendale**: Monitoraggio con Azure Application Insights, pipeline di rilevamento delle minacce e sicurezza della catena di fornitura
  - **Checklist di Implementazione**: Controlli di sicurezza obbligatori vs. raccomandati con vantaggi dell'ecosistema di sicurezza Microsoft

### Miglioramenti alla Qualità e agli Standard della Documentazione
- **Riferimenti alla Specifica**: Aggiornati tutti i riferimenti alla specifica MCP corrente 2025-06-18
- **Ecosistema di Sicurezza Microsoft**: Guida all'integrazione migliorata in tutta la documentazione di sicurezza
- **Implementazione Pratica**: Aggiunti esempi di codice dettagliati in .NET, Java e Python con pattern aziendali
- **Organizzazione delle Risorse**: Categorizzazione completa della documentazione ufficiale, standard di sicurezza e guide di implementazione
- **Indicatori Visivi**: Marcatura chiara dei requisiti obbligatori vs. pratiche raccomandate

#### Concetti Fondamentali (01-CoreConcepts/) - Modernizzazione Completa
- **Aggiornamento Versione Protocollo**: Aggiornato per fare riferimento alla specifica MCP corrente 2025-06-18 con versionamento basato su data (formato YYYY-MM-DD)
- **Raffinamento dell'Architettura**: Descrizioni migliorate di Host, Client e Server per riflettere i pattern di architettura MCP attuali
  - Gli Host ora definiti chiaramente come applicazioni IA che coordinano più connessioni client MCP
  - I Client descritti come connettori di protocollo che mantengono relazioni uno-a-uno con i server
  - I Server migliorati con scenari di distribuzione locale vs. remota
- **Ristrutturazione delle Primitiva**: Revisione completa delle primitive server e client
  - Primitive Server: Risorse (fonti di dati), Prompt (modelli), Strumenti (funzioni eseguibili) con spiegazioni ed esempi dettagliati
  - Primitive Client: Campionamento (completamenti LLM), Elicitazione (input utente), Logging (debug/monitoraggio)
  - Aggiornato con pattern di scoperta (`*/list`), recupero (`*/get`) ed esecuzione (`*/call`) correnti
- **Architettura del Protocollo**: Introdotto modello di architettura a due livelli
  - Livello Dati: Fondazione JSON-RPC 2.0 con gestione del ciclo di vita e primitive
  - Livello Trasporto: STDIO (locale) e HTTP Streamable con SSE (remoto)
- **Framework di Sicurezza**: Principi di sicurezza completi inclusi consenso esplicito dell'utente, protezione della privacy dei dati, sicurezza dell'esecuzione degli strumenti e sicurezza del livello di trasporto
- **Pattern di Comunicazione**: Messaggi di protocollo aggiornati per mostrare flussi di inizializzazione, scoperta, esecuzione e notifica
- **Esempi di Codice**: Esempi multi-lingua aggiornati (.NET, Java, Python, JavaScript) per riflettere i pattern SDK MCP attuali

#### Sicurezza (02-Security/) - Revisione Completa della Sicurezza  
- **Allineamento agli Standard**: Allineamento completo ai requisiti di sicurezza della specifica MCP 2025-06-18
- **Evoluzione dell'Autenticazione**: Documentata l'evoluzione da server OAuth personalizzati a delega a provider di identità esterni (Microsoft Entra ID)
- **Analisi delle Minacce Specifiche dell'IA**: Copertura migliorata dei moderni vettori di attacco IA
  - Scenari dettagliati di attacchi di iniezione di prompt con esempi reali
  - Meccanismi di avvelenamento degli strumenti e pattern di attacco "rug pull"
  - Avvelenamento della finestra di contesto e attacchi di confusione del modello
- **Soluzioni di Sicurezza IA Microsoft**: Copertura completa dell'ecosistema di sicurezza Microsoft
  - Prompt Shields IA con tecniche avanzate di rilevamento, spotlighting e delimitazione
  - Pattern di integrazione Azure Content Safety
  - GitHub Advanced Security per protezione della catena di fornitura
- **Mitigazione Avanzata delle Minacce**: Controlli di sicurezza dettagliati per
  - Dirottamento delle sessioni con scenari di attacco specifici MCP e requisiti crittografici per ID sessione
  - Problemi Confused Deputy negli scenari proxy MCP con requisiti di consenso espliciti
  - Vulnerabilità del passaggio dei token con controlli di validazione obbligatori
- **Sicurezza della Catena di Fornitura**: Copertura espansa della catena di fornitura IA inclusi modelli di base, servizi di embedding, provider di contesto e API di terze parti
- **Sicurezza Fondamentale**: Integrazione migliorata con pattern di sicurezza aziendali inclusa architettura zero trust e ecosistema di sicurezza Microsoft
- **Organizzazione delle Risorse**: Collegamenti a risorse complete categorizzati per tipo (Documenti Ufficiali, Standard, Ricerca, Soluzioni Microsoft, Guide di Implementazione)

### Miglioramenti alla Qualità della Documentazione
- **Obiettivi di Apprendimento Strutturati**: Obiettivi di apprendimento migliorati con risultati specifici e attuabili 
- **Riferimenti Incrociati**: Aggiunti collegamenti tra argomenti correlati di sicurezza e concetti fondamentali
- **Informazioni Aggiornate**: Aggiornati tutti i riferimenti di data e collegamenti alla specifica agli standard attuali
- **Guida all'Implementazione**: Aggiunte linee guida di implementazione specifiche e attuabili in tutte le sezioni

---

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per garantire l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un traduttore umano. Non siamo responsabili per eventuali incomprensioni o interpretazioni errate derivanti dall'uso di questa traduzione.