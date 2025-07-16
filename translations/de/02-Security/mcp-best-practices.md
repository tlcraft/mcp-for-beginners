<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:09:06+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "de"
}
-->
# MCP Sicherheits-Best Practices

Wenn Sie mit MCP-Servern arbeiten, befolgen Sie diese Sicherheits-Best Practices, um Ihre Daten, Infrastruktur und Nutzer zu schützen:

1. **Eingabevalidierung**: Validieren und bereinigen Sie Eingaben stets, um Injektionsangriffe und Confused Deputy-Probleme zu vermeiden.  
2. **Zugriffskontrolle**: Implementieren Sie eine angemessene Authentifizierung und Autorisierung für Ihren MCP-Server mit fein abgestuften Berechtigungen.  
3. **Sichere Kommunikation**: Verwenden Sie HTTPS/TLS für alle Kommunikationen mit Ihrem MCP-Server und ziehen Sie zusätzliche Verschlüsselung für sensible Daten in Betracht.  
4. **Rate Limiting**: Setzen Sie Rate Limiting ein, um Missbrauch, DoS-Angriffe zu verhindern und den Ressourcenverbrauch zu steuern.  
5. **Protokollierung und Überwachung**: Überwachen Sie Ihren MCP-Server auf verdächtige Aktivitäten und implementieren Sie umfassende Audit-Trails.  
6. **Sichere Speicherung**: Schützen Sie sensible Daten und Zugangsdaten durch geeignete Verschlüsselung im Ruhezustand.  
7. **Token-Management**: Verhindern Sie Token-Passthrough-Schwachstellen, indem Sie alle Modell-Eingaben und -Ausgaben validieren und bereinigen.  
8. **Sitzungsmanagement**: Implementieren Sie eine sichere Sitzungsverwaltung, um Session Hijacking und Fixation-Angriffe zu verhindern.  
9. **Sandboxing von Tool-Ausführungen**: Führen Sie Tool-Ausführungen in isolierten Umgebungen aus, um laterale Bewegungen bei Kompromittierung zu verhindern.  
10. **Regelmäßige Sicherheitsüberprüfungen**: Führen Sie periodische Sicherheitsprüfungen Ihrer MCP-Implementierungen und Abhängigkeiten durch.  
11. **Prompt-Validierung**: Scannen und filtern Sie sowohl Eingabe- als auch Ausgabe-Prompts, um Prompt Injection-Angriffe zu verhindern.  
12. **Authentifizierungsdelegation**: Nutzen Sie etablierte Identitätsanbieter, anstatt eigene Authentifizierungslösungen zu implementieren.  
13. **Berechtigungsumfang**: Setzen Sie granulare Berechtigungen für jedes Tool und jede Ressource um, basierend auf dem Prinzip der minimalen Rechte.  
14. **Datenminimierung**: Stellen Sie nur die minimal notwendigen Daten für jede Operation bereit, um die Angriffsfläche zu reduzieren.  
15. **Automatisierte Schwachstellen-Scans**: Scannen Sie Ihre MCP-Server und Abhängigkeiten regelmäßig auf bekannte Schwachstellen.

## Unterstützende Ressourcen für MCP Sicherheits-Best Practices

### Eingabevalidierung
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)  
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)  
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)  

### Zugriffskontrolle
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)  
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)  
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)  

### Sichere Kommunikation
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)  
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)  
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)  

### Rate Limiting
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)  
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)  
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)  

### Protokollierung und Überwachung
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)  
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)  
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)  

### Sichere Speicherung
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)  
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)  
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)  

### Token-Management
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)  
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)  
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)  

### Sitzungsmanagement
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)  
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)  
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)  

### Sandboxing von Tool-Ausführungen
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)  
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)  
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)  

### Regelmäßige Sicherheitsüberprüfungen
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)  
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)  
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)  

### Prompt-Validierung
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)  
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)  
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)  

### Authentifizierungsdelegation
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)  
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)  
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)  

### Berechtigungsumfang
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)  
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)  
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)  

### Datenminimierung
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)  
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)  
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)  

### Automatisierte Schwachstellen-Scans
- [GitHub Advanced Security](https://github.com/security/advanced-security)  
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)  
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Haftungsausschluss**:  
Dieses Dokument wurde mit dem KI-Übersetzungsdienst [Co-op Translator](https://github.com/Azure/co-op-translator) übersetzt. Obwohl wir uns um Genauigkeit bemühen, beachten Sie bitte, dass automatisierte Übersetzungen Fehler oder Ungenauigkeiten enthalten können. Das Originaldokument in seiner Ursprungssprache ist als maßgebliche Quelle zu betrachten. Für wichtige Informationen wird eine professionelle menschliche Übersetzung empfohlen. Wir übernehmen keine Haftung für Missverständnisse oder Fehlinterpretationen, die aus der Nutzung dieser Übersetzung entstehen.