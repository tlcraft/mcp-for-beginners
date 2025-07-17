<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-17T01:52:36+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "mr"
}
-->
# MCP सुरक्षा सर्वोत्तम पद्धती

MCP सर्व्हरवर काम करताना, तुमचा डेटा, पायाभूत सुविधा आणि वापरकर्त्यांचे संरक्षण करण्यासाठी खालील सुरक्षा सर्वोत्तम पद्धतींचे पालन करा:

1. **इनपुट व्हॅलिडेशन**: इंजेक्शन हल्ले आणि confused deputy समस्या टाळण्यासाठी नेहमी इनपुटची पडताळणी आणि स्वच्छता करा.
2. **अॅक्सेस कंट्रोल**: तुमच्या MCP सर्व्हरसाठी योग्य प्रमाणीकरण आणि अधिकृतता लागू करा, ज्यात सूक्ष्म परवानग्या असाव्यात.
3. **सुरक्षित संवाद**: तुमच्या MCP सर्व्हरशी सर्व संवाद HTTPS/TLS वापरून करा आणि संवेदनशील डेटासाठी अतिरिक्त एन्क्रिप्शनचा विचार करा.
4. **रेट लिमिटिंग**: गैरवापर, DoS हल्ले टाळण्यासाठी आणि संसाधन वापर नियंत्रित करण्यासाठी रेट लिमिटिंग लागू करा.
5. **लॉगिंग आणि मॉनिटरिंग**: संशयास्पद क्रियाकलापांसाठी तुमच्या MCP सर्व्हरवर लक्ष ठेवा आणि सखोल ऑडिट ट्रेल्स लागू करा.
6. **सुरक्षित संचयन**: संवेदनशील डेटा आणि क्रेडेन्शियल्स योग्य एन्क्रिप्शनसह सुरक्षित ठेवा.
7. **टोकन व्यवस्थापन**: सर्व मॉडेल इनपुट आणि आउटपुटची पडताळणी आणि स्वच्छता करून टोकन पासथ्रू कमकुवतपणा टाळा.
8. **सेशन व्यवस्थापन**: सेशन हायजॅकिंग आणि फिक्सेशन हल्ले टाळण्यासाठी सुरक्षित सेशन हाताळणी लागू करा.
9. **टूल एक्झिक्युशन सॅंडबॉक्सिंग**: जर संसाधन बिघडले तर साइडवे लॅटरल मूव्हमेंट टाळण्यासाठी टूल एक्झिक्युशन्स वेगळ्या वातावरणात चालवा.
10. **नियमित सुरक्षा तपासण्या**: तुमच्या MCP अंमलबजावणी आणि अवलंबित्वांची कालांतराने सुरक्षा पुनरावलोकने करा.
11. **प्रॉम्प्ट व्हॅलिडेशन**: प्रॉम्प्ट इंजेक्शन हल्ले टाळण्यासाठी इनपुट आणि आउटपुट प्रॉम्प्ट दोन्ही स्कॅन आणि फिल्टर करा.
12. **प्रमाणीकरण प्रतिनिधित्व**: कस्टम प्रमाणीकरणाऐवजी स्थापित ओळख प्रदात्यांचा वापर करा.
13. **परवानगी स्कोपिंग**: प्रत्येक टूल आणि संसाधनासाठी सूक्ष्म परवानग्या लागू करा, ज्यात किमान विशेषाधिकार तत्त्वे पाळली जातील.
14. **डेटा किमानकरण**: प्रत्येक ऑपरेशनसाठी आवश्यक किमान डेटा उघडा, ज्यामुळे धोका कमी होतो.
15. **स्वयंचलित कमकुवतपणा स्कॅनिंग**: तुमच्या MCP सर्व्हर आणि अवलंबित्वांवर नियमितपणे ज्ञात कमकुवतपणांसाठी स्कॅन करा.

## MCP सुरक्षा सर्वोत्तम पद्धतींसाठी सहाय्यक संसाधने

### इनपुट व्हॅलिडेशन
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### अॅक्सेस कंट्रोल
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### सुरक्षित संवाद
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### रेट लिमिटिंग
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### लॉगिंग आणि मॉनिटरिंग
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### सुरक्षित संचयन
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### टोकन व्यवस्थापन
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### सेशन व्यवस्थापन
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### टूल एक्झिक्युशन सॅंडबॉक्सिंग
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### नियमित सुरक्षा तपासण्या
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### प्रॉम्प्ट व्हॅलिडेशन
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### प्रमाणीकरण प्रतिनिधित्व
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### परवानगी स्कोपिंग
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### डेटा किमानकरण
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### स्वयंचलित कमकुवतपणा स्कॅनिंग
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**अस्वीकरण**:  
हा दस्तऐवज AI अनुवाद सेवा [Co-op Translator](https://github.com/Azure/co-op-translator) वापरून अनुवादित केला आहे. आम्ही अचूकतेसाठी प्रयत्नशील असलो तरी, कृपया लक्षात घ्या की स्वयंचलित अनुवादांमध्ये चुका किंवा अचूकतेची कमतरता असू शकते. मूळ दस्तऐवज त्याच्या स्थानिक भाषेत अधिकृत स्रोत मानला जावा. महत्त्वाच्या माहितीसाठी व्यावसायिक मानवी अनुवाद करण्याची शिफारस केली जाते. या अनुवादाच्या वापरामुळे उद्भवलेल्या कोणत्याही गैरसमजुती किंवा चुकीच्या अर्थलागी आम्ही जबाबदार नाही.