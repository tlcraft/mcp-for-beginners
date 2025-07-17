<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T13:44:21+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "my"
}
-->
# MCP လုံခြုံရေး အကောင်းဆုံး လေ့လာမှုများ

MCP ဆာဗာများနှင့်အလုပ်လုပ်ရာတွင် သင့်ဒေတာ၊ အဆောက်အအုံနှင့် အသုံးပြုသူများကို ကာကွယ်ရန် အောက်ပါ လုံခြုံရေး အကောင်းဆုံး လေ့လာမှုများကို လိုက်နာပါ။

1. **အချက်အလက် စစ်ဆေးခြင်း** - ထိုးထွင်းတိုက်ခိုက်မှုများနှင့် confused deputy ပြဿနာများကို ကာကွယ်ရန် အချက်အလက်များကို အမြဲ စစ်ဆေးပြီး သန့်ရှင်းစေပါ။
2. **ဝင်ရောက်ခွင့် ထိန်းချုပ်မှု** - MCP ဆာဗာအတွက် မှန်ကန်သော အတည်ပြုခြင်းနှင့် ခွင့်ပြုချက်များကို အသေးစိတ် ထိန်းချုပ်ပါ။
3. **လုံခြုံသော ဆက်သွယ်မှု** - MCP ဆာဗာနှင့် ဆက်သွယ်ရာတွင် HTTPS/TLS ကို အသုံးပြု၍ အထူးသတိထားရမည့် ဒေတာများအတွက် ထပ်မံ စာလုံးကူးခြင်း ထည့်သွင်းစဉ်းစားပါ။
4. **နှုန်းထား ကန့်သတ်ခြင်း** - မတရားအသုံးပြုမှု၊ DoS တိုက်ခိုက်မှုများကို ကာကွယ်ရန်နှင့် အရင်းအမြစ် စီမံခန့်ခွဲမှုအတွက် နှုန်းထား ကန့်သတ်မှုကို အကောင်အထည်ဖော်ပါ။
5. **မှတ်တမ်းတင်ခြင်းနှင့် စောင့်ကြည့်ခြင်း** - MCP ဆာဗာတွင် သံသယဖြစ်စေသော လှုပ်ရှားမှုများကို စောင့်ကြည့်ပြီး လုံးလုံးလေးလေး စစ်ဆေးမှု မှတ်တမ်းများကို ထည့်သွင်းပါ။
6. **လုံခြုံသော သိမ်းဆည်းမှု** - အထူးသတိထားရမည့် ဒေတာများနှင့် လက်မှတ်များကို သင့်တော်သော စာလုံးကူးခြင်းဖြင့် ကာကွယ်ပါ။
7. **Token စီမံခန့်ခွဲမှု** - Token passthrough အားနည်းချက်များကို ကာကွယ်ရန် မော်ဒယ်၏ အချက်အလက်များအားလုံးကို စစ်ဆေးပြီး သန့်ရှင်းစေပါ။
8. **အစည်းအဝေး စီမံခန့်ခွဲမှု** - အစည်းအဝေး ခိုးယူခြင်းနှင့် အစည်းအဝေး တည်ငြိမ်မှု ချိုးဖောက်မှုများကို ကာကွယ်ရန် လုံခြုံသော အစည်းအဝေး စီမံခန့်ခွဲမှုကို အကောင်အထည်ဖော်ပါ။
9. **ကိရိယာ အကောင်အထည်ဖော်မှု Isolation** - ကိရိယာများကို သီးခြား ပတ်ဝန်းကျင်များတွင် လည်ပတ်စေ၍ ထိခိုက်မှုဖြစ်ပါက အခြားနေရာသို့ ရွေ့ပြောင်းမှုကို ကာကွယ်ပါ။
10. **ပုံမှန် လုံခြုံရေး စစ်ဆေးမှုများ** - MCP အကောင်အထည်ဖော်မှုများနှင့် မူလအရင်းအမြစ်များကို ပုံမှန် လုံခြုံရေး ပြန်လည်သုံးသပ်ပါ။
11. **Prompt စစ်ဆေးခြင်း** - Prompt ထည့်သွင်းခြင်းနှင့် ထုတ်ပေးခြင်းများအားလုံးကို စစ်ဆေးပြီး prompt injection တိုက်ခိုက်မှုများကို ကာကွယ်ပါ။
12. **အတည်ပြုခြင်း ကိုယ်စားလှယ်ပေးခြင်း** - ကိုယ်ပိုင် အတည်ပြုခြင်း မလုပ်ဘဲ ရှိပြီးသား အတည်ပြုသူများကို အသုံးပြုပါ။
13. **ခွင့်ပြုချက် အကွာအဝေး သတ်မှတ်ခြင်း** - ကိရိယာနှင့် အရင်းအမြစ် တစ်ခုချင်းစီအတွက် အနည်းဆုံး ခွင့်ပြုချက် မူဝါဒအတိုင်း အသေးစိတ် ခွင့်ပြုချက်များကို ထည့်သွင်းပါ။
14. **ဒေတာ လျော့နည်းစေခြင်း** - လုပ်ဆောင်ချက်တစ်ခုချင်းစီအတွက် လိုအပ်သည့် ဒေတာ အနည်းဆုံးကိုသာ ဖော်ပြ၍ အန္တရာယ်ကို လျော့နည်းစေပါ။
15. **အလိုအလျောက် အားနည်းချက် စစ်ဆေးခြင်း** - MCP ဆာဗာများနှင့် မူလအရင်းအမြစ်များကို ပုံမှန် အားနည်းချက်များအတွက် စစ်ဆေးပါ။

## MCP လုံခြုံရေး အကောင်းဆုံး လေ့လာမှုများအတွက် အထောက်အကူပြု အရင်းအမြစ်များ

### အချက်အလက် စစ်ဆေးခြင်း
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### ဝင်ရောက်ခွင့် ထိန်းချုပ်မှု
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### လုံခြုံသော ဆက်သွယ်မှု
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### နှုန်းထား ကန့်သတ်ခြင်း
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### မှတ်တမ်းတင်ခြင်းနှင့် စောင့်ကြည့်ခြင်း
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### လုံခြုံသော သိမ်းဆည်းမှု
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Token စီမံခန့်ခွဲမှု
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### အစည်းအဝေး စီမံခန့်ခွဲမှု
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### ကိရိယာ အကောင်အထည်ဖော်မှု Isolation
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### ပုံမှန် လုံခြုံရေး စစ်ဆေးမှုများ
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Prompt စစ်ဆေးခြင်း
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### အတည်ပြုခြင်း ကိုယ်စားလှယ်ပေးခြင်း
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### ခွင့်ပြုချက် အကွာအဝေး သတ်မှတ်ခြင်း
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### ဒေတာ လျော့နည်းစေခြင်း
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### အလိုအလျောက် အားနည်းချက် စစ်ဆေးခြင်း
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**အကြောင်းကြားချက်**  
ဤစာတမ်းကို AI ဘာသာပြန်ဝန်ဆောင်မှု [Co-op Translator](https://github.com/Azure/co-op-translator) ဖြင့် ဘာသာပြန်ထားပါသည်။ ကျွန်ုပ်တို့သည် တိကျမှန်ကန်မှုအတွက် ကြိုးစားသော်လည်း အလိုအလျောက် ဘာသာပြန်ခြင်းတွင် အမှားများ သို့မဟုတ် မှားယွင်းချက်များ ပါဝင်နိုင်ကြောင်း သတိပြုပါရန် မေတ္တာရပ်ခံအပ်ပါသည်။ မူရင်းစာတမ်းကို မိမိဘာသာစကားဖြင့်သာ တရားဝင်အရင်းအမြစ်အဖြစ် ယူဆသင့်ပါသည်။ အရေးကြီးသော အချက်အလက်များအတွက် လူ့ပညာရှင်များ၏ ပရော်ဖက်ရှင်နယ် ဘာသာပြန်ခြင်းကို အကြံပြုပါသည်။ ဤဘာသာပြန်ချက်ကို အသုံးပြုရာမှ ဖြစ်ပေါ်လာနိုင်သည့် နားလည်မှုမှားယွင်းမှုများအတွက် ကျွန်ုပ်တို့သည် တာဝန်မယူပါ။