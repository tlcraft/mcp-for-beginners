<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b1cffc51b82049ac3d5e88db0ff4a0a1",
  "translation_date": "2025-06-13T00:56:29+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "cs"
}
-->
# Temas avanzados en MCP

Este capítulo está diseñado para cubrir una serie de temas avanzados en la implementación del Model Context Protocol (MCP), incluyendo integración multimodal, escalabilidad, mejores prácticas de seguridad e integración empresarial. Estos temas son fundamentales para construir aplicaciones MCP robustas y listas para producción que puedan satisfacer las demandas de los sistemas de IA modernos.

## Resumen

Esta lección explora conceptos avanzados en la implementación del Model Context Protocol, enfocándose en la integración multimodal, escalabilidad, mejores prácticas de seguridad e integración empresarial. Estos temas son esenciales para construir aplicaciones MCP de nivel productivo que puedan manejar requisitos complejos en entornos empresariales.

## Objetivos de aprendizaje

Al finalizar esta lección, podrás:

- Implementar capacidades multimodales dentro de frameworks MCP
- Diseñar arquitecturas MCP escalables para escenarios de alta demanda
- Aplicar mejores prácticas de seguridad alineadas con los principios de seguridad de MCP
- Integrar MCP con sistemas y frameworks de IA empresariales
- Optimizar el rendimiento y la confiabilidad en entornos de producción

## Lecciones y proyectos de ejemplo

| Link | Título | Descripción |
|------|--------|-------------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integración con Azure | Aprende cómo integrar tu MCP Server en Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Ejemplos MCP multimodal | Ejemplos para respuestas de audio, imagen y multimodal |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demo MCP OAuth2 | Aplicación minimalista en Spring Boot que muestra OAuth2 con MCP, tanto como Authorization como Resource Server. Demuestra emisión segura de tokens, endpoints protegidos, despliegue en Azure Container Apps e integración con API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contextos raíz | Aprende más sobre contextos raíz y cómo implementarlos |
| [5.5 Routing](./mcp-routing/README.md) | Enrutamiento | Aprende los diferentes tipos de enrutamiento |
| [5.6 Sampling](./mcp-sampling/README.md) | Muestreo | Aprende a trabajar con muestreo |
| [5.7 Scaling](./mcp-scaling/README.md) | Escalabilidad | Aprende sobre escalabilidad |
| [5.8 Security](./mcp-security/README.md) | Seguridad | Asegura tu MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Búsqueda web MCP | Servidor y cliente MCP en Python integrando SerpAPI para búsquedas web, noticias, productos y preguntas en tiempo real. Demuestra orquestación multi-herramienta, integración con APIs externas y manejo robusto de errores. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | La transmisión de datos en tiempo real se ha vuelto esencial en el mundo actual impulsado por datos, donde negocios y aplicaciones requieren acceso inmediato a la información para tomar decisiones oportunas. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Búsqueda web | Cómo MCP transforma la búsqueda web en tiempo real proporcionando un enfoque estandarizado para la gestión de contexto entre modelos de IA, motores de búsqueda y aplicaciones. |

## Referencias adicionales

Para obtener la información más actualizada sobre temas avanzados de MCP, consulta:
- [MCP Documentation](https://modelcontextprotocol.io/)
- [MCP Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Repository](https://github.com/modelcontextprotocol)

## Puntos clave

- Las implementaciones multimodales de MCP amplían las capacidades de IA más allá del procesamiento de texto
- La escalabilidad es esencial para despliegues empresariales y puede abordarse mediante escalado horizontal y vertical
- Las medidas de seguridad integrales protegen los datos y garantizan un control de acceso adecuado
- La integración empresarial con plataformas como Azure OpenAI y Microsoft AI Foundry potencia las capacidades de MCP
- Las implementaciones avanzadas de MCP se benefician de arquitecturas optimizadas y una gestión cuidadosa de recursos

## Ejercicio

Diseña una implementación MCP de nivel empresarial para un caso de uso específico:

1. Identifica los requisitos multimodales para tu caso de uso
2. Describe los controles de seguridad necesarios para proteger datos sensibles
3. Diseña una arquitectura escalable que pueda manejar cargas variables
4. Planifica los puntos de integración con sistemas de IA empresariales
5. Documenta posibles cuellos de botella en el rendimiento y estrategias de mitigación

## Recursos adicionales

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)

---

## Qué sigue

- [5.1 MCP Integration](./mcp-integration/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). I když usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za závazný zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo nesprávné výklady vzniklé použitím tohoto překladu.