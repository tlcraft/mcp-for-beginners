<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-02T08:49:32+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "es"
}
-->
# Temas Avanzados en MCP

Este capítulo está diseñado para cubrir una serie de temas avanzados en la implementación del Model Context Protocol (MCP), incluyendo integración multimodal, escalabilidad, mejores prácticas de seguridad e integración empresarial. Estos temas son cruciales para construir aplicaciones MCP robustas y listas para producción que puedan satisfacer las demandas de los sistemas de IA modernos.

## Resumen

Esta lección explora conceptos avanzados en la implementación del Model Context Protocol, enfocándose en la integración multimodal, escalabilidad, mejores prácticas de seguridad e integración empresarial. Estos temas son esenciales para desarrollar aplicaciones MCP de nivel productivo que puedan manejar requisitos complejos en entornos empresariales.

## Objetivos de Aprendizaje

Al finalizar esta lección, podrás:

- Implementar capacidades multimodales dentro de los frameworks MCP
- Diseñar arquitecturas MCP escalables para escenarios de alta demanda
- Aplicar mejores prácticas de seguridad alineadas con los principios de seguridad de MCP
- Integrar MCP con sistemas y frameworks de IA empresariales
- Optimizar el rendimiento y la confiabilidad en entornos de producción

## Lecciones y Proyectos de Ejemplo

| Enlace | Título | Descripción |
|--------|--------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integración con Azure | Aprende cómo integrar tu MCP Server en Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Ejemplos multimodales MCP | Ejemplos para respuestas de audio, imagen y multimodales |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Aplicación mínima con Spring Boot que muestra OAuth2 con MCP, tanto como Servidor de Autorización como de Recursos. Demuestra emisión segura de tokens, endpoints protegidos, despliegue en Azure Container Apps e integración con API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contextos raíz | Aprende más sobre los contextos raíz y cómo implementarlos |
| [5.5 Routing](./mcp-routing/README.md) | Enrutamiento | Aprende diferentes tipos de enrutamiento |
| [5.6 Sampling](./mcp-sampling/README.md) | Muestreo | Aprende cómo trabajar con muestreo |
| [5.7 Scaling](./mcp-scaling/README.md) | Escalabilidad | Aprende sobre escalabilidad |
| [5.8 Security](./mcp-security/README.md) | Seguridad | Asegura tu MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Búsqueda Web MCP | Servidor y cliente MCP en Python integrando SerpAPI para búsqueda web, noticias, productos y preguntas en tiempo real. Demuestra orquestación de múltiples herramientas, integración con APIs externas y manejo robusto de errores. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | La transmisión de datos en tiempo real se ha vuelto esencial en el mundo actual impulsado por datos, donde empresas y aplicaciones requieren acceso inmediato a la información para tomar decisiones oportunas. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Búsqueda Web | Búsqueda web en tiempo real: cómo MCP transforma la búsqueda web en tiempo real proporcionando un enfoque estandarizado para la gestión del contexto entre modelos de IA, motores de búsqueda y aplicaciones. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Autenticación Entra ID | Microsoft Entra ID ofrece una solución robusta en la nube para la gestión de identidad y acceso, ayudando a garantizar que solo usuarios y aplicaciones autorizados puedan interactuar con tu servidor MCP. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integración Azure AI Foundry | Aprende cómo integrar servidores Model Context Protocol con agentes Azure AI Foundry, habilitando una potente orquestación de herramientas y capacidades de IA empresarial con conexiones estandarizadas a fuentes de datos externas. |

## Referencias Adicionales

Para obtener la información más actualizada sobre temas avanzados de MCP, consulta:
- [Documentación MCP](https://modelcontextprotocol.io/)
- [Especificación MCP](https://spec.modelcontextprotocol.io/)
- [Repositorio GitHub](https://github.com/modelcontextprotocol)

## Puntos Clave

- Las implementaciones multimodales de MCP amplían las capacidades de IA más allá del procesamiento de texto
- La escalabilidad es esencial para despliegues empresariales y puede abordarse mediante escalado horizontal y vertical
- Medidas de seguridad integrales protegen los datos y aseguran un control de acceso adecuado
- La integración empresarial con plataformas como Azure OpenAI y Microsoft AI Foundry potencia las capacidades de MCP
- Las implementaciones avanzadas de MCP se benefician de arquitecturas optimizadas y una gestión cuidadosa de recursos

## Ejercicio

Diseña una implementación MCP de nivel empresarial para un caso de uso específico:

1. Identifica los requisitos multimodales para tu caso de uso
2. Define los controles de seguridad necesarios para proteger datos sensibles
3. Diseña una arquitectura escalable que pueda manejar cargas variables
4. Planifica los puntos de integración con sistemas de IA empresariales
5. Documenta posibles cuellos de botella en el rendimiento y estrategias de mitigación

## Recursos Adicionales

- [Documentación Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Documentación Microsoft AI Foundry](https://learn.microsoft.com/en-us/ai-services/)

---

## Qué sigue

- [5.1 MCP Integration](./mcp-integration/README.md)

**Aviso Legal**:  
Este documento ha sido traducido utilizando el servicio de traducción automática [Co-op Translator](https://github.com/Azure/co-op-translator). Aunque nos esforzamos por la precisión, tenga en cuenta que las traducciones automáticas pueden contener errores o inexactitudes. El documento original en su idioma nativo debe considerarse la fuente autorizada. Para información crítica, se recomienda una traducción profesional realizada por humanos. No nos responsabilizamos por malentendidos o interpretaciones erróneas derivadas del uso de esta traducción.