<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0c243c6189393ed7468e470ef2090049",
  "translation_date": "2025-08-18T23:27:40+00:00",
  "source_file": "02-Security/mcp-security-controls-2025.md",
  "language_code": "my"
}
-->
# MCP လုံခြုံရေးထိန်းချုပ်မှုများ - ၂၀၂၅ ခုနှစ် ဩဂုတ်လ အပ်ဒိတ်

> **လက်ရှိစံနှုန်း**: ဒီစာရွက်စာတမ်းသည် [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) လုံခြုံရေးလိုအပ်ချက်များနှင့် [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) တရားဝင်အကြံပေးချက်များကို အဓိကထားပြသထားသည်။

Model Context Protocol (MCP) သည် အဆင့်မြှင့်လုံခြုံရေးထိန်းချုပ်မှုများဖြင့် အရေးပါသော ဆော့ဖ်ဝဲလ်လုံခြုံရေးနှင့် AI-specific အန္တရာယ်များကို ဖြေရှင်းနိုင်ရန် အလွန်တိုးတက်လာပြီဖြစ်သည်။ ဒီစာရွက်စာတမ်းသည် ၂၀၂၅ ခုနှစ် ဩဂုတ်လအထိ MCP ကို လုံခြုံစွာ အကောင်အထည်ဖော်ရန် လုံခြုံရေးထိန်းချုပ်မှုများကို အပြည့်အစုံဖော်ပြထားသည်။

## **မဖြစ်မနေလိုအပ်သော လုံခြုံရေးလိုအပ်ချက်များ**

### **MCP Specification မှ အရေးကြီးသော တားမြစ်ချက်များ**

> **FORBIDDEN**: MCP server များသည် MCP server အတွက် ထုတ်ပေးထားသော token မဟုတ်သော token များကို **လက်ခံလို့မရ**  
>
> **PROHIBITED**: MCP server များသည် authentication အတွက် session များကို **အသုံးမပြုရ**  
>
> **REQUIRED**: Authorization ကို အကောင်အထည်ဖော်သော MCP server များသည် **ဝင်ရောက်လာသော request အားလုံးကို စစ်ဆေးရမည်**  
>
> **MANDATORY**: Static client ID များကို အသုံးပြုသော MCP proxy server များသည် **dynamic client registration တစ်ခုစီအတွက် အသုံးပြုသူ၏ သဘောတူညီမှုကို ရယူရမည်**  

---

## 1. **Authentication နှင့် Authorization ထိန်းချုပ်မှုများ**

### **အပြင် Identity Provider နှင့် ပေါင်းစည်းမှု**

**လက်ရှိ MCP စံနှုန်း (2025-06-18)** သည် MCP server များကို authentication ကို အပြင် identity provider များထံ အပ်နှံခွင့်ပြုထားပြီး လုံခြုံရေးအတွက် အရေးပါသော တိုးတက်မှုကို ကိုယ်စားပြုသည်။

**လုံခြုံရေးအကျိုးကျေးဇူးများ**:
1. **Custom Authentication အန္တရာယ်များကို ဖယ်ရှားခြင်း**: Custom authentication implementation များကို ရှောင်ရှားခြင်းဖြင့် အန္တရာယ်များကို လျှော့ချနိုင်သည်  
2. **အဖွဲ့အစည်းအဆင့် လုံခြုံရေး**: Microsoft Entra ID ကဲ့သို့သော အတည်ပြု identity provider များ၏ အဆင့်မြင့်လုံခြုံရေး features များကို အသုံးပြုနိုင်သည်  
3. **Identity စီမံခန့်ခွဲမှုကို အလွယ်ကူအောင်လုပ်ခြင်း**: အသုံးပြုသူ၏ lifecycle စီမံခန့်ခွဲမှု၊ access control နှင့် compliance auditing ကို လွယ်ကူစေသည်  
4. **Multi-Factor Authentication**: Enterprise identity provider များ၏ MFA စွမ်းရည်များကို အလိုအလျောက်ရရှိသည်  
5. **Conditional Access Policies**: အန္တရာယ်အခြေပြု access control နှင့် adaptive authentication ကို အကျိုးခံစားနိုင်သည်  

**အကောင်အထည်ဖော်ရန်လိုအပ်ချက်များ**:
- **Token Audience Validation**: Token များသည် MCP server အတွက် ထုတ်ပေးထားသည်ကို အတည်ပြုရမည်  
- **Issuer Verification**: Token issuer သည် မျှော်မှန်းထားသော identity provider နှင့် ကိုက်ညီမှုရှိသည်ကို စစ်ဆေးရမည်  
- **Signature Verification**: Token ၏ cryptographic တိကျမှုကို အတည်ပြုရမည်  
- **Expiration Enforcement**: Token lifetime အကန့်အသတ်များကို တင်းကျပ်စွာ လိုက်နာရမည်  
- **Scope Validation**: Token များတွင် တောင်းဆိုထားသော လုပ်ဆောင်မှုများအတွက် သင့်လျော်သော permissions ပါရှိသည်ကို အတည်ပြုရမည်  

### **Authorization Logic လုံခြုံရေး**

**အရေးပါသော ထိန်းချုပ်မှုများ**:
- **Authorization Audits အပြည့်အစုံ**: Authorization ဆုံးဖြတ်ချက်များအားလုံးကို ပုံမှန်လုံခြုံရေး ပြန်လည်သုံးသပ်မှုများ ပြုလုပ်ရမည်  
- **Fail-Safe Defaults**: Authorization logic သည် အတိအကျဆုံးဖြတ်ချက်မပေးနိုင်သောအခါ access ကို ပိတ်ထားရမည်  
- **Permission Boundaries**: Privilege အဆင့်များနှင့် resource access အကြား သတ်မှတ်ချက်များ ရှင်းလင်းစွာ ခွဲခြားထားရမည်  
- **Audit Logging**: Authorization ဆုံးဖြတ်ချက်များအားလုံးကို လုံခြုံရေးအတွက် မှတ်တမ်းတင်ထားရမည်  
- **Regular Access Reviews**: အသုံးပြုသူ၏ permission နှင့် privilege ချမှတ်မှုများကို ပုံမှန်စစ်ဆေးရမည်  

## 2. **Token လုံခြုံရေးနှင့် Anti-Passthrough ထိန်းချုပ်မှုများ**

### **Token Passthrough တားမြစ်ခြင်း**

**Token passthrough သည် MCP Authorization Specification တွင် အရေးပါသော လုံခြုံရေးအန္တရာယ်များကြောင့် တင်းကျပ်စွာ တားမြစ်ထားသည်**:

**ဖြေရှင်းထားသော လုံခြုံရေးအန္တရာယ်များ**:
- **Control Circumvention**: Rate limiting, request validation, traffic monitoring ကဲ့သို့သော အရေးပါသော လုံခြုံရေးထိန်းချုပ်မှုများကို ရှောင်ရှားနိုင်သည်  
- **Accountability Breakdown**: Client identification မဖြစ်နိုင်တော့ပြီး audit trail နှင့် အရေးပေါ်အခြေအနေ စုံစမ်းမှုများကို ပျက်စီးစေသည်  
- **Proxy-Based Exfiltration**: Server များကို proxy အဖြစ် အသုံးပြု၍ မလိုလားသော data access ပြုလုပ်နိုင်သည်  
- **Trust Boundary Violations**: Token မူလအရင်းအမြစ်အပေါ် Downstream service များ၏ ယုံကြည်မှုကို ဖျက်ဆီးသည်  
- **Lateral Movement**: Token များကို အတားအဆီးမရှိသော အခြား service များတွင် အသုံးပြု၍ အကျယ်ချဲ့သော တိုက်ခိုက်မှုများ ပြုလုပ်နိုင်သည်  

**Implementation Controls**:
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

### **Token စီမံခန့်ခွဲမှု လုံခြုံရေး Pattern များ**

**အကောင်းဆုံးအလေ့အထ**:
- **Short-Lived Tokens**: Token များကို အမြဲလှည့်လည်ပြောင်းလဲခြင်းဖြင့် အန္တရာယ်အချိန်ကို လျှော့ချခြင်း  
- **Just-in-Time Issuance**: Token များကို တိကျသော လုပ်ဆောင်မှုများအတွက် လိုအပ်သောအခါမှ ထုတ်ပေးခြင်း  
- **Secure Storage**: Hardware security module (HSM) များ သို့မဟုတ် secure key vault များကို အသုံးပြုခြင်း  
- **Token Binding**: Token များကို သတ်မှတ် client, session, သို့မဟုတ် လုပ်ဆောင်မှုများနှင့် ချိတ်ဆက်ထားခြင်း  
- **Monitoring & Alerting**: Token များကို မလိုလားသော အသုံးပြုမှု သို့မဟုတ် မခွင့်ပြုထားသော access pattern များကို အချိန်နှင့်တပြေးညီ ရှာဖွေခြင်း  

## 3. **Session လုံခြုံရေးထိန်းချုပ်မှုများ**

### **Session Hijacking တားဆီးခြင်း**

**ဖြေရှင်းထားသော တိုက်ခိုက်မှုများ**:
- **Session Hijack Prompt Injection**: Shared session state တွင် မကောင်းသော အဖြစ်အပျက်များ ထည့်သွင်းခြင်း  
- **Session Impersonation**: Session ID များကို ခိုးယူပြီး authentication ကို ကျော်လွှားခြင်း  
- **Resumable Stream Attacks**: Server-sent event resumption ကို အသုံးပြု၍ မကောင်းသော content ထည့်သွင်းခြင်း  

**မဖြစ်မနေလိုအပ်သော Session ထိန်းချုပ်မှုများ**:
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

**Transport Security**:
- **HTTPS Enforcement**: Session ဆက်သွယ်မှုအားလုံးကို TLS 1.3 ဖြင့် ပြုလုပ်ရမည်  
- **Secure Cookie Attributes**: HttpOnly, Secure, SameSite=Strict  
- **Certificate Pinning**: အရေးပါသော connection များအတွက် MITM တိုက်ခိုက်မှုများကို တားဆီးရန်  

### **Stateful နှင့် Stateless အတွေးအခေါ်များ**

**Stateful Implementation များအတွက်**:
- Shared session state တွင် injection တိုက်ခိုက်မှုများကို ထိန်းချုပ်ရန် အပိုကာကွယ်မှုများလိုအပ်သည်  
- Queue-based session management တွင် integrity verification လိုအပ်သည်  
- Server instance များစွာအကြား session state synchronization ကို လုံခြုံစွာ ပြုလုပ်ရမည်  

**Stateless Implementation များအတွက်**:
- JWT သို့မဟုတ် token-based session management  
- Session state integrity ကို cryptographic verification ဖြင့် အတည်ပြုခြင်း  
- တိုက်ခိုက်မှုအပေါ် အနည်းဆုံးအကျိုးသက်သာမှုရှိသည့် attack surface  

## 4. **AI-Specific လုံခြုံရေးထိန်းချုပ်မှုများ**

### **Prompt Injection ကာကွယ်မှု**

**Microsoft Prompt Shields Integration**:
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

**Implementation Controls**:
- **Input Sanitization**: အသုံးပြုသူ၏ input အားလုံးကို စစ်ဆေးခြင်းနှင့် စိစစ်ခြင်း  
- **Content Boundary Definition**: System instruction များနှင့် အသုံးပြုသူ content အကြား သတ်မှတ်ချက်များ ရှင်းလင်းစွာ ခွဲခြားထားခြင်း  
- **Instruction Hierarchy**: Instruction များအကြား conflict ဖြစ်သောအခါ precedence rule များကို သင့်လျော်စွာ သတ်မှတ်ထားခြင်း  
- **Output Monitoring**: မကောင်းသော သို့မဟုတ် manipulated ဖြစ်သော output များကို ရှာဖွေခြင်း  

### **Tool Poisoning ကာကွယ်မှု**

**Tool Security Framework**:
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

**Dynamic Tool Management**:
- **Approval Workflows**: Tool ပြောင်းလဲမှုများအတွက် အသုံးပြုသူ၏ သဘောတူညီမှုကို ရယူခြင်း  
- **Rollback Capabilities**: Tool version များကို ပြန်လည်ပြောင်းလဲနိုင်စွမ်း  
- **Change Auditing**: Tool definition ပြောင်းလဲမှုများ၏ မှတ်တမ်းတင်မှု  
- **Risk Assessment**: Tool လုံခြုံရေးအခြေအနေကို အလိုအလျောက် အကဲဖြတ်ခြင်း  

## 5. **Confused Deputy Attack ကာကွယ်မှု**

### **OAuth Proxy လုံခြုံရေး**

**Attack ကာကွယ်မှု ထိန်းချုပ်မှုများ**:
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

**Implementation Requirements**:
- **User Consent Verification**: Dynamic client registration အတွက် consent screen များကို မကျော်လွှားရ  
- **Redirect URI Validation**: Redirect destination များကို whitelist-based validation ဖြင့် စစ်ဆေးရ  
- **Authorization Code Protection**: Single-use enforcement ဖြင့် short-lived code များကို အသုံးပြုရ  
- **Client Identity Verification**: Client credentials နှင့် metadata ကို တင်းကျပ်စွာ စစ်ဆေးရ  

## 6. **Tool Execution လုံခြုံရေး**

### **Sandboxing နှင့် Isolation**

**Container-Based Isolation**:
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

**Process Isolation**:
- **Separate Process Contexts**: Tool execution တစ်ခုစီကို အထူး process space တွင် ပြုလုပ်ခြင်း  
- **Inter-Process Communication**: Validation ဖြင့် secure IPC mechanism များကို အသုံးပြုခြင်း  
- **Process Monitoring**: Runtime behavior analysis နှင့် anomaly detection  
- **Resource Enforcement**: CPU, memory, နှင့် I/O operation များအပေါ် hard limit များ သတ်မှတ်ထားခြင်း  

### **Least Privilege Implementation**

**Permission Management**:
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

## 7. **Supply Chain လုံခြုံရေးထိန်းချုပ်မှုများ**

### **Dependency Verification**

**Comprehensive Component Security**:
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

### **Continuous Monitoring**

**Supply Chain Threat Detection**:
- **Dependency Health Monitoring**: Dependency များအား security issue များအတွက် အဆက်မပြတ် စစ်ဆေးခြင်း  
- **Threat Intelligence Integration**: Supply chain အန္တရာယ်များအပေါ် အချိန်နှင့်တပြေးညီ အချက်အလက်ရယူခြင်း  
- **Behavioral Analysis**: အပြင် component များ၏ ထူးဆန်းသော အပြုအမူများကို ရှာဖွေခြင်း  
- **Automated Response**: Compromised ဖြစ်သော component များကို ချက်ချင်း containment ပြုလုပ်ခြင်း  

## 8. **Monitoring နှင့် Detection ထိန်းချုပ်မှုများ**

### **Security Information and Event Management (SIEM)**

**Comprehensive Logging Strategy**:
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

### **Real-Time Threat Detection**

**Behavioral Analytics**:
- **User Behavior Analytics (UBA)**: အသုံးပြုသူ၏ ထူးဆန်းသော access pattern များကို ရှာဖွေခြင်း  
- **Entity Behavior Analytics (EBA)**: MCP server နှင့် tool အပြုအမူကို စောင့်ကြည့်ခြင်း  
- **Machine Learning Anomaly Detection**: AI-powered security threat များကို ရှာဖွေခြင်း  
- **Threat Intelligence Correlation**: သိရှိထားသော တိုက်ခိုက်မှု pattern များနှင့် ကိုက်ညီမှုရှိသော လုပ်ဆောင်မှုများကို တွေ့ရှိခြင်း  

## 9. **Incident Response နှင့် Recovery**

### **Automated Response Capabilities**

**Immediate Response Actions**:
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

### **Forensic Capabilities**

**Investigation Support**:
- **Audit Trail Preservation**: Cryptographic တိကျမှုရှိသော immutable logging  
- **Evidence Collection**: လိုအပ်သော security artifact များကို အလိုအလျောက် စုဆောင်းခြင်း  
- **Timeline Reconstruction**: Security incident များအကြောင်းအရာကို အစဉ်အတိုင်း ပြန်လည်ဖော်ပြခြင်း  
- **Impact Assessment**: Compromise scope နှင့် data exposure ကို အကဲဖြတ်ခြင်း  

## **အရေးပါသော လုံခြုံရေး Architecture အခြေခံသဘောတရားများ**

### **Defense in Depth**
- **လုံခြုံရေးအလွှာများစွာ**: Security architecture တွင် single point of failure မရှိစေရန်  
- **Redundant Controls**: အရေးပါသော လုပ်ဆောင်မှုများအတွက် ထပ်တူလုံခြုံရေးအတိုင်းအတာများ  
- **Fail-Safe Mechanisms**: Error သို့မဟုတ် တိုက်ခိုက်မှုများဖြစ်ပေါ်သောအခါ secure defaults  

### **Zero Trust Implementation**
- **ယုံကြည်မှုမရှိ၊ အမြဲစစ်ဆေး**: Entity နှင့် request အားလုံးကို အဆက်မပြတ် validation ပြုလုပ်ခြင်း  
- **Principle of Least Privilege**: Component အားလုံးအတွက် access rights အနည်းဆုံး  
- **Micro-Segmentation**: Network နှင့် access control များကို အလွန်သေးငယ်စွာ ခွဲခြားထားခြင်း  

### **Continuous Security Evolution**
- **Threat Landscape Adaptation**: ပေါ်ပေါက်လာသော အန္တရာယ်များကို ဖြေရှင်းရန် ပုံမှန် update ပြုလုပ်ခြင်း  
- **Security Control Effectiveness**: ထိန်းချုပ်မှုများ၏ ထိရောက်မှုကို အဆက်မပြတ် အကဲဖြတ်ခြင်း  
- **Specification Compliance**: တိုးတက်လာသော MCP လုံခြုံရေးစံနှုန်းများနှင့် ကိုက်ညီမှုရှိစေရန်  

---

## **Implementation Resources**

### **Official MCP Documentation**
- [MCP Specification (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)

### **Microsoft Security Solutions**
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure Key Vault](https://learn.microsoft.com/azure/key-vault/)

### **Security Standards**
- [OAuth 2.0 Security Best Practices (RFC 

**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မှားယွင်းမှုများ ပါဝင်နိုင်သည်ကို ကျေးဇူးပြု၍ သတိပြုပါ။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူပညာရှင်များမှ ဘာသာပြန်ဆိုမှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပာယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။