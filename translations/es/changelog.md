<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f9d56a1327805a9f6df085a41fb81083",
  "translation_date": "2025-09-30T13:22:38+00:00",
  "source_file": "changelog.md",
  "language_code": "es"
}
-->
# Registro de cambios: Currículo MCP para principiantes

Este documento sirve como registro de todos los cambios significativos realizados en el currículo del Protocolo de Contexto de Modelo (MCP) para principiantes. Los cambios están documentados en orden cronológico inverso (los más recientes primero).

## 29 de septiembre de 2025

### Laboratorios de integración de bases de datos del servidor MCP - Ruta de aprendizaje práctica integral

#### 11-MCPServerHandsOnLabs - Nuevo currículo completo de integración de bases de datos
- **Ruta de aprendizaje de 13 laboratorios**: Se agregó un currículo práctico integral para construir servidores MCP listos para producción con integración de bases de datos PostgreSQL.
  - **Implementación en el mundo real**: Caso de uso de análisis de Zava Retail que demuestra patrones de nivel empresarial.
  - **Progresión estructurada de aprendizaje**:
    - **Laboratorios 00-03: Fundamentos** - Introducción, arquitectura central, seguridad y multi-tenencia, configuración del entorno.
    - **Laboratorios 04-06: Construcción del servidor MCP** - Diseño y esquema de base de datos, implementación del servidor MCP, desarrollo de herramientas.
    - **Laboratorios 07-09: Funciones avanzadas** - Integración de búsqueda semántica, pruebas y depuración, integración con VS Code.
    - **Laboratorios 10-12: Producción y mejores prácticas** - Estrategias de despliegue, monitoreo y observabilidad, mejores prácticas y optimización.
  - **Tecnologías empresariales**: Framework FastMCP, PostgreSQL con pgvector, embeddings de Azure OpenAI, Azure Container Apps, Application Insights.
  - **Funciones avanzadas**: Seguridad a nivel de fila (RLS), búsqueda semántica, acceso a datos multi-tenant, embeddings vectoriales, monitoreo en tiempo real.

#### Estandarización de terminología - Conversión de módulo a laboratorio
- **Actualización completa de documentación**: Se actualizaron sistemáticamente todos los archivos README en 11-MCPServerHandsOnLabs para usar la terminología "Laboratorio" en lugar de "Módulo".
  - **Encabezados de sección**: Se actualizó "Qué cubre este módulo" a "Qué cubre este laboratorio" en los 13 laboratorios.
  - **Descripción del contenido**: Se cambió "Este módulo proporciona..." a "Este laboratorio proporciona..." en toda la documentación.
  - **Objetivos de aprendizaje**: Se actualizó "Al final de este módulo..." a "Al final de este laboratorio...".
  - **Enlaces de navegación**: Se convirtieron todas las referencias "Módulo XX:" a "Laboratorio XX:" en referencias cruzadas y navegación.
  - **Seguimiento de finalización**: Se actualizó "Después de completar este módulo..." a "Después de completar este laboratorio...".
  - **Referencias técnicas preservadas**: Se mantuvieron las referencias a módulos de Python en archivos de configuración (por ejemplo, `"module": "mcp_server.main"`).

#### Mejora de la guía de estudio (study_guide.md)
- **Mapa visual del currículo**: Se agregó una nueva sección "11. Laboratorios de integración de bases de datos" con una visualización completa de la estructura de los laboratorios.
- **Estructura del repositorio**: Actualizado de diez a once secciones principales con una descripción detallada de 11-MCPServerHandsOnLabs.
- **Guía de ruta de aprendizaje**: Instrucciones de navegación mejoradas para cubrir las secciones 00-11.
- **Cobertura tecnológica**: Detalles de integración de FastMCP, PostgreSQL y servicios de Azure.
- **Resultados de aprendizaje**: Énfasis en el desarrollo de servidores listos para producción, patrones de integración de bases de datos y seguridad empresarial.

#### Mejora de la estructura del README principal
- **Terminología basada en laboratorios**: Se actualizó el README.md principal en 11-MCPServerHandsOnLabs para usar consistentemente la estructura de "Laboratorio".
- **Organización de la ruta de aprendizaje**: Progresión clara desde conceptos fundamentales hasta implementación avanzada y despliegue en producción.
- **Enfoque en el mundo real**: Énfasis en el aprendizaje práctico con patrones y tecnologías de nivel empresarial.

### Mejoras en la calidad y consistencia de la documentación
- **Énfasis en el aprendizaje práctico**: Se reforzó el enfoque práctico basado en laboratorios en toda la documentación.
- **Enfoque en patrones empresariales**: Se destacaron implementaciones listas para producción y consideraciones de seguridad empresarial.
- **Integración tecnológica**: Cobertura completa de servicios modernos de Azure y patrones de integración de IA.
- **Progresión de aprendizaje**: Ruta clara y estructurada desde conceptos básicos hasta despliegue en producción.

## 26 de septiembre de 2025

### Mejora de estudios de caso - Integración del registro MCP de GitHub

#### Estudios de caso (09-CaseStudy/) - Enfoque en desarrollo del ecosistema
- **README.md**: Expansión importante con un estudio de caso completo sobre el registro MCP de GitHub.
  - **Estudio de caso del registro MCP de GitHub**: Nuevo estudio de caso completo que examina el lanzamiento del registro MCP de GitHub en septiembre de 2025.
    - **Análisis del problema**: Examen detallado de los desafíos de descubrimiento y despliegue fragmentado de servidores MCP.
    - **Arquitectura de la solución**: Enfoque de registro centralizado de GitHub con instalación de VS Code con un solo clic.
    - **Impacto empresarial**: Mejoras medibles en la incorporación de desarrolladores y productividad.
    - **Valor estratégico**: Enfoque en el despliegue modular de agentes y la interoperabilidad entre herramientas.
    - **Desarrollo del ecosistema**: Posicionamiento como plataforma fundamental para la integración de agentes.
  - **Estructura mejorada de estudios de caso**: Se actualizaron los siete estudios de caso con formato consistente y descripciones completas.
    - Agentes de viaje de Azure AI: Énfasis en la orquestación multi-agente.
    - Integración con Azure DevOps: Enfoque en automatización de flujos de trabajo.
    - Recuperación de documentación en tiempo real: Implementación de cliente de consola Python.
    - Generador interactivo de planes de estudio: Aplicación web conversacional Chainlit.
    - Documentación en el editor: Integración con VS Code y GitHub Copilot.
    - Gestión de API de Azure: Patrones de integración de API empresariales.
    - Registro MCP de GitHub: Desarrollo del ecosistema y plataforma comunitaria.
  - **Conclusión completa**: Se reescribió la sección de conclusión destacando siete estudios de caso que abarcan múltiples dimensiones de implementación MCP.
    - Integración empresarial, orquestación multi-agente, productividad del desarrollador.
    - Desarrollo del ecosistema, aplicaciones educativas categorizadas.
    - Perspectivas mejoradas sobre patrones arquitectónicos, estrategias de implementación y mejores prácticas.
    - Énfasis en MCP como protocolo maduro y listo para producción.

#### Actualizaciones de la guía de estudio (study_guide.md)
- **Mapa visual del currículo**: Se actualizó el mapa mental para incluir el registro MCP de GitHub en la sección de estudios de caso.
- **Descripción de estudios de caso**: Mejorada de descripciones genéricas a desglose detallado de siete estudios de caso completos.
- **Estructura del repositorio**: Se actualizó la sección 10 para reflejar la cobertura completa de estudios de caso con detalles específicos de implementación.
- **Integración del registro de cambios**: Se agregó la entrada del 26 de septiembre de 2025 documentando la adición del registro MCP de GitHub y las mejoras en los estudios de caso.
- **Actualización de fechas**: Se actualizó la marca de tiempo del pie de página para reflejar la última revisión (26 de septiembre de 2025).

### Mejoras en la calidad de la documentación
- **Mejora de consistencia**: Se estandarizó el formato y la estructura de los estudios de caso en los siete ejemplos.
- **Cobertura completa**: Los estudios de caso ahora abarcan escenarios empresariales, de productividad del desarrollador y desarrollo del ecosistema.
- **Posicionamiento estratégico**: Enfoque mejorado en MCP como plataforma fundamental para el despliegue de sistemas de agentes.
- **Integración de recursos**: Se actualizaron los recursos adicionales para incluir el enlace al registro MCP de GitHub.

## 15 de septiembre de 2025

### Expansión de temas avanzados - Transportes personalizados e ingeniería de contexto

#### Transportes personalizados de MCP (05-AdvancedTopics/mcp-transport/) - Nueva guía de implementación avanzada
- **README.md**: Guía completa de implementación para mecanismos de transporte personalizados de MCP.
  - **Transporte Azure Event Grid**: Implementación completa de transporte sin servidor basado en eventos.
    - Ejemplos en C#, TypeScript y Python con integración de Azure Functions.
    - Patrones de arquitectura basada en eventos para soluciones MCP escalables.
    - Receptores de webhook y manejo de mensajes basado en push.
  - **Transporte Azure Event Hubs**: Implementación de transporte de transmisión de alta capacidad.
    - Capacidades de transmisión en tiempo real para escenarios de baja latencia.
    - Estrategias de particionamiento y gestión de puntos de control.
    - Agrupación de mensajes y optimización de rendimiento.
  - **Patrones de integración empresarial**: Ejemplos arquitectónicos listos para producción.
    - Procesamiento MCP distribuido en múltiples Azure Functions.
    - Arquitecturas híbridas de transporte que combinan múltiples tipos de transporte.
    - Estrategias de durabilidad, confiabilidad y manejo de errores de mensajes.
  - **Seguridad y monitoreo**: Integración con Azure Key Vault y patrones de observabilidad.
    - Autenticación de identidad administrada y acceso con privilegios mínimos.
    - Telemetría de Application Insights y monitoreo de rendimiento.
    - Cortafuegos y patrones de tolerancia a fallos.
  - **Marcos de prueba**: Estrategias completas de prueba para transportes personalizados.
    - Pruebas unitarias con dobles de prueba y marcos de simulación.
    - Pruebas de integración con contenedores de prueba de Azure.
    - Consideraciones de pruebas de rendimiento y carga.

#### Ingeniería de contexto (05-AdvancedTopics/mcp-contextengineering/) - Disciplina emergente de IA
- **README.md**: Exploración completa de la ingeniería de contexto como campo emergente.
  - **Principios básicos**: Compartición completa de contexto, conciencia de decisiones de acción y gestión de ventanas de contexto.
  - **Alineación con el protocolo MCP**: Cómo el diseño MCP aborda los desafíos de ingeniería de contexto.
    - Limitaciones de ventanas de contexto y estrategias de carga progresiva.
    - Determinación de relevancia y recuperación dinámica de contexto.
    - Manejo de contexto multimodal y consideraciones de seguridad.
  - **Enfoques de implementación**: Arquitecturas de un solo hilo frente a multi-agente.
    - Técnicas de fragmentación y priorización de contexto.
    - Carga progresiva de contexto y estrategias de compresión.
    - Enfoques de contexto en capas y optimización de recuperación.
  - **Marco de medición**: Métricas emergentes para evaluar la efectividad del contexto.
    - Eficiencia de entrada, rendimiento, calidad y consideraciones de experiencia del usuario.
    - Enfoques experimentales para la optimización del contexto.
    - Análisis de fallos y metodologías de mejora.

#### Actualizaciones de navegación del currículo (README.md)
- **Estructura mejorada de módulos**: Se actualizó la tabla del currículo para incluir nuevos temas avanzados.
  - Se agregaron las entradas de Ingeniería de Contexto (5.14) y Transporte Personalizado (5.15).
  - Formato consistente y enlaces de navegación en todos los módulos.
  - Descripciones actualizadas para reflejar el alcance actual del contenido.

### Mejoras en la estructura del directorio
- **Estandarización de nombres**: Se renombró "mcp transport" a "mcp-transport" para mantener la consistencia con otras carpetas de temas avanzados.
- **Organización del contenido**: Todas las carpetas de 05-AdvancedTopics ahora siguen un patrón de nombres consistente (mcp-[tema]).

### Mejoras en la calidad de la documentación
- **Alineación con la especificación MCP**: Todo el contenido nuevo hace referencia a la especificación MCP actual 2025-06-18.
- **Ejemplos en múltiples lenguajes**: Ejemplos de código completos en C#, TypeScript y Python.
- **Enfoque empresarial**: Patrones listos para producción e integración en la nube de Azure en todo el contenido.
- **Documentación visual**: Diagramas Mermaid para visualización de arquitectura y flujo.

## 18 de agosto de 2025

### Actualización completa de documentación - Estándares MCP 2025-06-18

#### Mejores prácticas de seguridad MCP (02-Security/) - Modernización completa
- **MCP-SECURITY-BEST-PRACTICES-2025.md**: Reescritura completa alineada con la especificación MCP 2025-06-18.
  - **Requisitos obligatorios**: Se agregaron requisitos explícitos MUST/MUST NOT de la especificación oficial con indicadores visuales claros.
  - **12 prácticas de seguridad principales**: Reestructuradas de una lista de 15 elementos a dominios de seguridad completos.
    - Seguridad de tokens y autenticación con integración de proveedores de identidad externos.
    - Gestión de sesiones y seguridad de transporte con requisitos criptográficos.
    - Protección contra amenazas específicas de IA con integración de Microsoft Prompt Shields.
    - Control de acceso y permisos con el principio de privilegio mínimo.
    - Seguridad de contenido y monitoreo con integración de Azure Content Safety.
    - Seguridad de la cadena de suministro con verificación completa de componentes.
    - Seguridad OAuth y prevención de ataques Confused Deputy con implementación PKCE.
    - Respuesta a incidentes y recuperación con capacidades automatizadas.
    - Cumplimiento y gobernanza con alineación regulatoria.
    - Controles de seguridad avanzados con arquitectura de confianza cero.
    - Integración con el ecosistema de seguridad de Microsoft con soluciones completas.
    - Evolución continua de la seguridad con prácticas adaptativas.
  - **Soluciones de seguridad de Microsoft**: Guía de integración mejorada para Prompt Shields, Azure Content Safety, Entra ID y GitHub Advanced Security.
  - **Recursos de implementación**: Enlaces de recursos completos categorizados por documentación oficial MCP, soluciones de seguridad de Microsoft, estándares de seguridad y guías de implementación.

#### Controles de seguridad avanzados (02-Security/) - Implementación empresarial
- **MCP-SECURITY-CONTROLS-2025.md**: Revisión completa con marco de seguridad de nivel empresarial.
  - **9 dominios de seguridad completos**: Expandidos de controles básicos a un marco empresarial detallado.
    - Autenticación y autorización avanzadas con integración de Microsoft Entra ID.
    - Seguridad de tokens y controles anti-passthrough con validación completa.
    - Controles de seguridad de sesiones con prevención de secuestro.
    - Controles de seguridad específicos de IA con prevención de inyección de prompts y envenenamiento de herramientas.
    - Prevención de ataques Confused Deputy con seguridad proxy OAuth.
    - Seguridad en la ejecución de herramientas con sandboxing y aislamiento.
    - Controles de seguridad de la cadena de suministro con verificación de dependencias.
    - Controles de monitoreo y detección con integración SIEM.
    - Respuesta a incidentes y recuperación con capacidades automatizadas.
  - **Ejemplos de implementación**: Se agregaron bloques de configuración YAML detallados y ejemplos de código.
  - **Integración de soluciones de Microsoft**: Cobertura completa de servicios de seguridad de Azure, GitHub Advanced Security y gestión de identidad empresarial.

#### Seguridad en temas avanzados (05-AdvancedTopics/mcp-security/) - Implementación lista para producción
- **README.md**: Reescritura completa para implementación de seguridad empresarial.
  - **Alineación con la especificación actual**: Actualizado a la especificación MCP 2025-06-18 con requisitos de seguridad obligatorios.
  - **Autenticación mejorada**: Integración de Microsoft Entra ID con ejemplos completos en .NET y Java Spring Security.
  - **Integración de seguridad IA**: Implementación de Microsoft Prompt Shields y Azure Content Safety con ejemplos detallados en Python.
  - **Mitigación avanzada de amenazas**: Ejemplos completos de implementación para:
    - Prevención de ataques Confused Deputy con PKCE y validación de consentimiento del usuario.
    - Prevención de passthrough de tokens con validación de audiencia y gestión segura de tokens.
    - Prevención de secuestro de sesiones con vinculación criptográfica y análisis de comportamiento.
  - **Integración de seguridad empresarial**: Monitoreo con Azure Application Insights, pipelines de detección de amenazas y seguridad de la cadena de suministro.
  - **Lista de verificación de implementación**: Controles de seguridad obligatorios frente a recomendados con beneficios del ecosistema de seguridad de Microsoft.

### Calidad de la documentación y alineación con estándares
- **Referencias a la especificación**: Se actualizaron todas las referencias a la especificación MCP actual 2025-06-18.
- **Ecosistema de seguridad de Microsoft**: Guía de integración mejorada en toda la documentación de seguridad.
- **Implementación práctica**: Se agregaron ejemplos de código detallados en .NET, Java y Python con patrones empresariales.
- **Organización de recursos**: Categorización completa de documentación oficial, estándares de seguridad y guías de implementación.
- **Indicadores Visuales**: Marcado claro de requisitos obligatorios frente a prácticas recomendadas

#### Conceptos Básicos (01-CoreConcepts/) - Modernización Completa
- **Actualización de Versión del Protocolo**: Actualizado para referenciar la Especificación MCP actual 2025-06-18 con versionado basado en fechas (formato YYYY-MM-DD)
- **Refinamiento de Arquitectura**: Descripciones mejoradas de Hosts, Clientes y Servidores para reflejar los patrones actuales de arquitectura MCP
  - Hosts ahora definidos claramente como aplicaciones de IA que coordinan múltiples conexiones de clientes MCP
  - Clientes descritos como conectores de protocolo que mantienen relaciones uno a uno con servidores
  - Servidores mejorados con escenarios de implementación local frente a remota
- **Reestructuración de Primitivas**: Revisión completa de primitivas de servidor y cliente
  - Primitivas de Servidor: Recursos (fuentes de datos), Prompts (plantillas), Herramientas (funciones ejecutables) con explicaciones detalladas y ejemplos
  - Primitivas de Cliente: Muestreo (completaciones de LLM), Elicitación (entrada del usuario), Registro (depuración/monitoreo)
  - Actualizado con patrones actuales de descubrimiento (`*/list`), recuperación (`*/get`) y ejecución (`*/call`)
- **Arquitectura del Protocolo**: Introducción de un modelo de arquitectura de dos capas
  - Capa de Datos: Fundamento JSON-RPC 2.0 con gestión del ciclo de vida y primitivas
  - Capa de Transporte: Mecanismos de transporte STDIO (local) y HTTP con SSE (remoto)
- **Marco de Seguridad**: Principios de seguridad integrales que incluyen consentimiento explícito del usuario, protección de privacidad de datos, seguridad en la ejecución de herramientas y seguridad en la capa de transporte
- **Patrones de Comunicación**: Mensajes del protocolo actualizados para mostrar flujos de inicialización, descubrimiento, ejecución y notificación
- **Ejemplos de Código**: Ejemplos multilingües actualizados (.NET, Java, Python, JavaScript) para reflejar los patrones actuales del SDK MCP

#### Seguridad (02-Security/) - Revisión Integral de Seguridad  
- **Alineación con Estándares**: Alineación completa con los requisitos de seguridad de la Especificación MCP 2025-06-18
- **Evolución de Autenticación**: Documentación de la evolución de servidores OAuth personalizados a delegación de proveedores de identidad externos (Microsoft Entra ID)
- **Análisis de Amenazas Específicas de IA**: Cobertura mejorada de vectores de ataque modernos en IA
  - Escenarios detallados de ataques de inyección de prompts con ejemplos reales
  - Mecanismos de envenenamiento de herramientas y patrones de ataque "rug pull"
  - Envenenamiento de ventanas de contexto y ataques de confusión de modelos
- **Soluciones de Seguridad de Microsoft para IA**: Cobertura integral del ecosistema de seguridad de Microsoft
  - Escudos de Prompt de IA con técnicas avanzadas de detección, resaltado y delimitación
  - Patrones de integración de Azure Content Safety
  - Seguridad Avanzada de GitHub para protección de la cadena de suministro
- **Mitigación Avanzada de Amenazas**: Controles de seguridad detallados para
  - Secuestro de sesiones con escenarios de ataque específicos de MCP y requisitos criptográficos de ID de sesión
  - Problemas de "confused deputy" en escenarios de proxy MCP con requisitos de consentimiento explícito
  - Vulnerabilidades de paso de tokens con controles de validación obligatorios
- **Seguridad de la Cadena de Suministro**: Cobertura ampliada de la cadena de suministro de IA, incluyendo modelos base, servicios de embeddings, proveedores de contexto y APIs de terceros
- **Seguridad Fundamental**: Integración mejorada con patrones de seguridad empresarial, incluyendo arquitectura de confianza cero y el ecosistema de seguridad de Microsoft
- **Organización de Recursos**: Enlaces de recursos categorizados de manera integral por tipo (Documentos Oficiales, Estándares, Investigación, Soluciones de Microsoft, Guías de Implementación)

### Mejoras en la Calidad de la Documentación
- **Objetivos de Aprendizaje Estructurados**: Objetivos de aprendizaje mejorados con resultados específicos y accionables
- **Referencias Cruzadas**: Enlaces añadidos entre temas relacionados de seguridad y conceptos básicos
- **Información Actualizada**: Todas las referencias de fechas y enlaces de especificaciones actualizados a estándares actuales
- **Guía de Implementación**: Directrices de implementación específicas y accionables añadidas en ambas secciones

## 16 de julio de 2025

### Mejoras en README y Navegación
- Rediseño completo de la navegación del currículo en README.md
- Sustitución de etiquetas `<details>` por un formato basado en tablas más accesible
- Creación de opciones de diseño alternativas en la nueva carpeta "alternative_layouts"
- Ejemplos de navegación añadidos con estilo de tarjetas, pestañas y acordeón
- Sección de estructura del repositorio actualizada para incluir todos los archivos más recientes
- Mejora de la sección "Cómo usar este currículo" con recomendaciones claras
- Enlaces de especificación MCP actualizados para apuntar a las URLs correctas
- Sección de Ingeniería de Contexto (5.14) añadida a la estructura del currículo

### Actualizaciones de la Guía de Estudio
- Revisión completa de la guía de estudio para alinearla con la estructura actual del repositorio
- Nuevas secciones añadidas para Clientes MCP y Herramientas, y Servidores MCP populares
- Mapa visual del currículo actualizado para reflejar con precisión todos los temas
- Descripciones mejoradas de Temas Avanzados para cubrir todas las áreas especializadas
- Sección de Estudios de Caso actualizada para reflejar ejemplos reales
- Añadido este registro de cambios integral

### Contribuciones de la Comunidad (06-CommunityContributions/)
- Información detallada añadida sobre servidores MCP para generación de imágenes
- Sección completa añadida sobre el uso de Claude en VSCode
- Instrucciones de configuración y uso del cliente terminal Cline añadidas
- Sección de clientes MCP actualizada para incluir todas las opciones populares de clientes
- Ejemplos de contribución mejorados con muestras de código más precisas

### Temas Avanzados (05-AdvancedTopics/)
- Organización de todas las carpetas de temas especializados con nombres consistentes
- Materiales y ejemplos de ingeniería de contexto añadidos
- Documentación de integración de agentes Foundry añadida
- Documentación mejorada de integración de seguridad Entra ID

## 11 de junio de 2025

### Creación Inicial
- Primera versión del currículo MCP para principiantes lanzada
- Estructura básica creada para las 10 secciones principales
- Implementación del Mapa Visual del Currículo para navegación
- Proyectos de muestra iniciales añadidos en múltiples lenguajes de programación

### Primeros Pasos (03-GettingStarted/)
- Ejemplos de implementación de servidor creados
- Guía de desarrollo de clientes añadida
- Instrucciones de integración de clientes LLM incluidas
- Documentación de integración con VS Code añadida
- Ejemplos de servidor con eventos enviados por el servidor (SSE) implementados

### Conceptos Básicos (01-CoreConcepts/)
- Explicación detallada de la arquitectura cliente-servidor añadida
- Documentación creada sobre componentes clave del protocolo
- Patrones de mensajería en MCP documentados

## 23 de mayo de 2025

### Estructura del Repositorio
- Repositorio inicializado con estructura básica de carpetas
- Archivos README creados para cada sección principal
- Infraestructura de traducción configurada
- Activos de imagen y diagramas añadidos

### Documentación
- README.md inicial creado con visión general del currículo
- CODE_OF_CONDUCT.md y SECURITY.md añadidos
- SUPPORT.md configurado con orientación para obtener ayuda
- Estructura preliminar de la guía de estudio creada

## 15 de abril de 2025

### Planificación y Marco
- Planificación inicial para el currículo MCP para principiantes
- Objetivos de aprendizaje y audiencia objetivo definidos
- Estructura de 10 secciones del currículo delineada
- Marco conceptual desarrollado para ejemplos y estudios de caso
- Prototipos iniciales creados para conceptos clave

---

**Descargo de responsabilidad**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por garantizar la precisión, tenga en cuenta que las traducciones automatizadas pueden contener errores o imprecisiones. El documento original en su idioma nativo debe considerarse como la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas que puedan surgir del uso de esta traducción.