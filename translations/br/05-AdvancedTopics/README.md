<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "adaf47734a5839447b5c60a27120fbaf",
  "translation_date": "2025-06-11T15:28:08+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "br"
}
-->
# Sujéitos Avançados em MCP

Este capítulo tem como objetivo abordar uma série de tópicos avançados na implementação do Model Context Protocol (MCP), incluindo integração multimodal, escalabilidade, melhores práticas de segurança e integração empresarial. Esses tópicos são fundamentais para construir aplicações MCP robustas e prontas para produção que atendam às demandas dos sistemas de IA modernos.

## Visão Geral

Esta lição explora conceitos avançados na implementação do Model Context Protocol, com foco em integração multimodal, escalabilidade, melhores práticas de segurança e integração empresarial. Esses temas são essenciais para desenvolver aplicações MCP de nível produtivo que consigam lidar com requisitos complexos em ambientes corporativos.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Implementar capacidades multimodais dentro dos frameworks MCP  
- Projetar arquiteturas MCP escaláveis para cenários de alta demanda  
- Aplicar melhores práticas de segurança alinhadas aos princípios de segurança do MCP  
- Integrar MCP com sistemas e frameworks de IA corporativos  
- Otimizar desempenho e confiabilidade em ambientes de produção  

## Lições e Projetos de Exemplo

| Link | Título | Descrição |
|------|--------|-----------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integrar com Azure | Aprenda como integrar seu MCP Server no Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Exemplos multimodais MCP | Exemplos para respostas de áudio, imagem e multimodais |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demonstração MCP OAuth2 | Aplicação Spring Boot minimalista mostrando OAuth2 com MCP, tanto como Authorization quanto Resource Server. Demonstra emissão segura de tokens, endpoints protegidos, implantação no Azure Container Apps e integração com API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contextos raiz | Saiba mais sobre contextos raiz e como implementá-los |
| [5.5 Routing](./mcp-routing/README.md) | Roteamento | Aprenda diferentes tipos de roteamento |
| [5.6 Sampling](./mcp-sampling/README.md) | Amostragem | Aprenda a trabalhar com amostragem |
| [5.7 Scaling](./mcp-scaling/README.md) | Escalabilidade | Aprenda sobre escalabilidade |
| [5.8 Security](./mcp-security/README.md) | Segurança | Proteja seu MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Busca Web MCP | Servidor e cliente Python MCP integrando com SerpAPI para busca em tempo real na web, notícias, produtos e perguntas e respostas. Demonstra orquestração multi-ferramentas, integração com APIs externas e tratamento robusto de erros. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming de dados em tempo real tornou-se essencial no mundo orientado a dados de hoje, onde empresas e aplicações precisam de acesso imediato à informação para tomar decisões rápidas. |

## Referências Adicionais

Para as informações mais atualizadas sobre tópicos avançados em MCP, consulte:  
- [MCP Documentation](https://modelcontextprotocol.io/)  
- [MCP Specification](https://spec.modelcontextprotocol.io/)  
- [GitHub Repository](https://github.com/modelcontextprotocol)  

## Principais Pontos

- Implementações multimodais MCP ampliam as capacidades de IA além do processamento de texto  
- Escalabilidade é fundamental para implantações corporativas e pode ser alcançada por escalonamento horizontal e vertical  
- Medidas abrangentes de segurança protegem dados e garantem controle de acesso adequado  
- Integração empresarial com plataformas como Azure OpenAI e Microsoft AI Foundry potencializa as capacidades do MCP  
- Implementações avançadas MCP se beneficiam de arquiteturas otimizadas e gestão cuidadosa de recursos  

## Exercício

Projete uma implementação MCP de nível corporativo para um caso de uso específico:

1. Identifique os requisitos multimodais para seu caso de uso  
2. Delineie os controles de segurança necessários para proteger dados sensíveis  
3. Projete uma arquitetura escalável que possa lidar com cargas variáveis  
4. Planeje os pontos de integração com sistemas de IA empresariais  
5. Documente possíveis gargalos de desempenho e estratégias de mitigação  

## Recursos Adicionais

- [Azure OpenAI Documentation](https://learn.microsoft.com/en-us/azure/ai-services/openai/)  
- [Microsoft AI Foundry Documentation](https://learn.microsoft.com/en-us/ai-services/)  

---

## O que vem a seguir

- [5.1 MCP Integration](./mcp-integration/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte oficial. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.