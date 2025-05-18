<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-17T07:26:47+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "it"
}
-->
# Migliori pratiche di sicurezza

Adottare il Model Context Protocol (MCP) porta nuove capacità potenti alle applicazioni guidate dall'AI, ma introduce anche sfide di sicurezza uniche che vanno oltre i rischi tradizionali del software. Oltre a preoccupazioni consolidate come la programmazione sicura, il principio del minimo privilegio e la sicurezza della supply chain, MCP e i carichi di lavoro dell'AI affrontano nuove minacce come l'iniezione di prompt, l'avvelenamento degli strumenti e la modifica dinamica degli strumenti. Questi rischi possono portare a esfiltrazione di dati, violazioni della privacy e comportamenti indesiderati del sistema se non gestiti correttamente.

Questa lezione esplora i rischi di sicurezza più rilevanti associati a MCP, tra cui autenticazione, autorizzazione, permessi eccessivi, iniezione indiretta di prompt e vulnerabilità della supply chain, e fornisce controlli attuabili e migliori pratiche per mitigarli. Imparerai anche come sfruttare le soluzioni Microsoft come Prompt Shields, Azure Content Safety e GitHub Advanced Security per rafforzare la tua implementazione MCP. Comprendendo e applicando questi controlli, puoi ridurre significativamente la probabilità di una violazione della sicurezza e garantire che i tuoi sistemi AI rimangano robusti e affidabili.

# Obiettivi di apprendimento

Entro la fine di questa lezione, sarai in grado di:

- Identificare e spiegare i rischi di sicurezza unici introdotti dal Model Context Protocol (MCP), inclusi l'iniezione di prompt, l'avvelenamento degli strumenti, permessi eccessivi e vulnerabilità della supply chain.
- Descrivere e applicare controlli di mitigazione efficaci per i rischi di sicurezza MCP, come autenticazione robusta, minimo privilegio, gestione sicura dei token e verifica della supply chain.
- Comprendere e sfruttare le soluzioni Microsoft come Prompt Shields, Azure Content Safety e GitHub Advanced Security per proteggere i carichi di lavoro MCP e AI.
- Riconoscere l'importanza di validare i metadati degli strumenti, monitorare i cambiamenti dinamici e difendersi dagli attacchi di iniezione indiretta di prompt.
- Integrare le migliori pratiche di sicurezza consolidate, come la programmazione sicura, il rafforzamento del server e l'architettura zero trust, nella tua implementazione MCP per ridurre la probabilità e l'impatto delle violazioni della sicurezza.

# Controlli di sicurezza MCP

Qualsiasi sistema che ha accesso a risorse importanti presenta sfide di sicurezza implicite. Le sfide di sicurezza possono generalmente essere affrontate attraverso l'applicazione corretta di controlli e concetti di sicurezza fondamentali. Poiché MCP è appena stato definito, la specifica sta cambiando molto rapidamente e mentre il protocollo evolve. Alla fine i controlli di sicurezza al suo interno matureranno, consentendo una migliore integrazione con le architetture di sicurezza aziendali e consolidate e le migliori pratiche.

La ricerca pubblicata nel [Microsoft Digital Defense Report](https://aka.ms/mddr) afferma che il 98% delle violazioni segnalate verrebbe prevenuto da una robusta igiene di sicurezza e la migliore protezione contro qualsiasi tipo di violazione è ottenere la tua igiene di sicurezza di base, le migliori pratiche di programmazione sicura e la sicurezza della supply chain giuste -- quelle pratiche provate e testate che già conosciamo continuano a fare il maggior impatto nella riduzione del rischio di sicurezza.

Esaminiamo alcuni dei modi in cui puoi iniziare ad affrontare i rischi di sicurezza quando adotti MCP.

# Autenticazione del server MCP (se la tua implementazione MCP è stata prima del 26 aprile 2025)

> **Nota:** Le informazioni seguenti sono corrette a partire dal 26 aprile 2025. Il protocollo MCP è in continua evoluzione e le implementazioni future potrebbero introdurre nuovi modelli di autenticazione e controlli. Per gli aggiornamenti e le indicazioni più recenti, fai sempre riferimento alla [Specifica MCP](https://spec.modelcontextprotocol.io/) e al [repository ufficiale MCP su GitHub](https://github.com/modelcontextprotocol).

### Dichiarazione del problema
La specifica originale di MCP presupponeva che gli sviluppatori avrebbero scritto il proprio server di autenticazione. Questo richiedeva conoscenze di OAuth e vincoli di sicurezza correlati. I server MCP agivano come Server di Autorizzazione OAuth 2.0, gestendo direttamente l'autenticazione dell'utente richiesta piuttosto che delegarla a un servizio esterno come Microsoft Entra ID. A partire dal 26 aprile 2025, un aggiornamento alla specifica MCP consente ai server MCP di delegare l'autenticazione dell'utente a un servizio esterno.

### Rischi
- La logica di autorizzazione configurata in modo errato nel server MCP può portare all'esposizione di dati sensibili e all'applicazione errata dei controlli di accesso.
- Furto del token OAuth sul server MCP locale. Se rubato, il token può essere utilizzato per impersonare il server MCP e accedere a risorse e dati dal servizio per cui è destinato il token OAuth.

### Controlli di mitigazione
- **Rivedi e Rafforza la Logica di Autorizzazione:** Audita attentamente l'implementazione dell'autorizzazione del tuo server MCP per garantire che solo gli utenti e i clienti previsti possano accedere a risorse sensibili. Per una guida pratica, vedi [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Imponi Pratiche Sicure per i Token:** Segui [le migliori pratiche di Microsoft per la validazione e la durata dei token](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) per prevenire l'uso improprio dei token di accesso e ridurre il rischio di replay o furto del token.
- **Proteggi la Memorizzazione dei Token:** Memorizza sempre i token in modo sicuro e utilizza la crittografia per proteggerli a riposo e in transito. Per suggerimenti sull'implementazione, vedi [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permessi eccessivi per i server MCP

### Dichiarazione del problema
I server MCP potrebbero essere stati concessi permessi eccessivi al servizio/risorsa che stanno accedendo. Ad esempio, un server MCP che fa parte di un'applicazione di vendita AI che si connette a un archivio dati aziendale dovrebbe avere accesso limitato ai dati di vendita e non essere autorizzato ad accedere a tutti i file nell'archivio. Riferendosi al principio del minimo privilegio (uno dei principi di sicurezza più antichi), nessuna risorsa dovrebbe avere permessi superiori a quelli necessari per eseguire i compiti per cui è stata progettata. L'AI presenta una sfida aumentata in questo spazio perché per abilitarla a essere flessibile, può essere difficile definire i permessi esatti richiesti.

### Rischi
- Concedere permessi eccessivi può consentire l'esfiltrazione o la modifica dei dati che il server MCP non era destinato ad essere in grado di accedere. Questo potrebbe anche essere un problema di privacy se i dati sono informazioni personali identificabili (PII).

### Controlli di mitigazione
- **Applica il Principio del Minimo Privilegio:** Concedi al server MCP solo i permessi minimi necessari per eseguire i suoi compiti richiesti. Rivedi e aggiorna regolarmente questi permessi per garantire che non superino ciò che è necessario. Per una guida dettagliata, vedi [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usa il Controllo di Accesso Basato sui Ruoli (RBAC):** Assegna ruoli al server MCP che sono strettamente limitati a risorse e azioni specifiche, evitando permessi ampi o non necessari.
- **Monitora e Audita i Permessi:** Monitora continuamente l'uso dei permessi e audita i log di accesso per rilevare e risolvere prontamente privilegi eccessivi o non utilizzati.

# Attacchi di iniezione indiretta di prompt

### Dichiarazione del problema

I server MCP dannosi o compromessi possono introdurre rischi significativi esponendo i dati dei clienti o abilitando azioni indesiderate. Questi rischi sono particolarmente rilevanti nei carichi di lavoro basati su AI e MCP, dove:

- **Attacchi di Iniezione di Prompt:** Gli aggressori incorporano istruzioni dannose nei prompt o nei contenuti esterni, facendo sì che il sistema AI esegua azioni indesiderate o divulghi dati sensibili. Scopri di più: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Avvelenamento degli Strumenti:** Gli aggressori manipolano i metadati degli strumenti (come descrizioni o parametri) per influenzare il comportamento dell'AI, potenzialmente bypassando i controlli di sicurezza o esfiltrando dati. Dettagli: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Iniezione di Prompt Cross-Domain:** Istruzioni dannose sono incorporate in documenti, pagine web o email, che vengono poi elaborate dall'AI, portando a fughe di dati o manipolazioni.
- **Modifica Dinamica degli Strumenti (Rug Pulls):** Le definizioni degli strumenti possono essere modificate dopo l'approvazione dell'utente, introducendo nuovi comportamenti dannosi senza la consapevolezza dell'utente.

Queste vulnerabilità evidenziano la necessità di una robusta validazione, monitoraggio e controlli di sicurezza quando si integrano server e strumenti MCP nel tuo ambiente. Per un approfondimento, vedi i riferimenti collegati sopra.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.4b2f1af239a32d46221a75c7bc5b6f392ebbacc47eccde241d4c60507232fa43.it.png)

**Iniezione Indiretta di Prompt** (nota anche come iniezione di prompt cross-domain o XPIA) è una vulnerabilità critica nei sistemi AI generativi, inclusi quelli che utilizzano il Model Context Protocol (MCP). In questo attacco, istruzioni dannose sono nascoste all'interno di contenuti esterni, come documenti, pagine web o email. Quando il sistema AI elabora questo contenuto, può interpretare le istruzioni incorporate come comandi legittimi dell'utente, risultando in azioni indesiderate come fughe di dati, generazione di contenuti dannosi o manipolazione delle interazioni degli utenti. Per una spiegazione dettagliata e esempi reali, vedi [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Una forma particolarmente pericolosa di questo attacco è **l'Avvelenamento degli Strumenti**. Qui, gli aggressori iniettano istruzioni dannose nei metadati degli strumenti MCP (come descrizioni o parametri degli strumenti). Poiché i modelli di linguaggio ampio (LLM) si basano su questi metadati per decidere quali strumenti invocare, descrizioni compromesse possono ingannare il modello facendogli eseguire chiamate di strumenti non autorizzate o bypassare i controlli di sicurezza. Queste manipolazioni sono spesso invisibili agli utenti finali ma possono essere interpretate e agite dal sistema AI. Questo rischio è aumentato negli ambienti di server MCP ospitati, dove le definizioni degli strumenti possono essere aggiornate dopo l'approvazione dell'utente -- uno scenario a volte indicato come un "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". In tali casi, uno strumento che era precedentemente sicuro potrebbe essere successivamente modificato per eseguire azioni dannose, come esfiltrare dati o alterare il comportamento del sistema, senza la conoscenza dell'utente. Per ulteriori informazioni su questo vettore di attacco, vedi [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.d4607023f69e16157954001ad81afd763676361f03db0a1cf24ec696b2ddcb88.it.png)

## Rischi
Azioni AI indesiderate presentano una varietà di rischi di sicurezza che includono esfiltrazione di dati e violazioni della privacy.

### Controlli di mitigazione
### Utilizzo di prompt shields per proteggersi dagli attacchi di iniezione indiretta di prompt
-----------------------------------------------------------------------------

**AI Prompt Shields** sono una soluzione sviluppata da Microsoft per difendersi dagli attacchi di iniezione di prompt sia diretti che indiretti. Aiutano attraverso:

1.  **Rilevamento e Filtraggio**: Prompt Shields utilizzano algoritmi avanzati di machine learning e elaborazione del linguaggio naturale per rilevare e filtrare le istruzioni dannose incorporate nei contenuti esterni, come documenti, pagine web o email.
    
2.  **Spotlighting**: Questa tecnica aiuta il sistema AI a distinguere tra istruzioni valide del sistema e input esterni potenzialmente inaffidabili. Trasformando il testo di input in modo che sia più pertinente al modello, Spotlighting garantisce che l'AI possa meglio identificare e ignorare le istruzioni dannose.
    
3.  **Delimitatori e Datamarking**: Includere delimitatori nel messaggio del sistema delinea esplicitamente la posizione del testo di input, aiutando il sistema AI a riconoscere e separare gli input degli utenti dai contenuti esterni potenzialmente dannosi. Datamarking estende questo concetto utilizzando marcatori speciali per evidenziare i confini tra dati affidabili e non affidabili.
    
4.  **Monitoraggio e Aggiornamenti Continui**: Microsoft monitora e aggiorna continuamente Prompt Shields per affrontare minacce nuove e in evoluzione. Questo approccio proattivo garantisce che le difese rimangano efficaci contro le ultime tecniche di attacco.
    
5. **Integrazione con Azure Content Safety:** Prompt Shields fanno parte della suite più ampia di Azure AI Content Safety, che fornisce strumenti aggiuntivi per rilevare tentativi di jailbreak, contenuti dannosi e altri rischi di sicurezza nelle applicazioni AI.

Puoi leggere di più sui prompt shields AI nella [documentazione di Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.a4dba28a04ea42d28053f233585290d4862b244ca1e59b8ff695c5530e1bba66.it.png)

### Sicurezza della supply chain

La sicurezza della supply chain rimane fondamentale nell'era dell'AI, ma l'ambito di ciò che costituisce la tua supply chain si è ampliato. Oltre ai pacchetti di codice tradizionali, ora devi verificare e monitorare rigorosamente tutti i componenti correlati all'AI, inclusi modelli di base, servizi di embedding, fornitori di contesto e API di terze parti. Ognuno di questi può introdurre vulnerabilità o rischi se non gestito correttamente.

**Principali pratiche di sicurezza della supply chain per AI e MCP:**
- **Verifica tutti i componenti prima dell'integrazione:** Questo include non solo le librerie open-source, ma anche modelli AI, fonti di dati e API esterne. Controlla sempre la provenienza, le licenze e le vulnerabilità conosciute.
- **Mantieni pipeline di distribuzione sicure:** Usa pipeline CI/CD automatizzate con scansione di sicurezza integrata per rilevare problemi precocemente. Assicurati che solo artefatti affidabili siano distribuiti in produzione.
- **Monitora e audita continuamente:** Implementa il monitoraggio continuo di tutte le dipendenze, inclusi modelli e servizi dati, per rilevare nuove vulnerabilità o attacchi alla supply chain.
- **Applica il minimo privilegio e controlli di accesso:** Limita l'accesso a modelli, dati e servizi solo a ciò che è necessario per il funzionamento del tuo server MCP.
- **Rispondi rapidamente alle minacce:** Avere un processo in atto per patchare o sostituire componenti compromessi e per ruotare segreti o credenziali se viene rilevata una violazione.

[GitHub Advanced Security](https://github.com/security/advanced-security) fornisce funzionalità come scansione dei segreti, scansione delle dipendenze e analisi CodeQL. Questi strumenti si integrano con [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) per aiutare i team a identificare e mitigare le vulnerabilità sia nel codice che nei componenti della supply chain AI.

Microsoft implementa anche pratiche di sicurezza della supply chain estese internamente per tutti i prodotti. Scopri di più in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Migliori pratiche di sicurezza consolidate che miglioreranno la postura di sicurezza della tua implementazione MCP

Qualsiasi implementazione MCP eredita la postura di sicurezza esistente dell'ambiente della tua organizzazione su cui è costruita, quindi quando si considera la sicurezza di MCP come componente dei tuoi sistemi AI complessivi, è consigliabile considerare di migliorare la tua postura di sicurezza esistente complessiva. I seguenti controlli di sicurezza consolidati sono particolarmente pertinenti:

-   Migliori pratiche di programmazione sicura nella tua applicazione AI - proteggi contro [l'OWASP Top 10](https://owasp.org/www-project-top-ten/), [l'OWASP Top 10 per LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso di vault sicuri per segreti e token, implementazione di comunicazioni sicure
- [OWASP Top 10 per LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Il percorso per proteggere la catena di fornitura del software in Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Accesso sicuro con privilegi minimi (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best practice per la validazione e la durata dei token](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Usa l'archiviazione sicura dei token e cripta i token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management come gateway di autenticazione per MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Utilizzare Microsoft Entra ID per autenticarsi con i server MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Successivo

Successivo: [Capitolo 3: Introduzione](/03-GettingStarted/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione AI [Co-op Translator](https://github.com/Azure/co-op-translator). Sebbene ci impegniamo per l'accuratezza, si prega di essere consapevoli che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua madre dovrebbe essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale umana. Non siamo responsabili per eventuali fraintendimenti o interpretazioni errate derivanti dall'uso di questa traduzione.