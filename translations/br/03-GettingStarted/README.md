<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:08:55+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "br"
}
-->
## Introdução  

Esta seção consiste em várias lições:

- **-1- Seu primeiro servidor**, nesta primeira lição, você aprenderá a criar seu primeiro servidor e inspecioná-lo com a ferramenta de inspeção, uma maneira valiosa de testar e depurar seu servidor, [para a lição](/03-GettingStarted/01-first-server/README.md)

- **-2- Cliente**, nesta lição, você aprenderá a escrever um cliente que pode se conectar ao seu servidor, [para a lição](/03-GettingStarted/02-client/README.md)

- **-3- Cliente com LLM**, uma maneira ainda melhor de escrever um cliente é adicionando um LLM para que ele possa "negociar" com seu servidor sobre o que fazer, [para a lição](/03-GettingStarted/03-llm-client/README.md)

- **-4- Consumindo um servidor no modo Agente do GitHub Copilot no Visual Studio Code**. Aqui, estamos vendo como executar nosso Servidor MCP de dentro do Visual Studio Code, [para a lição](/03-GettingStarted/04-vscode/README.md)

- **-5- Consumindo de um SSE (Server Sent Events)** SSE é um padrão para streaming de servidor para cliente, permitindo que servidores enviem atualizações em tempo real para clientes via HTTP [para a lição](/03-GettingStarted/05-sse-server/README.md)

- **-6- Utilizando AI Toolkit para VSCode** para consumir e testar seus Clientes e Servidores MCP [para a lição](/03-GettingStarted/06-aitk/README.md)

- **-7 Testando**. Aqui vamos focar especialmente em como podemos testar nosso servidor e cliente de diferentes maneiras, [para a lição](/03-GettingStarted/07-testing/README.md)

- **-8- Implantação**. Este capítulo abordará diferentes maneiras de implantar suas soluções MCP, [para a lição](/03-GettingStarted/08-deployment/README.md)

O Protocolo de Contexto de Modelo (MCP) é um protocolo aberto que padroniza como aplicações fornecem contexto para LLMs. Pense no MCP como uma porta USB-C para aplicações de IA - ele fornece uma maneira padronizada de conectar modelos de IA a diferentes fontes de dados e ferramentas.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:

- Configurar ambientes de desenvolvimento para MCP em C#, Java, Python, TypeScript e JavaScript
- Construir e implantar servidores MCP básicos com recursos personalizados (recursos, prompts e ferramentas)
- Criar aplicações hospedeiras que se conectam a servidores MCP
- Testar e depurar implementações MCP
- Compreender desafios comuns de configuração e suas soluções
- Conectar suas implementações MCP a serviços LLM populares

## Configurando Seu Ambiente MCP

Antes de começar a trabalhar com MCP, é importante preparar seu ambiente de desenvolvimento e entender o fluxo de trabalho básico. Esta seção irá guiá-lo através dos passos iniciais de configuração para garantir um início suave com o MCP.

### Pré-requisitos

Antes de mergulhar no desenvolvimento de MCP, certifique-se de ter:

- **Ambiente de Desenvolvimento**: Para a linguagem escolhida (C#, Java, Python, TypeScript ou JavaScript)
- **IDE/Editor**: Visual Studio, Visual Studio Code, IntelliJ, Eclipse, PyCharm ou qualquer editor de código moderno
- **Gerenciadores de Pacotes**: NuGet, Maven/Gradle, pip ou npm/yarn
- **Chaves de API**: Para quaisquer serviços de IA que você planeja usar em suas aplicações hospedeiras

### SDKs Oficiais

Nos próximos capítulos, você verá soluções construídas usando Python, TypeScript, Java e .NET. Aqui estão todos os SDKs oficialmente suportados.

MCP fornece SDKs oficiais para várias linguagens:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - Mantido em colaboração com a Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - Mantido em colaboração com Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - A implementação oficial em TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - A implementação oficial em Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - A implementação oficial em Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - Mantido em colaboração com Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - A implementação oficial em Rust

## Principais Conclusões

- Configurar um ambiente de desenvolvimento MCP é simples com SDKs específicos para cada linguagem
- Construir servidores MCP envolve criar e registrar ferramentas com esquemas claros
- Clientes MCP se conectam a servidores e modelos para aproveitar capacidades estendidas
- Testar e depurar são essenciais para implementações MCP confiáveis
- As opções de implantação variam de desenvolvimento local a soluções baseadas na nuvem

## Praticando

Temos um conjunto de exemplos que complementa os exercícios que você verá em todos os capítulos desta seção. Além disso, cada capítulo também tem seus próprios exercícios e tarefas

- [Calculadora em Java](./samples/java/calculator/README.md)
- [Calculadora em .Net](../../../03-GettingStarted/samples/csharp)
- [Calculadora em JavaScript](./samples/javascript/README.md)
- [Calculadora em TypeScript](./samples/typescript/README.md)
- [Calculadora em Python](../../../03-GettingStarted/samples/python)

## Recursos Adicionais

- [Repositório MCP no GitHub](https://github.com/microsoft/mcp-for-beginners)

## O que vem a seguir

Próximo: [Criando seu primeiro Servidor MCP](/03-GettingStarted/01-first-server/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automatizadas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritativa. Para informações críticas, recomenda-se a tradução humana profissional. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.