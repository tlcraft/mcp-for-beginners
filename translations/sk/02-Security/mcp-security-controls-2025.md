<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0c243c6189393ed7468e470ef2090049",
  "translation_date": "2025-08-18T20:22:55+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "sk"
}
-->
# MCP Bezpečnostné Kontroly - Aktualizácia August 2025

> **Aktuálny Štandard**: Tento dokument odráža bezpečnostné požiadavky [MCP Špecifikácie 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) a oficiálne [MCP Bezpečnostné Najlepšie Praktiky](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices).

Model Context Protocol (MCP) sa výrazne vyvinul s vylepšenými bezpečnostnými kontrolami, ktoré riešia tradičné softvérové bezpečnostné hrozby aj hrozby špecifické pre AI. Tento dokument poskytuje komplexné bezpečnostné kontroly pre bezpečné implementácie MCP k augustu 2025.

## **POVINNÉ Bezpečnostné Požiadavky**

### **Kritické Zákazy zo Špecifikácie MCP:**

> **ZAKÁZANÉ**: MCP servery **NESMÚ** akceptovať žiadne tokeny, ktoré neboli výslovne vydané pre MCP server  
>
> **ZAKÁZANÉ**: MCP servery **NESMÚ** používať relácie na autentifikáciu  
>
> **POVINNÉ**: MCP servery implementujúce autorizáciu **MUSIA** overiť VŠETKY prichádzajúce požiadavky  
>
> **POVINNÉ**: MCP proxy servery používajúce statické ID klientov **MUSIA** získať súhlas používateľa pre každého dynamicky registrovaného klienta  

---

## 1. **Kontroly Autentifikácie a Autorizácie**

### **Integrácia Externého Poskytovateľa Identity**

**Aktuálny MCP Štandard (2025-06-18)** umožňuje MCP serverom delegovať autentifikáciu na externých poskytovateľov identity, čo predstavuje významné zlepšenie bezpečnosti:

**Bezpečnostné Výhody:**
1. **Eliminácia Rizík Vlastnej Autentifikácie**: Znižuje povrch zraniteľnosti tým, že sa vyhýba vlastným implementáciám autentifikácie  
2. **Bezpečnosť na Úrovni Podnikov**: Využíva zavedených poskytovateľov identity, ako je Microsoft Entra ID, s pokročilými bezpečnostnými funkciami  
3. **Centralizované Riadenie Identity**: Zjednodušuje správu životného cyklu používateľov, kontrolu prístupu a auditovanie súladu  
4. **Viacfaktorová Autentifikácia**: Preberá schopnosti MFA od podnikových poskytovateľov identity  
5. **Podmienené Politiky Prístupu**: Využíva prístupy založené na rizikách a adaptívnu autentifikáciu  

**Požiadavky na Implementáciu:**
- **Validácia Publikum Tokenu**: Overte, že všetky tokeny sú výslovne vydané pre MCP server  
- **Overenie Vydavateľa**: Overte, že vydavateľ tokenu zodpovedá očakávanému poskytovateľovi identity  
- **Overenie Podpisu**: Kryptografické overenie integrity tokenu  
- **Vynucovanie Expirácie**: Prísne vynucovanie časových limitov platnosti tokenu  
- **Validácia Rozsahu**: Zabezpečte, aby tokeny obsahovali vhodné povolenia pre požadované operácie  

### **Bezpečnosť Logiky Autorizácie**

**Kritické Kontroly:**
- **Komplexné Audity Autorizácie**: Pravidelné bezpečnostné kontroly všetkých rozhodovacích bodov autorizácie  
- **Predvolené Bezpečné Nastavenia**: Odmietnutie prístupu, keď logika autorizácie nemôže urobiť jednoznačné rozhodnutie  
- **Hranice Povolení**: Jasné oddelenie rôznych úrovní privilégií a prístupu k zdrojom  
- **Auditovanie Logov**: Kompletné zaznamenávanie všetkých rozhodnutí o autorizácii pre bezpečnostné monitorovanie  
- **Pravidelné Kontroly Prístupu**: Periodická validácia povolení používateľov a priradení privilégií  

## 2. **Bezpečnosť Tokenov a Kontroly proti Prenosom**

### **Prevencia Prenosu Tokenov**

**Prenos tokenov je výslovne zakázaný** v MCP Špecifikácii Autorizácie kvôli kritickým bezpečnostným rizikám:

**Riziká, ktoré sa Riešia:**
- **Obchádzanie Kontrol**: Obchádza základné bezpečnostné kontroly, ako je obmedzovanie rýchlosti, validácia požiadaviek a monitorovanie prevádzky  
- **Nedostatok Zodpovednosti**: Znefunkčňuje identifikáciu klientov, čo narúša auditné stopy a vyšetrovanie incidentov  
- **Proxy Exfiltrácia**: Umožňuje škodlivým aktérom používať servery ako proxy na neoprávnený prístup k údajom  
- **Porušenie Dôveryhodných Hraníc**: Narúša predpoklady dôvery downstream služieb o pôvode tokenov  
- **Laterálny Pohyb**: Kompromitované tokeny medzi viacerými službami umožňujú širšiu expanziu útokov  

**Kontroly Implementácie:**
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

### **Vzory Bezpečného Riadenia Tokenov**

**Najlepšie Praktiky:**
- **Krátkodobé Tokeny**: Minimalizujte okno expozície častou rotáciou tokenov  
- **Vydávanie na Požiadanie**: Vydávajte tokeny iba vtedy, keď sú potrebné pre konkrétne operácie  
- **Bezpečné Ukladanie**: Používajte hardvérové bezpečnostné moduly (HSM) alebo bezpečné úložiská kľúčov  
- **Väzba Tokenov**: Viažte tokeny na konkrétnych klientov, relácie alebo operácie, kde je to možné  
- **Monitorovanie a Upozorňovanie**: Detekcia v reálnom čase na zneužitie tokenov alebo neoprávnené vzory prístupu  

## 3. **Kontroly Bezpečnosti Relácií**

### **Prevencia Únosu Relácií**

**Adresované Útoky:**
- **Únos Relácie cez Vstrekovanie**: Škodlivé udalosti vložené do zdieľaného stavu relácie  
- **Impersonácia Relácie**: Neoprávnené použitie ukradnutých ID relácií na obídenie autentifikácie  
- **Útoky na Obnoviteľné Prúdy**: Zneužitie obnovenia udalostí odosielaných serverom na vloženie škodlivého obsahu  

**Povinné Kontroly Relácií:**
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

**Transportná Bezpečnosť:**
- **Vynucovanie HTTPS**: Všetka komunikácia relácie cez TLS 1.3  
- **Atribúty Bezpečných Cookies**: HttpOnly, Secure, SameSite=Strict  
- **Pinning Certifikátov**: Pre kritické spojenia na prevenciu MITM útokov  

### **Úvahy o Stavových a Bezstavových Implementáciách**

**Pre Stavové Implementácie:**
- Zdieľaný stav relácie vyžaduje dodatočnú ochranu proti útokom na vstrekovanie  
- Riadenie relácií na báze frontov potrebuje overenie integrity  
- Viacero inštancií servera vyžaduje bezpečnú synchronizáciu stavu relácie  

**Pre Bezstavové Implementácie:**
- Riadenie relácií na báze tokenov, ako je JWT  
- Kryptografické overenie integrity stavu relácie  
- Znížený povrch útoku, ale vyžaduje robustnú validáciu tokenov  

## 4. **Bezpečnostné Kontroly Špecifické pre AI**

### **Obrana proti Vstrekovaniu Promptov**

**Integrácia Microsoft Prompt Shields:**
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

**Kontroly Implementácie:**
- **Sanitácia Vstupov**: Komplexná validácia a filtrovanie všetkých používateľských vstupov  
- **Definícia Hraníc Obsahu**: Jasné oddelenie systémových inštrukcií a používateľského obsahu  
- **Hierarchia Inštrukcií**: Správne pravidlá prednosti pre konfliktné inštrukcie  
- **Monitorovanie Výstupov**: Detekcia potenciálne škodlivých alebo manipulovaných výstupov  

### **Prevencia Otravy Nástrojov**

**Rámec Bezpečnosti Nástrojov:**
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

**Dynamické Riadenie Nástrojov:**
- **Schvaľovacie Procesy**: Výslovný súhlas používateľa pre úpravy nástrojov  
- **Možnosti Návratu**: Schopnosť vrátiť sa k predchádzajúcim verziám nástrojov  
- **Auditovanie Zmien**: Kompletná história úprav definícií nástrojov  
- **Hodnotenie Rizík**: Automatizované hodnotenie bezpečnostného stavu nástrojov  

## 5. **Prevencia Útokov na Zmätok Zástupcu**

### **Bezpečnosť OAuth Proxy**

**Kontroly Prevencie Útokov:**
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

**Požiadavky na Implementáciu:**
- **Overenie Súhlasu Používateľa**: Nikdy nepreskakujte obrazovky súhlasu pre dynamickú registráciu klientov  
- **Validácia URI Presmerovania**: Prísna validácia cieľov presmerovania na základe whitelistu  
- **Ochrana Autorizačných Kódov**: Krátkodobé kódy s vynucovaním jednorazového použitia  
- **Overenie Identity Klienta**: Robustné overenie poverení a metaúdajov klienta  

## 6. **Bezpečnosť Vykonávania Nástrojov**

### **Sandboxing a Izolácia**

**Izolácia na Báze Kontajnerov:**
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

**Izolácia Procesov:**
- **Oddelené Kontexty Procesov**: Každé vykonanie nástroja v izolovanom priestore procesu  
- **Medziprocesová Komunikácia**: Bezpečné mechanizmy IPC s validáciou  
- **Monitorovanie Procesov**: Analýza správania počas behu a detekcia anomálií  
- **Vynucovanie Zdroja**: Tvrdé limity na CPU, pamäť a I/O operácie  

### **Implementácia Minimálnych Práv**

**Riadenie Povolení:**
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

## 7. **Kontroly Bezpečnosti Dodávateľského Reťazca**

### **Overenie Závislostí**

**Komplexná Bezpečnosť Komponentov:**
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

### **Kontinuálne Monitorovanie**

**Detekcia Hrozieb v Dodávateľskom Reťazci:**
- **Monitorovanie Zdravia Závislostí**: Kontinuálne hodnotenie všetkých závislostí na bezpečnostné problémy  
- **Integrácia Inteligencie o Hrozbách**: Aktualizácie v reálnom čase o vznikajúcich hrozbách v dodávateľskom reťazci  
- **Analýza Správania**: Detekcia neobvyklého správania v externých komponentoch  
- **Automatizovaná Odozva**: Okamžité obmedzenie kompromitovaných komponentov  

## 8. **Kontroly Monitorovania a Detekcie**

### **Bezpečnostné Informácie a Riadenie Udalostí (SIEM)**

**Komplexná Stratégia Logovania:**
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

### **Detekcia Hrozieb v Reálnom Čase**

**Analýza Správania:**
- **Analýza Správania Používateľov (UBA)**: Detekcia neobvyklých vzorov prístupu používateľov  
- **Analýza Správania Entít (EBA)**: Monitorovanie správania MCP servera a nástrojov  
- **Detekcia Anomálií na Základe AI**: Identifikácia bezpečnostných hrozieb pomocou AI  
- **Korelácia Inteligencie o Hrozbách**: Porovnávanie pozorovaných aktivít s známymi vzormi útokov  

## 9. **Reakcia na Incidenty a Obnova**

### **Automatizované Schopnosti Odozvy**

**Okamžité Akcie Odozvy:**
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

### **Forenzné Schopnosti**

**Podpora Vyšetrovania:**
- **Zachovanie Auditných Stôp**: Nemenné logovanie s kryptografickou integritou  
- **Zber Dôkazov**: Automatizované zhromažďovanie relevantných bezpečnostných artefaktov  
- **Rekonštrukcia Časovej Osi**: Detailná sekvencia udalostí vedúcich k bezpečnostným incidentom  
- **Hodnotenie Dopadu**: Vyhodnotenie rozsahu kompromitácie a expozície údajov  

## **Kľúčové Princípy Bezpečnostnej Architektúry**

### **Obrana v Hĺbke**
- **Viacero Bezpečnostných Vrstiev**: Žiadny jediný bod zlyhania v bezpečnostnej architektúre  
- **Redundantné Kontroly**: Prekrývajúce sa bezpečnostné opatrenia pre kritické funkcie  
- **Mechanizmy Bezpečného Zlyhania**: Bezpečné predvolené nastavenia, keď systémy narazia na chyby alebo útoky  

### **Implementácia Zero Trust**
- **Nikdy Never, Vždy Overuj**: Kontinuálne overovanie všetkých entít a požiadaviek  
- **Princíp Minimálnych Práv**: Minimálne prístupové práva pre všetky komponenty  
- **Mikrosegmentácia**: Granulárne sieťové a prístupové kontroly  

### **Kontinuálny Vývoj Bezpečnosti**
- **Adaptácia na Hrozby**: Pravidelné aktualizácie na riešenie vznikajúcich hrozieb  
- **Efektívnosť Bezpečnostných Kontrol**: Neustále hodnotenie a zlepšovanie kontrol  
- **Súlad so Špecifikáciami**: Zarovnanie s vyvíjajúcimi sa bezpečnostnými štandardmi MCP  

---

## **Zdroje na Implementáciu**

### **Oficiálna Dokumentácia MCP**
- [MCP Špecifikácia (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)  
- [MCP Bezpečnostné Najlepšie Praktiky](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)  
- [MCP Špecifikácia Autorizácie](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)  

### **Microsoft Bezpečnostné Riešenia**
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [GitHub Advanced Security](https://github.com/security/advanced-security)  
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/)  

### **Bezpečnostné Štandardy**
- [OAuth 2.0 Bezpečnostné Najlepšie Praktiky (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [OWASP Top 10 pre Veľké Jazykové Modely](https://genai.owasp.org/)  
- [NIST Rámec Kybernetickej Bezpečnosti](https://www.nist.gov/cyberframework)  

---

> **Dôležité**: Tieto bezpečnostné kontroly odrážajú aktuálnu špecifikáciu MCP (2025-06-18). Vždy overte podľa najnovšej [oficiálnej dokumentácie](https://spec.modelcontextprotocol.io/), pretože štandardy sa rýchlo vyvíjajú.  

**Upozornenie**:  
Tento dokument bol preložený pomocou služby na automatický preklad [Co-op Translator](https://github.com/Azure/co-op-translator). Aj keď sa snažíme o presnosť, upozorňujeme, že automatické preklady môžu obsahovať chyby alebo nepresnosti. Pôvodný dokument v jeho pôvodnom jazyku by mal byť považovaný za autoritatívny zdroj. Pre dôležité informácie sa odporúča profesionálny ľudský preklad. Nezodpovedáme za žiadne nedorozumenia alebo nesprávne interpretácie vyplývajúce z použitia tohto prekladu.