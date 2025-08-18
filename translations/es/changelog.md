<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "245b03ae1e7973094fe82b8051ae0939",
  "translation_date": "2025-08-18T11:34:43+00:00",
  "source_file": "changelog.md",
  "language_code": "es"
}
-->
# Registro de cambios: Currículo de MCP para principiantes

Este documento sirve como registro de todos los cambios significativos realizados en el currículo del Protocolo de Contexto de Modelo (MCP) para principiantes. Los cambios están documentados en orden cronológico inverso (los cambios más recientes primero).

## 18 de agosto de 2025

### Actualización integral de la documentación - Estándares MCP 2025-06-18

#### Mejores prácticas de seguridad de MCP (02-Security/) - Modernización completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Reescritura completa alineada con la Especificación MCP 2025-06-18
  - **Requisitos obligatorios**: Se añadieron requisitos explícitos de DEBE/NO DEBE de la especificación oficial con indicadores visuales claros
  - **12 prácticas de seguridad fundamentales**: Reestructuración de una lista de 15 elementos a dominios de seguridad integrales
    - Seguridad de tokens y autenticación con integración de proveedores de identidad externos
    - Gestión de sesiones y seguridad de transporte con requisitos criptográficos
    - Protección contra amenazas específicas de IA con integración de Microsoft Prompt Shields
    - Control de acceso y permisos bajo el principio de privilegio mínimo
    - Seguridad y monitoreo de contenido con integración de Azure Content Safety
    - Seguridad de la cadena de suministro con verificación integral de componentes
    - Seguridad OAuth y prevención de ataques de "Confused Deputy" con implementación de PKCE
    - Respuesta y recuperación ante incidentes con capacidades automatizadas
    - Cumplimiento y gobernanza alineados con regulaciones
    - Controles avanzados de seguridad con arquitectura de confianza cero
    - Integración con el ecosistema de seguridad de Microsoft con soluciones completas
    - Evolución continua de la seguridad con prácticas adaptativas
  - **Soluciones de seguridad de Microsoft**: Guía mejorada para la integración de Prompt Shields, Azure Content Safety, Entra ID y GitHub Advanced Security
  - **Recursos de implementación**: Enlaces de recursos categorizados por Documentación oficial de MCP, Soluciones de seguridad de Microsoft, Estándares de seguridad y Guías de implementación

#### Controles avanzados de seguridad (02-Security/) - Implementación empresarial
- **MCP-SECURITY-CONTROLS-2025.md**: Revisión completa con un marco de seguridad de nivel empresarial
  - **9 dominios de seguridad integrales**: Ampliados de controles básicos a un marco detallado para empresas
    - Autenticación y autorización avanzadas con integración de Microsoft Entra ID
    - Seguridad de tokens y controles anti-passthrough con validación integral
    - Controles de seguridad de sesiones con prevención de secuestros
    - Controles de seguridad específicos de IA con prevención de inyecciones de prompts y envenenamiento de herramientas
    - Prevención de ataques de "Confused Deputy" con seguridad de proxy OAuth
    - Seguridad en la ejecución de herramientas con sandboxing y aislamiento
    - Controles de seguridad de la cadena de suministro con verificación de dependencias
    - Controles de monitoreo y detección con integración de SIEM
    - Respuesta y recuperación ante incidentes con capacidades automatizadas
  - **Ejemplos de implementación**: Se añadieron bloques de configuración YAML detallados y ejemplos de código
  - **Integración con soluciones de Microsoft**: Cobertura completa de servicios de seguridad de Azure, GitHub Advanced Security y gestión de identidad empresarial

#### Temas avanzados de seguridad (05-AdvancedTopics/mcp-security/) - Implementación lista para producción
- **README.md**: Reescritura completa para la implementación de seguridad empresarial
  - **Alineación con la especificación actual**: Actualizado a la Especificación MCP 2025-06-18 con requisitos de seguridad obligatorios
  - **Autenticación mejorada**: Integración de Microsoft Entra ID con ejemplos completos en .NET y Java Spring Security
  - **Integración de seguridad en IA**: Implementación de Microsoft Prompt Shields y Azure Content Safety con ejemplos detallados en Python
  - **Mitigación avanzada de amenazas**: Ejemplos de implementación completos para
    - Prevención de ataques de "Confused Deputy" con PKCE y validación de consentimiento del usuario
    - Prevención de passthrough de tokens con validación de audiencia y gestión segura de tokens
    - Prevención de secuestro de sesiones con vinculación criptográfica y análisis de comportamiento
  - **Integración de seguridad empresarial**: Monitoreo con Azure Application Insights, canalizaciones de detección de amenazas y seguridad de la cadena de suministro
  - **Lista de verificación de implementación**: Controles de seguridad obligatorios vs. recomendados con beneficios del ecosistema de seguridad de Microsoft

### Calidad de la documentación y alineación con estándares
- **Referencias a especificaciones**: Se actualizaron todas las referencias a la Especificación MCP 2025-06-18
- **Ecosistema de seguridad de Microsoft**: Guía mejorada para la integración en toda la documentación de seguridad
- **Implementación práctica**: Se añadieron ejemplos de código detallados en .NET, Java y Python con patrones empresariales
- **Organización de recursos**: Categorización integral de documentación oficial, estándares de seguridad y guías de implementación
- **Indicadores visuales**: Marcado claro de requisitos obligatorios vs. prácticas recomendadas

#### Conceptos básicos (01-CoreConcepts/) - Modernización completa
- **Actualización de versión del protocolo**: Actualizado para referenciar la Especificación MCP 2025-06-18 con versionado basado en fechas (formato AAAA-MM-DD)
- **Refinamiento de arquitectura**: Descripciones mejoradas de Hosts, Clientes y Servidores para reflejar patrones actuales de arquitectura MCP
  - Hosts definidos claramente como aplicaciones de IA que coordinan múltiples conexiones de clientes MCP
  - Clientes descritos como conectores de protocolo que mantienen relaciones uno a uno con servidores
  - Servidores mejorados con escenarios de despliegue local vs. remoto
- **Reestructuración de primitivas**: Revisión completa de primitivas de servidor y cliente
  - Primitivas del servidor: Recursos (fuentes de datos), Prompts (plantillas), Herramientas (funciones ejecutables) con explicaciones y ejemplos detallados
  - Primitivas del cliente: Muestreo (completaciones de LLM), Elicitación (entrada del usuario), Registro (depuración/monitoreo)
  - Actualizado con patrones actuales de descubrimiento (`*/list`), recuperación (`*/get`) y ejecución (`*/call`)
- **Arquitectura del protocolo**: Introducción de un modelo de arquitectura de dos capas
  - Capa de datos: Fundamento JSON-RPC 2.0 con gestión del ciclo de vida y primitivas
  - Capa de transporte: STDIO (local) y HTTP con SSE (remoto) como mecanismos de transporte
- **Marco de seguridad**: Principios de seguridad integrales que incluyen consentimiento explícito del usuario, protección de privacidad de datos, seguridad en la ejecución de herramientas y seguridad en la capa de transporte
- **Patrones de comunicación**: Mensajes del protocolo actualizados para mostrar flujos de inicialización, descubrimiento, ejecución y notificación
- **Ejemplos de código**: Ejemplos multilenguaje actualizados (.NET, Java, Python, JavaScript) para reflejar patrones actuales del SDK de MCP

#### Seguridad (02-Security/) - Revisión integral de seguridad
- **Alineación con estándares**: Alineación completa con los requisitos de seguridad de la Especificación MCP 2025-06-18
- **Evolución de la autenticación**: Documentada la evolución de servidores OAuth personalizados a delegación con proveedores de identidad externos (Microsoft Entra ID)
- **Análisis de amenazas específicas de IA**: Cobertura mejorada de vectores de ataque modernos en IA
  - Escenarios detallados de ataques de inyección de prompts con ejemplos del mundo real
  - Mecanismos de envenenamiento de herramientas y patrones de ataque "rug pull"
  - Envenenamiento de ventanas de contexto y ataques de confusión de modelos
- **Soluciones de seguridad de IA de Microsoft**: Cobertura integral del ecosistema de seguridad de Microsoft
  - Prompt Shields de IA con detección avanzada, delimitadores y técnicas de focalización
  - Patrones de integración de Azure Content Safety
  - GitHub Advanced Security para protección de la cadena de suministro
- **Mitigación avanzada de amenazas**: Controles de seguridad detallados para
  - Secuestro de sesiones con escenarios de ataque específicos de MCP y requisitos de ID de sesión criptográficos
  - Problemas de "Confused Deputy" en escenarios de proxy MCP con requisitos explícitos de consentimiento
  - Vulnerabilidades de passthrough de tokens con controles de validación obligatorios
- **Seguridad de la cadena de suministro**: Cobertura ampliada de la cadena de suministro de IA, incluyendo modelos base, servicios de embeddings, proveedores de contexto y APIs de terceros
- **Seguridad fundamental**: Integración mejorada con patrones de seguridad empresarial, incluyendo arquitectura de confianza cero y el ecosistema de seguridad de Microsoft
- **Organización de recursos**: Enlaces de recursos categorizados por tipo (Documentos oficiales, Estándares, Investigación, Soluciones de Microsoft, Guías de implementación)

### Mejoras en la calidad de la documentación
- **Objetivos de aprendizaje estructurados**: Objetivos de aprendizaje mejorados con resultados específicos y accionables
- **Referencias cruzadas**: Se añadieron enlaces entre temas relacionados de seguridad y conceptos básicos
- **Información actualizada**: Se actualizaron todas las referencias de fechas y enlaces de especificaciones a los estándares actuales
- **Guía de implementación**: Se añadieron pautas específicas y accionables de implementación en todas las secciones

## 16 de julio de 2025

### Mejoras en README y navegación
- Rediseño completo de la navegación del currículo en README.md
- Reemplazo de etiquetas `<details>` por un formato basado en tablas más accesible
- Creación de opciones de diseño alternativas en la nueva carpeta "alternative_layouts"
- Adición de ejemplos de navegación con estilo de tarjetas, pestañas y acordeón
- Actualización de la sección de estructura del repositorio para incluir todos los archivos más recientes
- Mejora de la sección "Cómo usar este currículo" con recomendaciones claras
- Actualización de enlaces de especificaciones de MCP para apuntar a las URLs correctas
- Adición de la sección de Ingeniería de Contexto (5.14) a la estructura del currículo

### Actualizaciones de la guía de estudio
- Revisión completa de la guía de estudio para alinearla con la estructura actual del repositorio
- Adición de nuevas secciones para Clientes y Herramientas MCP, y Servidores MCP populares
- Actualización del Mapa Visual del Currículo para reflejar con precisión todos los temas
- Mejora de las descripciones de Temas Avanzados para cubrir todas las áreas especializadas
- Actualización de la sección de Estudios de Caso para reflejar ejemplos reales
- Adición de este registro de cambios integral

### Contribuciones de la comunidad (06-CommunityContributions/)
- Adición de información detallada sobre servidores MCP para generación de imágenes
- Inclusión de una sección completa sobre el uso de Claude en VSCode
- Adición de instrucciones de configuración y uso del cliente terminal Cline
- Actualización de la sección de clientes MCP para incluir todas las opciones populares
- Mejora de ejemplos de contribución con muestras de código más precisas

### Temas avanzados (05-AdvancedTopics/)
- Organización de todas las carpetas de temas especializados con nombres consistentes
- Adición de materiales y ejemplos de ingeniería de contexto
- Documentación de integración de agentes Foundry
- Mejora de la documentación de integración de seguridad con Entra ID

## 11 de junio de 2025

### Creación inicial
- Publicación de la primera versión del currículo de MCP para principiantes
- Creación de la estructura básica para las 10 secciones principales
- Implementación del Mapa Visual del Currículo para la navegación
- Adición de proyectos de muestra iniciales en múltiples lenguajes de programación

### Primeros pasos (03-GettingStarted/)
- Creación de ejemplos de implementación de servidores iniciales
- Adición de orientación para el desarrollo de clientes
- Inclusión de instrucciones de integración de clientes LLM
- Adición de documentación de integración con VS Code
- Implementación de ejemplos de servidores con Server-Sent Events (SSE)

### Conceptos básicos (01-CoreConcepts/)
- Adición de explicaciones detalladas sobre la arquitectura cliente-servidor
- Creación de documentación sobre componentes clave del protocolo
- Documentación de patrones de mensajería en MCP

## 23 de mayo de 2025

### Estructura del repositorio
- Inicialización del repositorio con estructura básica de carpetas
- Creación de archivos README para cada sección principal
- Configuración de infraestructura de traducción
- Adición de activos de imagen y diagramas

### Documentación
- Creación del README.md inicial con una visión general del currículo
- Adición de CODE_OF_CONDUCT.md y SECURITY.md
- Configuración de SUPPORT.md con orientación para obtener ayuda
- Creación de la estructura preliminar de la guía de estudio

## 15 de abril de 2025

### Planificación y marco
- Planificación inicial del currículo de MCP para principiantes
- Definición de objetivos de aprendizaje y público objetivo
- Esbozo de la estructura de 10 secciones del currículo
- Desarrollo del marco conceptual para ejemplos y estudios de caso
- Creación de ejemplos prototipo iniciales para conceptos clave

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por garantizar la precisión, tenga en cuenta que las traducciones automatizadas pueden contener errores o imprecisiones. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas que puedan surgir del uso de esta traducción.