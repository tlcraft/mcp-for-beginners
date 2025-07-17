<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:52:56+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "ne"
}
-->
# MCP सुरक्षा उत्तम अभ्यासहरू

MCP सर्भरहरूसँग काम गर्दा, तपाईंको डेटा, पूर्वाधार, र प्रयोगकर्ताहरूलाई सुरक्षित राख्न यी सुरक्षा उत्तम अभ्यासहरू पालना गर्नुहोस्:

1. **इनपुट मान्यकरण**: इन्जेक्शन आक्रमण र भ्रमित डिप्युटी समस्याहरूबाट बच्न सधैं इनपुटहरू मान्य र सफा गर्नुहोस्।
2. **पहुँच नियन्त्रण**: तपाईंको MCP सर्भरका लागि उपयुक्त प्रमाणीकरण र प्राधिकरण लागू गर्नुहोस्, जसमा सूक्ष्म अनुमति व्यवस्थापन समावेश होस्।
3. **सुरक्षित सञ्चार**: तपाईंको MCP सर्भरसँग सबै सञ्चारका लागि HTTPS/TLS प्रयोग गर्नुहोस् र संवेदनशील डेटाका लागि थप इन्क्रिप्शन थप्न विचार गर्नुहोस्।
4. **दर सीमांकन**: दुरुपयोग, DoS आक्रमणहरू रोक्न र स्रोतको उपभोग व्यवस्थापन गर्न दर सीमांकन लागू गर्नुहोस्।
5. **लगिङ र अनुगमन**: तपाईंको MCP सर्भरमा शंकास्पद गतिविधिहरू अनुगमन गर्नुहोस् र व्यापक अडिट ट्रेलहरू लागू गर्नुहोस्।
6. **सुरक्षित भण्डारण**: संवेदनशील डेटा र प्रमाणपत्रहरूलाई उचित इन्क्रिप्शनका साथ सुरक्षित राख्नुहोस्।
7. **टोकन व्यवस्थापन**: सबै मोडेल इनपुट र आउटपुटहरूलाई मान्य र सफा गरेर टोकन पासथ्रू कमजोरीहरू रोक्नुहोस्।
8. **सेसन व्यवस्थापन**: सेसन हाइज्याकिङ र फिक्सेसन आक्रमणहरू रोक्न सुरक्षित सेसन ह्यान्डलिङ लागू गर्नुहोस्।
9. **टुल कार्यान्वयन स्यान्डबक्सिङ**: यदि कम्प्रोमाइज भएमा पार्श्वगत आन्दोलन रोक्न टुल कार्यान्वयनहरू अलग्गै वातावरणमा चलाउनुहोस्।
10. **नियमित सुरक्षा अडिटहरू**: तपाईंको MCP कार्यान्वयन र निर्भरताहरूको आवधिक सुरक्षा समीक्षा गर्नुहोस्।
11. **प्रम्प्ट मान्यकरण**: प्रम्प्ट इन्जेक्शन आक्रमणहरू रोक्न इनपुट र आउटपुट दुवै प्रम्प्टहरू स्क्यान र फिल्टर गर्नुहोस्।
12. **प्रमाणीकरण प्रतिनिधित्व**: कस्टम प्रमाणीकरण लागू गर्नुको सट्टा स्थापित पहिचान प्रदायकहरू प्रयोग गर्नुहोस्।
13. **अनुमति स्कोपिङ**: न्यूनतम विशेषाधिकार सिद्धान्त अनुसार प्रत्येक टुल र स्रोतका लागि सूक्ष्म अनुमति लागू गर्नुहोस्।
14. **डेटा न्यूनिकरण**: जोखिम सतह घटाउन प्रत्येक अपरेशनका लागि आवश्यक न्यूनतम डेटा मात्र उपलब्ध गराउनुहोस्।
15. **स्वचालित कमजोरी स्क्यानिङ**: तपाईंका MCP सर्भरहरू र निर्भरताहरूलाई नियमित रूपमा ज्ञात कमजोरीहरूको लागि स्क्यान गर्नुहोस्।

## MCP सुरक्षा उत्तम अभ्यासहरूका लागि सहयोगी स्रोतहरू

### इनपुट मान्यकरण
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### पहुँच नियन्त्रण
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### सुरक्षित सञ्चार
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### दर सीमांकन
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### लगिङ र अनुगमन
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### सुरक्षित भण्डारण
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### टोकन व्यवस्थापन
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### सेसन व्यवस्थापन
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### टुल कार्यान्वयन स्यान्डबक्सिङ
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### नियमित सुरक्षा अडिटहरू
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### प्रम्प्ट मान्यकरण
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### प्रमाणीकरण प्रतिनिधित्व
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### अनुमति स्कोपिङ
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### डेटा न्यूनिकरण
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### स्वचालित कमजोरी स्क्यानिङ
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**अस्वीकरण**:  
यो दस्तावेज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) प्रयोग गरी अनुवाद गरिएको हो। हामी शुद्धताका लागि प्रयासरत छौं, तर कृपया ध्यान दिनुहोस् कि स्वचालित अनुवादमा त्रुटि वा अशुद्धता हुनसक्छ। मूल दस्तावेज यसको मूल भाषामा नै अधिकारिक स्रोत मानिनुपर्छ। महत्वपूर्ण जानकारीका लागि व्यावसायिक मानव अनुवाद सिफारिस गरिन्छ। यस अनुवादको प्रयोगबाट उत्पन्न कुनै पनि गलतफहमी वा गलत व्याख्याका लागि हामी जिम्मेवार छैनौं।