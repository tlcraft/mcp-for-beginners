<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "98be664d3b19a81ee24fa3f920233864",
  "translation_date": "2025-05-16T14:39:12+00:00",
  "source_file": "02-Security/readme.md",
  "language_code": "es"
}
-->
# Mejores prácticas de seguridad

Adoptar el Model Context Protocol (MCP) aporta nuevas capacidades potentes a las aplicaciones impulsadas por IA, pero también introduce desafíos de seguridad únicos que van más allá de los riesgos tradicionales del software. Además de preocupaciones establecidas como la codificación segura, el principio de menor privilegio y la seguridad en la cadena de suministro, MCP y las cargas de trabajo de IA enfrentan nuevas amenazas como la inyección de prompts, el envenenamiento de herramientas y la modificación dinámica de herramientas. Estos riesgos pueden conducir a la exfiltración de datos, violaciones de privacidad y comportamientos no deseados del sistema si no se gestionan adecuadamente.

Esta lección explora los riesgos de seguridad más relevantes asociados con MCP—incluyendo autenticación, autorización, permisos excesivos, inyección indirecta de prompts y vulnerabilidades en la cadena de suministro—y proporciona controles prácticos y mejores prácticas para mitigarlos. También aprenderás a aprovechar soluciones de Microsoft como Prompt Shields, Azure Content Safety y GitHub Advanced Security para fortalecer tu implementación de MCP. Al entender y aplicar estos controles, podrás reducir significativamente la probabilidad de una brecha de seguridad y garantizar que tus sistemas de IA sean robustos y confiables.

# Objetivos de aprendizaje

Al finalizar esta lección, serás capaz de:

- Identificar y explicar los riesgos de seguridad únicos que introduce el Model Context Protocol (MCP), incluyendo inyección de prompts, envenenamiento de herramientas, permisos excesivos y vulnerabilidades en la cadena de suministro.
- Describir y aplicar controles efectivos para mitigar los riesgos de seguridad de MCP, como autenticación robusta, principio de menor privilegio, gestión segura de tokens y verificación de la cadena de suministro.
- Entender y aprovechar soluciones de Microsoft como Prompt Shields, Azure Content Safety y GitHub Advanced Security para proteger MCP y las cargas de trabajo de IA.
- Reconocer la importancia de validar los metadatos de las herramientas, monitorear cambios dinámicos y defenderse contra ataques de inyección indirecta de prompts.
- Integrar las mejores prácticas de seguridad establecidas—como codificación segura, endurecimiento de servidores y arquitectura de confianza cero—en tu implementación de MCP para reducir la probabilidad e impacto de brechas de seguridad.

# Controles de seguridad MCP

Cualquier sistema que tenga acceso a recursos importantes presenta desafíos de seguridad implícitos. Generalmente, estos desafíos pueden abordarse mediante la aplicación correcta de controles y conceptos fundamentales de seguridad. Como MCP es una especificación recién definida, está cambiando rápidamente a medida que el protocolo evoluciona. Eventualmente, los controles de seguridad dentro de MCP madurarán, permitiendo una mejor integración con arquitecturas de seguridad empresariales y mejores prácticas establecidas.

Una investigación publicada en el [Microsoft Digital Defense Report](https://aka.ms/mddr) indica que el 98% de las brechas reportadas podrían prevenirse con una higiene de seguridad robusta, y la mejor protección contra cualquier tipo de brecha es mantener una higiene de seguridad básica adecuada, buenas prácticas de codificación segura y seguridad en la cadena de suministro — esas prácticas probadas que ya conocemos siguen siendo las que más impacto tienen en la reducción del riesgo de seguridad.

Veamos algunas formas en las que puedes comenzar a abordar los riesgos de seguridad al adoptar MCP.

# Autenticación del servidor MCP (si tu implementación de MCP fue antes del 26 de abril de 2025)

> **Note:** La siguiente información es correcta al 26 de abril de 2025. El protocolo MCP está en constante evolución y futuras implementaciones pueden introducir nuevos patrones y controles de autenticación. Para las últimas actualizaciones y guías, siempre consulta la [MCP Specification](https://spec.modelcontextprotocol.io/) y el repositorio oficial de [MCP GitHub](https://github.com/modelcontextprotocol).

### Declaración del problema  
La especificación original de MCP asumía que los desarrolladores escribirían su propio servidor de autenticación. Esto requería conocimientos de OAuth y restricciones de seguridad relacionadas. Los servidores MCP actuaban como servidores de autorización OAuth 2.0, gestionando la autenticación de usuario directamente en lugar de delegarla a un servicio externo como Microsoft Entra ID. A partir del 26 de abril de 2025, una actualización de la especificación MCP permite que los servidores MCP deleguen la autenticación de usuarios a un servicio externo.

### Riesgos
- Una lógica de autorización mal configurada en el servidor MCP puede exponer datos sensibles y aplicar controles de acceso incorrectos.
- Robo de tokens OAuth en el servidor MCP local. Si un token es robado, puede usarse para suplantar al servidor MCP y acceder a recursos y datos del servicio asociado al token OAuth.

### Controles mitigantes
- **Revisar y fortalecer la lógica de autorización:** Audita cuidadosamente la implementación de autorización de tu servidor MCP para asegurar que solo los usuarios y clientes previstos puedan acceder a recursos sensibles. Para orientación práctica, consulta [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) y [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar prácticas seguras para tokens:** Sigue las [mejores prácticas de Microsoft para validación y duración de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para prevenir el uso indebido de tokens de acceso y reducir el riesgo de repetición o robo de tokens.
- **Proteger el almacenamiento de tokens:** Siempre almacena los tokens de forma segura y usa cifrado para protegerlos tanto en reposo como en tránsito. Para consejos de implementación, consulta [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permisos excesivos para servidores MCP

### Declaración del problema  
Es posible que a los servidores MCP se les hayan otorgado permisos excesivos sobre el servicio o recurso al que acceden. Por ejemplo, un servidor MCP que forma parte de una aplicación de ventas de IA que se conecta a un almacén de datos empresarial debería tener acceso limitado solo a los datos de ventas y no a todos los archivos del almacén. Recordando el principio de menor privilegio (uno de los principios de seguridad más antiguos), ningún recurso debe tener permisos superiores a los necesarios para realizar las tareas para las que fue diseñado. La IA presenta un desafío mayor en este ámbito porque para que sea flexible, puede ser complicado definir los permisos exactos requeridos.

### Riesgos  
- Otorgar permisos excesivos puede permitir la exfiltración o modificación de datos a los que el servidor MCP no debería acceder. Esto también puede ser un problema de privacidad si los datos contienen información personal identificable (PII).

### Controles mitigantes
- **Aplicar el principio de menor privilegio:** Otorga al servidor MCP solo los permisos mínimos necesarios para realizar sus tareas. Revisa y actualiza estos permisos regularmente para asegurarte de que no excedan lo necesario. Para una guía detallada, consulta [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar control de acceso basado en roles (RBAC):** Asigna roles al servidor MCP que estén estrictamente limitados a recursos y acciones específicas, evitando permisos amplios o innecesarios.
- **Monitorear y auditar permisos:** Supervisa continuamente el uso de permisos y audita los registros de acceso para detectar y corregir privilegios excesivos o no utilizados de forma oportuna.

# Ataques de inyección indirecta de prompts

### Declaración del problema

Servidores MCP maliciosos o comprometidos pueden introducir riesgos significativos al exponer datos de clientes o permitir acciones no deseadas. Estos riesgos son especialmente relevantes en cargas de trabajo basadas en IA y MCP, donde:

- **Ataques de inyección de prompts:** Los atacantes insertan instrucciones maliciosas en prompts o contenido externo, haciendo que el sistema de IA realice acciones no deseadas o filtre datos sensibles. Más información: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamiento de herramientas:** Los atacantes manipulan los metadatos de las herramientas (como descripciones o parámetros) para influir en el comportamiento de la IA, pudiendo evadir controles de seguridad o exfiltrar datos. Detalles: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Inyección de prompts cross-domain:** Instrucciones maliciosas se insertan en documentos, páginas web o correos electrónicos, que luego son procesados por la IA, causando filtración o manipulación de datos.
- **Modificación dinámica de herramientas (Rug Pulls):** Las definiciones de herramientas pueden cambiarse después de la aprobación del usuario, introduciendo comportamientos maliciosos sin su conocimiento.

Estas vulnerabilidades resaltan la necesidad de validación robusta, monitoreo y controles de seguridad al integrar servidores MCP y herramientas en tu entorno. Para profundizar, consulta las referencias enlazadas arriba.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.es.png)

**Inyección indirecta de prompts** (también conocida como inyección cross-domain o XPIA) es una vulnerabilidad crítica en sistemas generativos de IA, incluyendo aquellos que usan el Model Context Protocol (MCP). En este ataque, instrucciones maliciosas se ocultan dentro de contenido externo — como documentos, páginas web o correos electrónicos. Cuando el sistema de IA procesa este contenido, puede interpretar las instrucciones embebidas como comandos legítimos del usuario, resultando en acciones no deseadas como filtración de datos, generación de contenido dañino o manipulación de interacciones con el usuario. Para una explicación detallada y ejemplos reales, consulta [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Una forma particularmente peligrosa de este ataque es el **Envenenamiento de herramientas**. Aquí, los atacantes inyectan instrucciones maliciosas en los metadatos de las herramientas MCP (como descripciones o parámetros). Dado que los modelos de lenguaje grandes (LLMs) dependen de estos metadatos para decidir qué herramientas invocar, descripciones comprometidas pueden engañar al modelo para ejecutar llamadas a herramientas no autorizadas o evadir controles de seguridad. Estas manipulaciones suelen ser invisibles para los usuarios finales, pero pueden ser interpretadas y ejecutadas por el sistema de IA. Este riesgo se incrementa en entornos de servidores MCP alojados, donde las definiciones de herramientas pueden actualizarse después de la aprobación del usuario — un escenario a veces denominado "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". En estos casos, una herramienta que antes era segura puede modificarse posteriormente para realizar acciones maliciosas, como exfiltrar datos o alterar el comportamiento del sistema, sin que el usuario lo sepa. Para más información sobre este vector de ataque, consulta [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.es.png)

## Riesgos  
Las acciones no deseadas de la IA presentan diversos riesgos de seguridad que incluyen exfiltración de datos y violaciones de privacidad.

### Controles mitigantes  
### Uso de prompt shields para protegerse contra ataques de inyección indirecta de prompts
-----------------------------------------------------------------------------

**AI Prompt Shields** son una solución desarrollada por Microsoft para defenderse contra ataques de inyección directa e indirecta de prompts. Ayudan mediante:

1.  **Detección y filtrado:** Prompt Shields utilizan algoritmos avanzados de aprendizaje automático y procesamiento de lenguaje natural para detectar y filtrar instrucciones maliciosas embebidas en contenido externo, como documentos, páginas web o correos electrónicos.
    
2.  **Spotlighting:** Esta técnica ayuda al sistema de IA a distinguir entre instrucciones válidas del sistema y entradas externas potencialmente poco confiables. Al transformar el texto de entrada de una manera que lo haga más relevante para el modelo, Spotlighting asegura que la IA pueda identificar mejor y ignorar instrucciones maliciosas.
    
3.  **Delimitadores y marcado de datos:** Incluir delimitadores en el mensaje del sistema indica explícitamente la ubicación del texto de entrada, ayudando al sistema de IA a reconocer y separar las entradas del usuario del contenido externo potencialmente dañino. El marcado de datos extiende este concepto usando marcadores especiales para resaltar los límites de datos confiables y no confiables.
    
4.  **Monitoreo y actualizaciones continuas:** Microsoft monitorea y actualiza continuamente Prompt Shields para abordar nuevas y cambiantes amenazas. Este enfoque proactivo garantiza que las defensas sigan siendo efectivas contra las últimas técnicas de ataque.
    
5. **Integración con Azure Content Safety:** Prompt Shields forman parte del conjunto más amplio de Azure AI Content Safety, que proporciona herramientas adicionales para detectar intentos de jailbreak, contenido dañino y otros riesgos de seguridad en aplicaciones de IA.

Puedes leer más sobre AI prompt shields en la [documentación de Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.es.png)

### Seguridad en la cadena de suministro

La seguridad en la cadena de suministro sigue siendo fundamental en la era de la IA, pero el alcance de lo que constituye tu cadena de suministro se ha ampliado. Además de los paquetes de código tradicionales, ahora debes verificar y monitorear rigurosamente todos los componentes relacionados con IA, incluyendo modelos base, servicios de embeddings, proveedores de contexto y APIs de terceros. Cada uno de estos puede introducir vulnerabilidades o riesgos si no se gestionan adecuadamente.

**Prácticas clave de seguridad en la cadena de suministro para IA y MCP:**
- **Verificar todos los componentes antes de integrarlos:** Esto incluye no solo bibliotecas de código abierto, sino también modelos de IA, fuentes de datos y APIs externas. Siempre verifica la procedencia, licencias y vulnerabilidades conocidas.
- **Mantener pipelines de despliegue seguros:** Usa pipelines CI/CD automatizados con escaneo de seguridad integrado para detectar problemas tempranamente. Asegura que solo artefactos confiables se desplieguen en producción.
- **Monitoreo y auditoría continuos:** Implementa monitoreo constante para todas las dependencias, incluyendo modelos y servicios de datos, para detectar nuevas vulnerabilidades o ataques en la cadena de suministro.
- **Aplicar principio de menor privilegio y controles de acceso:** Restringe el acceso a modelos, datos y servicios solo a lo necesario para que el servidor MCP funcione.
- **Responder rápidamente a amenazas:** Ten un proceso para parchear o reemplazar componentes comprometidos, y para rotar secretos o credenciales si se detecta una brecha.

[GitHub Advanced Security](https://github.com/security/advanced-security) ofrece funciones como escaneo de secretos, escaneo de dependencias y análisis con CodeQL. Estas herramientas se integran con [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) y [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ayudar a los equipos a identificar y mitigar vulnerabilidades tanto en el código como en los componentes de la cadena de suministro de IA.

Microsoft también implementa extensas prácticas de seguridad en la cadena de suministro internamente para todos sus productos. Aprende más en [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).

# Mejores prácticas de seguridad establecidas que mejorarán la postura de seguridad de tu implementación MCP

Cualquier implementación de MCP hereda la postura de seguridad existente del entorno de tu organización sobre la que está construida, por lo que al considerar la seguridad de MCP como componente de tus sistemas de IA en general, se recomienda elevar la postura de seguridad general existente. Los siguientes controles de seguridad establecidos son especialmente relevantes:

- Mejores prácticas de codificación segura en tu aplicación de IA — protección contra [el OWASP Top 10](https://owasp.org/www-project-top-ten/), el [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de bóvedas seguras para secretos y tokens, implementación de comunicaciones seguras de extremo a extremo entre todos los componentes de la aplicación, etc.
- Endurecimiento del servidor — usar MFA cuando sea posible, mantener los parches actualizados, integrar el servidor con un proveedor de identidad externo para acceso, etc.
- Mantener dispositivos, infraestructura y aplicaciones actualizados con parches
- Monitoreo de seguridad — implementar registro y monitoreo de la aplicación de IA (incluyendo cliente/servidores MCP) y enviar esos registros a un SIEM central para detectar actividades anómalas
- Arquitectura de confianza cero — aislar componentes mediante controles de red e identidad de forma lógica para minimizar movimientos laterales en caso de que una aplicación de IA sea comprometida.

# Conclusiones clave

- Los fundamentos de seguridad siguen siendo críticos: codificación segura, principio de menor privilegio, verificación de la cadena de suministro y monitoreo continuo son esenciales para MCP y cargas de trabajo de IA.
- MCP introduce nuevos riesgos — como inyección de prompts, envenenamiento de herramientas y permisos excesivos — que requieren controles tanto tradicionales como específicos para IA.
- Usa prácticas robustas de autenticación, autorización y gestión de tokens, aprovechando proveedores de identidad externos como Microsoft Entra ID cuando sea posible.
- Protégete contra la inyección indirecta de prompts y el envenenamiento de herramientas validando los metadatos de las herramientas, monitoreando cambios dinámicos y usando soluciones como Microsoft Prompt Shields.
- Trata todos los componentes de tu cadena de suministro de IA — incluyendo modelos, embeddings y proveedores de contexto — con el mismo rigor que las dependencias de código.
- Mantente al día con las especificaciones MCP en evolución y contribuye a la comunidad para ayudar a definir estándares seguros.

# Recursos adicionales

- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [Prompt Injection en MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Ataques de envenenamiento de herramientas (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls en MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Documentación de Prompt Shields (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [El viaje para asegurar la cadena de suministro de software en Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acceso seguro con privilegios mínimos (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Mejores prácticas para la validación y duración de tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Usar almacenamiento seguro de tokens y cifrar tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management como puerta de enlace de autenticación para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Usar Microsoft Entra ID para autenticar con servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

### Siguiente

Siguiente: [Capítulo 3: Primeros pasos](/03-GettingStarted/README.md)

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables por malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.