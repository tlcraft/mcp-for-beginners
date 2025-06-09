<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00aedb7b1d11b7eaacb0618d8791c65",
  "translation_date": "2025-05-29T23:34:03+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "cs"
}
-->
# Security Best Practices

Adoptar el Model Context Protocol (MCP) aporta nuevas capacidades potentes a las aplicaciones impulsadas por IA, pero también introduce desafíos únicos de seguridad que van más allá de los riesgos tradicionales de software. Además de preocupaciones establecidas como la codificación segura, el principio de menor privilegio y la seguridad en la cadena de suministro, MCP y las cargas de trabajo de IA enfrentan nuevas amenazas como la inyección de prompts, el envenenamiento de herramientas y la modificación dinámica de herramientas. Estos riesgos pueden provocar exfiltración de datos, violaciones de privacidad y comportamientos no deseados del sistema si no se gestionan adecuadamente.

Esta lección explora los riesgos de seguridad más relevantes asociados con MCP — incluyendo autenticación, autorización, permisos excesivos, inyección indirecta de prompts y vulnerabilidades en la cadena de suministro — y ofrece controles prácticos y mejores prácticas para mitigarlos. También aprenderás a aprovechar soluciones de Microsoft como Prompt Shields, Azure Content Safety y GitHub Advanced Security para fortalecer tu implementación de MCP. Al comprender y aplicar estos controles, podrás reducir significativamente la probabilidad de una brecha de seguridad y garantizar que tus sistemas de IA sean robustos y confiables.

# Learning Objectives

Al finalizar esta lección, podrás:

- Identificar y explicar los riesgos de seguridad únicos introducidos por el Model Context Protocol (MCP), incluyendo inyección de prompts, envenenamiento de herramientas, permisos excesivos y vulnerabilidades en la cadena de suministro.
- Describir y aplicar controles efectivos para mitigar los riesgos de seguridad de MCP, como autenticación robusta, principio de menor privilegio, gestión segura de tokens y verificación de la cadena de suministro.
- Entender y aprovechar soluciones de Microsoft como Prompt Shields, Azure Content Safety y GitHub Advanced Security para proteger MCP y las cargas de trabajo de IA.
- Reconocer la importancia de validar los metadatos de las herramientas, monitorear cambios dinámicos y defenderse contra ataques de inyección indirecta de prompts.
- Integrar mejores prácticas de seguridad establecidas — como codificación segura, endurecimiento de servidores y arquitectura de confianza cero — en tu implementación de MCP para reducir la probabilidad e impacto de brechas de seguridad.

# MCP security controls

Cualquier sistema con acceso a recursos importantes enfrenta desafíos implícitos de seguridad. Estos desafíos generalmente pueden abordarse mediante la correcta aplicación de controles y conceptos fundamentales de seguridad. Dado que MCP es un protocolo recién definido, la especificación está cambiando rápidamente y evolucionando. Eventualmente, los controles de seguridad dentro del protocolo madurarán, permitiendo una mejor integración con arquitecturas y prácticas de seguridad empresariales establecidas.

La investigación publicada en el [Microsoft Digital Defense Report](https://aka.ms/mddr) indica que el 98% de las brechas reportadas podrían prevenirse con una higiene de seguridad robusta, y la mejor protección contra cualquier tipo de brecha es mantener una higiene básica de seguridad, prácticas de codificación segura y seguridad en la cadena de suministro bien implementadas — esas prácticas probadas siguen siendo las que más impacto tienen en la reducción del riesgo de seguridad.

Veamos algunas formas en las que puedes comenzar a abordar los riesgos de seguridad al adoptar MCP.

> **Note:** La información siguiente es correcta al **29 de mayo de 2025**. El protocolo MCP está en evolución continua, y futuras implementaciones pueden introducir nuevos patrones y controles de autenticación. Para las últimas actualizaciones y guías, consulta siempre la [MCP Specification](https://spec.modelcontextprotocol.io/), el repositorio oficial de [MCP GitHub](https://github.com/modelcontextprotocol) y la [página de mejores prácticas de seguridad](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Problem statement 
La especificación original de MCP asumía que los desarrolladores escribirían su propio servidor de autenticación. Esto requería conocimientos de OAuth y restricciones de seguridad relacionadas. Los servidores MCP actuaban como Servidores de Autorización OAuth 2.0, gestionando la autenticación del usuario directamente en lugar de delegarla a un servicio externo como Microsoft Entra ID. A partir del **26 de abril de 2025**, una actualización a la especificación MCP permite que los servidores MCP deleguen la autenticación de usuarios a un servicio externo.

### Risks
- Una lógica de autorización mal configurada en el servidor MCP puede conducir a la exposición de datos sensibles y controles de acceso aplicados incorrectamente.
- Robo de tokens OAuth en el servidor local MCP. Si se roba el token, este puede usarse para suplantar al servidor MCP y acceder a recursos y datos del servicio para el que fue emitido el token OAuth.

#### Token Passthrough
El paso directo de tokens está explícitamente prohibido en la especificación de autorización porque introduce varios riesgos de seguridad, que incluyen:

#### Security Control Circumvention
El servidor MCP o las APIs aguas abajo podrían implementar controles importantes de seguridad como limitación de tasa, validación de solicitudes o monitoreo de tráfico, que dependen del público del token u otras restricciones de credenciales. Si los clientes pueden obtener y usar tokens directamente con las APIs aguas abajo sin que el servidor MCP los valide correctamente o asegure que los tokens fueron emitidos para el servicio correcto, están eludiendo estos controles.

#### Accountability and Audit Trail Issues
El servidor MCP no podrá identificar ni distinguir entre clientes MCP cuando estos llamen con un token de acceso emitido por un sistema upstream que puede ser opaco para el servidor MCP.
Los registros del servidor de recursos aguas abajo pueden mostrar solicitudes que parecen provenir de una fuente o identidad diferente, en lugar del servidor MCP que realmente está reenviando los tokens.
Ambos factores dificultan la investigación de incidentes, controles y auditorías.
Si el servidor MCP pasa tokens sin validar sus claims (por ejemplo, roles, privilegios o audiencia) u otros metadatos, un actor malicioso en posesión de un token robado puede usar el servidor como proxy para exfiltración de datos.

#### Trust Boundary Issues
El servidor de recursos aguas abajo otorga confianza a entidades específicas. Esta confianza podría incluir suposiciones sobre el origen o patrones de comportamiento del cliente. Romper este límite de confianza podría causar problemas inesperados.
Si el token es aceptado por múltiples servicios sin la validación adecuada, un atacante que comprometa un servicio puede usar el token para acceder a otros servicios conectados.

#### Future Compatibility Risk
Aunque un servidor MCP comience hoy como un “proxy puro”, podría necesitar añadir controles de seguridad más adelante. Comenzar con una separación adecuada del público del token facilita la evolución del modelo de seguridad.

### Mitigating controls

**Los servidores MCP NO DEBEN aceptar tokens que no hayan sido emitidos explícitamente para el servidor MCP**

- **Revisar y Endurecer la Lógica de Autorización:** Audita cuidadosamente la implementación de autorización de tu servidor MCP para asegurar que solo los usuarios y clientes previstos puedan acceder a recursos sensibles. Para guía práctica, consulta [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) y [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar Prácticas Seguras de Tokens:** Sigue las [mejores prácticas de Microsoft para validación y duración de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para prevenir el mal uso de tokens de acceso y reducir el riesgo de reproducción o robo de tokens.
- **Proteger el Almacenamiento de Tokens:** Siempre almacena los tokens de forma segura y usa cifrado para protegerlos en reposo y en tránsito. Para consejos de implementación, consulta [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Excessive permissions for MCP servers

### Problem statement
Los servidores MCP pueden haber recibido permisos excesivos para el servicio o recurso al que acceden. Por ejemplo, un servidor MCP que forma parte de una aplicación de ventas de IA que se conecta a un almacén de datos empresarial debería tener acceso limitado solo a los datos de ventas y no a todos los archivos del almacén. Volviendo al principio de menor privilegio (uno de los principios de seguridad más antiguos), ningún recurso debería tener permisos que excedan lo necesario para ejecutar las tareas para las que fue diseñado. La IA presenta un desafío adicional en este aspecto porque, para que sea flexible, puede ser difícil definir los permisos exactos requeridos.

### Risks 
- Otorgar permisos excesivos puede permitir la exfiltración o modificación de datos a los que el servidor MCP no debería tener acceso. Esto también puede ser un problema de privacidad si los datos contienen información personal identificable (PII).

### Mitigating controls
- **Aplicar el Principio de Menor Privilegio:** Otorga al servidor MCP solo los permisos mínimos necesarios para realizar sus tareas. Revisa y actualiza estos permisos regularmente para asegurarte de que no excedan lo necesario. Para guía detallada, consulta [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar Control de Acceso Basado en Roles (RBAC):** Asigna roles al servidor MCP que estén estrictamente limitados a recursos y acciones específicas, evitando permisos amplios o innecesarios.
- **Monitorear y Auditar Permisos:** Supervisa continuamente el uso de permisos y audita los registros de acceso para detectar y corregir privilegios excesivos o no utilizados de forma rápida.

# Indirect prompt injection attacks

### Problem statement

Servidores MCP maliciosos o comprometidos pueden introducir riesgos significativos al exponer datos de clientes o permitir acciones no intencionadas. Estos riesgos son especialmente relevantes en cargas de trabajo basadas en IA y MCP, donde:

- **Prompt Injection Attacks:** Los atacantes incrustan instrucciones maliciosas en prompts o contenido externo, haciendo que el sistema de IA realice acciones no deseadas o filtre datos sensibles. Más información: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Tool Poisoning:** Los atacantes manipulan los metadatos de herramientas (como descripciones o parámetros) para influir en el comportamiento de la IA, potencialmente evadiendo controles de seguridad o exfiltrando datos. Detalles: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Cross-Domain Prompt Injection:** Instrucciones maliciosas incrustadas en documentos, páginas web o correos electrónicos que luego son procesados por la IA, causando filtración o manipulación de datos.
- **Dynamic Tool Modification (Rug Pulls):** Las definiciones de herramientas pueden cambiar después de la aprobación del usuario, introduciendo nuevos comportamientos maliciosos sin que el usuario lo sepa.

Estas vulnerabilidades resaltan la necesidad de validación robusta, monitoreo y controles de seguridad al integrar servidores MCP y herramientas en tu entorno. Para un análisis más profundo, consulta las referencias enlazadas arriba.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.cs.png)

**Indirect Prompt Injection** (también conocido como inyección cruzada de dominio o XPIA) es una vulnerabilidad crítica en sistemas de IA generativa, incluidos aquellos que usan el Model Context Protocol (MCP). En este ataque, instrucciones maliciosas se ocultan dentro de contenido externo — como documentos, páginas web o correos electrónicos. Cuando el sistema de IA procesa este contenido, puede interpretar las instrucciones incrustadas como comandos legítimos del usuario, resultando en acciones no deseadas como filtración de datos, generación de contenido dañino o manipulación de interacciones del usuario. Para una explicación detallada y ejemplos reales, consulta [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Una forma particularmente peligrosa de este ataque es el **Tool Poisoning**. Aquí, los atacantes inyectan instrucciones maliciosas en los metadatos de las herramientas MCP (como descripciones o parámetros). Dado que los modelos de lenguaje grandes (LLMs) dependen de estos metadatos para decidir qué herramientas invocar, descripciones comprometidas pueden engañar al modelo para ejecutar llamadas a herramientas no autorizadas o evadir controles de seguridad. Estas manipulaciones suelen ser invisibles para los usuarios finales, pero pueden ser interpretadas y ejecutadas por el sistema de IA. Este riesgo se intensifica en entornos de servidores MCP alojados, donde las definiciones de herramientas pueden actualizarse después de la aprobación del usuario — un escenario a veces llamado "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". En tales casos, una herramienta que antes era segura puede ser modificada posteriormente para realizar acciones maliciosas, como exfiltrar datos o alterar el comportamiento del sistema, sin que el usuario lo sepa. Para más información sobre este vector de ataque, consulta [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.cs.png)

## Risks
Las acciones no intencionadas de la IA presentan varios riesgos de seguridad que incluyen exfiltración de datos y violaciones de privacidad.

### Mitigating controls
### Using prompt shields to protect against Indirect Prompt Injection attacks
-----------------------------------------------------------------------------

**AI Prompt Shields** son una solución desarrollada por Microsoft para defenderse contra ataques de inyección directa e indirecta de prompts. Ayudan mediante:

1.  **Detección y Filtrado:** Prompt Shields usan algoritmos avanzados de aprendizaje automático y procesamiento de lenguaje natural para detectar y filtrar instrucciones maliciosas incrustadas en contenido externo, como documentos, páginas web o correos electrónicos.
    
2.  **Spotlighting:** Esta técnica ayuda al sistema de IA a distinguir entre instrucciones válidas del sistema y entradas externas potencialmente no confiables. Al transformar el texto de entrada para hacerlo más relevante para el modelo, Spotlighting asegura que la IA pueda identificar mejor y ignorar instrucciones maliciosas.
    
3.  **Delimitadores y Marcado de Datos:** Incluir delimitadores en el mensaje del sistema delimita explícitamente la ubicación del texto de entrada, ayudando al sistema de IA a reconocer y separar las entradas del usuario del contenido externo potencialmente dañino. El marcado de datos extiende este concepto usando marcadores especiales para resaltar los límites de datos confiables y no confiables.
    
4.  **Monitoreo y Actualizaciones Continuas:** Microsoft monitorea y actualiza continuamente Prompt Shields para enfrentar nuevas y cambiantes amenazas. Este enfoque proactivo asegura que las defensas se mantengan efectivas contra las técnicas de ataque más recientes.
    
5. **Integración con Azure Content Safety:** Prompt Shields forman parte del conjunto más amplio de Azure AI Content Safety, que proporciona herramientas adicionales para detectar intentos de jailbreak, contenido dañino y otros riesgos de seguridad en aplicaciones de IA.

Puedes leer más sobre AI prompt shields en la [documentación de Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.cs.png)

### Supply chain security

La seguridad en la cadena de suministro sigue siendo fundamental en la era de la IA, pero el alcance de lo que constituye tu cadena de suministro se ha ampliado. Además de los paquetes de código tradicionales, ahora debes verificar y monitorear rigurosamente todos los componentes relacionados con IA, incluidos modelos base, servicios de embeddings, proveedores de contexto y APIs de terceros. Cada uno de estos puede introducir vulnerabilidades o riesgos si no se gestionan adecuadamente.

**Prácticas clave de seguridad en la cadena de suministro para IA y MCP:**
- **Verificar todos los componentes antes de la integración:** Esto incluye no solo bibliotecas de código abierto, sino también modelos de IA, fuentes de datos y APIs externas. Siempre verifica la procedencia, licencias y vulnerabilidades conocidas.
- **Mantener pipelines de despliegue seguros:** Usa pipelines CI/CD automatizados con escaneo de seguridad integrado para detectar problemas temprano. Asegura que solo artefactos confiables se desplieguen en producción.
- **Monitorear y auditar continuamente:** Implementa monitoreo constante para todas las dependencias, incluidos modelos y servicios de datos, para detectar nuevas vulnerabilidades o ataques a la cadena de suministro.
- **Aplicar el principio de menor privilegio y controles de acceso:** Restringe el acceso a modelos, datos y servicios solo a lo necesario para que funcione tu servidor MCP.
- **Responder rápidamente a amenazas:** Ten un proceso para parchear o reemplazar componentes comprometidos, y para rotar secretos o credenciales si se detecta una brecha.

[GitHub Advanced Security](https://github.com/security/advanced-security) ofrece funciones como escaneo de secretos, escaneo de dependencias y análisis con CodeQL. Estas herramientas se integran con [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) y [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ayudar a los equipos a identificar y mitigar vulnerabilidades tanto en el código como en los componentes de la cadena de suministro de IA.

Microsoft también implementa prácticas extensas de seguridad en la cadena de suministro internamente para todos sus productos. Aprende más en [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Established security best practices that will uplift your MCP implementation's security posture

Cualquier implementación de MCP hereda la postura de seguridad existente del entorno de tu organización sobre el que se construye, por lo que al considerar la seguridad de MCP como parte de tus sistemas generales de IA, se recomienda fortalecer tu postura de seguridad general existente. Los siguientes controles de seguridad establecidos son especialmente pertinentes:

-   Mejores prácticas de codificación segura en tu aplicación de IA — protección contra [OWASP Top 10](https://owasp.org/www-project-top-ten/), el [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de vaults seguros para secretos y tokens, implementación de comunicaciones seguras de extremo a extremo entre todos los componentes de la aplicación, etc.
-   Endurecimiento de servidores — usar MFA donde sea posible, mantener los parches actualizados, integrar el servidor con un proveedor de identidad externo para acceso, etc.
-   Mantener dispositivos, infraestructura y aplicaciones actualizados con parches.
-   Monitoreo de seguridad — implementar registro y monitoreo de una aplicación de IA (incluyendo cliente/servidores MCP) y enviar esos logs a un SIEM central para detectar actividades anómalas.
-   Arquitectura de confianza cero — aislar componentes mediante controles de red e identidad de forma lógica para minimizar movimientos laterales si una aplicación de IA fuera comprometida.

# Key Takeaways

- Los fundamentos de seguridad siguen siendo críticos: codificación segura, principio de menor privilegio, verificación de la cadena de
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
- [MCP Security Best Practice](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Using Microsoft Entra ID to Authenticate with MCP Servers](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Next 

Siguiente: [Capítulo 3: Primeros Pasos](/03-GettingStarted/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vzniklé použitím tohoto překladu.