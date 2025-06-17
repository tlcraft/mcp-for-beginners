<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "9a14017adf28f7440f20c2d5e7f1d0f8",
  "translation_date": "2025-06-17T15:39:49+00:00",
  "source_file": "README.md",
  "language_code": "br"
}
-->
![MCP-for-beginners](../../translated_images/mcp-beginners.2ce2b317996369ff66c5b72e25eff9d4288ab2741fc70c0b4e523d1ae1e249fd.br.png) 

[![GitHub contributors](https://img.shields.io/github/contributors/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/graphs/contributors)
[![GitHub issues](https://img.shields.io/github/issues/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/issues)
[![GitHub pull-requests](https://img.shields.io/github/issues-pr/microsoft/mcp-for-beginners.svg)](https://GitHub.com/microsoft/mcp-for-beginners/pulls)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](http://makeapullrequest.com)

[![GitHub watchers](https://img.shields.io/github/watchers/microsoft/mcp-for-beginners.svg?style=social&label=Watch)](https://GitHub.com/microsoft/mcp-for-beginners/watchers)
[![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
[![GitHub stars](https://img.shields.io/github/stars/microsoft/mcp-for-beginners?style=social&label=Star)](https://GitHub.com/microsoft/mcp-for-beginners/stargazers)


[![Microsoft Azure AI Foundry Discord](https://dcbadge.vercel.app/api/server/ByRwuEEgH4)](https://discord.com/invite/ByRwuEEgH4)


Siga estes passos para começar a usar esses recursos:
1. **Faça um Fork do Repositório**: Clique em [![GitHub forks](https://img.shields.io/github/forks/microsoft/mcp-for-beginners.svg?style=social&label=Fork)](https://GitHub.com/microsoft/mcp-for-beginners/fork)
2. **Clone o Repositório**:   `git clone https://github.com/microsoft/mcp-for-beginners.git`
3. [**Junte-se ao Discord do Azure AI Foundry e conheça especialistas e outros desenvolvedores**](https://discord.com/invite/ByRwuEEgH4)


### 🌐 Suporte Multilíngue

#### Suportado via GitHub Action (Automatizado e Sempre Atualizado)

# 🚀 Currículo do Model Context Protocol (MCP) para Iniciantes

## **Aprenda MCP com Exemplos Práticos de Código em C#, Java, JavaScript, Python e TypeScript**

## 🧠 Visão Geral do Currículo do Model Context Protocol

O **Model Context Protocol (MCP)** é um framework inovador criado para padronizar as interações entre modelos de IA e aplicações clientes. Este currículo open-source oferece um caminho de aprendizado estruturado, com exemplos práticos de código e casos de uso reais, em linguagens populares como C#, Java, JavaScript, TypeScript e Python.

Seja você um desenvolvedor de IA, arquiteto de sistemas ou engenheiro de software, este guia é seu recurso completo para dominar os fundamentos e estratégias de implementação do MCP.

## 🔗 Recursos Oficiais do MCP

- 📘 [Documentação MCP](https://modelcontextprotocol.io/) – Tutoriais detalhados e guias do usuário  
- 📜 [Especificação MCP](https://spec.modelcontextprotocol.io/) – Arquitetura do protocolo e referências técnicas  
- 🧑‍💻 [Repositório MCP no GitHub](https://github.com/modelcontextprotocol) – SDKs open-source, ferramentas e exemplos de código  

## 🧭 Estrutura Completa do Currículo MCP

| Ch | Título | Descrição | Link |
|--|--|--|--|
| 00 | **Introdução ao MCP** | Visão geral do Model Context Protocol e sua importância em pipelines de IA, incluindo o que é o Model Context Protocol, por que a padronização é importante e casos práticos de uso e benefícios | [Introdução](./00-Introduction/README.md) |
| 01 | **Conceitos Básicos Explicados** | Exploração aprofundada dos conceitos centrais do MCP, incluindo arquitetura cliente-servidor, principais componentes do protocolo e padrões de mensagens | [Conceitos Básicos](./01-CoreConcepts/README.md) |
| 02 | **Segurança no MCP** | Identificação de ameaças de segurança em sistemas baseados em MCP, técnicas e melhores práticas para proteger implementações | [Segurança](./02-Security/README.md) |
| 03 | **Começando com MCP** | Configuração do ambiente, criação de servidores e clientes MCP básicos, integração do MCP com aplicações existentes | [Começando](./03-GettingStarted/README.md) |
| 3.1 | **Primeiro servidor** | Configurando um servidor básico usando o protocolo MCP, entendendo a interação servidor-cliente e testando o servidor | [Primeiro Servidor](./03-GettingStarted/01-first-server/README.md) |
| 3.2 | **Primeiro cliente**  | Configurando um cliente básico usando o protocolo MCP, entendendo a interação cliente-servidor e testando o cliente | [Primeiro Cliente](./03-GettingStarted/02-client/README.md) |
| 3.3 | **Cliente com LLM**  | Configurando um cliente usando o protocolo MCP com um Modelo de Linguagem Grande (LLM) | [Cliente com LLM](./03-GettingStarted/03-llm-client/README.md) |
| 3.4 | **Consumindo um servidor com Visual Studio Code** | Configurando o Visual Studio Code para consumir servidores usando o protocolo MCP | [Consumindo um servidor com Visual Studio Code](./03-GettingStarted/04-vscode/README.md) |
| 3.5 | **Criando um servidor usando SSE** | SSE nos ajuda a expor um servidor para a internet. Esta seção vai te ajudar a criar um servidor usando SSE | [Criando um servidor usando SSE](./03-GettingStarted/05-sse-server/README.md) |
| 3.6 | **Streaming HTTP** | Aprenda a implementar streaming HTTP para transferência de dados em tempo real entre clientes e servidores MCP | [Streaming HTTP](./03-GettingStarted/06-http-streaming/README.md) |
| 3.7 | **Usando AI Toolkit** | AI Toolkit é uma ótima ferramenta que vai te ajudar a gerenciar seu fluxo de trabalho de IA e MCP. | [Usando AI Toolkit](./03-GettingStarted/07-aitk/README.md) |
| 3.8 | **Testando seu servidor** | Testes são uma parte importante do processo de desenvolvimento. Esta seção vai te ajudar a testar usando várias ferramentas diferentes. | [Testando seu servidor](./03-GettingStarted/08-testing/README.md) |
| 3.9 | **Implantando seu servidor** | Como passar do desenvolvimento local para produção? Esta seção vai te ajudar a desenvolver e implantar seu servidor. | [Implantando seu servidor](./03-GettingStarted/09-deployment/README.md) |
| 04 | **Implementação Prática** | Uso de SDKs em diferentes linguagens, depuração, testes e validação, criação de templates e fluxos de trabalho reutilizáveis para prompts | [Implementação Prática](./04-PracticalImplementation/README.md) |
| 05 | **Tópicos Avançados em MCP** | Fluxos de trabalho multimodais e extensibilidade, estratégias seguras de escalabilidade, MCP em ecossistemas empresariais | [Tópicos Avançados](./05-AdvancedTopics/README.md) |
| 5.1 | **Integração MCP com Azure** | Demonstra integração com Azure | [Integração MCP Azure](./05-AdvancedTopics/mcp-integration/README.md) |
| 5.2 | **Multimodalidade** | Mostrando como trabalhar com diferentes modalidades como imagens e outras | [Multimodalidade](./05-AdvancedTopics/mcp-multi-modality/README.md) |
| 5.3 | **Demonstração MCP OAuth2** | Aplicação minimalista Spring Boot mostrando OAuth2 com MCP, tanto como Servidor de Autorização quanto de Recursos. Demonstra emissão segura de tokens, endpoints protegidos, implantação no Azure Container Apps e integração com API Management. | [Demonstração MCP OAuth2](./05-AdvancedTopics/mcp-oauth2-demo/README.md) |
| 5.4 | **Contextos Raiz** | Saiba mais sobre contextos raiz e como implementá-los | [Contextos Raiz](./05-AdvancedTopics/mcp-root-contexts/README.md) |
| 5.5 | **Roteamento** | Aprenda os diferentes tipos de roteamento | [Roteamento](./05-AdvancedTopics/mcp-routing/README.md) |
| 5.6 | **Amostragem** | Aprenda como trabalhar com amostragem | [Amostragem](./05-AdvancedTopics/mcp-sampling/README.md) |
| 5.7 | **Escalabilidade** | Saiba sobre escalabilidade de servidores MCP, incluindo estratégias horizontais e verticais, otimização de recursos e ajuste de desempenho | [Escalabilidade](./05-AdvancedTopics/mcp-scaling/README.md) |
| 5.8 | **Segurança** | Proteja seu servidor MCP, incluindo autenticação, autorização e estratégias de proteção de dados | [Segurança](./05-AdvancedTopics/mcp-security/README.md) |
| 5.9 | **Busca Web MCP** | Servidor e cliente MCP em Python integrando com SerpAPI para busca em tempo real na web, notícias, produtos e Q&A. Demonstra orquestração multi-ferramentas, integração com APIs externas e tratamento robusto de erros | [Busca Web MCP](./05-AdvancedTopics/web-search-mcp/README.md) |
| 5.10 | **Streaming em Tempo Real** | O streaming de dados em tempo real se tornou essencial no mundo orientado a dados de hoje, onde negócios e aplicações precisam de acesso imediato à informação para tomar decisões rápidas. | [Streaming em Tempo Real](./05-AdvancedTopics/mcp-realtimestreaming/README.md) |
| 5.11 | **Busca Web em Tempo Real** | Busca web em tempo real: como o MCP transforma a busca web em tempo real oferecendo uma abordagem padronizada para gerenciamento de contexto entre modelos de IA, motores de busca e aplicações. | [Busca Web em Tempo Real](./05-AdvancedTopics/mcp-realtimesearch/README.md) |
| 06 | **Contribuições da Comunidade** | Como contribuir com código e documentação, colaboração via GitHub, melhorias e feedback orientados pela comunidade | [Contribuições da Comunidade](./06-CommunityContributions/README.md) |
| 07 | **Insights da Adoção Inicial** | Implementações no mundo real e o que funcionou, construção e implantação de soluções baseadas em MCP, tendências e roteiro futuro | [Insights](./07-LessonsFromEarlyAdoption/README.md) |
| 08 | **Melhores Práticas para MCP** | Ajuste e otimização de desempenho, design de sistemas MCP tolerantes a falhas, estratégias de teste e resiliência | [Best Practices](./08-BestPractices/README.md) |
| 09 | **Estudos de Caso MCP** | Análises detalhadas de arquiteturas de soluções MCP, modelos de implantação e dicas de integração, diagramas anotados e walkthroughs de projetos | [Case Studies](./09-CaseStudy/README.md) |
| 10 | **Simplificando Fluxos de Trabalho de IA: Construindo um Servidor MCP com AI Toolkit** | Workshop prático completo combinando MCP com o AI Toolkit da Microsoft para VS Code. Aprenda a criar aplicações inteligentes que conectam modelos de IA com ferramentas do mundo real através de módulos práticos cobrindo fundamentos, desenvolvimento de servidor personalizado e estratégias de implantação em produção. | [Hands On Lab](./10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md) |

## Projetos de Exemplo

### 🧮 Projetos de Exemplo do Calculador MCP:
<details>
  <summary><strong>Explore Implementações de Código por Linguagem</strong></summary>

  - [Exemplo de Servidor MCP em C#](./03-GettingStarted/samples/csharp/README.md)
  - [Calculadora MCP em Java](./03-GettingStarted/samples/java/calculator/README.md)
  - [Demonstração MCP em JavaScript](./03-GettingStarted/samples/javascript/README.md)
  - [Servidor MCP em Python](../../03-GettingStarted/samples/python/mcp_calculator_server.py)
  - [Exemplo MCP em TypeScript](./03-GettingStarted/samples/typescript/README.md)

</details>

### 💡 Projetos Avançados de Calculadora MCP:
<details>
  <summary><strong>Explore Exemplos Avançados</strong></summary>

  - [Exemplo Avançado em C#](./04-PracticalImplementation/samples/csharp/README.md)
  - [Exemplo de Aplicativo Container em Java](./04-PracticalImplementation/samples/java/containerapp/README.md)
  - [Exemplo Avançado em JavaScript](./04-PracticalImplementation/samples/javascript/README.md)
  - [Implementação Complexa em Python](../../04-PracticalImplementation/samples/python/mcp_sample.py)
  - [Exemplo de Container em TypeScript](./04-PracticalImplementation/samples/typescript/README.md)

</details>


## 🎯 Pré-requisitos para Aprender MCP

Para aproveitar ao máximo este currículo, você deve ter:

- Conhecimentos básicos de C#, Java ou Python  
- Entendimento do modelo cliente-servidor e APIs  
- (Opcional) Familiaridade com conceitos de machine learning  

## 📚 Guia de Estudo

Um [Guia de Estudo](./study_guide.md) completo está disponível para ajudar você a navegar neste repositório de forma eficiente. O guia inclui:

- Um mapa visual do currículo mostrando todos os tópicos abordados  
- Detalhamento de cada seção do repositório  
- Orientações sobre como usar os projetos de exemplo  
- Caminhos de aprendizado recomendados para diferentes níveis de habilidade  
- Recursos adicionais para complementar sua jornada de aprendizado  

## 🛠️ Como Usar Este Currículo de Forma Eficiente

Cada lição neste guia inclui:

1. Explicações claras dos conceitos MCP  
2. Exemplos de código ao vivo em várias linguagens  
3. Exercícios para construir aplicações MCP reais  
4. Recursos extras para aprendizes avançados  

## 📜 Informações de Licença

Este conteúdo está licenciado sob a **Licença MIT**. Para termos e condições, consulte o [LICENSE](../../LICENSE).

## 🤝 Diretrizes de Contribuição

Este projeto aceita contribuições e sugestões. A maioria das contribuições exige que você concorde com um Acordo de Licença de Contribuidor (CLA) declarando que você tem o direito e realmente concede os direitos para usarmos sua contribuição. Para detalhes, visite <https://cla.opensource.microsoft.com>.

Ao enviar um pull request, um bot CLA determinará automaticamente se você precisa fornecer um CLA e sinalizará o PR adequadamente (ex.: verificação de status, comentário). Basta seguir as instruções fornecidas pelo bot. Você precisará fazer isso apenas uma vez para todos os repositórios que usam nosso CLA.

Este projeto adotou o [Código de Conduta de Código Aberto da Microsoft](https://opensource.microsoft.com/codeofconduct/). Para mais informações, consulte as [Perguntas Frequentes sobre o Código de Conduta](https://opensource.microsoft.com/codeofconduct/faq/) ou entre em contato pelo email [opencode@microsoft.com](mailto:opencode@microsoft.com) para dúvidas ou comentários adicionais.

## 🎒 Outros Cursos
Nossa equipe produz outros cursos! Confira:

- [Agentes de IA para Iniciantes](https://github.com/microsoft/ai-agents-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [IA Generativa para Iniciantes usando .NET](https://github.com/microsoft/Generative-AI-for-beginners-dotnet?WT.mc_id=academic-105485-koreyst)  
- [IA Generativa para Iniciantes usando JavaScript](https://github.com/microsoft/generative-ai-with-javascript?WT.mc_id=academic-105485-koreyst)  
- [IA Generativa para Iniciantes](https://github.com/microsoft/generative-ai-for-beginners?WT.mc_id=academic-105485-koreyst)  
- [ML para Iniciantes](https://aka.ms/ml-beginners?WT.mc_id=academic-105485-koreyst)  
- [Ciência de Dados para Iniciantes](https://aka.ms/datascience-beginners?WT.mc_id=academic-105485-koreyst)  
- [IA para Iniciantes](https://aka.ms/ai-beginners?WT.mc_id=academic-105485-koreyst)  
- [Cibersegurança para Iniciantes](https://github.com/microsoft/Security-101??WT.mc_id=academic-96948-sayoung)  
- [Desenvolvimento Web para Iniciantes](https://aka.ms/webdev-beginners?WT.mc_id=academic-105485-koreyst)  
- [IoT para Iniciantes](https://aka.ms/iot-beginners?WT.mc_id=academic-105485-koreyst)  
- [Desenvolvimento XR para Iniciantes](https://github.com/microsoft/xr-development-for-beginners?WT.mc_id=academic-105485-koreyst)
- [Dominando o GitHub Copilot para Programação Emparelhada com IA](https://aka.ms/GitHubCopilotAI?WT.mc_id=academic-105485-koreyst)
- [Dominando o GitHub Copilot para Desenvolvedores C#/.NET](https://github.com/microsoft/mastering-github-copilot-for-dotnet-csharp-developers?WT.mc_id=academic-105485-koreyst)
- [Escolha Sua Própria Aventura com o Copilot](https://github.com/microsoft/CopilotAdventures?WT.mc_id=academic-105485-koreyst)


## ™️ Aviso de Marca Registrada

Este projeto pode conter marcas registradas ou logotipos de projetos, produtos ou serviços. O uso autorizado das marcas registradas ou logotipos da Microsoft está sujeito e deve seguir as [Diretrizes de Marca e Propriedade Intelectual da Microsoft](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general).  
O uso das marcas registradas ou logotipos da Microsoft em versões modificadas deste projeto não deve causar confusão nem sugerir patrocínio da Microsoft.  
Qualquer uso de marcas registradas ou logotipos de terceiros está sujeito às políticas desses terceiros.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.