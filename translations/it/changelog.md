<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T17:20:53+00:00",
  "source_file": "changelog.md",
  "language_code": "it"
}
-->
# Registro delle modifiche: Curriculum MCP per principianti

Questo documento funge da registro di tutte le modifiche significative apportate al curriculum del Model Context Protocol (MCP) per principianti. Le modifiche sono documentate in ordine cronologico inverso (le modifiche più recenti per prime).

## 18 agosto 2025

### Aggiornamento completo della documentazione - Standard MCP 2025-06-18

#### Migliori pratiche di sicurezza MCP (02-Security/) - Modernizzazione completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Riscrittura completa in linea con la specifica MCP 2025-06-18
  - **Requisiti obbligatori**: Aggiunti requisiti espliciti MUST/MUST NOT dalla specifica ufficiale con indicatori visivi chiari
  - **12 pratiche di sicurezza fondamentali**: Ristrutturazione da un elenco di 15 elementi a domini di sicurezza completi
    - Sicurezza dei token e autenticazione con integrazione di provider di identità esterni
    - Gestione delle sessioni e sicurezza del trasporto con requisiti crittografici
    - Protezione da minacce specifiche per l'IA con integrazione di Microsoft Prompt Shields
    - Controllo degli accessi e permessi con il principio del minimo privilegio
    - Sicurezza dei contenuti e monitoraggio con integrazione di Azure Content Safety
    - Sicurezza della catena di approvvigionamento con verifica completa dei componenti
    - Sicurezza OAuth e prevenzione di attacchi Confused Deputy con implementazione PKCE
    - Risposta agli incidenti e recupero con capacità automatizzate
    - Conformità e governance con allineamento normativo
    - Controlli di sicurezza avanzati con architettura zero trust
    - Integrazione dell'ecosistema di sicurezza Microsoft con soluzioni complete
    - Evoluzione continua della sicurezza con pratiche adattive
  - **Soluzioni di sicurezza Microsoft**: Guida migliorata per l'integrazione di Prompt Shields, Azure Content Safety, Entra ID e GitHub Advanced Security
  - **Risorse per l'implementazione**: Collegamenti a risorse complete categorizzati per Documentazione ufficiale MCP, Soluzioni di sicurezza Microsoft, Standard di sicurezza e Guide all'implementazione

#### Controlli di sicurezza avanzati (02-Security/) - Implementazione aziendale
- **MCP-SECURITY-CONTROLS-2025.md**: Revisione completa con framework di sicurezza di livello aziendale
  - **9 domini di sicurezza completi**: Espansione da controlli di base a framework aziendale dettagliato
    - Autenticazione e autorizzazione avanzate con integrazione di Microsoft Entra ID
    - Sicurezza dei token e controlli anti-passthrough con validazione completa
    - Controlli di sicurezza delle sessioni con prevenzione di dirottamenti
    - Controlli di sicurezza specifici per l'IA con prevenzione di iniezioni di prompt e avvelenamento degli strumenti
    - Prevenzione di attacchi Confused Deputy con sicurezza proxy OAuth
    - Sicurezza dell'esecuzione degli strumenti con sandboxing e isolamento
    - Controlli di sicurezza della catena di approvvigionamento con verifica delle dipendenze
    - Controlli di monitoraggio e rilevamento con integrazione SIEM
    - Risposta agli incidenti e recupero con capacità automatizzate
  - **Esempi di implementazione**: Aggiunti blocchi di configurazione YAML dettagliati ed esempi di codice
  - **Integrazione delle soluzioni Microsoft**: Copertura completa dei servizi di sicurezza Azure, GitHub Advanced Security e gestione delle identità aziendali

#### Argomenti avanzati di sicurezza (05-AdvancedTopics/mcp-security/) - Implementazione pronta per la produzione
- **README.md**: Riscrittura completa per l'implementazione della sicurezza aziendale
  - **Allineamento alla specifica corrente**: Aggiornato alla specifica MCP 2025-06-18 con requisiti di sicurezza obbligatori
  - **Autenticazione avanzata**: Integrazione di Microsoft Entra ID con esempi completi in .NET e Java Spring Security
  - **Integrazione della sicurezza IA**: Implementazione di Microsoft Prompt Shields e Azure Content Safety con esempi dettagliati in Python
  - **Mitigazione avanzata delle minacce**: Esempi di implementazione completi per
    - Prevenzione di attacchi Confused Deputy con PKCE e validazione del consenso dell'utente
    - Prevenzione del passaggio di token con validazione dell'audience e gestione sicura dei token
    - Prevenzione di dirottamenti di sessione con binding crittografico e analisi comportamentale
  - **Integrazione della sicurezza aziendale**: Monitoraggio con Azure Application Insights, pipeline di rilevamento delle minacce e sicurezza della catena di approvvigionamento
  - **Checklist di implementazione**: Controlli di sicurezza obbligatori vs. raccomandati con vantaggi dell'ecosistema di sicurezza Microsoft

### Miglioramenti alla qualità e agli standard della documentazione
- **Riferimenti alla specifica**: Aggiornati tutti i riferimenti alla specifica MCP corrente 2025-06-18
- **Ecosistema di sicurezza Microsoft**: Guida migliorata per l'integrazione in tutta la documentazione sulla sicurezza
- **Implementazione pratica**: Aggiunti esempi di codice dettagliati in .NET, Java e Python con modelli aziendali
- **Organizzazione delle risorse**: Categorizzazione completa della documentazione ufficiale, standard di sicurezza e guide all'implementazione
- **Indicatori visivi**: Marcatura chiara dei requisiti obbligatori rispetto alle pratiche raccomandate

#### Concetti fondamentali (01-CoreConcepts/) - Modernizzazione completa
- **Aggiornamento della versione del protocollo**: Aggiornato per fare riferimento alla specifica MCP corrente 2025-06-18 con versionamento basato sulla data (formato YYYY-MM-DD)
- **Raffinamento dell'architettura**: Descrizioni migliorate di Host, Client e Server per riflettere i modelli di architettura MCP attuali
  - Host ora definiti chiaramente come applicazioni IA che coordinano più connessioni client MCP
  - Client descritti come connettori di protocollo che mantengono relazioni uno-a-uno con i server
  - Server migliorati con scenari di distribuzione locale vs. remota
- **Ristrutturazione delle primitive**: Revisione completa delle primitive di server e client
  - Primitive del server: Risorse (fonti di dati), Prompt (modelli), Strumenti (funzioni eseguibili) con spiegazioni ed esempi dettagliati
  - Primitive del client: Campionamento (completamenti LLM), Elicitazione (input utente), Logging (debug/monitoraggio)
  - Aggiornato con i modelli di metodo correnti di scoperta (`*/list`), recupero (`*/get`) ed esecuzione (`*/call`)
- **Architettura del protocollo**: Introdotto modello di architettura a due livelli
  - Livello dati: Fondazione JSON-RPC 2.0 con gestione del ciclo di vita e primitive
  - Livello trasporto: STDIO (locale) e HTTP streamable con SSE (remoto)
- **Framework di sicurezza**: Principi di sicurezza completi inclusi consenso esplicito dell'utente, protezione della privacy dei dati, sicurezza dell'esecuzione degli strumenti e sicurezza del livello di trasporto
- **Modelli di comunicazione**: Messaggi del protocollo aggiornati per mostrare flussi di inizializzazione, scoperta, esecuzione e notifica
- **Esempi di codice**: Esempi multi-lingua aggiornati (.NET, Java, Python, JavaScript) per riflettere i modelli SDK MCP correnti

#### Sicurezza (02-Security/) - Revisione completa della sicurezza  
- **Allineamento agli standard**: Allineamento completo ai requisiti di sicurezza della specifica MCP 2025-06-18
- **Evoluzione dell'autenticazione**: Documentata l'evoluzione da server OAuth personalizzati a delega di provider di identità esterni (Microsoft Entra ID)
- **Analisi delle minacce specifiche per l'IA**: Copertura migliorata dei vettori di attacco IA moderni
  - Scenari dettagliati di attacchi di iniezione di prompt con esempi reali
  - Meccanismi di avvelenamento degli strumenti e modelli di attacco "rug pull"
  - Avvelenamento della finestra di contesto e attacchi di confusione del modello
- **Soluzioni di sicurezza IA Microsoft**: Copertura completa dell'ecosistema di sicurezza Microsoft
  - Prompt Shields IA con tecniche avanzate di rilevamento, spotlighting e delimitazione
  - Modelli di integrazione di Azure Content Safety
  - GitHub Advanced Security per la protezione della catena di approvvigionamento
- **Mitigazione avanzata delle minacce**: Controlli di sicurezza dettagliati per
  - Dirottamento delle sessioni con scenari di attacco specifici MCP e requisiti crittografici per ID di sessione
  - Problemi di Confused Deputy negli scenari proxy MCP con requisiti di consenso espliciti
  - Vulnerabilità del passaggio di token con controlli di validazione obbligatori
- **Sicurezza della catena di approvvigionamento**: Copertura ampliata della catena di approvvigionamento IA inclusi modelli di base, servizi di embedding, fornitori di contesto e API di terze parti
- **Sicurezza di base**: Integrazione migliorata con modelli di sicurezza aziendali inclusa l'architettura zero trust e l'ecosistema di sicurezza Microsoft
- **Organizzazione delle risorse**: Collegamenti a risorse complete categorizzati per tipo (Documenti ufficiali, Standard, Ricerca, Soluzioni Microsoft, Guide all'implementazione)

### Miglioramenti alla qualità della documentazione
- **Obiettivi di apprendimento strutturati**: Obiettivi di apprendimento migliorati con risultati specifici e attuabili
- **Riferimenti incrociati**: Aggiunti collegamenti tra argomenti correlati di sicurezza e concetti fondamentali
- **Informazioni aggiornate**: Aggiornati tutti i riferimenti alle date e ai collegamenti alle specifiche correnti
- **Guida all'implementazione**: Aggiunte linee guida specifiche e attuabili per l'implementazione in entrambe le sezioni

## 16 luglio 2025

### Miglioramenti a README e navigazione
- Completamente ridisegnata la navigazione del curriculum in README.md
- Sostituiti i tag `<details>` con un formato basato su tabelle più accessibile
- Creato opzioni di layout alternative nella nuova cartella "alternative_layouts"
- Aggiunti esempi di navigazione in stile schede, a schede e a fisarmonica
- Aggiornata la sezione sulla struttura del repository per includere tutti i file più recenti
- Migliorata la sezione "Come utilizzare questo curriculum" con raccomandazioni chiare
- Aggiornati i collegamenti alla specifica MCP per puntare agli URL corretti
- Aggiunta la sezione di ingegneria del contesto (5.14) alla struttura del curriculum

### Aggiornamenti alla guida di studio
- Guida di studio completamente rivista per allinearsi alla struttura del repository corrente
- Aggiunte nuove sezioni per Client e Strumenti MCP e Server MCP popolari
- Aggiornata la mappa visiva del curriculum per riflettere accuratamente tutti gli argomenti
- Migliorate le descrizioni degli argomenti avanzati per coprire tutte le aree specializzate
- Aggiornata la sezione Studi di caso per riflettere esempi reali
- Aggiunto questo registro delle modifiche completo

### Contributi della comunità (06-CommunityContributions/)
- Aggiunte informazioni dettagliate sui server MCP per la generazione di immagini
- Aggiunta una sezione completa sull'utilizzo di Claude in VSCode
- Aggiunte istruzioni per la configurazione e l'utilizzo del client terminale Cline
- Aggiornata la sezione client MCP per includere tutte le opzioni client popolari
- Migliorati gli esempi di contributo con campioni di codice più accurati

### Argomenti avanzati (05-AdvancedTopics/)
- Organizzati tutti i folder di argomenti specializzati con una nomenclatura coerente
- Aggiunti materiali ed esempi di ingegneria del contesto
- Aggiunta documentazione sull'integrazione degli agenti Foundry
- Migliorata la documentazione sull'integrazione della sicurezza Entra ID

## 11 giugno 2025

### Creazione iniziale
- Rilasciata la prima versione del curriculum MCP per principianti
- Creata la struttura di base per tutte le 10 sezioni principali
- Implementata la mappa visiva del curriculum per la navigazione
- Aggiunti progetti di esempio iniziali in più linguaggi di programmazione

### Introduzione (03-GettingStarted/)
- Creati i primi esempi di implementazione del server
- Aggiunta guida allo sviluppo del client
- Inclusa documentazione sull'integrazione del client LLM
- Aggiunta documentazione sull'integrazione con VS Code
- Implementati esempi di server con Server-Sent Events (SSE)

### Concetti fondamentali (01-CoreConcepts/)
- Aggiunta spiegazione dettagliata dell'architettura client-server
- Creata documentazione sui componenti chiave del protocollo
- Documentati i modelli di messaggistica in MCP

## 23 maggio 2025

### Struttura del repository
- Inizializzato il repository con struttura di folder di base
- Creati file README per ogni sezione principale
- Configurata l'infrastruttura di traduzione
- Aggiunti asset grafici e diagrammi

### Documentazione
- Creato README.md iniziale con panoramica del curriculum
- Aggiunti CODE_OF_CONDUCT.md e SECURITY.md
- Configurato SUPPORT.md con indicazioni per ottenere aiuto
- Creata struttura preliminare della guida di studio

## 15 aprile 2025

### Pianificazione e framework
- Pianificazione iniziale per il curriculum MCP per principianti
- Definiti obiettivi di apprendimento e pubblico target
- Delineata la struttura in 10 sezioni del curriculum
- Sviluppato framework concettuale per esempi e studi di caso
- Creati prototipi iniziali di esempi per concetti chiave

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per garantire l'accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si consiglia una traduzione professionale eseguita da un traduttore umano. Non siamo responsabili per eventuali fraintendimenti o interpretazioni errate derivanti dall'uso di questa traduzione.