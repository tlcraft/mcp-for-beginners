<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "90bfc6f3be00e34f6124e2a24bf94167",
  "translation_date": "2025-07-16T23:08:51+00:00",
  "source_file": "02-Security/mcp-best-practices.md",
  "language_code": "es"
}
-->
# Mejores Prácticas de Seguridad para MCP

Al trabajar con servidores MCP, sigue estas mejores prácticas de seguridad para proteger tus datos, infraestructura y usuarios:

1. **Validación de Entradas**: Siempre valida y sanitiza las entradas para evitar ataques de inyección y problemas de delegado confundido.
2. **Control de Acceso**: Implementa una autenticación y autorización adecuadas para tu servidor MCP con permisos detallados.
3. **Comunicación Segura**: Usa HTTPS/TLS para todas las comunicaciones con tu servidor MCP y considera añadir cifrado adicional para datos sensibles.
4. **Limitación de Tasa**: Implementa limitación de tasa para prevenir abusos, ataques DoS y gestionar el consumo de recursos.
5. **Registro y Monitoreo**: Supervisa tu servidor MCP en busca de actividades sospechosas e implementa auditorías completas.
6. **Almacenamiento Seguro**: Protege datos sensibles y credenciales con cifrado adecuado en reposo.
7. **Gestión de Tokens**: Evita vulnerabilidades de paso de tokens validando y sanitizando todas las entradas y salidas del modelo.
8. **Gestión de Sesiones**: Implementa manejo seguro de sesiones para prevenir secuestro y fijación de sesión.
9. **Aislamiento de Ejecución de Herramientas**: Ejecuta las herramientas en entornos aislados para evitar movimientos laterales en caso de compromiso.
10. **Auditorías de Seguridad Regulares**: Realiza revisiones periódicas de seguridad en tus implementaciones y dependencias MCP.
11. **Validación de Prompts**: Escanea y filtra tanto los prompts de entrada como de salida para evitar ataques de inyección de prompts.
12. **Delegación de Autenticación**: Usa proveedores de identidad establecidos en lugar de implementar autenticación personalizada.
13. **Alcance de Permisos**: Implementa permisos granulares para cada herramienta y recurso siguiendo el principio de menor privilegio.
14. **Minimización de Datos**: Expón solo los datos mínimos necesarios para cada operación para reducir la superficie de riesgo.
15. **Escaneo Automatizado de Vulnerabilidades**: Escanea regularmente tus servidores MCP y dependencias en busca de vulnerabilidades conocidas.

## Recursos de Apoyo para las Mejores Prácticas de Seguridad MCP

### Validación de Entradas
- [OWASP Input Validation Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Input_Validation_Cheat_Sheet.html)
- [Prevención de Inyección de Prompts en MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Implementación de Azure Content Safety](./azure-content-safety-implementation.md)

### Control de Acceso
- [Especificación de Autorización MCP](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Uso de Microsoft Entra ID con Servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)
- [Azure API Management como Gateway de Autenticación para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)

### Comunicación Segura
- [Mejores Prácticas de Transport Layer Security (TLS)](https://learn.microsoft.com/security/engineering/solving-tls)
- [Guías de Seguridad de Transporte MCP](https://modelcontextprotocol.io/docs/concepts/transports)
- [Cifrado de Extremo a Extremo para Cargas de Trabajo de IA](https://learn.microsoft.com/azure/architecture/example-scenario/confidential/end-to-end-encryption)

### Limitación de Tasa
- [Patrones de Limitación de Tasa para API](https://learn.microsoft.com/azure/architecture/patterns/rate-limiting-pattern)
- [Implementación de Limitación de Tasa con Token Bucket](https://konghq.com/blog/engineering/how-to-design-a-scalable-rate-limiting-algorithm)
- [Limitación de Tasa en Azure API Management](https://learn.microsoft.com/azure/api-management/rate-limit-policy)

### Registro y Monitoreo
- [Registro Centralizado para Sistemas de IA](https://learn.microsoft.com/azure/architecture/example-scenario/logging/centralized-logging)
- [Mejores Prácticas para Registro de Auditoría](https://cheatsheetseries.owasp.org/cheatsheets/Logging_Cheat_Sheet.html)
- [Azure Monitor para Cargas de Trabajo de IA](https://learn.microsoft.com/azure/azure-monitor/overview)

### Almacenamiento Seguro
- [Azure Key Vault para Almacenamiento de Credenciales](https://learn.microsoft.com/azure/key-vault/general/basic-concepts)
- [Cifrado de Datos Sensibles en Reposo](https://learn.microsoft.com/security/engineering/data-encryption-at-rest)
- [Uso de Almacenamiento Seguro de Tokens y Cifrado de Tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)

### Gestión de Tokens
- [Mejores Prácticas JWT (RFC 8725)](https://datatracker.ietf.org/doc/html/rfc8725)
- [Mejores Prácticas de Seguridad OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Mejores Prácticas para Validación y Duración de Tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)

### Gestión de Sesiones
- [OWASP Session Management Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html)
- [Guías de Manejo de Sesiones MCP](https://modelcontextprotocol.io/docs/guides/security)
- [Patrones de Diseño para Sesiones Seguras](https://learn.microsoft.com/security/engineering/session-security)

### Aislamiento de Ejecución de Herramientas
- [Mejores Prácticas de Seguridad para Contenedores](https://learn.microsoft.com/azure/container-instances/container-instances-image-security)
- [Implementación de Aislamiento de Procesos](https://learn.microsoft.com/windows/security/threat-protection/security-policy-settings/user-rights-assignment)
- [Límites de Recursos para Aplicaciones Contenerizadas](https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/)

### Auditorías de Seguridad Regulares
- [Microsoft Security Development Lifecycle](https://www.microsoft.com/sdl)
- [OWASP Application Security Verification Standard](https://owasp.org/www-project-application-security-verification-standard/)
- [Guías para Revisión de Código de Seguridad](https://owasp.org/www-pdf-archive/OWASP_Code_Review_Guide_v2.pdf)

### Validación de Prompts
- [Microsoft Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [Azure Content Safety para IA](https://learn.microsoft.com/azure/ai-services/content-safety/)
- [Prevención de Inyección de Prompts](https://github.com/microsoft/prompt-shield-js)

### Delegación de Autenticación
- [Integración Microsoft Entra ID](https://learn.microsoft.com/entra/identity-platform/v2-oauth2-auth-code-flow)
- [OAuth 2.0 para Servicios MCP](https://learn.microsoft.com/security/engineering/solving-oauth)
- [Controles de Seguridad MCP 2025](./mcp-security-controls-2025.md)

### Alcance de Permisos
- [Acceso Seguro con Menor Privilegio](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Diseño de Control de Acceso Basado en Roles (RBAC)](https://learn.microsoft.com/azure/role-based-access-control/overview)
- [Autorización Específica para Herramientas en MCP](https://modelcontextprotocol.io/docs/guides/best-practices)

### Minimización de Datos
- [Protección de Datos desde el Diseño](https://learn.microsoft.com/compliance/regulatory/gdpr-data-protection-impact-assessments)
- [Mejores Prácticas de Privacidad de Datos en IA](https://learn.microsoft.com/legal/cognitive-services/openai/data-privacy)
- [Implementación de Tecnologías para Mejorar la Privacidad](https://www.microsoft.com/security/blog/2021/07/13/microsofts-pet-project-privacy-enhancing-technologies-in-action/)

### Escaneo Automatizado de Vulnerabilidades
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Implementación de Pipeline DevSecOps](https://learn.microsoft.com/azure/devops/migrate/security-validation-cicd-pipeline)
- [Validación Continua de Seguridad](https://www.microsoft.com/security/blog/2022/04/05/step-by-step-building-a-more-efficient-devsecops-environment/)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.