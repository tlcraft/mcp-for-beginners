<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c69f9df7f3215dac8d056020539bac36",
  "translation_date": "2025-07-04T17:07:41+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "it"
}
-->
# Best Practice di Sicurezza

Adottare il Model Context Protocol (MCP) offre nuove potenti funzionalità per le applicazioni basate su AI, ma introduce anche sfide di sicurezza uniche che vanno oltre i rischi tradizionali del software. Oltre a preoccupazioni consolidate come la scrittura di codice sicuro, il principio del minimo privilegio e la sicurezza della supply chain, MCP e i carichi di lavoro AI affrontano nuove minacce come prompt injection, avvelenamento degli strumenti e modifiche dinamiche degli strumenti. Questi rischi possono portare a esfiltrazione di dati, violazioni della privacy e comportamenti imprevisti del sistema se non gestiti correttamente.

Questa lezione esplora i rischi di sicurezza più rilevanti associati a MCP — inclusi autenticazione, autorizzazione, permessi eccessivi, prompt injection indiretta e vulnerabilità della supply chain — e fornisce controlli pratici e best practice per mitigarli. Imparerai anche come sfruttare soluzioni Microsoft come Prompt Shields, Azure Content Safety e GitHub Advanced Security per rafforzare la tua implementazione MCP. Comprendendo e applicando questi controlli, potrai ridurre significativamente la probabilità di una violazione della sicurezza e garantire che i tuoi sistemi AI rimangano robusti e affidabili.

# Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Identificare e spiegare i rischi di sicurezza unici introdotti dal Model Context Protocol (MCP), inclusi prompt injection, avvelenamento degli strumenti, permessi eccessivi e vulnerabilità della supply chain.
- Descrivere e applicare controlli efficaci per mitigare i rischi di sicurezza MCP, come autenticazione robusta, principio del minimo privilegio, gestione sicura dei token e verifica della supply chain.
- Comprendere e utilizzare soluzioni Microsoft come Prompt Shields, Azure Content Safety e GitHub Advanced Security per proteggere MCP e i carichi di lavoro AI.
- Riconoscere l’importanza di validare i metadata degli strumenti, monitorare le modifiche dinamiche e difendersi dagli attacchi di prompt injection indiretta.
- Integrare best practice di sicurezza consolidate — come coding sicuro, hardening del server e architettura zero trust — nella tua implementazione MCP per ridurre la probabilità e l’impatto di violazioni della sicurezza.

# Controlli di sicurezza MCP

Qualsiasi sistema che ha accesso a risorse importanti presenta sfide di sicurezza implicite. Queste sfide possono generalmente essere affrontate attraverso l’applicazione corretta di controlli e concetti fondamentali di sicurezza. Poiché MCP è una specifica appena definita, la sua evoluzione è molto rapida e, con il tempo, i controlli di sicurezza al suo interno matureranno, permettendo una migliore integrazione con architetture di sicurezza aziendali consolidate e best practice.

La ricerca pubblicata nel [Microsoft Digital Defense Report](https://aka.ms/mddr) afferma che il 98% delle violazioni segnalate sarebbe prevenuto da una rigorosa igiene della sicurezza e che la migliore protezione contro qualsiasi tipo di violazione è mantenere una solida igiene di base, seguire le best practice di coding sicuro e garantire la sicurezza della supply chain — quelle pratiche collaudate che già conosciamo continuano a fare la differenza nella riduzione del rischio di sicurezza.

Vediamo alcune modalità per iniziare ad affrontare i rischi di sicurezza adottando MCP.

> **Nota:** Le informazioni seguenti sono corrette al **29 maggio 2025**. Il protocollo MCP è in continua evoluzione e le implementazioni future potrebbero introdurre nuovi schemi di autenticazione e controlli. Per gli aggiornamenti più recenti e le linee guida, fai sempre riferimento alla [Specificazione MCP](https://spec.modelcontextprotocol.io/) e al repository ufficiale [MCP GitHub](https://github.com/modelcontextprotocol) e alla [pagina delle best practice di sicurezza](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Descrizione del problema  
La specifica originale MCP presupponeva che gli sviluppatori scrivessero il proprio server di autenticazione. Questo richiedeva conoscenze di OAuth e dei relativi vincoli di sicurezza. I server MCP agivano come OAuth 2.0 Authorization Server, gestendo direttamente l’autenticazione degli utenti invece di delegarla a un servizio esterno come Microsoft Entra ID. Dal **26 aprile 2025**, un aggiornamento della specifica MCP consente ai server MCP di delegare l’autenticazione utente a un servizio esterno.

### Rischi
- Logica di autorizzazione mal configurata nel server MCP può portare all’esposizione di dati sensibili e a controlli di accesso applicati in modo errato.
- Furto di token OAuth sul server MCP locale. Se rubato, il token può essere usato per impersonare il server MCP e accedere a risorse e dati del servizio per cui il token OAuth è valido.

#### Token Passthrough
Il token passthrough è esplicitamente vietato nella specifica di autorizzazione poiché introduce diversi rischi di sicurezza, tra cui:

#### Elusione dei Controlli di Sicurezza
Il server MCP o le API a valle potrebbero implementare controlli di sicurezza importanti come rate limiting, validazione delle richieste o monitoraggio del traffico, che dipendono dal pubblico del token o da altri vincoli delle credenziali. Se i client possono ottenere e usare token direttamente con le API a valle senza che il server MCP li convalidi correttamente o assicuri che i token siano emessi per il servizio giusto, questi controlli vengono aggirati.

#### Problemi di Responsabilità e Tracciabilità
Il server MCP non sarà in grado di identificare o distinguere tra i client MCP quando questi chiamano con un token di accesso emesso a monte che potrebbe essere opaco per il server MCP.  
I log del Resource Server a valle potrebbero mostrare richieste che sembrano provenire da una fonte diversa con un’identità differente, anziché dal server MCP che effettivamente inoltra i token.  
Entrambi i fattori rendono più difficili le indagini sugli incidenti, i controlli e le verifiche.  
Se il server MCP passa i token senza convalidarne le affermazioni (ad esempio ruoli, privilegi o pubblico) o altri metadata, un attore malevolo in possesso di un token rubato può usare il server come proxy per l’esfiltrazione di dati.

#### Problemi di Confine di Fiducia
Il Resource Server a valle concede fiducia a entità specifiche. Questa fiducia può includere assunzioni sull’origine o sui modelli di comportamento del client. Rompere questo confine di fiducia potrebbe causare problemi imprevisti.  
Se il token è accettato da più servizi senza una convalida adeguata, un attaccante che compromette un servizio può usare il token per accedere ad altri servizi connessi.

#### Rischio di Compatibilità Futura
Anche se un server MCP inizia oggi come un “proxy puro”, potrebbe dover aggiungere controlli di sicurezza in seguito. Iniziare con una corretta separazione del pubblico del token facilita l’evoluzione del modello di sicurezza.

### Controlli mitiganti

**I server MCP NON DEVONO accettare token che non siano stati esplicitamente emessi per il server MCP**

- **Revisiona e Rafforza la Logica di Autorizzazione:** Effettua un audit accurato dell’implementazione di autorizzazione del tuo server MCP per garantire che solo gli utenti e i client previsti possano accedere a risorse sensibili. Per indicazioni pratiche, consulta [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Applica Pratiche Sicure per i Token:** Segui le [best practice Microsoft per la validazione e la durata dei token](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) per prevenire l’uso improprio dei token di accesso e ridurre il rischio di replay o furto.
- **Proteggi l’Archiviazione dei Token:** Conserva sempre i token in modo sicuro e usa la crittografia per proteggerli a riposo e in transito. Per suggerimenti sull’implementazione, vedi [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permessi eccessivi per i server MCP

### Descrizione del problema
I server MCP potrebbero aver ricevuto permessi eccessivi sul servizio o sulla risorsa a cui accedono. Ad esempio, un server MCP che fa parte di un’applicazione AI per le vendite che si connette a un archivio dati aziendale dovrebbe avere accesso limitato ai dati di vendita e non dovrebbe poter accedere a tutti i file dell’archivio. Richiamando il principio del minimo privilegio (uno dei principi di sicurezza più antichi), nessuna risorsa dovrebbe avere permessi superiori a quelli necessari per eseguire i compiti per cui è stata progettata. L’AI presenta una sfida maggiore in questo ambito perché, per garantirne la flessibilità, può essere difficile definire esattamente i permessi richiesti.

### Rischi  
- Concedere permessi eccessivi può permettere l’esfiltrazione o la modifica di dati a cui il server MCP non dovrebbe avere accesso. Questo può anche rappresentare un problema di privacy se i dati sono informazioni personali identificabili (PII).

### Controlli mitiganti
- **Applica il Principio del Minimo Privilegio:** Concedi al server MCP solo i permessi minimi necessari per svolgere i compiti richiesti. Rivedi e aggiorna regolarmente questi permessi per assicurarti che non superino quanto necessario. Per indicazioni dettagliate, consulta [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usa il Controllo di Accesso Basato sui Ruoli (RBAC):** Assegna ruoli al server MCP strettamente limitati a risorse e azioni specifiche, evitando permessi ampi o non necessari.
- **Monitora e Audita i Permessi:** Monitora continuamente l’uso dei permessi e verifica i log di accesso per rilevare e correggere tempestivamente privilegi eccessivi o inutilizzati.

# Attacchi di prompt injection indiretta

### Descrizione del problema

Server MCP malevoli o compromessi possono introdurre rischi significativi esponendo dati dei clienti o abilitando azioni non intenzionali. Questi rischi sono particolarmente rilevanti nei carichi di lavoro AI e basati su MCP, dove:

- **Attacchi di Prompt Injection:** Gli attaccanti inseriscono istruzioni malevole nei prompt o in contenuti esterni, inducendo il sistema AI a compiere azioni non volute o a divulgare dati sensibili. Approfondisci: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Avvelenamento degli Strumenti:** Gli attaccanti manipolano i metadata degli strumenti (come descrizioni o parametri) per influenzare il comportamento dell’AI, potenzialmente aggirando controlli di sicurezza o esfiltrando dati. Dettagli: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Prompt Injection Cross-Domain:** Istruzioni malevole sono inserite in documenti, pagine web o email, che vengono poi processati dall’AI, causando perdite o manipolazioni di dati.
- **Modifica Dinamica degli Strumenti (Rug Pulls):** Le definizioni degli strumenti possono essere modificate dopo l’approvazione dell’utente, introducendo nuovi comportamenti malevoli senza che l’utente ne sia consapevole.

Queste vulnerabilità evidenziano la necessità di validazione robusta, monitoraggio e controlli di sicurezza quando si integrano server MCP e strumenti nel proprio ambiente. Per approfondire, consulta i riferimenti linkati sopra.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.it.png)

**Prompt Injection Indiretta** (nota anche come cross-domain prompt injection o XPIA) è una vulnerabilità critica nei sistemi AI generativi, inclusi quelli che utilizzano il Model Context Protocol (MCP). In questo attacco, istruzioni malevole sono nascoste all’interno di contenuti esterni — come documenti, pagine web o email. Quando il sistema AI elabora questo contenuto, può interpretare le istruzioni incorporate come comandi legittimi dell’utente, causando azioni non intenzionali come la fuga di dati, la generazione di contenuti dannosi o la manipolazione delle interazioni con l’utente. Per una spiegazione dettagliata ed esempi reali, vedi [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Una forma particolarmente pericolosa di questo attacco è il **Tool Poisoning**. Qui, gli attaccanti iniettano istruzioni malevole nei metadata degli strumenti MCP (come descrizioni o parametri). Poiché i modelli di linguaggio di grandi dimensioni (LLM) si basano su questi metadata per decidere quali strumenti invocare, descrizioni compromesse possono ingannare il modello inducendolo a eseguire chiamate a strumenti non autorizzate o a bypassare controlli di sicurezza. Queste manipolazioni sono spesso invisibili agli utenti finali ma possono essere interpretate e agite dal sistema AI. Questo rischio è accentuato negli ambienti con server MCP ospitati, dove le definizioni degli strumenti possono essere aggiornate dopo l’approvazione dell’utente — uno scenario talvolta definito come "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". In questi casi, uno strumento precedentemente sicuro può essere modificato successivamente per compiere azioni malevole, come esfiltrare dati o alterare il comportamento del sistema, senza che l’utente ne sia a conoscenza. Per maggiori informazioni su questo vettore di attacco, vedi [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.it.png)

## Rischi
Azioni AI non intenzionali presentano vari rischi di sicurezza, tra cui esfiltrazione di dati e violazioni della privacy.

### Controlli mitiganti
### Uso di prompt shields per proteggersi dagli attacchi di Prompt Injection Indiretta
-----------------------------------------------------------------------------

**AI Prompt Shields** sono una soluzione sviluppata da Microsoft per difendersi sia dagli attacchi di prompt injection diretta che indiretta. Aiutano attraverso:

1.  **Rilevamento e Filtraggio:** Prompt Shields utilizzano algoritmi avanzati di machine learning e elaborazione del linguaggio naturale per rilevare e filtrare istruzioni malevole incorporate in contenuti esterni, come documenti, pagine web o email.
    
2.  **Spotlighting:** Questa tecnica aiuta il sistema AI a distinguere tra istruzioni di sistema valide e input esterni potenzialmente non affidabili. Trasformando il testo di input in modo che sia più rilevante per il modello, Spotlighting assicura che l’AI possa identificare meglio e ignorare istruzioni malevole.
    
3.  **Delimitatori e Datamarking:** L’inclusione di delimitatori nel messaggio di sistema indica esplicitamente la posizione del testo di input, aiutando il sistema AI a riconoscere e separare gli input dell’utente da contenuti esterni potenzialmente dannosi. Il datamarking estende questo concetto usando marcatori speciali per evidenziare i confini tra dati affidabili e non affidabili.
    
4.  **Monitoraggio Continuo e Aggiornamenti:** Microsoft monitora e aggiorna costantemente Prompt Shields per affrontare nuove minacce in evoluzione. Questo approccio proattivo garantisce che le difese rimangano efficaci contro le tecniche di attacco più recenti.
    
5. **Integrazione con Azure Content Safety:** Prompt Shields fanno parte della suite più ampia Azure AI Content Safety, che fornisce ulteriori strumenti per rilevare tentativi di jailbreak, contenuti dannosi e altri rischi di sicurezza nelle applicazioni AI.

Puoi leggere di più su AI prompt shields nella [documentazione di Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.it.png)

### Sicurezza della supply chain
La sicurezza della supply chain rimane fondamentale nell’era dell’AI, ma il concetto di supply chain si è ampliato. Oltre ai tradizionali pacchetti di codice, ora è necessario verificare e monitorare rigorosamente tutti i componenti legati all’AI, inclusi modelli di base, servizi di embeddings, provider di contesto e API di terze parti. Ognuno di questi può introdurre vulnerabilità o rischi se non gestito correttamente.

**Principali pratiche di sicurezza della supply chain per AI e MCP:**
- **Verificare tutti i componenti prima dell’integrazione:** Questo include non solo librerie open source, ma anche modelli AI, fonti di dati e API esterne. Controlla sempre provenienza, licenze e vulnerabilità note.
- **Mantenere pipeline di deployment sicure:** Usa pipeline CI/CD automatizzate con scansioni di sicurezza integrate per individuare problemi precocemente. Assicurati che solo artefatti affidabili vengano distribuiti in produzione.
- **Monitorare e auditare continuamente:** Implementa un monitoraggio costante di tutte le dipendenze, inclusi modelli e servizi dati, per rilevare nuove vulnerabilità o attacchi alla supply chain.
- **Applicare il principio del minimo privilegio e controlli di accesso:** Limita l’accesso a modelli, dati e servizi solo a quanto necessario per il funzionamento del tuo server MCP.
- **Rispondere rapidamente alle minacce:** Prevedi un processo per correggere o sostituire componenti compromessi e per ruotare segreti o credenziali in caso di violazioni.

[GitHub Advanced Security](https://github.com/security/advanced-security) offre funzionalità come secret scanning, dependency scanning e analisi CodeQL. Questi strumenti si integrano con [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) per aiutare i team a identificare e mitigare vulnerabilità sia nel codice che nei componenti della supply chain AI.

Microsoft applica inoltre internamente pratiche estese di sicurezza della supply chain per tutti i prodotti. Scopri di più in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Best practice di sicurezza consolidate per migliorare la postura di sicurezza della tua implementazione MCP

Ogni implementazione MCP eredita la postura di sicurezza esistente dell’ambiente della tua organizzazione su cui si basa, quindi quando consideri la sicurezza di MCP come componente dei tuoi sistemi AI complessivi, è consigliabile migliorare la postura di sicurezza generale già presente. I seguenti controlli di sicurezza consolidati sono particolarmente rilevanti:

-   Best practice di coding sicuro nella tua applicazione AI – proteggere contro [l’OWASP Top 10](https://owasp.org/www-project-top-ten/), l’[OWASP Top 10 per LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso di vault sicuri per segreti e token, implementazione di comunicazioni sicure end-to-end tra tutti i componenti dell’applicazione, ecc.
-   Hardening del server – usa MFA dove possibile, mantieni aggiornate le patch, integra il server con un provider di identità di terze parti per l’accesso, ecc.
-   Mantieni dispositivi, infrastruttura e applicazioni aggiornati con le patch
-   Monitoraggio della sicurezza – implementa logging e monitoraggio di un’applicazione AI (inclusi client/server MCP) e invia i log a un SIEM centrale per rilevare attività anomale
-   Architettura zero trust – isola i componenti tramite controlli di rete e identità in modo logico per minimizzare i movimenti laterali in caso di compromissione di un’app AI.

# Punti chiave

- I fondamenti della sicurezza restano critici: coding sicuro, minimo privilegio, verifica della supply chain e monitoraggio continuo sono essenziali per MCP e carichi di lavoro AI.
- MCP introduce nuovi rischi — come prompt injection, tool poisoning e permessi eccessivi — che richiedono controlli sia tradizionali che specifici per l’AI.
- Usa pratiche robuste di autenticazione, autorizzazione e gestione dei token, sfruttando provider di identità esterni come Microsoft Entra ID quando possibile.
- Proteggiti da prompt injection indiretta e tool poisoning validando i metadata degli strumenti, monitorando cambiamenti dinamici e utilizzando soluzioni come Microsoft Prompt Shields.
- Tratta tutti i componenti della tua supply chain AI — inclusi modelli, embeddings e provider di contesto — con la stessa attenzione riservata alle dipendenze di codice.
- Rimani aggiornato sulle specifiche MCP in evoluzione e contribuisci alla community per aiutare a definire standard sicuri.

# Risorse aggiuntive

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Successivo

Successivo: [Capitolo 3: Iniziare](../03-GettingStarted/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.