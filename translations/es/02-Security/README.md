<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "382fddb4ee4d9c1bdc806e2ee99b70c8",
  "translation_date": "2025-07-16T22:09:24+00:00",
  "source_file": "02-Security/README.md",
  "language_code": "es"
}
-->
# Mejores Prácticas de Seguridad

Adoptar el Protocolo de Contexto de Modelo (MCP) aporta nuevas capacidades potentes a las aplicaciones impulsadas por IA, pero también introduce desafíos de seguridad únicos que van más allá de los riesgos tradicionales del software. Además de preocupaciones establecidas como la codificación segura, el principio de menor privilegio y la seguridad de la cadena de suministro, MCP y las cargas de trabajo de IA enfrentan nuevas amenazas como la inyección de prompts, el envenenamiento de herramientas, la modificación dinámica de herramientas, el secuestro de sesiones, ataques de delegado confundido y vulnerabilidades de paso de tokens. Estos riesgos pueden conducir a la exfiltración de datos, violaciones de privacidad y comportamientos no deseados del sistema si no se gestionan adecuadamente.

Esta lección explora los riesgos de seguridad más relevantes asociados con MCP — incluyendo autenticación, autorización, permisos excesivos, inyección indirecta de prompts, seguridad de sesiones, problemas de delegado confundido, vulnerabilidades de paso de tokens y vulnerabilidades en la cadena de suministro — y proporciona controles prácticos y mejores prácticas para mitigarlos. También aprenderás a aprovechar soluciones de Microsoft como Prompt Shields, Azure Content Safety y GitHub Advanced Security para fortalecer tu implementación de MCP. Al entender y aplicar estos controles, podrás reducir significativamente la probabilidad de una brecha de seguridad y asegurar que tus sistemas de IA se mantengan robustos y confiables.

# Objetivos de Aprendizaje

Al finalizar esta lección, serás capaz de:

- Identificar y explicar los riesgos de seguridad únicos que introduce el Protocolo de Contexto de Modelo (MCP), incluyendo inyección de prompts, envenenamiento de herramientas, permisos excesivos, secuestro de sesiones, problemas de delegado confundido, vulnerabilidades de paso de tokens y vulnerabilidades en la cadena de suministro.
- Describir y aplicar controles efectivos para mitigar los riesgos de seguridad de MCP, tales como autenticación robusta, principio de menor privilegio, gestión segura de tokens, controles de seguridad de sesiones y verificación de la cadena de suministro.
- Entender y aprovechar soluciones de Microsoft como Prompt Shields, Azure Content Safety y GitHub Advanced Security para proteger MCP y las cargas de trabajo de IA.
- Reconocer la importancia de validar los metadatos de las herramientas, monitorear cambios dinámicos, defenderse contra ataques de inyección indirecta de prompts y prevenir el secuestro de sesiones.
- Integrar las mejores prácticas de seguridad establecidas — como codificación segura, endurecimiento de servidores y arquitectura de confianza cero — en tu implementación de MCP para reducir la probabilidad e impacto de brechas de seguridad.

# Controles de seguridad MCP

Cualquier sistema que tenga acceso a recursos importantes presenta desafíos de seguridad implícitos. Generalmente, estos desafíos pueden abordarse mediante la correcta aplicación de controles y conceptos fundamentales de seguridad. Como MCP es un protocolo recién definido, la especificación está cambiando rápidamente y evolucionando. Eventualmente, los controles de seguridad dentro de él madurarán, permitiendo una mejor integración con arquitecturas empresariales y mejores prácticas de seguridad establecidas.

La investigación publicada en el [Microsoft Digital Defense Report](https://aka.ms/mddr) indica que el 98% de las brechas reportadas podrían prevenirse con una higiene de seguridad robusta, y la mejor protección contra cualquier tipo de brecha es tener una higiene de seguridad básica adecuada, buenas prácticas de codificación segura y seguridad en la cadena de suministro — esas prácticas probadas que ya conocemos siguen siendo las que más impacto tienen en la reducción del riesgo de seguridad.

Veamos algunas formas en que puedes comenzar a abordar los riesgos de seguridad al adoptar MCP.

> **Note:** La siguiente información es correcta a fecha de **29 de mayo de 2025**. El protocolo MCP está en constante evolución, y futuras implementaciones pueden introducir nuevos patrones y controles de autenticación. Para las últimas actualizaciones y guías, siempre consulta la [Especificación MCP](https://spec.modelcontextprotocol.io/) y el repositorio oficial de [MCP en GitHub](https://github.com/modelcontextprotocol) y la [página de mejores prácticas de seguridad](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices).

### Declaración del problema  
La especificación original de MCP asumía que los desarrolladores escribirían su propio servidor de autenticación. Esto requería conocimiento de OAuth y restricciones de seguridad relacionadas. Los servidores MCP actuaban como Servidores de Autorización OAuth 2.0, gestionando la autenticación de usuario requerida directamente en lugar de delegarla a un servicio externo como Microsoft Entra ID. A partir del **26 de abril de 2025**, una actualización de la especificación MCP permite que los servidores MCP deleguen la autenticación de usuario a un servicio externo.

### Riesgos
- Una lógica de autorización mal configurada en el servidor MCP puede llevar a la exposición de datos sensibles y a controles de acceso aplicados incorrectamente.
- Robo de tokens OAuth en el servidor MCP local. Si se roba el token, puede usarse para suplantar al servidor MCP y acceder a recursos y datos del servicio para el que fue emitido el token OAuth.

#### Paso de tokens
El paso de tokens está explícitamente prohibido en la especificación de autorización ya que introduce varios riesgos de seguridad, que incluyen:

#### Evasión de controles de seguridad
El servidor MCP o las APIs aguas abajo podrían implementar controles de seguridad importantes como limitación de tasa, validación de solicitudes o monitoreo de tráfico, que dependen del público del token u otras restricciones de credenciales. Si los clientes pueden obtener y usar tokens directamente con las APIs aguas abajo sin que el servidor MCP los valide correctamente o asegure que los tokens fueron emitidos para el servicio correcto, evaden estos controles.

#### Problemas de responsabilidad y auditoría
El servidor MCP no podrá identificar o distinguir entre clientes MCP cuando estos llamen con un token de acceso emitido aguas arriba que puede ser opaco para el servidor MCP.  
Los registros del servidor de recursos aguas abajo pueden mostrar solicitudes que parecen provenir de una fuente diferente con una identidad distinta, en lugar del servidor MCP que realmente está reenviando los tokens.  
Ambos factores dificultan la investigación de incidentes, el control y la auditoría.  
Si el servidor MCP pasa tokens sin validar sus claims (por ejemplo, roles, privilegios o público) u otros metadatos, un actor malicioso en posesión de un token robado puede usar el servidor como proxy para la exfiltración de datos.

#### Problemas en el límite de confianza
El servidor de recursos aguas abajo otorga confianza a entidades específicas. Esta confianza puede incluir suposiciones sobre el origen o patrones de comportamiento del cliente. Romper este límite de confianza podría causar problemas inesperados.  
Si el token es aceptado por múltiples servicios sin una validación adecuada, un atacante que comprometa un servicio puede usar el token para acceder a otros servicios conectados.

#### Riesgo de compatibilidad futura
Aunque un servidor MCP comience hoy como un "proxy puro", podría necesitar agregar controles de seguridad más adelante. Comenzar con una separación adecuada del público del token facilita la evolución del modelo de seguridad.

### Controles mitigantes

**Los servidores MCP NO DEBEN aceptar tokens que no hayan sido emitidos explícitamente para el servidor MCP**

- **Revisar y fortalecer la lógica de autorización:** Audita cuidadosamente la implementación de autorización de tu servidor MCP para asegurar que solo los usuarios y clientes previstos puedan acceder a recursos sensibles. Para orientación práctica, consulta [Azure API Management Your Auth Gateway For MCP Servers | Microsoft Community Hub](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690) y [Using Microsoft Entra ID To Authenticate With MCP Servers Via Sessions - Den Delimarsky](https://den.dev/blog/mcp-server-auth-entra-id-session/).
- **Aplicar prácticas seguras de manejo de tokens:** Sigue las [mejores prácticas de Microsoft para validación y duración de tokens](https://learn.microsoft.com/en-us/entra/identity-platform/access-tokens) para prevenir el mal uso de tokens de acceso y reducir el riesgo de repetición o robo de tokens.
- **Proteger el almacenamiento de tokens:** Siempre almacena los tokens de forma segura y usa cifrado para protegerlos en reposo y en tránsito. Para consejos de implementación, consulta [Use secure token storage and encrypt tokens](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2).

# Permisos excesivos para servidores MCP

### Declaración del problema  
Los servidores MCP pueden haber recibido permisos excesivos para el servicio o recurso al que acceden. Por ejemplo, un servidor MCP que forma parte de una aplicación de ventas con IA que se conecta a un almacén de datos empresarial debería tener acceso limitado a los datos de ventas y no poder acceder a todos los archivos del almacén. Volviendo al principio de menor privilegio (uno de los principios de seguridad más antiguos), ningún recurso debería tener permisos superiores a los necesarios para ejecutar las tareas para las que fue diseñado. La IA presenta un desafío mayor en este ámbito porque, para que sea flexible, puede ser difícil definir exactamente los permisos requeridos.

### Riesgos  
- Otorgar permisos excesivos puede permitir la exfiltración o modificación de datos a los que el servidor MCP no debería tener acceso. Esto también podría ser un problema de privacidad si los datos son información personal identificable (PII).

### Controles mitigantes  
- **Aplicar el principio de menor privilegio:** Otorga al servidor MCP solo los permisos mínimos necesarios para realizar sus tareas. Revisa y actualiza regularmente estos permisos para asegurarte de que no excedan lo necesario. Para orientación detallada, consulta [Secure least-privileged access](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access).
- **Usar control de acceso basado en roles (RBAC):** Asigna roles al servidor MCP que estén estrictamente limitados a recursos y acciones específicas, evitando permisos amplios o innecesarios.
- **Monitorear y auditar permisos:** Supervisa continuamente el uso de permisos y audita los registros de acceso para detectar y corregir privilegios excesivos o no utilizados de forma oportuna.

# Ataques de inyección indirecta de prompts

### Declaración del problema

Servidores MCP maliciosos o comprometidos pueden introducir riesgos significativos al exponer datos de clientes o permitir acciones no deseadas. Estos riesgos son especialmente relevantes en cargas de trabajo basadas en IA y MCP, donde:

- **Ataques de inyección de prompts:** Los atacantes incrustan instrucciones maliciosas en prompts o contenido externo, haciendo que el sistema de IA realice acciones no deseadas o filtre datos sensibles. Más información: [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- **Envenenamiento de herramientas:** Los atacantes manipulan los metadatos de las herramientas (como descripciones o parámetros) para influir en el comportamiento de la IA, potencialmente evadiendo controles de seguridad o exfiltrando datos. Detalles: [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- **Inyección de prompts cross-domain:** Instrucciones maliciosas se incrustan en documentos, páginas web o correos electrónicos, que luego son procesados por la IA, causando filtración o manipulación de datos.
- **Modificación dinámica de herramientas (Rug Pulls):** Las definiciones de herramientas pueden cambiar después de la aprobación del usuario, introduciendo nuevos comportamientos maliciosos sin que el usuario lo sepa.

Estas vulnerabilidades resaltan la necesidad de validación robusta, monitoreo y controles de seguridad al integrar servidores MCP y herramientas en tu entorno. Para un análisis más profundo, consulta las referencias enlazadas arriba.

![prompt-injection-lg-2048x1034](../../../translated_images/prompt-injection.ed9fbfde297ca877c15bc6daa808681cd3c3dc7bf27bbbda342ef1ba5fc4f52d.es.png)

**Inyección Indirecta de Prompts** (también conocida como inyección de prompts cross-domain o XPIA) es una vulnerabilidad crítica en sistemas de IA generativa, incluidos aquellos que usan el Protocolo de Contexto de Modelo (MCP). En este ataque, instrucciones maliciosas se ocultan dentro de contenido externo — como documentos, páginas web o correos electrónicos. Cuando el sistema de IA procesa este contenido, puede interpretar las instrucciones incrustadas como comandos legítimos del usuario, resultando en acciones no deseadas como filtración de datos, generación de contenido dañino o manipulación de interacciones con el usuario. Para una explicación detallada y ejemplos reales, consulta [Prompt Injection](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/).

Una forma particularmente peligrosa de este ataque es el **Envenenamiento de Herramientas**. Aquí, los atacantes inyectan instrucciones maliciosas en los metadatos de las herramientas MCP (como descripciones o parámetros). Dado que los modelos de lenguaje grandes (LLMs) dependen de estos metadatos para decidir qué herramientas invocar, descripciones comprometidas pueden engañar al modelo para ejecutar llamadas a herramientas no autorizadas o evadir controles de seguridad. Estas manipulaciones suelen ser invisibles para los usuarios finales, pero pueden ser interpretadas y ejecutadas por el sistema de IA. Este riesgo se incrementa en entornos de servidores MCP alojados, donde las definiciones de herramientas pueden actualizarse después de la aprobación del usuario — un escenario a veces llamado "[rug pull](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)". En tales casos, una herramienta que antes era segura puede ser modificada posteriormente para realizar acciones maliciosas, como exfiltrar datos o alterar el comportamiento del sistema, sin que el usuario lo sepa. Para más información sobre este vector de ataque, consulta [Tool Poisoning](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks).

![tool-injection-lg-2048x1239 (1)](../../../translated_images/tool-injection.3b0b4a6b24de6befe7d3afdeae44138ef005881aebcfc84c6f61369ce31e3640.es.png)

## Riesgos  
Las acciones no deseadas de la IA presentan una variedad de riesgos de seguridad que incluyen exfiltración de datos y violaciones de privacidad.

### Controles mitigantes  
### Uso de prompt shields para proteger contra ataques de inyección indirecta de prompts
-----------------------------------------------------------------------------

**AI Prompt Shields** son una solución desarrollada por Microsoft para defenderse contra ataques de inyección de prompts directos e indirectos. Ayudan mediante:

1.  **Detección y filtrado:** Prompt Shields utilizan algoritmos avanzados de aprendizaje automático y procesamiento de lenguaje natural para detectar y filtrar instrucciones maliciosas incrustadas en contenido externo, como documentos, páginas web o correos electrónicos.
    
2.  **Spotlighting:** Esta técnica ayuda al sistema de IA a distinguir entre instrucciones válidas del sistema y entradas externas potencialmente no confiables. Al transformar el texto de entrada de manera que sea más relevante para el modelo, Spotlighting asegura que la IA pueda identificar y ignorar mejor las instrucciones maliciosas.
    
3.  **Delimitadores y marcado de datos:** Incluir delimitadores en el mensaje del sistema señala explícitamente la ubicación del texto de entrada, ayudando al sistema de IA a reconocer y separar las entradas del usuario del contenido externo potencialmente dañino. El marcado de datos extiende este concepto usando marcadores especiales para resaltar los límites de datos confiables y no confiables.
    
4.  **Monitoreo y actualizaciones continuas:** Microsoft monitorea y actualiza continuamente Prompt Shields para abordar amenazas nuevas y en evolución. Este enfoque proactivo asegura que las defensas sigan siendo efectivas contra las técnicas de ataque más recientes.
    
5. **Integración con Azure Content Safety:** Prompt Shields forman parte de la suite más amplia Azure AI Content Safety, que proporciona herramientas adicionales para detectar intentos de jailbreak, contenido dañino y otros riesgos de seguridad en aplicaciones de IA.

Puedes leer más sobre AI prompt shields en la [documentación de Prompt Shields](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection).

![prompt-shield-lg-2048x1328](../../../translated_images/prompt-shield.ff5b95be76e9c78c6ec0888206a4a6a0a5ab4bb787832a9eceef7a62fe0138d1.es.png)

# Problema del Delegado Confundido

### Declaración del problema
El problema del delegado confundido es una vulnerabilidad de seguridad que ocurre cuando un servidor MCP actúa como proxy entre clientes MCP y APIs de terceros. Esta vulnerabilidad puede ser explotada cuando el servidor MCP utiliza un ID de cliente estático para autenticarse con un servidor de autorización de terceros que no soporta el registro dinámico de clientes.

### Riesgos

- **Evasión del consentimiento basada en cookies**: Si un usuario se ha autenticado previamente a través del servidor proxy MCP, un servidor de autorización de terceros puede establecer una cookie de consentimiento en el navegador del usuario. Un atacante puede luego aprovechar esto enviando al usuario un enlace malicioso con una solicitud de autorización manipulada que contiene un URI de redirección malicioso.
- **Robo del código de autorización**: Cuando el usuario hace clic en el enlace malicioso, el servidor de autorización de terceros puede omitir la pantalla de consentimiento debido a la cookie existente, y el código de autorización podría ser redirigido al servidor del atacante.
- **Acceso no autorizado a la API**: El atacante puede intercambiar el código de autorización robado por tokens de acceso e impersonar al usuario para acceder a la API de terceros sin aprobación explícita.

### Controles mitigantes

- **Requisitos de consentimiento explícito**: Los servidores proxy MCP que usan IDs de cliente estáticos **DEBEN** obtener el consentimiento del usuario para cada cliente registrado dinámicamente antes de reenviar a los servidores de autorización de terceros.
- **Implementación adecuada de OAuth**: Seguir las mejores prácticas de seguridad de OAuth 2.1, incluyendo el uso de desafíos de código (PKCE) para solicitudes de autorización para prevenir ataques de interceptación.
- **Validación del cliente**: Implementar una validación estricta de los URIs de redirección e identificadores de cliente para evitar la explotación por actores maliciosos.


# Vulnerabilidades de paso de tokens

### Declaración del problema

El "paso de tokens" es un antipatrón donde un servidor MCP acepta tokens de un cliente MCP sin validar que los tokens fueron emitidos correctamente para el propio servidor MCP, y luego los "pasa" a APIs aguas abajo. Esta práctica viola explícitamente la especificación de autorización MCP e introduce riesgos serios de seguridad.

### Riesgos

- **Circunvención de controles de seguridad**: Los clientes podrían evadir controles importantes como limitación de tasa, validación de solicitudes o monitoreo de tráfico si pueden usar tokens directamente con APIs aguas abajo sin la validación adecuada.
- **Problemas de responsabilidad y auditoría**: El servidor MCP no podrá identificar ni distinguir entre clientes MCP cuando estos usen tokens de acceso emitidos aguas arriba, dificultando la investigación de incidentes y auditorías.
- **Exfiltración de datos**: Si los tokens se pasan sin una validación adecuada de las claims, un actor malicioso con un token robado podría usar el servidor como proxy para la exfiltración de datos.
- **Violaciones del límite de confianza**: Los servidores de recursos aguas abajo pueden otorgar confianza a entidades específicas con suposiciones sobre el origen o patrones de comportamiento. Romper este límite de confianza podría causar problemas de seguridad inesperados.
- **Uso indebido de tokens multi-servicio**: Si los tokens son aceptados por múltiples servicios sin la validación adecuada, un atacante que comprometa un servicio podría usar el token para acceder a otros servicios conectados.

### Controles mitigantes

- **Validación de tokens**: Los servidores MCP **NO DEBEN** aceptar tokens que no hayan sido emitidos explícitamente para el propio servidor MCP.
- **Verificación de audiencia**: Siempre validar que los tokens tengan la claim de audiencia correcta que coincida con la identidad del servidor MCP.
- **Gestión adecuada del ciclo de vida del token**: Implementar tokens de acceso de corta duración y prácticas adecuadas de rotación de tokens para reducir el riesgo de robo y uso indebido.


# Secuestro de sesión

### Declaración del problema

El secuestro de sesión es un vector de ataque donde un cliente recibe un ID de sesión por parte del servidor, y un tercero no autorizado obtiene y usa ese mismo ID de sesión para suplantar al cliente original y realizar acciones no autorizadas en su nombre. Esto es especialmente preocupante en servidores HTTP con estado que manejan solicitudes MCP.

### Riesgos

- **Inyección de prompt por secuestro de sesión**: Un atacante que obtiene un ID de sesión podría enviar eventos maliciosos a un servidor que comparte el estado de sesión con el servidor al que está conectado el cliente, potencialmente desencadenando acciones dañinas o accediendo a datos sensibles.
- **Suplantación por secuestro de sesión**: Un atacante con un ID de sesión robado podría hacer llamadas directamente al servidor MCP, eludiendo la autenticación y siendo tratado como el usuario legítimo.
- **Streams reanudables comprometidos**: Cuando un servidor soporta redelivery o streams reanudables, un atacante podría terminar una solicitud prematuramente, lo que llevaría a que sea reanudada más tarde por el cliente original con contenido potencialmente malicioso.

### Controles mitigantes

- **Verificación de autorización**: Los servidores MCP que implementen autorización **DEBEN** verificar todas las solicitudes entrantes y **NO DEBEN** usar sesiones para autenticación.
- **IDs de sesión seguros**: Los servidores MCP **DEBEN** usar IDs de sesión seguros y no determinísticos generados con generadores de números aleatorios seguros. Evitar identificadores predecibles o secuenciales.
- **Vinculación de sesión específica por usuario**: Los servidores MCP **DEBERÍAN** vincular los IDs de sesión con información específica del usuario, combinando el ID de sesión con información única del usuario autorizado (como su ID interno) usando un formato como `
<user_id>:<session_id>`.
- **Expiración de sesión**: Implementar una expiración y rotación adecuada de sesiones para limitar la ventana de vulnerabilidad si un ID de sesión es comprometido.
- **Seguridad en el transporte**: Usar siempre HTTPS para toda la comunicación para evitar la interceptación de IDs de sesión.


# Seguridad en la cadena de suministro

La seguridad en la cadena de suministro sigue siendo fundamental en la era de la IA, pero el alcance de lo que constituye tu cadena de suministro se ha ampliado. Además de los paquetes de código tradicionales, ahora debes verificar y monitorear rigurosamente todos los componentes relacionados con IA, incluyendo modelos base, servicios de embeddings, proveedores de contexto y APIs de terceros. Cada uno de estos puede introducir vulnerabilidades o riesgos si no se gestionan adecuadamente.

**Prácticas clave de seguridad en la cadena de suministro para IA y MCP:**
- **Verificar todos los componentes antes de la integración:** Esto incluye no solo bibliotecas de código abierto, sino también modelos de IA, fuentes de datos y APIs externas. Siempre revisar la procedencia, licencias y vulnerabilidades conocidas.
- **Mantener pipelines de despliegue seguros:** Usar pipelines CI/CD automatizados con escaneo de seguridad integrado para detectar problemas temprano. Asegurar que solo artefactos confiables se desplieguen en producción.
- **Monitoreo y auditoría continua:** Implementar monitoreo constante para todas las dependencias, incluyendo modelos y servicios de datos, para detectar nuevas vulnerabilidades o ataques a la cadena de suministro.
- **Aplicar el principio de menor privilegio y controles de acceso:** Restringir el acceso a modelos, datos y servicios solo a lo necesario para que el servidor MCP funcione.
- **Responder rápidamente a amenazas:** Tener un proceso para parchear o reemplazar componentes comprometidos, y para rotar secretos o credenciales si se detecta una brecha.

[GitHub Advanced Security](https://github.com/security/advanced-security) ofrece características como escaneo de secretos, escaneo de dependencias y análisis con CodeQL. Estas herramientas se integran con [Azure DevOps](https://azure.microsoft.com/en-us/products/devops) y [Azure Repos](https://azure.microsoft.com/en-us/products/devops/repos/) para ayudar a los equipos a identificar y mitigar vulnerabilidades tanto en el código como en los componentes de la cadena de suministro de IA.

Microsoft también implementa prácticas extensas de seguridad en la cadena de suministro internamente para todos sus productos. Aprende más en [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/).


# Mejores prácticas de seguridad establecidas que mejorarán la postura de seguridad de tu implementación MCP

Cualquier implementación MCP hereda la postura de seguridad existente del entorno de tu organización sobre el que se construye, por lo que al considerar la seguridad de MCP como un componente de tus sistemas de IA en general, se recomienda mejorar la postura de seguridad general existente. Los siguientes controles de seguridad establecidos son especialmente relevantes:

-   Mejores prácticas de codificación segura en tu aplicación de IA - proteger contra [el OWASP Top 10](https://owasp.org/www-project-top-ten/), el [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559), uso de bóvedas seguras para secretos y tokens, implementación de comunicaciones seguras de extremo a extremo entre todos los componentes de la aplicación, etc.
-   Endurecimiento del servidor -- usar MFA donde sea posible, mantener los parches actualizados, integrar el servidor con un proveedor de identidad externo para el acceso, etc.
-   Mantener dispositivos, infraestructura y aplicaciones actualizados con parches
-   Monitoreo de seguridad -- implementar registro y monitoreo de una aplicación de IA (incluyendo clientes/servidores MCP) y enviar esos registros a un SIEM central para detectar actividades anómalas
-   Arquitectura de confianza cero -- aislar componentes mediante controles de red e identidad de manera lógica para minimizar movimientos laterales si una aplicación de IA es comprometida.

# Puntos clave

- Los fundamentos de seguridad siguen siendo críticos: codificación segura, principio de menor privilegio, verificación de la cadena de suministro y monitoreo continuo son esenciales para MCP y cargas de trabajo de IA.
- MCP introduce nuevos riesgos—como inyección de prompt, envenenamiento de herramientas, secuestro de sesión, problemas de delegado confundido, vulnerabilidades de paso de tokens y permisos excesivos—que requieren controles tanto tradicionales como específicos para IA.
- Usar prácticas robustas de autenticación, autorización y gestión de tokens, aprovechando proveedores de identidad externos como Microsoft Entra ID cuando sea posible.
- Proteger contra inyección indirecta de prompt y envenenamiento de herramientas validando metadatos de herramientas, monitoreando cambios dinámicos y usando soluciones como Microsoft Prompt Shields.
- Implementar gestión segura de sesiones usando IDs de sesión no determinísticos, vinculando sesiones a identidades de usuario y nunca usando sesiones para autenticación.
- Prevenir ataques de delegado confundido requiriendo consentimiento explícito del usuario para cada cliente registrado dinámicamente e implementando prácticas adecuadas de seguridad OAuth.
- Evitar vulnerabilidades de paso de tokens asegurando que los servidores MCP solo acepten tokens emitidos explícitamente para ellos y validen adecuadamente las claims de los tokens.
- Tratar todos los componentes en tu cadena de suministro de IA—incluyendo modelos, embeddings y proveedores de contexto—con el mismo rigor que las dependencias de código.
- Mantenerse actualizado con las especificaciones MCP en evolución y contribuir a la comunidad para ayudar a moldear estándares seguros.

# Recursos adicionales

## Recursos externos
- [Microsoft Digital Defense Report](https://aka.ms/mddr)
- [Especificación MCP](https://spec.modelcontextprotocol.io/)
- [Mejores prácticas de seguridad MCP](https://modelcontextprotocol.io/specification/draft/basic/security_best_practices)
- [Especificación de autorización MCP](https://modelcontextprotocol.io/specification/draft/basic/authorization)
- [Mejores prácticas de seguridad OAuth 2.0 (RFC 9700)](https://datatracker.ietf.org/doc/html/rfc9700)
- [Inyección de prompt en MCP (Simon Willison)](https://simonwillison.net/2025/Apr/9/mcp-prompt-injection/)
- [Ataques de envenenamiento de herramientas (Invariant Labs)](https://invariantlabs.ai/blog/mcp-security-notification-tool-poisoning-attacks)
- [Rug Pulls en MCP (Wiz Security)](https://www.wiz.io/blog/mcp-security-research-briefing#remote-servers-22)
- [Documentación de Prompt Shields (Microsoft)](https://learn.microsoft.com/azure/ai-services/content-safety/concepts/jailbreak-detection)
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [OWASP Top 10 para LLMs](https://genai.owasp.org/download/43299/?tmstv=1731900559)
- [GitHub Advanced Security](https://github.com/security/advanced-security)
- [Azure DevOps](https://azure.microsoft.com/products/devops)
- [Azure Repos](https://azure.microsoft.com/products/devops/repos/)
- [The Journey to Secure the Software Supply Chain at Microsoft](https://devblogs.microsoft.com/engineering-at-microsoft/the-journey-to-secure-the-software-supply-chain-at-microsoft/)
- [Acceso seguro con menor privilegio (Microsoft)](https://learn.microsoft.com/entra/identity-platform/secure-least-privileged-access)
- [Mejores prácticas para validación y duración de tokens](https://learn.microsoft.com/entra/identity-platform/access-tokens)
- [Uso de almacenamiento seguro de tokens y cifrado de tokens (YouTube)](https://youtu.be/uRdX37EcCwg?si=6fSChs1G4glwXRy2)
- [Azure API Management como puerta de autenticación para MCP](https://techcommunity.microsoft.com/blog/integrationsonazureblog/azure-api-management-your-auth-gateway-for-mcp-servers/4402690)
- [Uso de Microsoft Entra ID para autenticarse con servidores MCP](https://den.dev/blog/mcp-server-auth-entra-id-session/)

## Documentos adicionales de seguridad

Para una guía de seguridad más detallada, consulta estos documentos:

- [Mejores prácticas de seguridad MCP 2025](./mcp-security-best-practices-2025.md) - Lista completa de mejores prácticas de seguridad para implementaciones MCP
- [Implementación de Azure Content Safety](./azure-content-safety-implementation.md) - Ejemplos de implementación para integrar Azure Content Safety con servidores MCP
- [Controles de seguridad MCP 2025](./mcp-security-controls-2025.md) - Controles y técnicas de seguridad más recientes para asegurar despliegues MCP
- [Mejores prácticas MCP](./mcp-best-practices.md) - Guía rápida de referencia para seguridad MCP

### Siguiente

Siguiente: [Capítulo 3: Primeros pasos](../03-GettingStarted/README.md)

**Aviso legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda la traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.