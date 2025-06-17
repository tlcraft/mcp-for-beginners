<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:08:33+00:00",
  "source_file": "README.md",
  "language_code": "es"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.es.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Sigue estos pasos para comenzar a usar estos recursos:
1. **Haz un fork del repositorio**: Haz clic en [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clona el repositorio**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Únete al Discord de Azure AI Foundry y conoce a expertos y otros desarrolladores**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Soporte Multilingüe

#### Soportado mediante GitHub Action (Automatizado y Siempre Actualizado)

# 🚀 Currículo del Protocolo de Contexto de Modelo (MCP) para Principiantes

## **Aprende MCP con ejemplos prácticos en C#, Java, JavaScript, Python y TypeScript**

## 🧠 Visión general del currículo del Protocolo de Contexto de Modelo

El **Protocolo de Contexto de Modelo (MCP)** es un marco innovador diseñado para estandarizar las interacciones entre modelos de IA y aplicaciones cliente. Este currículo de código abierto ofrece una ruta de aprendizaje estructurada, con ejemplos prácticos de código y casos de uso reales, en lenguajes de programación populares como C#, Java, JavaScript, TypeScript y Python.

Ya seas desarrollador de IA, arquitecto de sistemas o ingeniero de software, esta guía es tu recurso integral para dominar los fundamentos y las estrategias de implementación de MCP.

## 🔗 Recursos oficiales de MCP

- 📘 [Documentación MCP](https://modelcontextprotocol.io/) – Tutoriales detallados y guías de usuario  
- 📜 [Especificación MCP](https://spec.modelcontextprotocol.io/) – Arquitectura del protocolo y referencias técnicas  
- 🧑‍💻 [Repositorio GitHub MCP](https://github.com/modelcontextprotocol) – SDKs, herramientas y ejemplos de código de código abierto  

## 🧭 Estructura completa del currículo MCP

| Cap | Título | Descripción | Enlace |
|--|--|--|--|
| 00 | **Introducción a MCP** | Visión general del Protocolo de Contexto de Modelo y su importancia en pipelines de IA, incluyendo qué es el Protocolo de Contexto de Modelo, por qué la estandarización es importante, casos prácticos y beneficios | [Introducción](./00-Introduction/README.md) |
| 01 | **Conceptos fundamentales explicados** | Exploración profunda de los conceptos clave de MCP, incluyendo arquitectura cliente-servidor, componentes principales del protocolo y patrones de mensajería | [Conceptos fundamentales](./01-CoreConcepts/README.md) |
| 02 | **Seguridad en MCP** | Identificación de amenazas de seguridad en sistemas basados en MCP, técnicas y mejores prácticas para asegurar las implementaciones | [Seguridad](./02-Security/README.md) |
| 03 | **Primeros pasos con MCP** | Configuración del entorno, creación de servidores y clientes MCP básicos, integración de MCP con aplicaciones existentes | [Primeros pasos](./03-GettingStarted/README.md) |
| 3.1 | **Primer servidor** | Configuración de un servidor básico usando el protocolo MCP, comprensión de la interacción servidor-cliente y pruebas del servidor | [Primer servidor](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Primer cliente** | Configuración de un cliente básico usando el protocolo MCP, comprensión de la interacción cliente-servidor y pruebas del cliente | [Primer cliente](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Cliente con LLM** | Configuración de un cliente usando el protocolo MCP con un Modelo de Lenguaje Grande (LLM) | [Cliente con LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Consumir un servidor con Visual Studio Code** | Configuración de Visual Studio Code para consumir servidores usando el protocolo MCP | [Consumir un servidor con Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Crear un servidor usando SSE** | SSE nos ayuda a exponer un servidor a internet. Esta sección te ayudará a crear un servidor usando SSE | [Crear un servidor usando SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Streaming HTTP** | Aprende a implementar streaming HTTP para transferencia de datos en tiempo real entre clientes y servidores MCP | [Streaming HTTP](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Uso de AI Toolkit** | AI Toolkit es una gran herramienta que te ayudará a gestionar tu flujo de trabajo de IA y MCP. | [Uso de AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Pruebas de tu servidor** | Las pruebas son una parte importante del proceso de desarrollo. Esta sección te ayudará a probar usando varias herramientas diferentes. | [Pruebas de tu servidor](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Despliega tu servidor** | ¿Cómo pasar del desarrollo local a producción? Esta sección te ayudará a desarrollar y desplegar tu servidor. | [Despliega tu servidor](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Implementación práctica** | Uso de SDKs en diferentes lenguajes, depuración, pruebas y validación, creación de plantillas reutilizables de prompts y flujos de trabajo | [Implementación práctica](./04-PracticalImplementation/README.md) |
| 05 | **Temas avanzados en MCP** | Flujos de trabajo multimodales de IA y extensibilidad, estrategias seguras de escalado, MCP en ecosistemas empresariales | [Temas avanzados](./05-AdvancedTopics/README.md) |
| 5.1 | **Integración MCP con Azure** | Muestra la integración con Azure | [Integración MCP Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalidad** | Muestra cómo trabajar con diferentes modalidades como imágenes y más | [Multimodalidad](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demo MCP OAuth2** | Aplicación mínima con Spring Boot mostrando OAuth2 con MCP, tanto como Servidor de Autorización como de Recursos. Demuestra emisión segura de tokens, endpoints protegidos, despliegue en Azure Container Apps e integración con API Management. | [Demo MCP OAuth2](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Contextos raíz** | Aprende más sobre contextos raíz y cómo implementarlos | [Contextos raíz](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Enrutamiento** | Aprende diferentes tipos de enrutamiento | [Enrutamiento](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Muestreo** | Aprende cómo trabajar con muestreo | [Muestreo](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Escalado** | Aprende sobre el escalado de servidores MCP, incluyendo estrategias de escalado horizontal y vertical, optimización de recursos y ajuste de rendimiento | [Escalado](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Seguridad** | Asegura tu servidor MCP, incluyendo estrategias de autenticación, autorización y protección de datos | [Seguridad](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Búsqueda web MCP** | Servidor y cliente MCP en Python integrando SerpAPI para búsqueda web, noticias, productos y preguntas en tiempo real. Demuestra orquestación multi-herramienta, integración con API externas y manejo robusto de errores | [Búsqueda web MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Streaming en tiempo real** | El streaming de datos en tiempo real se ha vuelto esencial en el mundo actual orientado a los datos, donde empresas y aplicaciones requieren acceso inmediato a la información para tomar decisiones oportunas. | [Streaming en tiempo real](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Búsqueda web en tiempo real** | Cómo MCP transforma la búsqueda web en tiempo real proporcionando un enfoque estandarizado para la gestión del contexto entre modelos de IA, motores de búsqueda y aplicaciones. | [Búsqueda web en tiempo real](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Contribuciones de la comunidad** | Cómo contribuir con código y documentación, colaboración vía GitHub, mejoras impulsadas por la comunidad y retroalimentación | [Contribuciones de la comunidad](./06-CommunityContributions/README.md) |
| 07 | **Perspectivas de la Adopción Temprana** | Implementaciones reales y qué funcionó, creación y despliegue de soluciones basadas en MCP, tendencias y hoja de ruta futura | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Mejores Prácticas para MCP** | Ajuste y optimización del rendimiento, diseño de sistemas MCP tolerantes a fallos, estrategias de pruebas y resiliencia | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Estudios de Caso de MCP** | Análisis profundos de arquitecturas de soluciones MCP, planos de despliegue y consejos de integración, diagramas anotados y recorridos de proyectos | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Optimización de Flujos de Trabajo de IA: Construyendo un Servidor MCP con AI Toolkit** | Taller práctico completo que combina MCP con AI Toolkit de Microsoft para VS Code. Aprende a crear aplicaciones inteligentes que conectan modelos de IA con herramientas reales mediante módulos prácticos que cubren fundamentos, desarrollo de servidores personalizados y estrategias de despliegue en producción. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Proyectos de Ejemplo

### 🧮 Proyectos de Calculadora MCP de Ejemplo:
<details>
  <summary><strong>Explora implementaciones de código por lenguaje</strong></summary>

  - [Ejemplo de Servidor MCP en C#](./03-GettingStarted/samples/csharp/README.md)
  - [Calculadora MCP en Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demo MCP en JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Servidor MCP en Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Ejemplo MCP en TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Proyectos Avanzados de Calculadora MCP:
<details>
  <summary><strong>Explora ejemplos avanzados</strong></summary>

  - [Ejemplo Avanzado en C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Ejemplo de Aplicación Contenedor en Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Ejemplo Avanzado en JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Implementación Compleja en Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Ejemplo de Contenedor en TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Requisitos Previos para Aprender MCP

Para aprovechar al máximo este currículo, deberías tener:

- Conocimientos básicos de C#, Java o Python  
- Comprensión del modelo cliente-servidor y APIs  
- (Opcional) Familiaridad con conceptos de aprendizaje automático  

## 📚 Guía de Estudio

Hay disponible una [Guía de Estudio](./study_guide.md) completa para ayudarte a navegar este repositorio de manera efectiva. La guía incluye:

- Un mapa visual del currículo con todos los temas cubiertos  
- Desglose detallado de cada sección del repositorio  
- Orientación sobre cómo usar los proyectos de ejemplo  
- Rutas de aprendizaje recomendadas para distintos niveles  
- Recursos adicionales para complementar tu aprendizaje  

## 🛠️ Cómo Usar Este Currículo de Forma Efectiva

Cada lección en esta guía incluye:

1. Explicaciones claras de los conceptos MCP  
2. Ejemplos de código en vivo en varios lenguajes  
3. Ejercicios para construir aplicaciones MCP reales  
4. Recursos extra para quienes buscan profundizar  

## 📜 Información de Licencia

Este contenido está licenciado bajo la **Licencia MIT**. Para términos y condiciones, consulta el [LICENSE](../../LICENSE).

## 🤝 Guía para Contribuciones

Este proyecto acepta contribuciones y sugerencias. La mayoría de las contribuciones requieren que aceptes un
Acuerdo de Licencia de Contribuyente (CLA) declarando que tienes el derecho y efectivamente otorgas
los derechos para usar tu contribución. Para más detalles, visita <https://cla.opensource.microsoft.com>.

Cuando envíes un pull request, un bot de CLA determinará automáticamente si necesitas proporcionar
un CLA y decorará el PR apropiadamente (por ejemplo, chequeo de estado, comentario). Solo sigue las instrucciones
del bot. Solo tendrás que hacerlo una vez en todos los repositorios que usan nuestro CLA.

Este proyecto ha adoptado el [Código de Conducta de Código Abierto de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para más información, consulta las [Preguntas frecuentes sobre el Código de Conducta](https://opensource.microsoft.com/codeofconduct/faq/) o
contacta a [opencode@microsoft.com](mailto:opencode@microsoft.com) para cualquier duda o comentario adicional.

## 🎒 Otros Cursos
¡Nuestro equipo produce otros cursos! Echa un vistazo a:

- [AI Agents For Beginners](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners using JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)
- [Generative AI for Beginners](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)
- [ML for Beginners](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)
- [Data Science for Beginners](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)
- [AI for Beginners](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)
- [Cybersecurity for Beginners](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)
- [Web Dev for Beginners](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)
- [IoT for Beginners](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)
- [XR Development for Beginners](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Dominando GitHub Copilot para Programación en Pareja con IA](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Dominando GitHub Copilot para Desarrolladores C#/.NET](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Elige Tu Propia Aventura con Copilot](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Aviso de Marca Registrada

Este proyecto puede contener marcas registradas o logotipos de proyectos, productos o servicios. El uso autorizado de marcas o logotipos de Microsoft está sujeto a y debe cumplir con las [Directrices de Marcas y Marca Comercial de Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).
El uso de marcas o logotipos de Microsoft en versiones modificadas de este proyecto no debe causar confusión ni implicar patrocinio por parte de Microsoft.
Cualquier uso de marcas o logotipos de terceros está sujeto a las políticas de dichos terceros.

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos hacemos responsables de malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.