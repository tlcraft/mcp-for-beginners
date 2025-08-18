<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0c243c6189393ed7468e470ef2090049",
  "translation_date": "2025-08-18T15:07:04+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "cs"
}
-->
# MCP Bezpečnostní Kontroly - Aktualizace srpen 2025

> **Aktuální standard**: Tento dokument odráží bezpečnostní požadavky [MCP Specifikace 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) a oficiální [MCP Bezpečnostní Nejlepší Praktiky](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices).

Model Context Protocol (MCP) se výrazně vyvinul s vylepšenými bezpečnostními kontrolami, které řeší jak tradiční softwarovou bezpečnost, tak hrozby specifické pro umělou inteligenci. Tento dokument poskytuje komplexní bezpečnostní kontroly pro bezpečné implementace MCP k srpnu 2025.

## **POVINNÉ Bezpečnostní Požadavky**

### **Kritické Zákazy ze Specifikace MCP:**

> **ZAKÁZÁNO**: MCP servery **NESMÍ** přijímat žádné tokeny, které nebyly výslovně vydány pro MCP server  
>
> **ZAKÁZÁNO**: MCP servery **NESMÍ** používat relace pro autentizaci  
>
> **POVINNÉ**: MCP servery implementující autorizaci **MUSÍ** ověřovat VŠECHNY příchozí požadavky  
>
> **POVINNÉ**: MCP proxy servery používající statické ID klientů **MUSÍ** získat souhlas uživatele pro každého dynamicky registrovaného klienta  

---

## 1. **Kontroly Autentizace a Autorizace**

### **Integrace Externího Poskytovatele Identit**

**Aktuální MCP Standard (2025-06-18)** umožňuje MCP serverům delegovat autentizaci na externí poskytovatele identit, což představuje významné zlepšení bezpečnosti:

**Bezpečnostní Výhody:**
1. **Eliminace Rizik Vlastní Autentizace**: Snižuje povrch zranitelnosti tím, že se vyhýbá vlastním implementacím autentizace  
2. **Podniková Bezpečnostní Úroveň**: Využívá zavedené poskytovatele identit, jako je Microsoft Entra ID, s pokročilými bezpečnostními funkcemi  
3. **Centralizovaná Správa Identit**: Zjednodušuje správu životního cyklu uživatelů, kontrolu přístupu a auditování souladu  
4. **Vícefaktorová Autentizace**: Přebírá schopnosti MFA od podnikových poskytovatelů identit  
5. **Podmíněné Přístupové Politiky**: Využívá přístupy založené na rizicích a adaptivní autentizaci  

**Požadavky na Implementaci:**
- **Ověření Audience Tokenu**: Ověřte, že všechny tokeny byly výslovně vydány pro MCP server  
- **Ověření Vydavatele**: Ověřte, že vydavatel tokenu odpovídá očekávanému poskytovateli identit  
- **Ověření Podpisu**: Kryptografické ověření integrity tokenu  
- **Vynucení Expirace**: Přísné dodržování časových limitů platnosti tokenu  
- **Ověření Rozsahu**: Zajistěte, že tokeny obsahují odpovídající oprávnění pro požadované operace  

### **Bezpečnost Logiky Autorizace**

**Kritické Kontroly:**
- **Komplexní Audity Autorizace**: Pravidelné bezpečnostní přezkumy všech rozhodovacích bodů autorizace  
- **Výchozí Bezpečné Nastavení**: Odepření přístupu, pokud logika autorizace nemůže učinit jednoznačné rozhodnutí  
- **Hranice Oprávnění**: Jasné oddělení mezi různými úrovněmi oprávnění a přístupu k prostředkům  
- **Auditní Logování**: Kompletní zaznamenávání všech rozhodnutí autorizace pro bezpečnostní monitorování  
- **Pravidelné Přezkumy Přístupu**: Periodická validace uživatelských oprávnění a přiřazení privilegií  

## 2. **Bezpečnost Tokenů a Kontroly proti Přeposílání**

### **Prevence Přeposílání Tokenů**

**Přeposílání tokenů je výslovně zakázáno** ve Specifikaci Autorizace MCP kvůli kritickým bezpečnostním rizikům:

**Řešená Bezpečnostní Rizika:**
- **Obcházení Kontrol**: Obchází základní bezpečnostní kontroly, jako je omezení rychlosti, validace požadavků a monitorování provozu  
- **Narušení Odpovědnosti**: Ztěžuje identifikaci klientů, což narušuje auditní stopy a vyšetřování incidentů  
- **Proxy Exfiltrace**: Umožňuje škodlivým aktérům používat servery jako proxy pro neoprávněný přístup k datům  
- **Porušení Důvěryhodných Hranic**: Narušuje předpoklady o původu tokenů u downstream služeb  
- **Laterální Pohyb**: Kompromitované tokeny napříč více službami umožňují širší expanzi útoků  

**Kontroly Implementace:**
```yaml
Token Validation Requirements:
  audience_validation: MANDATORY
  issuer_verification: MANDATORY  
  signature_check: MANDATORY
  expiration_enforcement: MANDATORY
  scope_validation: MANDATORY
  
Token Lifecycle Management:
  rotation_frequency: "Short-lived tokens preferred"
  secure_storage: "Azure Key Vault or equivalent"
  transmission_security: "TLS 1.3 minimum"
  replay_protection: "Implemented via nonce/timestamp"
```

### **Bezpečné Vzory Správy Tokenů**

**Nejlepší Praktiky:**
- **Krátkodobé Tokeny**: Minimalizace expozičního okna častou rotací tokenů  
- **Vydávání na Poslední Chvíli**: Vydávání tokenů pouze tehdy, když jsou potřeba pro konkrétní operace  
- **Bezpečné Ukládání**: Použití hardwarových bezpečnostních modulů (HSM) nebo bezpečných úložišť klíčů  
- **Vázání Tokenů**: Vázání tokenů na konkrétní klienty, relace nebo operace, pokud je to možné  
- **Monitorování a Upozorňování**: Detekce zneužití tokenů nebo neoprávněných přístupových vzorců v reálném čase  

## 3. **Kontroly Bezpečnosti Relací**

### **Prevence Únosu Relací**

**Řešené Útočné Vektory:**
- **Únos Relace Pomocí Vkládání**: Škodlivé události vložené do sdíleného stavu relace  
- **Impersonace Relace**: Neoprávněné použití odcizených ID relací k obcházení autentizace  
- **Útoky na Obnovitelné Streamy**: Zneužití obnovení serverem odesílaných událostí pro vkládání škodlivého obsahu  

**Povinné Kontroly Relací:**
```yaml
Session ID Generation:
  randomness_source: "Cryptographically secure RNG"
  entropy_bits: 128 # Minimum recommended
  format: "Base64url encoded"
  predictability: "MUST be non-deterministic"

Session Binding:
  user_binding: "REQUIRED - <user_id>:<session_id>"
  additional_identifiers: "Device fingerprint, IP validation"
  context_binding: "Request origin, user agent validation"
  
Session Lifecycle:
  expiration: "Configurable timeout policies"
  rotation: "After privilege escalation events"
  invalidation: "Immediate on security events"
  cleanup: "Automated expired session removal"
```

**Transportní Bezpečnost:**
- **Vynucení HTTPS**: Veškerá komunikace relace přes TLS 1.3  
- **Atributy Bezpečných Cookies**: HttpOnly, Secure, SameSite=Strict  
- **Pinning Certifikátů**: Pro kritická spojení k prevenci MITM útoků  

### **Stavové vs Bezstavové Úvahy**

**Pro Stavové Implementace:**
- Sdílený stav relace vyžaduje dodatečnou ochranu proti útokům vkládání  
- Správa relací založená na frontách potřebuje ověření integrity  
- Více instancí serveru vyžaduje bezpečnou synchronizaci stavu relace  

**Pro Bezstavové Implementace:**
- Správa relací na bázi JWT nebo podobných tokenů  
- Kryptografické ověření integrity stavu relace  
- Snížený povrch útoku, ale vyžaduje robustní validaci tokenů  

## 4. **Bezpečnostní Kontroly Specifické pro AI**

### **Obrana proti Vkládání Promptů**

**Integrace Microsoft Prompt Shields:**
```yaml
Detection Mechanisms:
  - "Advanced ML-based instruction detection"
  - "Contextual analysis of external content"
  - "Real-time threat pattern recognition"
  
Protection Techniques:
  - "Spotlighting trusted vs untrusted content"
  - "Delimiter systems for content boundaries"  
  - "Data marking for content source identification"
  
Integration Points:
  - "Azure Content Safety service"
  - "Real-time content filtering"
  - "Threat intelligence updates"
```

**Kontroly Implementace:**
- **Sanitizace Vstupů**: Komplexní validace a filtrování všech uživatelských vstupů  
- **Definice Hranic Obsahu**: Jasné oddělení mezi systémovými instrukcemi a uživatelským obsahem  
- **Hierarchie Instrukcí**: Správná precedence pravidel pro konfliktní instrukce  
- **Monitorování Výstupů**: Detekce potenciálně škodlivých nebo manipulovaných výstupů  

### **Prevence Otravy Nástrojů**

**Rámec Bezpečnosti Nástrojů:**
```yaml
Tool Definition Protection:
  validation:
    - "Schema validation against expected formats"
    - "Content analysis for malicious instructions" 
    - "Parameter injection detection"
    - "Hidden instruction identification"
  
  integrity_verification:
    - "Cryptographic hashing of tool definitions"
    - "Digital signatures for tool packages"
    - "Version control with change auditing"
    - "Tamper detection mechanisms"
  
  monitoring:
    - "Real-time change detection"
    - "Behavioral analysis of tool usage"
    - "Anomaly detection for execution patterns"
    - "Automated alerting for suspicious modifications"
```

**Dynamická Správa Nástrojů:**
- **Schvalovací Procesy**: Výslovný souhlas uživatele pro změny nástrojů  
- **Možnosti Vrácení Změn**: Schopnost vrátit se k předchozím verzím nástrojů  
- **Audit Změn**: Kompletní historie úprav definic nástrojů  
- **Hodnocení Rizik**: Automatizované vyhodnocení bezpečnostního stavu nástrojů  

## 5. **Prevence Útoků na Zmateného Zástupce**

### **Bezpečnost OAuth Proxy**

**Kontroly Prevence Útoků:**
```yaml
Client Registration:
  static_client_protection:
    - "Explicit user consent for dynamic registration"
    - "Consent bypass prevention mechanisms"  
    - "Cookie-based consent validation"
    - "Redirect URI strict validation"
    
  authorization_flow:
    - "PKCE implementation (OAuth 2.1)"
    - "State parameter validation"
    - "Authorization code binding"
    - "Nonce verification for ID tokens"
```

**Požadavky na Implementaci:**
- **Ověření Souhlasu Uživatelů**: Nikdy nevynechávejte obrazovky souhlasu pro dynamickou registraci klientů  
- **Validace Přesměrovacích URI**: Přísná validace destinací přesměrování na základě whitelistu  
- **Ochrana Autorizačních Kódů**: Krátkodobé kódy s vynucením jednorázového použití  
- **Ověření Identity Klienta**: Robustní validace přihlašovacích údajů a metadat klienta  

## 6. **Bezpečnost Spouštění Nástrojů**

### **Sandboxing a Izolace**

**Izolace na Bázi Kontejnerů:**
```yaml
Execution Environment:
  containerization: "Docker/Podman with security profiles"
  resource_limits:
    cpu: "Configurable CPU quotas"
    memory: "Memory usage restrictions"
    disk: "Storage access limitations"
    network: "Network policy enforcement"
  
  privilege_restrictions:
    user_context: "Non-root execution mandatory"
    capability_dropping: "Remove unnecessary Linux capabilities"
    syscall_filtering: "Seccomp profiles for syscall restriction"
    filesystem: "Read-only root with minimal writable areas"
```

**Izolace Procesů:**
- **Oddělené Kontexty Procesů**: Každé spuštění nástroje v izolovaném procesním prostoru  
- **Meziprocesová Komunikace**: Bezpečné mechanismy IPC s validací  
- **Monitorování Procesů**: Analýza chování za běhu a detekce anomálií  
- **Vynucení Zdroje**: Tvrdé limity na CPU, paměť a I/O operace  

### **Implementace Minimálních Práv**

**Správa Oprávnění:**
```yaml
Access Control:
  file_system:
    - "Minimal required directory access"
    - "Read-only access where possible"
    - "Temporary file cleanup automation"
    
  network_access:
    - "Explicit allowlist for external connections"
    - "DNS resolution restrictions" 
    - "Port access limitations"
    - "SSL/TLS certificate validation"
  
  system_resources:
    - "No administrative privilege elevation"
    - "Limited system call access"
    - "No hardware device access"
    - "Restricted environment variable access"
```

## 7. **Kontroly Bezpečnosti Dodavatelského Řetězce**

### **Ověření Závislostí**

**Komplexní Bezpečnost Komponent:**
```yaml
Software Dependencies:
  scanning: 
    - "Automated vulnerability scanning (GitHub Advanced Security)"
    - "License compliance verification"
    - "Known vulnerability database checks"
    - "Malware detection and analysis"
  
  verification:
    - "Package signature verification"
    - "Checksum validation"
    - "Provenance attestation"
    - "Software Bill of Materials (SBOM)"

AI Components:
  model_verification:
    - "Model provenance validation"
    - "Training data source verification" 
    - "Model behavior testing"
    - "Adversarial robustness assessment"
  
  service_validation:
    - "Third-party API security assessment"
    - "Service level agreement review"
    - "Data handling compliance verification"
    - "Incident response capability evaluation"
```

### **Průběžné Monitorování**

**Detekce Hrozeb v Dodavatelském Řetězci:**
- **Monitorování Zdraví Závislostí**: Průběžné hodnocení všech závislostí na bezpečnostní problémy  
- **Integrace Zpravodajství o Hrozbách**: Aktualizace v reálném čase o vznikajících hrozbách v dodavatelském řetězci  
- **Analýza Chování**: Detekce neobvyklého chování externích komponent  
- **Automatizovaná Odezva**: Okamžité omezení kompromitovaných komponent  

## 8. **Kontroly Monitorování a Detekce**

### **Bezpečnostní Informace a Správa Událostí (SIEM)**

**Komplexní Strategie Logování:**
```yaml
Authentication Events:
  - "All authentication attempts (success/failure)"
  - "Token issuance and validation events"
  - "Session creation, modification, termination"
  - "Authorization decisions and policy evaluations"

Tool Execution:
  - "Tool invocation details and parameters"
  - "Execution duration and resource usage"
  - "Output generation and content analysis"
  - "Error conditions and exception handling"

Security Events:
  - "Potential prompt injection attempts"
  - "Tool poisoning detection events"
  - "Session hijacking indicators"
  - "Unusual access patterns and anomalies"
```

### **Detekce Hrozeb v Reálném Čase**

**Analýza Chování:**
- **Analýza Chování Uživatelů (UBA)**: Detekce neobvyklých vzorců přístupu uživatelů  
- **Analýza Chování Entit (EBA)**: Monitorování chování MCP serveru a nástrojů  
- **Detekce Anomálií Pomocí Strojového Učení**: Identifikace bezpečnostních hrozeb pomocí AI  
- **Korelace Zpravodajství o Hrozbách**: Porovnání pozorovaných aktivit s známými vzory útoků  

## 9. **Reakce na Incidenty a Obnova**

### **Automatizované Reakční Schopnosti**

**Okamžité Akce:**
```yaml
Threat Containment:
  session_management:
    - "Immediate session termination"
    - "Account lockout procedures"
    - "Access privilege revocation"
  
  system_isolation:
    - "Network segmentation activation"
    - "Service isolation protocols"
    - "Communication channel restriction"

Recovery Procedures:
  credential_rotation:
    - "Automated token refresh"
    - "API key regeneration"
    - "Certificate renewal"
  
  system_restoration:
    - "Clean state restoration"
    - "Configuration rollback"
    - "Service restart procedures"
```

### **Forenzní Schopnosti**

**Podpora Vyšetřování:**
- **Zachování Auditní Stopy**: Neměnné logování s kryptografickou integritou  
- **Sběr Důkazů**: Automatizované shromažďování relevantních bezpečnostních artefaktů  
- **Rekonstrukce Časové Osy**: Detailní sekvence událostí vedoucích k bezpečnostním incidentům  
- **Hodnocení Dopadu**: Vyhodnocení rozsahu kompromitace a expozice dat  

## **Klíčové Principy Bezpečnostní Architektury**

### **Obrana ve Hloubce**
- **Více Vrstvová Bezpečnost**: Žádný jediný bod selhání v bezpečnostní architektuře  
- **Redundantní Kontroly**: Překrývající se bezpečnostní opatření pro kritické funkce  
- **Mechanismy Bezpečného Selhání**: Bezpečné výchozí nastavení při chybách nebo útocích  

### **Implementace Zero Trust**
- **Nikdy Nedůvěřuj, Vždy Ověřuj**: Průběžná validace všech entit a požadavků  
- **Princip Minimálních Práv**: Minimální přístupová práva pro všechny komponenty  
- **Mikrosegmentace**: Granulární síťové a přístupové kontroly  

### **Průběžný Vývoj Bezpečnosti**
- **Adaptace na Hrozby**: Pravidelné aktualizace pro řešení vznikajících hrozeb  
- **Efektivita Bezpečnostních Kontrol**: Průběžné hodnocení a zlepšování kontrol  
- **Soulad se Specifikacemi**: Sjednocení s vyvíjejícími se bezpečnostními standardy MCP  

---

## **Zdroje pro Implementaci**

### **Oficiální Dokumentace MCP**
- [MCP Specifikace (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)  
- [MCP Bezpečnostní Nejlepší Praktiky](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)  
- [MCP Specifikace Autorizace](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)  

### **Microsoft Bezpečnostní Řešení**
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [GitHub Advanced Security](https://github.com/security/advanced-security)  
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/)  

### **Bezpečnostní Standardy**
- [OAuth 2.0 Bezpečnostní Nejlepší Praktiky (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [OWASP Top 10 pro Velké Jazykové Modely](https://genai.owasp.org/)  
- [NIST Rámec Kybernetické Bezpečnosti](https://www.nist.gov/cyberframework)  

---

> **Důležité**: Tyto bezpečnostní kontroly odrážejí aktuální specifikaci MCP (2025-06-18). Vždy ověřujte podle nejnovější [oficiální dokumentace](https://spec.modelcontextprotocol.io/), protože standardy se rychle vyvíjejí.

**Prohlášení:**  
Tento dokument byl přeložen pomocí služby pro automatický překlad [Co-op Translator](https://github.com/Azure/co-op-translator). Ačkoli se snažíme o přesnost, mějte na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho původním jazyce by měl být považován za autoritativní zdroj. Pro důležité informace doporučujeme profesionální lidský překlad. Neodpovídáme za žádná nedorozumění nebo nesprávné interpretace vyplývající z použití tohoto překladu.