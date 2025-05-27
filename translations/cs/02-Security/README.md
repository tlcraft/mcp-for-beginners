<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-27T16:17:39+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "cs"
}
-->
# Security Best Practices

Adoptar el Model Context Protocol (MCP) aporta capacidades poderosas a las aplicaciones impulsadas por IA, pero también introduce desafíos de seguridad únicos que van más allá de los riesgos tradicionales del software. Además de preocupaciones ya conocidas como codificación segura, principio de menor privilegio y seguridad en la cadena de suministro, MCP y las cargas de trabajo de IA enfrentan nuevas amenazas como inyección de prompts, envenenamiento de herramientas y modificación dinámica de herramientas. Estos riesgos pueden derivar en exfiltración de datos, violaciones de privacidad y comportamientos no deseados del sistema si no se gestionan adecuadamente.

Esta lección explora los riesgos de seguridad más relevantes asociados con MCP — incluyendo autenticación, autorización, permisos excesivos, inyección indirecta de prompts y vulnerabilidades en la cadena de suministro — y ofrece controles prácticos y mejores prácticas para mitigarlos. También aprenderás a aprovechar soluciones de Microsoft como Prompt Shields, Azure Content Safety y GitHub Advanced Security para fortalecer tu implementación de MCP. Al entender y aplicar estos controles, puedes reducir significativamente la probabilidad de una brecha de seguridad y garantizar que tus sistemas de IA sean robustos y confiables.

# Learning Objectives

Al finalizar esta lección, podrás:

- Identificar y explicar los riesgos de seguridad únicos introducidos por el Model Context Protocol (MCP), incluyendo inyección de prompts, envenenamiento de herramientas, permisos excesivos y vulnerabilidades en la cadena de suministro.
- Describir y aplicar controles efectivos para mitigar los riesgos de seguridad de MCP, tales como autenticación robusta, principio de menor privilegio, gestión segura de tokens y verificación de la cadena de suministro.
- Entender y aprovechar soluciones de Microsoft como Prompt Shields, Azure Content Safety y GitHub Advanced Security para proteger MCP y las cargas de trabajo de IA.
- Reconocer la importancia de validar los metadatos de las herramientas, monitorear cambios dinámicos y defenderse contra ataques de inyección indirecta de prompts.
- Integrar mejores prácticas de seguridad establecidas — como codificación segura, endurecimiento de servidores y arquitectura de confianza cero — en tu implementación de MCP para reducir la probabilidad e impacto de brechas de seguridad.

# MCP security controls

Cualquier sistema con acceso a recursos importantes enfrenta desafíos de seguridad implícitos. Estos desafíos generalmente pueden abordarse aplicando correctamente controles y conceptos fundamentales de seguridad. Dado que MCP es un estándar recién definido, la especificación está cambiando rápidamente y, a medida que el protocolo evoluciona, eventualmente sus controles de seguridad madurarán, permitiendo una mejor integración con arquitecturas y prácticas de seguridad empresariales establecidas.

Investigaciones publicadas en el [Microsoft Digital Defense Report](https://aka.ms/mddr) indican que el 98% de las brechas reportadas podrían haberse evitado con una higiene de seguridad robusta, y la mejor protección contra cualquier tipo de brecha es tener una base sólida en higiene de seguridad, prácticas de codificación segura y seguridad en la cadena de suministro — esas prácticas probadas y conocidas siguen siendo las que más impacto tienen en la reducción del riesgo de seguridad.

Veamos algunas formas de empezar a abordar los riesgos de seguridad al adoptar MCP.

# MCP server authentication (if your MCP implementation was before 26th April 2025)

> **Note:** La siguiente información es válida al 26 de abril de 2025. El protocolo MCP está en constante evolución, y las futuras implementaciones podrían introducir nuevos patrones y controles de autenticación. Para las actualizaciones y orientación más recientes, consulta siempre la [MCP Specification](https://spec.modelcontextprotocol.io/) y el repositorio oficial [MCP GitHub repository](https://github.com/modelcontextprotocol).

### Problem statement  
La especificación original de MCP asumía que los desarrolladores crearían su propio servidor de autenticación. Esto requería conocimientos de OAuth y restricciones de seguridad relacionadas. Los servidores MCP actuaban como servidores de autorización OAuth 2.0, gestionando la autenticación de usuario directamente en lugar de delegarla a un servicio externo como Microsoft Entra ID. A partir del 26 de abril de 2025, una actualización de la especificación MCP permite que los servidores MCP deleguen la autenticación de usuario a un servicio externo.

### Risks
- Una lógica de autorización mal configurada en el servidor MCP puede provocar exposición de datos sensibles y controles de acceso incorrectamente aplicados.
- Robo de tokens OAuth en el servidor MCP local. Si se roba el token, puede usarse para suplantar al servidor MCP y acceder a recursos y datos del servicio asociado al token OAuth.

### Mitigating controls
- **Revisar y reforzar la lógica de autorización:** Audita cuidadosamente la implementación de autorización de tu servidor MCP para asegurar que solo los usuarios y clientes autorizados puedan acceder a recursos sensibles. Para orientación práctica, consulta [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) y [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar prácticas seguras para tokens:** Sigue las [mejores prácticas de Microsoft para validación y duración de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para evitar el uso indebido de tokens de acceso y reducir el riesgo de reproducción o robo.
- **Proteger el almacenamiento de tokens:** Siempre almacena los tokens de forma segura y usa cifrado para protegerlos tanto en reposo como en tránsito. Para consejos de implementación, consulta [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement  
Los servidores MCP pueden haber recibido permisos excesivos para el servicio o recurso al que acceden. Por ejemplo, un servidor MCP que forma parte de una aplicación de ventas de IA que se conecta a un almacén de datos empresarial debería tener acceso limitado a los datos de ventas y no poder acceder a todos los archivos del almacén. Volviendo al principio de menor privilegio (uno de los principios de seguridad más antiguos), ningún recurso debe tener permisos que excedan lo necesario para realizar las tareas para las que fue diseñado. La IA presenta un desafío adicional en este aspecto porque para ser flexible puede ser difícil definir exactamente qué permisos se requieren.

### Risks  
- Otorgar permisos excesivos puede permitir la exfiltración o modificación de datos a los que el servidor MCP no debería tener acceso. Esto también puede representar un problema de privacidad si los datos son información personal identificable (PII).

### Mitigating controls
- **Aplicar el principio de menor privilegio:** Otorga al servidor MCP solo los permisos mínimos necesarios para realizar sus tareas. Revisa y actualiza regularmente estos permisos para asegurar que no excedan lo necesario. Para orientación detallada, consulta [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Control de Acceso Basado en Roles (RBAC):** Asigna roles al servidor MCP que estén estrictamente limitados a recursos y acciones específicas, evitando permisos amplios o innecesarios.
- **Monitorear y auditar permisos:** Supervisa continuamente el uso de permisos y audita los registros de acceso para detectar y corregir privilegios excesivos o no utilizados con rapidez.

# Indirect prompt injection attacks

### Problem statement

Servidores MCP maliciosos o comprometidos pueden introducir riesgos significativos al exponer datos de clientes o habilitar acciones no deseadas. Estos riesgos son especialmente relevantes en cargas de trabajo basadas en IA y MCP, donde:

- **Ataques de inyección de prompts:** Los atacantes insertan instrucciones maliciosas en prompts o contenido externo, haciendo que el sistema de IA realice acciones no deseadas o filtre datos sensibles. Más información: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamiento de herramientas:** Los atacantes manipulan los metadatos de las herramientas (como descripciones o parámetros) para influir en el comportamiento de la IA, potencialmente eludiendo controles de seguridad o exfiltrando datos. Detalles: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Inyección cruzada de prompts:** Instrucciones maliciosas se ocultan en documentos, páginas web o correos electrónicos, que luego procesa la IA, lo que puede causar filtración o manipulación de datos.
- **Modificación dinámica de herramientas (Rug Pulls):** Las definiciones de herramientas pueden cambiar después de la aprobación del usuario, introduciendo comportamientos maliciosos sin que el usuario lo sepa.

Estas vulnerabilidades resaltan la necesidad de una validación robusta, monitoreo y controles de seguridad al integrar servidores y herramientas MCP en tu entorno. Para profundizar, consulta las referencias vinculadas arriba.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.cs.png)

**Inyección Indirecta de Prompts** (también conocida como inyección cruzada de prompts o XPIA) es una vulnerabilidad crítica en sistemas de IA generativa, incluyendo aquellos que usan Model Context Protocol (MCP). En este ataque, instrucciones maliciosas están ocultas dentro de contenido externo — como documentos, páginas web o correos electrónicos. Cuando el sistema de IA procesa este contenido, puede interpretar las instrucciones incrustadas como comandos legítimos del usuario, resultando en acciones no deseadas como filtración de datos, generación de contenido dañino o manipulación de interacciones del usuario. Para una explicación detallada y ejemplos reales, consulta [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Una forma particularmente peligrosa de este ataque es el **Envenenamiento de Herramientas**. Aquí, los atacantes inyectan instrucciones maliciosas en los metadatos de las herramientas MCP (como descripciones o parámetros). Dado que los modelos de lenguaje grandes (LLMs) dependen de estos metadatos para decidir qué herramientas invocar, descripciones comprometidas pueden engañar al modelo para ejecutar llamadas a herramientas no autorizadas o eludir controles de seguridad. Estas manipulaciones suelen ser invisibles para los usuarios finales, pero pueden ser interpretadas y ejecutadas por el sistema de IA. Este riesgo se intensifica en entornos de servidores MCP alojados, donde las definiciones de herramientas pueden actualizarse después de la aprobación del usuario — un escenario a veces llamado "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". En tales casos, una herramienta que antes era segura puede modificarse para realizar acciones maliciosas, como exfiltrar datos o alterar el comportamiento del sistema, sin que el usuario lo sepa. Para más información sobre este vector de ataque, consulta [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.cs.png)

## Risks  
Las acciones no deseadas de la IA presentan diversos riesgos de seguridad que incluyen exfiltración de datos y violaciones de privacidad.

### Mitigating controls  
### Using prompt shields to protect against Indirect Prompt Injection attacks  
-----------------------------------------------------------------------------

**AI Prompt Shields** son una solución desarrollada por Microsoft para defender contra ataques de inyección de prompts directos e indirectos. Ayudan mediante:

1.  **Detección y filtrado:** Prompt Shields utilizan algoritmos avanzados de aprendizaje automático y procesamiento de lenguaje natural para detectar y filtrar instrucciones maliciosas incrustadas en contenido externo, como documentos, páginas web o correos electrónicos.
    
2.  **Spotlighting:** Esta técnica ayuda al sistema de IA a distinguir entre instrucciones válidas del sistema y entradas externas potencialmente no confiables. Al transformar el texto de entrada para hacerlo más relevante para el modelo, Spotlighting asegura que la IA pueda identificar y ignorar mejor las instrucciones maliciosas.
    
3.  **Delimitadores y marcado de datos:** Incluir delimitadores en el mensaje del sistema señala explícitamente la ubicación del texto de entrada, ayudando al sistema de IA a reconocer y separar las entradas del usuario del contenido externo potencialmente dañino. El marcado de datos extiende este concepto usando marcadores especiales para resaltar los límites de datos confiables y no confiables.
    
4.  **Monitoreo y actualizaciones continuas:** Microsoft monitorea y actualiza constantemente Prompt Shields para enfrentar nuevas amenazas y técnicas de ataque en evolución. Este enfoque proactivo asegura que las defensas sigan siendo efectivas.
    
5. **Integración con Azure Content Safety:** Prompt Shields forman parte de la suite más amplia Azure AI Content Safety, que ofrece herramientas adicionales para detectar intentos de jailbreak, contenido dañino y otros riesgos de seguridad en aplicaciones de IA.

Puedes leer más sobre AI prompt shields en la [documentación de Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.cs.png)

### Supply chain security

La seguridad en la cadena de suministro sigue siendo fundamental en la era de la IA, pero el alcance de lo que constituye tu cadena de suministro se ha ampliado. Además de los paquetes de código tradicionales, ahora debes verificar y monitorear rigurosamente todos los componentes relacionados con IA, incluyendo modelos base, servicios de embeddings, proveedores de contexto y APIs de terceros. Cada uno de estos puede introducir vulnerabilidades o riesgos si no se gestiona correctamente.

**Prácticas clave de seguridad en la cadena de suministro para IA y MCP:**
- **Verificar todos los componentes antes de integrarlos:** Esto incluye no solo librerías de código abierto, sino también modelos de IA, fuentes de datos y APIs externas. Siempre revisa la procedencia, licencias y vulnerabilidades conocidas.
- **Mantener pipelines de despliegue seguros:** Usa pipelines automáticos de CI/CD con escaneo de seguridad integrado para detectar problemas temprano. Asegura que solo artefactos confiables se desplieguen en producción.
- **Monitorear y auditar continuamente:** Implementa monitoreo permanente para todas las dependencias, incluidos modelos y servicios de datos, para detectar nuevas vulnerabilidades o ataques en la cadena de suministro.
- **Aplicar principio de menor privilegio y controles de acceso:** Restringe el acceso a modelos, datos y servicios solo a lo necesario para que el servidor MCP funcione.
- **Responder rápidamente a amenazas:** Ten un proceso para parchear o reemplazar componentes comprometidos, y para rotar secretos o credenciales si se detecta una brecha.

[GitHub Advanced Security](https://github.com/security/advanced-security) ofrece funciones como escaneo de secretos, escaneo de dependencias y análisis con CodeQL. Estas herramientas se integran con [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) y [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ayudar a los equipos a identificar y mitigar vulnerabilidades tanto en código como en componentes de la cadena de suministro de IA.

Microsoft también implementa prácticas extensas de seguridad en la cadena de suministro internamente para todos sus productos. Aprende más en [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Cualquier implementación de MCP hereda la postura de seguridad existente del entorno organizacional sobre el que se construye, por lo que al considerar la seguridad de MCP como parte de tus sistemas de IA, se recomienda fortalecer la postura de seguridad general ya existente. Los siguientes controles de seguridad establecidos son especialmente relevantes:

- Prácticas de codificación segura en tu aplicación de IA — proteger contra [el OWASP Top 10](https://owasp.org/www-project-top-ten/), el [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de bóvedas seguras para secretos y tokens, implementación de comunicaciones seguras de extremo a extremo entre todos los componentes de la aplicación, etc.
- Endurecimiento de servidores — usar MFA donde sea posible, mantener el parcheo actualizado, integrar el servidor con un proveedor de identidad externo para el acceso, etc.
- Mantener dispositivos, infraestructura y aplicaciones actualizados con parches.
- Monitoreo de seguridad — implementar registro y monitoreo de la aplicación de IA (incluyendo clientes y servidores MCP) y enviar esos logs a un SIEM central para detectar actividades anómalas.
- Arquitectura de confianza cero — aislar componentes mediante controles de red e identidad de forma lógica para minimizar el movimiento lateral en caso de que una aplicación de IA sea comprometida.

# Key Takeaways

- Los fundamentos de seguridad siguen siendo críticos: codificación segura, principio de menor privilegio, verificación de la cadena de suministro y monitoreo continuo son esenciales para MCP y cargas de trabajo de IA.
- MCP introduce nuevos riesgos — como inyección de prompts, envenenamiento de herramientas y permisos excesivos — que requieren controles tanto tradicionales como específicos para IA.
- Usa prácticas robustas de autenticación, autorización y gestión de tokens, aprovechando proveedores de identidad externos como Microsoft Entra ID cuando sea posible.
- Protégete contra inyección indirecta de prompts y envenenamiento de herramientas validando metadatos, monitoreando cambios dinámicos y usando soluciones como Microsoft Prompt Shields.
- Trata todos los componentes en tu cadena de suministro de IA — incluyendo modelos, embeddings y proveedores de contexto — con el mismo rigor que las dependencias de código.
- Mantente al día con las especificaciones MCP en evolución y contribuye a la comunidad para ayudar a definir estándares seguros.

# Additional Resources

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection in MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Tool Poisoning Attacks (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls in MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Prompt Shields Documentation (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 for LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Secure Least-Privileged Access (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Best Practices for Token Validation and Lifetime](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Use Secure Token Storage and Encrypt Tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management as Auth Gateway for MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Next 

Next: [Chapter 3: Getting Started](/03-GettingStarted/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatizované překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro kritické informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoliv nedorozumění nebo chybné výklady vzniklé použitím tohoto překladu.