<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:09:58+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "hi"
}
-->
# MCP सुरक्षा सर्वोत्तम प्रथाएँ

जब आप MCP सर्वरों के साथ काम कर रहे हों, तो अपने डेटा, इन्फ्रास्ट्रक्चर और उपयोगकर्ताओं की सुरक्षा के लिए निम्नलिखित सुरक्षा सर्वोत्तम प्रथाओं का पालन करें:

1. **इनपुट वैलिडेशन**: हमेशा इनपुट को वैध और साफ़ करें ताकि इंजेक्शन हमलों और कन्फ्यूज्ड डिप्टी समस्याओं से बचा जा सके।
2. **एक्सेस कंट्रोल**: अपने MCP सर्वर के लिए उचित प्रमाणीकरण और प्राधिकरण लागू करें, जिसमें सूक्ष्म स्तर की अनुमतियाँ हों।
3. **सुरक्षित संचार**: MCP सर्वर के साथ सभी संचार के लिए HTTPS/TLS का उपयोग करें और संवेदनशील डेटा के लिए अतिरिक्त एन्क्रिप्शन जोड़ने पर विचार करें।
4. **रेट लिमिटिंग**: दुरुपयोग, DoS हमलों को रोकने और संसाधन उपयोग को नियंत्रित करने के लिए रेट लिमिटिंग लागू करें।
5. **लॉगिंग और मॉनिटरिंग**: संदिग्ध गतिविधियों के लिए अपने MCP सर्वर की निगरानी करें और व्यापक ऑडिट ट्रेल्स लागू करें।
6. **सुरक्षित भंडारण**: संवेदनशील डेटा और क्रेडेंशियल्स को उचित एन्क्रिप्शन के साथ सुरक्षित रखें।
7. **टोकन प्रबंधन**: टोकन पासथ्रू कमजोरियों को रोकने के लिए सभी मॉडल इनपुट और आउटपुट को वैध और साफ़ करें।
8. **सेशन प्रबंधन**: सेशन हाईजैकिंग और फिक्सेशन हमलों को रोकने के लिए सुरक्षित सेशन हैंडलिंग लागू करें।
9. **टूल निष्पादन सैंडबॉक्सिंग**: यदि कोई समझौता होता है तो पार्श्वीय आंदोलन को रोकने के लिए टूल निष्पादनों को अलग-थलग वातावरण में चलाएं।
10. **नियमित सुरक्षा ऑडिट**: अपने MCP कार्यान्वयन और निर्भरताओं की समय-समय पर सुरक्षा समीक्षा करें।
11. **प्रॉम्प्ट वैलिडेशन**: प्रॉम्प्ट इंजेक्शन हमलों को रोकने के लिए इनपुट और आउटपुट दोनों प्रॉम्प्ट्स को स्कैन और फ़िल्टर करें।
12. **प्रमाणीकरण प्रतिनिधित्व**: कस्टम प्रमाणीकरण लागू करने के बजाय स्थापित पहचान प्रदाताओं का उपयोग करें।
13. **अनुमति स्कोपिंग**: न्यूनतम विशेषाधिकार सिद्धांतों का पालन करते हुए प्रत्येक टूल और संसाधन के लिए सूक्ष्म अनुमतियाँ लागू करें।
14. **डेटा न्यूनिकरण**: जोखिम को कम करने के लिए प्रत्येक ऑपरेशन के लिए केवल आवश्यक न्यूनतम डेटा ही एक्सपोज़ करें।
15. **स्वचालित कमजोरियों का स्कैनिंग**: अपने MCP सर्वरों और निर्भरताओं को ज्ञात कमजोरियों के लिए नियमित रूप से स्कैन करें।

## MCP सुरक्षा सर्वोत्तम प्रथाओं के लिए सहायक संसाधन

### इनपुट वैलिडेशन
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### एक्सेस कंट्रोल
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### सुरक्षित संचार
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### रेट लिमिटिंग
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### लॉगिंग और मॉनिटरिंग
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### सुरक्षित भंडारण
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### टोकन प्रबंधन
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### सेशन प्रबंधन
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### टूल निष्पादन सैंडबॉक्सिंग
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### नियमित सुरक्षा ऑडिट
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### प्रॉम्प्ट वैलिडेशन
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### प्रमाणीकरण प्रतिनिधित्व
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### अनुमति स्कोपिंग
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### डेटा न्यूनिकरण
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### स्वचालित कमजोरियों का स्कैनिंग
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**अस्वीकरण**:  
यह दस्तावेज़ AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) का उपयोग करके अनुवादित किया गया है। जबकि हम सटीकता के लिए प्रयासरत हैं, कृपया ध्यान दें कि स्वचालित अनुवादों में त्रुटियाँ या अशुद्धियाँ हो सकती हैं। मूल दस्तावेज़ अपनी मूल भाषा में ही अधिकारिक स्रोत माना जाना चाहिए। महत्वपूर्ण जानकारी के लिए, पेशेवर मानव अनुवाद की सलाह दी जाती है। इस अनुवाद के उपयोग से उत्पन्न किसी भी गलतफहमी या गलत व्याख्या के लिए हम जिम्मेदार नहीं हैं।