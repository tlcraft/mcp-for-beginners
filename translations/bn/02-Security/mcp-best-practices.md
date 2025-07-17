<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:52:19+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "bn"
}
-->
# MCP সিকিউরিটি সেরা অনুশীলনসমূহ

MCP সার্ভার নিয়ে কাজ করার সময়, আপনার ডেটা, অবকাঠামো এবং ব্যবহারকারীদের সুরক্ষিত রাখতে নিম্নলিখিত সিকিউরিটি সেরা অনুশীলনগুলো অনুসরণ করুন:

1. **ইনপুট যাচাই**: ইনজেকশন আক্রমণ এবং বিভ্রান্ত ডেপুটি সমস্যাগুলো প্রতিরোধ করতে সবসময় ইনপুট যাচাই ও স্যানিটাইজ করুন।
2. **অ্যাক্সেস নিয়ন্ত্রণ**: আপনার MCP সার্ভারের জন্য সঠিক প্রমাণীকরণ এবং অনুমোদন প্রয়োগ করুন, সূক্ষ্ম-গ্রেনুলার পারমিশন সহ।
3. **নিরাপদ যোগাযোগ**: MCP সার্ভারের সাথে সব যোগাযোগে HTTPS/TLS ব্যবহার করুন এবং সংবেদনশীল ডেটার জন্য অতিরিক্ত এনক্রিপশন বিবেচনা করুন।
4. **রেট সীমাবদ্ধকরণ**: অপব্যবহার, DoS আক্রমণ প্রতিরোধ এবং রিসোর্স ব্যবহারের নিয়ন্ত্রণের জন্য রেট সীমাবদ্ধকরণ প্রয়োগ করুন।
5. **লগিং এবং মনিটরিং**: সন্দেহজনক কার্যকলাপ পর্যবেক্ষণ করুন এবং বিস্তৃত অডিট ট্রেইল বাস্তবায়ন করুন।
6. **নিরাপদ সংরক্ষণ**: সংবেদনশীল ডেটা এবং ক্রেডেনশিয়াল সঠিক এনক্রিপশন দিয়ে সুরক্ষিত রাখুন।
7. **টোকেন ব্যবস্থাপনা**: টোকেন পাসথ্রু দুর্বলতা প্রতিরোধ করতে সব মডেল ইনপুট এবং আউটপুট যাচাই ও স্যানিটাইজ করুন।
8. **সেশন ব্যবস্থাপনা**: সেশন হাইজ্যাকিং এবং ফিক্সেশন আক্রমণ প্রতিরোধে নিরাপদ সেশন হ্যান্ডলিং প্রয়োগ করুন।
9. **টুল এক্সিকিউশন স্যান্ডবক্সিং**: যদি কোনো কম্প্রোমাইজ হয়, তাহলে পার্শ্ববর্তী গতিবিধি রোধ করতে টুল এক্সিকিউশনগুলো আলাদা পরিবেশে চালান।
10. **নিয়মিত সিকিউরিটি অডিট**: আপনার MCP ইমপ্লিমেন্টেশন এবং ডিপেন্ডেন্সিগুলোর সময়ে সময়ে সিকিউরিটি পর্যালোচনা করুন।
11. **প্রম্পট যাচাই**: প্রম্পট ইনজেকশন আক্রমণ প্রতিরোধে ইনপুট এবং আউটপুট প্রম্পট উভয়ই স্ক্যান এবং ফিল্টার করুন।
12. **প্রমাণীকরণ ডেলিগেশন**: কাস্টম প্রমাণীকরণ তৈরি করার পরিবর্তে প্রতিষ্ঠিত আইডেন্টিটি প্রোভাইডার ব্যবহার করুন।
13. **পারমিশন স্কোপিং**: প্রতিটি টুল এবং রিসোর্সের জন্য সর্বনিম্ন প্রিভিলেজ নীতিমালা অনুসারে সূক্ষ্ম পারমিশন প্রয়োগ করুন।
14. **ডেটা মিনিমাইজেশন**: প্রতিটি অপারেশনের জন্য প্রয়োজনীয় সর্বনিম্ন ডেটা প্রকাশ করুন যাতে ঝুঁকি কমে।
15. **স্বয়ংক্রিয় দুর্বলতা স্ক্যানিং**: আপনার MCP সার্ভার এবং ডিপেন্ডেন্সিগুলো নিয়মিত পরিচিত দুর্বলতার জন্য স্ক্যান করুন।

## MCP সিকিউরিটির সেরা অনুশীলনের জন্য সহায়ক সম্পদসমূহ

### ইনপুট যাচাই
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### অ্যাক্সেস নিয়ন্ত্রণ
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### নিরাপদ যোগাযোগ
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### রেট সীমাবদ্ধকরণ
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### লগিং এবং মনিটরিং
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### নিরাপদ সংরক্ষণ
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### টোকেন ব্যবস্থাপনা
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### সেশন ব্যবস্থাপনা
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### টুল এক্সিকিউশন স্যান্ডবক্সিং
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### নিয়মিত সিকিউরিটি অডিট
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### প্রম্পট যাচাই
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### প্রমাণীকরণ ডেলিগেশন
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### পারমিশন স্কোপিং
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### ডেটা মিনিমাইজেশন
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### স্বয়ংক্রিয় দুর্বলতা স্ক্যানিং
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**অস্বীকৃতি**:  
এই নথিটি AI অনুবাদ সেবা [Co-op Translator](https://github.com/Azure/co-op-translator) ব্যবহার করে অনূদিত হয়েছে। আমরা যথাসাধ্য সঠিকতার চেষ্টা করি, তবে স্বয়ংক্রিয় অনুবাদে ত্রুটি বা অসঙ্গতি থাকতে পারে। মূল নথিটি তার নিজস্ব ভাষায়ই কর্তৃত্বপূর্ণ উৎস হিসেবে বিবেচিত হওয়া উচিত। গুরুত্বপূর্ণ তথ্যের জন্য পেশাদার মানব অনুবাদ গ্রহণ করার পরামর্শ দেওয়া হয়। এই অনুবাদের ব্যবহারে সৃষ্ট কোনো ভুল বোঝাবুঝি বা ভুল ব্যাখ্যার জন্য আমরা দায়ী নই।