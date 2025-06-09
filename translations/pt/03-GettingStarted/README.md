<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:29:25+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "pt"
}
-->
## Começando  

Esta seção consiste em várias lições:

- **-1- Seu primeiro servidor**, nesta primeira lição, você aprenderá como criar seu primeiro servidor e inspecioná-lo com a ferramenta de inspeção, uma forma valiosa de testar e depurar seu servidor, [para a lição](/03-GettingStarted/01-first-server/README.md)

- **-2- Cliente**, nesta lição, você aprenderá como escrever um cliente que possa se conectar ao seu servidor, [para a lição](/03-GettingStarted/02-client/README.md)

- **-3- Cliente com LLM**, uma forma ainda melhor de escrever um cliente é adicionando um LLM a ele para que ele possa "negociar" com seu servidor sobre o que fazer, [para a lição](/03-GettingStarted/03-llm-client/README.md)

- **-4- Consumindo um servidor no modo GitHub Copilot Agent no Visual Studio Code**. Aqui, veremos como executar nosso MCP Server dentro do Visual Studio Code, [para a lição](/03-GettingStarted/04-vscode/README.md)

- **-5- Consumindo a partir de SSE (Server Sent Events)** SSE é um padrão para streaming de servidor para cliente, permitindo que servidores enviem atualizações em tempo real para os clientes via HTTP [para a lição](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utilizando AI Toolkit para VSCode** para consumir e testar seus MCP Clients e Servers [para a lição](/03-GettingStarted/06-aitk/README.md)

- **-7 Testes**. Aqui vamos focar especialmente em como podemos testar nosso servidor e cliente de diferentes maneiras, [para a lição](/03-GettingStarted/07-testing/README.md)

- **-8- Implantação**. Este capítulo abordará diferentes formas de implantar suas soluções MCP, [para a lição](/03-GettingStarted/08-deployment/README.md)


O Model Context Protocol (MCP) é um protocolo aberto que padroniza como aplicações fornecem contexto para LLMs. Pense no MCP como uma porta USB-C para aplicações de IA - ele oferece uma forma padronizada de conectar modelos de IA a diferentes fontes de dados e ferramentas.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Configurar ambientes de desenvolvimento para MCP em C#, Java, Python, TypeScript e JavaScript
- Construir e implantar servidores MCP básicos com recursos personalizados (recursos, prompts e ferramentas)
- Criar aplicações host que se conectam a servidores MCP
- Testar e depurar implementações MCP
- Entender desafios comuns de configuração e suas soluções
- Conectar suas implementações MCP a serviços populares de LLM

## Configurando seu Ambiente MCP

Antes de começar a trabalhar com MCP, é importante preparar seu ambiente de desenvolvimento e entender o fluxo básico de trabalho. Esta seção irá guiá-lo pelos passos iniciais para garantir um começo tranquilo com MCP.

### Pré-requisitos

Antes de mergulhar no desenvolvimento MCP, certifique-se de que você tem:

- **Ambiente de Desenvolvimento**: Para a linguagem escolhida (C#, Java, Python, TypeScript ou JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ou qualquer editor de código moderno
- **Gerenciadores de Pacotes**: NuGet, Maven/Gradle, pip ou npm/yarn
- **Chaves de API**: Para quaisquer serviços de IA que você planeja usar nas aplicações host


### SDKs Oficiais

Nos próximos capítulos você verá soluções construídas usando Python, TypeScript, Java e .NET. Aqui estão todos os SDKs oficialmente suportados.

O MCP oferece SDKs oficiais para múltiplas linguagens:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantido em colaboração com a Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantido em colaboração com Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - Implementação oficial em TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - Implementação oficial em Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - Implementação oficial em Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantido em colaboração com Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - Implementação oficial em Rust

## Principais Pontos

- Configurar um ambiente de desenvolvimento MCP é simples com SDKs específicos para cada linguagem
- Construir servidores MCP envolve criar e registrar ferramentas com esquemas claros
- Clientes MCP conectam-se a servidores e modelos para aproveitar capacidades estendidas
- Testar e depurar são essenciais para implementações MCP confiáveis
- As opções de implantação variam desde desenvolvimento local até soluções baseadas em nuvem

## Praticando

Temos um conjunto de exemplos que complementa os exercícios que você verá em todos os capítulos desta seção. Além disso, cada capítulo também tem seus próprios exercícios e tarefas

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## Recursos Adicionais

- [Construindo Agentes usando Model Context Protocol no Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP Remoto com Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## O que vem a seguir

Próximo: [Criando seu primeiro MCP Server](/03-GettingStarted/01-first-server/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.