<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:54:02+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "it"
}
-->
# Best Practice di Sicurezza MCP

Quando lavori con i server MCP, segui queste best practice di sicurezza per proteggere i tuoi dati, l'infrastruttura e gli utenti:

1. **Validazione degli Input**: Valida e sanifica sempre gli input per prevenire attacchi di injection e problemi di confused deputy.
2. **Controllo degli Accessi**: Implementa un’autenticazione e un’autorizzazione adeguate per il tuo server MCP con permessi dettagliati.
3. **Comunicazione Sicura**: Usa HTTPS/TLS per tutte le comunicazioni con il server MCP e considera l’aggiunta di ulteriori livelli di crittografia per i dati sensibili.
4. **Limitazione della Frequenza**: Implementa meccanismi di rate limiting per prevenire abusi, attacchi DoS e gestire il consumo delle risorse.
5. **Logging e Monitoraggio**: Monitora il server MCP per attività sospette e implementa audit trail completi.
6. **Archiviazione Sicura**: Proteggi i dati sensibili e le credenziali con una crittografia adeguata a riposo.
7. **Gestione dei Token**: Previeni vulnerabilità di token passthrough validando e sanificando tutti gli input e output dei modelli.
8. **Gestione delle Sessioni**: Implementa una gestione sicura delle sessioni per prevenire attacchi di session hijacking e fixation.
9. **Sandboxing dell’Esecuzione degli Strumenti**: Esegui gli strumenti in ambienti isolati per evitare movimenti laterali in caso di compromissione.
10. **Audit di Sicurezza Regolari**: Effettua revisioni periodiche della sicurezza delle implementazioni MCP e delle dipendenze.
11. **Validazione dei Prompt**: Scansiona e filtra sia i prompt in input che in output per prevenire attacchi di prompt injection.
12. **Delegazione dell’Autenticazione**: Usa provider di identità consolidati invece di implementare autenticazioni personalizzate.
13. **Scoping dei Permessi**: Implementa permessi granulari per ogni strumento e risorsa seguendo il principio del minimo privilegio.
14. **Minimizzazione dei Dati**: Esponi solo i dati strettamente necessari per ogni operazione per ridurre la superficie di rischio.
15. **Scansione Automatica delle Vulnerabilità**: Esegui regolarmente scansioni dei server MCP e delle dipendenze per vulnerabilità note.

## Risorse di Supporto per le Best Practice di Sicurezza MCP

### Validazione degli Input
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Prevenire il Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Implementazione Azure Content Safety](./azure-content-safety-implementation.md)

### Controllo degli Accessi
- [Specifiche di Autorizzazione MCP](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Uso di Microsoft Entra ID con i Server MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management come Gateway di Autenticazione per MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Comunicazione Sicura
- [Best Practice per Transport Layer Security (TLS)](https://learn.microsoft.com/security/engineering/solving-tls)
- [Linee Guida per la Sicurezza del Trasporto MCP](https://modelcontextprotocol.io/docs/concepts/transports)
- [Crittografia End-to-End per Carichi di Lavoro AI](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Limitazione della Frequenza
- [Pattern di Rate Limiting per API](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementazione del Rate Limiting con Token Bucket](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Logging e Monitoraggio
- [Logging Centralizzato per Sistemi AI](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Best Practice per Audit Logging](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor per Carichi di Lavoro AI](https://learn.microsoft.com/azure/azure-monitor/overview)

### Archiviazione Sicura
- [Azure Key Vault per l’Archiviazione delle Credenziali](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Crittografia dei Dati Sensibili a Riposo](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Uso di Archiviazione Sicura per Token e Crittografia dei Token](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Gestione dei Token
- [Best Practice JWT (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [Best Practice di Sicurezza OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practice per la Validazione e la Durata dei Token](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Gestione delle Sessioni
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [Linee Guida per la Gestione delle Sessioni MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Pattern di Progettazione per Sessioni Sicure](https://learn.microsoft.com/security/engineering/session-security)

### Sandboxing dell’Esecuzione degli Strumenti
- [Best Practice per la Sicurezza dei Container](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementazione dell’Isolamento dei Processi](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Limiti di Risorse per Applicazioni Containerizzate](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Audit di Sicurezza Regolari
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Linee Guida per la Revisione del Codice di Sicurezza](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validazione dei Prompt
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety per AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Prevenzione del Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Delegazione dell’Autenticazione
- [Integrazione Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 per i Servizi MCP](https://learn.microsoft.com/security/engineering/solving-oauth)
- [Controlli di Sicurezza MCP 2025](./mcp-security-controls-2025.md)

### Scoping dei Permessi
- [Accesso Sicuro con Minimo Privilegio](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Progettazione RBAC (Role-Based Access Control)](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Autorizzazione Specifica per Strumenti in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimizzazione dei Dati
- [Protezione dei Dati by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [Best Practice per la Privacy dei Dati AI](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementazione di Tecnologie per la Privacy](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Scansione Automatica delle Vulnerabilità
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Implementazione Pipeline DevSecOps](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Validazione Continua della Sicurezza](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Disclaimer**:  
Questo documento è stato tradotto utilizzando il servizio di traduzione automatica [Co-op Translator](https://github.com/Azure/co-op-translator). Pur impegnandoci per garantire accuratezza, si prega di notare che le traduzioni automatiche possono contenere errori o imprecisioni. Il documento originale nella sua lingua nativa deve essere considerato la fonte autorevole. Per informazioni critiche, si raccomanda una traduzione professionale effettuata da un umano. Non ci assumiamo alcuna responsabilità per eventuali malintesi o interpretazioni errate derivanti dall’uso di questa traduzione.