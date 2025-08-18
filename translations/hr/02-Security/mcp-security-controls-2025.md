<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0c243c6189393ed7468e470ef2090049",
  "translation_date": "2025-08-18T17:28:14+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "hr"
}
-->
# MCP Sigurnosne Kontrole - Ažuriranje za kolovoz 2025.

> **Trenutni standard**: Ovaj dokument odražava sigurnosne zahtjeve [MCP Specifikacije 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) i službene [MCP Sigurnosne Najbolje Prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices).

Model Context Protocol (MCP) značajno je napredovao s poboljšanim sigurnosnim kontrolama koje se bave i tradicionalnim softverskim sigurnosnim prijetnjama i prijetnjama specifičnim za umjetnu inteligenciju. Ovaj dokument pruža sveobuhvatne sigurnosne kontrole za sigurne MCP implementacije od kolovoza 2025.

## **OBVEZNI Sigurnosni Zahtjevi**

### **Ključne Zabrane iz MCP Specifikacije:**

> **ZABRANJENO**: MCP poslužitelji **NE SMIJU** prihvaćati tokene koji nisu izričito izdani za MCP poslužitelj  
>
> **ZABRANJENO**: MCP poslužitelji **NE SMIJU** koristiti sesije za autentifikaciju  
>
> **OBVEZNO**: MCP poslužitelji koji implementiraju autorizaciju **MORAJU** provjeriti SVE dolazne zahtjeve  
>
> **OBVEZNO**: MCP proxy poslužitelji koji koriste statične ID-ove klijenata **MORAJU** dobiti pristanak korisnika za svakog dinamički registriranog klijenta  

---

## 1. **Kontrole Autentifikacije i Autorizacije**

### **Integracija Vanjskog Pružatelja Identiteta**

**Trenutni MCP Standard (2025-06-18)** omogućuje MCP poslužiteljima delegiranje autentifikacije vanjskim pružateljima identiteta, što predstavlja značajno sigurnosno poboljšanje:

**Sigurnosne Prednosti:**
1. **Uklanjanje Rizika Prilagođene Autentifikacije**: Smanjuje površinu ranjivosti izbjegavanjem prilagođenih implementacija autentifikacije  
2. **Sigurnost na Razini Poduzeća**: Koristi etablirane pružatelje identiteta poput Microsoft Entra ID-a s naprednim sigurnosnim značajkama  
3. **Centralizirano Upravljanje Identitetima**: Pojednostavljuje upravljanje korisničkim životnim ciklusom, kontrolu pristupa i reviziju usklađenosti  
4. **Višefaktorska Autentifikacija**: Nasljeđuje MFA mogućnosti od pružatelja identiteta na razini poduzeća  
5. **Uvjetne Politike Pristupa**: Koristi kontrole pristupa temeljene na riziku i prilagodljivu autentifikaciju  

**Zahtjevi za Implementaciju:**
- **Validacija Publike Tokena**: Provjerite jesu li svi tokeni izričito izdani za MCP poslužitelj  
- **Provjera Izdavatelja**: Validirajte da izdavatelj tokena odgovara očekivanom pružatelju identiteta  
- **Provjera Potpisa**: Kriptografska validacija integriteta tokena  
- **Provođenje Isteka**: Strogo provođenje vremenskih ograničenja tokena  
- **Validacija Domena**: Osigurajte da tokeni sadrže odgovarajuće dozvole za tražene operacije  

### **Sigurnost Logike Autorizacije**

**Ključne Kontrole:**
- **Sveobuhvatne Revizije Autorizacije**: Redoviti sigurnosni pregledi svih točaka donošenja odluka o autorizaciji  
- **Sigurni Zadani Postavci**: Odbijte pristup kada logika autorizacije ne može donijeti konačnu odluku  
- **Granice Dozvola**: Jasno razdvajanje između različitih razina privilegija i pristupa resursima  
- **Revizijski Zapisnici**: Potpuno bilježenje svih odluka o autorizaciji za sigurnosno praćenje  
- **Redoviti Pregledi Pristupa**: Periodična validacija korisničkih dozvola i dodjela privilegija  

## 2. **Sigurnost Tokena i Kontrole protiv Prosljeđivanja**

### **Prevencija Prosljeđivanja Tokena**

**Prosljeđivanje tokena izričito je zabranjeno** u MCP Specifikaciji Autorizacije zbog kritičnih sigurnosnih rizika:

**Sigurnosni Rizici koji se Rješavaju:**
- **Zaobilaženje Kontrola**: Zaobilazi ključne sigurnosne kontrole poput ograničavanja brzine, validacije zahtjeva i praćenja prometa  
- **Narušavanje Odgovornosti**: Onemogućuje identifikaciju klijenata, narušavajući revizijske tragove i istrage incidenata  
- **Eksfiltracija putem Proxyja**: Omogućuje zlonamjernim akterima korištenje poslužitelja kao proxyja za neovlašteni pristup podacima  
- **Kršenje Granica Povjerenja**: Ruši pretpostavke o podrijetlu tokena kod usluga nizvodno  
- **Bočno Kretanje**: Kompromitirani tokeni između više usluga omogućuju širenje napada  

**Kontrole Implementacije:**
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

### **Sigurni Obrasci Upravljanja Tokenima**

**Najbolje Prakse:**
- **Tokeni Kratkog Trajanja**: Minimizirajte prozor izloženosti čestom rotacijom tokena  
- **Izdavanje po Potrebi**: Izdajte tokene samo kada su potrebni za specifične operacije  
- **Sigurno Pohranjivanje**: Koristite hardverske sigurnosne module (HSM) ili sigurne spremnike ključeva  
- **Vezivanje Tokena**: Vežite tokene za specifične klijente, sesije ili operacije gdje je moguće  
- **Praćenje i Upozoravanje**: Detekcija u stvarnom vremenu zloupotrebe tokena ili obrazaca neovlaštenog pristupa  

## 3. **Kontrole Sigurnosti Sesija**

### **Prevencija Otimanja Sesija**

**Napadni Vektori koji se Rješavaju:**
- **Umetanje Zlonamjernih Podataka u Sesiju**: Zlonamjerni događaji umetnuti u zajedničko stanje sesije  
- **Lažno Predstavljanje Sesije**: Neovlaštena uporaba ukradenih ID-ova sesija za zaobilaženje autentifikacije  
- **Napadi na Nastavljive Tokove**: Iskorištavanje nastavka događaja poslanih od poslužitelja za umetanje zlonamjernog sadržaja  

**Obvezne Kontrole Sesija:**
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

**Sigurnost Prijenosa:**
- **Provođenje HTTPS-a**: Sva komunikacija sesije preko TLS 1.3  
- **Atributi Sigurnih Kolačića**: HttpOnly, Secure, SameSite=Strict  
- **Pinning Certifikata**: Za kritične veze kako bi se spriječili MITM napadi  

### **Razmatranja o Stanju Sesije**

**Za Implementacije sa Stanjima:**
- Dijeljeno stanje sesije zahtijeva dodatnu zaštitu od napada umetanja  
- Upravljanje sesijama temeljeno na redovima zahtijeva provjeru integriteta  
- Više instanci poslužitelja zahtijeva sigurnu sinkronizaciju stanja sesije  

**Za Implementacije bez Stanja:**
- JWT ili sličan token-bazirani sustav upravljanja sesijama  
- Kriptografska provjera integriteta stanja sesije  
- Smanjena površina napada, ali zahtijeva robusnu validaciju tokena  

## 4. **Sigurnosne Kontrole Specifične za AI**

### **Obrana od Umetanja Uputa**

**Integracija Microsoft Prompt Shields:**
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

**Kontrole Implementacije:**
- **Sanitizacija Unosa**: Sveobuhvatna validacija i filtriranje svih korisničkih unosa  
- **Definicija Granica Sadržaja**: Jasno razdvajanje između sistemskih uputa i korisničkog sadržaja  
- **Hijerarhija Uputa**: Ispravna pravila prioriteta za sukobljene upute  
- **Praćenje Izlaza**: Detekcija potencijalno štetnih ili manipuliranih izlaza  

### **Prevencija Trovanja Alata**

**Sigurnosni Okvir za Alate:**
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

**Dinamičko Upravljanje Alatima:**
- **Radni Tokovi Odobrenja**: Izričiti pristanak korisnika za izmjene alata  
- **Mogućnosti Vraćanja**: Sposobnost vraćanja na prethodne verzije alata  
- **Revizija Promjena**: Potpuna povijest izmjena definicija alata  
- **Procjena Rizika**: Automatizirana evaluacija sigurnosnog stanja alata  

## 5. **Prevencija Napada Zbunjenog Zamjenika**

### **Sigurnost OAuth Proxyja**

**Kontrole za Prevenciju Napada:**
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

**Zahtjevi za Implementaciju:**
- **Provjera Pristanka Korisnika**: Nikada ne preskačite ekrane za pristanak kod dinamičke registracije klijenata  
- **Validacija URI-ja za Preusmjeravanje**: Stroga validacija odredišta preusmjeravanja temeljena na bijelim listama  
- **Zaštita Autorizacijskog Koda**: Kodovi kratkog trajanja s provođenjem jednokratne uporabe  
- **Provjera Identiteta Klijenta**: Robusna validacija vjerodajnica i metapodataka klijenata  

## 6. **Sigurnost Izvršavanja Alata**

### **Sandboxing i Izolacija**

**Izolacija Temeljena na Kontejnerima:**
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

**Izolacija Procesa:**
- **Odvojeni Konteksti Procesa**: Svako izvršavanje alata u izoliranom prostoru procesa  
- **Međuprocesna Komunikacija**: Sigurni mehanizmi IPC-a s validacijom  
- **Praćenje Procesa**: Analiza ponašanja u stvarnom vremenu i detekcija anomalija  
- **Ograničenje Resursa**: Stroga ograničenja na CPU, memoriju i I/O operacije  

### **Implementacija Najmanjih Privilegija**

**Upravljanje Dozvolama:**
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

## 7. **Kontrole Sigurnosti Opskrbnog Lanca**

### **Provjera Ovisnosti**

**Sveobuhvatna Sigurnost Komponenti:**
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

### **Kontinuirano Praćenje**

**Detekcija Prijetnji u Opskrbnom Lancu:**
- **Praćenje Zdravlja Ovisnosti**: Kontinuirana procjena svih ovisnosti za sigurnosne probleme  
- **Integracija Obavještajnih Podataka o Prijetnjama**: Ažuriranja u stvarnom vremenu o novim prijetnjama opskrbnom lancu  
- **Analiza Ponašanja**: Detekcija neobičnog ponašanja u vanjskim komponentama  
- **Automatizirani Odgovor**: Trenutno ograničavanje kompromitiranih komponenti  

## 8. **Kontrole Praćenja i Detekcije**

### **Upravljanje Sigurnosnim Informacijama i Događajima (SIEM)**

**Sveobuhvatna Strategija Bilježenja:**
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

### **Detekcija Prijetnji u Stvarnom Vremenu**

**Analitika Ponašanja:**
- **Analitika Ponašanja Korisnika (UBA)**: Detekcija neobičnih obrazaca pristupa korisnika  
- **Analitika Ponašanja Entiteta (EBA)**: Praćenje ponašanja MCP poslužitelja i alata  
- **Detekcija Anomalija Temeljena na AI-u**: Identifikacija sigurnosnih prijetnji pomoću umjetne inteligencije  
- **Korelacija Obavještajnih Podataka o Prijetnjama**: Usporedba opaženih aktivnosti s poznatim obrascima napada  

## 9. **Odgovor na Incidente i Oporavak**

### **Automatizirane Mogućnosti Odgovora**

**Trenutne Akcije Odgovora:**
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

### **Forenzičke Mogućnosti**

**Podrška za Istragu:**
- **Očuvanje Revizijskog Traga**: Nepromjenjivo bilježenje s kriptografskim integritetom  
- **Prikupljanje Dokaza**: Automatizirano prikupljanje relevantnih sigurnosnih artefakata  
- **Rekonstrukcija Vremenske Crte**: Detaljan slijed događaja koji su doveli do sigurnosnih incidenata  
- **Procjena Utjecaja**: Evaluacija opsega kompromitacije i izloženosti podataka  

## **Ključna Načela Sigurnosne Arhitekture**

### **Obrana u Dubini**
- **Višestruki Sigurnosni Slojevi**: Nema jedne točke neuspjeha u sigurnosnoj arhitekturi  
- **Redundantne Kontrole**: Preklapajuće sigurnosne mjere za kritične funkcije  
- **Sigurni Mehanizmi za Neuspjeh**: Sigurni zadani postavci kada sustavi naiđu na pogreške ili napade  

### **Implementacija Zero Trust-a**
- **Nikad Ne Vjeruj, Uvijek Provjeravaj**: Kontinuirana validacija svih entiteta i zahtjeva  
- **Načelo Najmanjih Privilegija**: Minimalna prava pristupa za sve komponente  
- **Mikrosegmentacija**: Granularna mrežna i pristupna kontrola  

### **Kontinuirana Evolucija Sigurnosti**
- **Prilagodba Prijetnjama**: Redovita ažuriranja za rješavanje novih prijetnji  
- **Učinkovitost Sigurnosnih Kontrola**: Stalna evaluacija i poboljšanje kontrola  
- **Usklađenost sa Specifikacijama**: Usklađenost s evoluirajućim MCP sigurnosnim standardima  

---

## **Resursi za Implementaciju**

### **Službena MCP Dokumentacija**
- [MCP Specifikacija (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)  
- [MCP Sigurnosne Najbolje Prakse](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)  
- [MCP Specifikacija Autorizacije](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)  

### **Microsoft Sigurnosna Rješenja**
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [GitHub Advanced Security](https://github.com/security/advanced-security)  
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/)  

### **Sigurnosni Standardi**
- [OAuth 2.0 Sigurnosne Najbolje Prakse (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [OWASP Top 10 za Velike Jezične Modele](https://genai.owasp.org/)  
- [NIST Okvir za Kibernetičku Sigurnost](https://www.nist.gov/cyberframework)  

---

> **Važno**: Ove sigurnosne kontrole odražavaju trenutnu MCP specifikaciju (2025-06-18). Uvijek provjerite najnoviju [službenu dokumentaciju](https://spec.modelcontextprotocol.io/) jer se standardi brzo razvijaju.  

**Odricanje od odgovornosti**:  
Ovaj dokument je preveden korištenjem AI usluge za prijevod [Co-op Translator](https://github.com/Azure/co-op-translator). Iako nastojimo osigurati točnost, imajte na umu da automatski prijevodi mogu sadržavati pogreške ili netočnosti. Izvorni dokument na izvornom jeziku treba smatrati mjerodavnim izvorom. Za ključne informacije preporučuje se profesionalni prijevod od strane stručnjaka. Ne preuzimamo odgovornost za bilo kakve nesporazume ili pogrešne interpretacije proizašle iz korištenja ovog prijevoda.