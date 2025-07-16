<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:07:49+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "fr"
}
-->
# Bonnes pratiques de sécurité MCP

Lorsque vous travaillez avec des serveurs MCP, suivez ces bonnes pratiques de sécurité pour protéger vos données, votre infrastructure et vos utilisateurs :

1. **Validation des entrées** : Validez et nettoyez toujours les entrées pour éviter les attaques par injection et les problèmes de délégué confus.
2. **Contrôle d’accès** : Mettez en place une authentification et une autorisation appropriées pour votre serveur MCP avec des permissions granulaires.
3. **Communication sécurisée** : Utilisez HTTPS/TLS pour toutes les communications avec votre serveur MCP et envisagez d’ajouter un chiffrement supplémentaire pour les données sensibles.
4. **Limitation du débit** : Implémentez une limitation du débit pour prévenir les abus, les attaques par déni de service (DoS) et gérer la consommation des ressources.
5. **Journalisation et surveillance** : Surveillez votre serveur MCP pour détecter toute activité suspecte et mettez en place des pistes d’audit complètes.
6. **Stockage sécurisé** : Protégez les données sensibles et les identifiants avec un chiffrement approprié au repos.
7. **Gestion des tokens** : Évitez les vulnérabilités liées au passage de tokens en validant et en nettoyant toutes les entrées et sorties des modèles.
8. **Gestion des sessions** : Mettez en œuvre une gestion sécurisée des sessions pour prévenir le détournement et la fixation de session.
9. **Sandboxing de l’exécution des outils** : Exécutez les outils dans des environnements isolés pour empêcher les mouvements latéraux en cas de compromission.
10. **Audits de sécurité réguliers** : Réalisez des revues de sécurité périodiques de vos implémentations MCP et de leurs dépendances.
11. **Validation des prompts** : Analysez et filtrez les prompts d’entrée et de sortie pour éviter les attaques par injection de prompt.
12. **Délégation d’authentification** : Utilisez des fournisseurs d’identité reconnus plutôt que de créer une authentification personnalisée.
13. **Ciblage des permissions** : Appliquez des permissions granulaires pour chaque outil et ressource en suivant le principe du moindre privilège.
14. **Minimisation des données** : Ne fournissez que les données strictement nécessaires à chaque opération pour réduire la surface de risque.
15. **Analyse automatisée des vulnérabilités** : Scannez régulièrement vos serveurs MCP et leurs dépendances pour détecter les vulnérabilités connues.

## Ressources complémentaires pour les bonnes pratiques de sécurité MCP

### Validation des entrées
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Preventing Prompt Injection in MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Azure Content Safety Implementation](./azure-content-safety-implementation.md)

### Contrôle d’accès
- [MCP Authorization Specification](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Using Microsoft Entra ID with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Communication sécurisée
- [Transport Layer Security (TLS) Best Practices](https://learn.microsoft.com/security/engineering/solving-tls)
- [MCP Transport Security Guidelines](https://modelcontextprotocol.io/docs/concepts/transports)
- [End-to-End Encryption for AI Workloads](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Limitation du débit
- [API Rate Limiting Patterns](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementing Token Bucket Rate Limiting](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Rate Limiting in Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Journalisation et surveillance
- [Centralized Logging for AI Systems](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Audit Logging Best Practices](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor for AI Workloads](https://learn.microsoft.com/azure/azure-monitor/overview)

### Stockage sécurisé
- [Azure Key Vault for Credential Storage](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Encrypting Sensitive Data at Rest](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Use Secure Token Storage and Encrypt Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Gestion des tokens
- [JWT Best Practices (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [OAuth 2.0 Security Best Practices (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Gestion des sessions
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [MCP Session Handling Guidelines](https://modelcontextprotocol.io/docs/guides/security)
- [Secure Session Design Patterns](https://learn.microsoft.com/security/engineering/session-security)

### Sandboxing de l’exécution des outils
- [Container Security Best Practices](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementing Process Isolation](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Resource Limits for Containerized Applications](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Audits de sécurité réguliers
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Security Code Review Guidelines](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validation des prompts
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety for AI](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Preventing Prompt Injection](https://github.com/microsoft/prompt-shield-js)

### Délégation d’authentification
- [Microsoft Entra ID Integration](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 for MCP Services](https://learn.microsoft.com/security/engineering/solving-oauth)
- [MCP Security Controls 2025](./mcp-security-controls-2025.md)

### Ciblage des permissions
- [Secure Least-Privileged Access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Role-Based Access Control (RBAC) Design](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Tool-specific Authorization in MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimisation des données
- [Data Protection by Design](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [AI Data Privacy Best Practices](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementing Privacy-enhancing Technologies](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Analyse automatisée des vulnérabilités
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [DevSecOps Pipeline Implementation](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Continuous Security Validation](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Avertissement** :  
Ce document a été traduit à l’aide du service de traduction automatique [Co-op Translator](https://github.com/Azure/co-op-translator). Bien que nous nous efforcions d’assurer l’exactitude, veuillez noter que les traductions automatiques peuvent contenir des erreurs ou des inexactitudes. Le document original dans sa langue d’origine doit être considéré comme la source faisant foi. Pour les informations critiques, une traduction professionnelle réalisée par un humain est recommandée. Nous déclinons toute responsabilité en cas de malentendus ou de mauvaises interprétations résultant de l’utilisation de cette traduction.