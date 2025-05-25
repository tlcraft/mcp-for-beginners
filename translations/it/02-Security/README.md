<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-20T23:05:51+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "it"
}
-->
# Pratiche di Sicurezza Migliori

Adottare il Model Context Protocol (MCP) introduce potenti nuove funzionalità nelle applicazioni basate su AI, ma porta con sé anche sfide di sicurezza uniche che vanno oltre i rischi tradizionali del software. Oltre a preoccupazioni consolidate come coding sicuro, principio del privilegio minimo e sicurezza della supply chain, MCP e i carichi di lavoro AI affrontano nuove minacce come prompt injection, tool poisoning e modifiche dinamiche agli strumenti. Questi rischi possono portare a esfiltrazione di dati, violazioni della privacy e comportamenti imprevisti del sistema se non gestiti correttamente.

Questa lezione esplora i rischi di sicurezza più rilevanti associati a MCP — inclusi autenticazione, autorizzazione, permessi eccessivi, prompt injection indiretti e vulnerabilità nella supply chain — e fornisce controlli pratici e best practice per mitigarli. Imparerai anche come sfruttare soluzioni Microsoft come Prompt Shields, Azure Content Safety e GitHub Advanced Security per rafforzare la tua implementazione MCP. Comprendendo e applicando questi controlli, potrai ridurre significativamente la probabilità di una violazione di sicurezza e garantire che i tuoi sistemi AI rimangano robusti e affidabili.

# Obiettivi di Apprendimento

Al termine di questa lezione, sarai in grado di:

- Identificare e spiegare i rischi di sicurezza unici introdotti dal Model Context Protocol (MCP), inclusi prompt injection, tool poisoning, permessi eccessivi e vulnerabilità della supply chain.
- Descrivere e applicare controlli efficaci per mitigare i rischi di sicurezza MCP, come autenticazione robusta, principio del privilegio minimo, gestione sicura dei token e verifica della supply chain.
- Comprendere e utilizzare soluzioni Microsoft come Prompt Shields, Azure Content Safety e GitHub Advanced Security per proteggere MCP e i carichi di lavoro AI.
- Riconoscere l’importanza di validare i metadata degli strumenti, monitorare le modifiche dinamiche e difendersi dagli attacchi di prompt injection indiretti.
- Integrare best practice di sicurezza consolidate — come coding sicuro, hardening dei server e architettura zero trust — nella tua implementazione MCP per ridurre la probabilità e l’impatto di violazioni di sicurezza.

# Controlli di sicurezza MCP

Qualsiasi sistema che ha accesso a risorse importanti presenta sfide di sicurezza implicite. Queste sfide possono generalmente essere affrontate attraverso l’applicazione corretta di controlli e concetti fondamentali di sicurezza. Poiché MCP è una specifica relativamente nuova, essa sta evolvendo rapidamente e, con il tempo, i controlli di sicurezza al suo interno matureranno, permettendo una migliore integrazione con architetture di sicurezza aziendali consolidate e best practice.

Una ricerca pubblicata nel [Microsoft Digital Defense Report](https://aka.ms/mddr) afferma che il 98% delle violazioni segnalate sarebbe prevenuto da una robusta igiene della sicurezza. La miglior protezione contro qualsiasi tipo di violazione è mantenere una solida igiene di base, seguendo le best practice di coding sicuro e sicurezza della supply chain — quelle pratiche collaudate che conosciamo già continuano a fare la differenza nella riduzione del rischio.

Vediamo alcune modalità per iniziare ad affrontare i rischi di sicurezza adottando MCP.

# Autenticazione server MCP (se la tua implementazione MCP è antecedente al 26 aprile 2025)

> **Note:** Le informazioni seguenti sono aggiornate al 26 aprile 2025. Il protocollo MCP è in continua evoluzione e le implementazioni future potrebbero introdurre nuovi schemi e controlli di autenticazione. Per aggiornamenti e indicazioni più recenti, consulta sempre la [Specificazione MCP](https://spec.modelcontextprotocol.io/) e il repository ufficiale [MCP GitHub](https://github.com/modelcontextprotocol).

### Descrizione del problema  
La specifica MCP originale presumeva che gli sviluppatori scrivessero un proprio server di autenticazione. Questo richiedeva conoscenze su OAuth e vincoli di sicurezza correlati. I server MCP agivano come OAuth 2.0 Authorization Server, gestendo direttamente l’autenticazione degli utenti invece di delegarla a un servizio esterno come Microsoft Entra ID. Dal 26 aprile 2025, un aggiornamento della specifica MCP consente ai server MCP di delegare l’autenticazione utente a un servizio esterno.

### Rischi
- Logica di autorizzazione mal configurata nel server MCP può portare all’esposizione di dati sensibili e a controlli di accesso errati.
- Furto di token OAuth sul server MCP locale. Se rubato, il token può essere usato per impersonare il server MCP e accedere a risorse e dati del servizio a cui il token OAuth si riferisce.

### Controlli mitiganti
- **Revisiona e rinforza la logica di autorizzazione:** Effettua un audit accurato dell’implementazione dell’autorizzazione del server MCP per garantire che solo utenti e client autorizzati possano accedere a risorse sensibili. Per indicazioni pratiche, consulta [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) e [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Applica pratiche sicure per i token:** Segui le [best practice Microsoft per la validazione e la durata dei token](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) per prevenire l’uso improprio e ridurre il rischio di replay o furto dei token.
- **Proteggi lo storage dei token:** Conserva sempre i token in modo sicuro e usa la crittografia per proteggerli a riposo e in transito. Per suggerimenti sull’implementazione, vedi [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permessi eccessivi per i server MCP

### Descrizione del problema  
I server MCP potrebbero aver ricevuto permessi eccessivi sul servizio o risorsa a cui accedono. Ad esempio, un server MCP che fa parte di un’applicazione AI per le vendite collegata a un archivio dati aziendale dovrebbe avere accesso limitato ai dati di vendita e non a tutti i file dell’archivio. Tornando al principio del privilegio minimo (uno dei principi di sicurezza più antichi), nessuna risorsa dovrebbe avere permessi superiori a quelli necessari per eseguire i compiti previsti. L’AI rende questa sfida più complessa, perché per garantire flessibilità può essere difficile definire con precisione i permessi necessari.

### Rischi  
- Concedere permessi eccessivi può permettere l’esfiltrazione o la modifica di dati che il server MCP non dovrebbe poter accedere. Questo può anche rappresentare un problema di privacy se i dati contengono informazioni personali identificabili (PII).

### Controlli mitiganti
- **Applica il principio del privilegio minimo:** Concedi al server MCP solo i permessi minimi necessari per svolgere i compiti richiesti. Rivedi e aggiorna regolarmente questi permessi per assicurarti che non superino il necessario. Per indicazioni dettagliate, consulta [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usa il controllo degli accessi basato sui ruoli (RBAC):** Assegna ruoli al server MCP strettamente limitati a risorse e azioni specifiche, evitando permessi ampi o non necessari.
- **Monitora e verifica i permessi:** Monitora continuamente l’uso dei permessi e verifica i log di accesso per individuare e correggere tempestivamente privilegi eccessivi o non utilizzati.

# Attacchi di prompt injection indiretti

### Descrizione del problema

Server MCP malevoli o compromessi possono introdurre rischi significativi esponendo dati dei clienti o abilitando azioni non intenzionali. Questi rischi sono particolarmente rilevanti nei carichi di lavoro AI e MCP, dove:

- **Prompt Injection Attacks:** Gli attaccanti inseriscono istruzioni malevole in prompt o contenuti esterni, inducendo il sistema AI a compiere azioni non previste o a divulgare dati sensibili. Approfondisci: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Gli attaccanti manipolano i metadata degli strumenti (come descrizioni o parametri) per influenzare il comportamento dell’AI, potenzialmente aggirando controlli di sicurezza o esfiltrando dati. Dettagli: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Istruzioni malevole sono inserite in documenti, pagine web o email, poi elaborate dall’AI, causando perdite o manipolazioni di dati.
- **Modifica dinamica degli strumenti (Rug Pulls):** Le definizioni degli strumenti possono essere modificate dopo l’approvazione dell’utente, introducendo nuovi comportamenti malevoli senza che l’utente ne sia consapevole.

Queste vulnerabilità sottolineano la necessità di validazione robusta, monitoraggio e controlli di sicurezza nell’integrare server MCP e strumenti nel tuo ambiente. Per approfondire, consulta i riferimenti indicati sopra.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.it.png)

**Indirect Prompt Injection** (nota anche come cross-domain prompt injection o XPIA) è una vulnerabilità critica nei sistemi di AI generativa, inclusi quelli che utilizzano il Model Context Protocol (MCP). In questo attacco, istruzioni malevole sono nascoste all’interno di contenuti esterni — come documenti, pagine web o email. Quando il sistema AI elabora questo contenuto, può interpretare le istruzioni incorporate come comandi legittimi dell’utente, causando azioni non volute come fuga di dati, generazione di contenuti dannosi o manipolazione delle interazioni utente. Per una spiegazione dettagliata ed esempi reali, vedi [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Una forma particolarmente pericolosa di questo attacco è il **Tool Poisoning**. Qui, gli attaccanti inseriscono istruzioni malevole nei metadata degli strumenti MCP (come descrizioni o parametri). Poiché i modelli di linguaggio di grandi dimensioni (LLM) si basano su questi metadata per decidere quali strumenti invocare, descrizioni compromesse possono ingannare il modello a eseguire chiamate non autorizzate o aggirare controlli di sicurezza. Queste manipolazioni sono spesso invisibili agli utenti finali ma possono essere interpretate e agite dal sistema AI. Il rischio è maggiore negli ambienti MCP ospitati, dove le definizioni degli strumenti possono essere aggiornate dopo l’approvazione dell’utente — uno scenario talvolta chiamato "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". In questi casi, uno strumento precedentemente sicuro può essere modificato per eseguire azioni malevole, come esfiltrare dati o alterare il comportamento del sistema, senza che l’utente ne sia a conoscenza. Per maggiori informazioni su questo vettore di attacco, vedi [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.it.png)

## Rischi
Azioni AI non intenzionali comportano vari rischi di sicurezza, inclusa l’esfiltrazione di dati e violazioni della privacy.

### Controlli mitiganti
### Uso di prompt shields per proteggersi dagli attacchi di Indirect Prompt Injection
-----------------------------------------------------------------------------

**AI Prompt Shields** sono una soluzione sviluppata da Microsoft per difendersi sia dagli attacchi diretti che indiretti di prompt injection. Aiutano tramite:

1.  **Rilevamento e filtraggio:** Prompt Shields utilizzano algoritmi avanzati di machine learning e natural language processing per identificare e filtrare istruzioni malevole incorporate in contenuti esterni, come documenti, pagine web o email.
    
2.  **Spotlighting:** Questa tecnica aiuta il sistema AI a distinguere tra istruzioni di sistema valide e input esterni potenzialmente non affidabili. Trasformando il testo in ingresso in modo che sia più rilevante per il modello, Spotlighting garantisce che l’AI possa identificare e ignorare meglio le istruzioni malevole.
    
3.  **Delimitatori e datamarking:** L’inclusione di delimitatori nel messaggio di sistema indica esplicitamente la posizione del testo in ingresso, aiutando il sistema AI a riconoscere e separare gli input utente da contenuti esterni potenzialmente dannosi. Il datamarking estende questo concetto usando marcatori speciali per evidenziare i confini tra dati affidabili e non affidabili.
    
4.  **Monitoraggio continuo e aggiornamenti:** Microsoft monitora e aggiorna costantemente Prompt Shields per affrontare nuove minacce e tecniche di attacco in evoluzione. Questo approccio proattivo garantisce che le difese rimangano efficaci.
    
5. **Integrazione con Azure Content Safety:** Prompt Shields fanno parte della suite più ampia Azure AI Content Safety, che fornisce ulteriori strumenti per rilevare tentativi di jailbreak, contenuti dannosi e altri rischi di sicurezza nelle applicazioni AI.

Puoi approfondire AI prompt shields nella [documentazione Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.it.png)

### Sicurezza della supply chain

La sicurezza della supply chain rimane fondamentale nell’era AI, ma l’ambito di ciò che costituisce la tua supply chain si è ampliato. Oltre ai tradizionali pacchetti di codice, ora devi verificare e monitorare rigorosamente tutti i componenti legati all’AI, inclusi modelli di base, servizi di embeddings, provider di contesto e API di terze parti. Ognuno di questi può introdurre vulnerabilità o rischi se non gestito correttamente.

**Pratiche chiave per la sicurezza della supply chain in AI e MCP:**
- **Verifica tutti i componenti prima dell’integrazione:** Questo include non solo librerie open-source, ma anche modelli AI, fonti dati e API esterne. Controlla sempre provenienza, licenze e vulnerabilità note.
- **Mantieni pipeline di deployment sicure:** Usa pipeline CI/CD automatizzate con scansione di sicurezza integrata per individuare problemi precocemente. Assicurati che solo artefatti affidabili vengano distribuiti in produzione.
- **Monitora e verifica continuamente:** Implementa un monitoraggio costante di tutte le dipendenze, inclusi modelli e servizi dati, per rilevare nuove vulnerabilità o attacchi alla supply chain.
- **Applica il principio del privilegio minimo e controlli di accesso:** Limita l’accesso a modelli, dati e servizi solo a quanto necessario per il funzionamento del server MCP.
- **Rispondi rapidamente alle minacce:** Prevedi un processo per patchare o sostituire componenti compromessi e per ruotare segreti o credenziali in caso di violazioni.

[GitHub Advanced Security](https://github.com/security/advanced-security) offre funzionalità come scansione di segreti, scansione delle dipendenze e analisi CodeQL. Questi strumenti si integrano con [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) e [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) per aiutare i team a identificare e mitigare vulnerabilità sia nel codice che nei componenti della supply chain AI.

Microsoft applica inoltre pratiche estese di sicurezza della supply chain internamente per tutti i prodotti. Scopri di più in [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Best practice di sicurezza consolidate che miglioreranno la postura di sicurezza della tua implementazione MCP

Ogni implementazione MCP eredita la postura di sicurezza esistente dell’ambiente organizzativo su cui è costruita, quindi nel considerare la sicurezza di MCP come componente dei tuoi sistemi AI complessivi, è consigliabile migliorare la postura di sicurezza generale già presente. I seguenti controlli di sicurezza consolidati sono particolarmente rilevanti:

- Best practice di coding sicuro nella tua applicazione AI — protezione contro [l’OWASP Top 10](https://owasp.org/www-project-top-ten/), l’[OWASP Top 10 per LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso di vault sicuri per segreti e token, implementazione di comunicazioni sicure end-to-end tra tutti i componenti dell’applicazione, ecc.
- Hardening dei server — utilizzo di MFA dove possibile, mantenimento degli aggiornamenti di sicurezza, integrazione del server con un provider di identità terzo per l’accesso, ecc.
- Mantenere dispositivi, infrastrutture e applicazioni aggiornati con patch
- Monitoraggio della sicurezza — implementazione di logging e monitoraggio di un’applicazione AI (inclusi client/server MCP) e invio di questi log a un SIEM centrale per rilevare attività anomale
- Architettura zero trust — isolamento dei componenti tramite controlli di rete e identità in modo logico per minimizzare i movimenti laterali in caso di compromissione dell’applicazione AI.

# Punti Chiave

- I fondamenti della sicurezza restano critici: coding sicuro, principio del privilegio minimo, verifica della supply chain e monitoraggio continuo sono essenziali per MCP e carichi di lavoro AI.
- MCP introduce nuovi rischi — come prompt injection, tool poisoning e permessi eccessivi — che richiedono controlli sia tradizionali che specifici per l’AI.
- Usa pratiche robuste di autenticazione,
- [OWASP Top 10 per LLM](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [Il percorso per mettere in sicurezza la catena di fornitura software in Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Accesso minimo privilegiato sicuro (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best practice per la convalida e la durata dei token](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Usa l’archiviazione sicura dei token e cifra i token (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management come gateway di autenticazione per MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Usare Microsoft Entra ID per autenticarsi con i server MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Successivo

Successivo: [Capitolo 3: Per iniziare](/03-GettingStarted/README.md)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per l’accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o inesattezze. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali incomprensioni o interpretazioni errate derivanti dall’uso di questa traduzione.