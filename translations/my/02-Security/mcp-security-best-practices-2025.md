<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "057dd5cc6bea6434fdb788e6c93f3f3d",
  "translation_date": "2025-08-18T23:23:38+00:00",
  "source_file": "02-Security/mcp-security-best-practices-2025.md",
  "language_code": "my"
}
-->
# MCP လုံခြုံရေးအကောင်းဆုံးအကြံပြုချက်များ - ၂၀၂၅ ခုနှစ် ဩဂုတ်လ အပ်ဒိတ်

> **အရေးကြီး**: ဒီစာရွက်စာတမ်းမှာ [MCP Specification 2025-06-18](https://spec.modelcontextprotocol.io/specification/2025-06-18/) လုံခြုံရေးလိုအပ်ချက်များနှင့် [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices) အတည်ပြုထားသောအကြံပြုချက်များကို အဓိကထားရေးသားထားပါတယ်။ အမြဲတမ်းလက်ရှိ specification ကို ကိုးကားပြီး အပ်ဒိတ်အချက်အလက်များကို လိုက်နာပါ။

## MCP အကောင်အထည်ဖော်မှုများအတွက် မရှိမဖြစ်လိုအပ်သော လုံခြုံရေးအလေ့အကျင့်များ

Model Context Protocol သည် ရိုးရိုး software လုံခြုံရေးထက် ကျော်လွန်သော ထူးခြားသော လုံခြုံရေးစိန်ခေါ်မှုများကို ဖန်တီးပေးသည်။ ဒီအလေ့အကျင့်များသည် အခြေခံလုံခြုံရေးလိုအပ်ချက်များနှင့် MCP-specific အန္တရာယ်များ (ဥပမာ - prompt injection, tool poisoning, session hijacking, confused deputy problems, token passthrough vulnerabilities) ကို ကိုင်တွယ်ရန် ရည်ရွယ်ထားသည်။

### **မရှိမဖြစ်လိုအပ်သော လုံခြုံရေးလိုအပ်ချက်များ**

**MCP Specification မှ အရေးကြီးလိုအပ်ချက်များ:**

> **MUST NOT**: MCP servers သည် MCP server အတွက် ထုတ်ပေးထားခြင်းမရှိသော tokens များကို လက်ခံ **မရ**ပါ။
> 
> **MUST**: Authorization ကို အကောင်အထည်ဖော်သော MCP servers သည် **အားလုံးသော** inbound requests များကို စစ်ဆေးရမည်။
>  
> **MUST NOT**: MCP servers သည် authentication အတွက် sessions များကို အသုံးပြု **မရ**ပါ။
>
> **MUST**: Static client IDs ကို အသုံးပြုသော MCP proxy servers သည် dynamically registered client တစ်ခုစီအတွက် အသုံးပြုသူ၏ သဘောတူညီမှုကို ရယူရမည်။

---

## ၁။ **Token လုံခြုံရေးနှင့် Authentication**

**Authentication & Authorization ထိန်းချုပ်မှုများ:**
   - **ခိုင်မာသော Authorization စစ်ဆေးမှု**: MCP server authorization logic ကို စစ်ဆေးပြီး သတ်မှတ်ထားသော အသုံးပြုသူများနှင့် clients များသာ ရရှိခွင့်ရှိစေရန် သေချာပါစေ။
   - **အပြင် Identity Provider ပေါင်းစည်းမှု**: Microsoft Entra ID ကဲ့သို့သော အတည်ပြုထားသော identity providers များကို အသုံးပြုပါ၊ ကိုယ်ပိုင် authentication system မထည့်သွင်းပါနှင့်။
   - **Token Audience စစ်ဆေးမှု**: Tokens များကို MCP server အတွက် ထုတ်ပေးထားကြောင်း အမြဲစစ်ဆေးပါ - upstream tokens များကို လက်ခံမထားပါနှင့်။
   - **Token Lifecycle ထိန်းချုပ်မှု**: Token rotation, expiration policies များကို လုံခြုံစွာ အကောင်အထည်ဖော်ပြီး token replay attacks များကို ကာကွယ်ပါ။

**Token ကို ကာကွယ်ထားသော သိမ်းဆည်းမှု:**
   - Azure Key Vault သို့မဟုတ် အလားတူသော လုံခြုံသော credential stores များကို အသုံးပြုပါ။
   - Token များကို rest နှင့် transit နှစ်ခုစလုံးတွင် စာဝှက်ထားပါ။
   - Regular credential rotation နှင့် unauthorized access များအတွက် စောင့်ကြည့်မှုများ ပြုလုပ်ပါ။

## ၂။ **Session စီမံခန့်ခွဲမှုနှင့် Transport လုံခြုံရေး**

**Session လုံခြုံရေးအလေ့အကျင့်များ:**
   - **Cryptographically Secure Session IDs**: Secure random number generators များဖြင့် ဖန်တီးထားသော လုံခြုံသော session IDs များကို အသုံးပြုပါ။
   - **အသုံးပြုသူအထူးသတ်မှတ်မှု**: Session IDs များကို `<user_id>:<session_id>` ကဲ့သို့သော format များဖြင့် အသုံးပြုသူ၏ identity နှင့် ချိတ်ဆက်ထားပါ။
   - **Session Lifecycle စီမံခန့်ခွဲမှု**: Expiration, rotation, invalidation များကို သင့်တော်စွာ အကောင်အထည်ဖော်ပါ။
   - **HTTPS/TLS အတည်ပြုမှု**: Session ID interception မဖြစ်စေရန် communication အားလုံးအတွက် HTTPS ကို မဖြစ်မနေ အသုံးပြုပါ။

**Transport Layer လုံခြုံရေး:**
   - TLS 1.3 ကို အလားအလာရှိသည့်နေရာတွင် configure လုပ်ပါ၊ certificate management ကို သေချာစွာ ပြုလုပ်ပါ။
   - အရေးကြီးသော ချိတ်ဆက်မှုများအတွက် certificate pinning ကို အကောင်အထည်ဖော်ပါ။
   - Regular certificate rotation နှင့် သက်တမ်းစစ်ဆေးမှုများ ပြုလုပ်ပါ။

## ၃။ **AI-Specific အန္တရာယ်ကာကွယ်မှု** 🤖

**Prompt Injection ကာကွယ်မှု:**
   - **Microsoft Prompt Shields**: မကောင်းသောညွှန်ကြားချက်များကို ရှာဖွေခြင်းနှင့် စစ်ထုတ်ခြင်းအတွက် AI Prompt Shields များကို အသုံးပြုပါ။
   - **Input Sanitization**: Injection attacks နှင့် confused deputy problems များကို ကာကွယ်ရန် အားလုံးသော inputs များကို စစ်ဆေးပြီး သန့်စင်ပါ။
   - **Content Boundaries**: Trusted instructions နှင့် အပြင် content များကို ခွဲခြားရန် delimiter နှင့် datamarking systems များကို အသုံးပြုပါ။

**Tool Poisoning ကာကွယ်မှု:**
   - **Tool Metadata စစ်ဆေးမှု**: Tool definitions များအတွက် integrity checks များကို အကောင်အထည်ဖော်ပြီး မထင်မှတ်ထားသော ပြောင်းလဲမှုများကို စောင့်ကြည့်ပါ။
   - **Dynamic Tool Monitoring**: Runtime အပြုအမူများကို စောင့်ကြည့်ပြီး မထင်မှတ်ထားသော execution patterns များအတွက် alerting များကို ထည့်သွင်းပါ။
   - **Approval Workflows**: Tool ပြင်ဆင်မှုများနှင့် စွမ်းဆောင်ရည်ပြောင်းလဲမှုများအတွက် အသုံးပြုသူ၏ သဘောတူညီမှုကို လိုအပ်ပါသည်။

## ၄။ **Access Control & Permissions**

**Principle of Least Privilege:**
   - MCP servers များကို လိုအပ်သော အနည်းဆုံး permissions များသာ ပေးပါ။
   - Role-based access control (RBAC) ကို အသုံးပြုပြီး အပြည့်အဝ ထိန်းချုပ်မှုများကို အကောင်အထည်ဖော်ပါ။
   - Regular permission reviews နှင့် privilege escalation များအတွက် စောင့်ကြည့်မှုများ ပြုလုပ်ပါ။

**Runtime Permission ထိန်းချုပ်မှုများ:**
   - Resource exhaustion attacks များကို ကာကွယ်ရန် resource limits များကို အသုံးပြုပါ။
   - Tool execution environments များအတွက် container isolation ကို အသုံးပြုပါ။
   - Administrative functions များအတွက် just-in-time access ကို အကောင်အထည်ဖော်ပါ။

## ၅။ **Content လုံခြုံရေးနှင့် စောင့်ကြည့်မှု**

**Content လုံခြုံရေးအကောင်အထည်ဖော်မှု:**
   - **Azure Content Safety Integration**: Azure Content Safety ကို အသုံးပြုပြီး အန္တရာယ်ရှိသော content, jailbreak ကြိုးစားမှုများနှင့် policy ချိုးဖောက်မှုများကို ရှာဖွေပါ။
   - **Behavioral Analysis**: MCP server နှင့် tool execution အပြုအမူများကို စောင့်ကြည့်ပြီး အထူးပြောင်းလဲမှုများကို ရှာဖွေပါ။
   - **Comprehensive Logging**: Authentication ကြိုးစားမှုများ, tool invocations, security events များအားလုံးကို tamper-proof storage တွင် မှတ်တမ်းတင်ပါ။

**ဆက်လက်စောင့်ကြည့်မှု:**
   - မထင်မှတ်ထားသော pattern များနှင့် unauthorized access ကြိုးစားမှုများအတွက် real-time alerting များကို ထည့်သွင်းပါ။
   - SIEM systems များနှင့် ပေါင်းစည်းပြီး centralized security event management ကို အကောင်အထည်ဖော်ပါ။
   - MCP အကောင်အထည်ဖော်မှုများအတွက် regular security audits နှင့် penetration testing များ ပြုလုပ်ပါ။

## ၆။ **Supply Chain လုံခြုံရေး**

**Component Verification:**
   - **Dependency Scanning**: Software dependencies နှင့် AI components အားလုံးအတွက် automated vulnerability scanning ကို အသုံးပြုပါ။
   - **Provenance Validation**: Models, data sources, external services များ၏ မူလအရင်းအမြစ်, လိုင်စင်နှင့် integrity ကို စစ်ဆေးပါ။
   - **Signed Packages**: Cryptographically signed packages များကို အသုံးပြုပြီး deployment မပြုမီ signatures များကို စစ်ဆေးပါ။

**Secure Development Pipeline:**
   - **GitHub Advanced Security**: Secret scanning, dependency analysis, CodeQL static analysis များကို အကောင်အထည်ဖော်ပါ။
   - **CI/CD Security**: Automated deployment pipelines အတွင်း security validation များကို ထည့်သွင်းပါ။
   - **Artifact Integrity**: Deployed artifacts နှင့် configurations များအတွက် cryptographic verification ကို အကောင်အထည်ဖော်ပါ။

## ၇။ **OAuth လုံခြုံရေးနှင့် Confused Deputy ကာကွယ်မှု**

**OAuth 2.1 အကောင်အထည်ဖော်မှု:**
   - **PKCE အကောင်အထည်ဖော်မှု**: Authorization requests အားလုံးအတွက် Proof Key for Code Exchange (PKCE) ကို အသုံးပြုပါ။
   - **အသုံးပြုသူ သဘောတူညီမှု**: Confused deputy attacks များကို ကာကွယ်ရန် dynamically registered client တစ်ခုစီအတွက် အသုံးပြုသူ၏ သဘောတူညီမှုကို ရယူပါ။
   - **Redirect URI စစ်ဆေးမှု**: Redirect URIs နှင့် client identifiers များကို တိကျစွာ စစ်ဆေးပါ။

**Proxy လုံခြုံရေး:**
   - Static client ID exploitation မှတဆင့် authorization bypass မဖြစ်စေရန် ကာကွယ်ပါ။
   - Third-party API access အတွက် သင့်တော်သော consent workflows များကို အကောင်အထည်ဖော်ပါ။
   - Authorization code ခိုးယူမှုနှင့် unauthorized API access များအတွက် စောင့်ကြည့်ပါ။

## ၈။ **အန္တရာယ်တုံ့ပြန်မှုနှင့် ပြန်လည်ထူထောင်မှု**

**အမြန်တုံ့ပြန်နိုင်စွမ်းများ:**
   - **Automated Response**: Credential rotation နှင့် အန္တရာယ်ကာကွယ်မှုအတွက် automated systems များကို အကောင်အထည်ဖော်ပါ။
   - **Rollback Procedures**: Known-good configurations နှင့် components များသို့ အမြန်ပြန်လည်ပြောင်းနိုင်စွမ်းရှိပါစေ။
   - **Forensic Capabilities**: Incident investigation အတွက် အသေးစိတ် audit trails နှင့် logging များကို ထည့်သွင်းပါ။

**ဆက်သွယ်မှုနှင့် ပေါင်းစည်းမှု:**
   - လုံခြုံရေးအန္တရာယ်များအတွက် ရှင်းလင်းသော escalation လုပ်ငန်းစဉ်များကို သတ်မှတ်ပါ။
   - အဖွဲ့အစည်း၏ incident response teams များနှင့် ပေါင်းစည်းပါ။
   - Regular security incident simulations နှင့် tabletop exercises များကို ပြုလုပ်ပါ။

## ၉။ **အညွှန်းနှင့် အုပ်ချုပ်မှု**

**ဥပဒေလိုက်နာမှု:**
   - MCP အကောင်အထည်ဖော်မှုများသည် စက်မှုလုပ်ငန်းအထူးလိုအပ်ချက်များ (ဥပမာ - GDPR, HIPAA, SOC 2) ကို လိုက်နာရမည်။
   - AI data processing အတွက် data classification နှင့် privacy controls များကို အကောင်အထည်ဖော်ပါ။
   - Compliance auditing အတွက် ပြည့်စုံသော documentation များကို ထိန်းသိမ်းပါ။

**ပြောင်းလဲမှု စီမံခန့်ခွဲမှု:**
   - MCP system ပြင်ဆင်မှုများအတွက် တရားဝင် security review လုပ်ငန်းစဉ်များကို ထည့်သွင်းပါ။
   - Configuration ပြောင်းလဲမှုများအတွက် version control နှင့် အတည်ပြုလုပ်ငန်းစဉ်များကို အသုံးပြုပါ။
   - Regular compliance assessments နှင့် gap analysis များကို ပြုလုပ်ပါ။

## ၁၀။ **အဆင့်မြင့် လုံခြုံရေးထိန်းချုပ်မှုများ**

**Zero Trust Architecture:**
   - **Never Trust, Always Verify**: အသုံးပြုသူများ, devices, connections များကို အမြဲတမ်းစစ်ဆေးပါ။
   - **Micro-segmentation**: MCP components တစ်ခုစီကို သီးခြားထားသော network controls များကို အသုံးပြုပါ။
   - **Conditional Access**: လက်ရှိ context နှင့် အပြုအမူအခြေပြု risk-based access controls များကို အသုံးပြုပါ။

**Runtime Application Protection:**
   - **Runtime Application Self-Protection (RASP)**: Real-time threat detection အတွက် RASP နည်းလမ်းများကို အသုံးပြုပါ။
   - **Application Performance Monitoring**: အန္တရာယ်များကို ပြသနိုင်သော performance anomalies များကို စောင့်ကြည့်ပါ။
   - **Dynamic Security Policies**: လက်ရှိအန္တရာယ်အခြေအနေအပေါ်မူတည်၍ လုံခြုံရေးမူဝါဒများကို ပြောင်းလဲပါ။

## ၁၁။ **Microsoft လုံခြုံရေး Ecosystem ပေါင်းစည်းမှု**

**Microsoft လုံခြုံရေးအပြည့်အစုံ:**
   - **Microsoft Defender for Cloud**: MCP workloads များအတွက် Cloud security posture management
   - **Azure Sentinel**: အဆင့်မြင့်အန္တရာယ်ရှာဖွေမှုအတွက် Cloud-native SIEM နှင့် SOAR စွမ်းရည်များ
   - **Microsoft Purview**: AI workflows နှင့် data sources များအတွက် Data governance နှင့် compliance

**Identity & Access Management:**
   - **Microsoft Entra ID**: Conditional access policies ဖြင့် Enterprise identity management
   - **Privileged Identity Management (PIM)**: Just-in-time access နှင့် administrative functions များအတွက် အတည်ပြုလုပ်ငန်းစဉ်များ
   - **Identity Protection**: Risk-based conditional access နှင့် automated threat response

## ၁၂။ **လုံခြုံရေးဆက်လက်တိုးတက်မှု**

**လက်ရှိအခြေအနေကို လိုက်နာခြင်း:**
   - **Specification Monitoring**: MCP specification အပ်ဒိတ်များနှင့် လုံခြုံရေးအကြံပြုချက်များကို Regular review ပြုလုပ်ပါ။
   - **Threat Intelligence**: AI-specific threat feeds နှင့် indicators of compromise များကို ပေါင်းစည်းပါ။
   - **Security Community Engagement**: MCP လုံခြုံရေးအသိုင်းအဝိုင်းနှင့် vulnerability disclosure programs များတွင် တက်ကြွစွာ ပါဝင်ပါ။

**Adaptive Security:**
   - **Machine Learning Security**: Attack patterns အသစ်များကို ရှာဖွေရန် ML-based anomaly detection ကို အသုံးပြုပါ။
   - **Predictive Security Analytics**: အန္တရာယ်များကို ကြိုတင်သိရှိရန် predictive models များကို အသုံးပြုပါ။
   - **Security Automation**: Threat intelligence နှင့် specification ပြောင်းလဲမှုများအပေါ်မူတည်၍ လုံခြုံရေးမူဝါဒများကို အလိုအလျောက် အပ်ဒိတ်လုပ်ပါ။

---

## **အရေးကြီးသော လုံခြုံရေးအရင်းအမြစ်များ**

### **တရားဝင် MCP စာရွက်စာတမ်းများ**
- [MCP Specification (2025-06-18)](https://spec.modelcontextprotocol.io/specification/2025-06-18/)
- [MCP Security Best Practices](https://modelcontextprotocol.io/specification/2025-06-18/basic/security_best_practices)
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/2025-06-18/basic/authorization)

### **Microsoft လုံခြုံရေးဖြေရှင်းချက်များ**
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Microsoft Entra ID Security](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [GitHub Advanced Security](https://github.com/security/advanced-security)

### **လုံခြုံရေးစံနှုန်းများ**
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [OWASP Top 10 for Large Language Models](https://genai.owasp.org/)
- [NIST AI Risk Management Framework](https://www.nist.gov/itl/ai-risk-management-framework)



**ဝက်ဘ်ဆိုက်မှတ်ချက်**:  
ဤစာရွက်စာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ကို အသုံးပြု၍ ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားနေပါသော်လည်း၊ အလိုအလျောက်ဘာသာပြန်ဆိုမှုများတွင် အမှားများ သို့မဟုတ် မတိကျမှုများ ပါဝင်နိုင်ပါသည်။ မူရင်းစာရွက်စာတမ်းကို ၎င်း၏ မူလဘာသာစကားဖြင့် အာဏာတည်သောရင်းမြစ်အဖြစ် သတ်မှတ်သင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူပညာရှင်များမှ ဘာသာပြန်ဆိုမှုကို အကြံပြုပါသည်။ ဤဘာသာပြန်ဆိုမှုကို အသုံးပြုခြင်းမှ ဖြစ်ပေါ်လာသော နားလည်မှုမှားများ သို့မဟုတ် အဓိပ္ပါယ်မှားများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။