<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:15:28+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "it"
}
-->
# Best Practice di Sicurezza

L’adozione del Model Context Protocol (MCP) introduce potenti nuove funzionalità nelle applicazioni AI-driven, ma comporta anche sfide di sicurezza uniche che vanno oltre i rischi software tradizionali. Oltre a preoccupazioni consolidate come il coding sicuro, il principio del privilegio minimo e la sicurezza della supply chain, MCP e i workload AI affrontano nuove minacce quali prompt injection, tool poisoning e modifiche dinamiche agli strumenti. Questi rischi possono portare a furto di dati, violazioni della privacy e comportamenti imprevisti del sistema se non gestiti correttamente.

Questa lezione esplora i rischi di sicurezza più rilevanti associati a MCP — inclusi autenticazione, autorizzazione, permessi eccessivi, prompt injection indiretta e vulnerabilità della supply chain — e fornisce controlli pratici e best practice per mitigarli. Imparerai anche come sfruttare soluzioni Microsoft come Prompt Shields, Azure Content Safety e GitHub Advanced Security per rafforzare la tua implementazione MCP. Comprendendo e applicando questi controlli, potrai ridurre significativamente la probabilità di una violazione della sicurezza e garantire che i tuoi sistemi AI rimangano robusti e affidabili.

# Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Identificare e spiegare i rischi di sicurezza unici introdotti dal Model Context Protocol (MCP), inclusi prompt injection, tool poisoning, permessi eccessivi e vulnerabilità della supply chain.
- Descrivere e applicare controlli efficaci per mitigare i rischi di sicurezza MCP, come autenticazione robusta, principio del privilegio minimo, gestione sicura dei token e verifica della supply chain.
- Comprendere e sfruttare soluzioni Microsoft come Prompt Shields, Azure Content Safety e GitHub Advanced Security per proteggere MCP e i workload AI.
- Riconoscere l’importanza di validare i metadata degli strumenti, monitorare modifiche dinamiche e difendersi dagli attacchi di prompt injection indiretta.
- Integrare best practice di sicurezza consolidate — come coding sicuro, hardening dei server e architettura zero trust — nella tua implementazione MCP per ridurre probabilità e impatto di violazioni.

# Controlli di sicurezza MCP

Qualsiasi sistema con accesso a risorse importanti presenta sfide di sicurezza implicite. Queste sfide possono generalmente essere affrontate applicando correttamente controlli e concetti fondamentali di sicurezza. Poiché MCP è una specifica nuova e in rapido cambiamento, i controlli di sicurezza al suo interno si evolveranno e matureranno, permettendo una migliore integrazione con architetture di sicurezza aziendali consolidate e best practice.

La ricerca pubblicata nel [Microsoft Digital Defense Report](https://aka.ms/mddr) afferma che il 98% delle violazioni segnalate sarebbe prevenuto da una solida igiene di sicurezza. La miglior protezione contro qualsiasi tipo di violazione è mantenere una buona igiene di base, seguire best practice di coding sicuro e assicurare la sicurezza della supply chain — pratiche collaudate che ancora oggi fanno la differenza nella riduzione del rischio.

Vediamo alcuni modi per iniziare ad affrontare i rischi di sicurezza adottando MCP.

> **Nota:** Le informazioni seguenti sono corrette al **29 maggio 2025**. Il protocollo MCP è in continua evoluzione e future implementazioni potrebbero introdurre nuovi schemi di autenticazione e controlli. Per aggiornamenti e linee guida, consulta sempre la [MCP Specification](https://spec.modelcontextprotocol.io/), il repository ufficiale [MCP GitHub](https://github.com/modelcontextprotocol) e la [pagina best practice di sicurezza](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problema

La specifica originale MCP presupponeva che gli sviluppatori scrivessero un proprio server di autenticazione. Questo richiedeva conoscenze di OAuth e vincoli di sicurezza correlati. I server MCP agivano come OAuth 2.0 Authorization Server, gestendo direttamente l’autenticazione utente invece di delegarla a un servizio esterno come Microsoft Entra ID. Dal **26 aprile 2025**, un aggiornamento della specifica MCP consente ai server MCP di delegare l’autenticazione utente a un servizio esterno.

### Rischi

- Logica di autorizzazione mal configurata nel server MCP può portare a esposizione di dati sensibili e controlli di accesso applicati in modo errato.
- Furto di token OAuth sul server MCP locale. Se rubato, il token può essere usato per impersonare il server MCP e accedere a risorse e dati del servizio associato al token.

#### Token Passthrough

Il token passthrough è esplicitamente vietato nella specifica di autorizzazione perché introduce diversi rischi di sicurezza, tra cui:

#### Circumvention dei Controlli di Sicurezza

Il server MCP o le API downstream potrebbero implementare controlli importanti come rate limiting, validazione delle richieste o monitoraggio del traffico, che dipendono dal pubblico del token o da altri vincoli delle credenziali. Se i client possono ottenere e usare token direttamente con le API downstream senza che il server MCP li convalidi correttamente o assicuri che siano stati emessi per il servizio giusto, aggirano questi controlli.

#### Problemi di Responsabilità e Tracciabilità

Il server MCP non sarà in grado di identificare o distinguere i client MCP quando questi chiamano con un token di accesso emesso a monte, che può essere opaco per il server MCP. I log del Resource Server downstream potrebbero mostrare richieste apparentemente provenienti da una fonte diversa con identità differente, anziché dal server MCP che effettivamente inoltra i token. Entrambi i fattori complicano l’indagine sugli incidenti, i controlli e gli audit. Se il server MCP passa token senza convalidarne le affermazioni (ad esempio ruoli, privilegi o audience) o altri metadata, un attore malintenzionato in possesso di un token rubato può usare il server come proxy per l’esfiltrazione dati.

#### Problemi di Confine di Fiducia

Il Resource Server downstream concede fiducia a entità specifiche, basandosi su assunzioni sull’origine o sul comportamento del client. Rompere questo confine di fiducia può causare problemi imprevisti. Se il token è accettato da più servizi senza una valida convalida, un attaccante che compromette un servizio può usare il token per accedere ad altri servizi connessi.

#### Rischio di Compatibilità Futuro

Anche se un server MCP parte oggi come “proxy puro”, potrebbe dover aggiungere controlli di sicurezza in futuro. Iniziare con una corretta separazione del pubblico del token facilita l’evoluzione del modello di sicurezza.

### Controlli mitiganti

**I server MCP NON DEVONO accettare token che non siano stati esplicitamente emessi per il server MCP**

- **Revisiona e Rinforza la Logica di Autorizzazione:** Controlla attentamente l’implementazione dell’autorizzazione del tuo server MCP per assicurarti che solo utenti e client autorizzati possano accedere a risorse sensibili. Per indicazioni pratiche, consulta [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Applica Pratiche Sicure per i Token:** Segui le [best practice Microsoft per la validazione e la durata dei token](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) per prevenire usi impropri e ridurre il rischio di replay o furto.
- **Proteggi lo Storage dei Token:** Conserva sempre i token in modo sicuro, usando crittografia a riposo e in transito. Per consigli sull’implementazione, vedi [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permessi eccessivi per i server MCP

### Problema

I server MCP potrebbero aver ricevuto permessi eccessivi sul servizio o risorsa a cui accedono. Per esempio, un server MCP parte di un’applicazione AI per le vendite che si collega a un data store aziendale dovrebbe avere accesso limitato ai dati di vendita e non a tutti i file del deposito. Tornando al principio del privilegio minimo (uno dei più antichi principi di sicurezza), nessuna risorsa dovrebbe avere permessi superiori a quelli necessari per svolgere i compiti previsti. L’AI rappresenta una sfida maggiore in questo ambito perché, per garantirne la flessibilità, è difficile definire con precisione i permessi richiesti.

### Rischi

- Concedere permessi eccessivi può permettere esfiltrazione o modifica di dati non autorizzati. Questo può anche rappresentare un problema di privacy se i dati sono informazioni personali identificabili (PII).

### Controlli mitiganti

- **Applica il Principio del Privilegio Minimo:** Concedi al server MCP solo i permessi minimi necessari per eseguire i suoi compiti. Revisiona e aggiorna regolarmente questi permessi per assicurarti che non eccedano quanto richiesto. Per guida dettagliata, vedi [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usa il Controllo di Accesso Basato sui Ruoli (RBAC):** Assegna ruoli al server MCP strettamente limitati a specifiche risorse e azioni, evitando permessi ampi o inutili.
- **Monitora e Audita i Permessi:** Tieni sotto controllo l’uso dei permessi e audita i log di accesso per rilevare e correggere tempestivamente privilegi eccessivi o inutilizzati.

# Attacchi di prompt injection indiretta

### Problema

Server MCP malevoli o compromessi possono introdurre rischi significativi esponendo dati dei clienti o abilitando azioni non intenzionate. Questi rischi sono particolarmente rilevanti nei workload AI e basati su MCP, dove:

- **Prompt Injection Attacks**: Gli attaccanti inseriscono istruzioni malevole nei prompt o contenuti esterni, inducendo il sistema AI a compiere azioni non volute o a divulgare dati sensibili. Approfondisci: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning**: Gli attaccanti manipolano i metadata degli strumenti (come descrizioni o parametri) per influenzare il comportamento dell’AI, potenzialmente aggirando controlli di sicurezza o esfiltrando dati. Dettagli: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection**: Istruzioni malevole nascoste in documenti, pagine web o email, poi processate dall’AI, causando perdita o manipolazione dati.
- **Modifica Dinamica degli Strumenti (Rug Pulls)**: Le definizioni degli strumenti possono essere modificate dopo l’approvazione dell’utente, introducendo comportamenti malevoli senza che l’utente ne sia consapevole.

Queste vulnerabilità sottolineano la necessità di validazione robusta, monitoraggio e controlli di sicurezza quando si integrano server MCP e strumenti nel proprio ambiente. Per approfondimenti, consulta i riferimenti linkati.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.it.png)

**Prompt Injection Indiretta** (nota anche come cross-domain prompt injection o XPIA) è una vulnerabilità critica nei sistemi AI generativi, inclusi quelli che usano MCP. In questo attacco, istruzioni malevole sono nascoste in contenuti esterni — come documenti, pagine web o email. Quando il sistema AI elabora questi contenuti, può interpretare le istruzioni incorporate come comandi legittimi, causando azioni indesiderate come fuga di dati, generazione di contenuti dannosi o manipolazione delle interazioni utente. Per una spiegazione dettagliata ed esempi reali, vedi [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Una forma particolarmente pericolosa di questo attacco è il **Tool Poisoning**. Qui, gli attaccanti iniettano istruzioni malevole nei metadata degli strumenti MCP (come descrizioni o parametri). Poiché i modelli linguistici di grandi dimensioni (LLM) si basano su questi metadata per decidere quali strumenti invocare, descrizioni compromesse possono ingannare il modello inducendolo a chiamate non autorizzate o a eludere controlli di sicurezza. Queste manipolazioni sono spesso invisibili agli utenti finali ma interpretate e eseguite dal sistema AI. Il rischio è amplificato negli ambienti di server MCP ospitati, dove le definizioni degli strumenti possono essere aggiornate dopo l’approvazione dell’utente — uno scenario noto come "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". In questi casi, uno strumento precedentemente sicuro può essere modificato per compiere azioni malevole, come esfiltrazione dati o alterazione del comportamento del sistema, senza che l’utente ne sia a conoscenza. Per maggiori informazioni, vedi [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.it.png)

## Rischi

Azioni AI non intenzionate comportano vari rischi di sicurezza, tra cui esfiltrazione dati e violazioni della privacy.

### Controlli mitiganti

### Uso di prompt shields per proteggersi dagli attacchi di Prompt Injection Indiretta
-----------------------------------------------------------------------------

**AI Prompt Shields** sono una soluzione sviluppata da Microsoft per difendersi sia dagli attacchi diretti che indiretti di prompt injection. Aiutano attraverso:

1.  **Rilevamento e Filtraggio:** Prompt Shields utilizzano algoritmi avanzati di machine learning e natural language processing per individuare e filtrare istruzioni malevole nascoste in contenuti esterni, come documenti, pagine web o email.
    
2.  **Spotlighting:** Questa tecnica aiuta il sistema AI a distinguere tra istruzioni di sistema valide e input esterni potenzialmente non affidabili. Trasformando il testo in ingresso in modo da renderlo più rilevante per il modello, Spotlighting assicura che l’AI identifichi meglio e ignori le istruzioni malevole.
    
3.  **Delimitatori e Datamarking:** L’inserimento di delimitatori nel messaggio di sistema indica esplicitamente la posizione del testo in ingresso, aiutando l’AI a riconoscere e separare gli input utente da contenuti esterni potenzialmente dannosi. Il datamarking estende questo concetto usando marcatori speciali per evidenziare i confini tra dati affidabili e non affidabili.
    
4.  **Monitoraggio e Aggiornamenti Continui:** Microsoft monitora e aggiorna costantemente Prompt Shields per affrontare nuove minacce in evoluzione. Questo approccio proattivo garantisce che le difese rimangano efficaci contro le ultime tecniche di attacco.
    
5. **Integrazione con Azure Content Safety:** Prompt Shields fanno parte della suite Azure AI Content Safety, che offre ulteriori strumenti per rilevare tentativi di jailbreak, contenuti dannosi e altri rischi di sicurezza nelle applicazioni AI.

Puoi approfondire AI Prompt Shields nella [documentazione Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.it.png)

### Sicurezza della supply chain

La sicurezza della supply chain resta fondamentale nell’era AI, ma il concetto di supply chain si è ampliato. Oltre ai tradizionali pacchetti di codice, è necessario verificare e monitorare rigorosamente tutti i componenti AI, inclusi modelli di base, servizi di embeddings, provider di contesto e API di terze parti. Ognuno di questi può introdurre vulnerabilità o rischi se non gestito correttamente.

**Pratiche chiave di sicurezza della supply chain per AI e MCP:**
- **Verifica tutti i componenti prima dell’integrazione:** Non solo librerie open source, ma anche modelli AI, fonti dati e API esterne. Controlla sempre provenienza, licenze e vulnerabilità note.
- **Mantieni pipeline di deployment sicure:** Usa pipeline CI/CD automatizzate con scansione di sicurezza integrata per individuare problemi precocemente. Assicurati che solo artefatti affidabili vengano distribuiti in produzione.
- **Monitora e audita continuamente:** Implementa monitoraggio costante di tutte le dipendenze, inclusi modelli e servizi dati, per rilevare nuove vulnerabilità o attacchi alla supply chain.
- **Applica il principio del privilegio minimo e controlli di accesso:** Limita l’accesso a modelli, dati e servizi solo a quanto necessario per il funzionamento del server MCP.
- **Rispondi rapidamente alle minacce:** Prevedi processi per patchare o sostituire componenti compromessi e per ruotare segreti o credenziali in caso di violazioni.

[GitHub Advanced Security](https://github.com/security/advanced-security) offre funzionalità come scansione di segreti, scansione delle dipendenze e analisi CodeQL. Questi strumenti si integrano con [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) per aiutare i team a identificare e mitigare vulnerabilità sia nel codice sia nei componenti AI della supply chain.

Microsoft applica inoltre pratiche estese di sicurezza della supply chain internamente per tutti i suoi prodotti. Scopri di più in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Best practice di sicurezza consolidate per migliorare la postura di sicurezza della tua implementazione
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 per LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Il percorso per mettere in sicurezza la supply chain del software in Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Accesso con privilegi minimi sicuro (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best practice per la validazione e la durata dei token](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Usa uno storage sicuro per i token e crittografa i token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management come gateway di autenticazione per MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Best practice di sicurezza MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Usare Microsoft Entra ID per autenticarsi con i server MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Successivo

Successivo: [Capitolo 3: Per iniziare](/03-GettingStarted/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda la traduzione professionale umana. Non siamo responsabili per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.