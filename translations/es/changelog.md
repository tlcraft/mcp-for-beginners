<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "56dd5af7e84cc0db6e17e310112109ae",
  "translation_date": "2025-09-15T21:50:33+00:00",
  "source_file": "changelog.md",
  "language_code": "es"
}
-->
# Registro de cambios: Currículo MCP para principiantes

Este documento sirve como registro de todos los cambios significativos realizados en el currículo del Protocolo de Contexto de Modelo (MCP) para principiantes. Los cambios están documentados en orden cronológico inverso (los cambios más recientes primero).

## 15 de septiembre de 2025

### Expansión de temas avanzados - Transportes personalizados y ingeniería de contexto

#### Transportes personalizados de MCP (05-AdvancedTopics/mcp-transport/) - Nueva guía avanzada de implementación
- **README.md**: Guía completa de implementación para mecanismos de transporte personalizados de MCP
  - **Transporte Azure Event Grid**: Implementación integral de transporte sin servidor basado en eventos
    - Ejemplos en C#, TypeScript y Python con integración de Azure Functions
    - Patrones de arquitectura basada en eventos para soluciones MCP escalables
    - Receptores de webhook y manejo de mensajes basado en empuje
  - **Transporte Azure Event Hubs**: Implementación de transporte de transmisión de alta capacidad
    - Capacidades de transmisión en tiempo real para escenarios de baja latencia
    - Estrategias de particionamiento y gestión de puntos de control
    - Agrupación de mensajes y optimización de rendimiento
  - **Patrones de integración empresarial**: Ejemplos arquitectónicos listos para producción
    - Procesamiento MCP distribuido en múltiples Azure Functions
    - Arquitecturas híbridas de transporte que combinan múltiples tipos de transporte
    - Estrategias de durabilidad, confiabilidad y manejo de errores de mensajes
  - **Seguridad y monitoreo**: Integración de Azure Key Vault y patrones de observabilidad
    - Autenticación con identidad administrada y acceso con privilegios mínimos
    - Telemetría de Application Insights y monitoreo de rendimiento
    - Interruptores de circuito y patrones de tolerancia a fallos
  - **Marcos de prueba**: Estrategias completas de prueba para transportes personalizados
    - Pruebas unitarias con dobles de prueba y marcos de simulación
    - Pruebas de integración con contenedores de prueba de Azure
    - Consideraciones de pruebas de rendimiento y carga

#### Ingeniería de contexto (05-AdvancedTopics/mcp-contextengineering/) - Disciplina emergente de IA
- **README.md**: Exploración completa de la ingeniería de contexto como campo emergente
  - **Principios fundamentales**: Compartir contexto completo, conciencia de decisiones de acción y gestión de ventanas de contexto
  - **Alineación con el protocolo MCP**: Cómo el diseño de MCP aborda los desafíos de la ingeniería de contexto
    - Limitaciones de ventanas de contexto y estrategias de carga progresiva
    - Determinación de relevancia y recuperación dinámica de contexto
    - Manejo de contexto multimodal y consideraciones de seguridad
  - **Enfoques de implementación**: Arquitecturas de un solo hilo frente a arquitecturas multiagente
    - Técnicas de fragmentación y priorización de contexto
    - Carga progresiva de contexto y estrategias de compresión
    - Enfoques de contexto en capas y optimización de recuperación
  - **Marco de medición**: Métricas emergentes para evaluar la efectividad del contexto
    - Eficiencia de entrada, rendimiento, calidad y consideraciones de experiencia del usuario
    - Enfoques experimentales para la optimización del contexto
    - Análisis de fallos y metodologías de mejora

#### Actualizaciones de navegación del currículo (README.md)
- **Estructura de módulos mejorada**: Tabla de currículo actualizada para incluir nuevos temas avanzados
  - Se añadieron las entradas de Ingeniería de Contexto (5.14) y Transporte Personalizado (5.15)
  - Formateo consistente y enlaces de navegación en todos los módulos
  - Descripciones actualizadas para reflejar el alcance actual del contenido

### Mejoras en la estructura del directorio
- **Estandarización de nombres**: Renombrado de "mcp transport" a "mcp-transport" para consistencia con otras carpetas de temas avanzados
- **Organización de contenido**: Todas las carpetas de 05-AdvancedTopics ahora siguen un patrón de nombres consistente (mcp-[tema])

### Mejoras en la calidad de la documentación
- **Alineación con la especificación MCP**: Todo el contenido nuevo hace referencia a la especificación MCP actual 2025-06-18
- **Ejemplos multilingües**: Ejemplos de código completos en C#, TypeScript y Python
- **Enfoque empresarial**: Patrones listos para producción e integración en la nube de Azure en todo el contenido
- **Documentación visual**: Diagramas Mermaid para visualización de arquitectura y flujo

## 18 de agosto de 2025

### Actualización integral de documentación - Estándares MCP 2025-06-18

#### Mejores prácticas de seguridad MCP (02-Security/) - Modernización completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Reescritura completa alineada con la especificación MCP 2025-06-18
  - **Requisitos obligatorios**: Se añadieron requisitos explícitos MUST/MUST NOT de la especificación oficial con indicadores visuales claros
  - **12 prácticas de seguridad fundamentales**: Reestructuradas de una lista de 15 ítems a dominios de seguridad completos
    - Seguridad de tokens y autenticación con integración de proveedores de identidad externos
    - Gestión de sesiones y seguridad de transporte con requisitos criptográficos
    - Protección contra amenazas específicas de IA con integración de Microsoft Prompt Shields
    - Control de acceso y permisos con el principio de privilegio mínimo
    - Seguridad de contenido y monitoreo con integración de Azure Content Safety
    - Seguridad de la cadena de suministro con verificación integral de componentes
    - Seguridad OAuth y prevención de ataques de delegado confundido con implementación PKCE
    - Respuesta a incidentes y recuperación con capacidades automatizadas
    - Cumplimiento y gobernanza con alineación regulatoria
    - Controles de seguridad avanzados con arquitectura de confianza cero
    - Integración del ecosistema de seguridad de Microsoft con soluciones completas
    - Evolución continua de seguridad con prácticas adaptativas
  - **Soluciones de seguridad de Microsoft**: Guía de integración mejorada para Prompt Shields, Azure Content Safety, Entra ID y GitHub Advanced Security
  - **Recursos de implementación**: Enlaces de recursos categorizados por Documentación oficial MCP, Soluciones de seguridad de Microsoft, Estándares de seguridad y Guías de implementación

#### Controles de seguridad avanzados (02-Security/) - Implementación empresarial
- **MCP-SECURITY-CONTROLS-2025.md**: Revisión completa con marco de seguridad empresarial
  - **9 dominios de seguridad completos**: Ampliados de controles básicos a un marco empresarial detallado
    - Autenticación y autorización avanzadas con integración de Microsoft Entra ID
    - Seguridad de tokens y controles contra el paso de tokens con validación integral
    - Controles de seguridad de sesiones con prevención de secuestro
    - Controles de seguridad específicos de IA con prevención de inyección de prompts y envenenamiento de herramientas
    - Prevención de ataques de delegado confundido con seguridad proxy OAuth
    - Seguridad en la ejecución de herramientas con aislamiento y sandboxing
    - Controles de seguridad de la cadena de suministro con verificación de dependencias
    - Controles de monitoreo y detección con integración SIEM
    - Respuesta a incidentes y recuperación con capacidades automatizadas
  - **Ejemplos de implementación**: Se añadieron bloques de configuración YAML detallados y ejemplos de código
  - **Integración de soluciones de Microsoft**: Cobertura completa de servicios de seguridad de Azure, GitHub Advanced Security y gestión de identidad empresarial

#### Seguridad en temas avanzados (05-AdvancedTopics/mcp-security/) - Implementación lista para producción
- **README.md**: Reescritura completa para implementación de seguridad empresarial
  - **Alineación con la especificación actual**: Actualizado a la especificación MCP 2025-06-18 con requisitos de seguridad obligatorios
  - **Autenticación mejorada**: Integración de Microsoft Entra ID con ejemplos completos en .NET y Java Spring Security
  - **Integración de seguridad IA**: Implementación de Microsoft Prompt Shields y Azure Content Safety con ejemplos detallados en Python
  - **Mitigación avanzada de amenazas**: Ejemplos de implementación completos para
    - Prevención de ataques de delegado confundido con PKCE y validación de consentimiento del usuario
    - Prevención de paso de tokens con validación de audiencia y gestión segura de tokens
    - Prevención de secuestro de sesiones con vinculación criptográfica y análisis de comportamiento
  - **Integración de seguridad empresarial**: Monitoreo de Application Insights de Azure, pipelines de detección de amenazas y seguridad de la cadena de suministro
  - **Lista de verificación de implementación**: Controles de seguridad obligatorios frente a recomendados con beneficios del ecosistema de seguridad de Microsoft

### Mejoras en la calidad y alineación de estándares de documentación
- **Referencias de especificación**: Actualización de todas las referencias a la especificación MCP actual 2025-06-18
- **Ecosistema de seguridad de Microsoft**: Guía de integración mejorada en toda la documentación de seguridad
- **Implementación práctica**: Ejemplos de código detallados en .NET, Java y Python con patrones empresariales
- **Organización de recursos**: Categorización completa de documentación oficial, estándares de seguridad y guías de implementación
- **Indicadores visuales**: Marcado claro de requisitos obligatorios frente a prácticas recomendadas

#### Conceptos fundamentales (01-CoreConcepts/) - Modernización completa
- **Actualización de versión del protocolo**: Actualizado para referenciar la especificación MCP actual 2025-06-18 con versionado basado en fechas (formato YYYY-MM-DD)
- **Refinamiento de arquitectura**: Descripciones mejoradas de Hosts, Clientes y Servidores para reflejar patrones actuales de arquitectura MCP
  - Hosts ahora definidos claramente como aplicaciones de IA que coordinan múltiples conexiones de clientes MCP
  - Clientes descritos como conectores de protocolo que mantienen relaciones uno a uno con servidores
  - Servidores mejorados con escenarios de despliegue local frente a remoto
- **Reestructuración de primitivas**: Revisión completa de primitivas de servidor y cliente
  - Primitivas de servidor: Recursos (fuentes de datos), Prompts (plantillas), Herramientas (funciones ejecutables) con explicaciones y ejemplos detallados
  - Primitivas de cliente: Muestreo (completaciones de LLM), Elicitación (entrada del usuario), Registro (depuración/monitoreo)
  - Actualizado con patrones actuales de descubrimiento (`*/list`), recuperación (`*/get`) y ejecución (`*/call`)
- **Arquitectura del protocolo**: Introducción de un modelo de arquitectura de dos capas
  - Capa de datos: Fundación JSON-RPC 2.0 con gestión del ciclo de vida y primitivas
  - Capa de transporte: STDIO (local) y HTTP transmisible con SSE (remoto)
- **Marco de seguridad**: Principios de seguridad completos incluyendo consentimiento explícito del usuario, protección de privacidad de datos, seguridad en la ejecución de herramientas y seguridad en la capa de transporte
- **Patrones de comunicación**: Mensajes de protocolo actualizados para mostrar flujos de inicialización, descubrimiento, ejecución y notificación
- **Ejemplos de código**: Ejemplos multilingües actualizados (.NET, Java, Python, JavaScript) para reflejar patrones actuales del SDK MCP

#### Seguridad (02-Security/) - Revisión integral de seguridad  
- **Alineación de estándares**: Alineación completa con los requisitos de seguridad de la especificación MCP 2025-06-18
- **Evolución de autenticación**: Documentación de la evolución de servidores OAuth personalizados a delegación de proveedores de identidad externos (Microsoft Entra ID)
- **Análisis de amenazas específicas de IA**: Cobertura mejorada de vectores de ataque modernos en IA
  - Escenarios detallados de ataques de inyección de prompts con ejemplos del mundo real
  - Mecanismos de envenenamiento de herramientas y patrones de ataque "rug pull"
  - Envenenamiento de ventanas de contexto y ataques de confusión de modelos
- **Soluciones de seguridad IA de Microsoft**: Cobertura completa del ecosistema de seguridad de Microsoft
  - Prompt Shields de IA con técnicas avanzadas de detección, delimitación y resaltado
  - Patrones de integración de Azure Content Safety
  - GitHub Advanced Security para protección de la cadena de suministro
- **Mitigación avanzada de amenazas**: Controles de seguridad detallados para
  - Secuestro de sesiones con escenarios de ataque específicos de MCP y requisitos de ID de sesión criptográficos
  - Problemas de delegado confundido en escenarios de proxy MCP con requisitos de consentimiento explícito
  - Vulnerabilidades de paso de tokens con controles de validación obligatorios
- **Seguridad de la cadena de suministro**: Cobertura ampliada de la cadena de suministro de IA incluyendo modelos base, servicios de embeddings, proveedores de contexto y APIs de terceros
- **Seguridad fundamental**: Integración mejorada con patrones de seguridad empresarial incluyendo arquitectura de confianza cero y ecosistema de seguridad de Microsoft
- **Organización de recursos**: Enlaces de recursos categorizados por tipo (Documentos oficiales, Estándares, Investigación, Soluciones de Microsoft, Guías de implementación)

### Mejoras en la calidad de la documentación
- **Objetivos de aprendizaje estructurados**: Objetivos de aprendizaje mejorados con resultados específicos y accionables 
- **Referencias cruzadas**: Enlaces añadidos entre temas relacionados de seguridad y conceptos fundamentales
- **Información actualizada**: Actualización de todas las referencias de fechas y enlaces de especificación a estándares actuales
- **Guía de implementación**: Directrices específicas y accionables añadidas en todas las secciones

## 16 de julio de 2025

### Mejoras en README y navegación
- Rediseño completo de la navegación del currículo en README.md
- Reemplazo de etiquetas `<details>` por un formato basado en tablas más accesible
- Creación de opciones de diseño alternativas en la nueva carpeta "alternative_layouts"
- Añadidos ejemplos de navegación estilo tarjetas, pestañas y acordeón
- Actualización de la sección de estructura del repositorio para incluir todos los archivos más recientes
- Mejora de la sección "Cómo usar este currículo" con recomendaciones claras
- Actualización de enlaces de especificación MCP para apuntar a las URLs correctas
- Añadida la sección de Ingeniería de Contexto (5.14) a la estructura del currículo

### Actualizaciones de la guía de estudio
- Revisión completa de la guía de estudio para alinearla con la estructura actual del repositorio
- Añadidas nuevas secciones para Clientes y Herramientas MCP, y Servidores MCP populares
- Actualización del Mapa Visual del Currículo para reflejar con precisión todos los temas
- Mejora de las descripciones de Temas Avanzados para cubrir todas las áreas especializadas
- Actualización de la sección de Estudios de Caso para reflejar ejemplos reales
- Añadido este registro de cambios completo

### Contribuciones de la comunidad (06-CommunityContributions/)
- Añadida información detallada sobre servidores MCP para generación de imágenes
- Añadida sección completa sobre el uso de Claude en VSCode
- Añadidas instrucciones de configuración y uso del cliente terminal Cline
- Actualización de la sección de clientes MCP para incluir todas las opciones populares de clientes
- Mejora de ejemplos de contribución con muestras de código más precisas

### Temas avanzados (05-AdvancedTopics/)
- Organización de todas las carpetas de temas especializados con nombres consistentes
- Añadidos materiales y ejemplos de ingeniería de contexto
- Añadida documentación de integración de agentes Foundry
- Mejora de la documentación de integración de seguridad Entra ID

## 11 de junio de 2025

### Creación inicial
- Lanzamiento de la primera versión del currículo MCP para principiantes
- Creación de la estructura básica para las 10 secciones principales
- Implementación del Mapa Visual del Currículo para navegación
- Añadidos proyectos de muestra iniciales en múltiples lenguajes de programación

### Primeros pasos (03-GettingStarted/)
- Creación de los primeros ejemplos de implementación de servidores
- Añadida guía de desarrollo de clientes
- Incluidas instrucciones de integración de clientes LLM
- Añadida documentación de integración con VS Code
- Implementación de ejemplos de servidores con Server-Sent Events (SSE)

### Conceptos fundamentales (01-CoreConcepts/)
- Añadida explicación detallada de la arquitectura cliente-servidor
- Creación de documentación sobre componentes clave del protocolo
- Documentación de patrones de mensajería en MCP

## 23 de mayo de 2025

### Estructura del repositorio
- Inicialización del repositorio con estructura básica de carpetas
- Creación de archivos README para cada sección principal
- Configuración de infraestructura de traducción
- Añadidos activos de imagen y diagramas

### Documentación
- Creación inicial de README.md con visión general del currículo
- Añadidos CODE_OF_CONDUCT.md y SECURITY.md
- Configuración de SUPPORT.md con orientación para obtener ayuda
- Creación de estructura preliminar de la guía de estudio

## 15 de abril de 2025

### Planificación y marco
- Planificación inicial del currículo MCP para principiantes
- Definición de objetivos de aprendizaje y audiencia objetivo
- Esbozo de la estructura de 10 secciones del currículo
- Desarrollo del marco conceptual para ejemplos y estudios de caso
- Creación de ejemplos prototipo iniciales para conceptos clave

---

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por garantizar la precisión, tenga en cuenta que las traducciones automatizadas pueden contener errores o imprecisiones. El documento original en su idioma nativo debe considerarse como la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas que puedan surgir del uso de esta traducción.