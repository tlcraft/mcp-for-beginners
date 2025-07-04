<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "97f1c99b5b12cf03d4b1be68b3636a4a",
  "translation_date": "2025-07-04T16:55:51+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "pt"
}
-->
## Começar  

Esta secção consiste em várias lições:

- **1 O teu primeiro servidor**, nesta primeira lição, vais aprender a criar o teu primeiro servidor e a inspecioná-lo com a ferramenta de inspeção, uma forma valiosa de testar e depurar o teu servidor, [para a lição](/03-GettingStarted/01-first-server/README.md)

- **2 Cliente**, nesta lição, vais aprender a escrever um cliente que pode ligar-se ao teu servidor, [para a lição](/03-GettingStarted/02-client/README.md)

- **3 Cliente com LLM**, uma forma ainda melhor de escrever um cliente é adicionando um LLM para que possa "negociar" com o teu servidor sobre o que fazer, [para a lição](/03-GettingStarted/03-llm-client/README.md)

- **4 Consumir um servidor no modo GitHub Copilot Agent no Visual Studio Code**. Aqui, vamos ver como executar o nosso MCP Server a partir do Visual Studio Code, [para a lição](/03-GettingStarted/04-vscode/README.md)

- **5 Consumir a partir de SSE (Server Sent Events)** SSE é um standard para streaming do servidor para o cliente, permitindo que os servidores enviem atualizações em tempo real para os clientes via HTTP [para a lição](/03-GettingStarted/05-sse-server/README.md)

- **6 Streaming HTTP com MCP (Streamable HTTP)**. Aprende sobre streaming HTTP moderno, notificações de progresso, e como implementar servidores e clientes MCP escaláveis e em tempo real usando Streamable HTTP. [para a lição](/03-GettingStarted/06-http-streaming/README.md)

- **7 Utilizar o AI Toolkit para VSCode** para consumir e testar os teus MCP Clients e Servers [para a lição](/03-GettingStarted/07-aitk/README.md)

- **8 Testes**. Aqui vamos focar especialmente em como podemos testar o nosso servidor e cliente de diferentes formas, [para a lição](/03-GettingStarted/08-testing/README.md)

- **9 Deployment**. Este capítulo vai abordar diferentes formas de fazer o deployment das tuas soluções MCP, [para a lição](/03-GettingStarted/09-deployment/README.md)


O Model Context Protocol (MCP) é um protocolo aberto que standardiza a forma como as aplicações fornecem contexto aos LLMs. Pensa no MCP como uma porta USB-C para aplicações de IA - oferece uma forma standard de ligar modelos de IA a diferentes fontes de dados e ferramentas.

## Objetivos de Aprendizagem

No final desta lição, serás capaz de:

- Configurar ambientes de desenvolvimento para MCP em C#, Java, Python, TypeScript e JavaScript
- Construir e fazer deploy de servidores MCP básicos com funcionalidades personalizadas (recursos, prompts e ferramentas)
- Criar aplicações host que se liguem a servidores MCP
- Testar e depurar implementações MCP
- Compreender desafios comuns na configuração e as suas soluções
- Ligar as tuas implementações MCP a serviços populares de LLM

## Configurar o teu Ambiente MCP

Antes de começares a trabalhar com MCP, é importante preparar o teu ambiente de desenvolvimento e compreender o fluxo básico de trabalho. Esta secção vai guiar-te pelos passos iniciais para garantir um início tranquilo com MCP.

### Pré-requisitos

Antes de mergulhares no desenvolvimento MCP, certifica-te que tens:

- **Ambiente de Desenvolvimento**: Para a linguagem escolhida (C#, Java, Python, TypeScript ou JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm, ou qualquer editor de código moderno
- **Gestores de Pacotes**: NuGet, Maven/Gradle, pip, ou npm/yarn
- **Chaves API**: Para quaisquer serviços de IA que planeies usar nas tuas aplicações host


### SDKs Oficiais

Nos próximos capítulos vais ver soluções construídas usando Python, TypeScript, Java e .NET. Aqui estão todos os SDKs oficialmente suportados.

O MCP fornece SDKs oficiais para várias linguagens:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantido em colaboração com a Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantido em colaboração com a Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - A implementação oficial em TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - A implementação oficial em Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - A implementação oficial em Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantido em colaboração com a Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - A implementação oficial em Rust

## Principais Conclusões

- Configurar um ambiente de desenvolvimento MCP é simples com SDKs específicos para cada linguagem
- Construir servidores MCP envolve criar e registar ferramentas com esquemas claros
- Clientes MCP ligam-se a servidores e modelos para tirar partido de capacidades alargadas
- Testar e depurar são essenciais para implementações MCP fiáveis
- As opções de deployment vão desde desenvolvimento local a soluções baseadas na cloud

## Praticar

Temos um conjunto de exemplos que complementa os exercícios que vais encontrar em todos os capítulos desta secção. Além disso, cada capítulo tem também os seus próprios exercícios e tarefas

- [Calculadora Java](./samples/java/calculator/README.md)
- [Calculadora .Net](../../../03-GettingStarted/samples/csharp)
- [Calculadora JavaScript](./samples/javascript/README.md)
- [Calculadora TypeScript](./samples/typescript/README.md)
- [Calculadora Python](../../../03-GettingStarted/samples/python)

## Recursos Adicionais

- [Construir Agentes usando Model Context Protocol na Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP Remoto com Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [Agente MCP OpenAI .NET](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## O que vem a seguir

A seguir: [Criar o teu primeiro MCP Server](./01-first-server/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.