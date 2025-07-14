<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "748c61250d4a326206b72b28f6154615",
  "translation_date": "2025-07-13T23:43:30+00:00",
  "source_file": "05-AdvancedTopics/README.md",
  "language_code": "br"
}
-->
# Tópicos Avançados em MCP

Este capítulo aborda uma série de tópicos avançados na implementação do Model Context Protocol (MCP), incluindo integração multimodal, escalabilidade, melhores práticas de segurança e integração empresarial. Esses temas são fundamentais para construir aplicações MCP robustas e prontas para produção, capazes de atender às demandas dos sistemas de IA modernos.

## Visão Geral

Esta lição explora conceitos avançados na implementação do Model Context Protocol, com foco em integração multimodal, escalabilidade, melhores práticas de segurança e integração empresarial. Esses tópicos são essenciais para desenvolver aplicações MCP de nível produtivo que possam lidar com requisitos complexos em ambientes corporativos.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Implementar capacidades multimodais dentro dos frameworks MCP
- Projetar arquiteturas MCP escaláveis para cenários de alta demanda
- Aplicar melhores práticas de segurança alinhadas aos princípios de segurança do MCP
- Integrar MCP com sistemas e frameworks de IA empresariais
- Otimizar desempenho e confiabilidade em ambientes de produção

## Lições e Projetos de Exemplo

| Link | Título | Descrição |
|------|--------|-----------|
| [5.1 Integration with Azure](./mcp-integration/README.md) | Integração com Azure | Aprenda como integrar seu MCP Server no Azure |
| [5.2 Multi modal sample](./mcp-multi-modality/README.md) | Exemplos multimodais MCP | Exemplos para respostas em áudio, imagem e multimodal |
| [5.3 MCP OAuth2 sample](../../../05-AdvancedTopics/mcp-oauth2-demo) | Demonstração MCP OAuth2 | Aplicação mínima em Spring Boot mostrando OAuth2 com MCP, tanto como Authorization quanto Resource Server. Demonstra emissão segura de tokens, endpoints protegidos, implantação no Azure Container Apps e integração com API Management. |
| [5.4 Root Contexts](./mcp-root-contexts/README.md) | Contextos raiz | Saiba mais sobre contextos raiz e como implementá-los |
| [5.5 Routing](./mcp-routing/README.md) | Roteamento | Aprenda diferentes tipos de roteamento |
| [5.6 Sampling](./mcp-sampling/README.md) | Amostragem | Aprenda a trabalhar com amostragem |
| [5.7 Scaling](./mcp-scaling/README.md) | Escalabilidade | Conheça conceitos de escalabilidade |
| [5.8 Security](./mcp-security/README.md) | Segurança | Proteja seu MCP Server |
| [5.9 Web Search sample](./web-search-mcp/README.md) | Busca Web MCP | Servidor e cliente MCP em Python integrando com SerpAPI para busca em tempo real na web, notícias, produtos e Q&A. Demonstra orquestração multi-ferramenta, integração com APIs externas e tratamento robusto de erros. |
| [5.10 Realtime Streaming](./mcp-realtimestreaming/README.md) | Streaming | Streaming de dados em tempo real tornou-se essencial no mundo orientado a dados de hoje, onde empresas e aplicações precisam de acesso imediato à informação para tomar decisões rápidas. |
| [5.11 Realtime Web Search](./mcp-realtimesearch/README.md) | Busca Web | Busca web em tempo real: como o MCP transforma a busca web em tempo real ao fornecer uma abordagem padronizada para gerenciamento de contexto entre modelos de IA, motores de busca e aplicações. |
| [5.12  Entra ID Authentication for Model Context Protocol Servers](./mcp-security-entra/README.md) | Autenticação Entra ID | Microsoft Entra ID oferece uma solução robusta de gerenciamento de identidade e acesso baseada em nuvem, garantindo que apenas usuários e aplicações autorizados possam interagir com seu servidor MCP. |
| [5.13 Azure AI Foundry Agent Integration](./mcp-foundry-agent-integration/README.md) | Integração Azure AI Foundry | Aprenda a integrar servidores Model Context Protocol com agentes Azure AI Foundry, possibilitando orquestração poderosa de ferramentas e capacidades de IA empresarial com conexões padronizadas a fontes externas de dados. |

## Referências Adicionais

Para as informações mais atualizadas sobre tópicos avançados de MCP, consulte:
- [Documentação MCP](https://modelcontextprotocol.io/)
- [Especificação MCP](https://spec.modelcontextprotocol.io/)
- [Repositório GitHub](https://github.com/modelcontextprotocol)

## Principais Lições

- Implementações multimodais MCP ampliam as capacidades de IA além do processamento de texto
- Escalabilidade é fundamental para implantações empresariais e pode ser abordada por meio de escalonamento horizontal e vertical
- Medidas abrangentes de segurança protegem dados e garantem controle adequado de acesso
- Integração empresarial com plataformas como Azure OpenAI e Microsoft AI Foundry potencializa as capacidades do MCP
- Implementações avançadas de MCP se beneficiam de arquiteturas otimizadas e gerenciamento cuidadoso de recursos

## Exercício

Projete uma implementação MCP de nível empresarial para um caso de uso específico:

1. Identifique os requisitos multimodais para seu caso de uso
2. Defina os controles de segurança necessários para proteger dados sensíveis
3. Projete uma arquitetura escalável capaz de lidar com cargas variáveis
4. Planeje pontos de integração com sistemas de IA empresariais
5. Documente possíveis gargalos de desempenho e estratégias de mitigação

## Recursos Adicionais

- [Documentação Azure OpenAI](https://learn.microsoft.com/en-us/azure/ai-services/openai/)
- [Documentação Microsoft AI Foundry](https://learn.microsoft.com/en-us/ai-services/)

---

## O que vem a seguir

- [5.1 MCP Integration](./mcp-integration/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.