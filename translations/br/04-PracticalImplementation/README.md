<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T18:11:41+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "br"
}
-->
# Implementação Prática

A implementação prática é onde o poder do Model Context Protocol (MCP) se torna tangível. Embora entender a teoria e a arquitetura por trás do MCP seja importante, o valor real surge quando você aplica esses conceitos para construir, testar e implantar soluções que resolvem problemas do mundo real. Este capítulo faz a ponte entre o conhecimento conceitual e o desenvolvimento prático, guiando você no processo de dar vida a aplicações baseadas em MCP.

Seja desenvolvendo assistentes inteligentes, integrando IA em fluxos de trabalho empresariais ou criando ferramentas personalizadas para processamento de dados, o MCP oferece uma base flexível. Seu design independente de linguagem e os SDKs oficiais para linguagens populares tornam-no acessível a uma ampla variedade de desenvolvedores. Ao aproveitar esses SDKs, você pode rapidamente prototipar, iterar e escalar suas soluções em diferentes plataformas e ambientes.

Nas seções seguintes, você encontrará exemplos práticos, códigos de amostra e estratégias de implantação que demonstram como implementar o MCP em C#, Java, TypeScript, JavaScript e Python. Também aprenderá como depurar e testar seus servidores MCP, gerenciar APIs e implantar soluções na nuvem usando Azure. Esses recursos práticos foram criados para acelerar seu aprendizado e ajudar você a construir com confiança aplicações MCP robustas e prontas para produção.

## Visão Geral

Esta lição foca nos aspectos práticos da implementação do MCP em várias linguagens de programação. Vamos explorar como usar os SDKs MCP em C#, Java, TypeScript, JavaScript e Python para construir aplicações robustas, depurar e testar servidores MCP, além de criar recursos, prompts e ferramentas reutilizáveis.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:
- Implementar soluções MCP usando os SDKs oficiais em diversas linguagens de programação
- Depurar e testar servidores MCP de forma sistemática
- Criar e usar funcionalidades do servidor (Recursos, Prompts e Ferramentas)
- Projetar fluxos de trabalho MCP eficazes para tarefas complexas
- Otimizar implementações MCP para desempenho e confiabilidade

## Recursos Oficiais dos SDKs

O Model Context Protocol oferece SDKs oficiais para várias linguagens:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Trabalhando com os SDKs MCP

Esta seção oferece exemplos práticos de implementação do MCP em várias linguagens de programação. Você pode encontrar códigos de amostra no diretório `samples` organizados por linguagem.

### Amostras Disponíveis

O repositório inclui implementações de exemplo nas seguintes linguagens:

- C#
- Java
- TypeScript
- JavaScript
- Python

Cada amostra demonstra conceitos-chave do MCP e padrões de implementação para aquela linguagem e ecossistema específicos.

## Funcionalidades Principais do Servidor

Servidores MCP podem implementar qualquer combinação dessas funcionalidades:

### Recursos  
Recursos fornecem contexto e dados para o usuário ou modelo de IA usar:  
- Repositórios de documentos  
- Bases de conhecimento  
- Fontes de dados estruturados  
- Sistemas de arquivos  

### Prompts  
Prompts são mensagens e fluxos de trabalho modelados para os usuários:  
- Templates de conversa pré-definidos  
- Padrões de interação guiada  
- Estruturas de diálogo especializadas  

### Ferramentas  
Ferramentas são funções para o modelo de IA executar:  
- Utilitários de processamento de dados  
- Integrações com APIs externas  
- Capacidades computacionais  
- Funcionalidade de busca  

## Implementações de Exemplo: C#

O repositório oficial do SDK C# contém várias implementações de exemplo que demonstram diferentes aspectos do MCP:

- **Cliente MCP Básico**: Exemplo simples mostrando como criar um cliente MCP e chamar ferramentas  
- **Servidor MCP Básico**: Implementação mínima de servidor com registro básico de ferramentas  
- **Servidor MCP Avançado**: Servidor completo com registro de ferramentas, autenticação e tratamento de erros  
- **Integração ASP.NET**: Exemplos demonstrando integração com ASP.NET Core  
- **Padrões de Implementação de Ferramentas**: Vários padrões para implementar ferramentas com diferentes níveis de complexidade  

O SDK MCP para C# está em prévia e as APIs podem mudar. Continuaremos atualizando este blog conforme o SDK evolui.

### Funcionalidades Principais  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construindo seu [primeiro Servidor MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para amostras completas de implementação em C#, visite o [repositório oficial de amostras do SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementação de Exemplo: Java

O SDK Java oferece opções robustas para implementação do MCP com recursos de nível empresarial.

### Funcionalidades Principais

- Integração com Spring Framework  
- Forte segurança de tipos  
- Suporte a programação reativa  
- Tratamento abrangente de erros  

Para um exemplo completo de implementação em Java, veja [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) no diretório de amostras.

## Implementação de Exemplo: JavaScript

O SDK JavaScript oferece uma abordagem leve e flexível para implementação do MCP.

### Funcionalidades Principais

- Suporte a Node.js e navegadores  
- API baseada em Promises  
- Integração fácil com Express e outros frameworks  
- Suporte a WebSocket para streaming  

Para um exemplo completo de implementação em JavaScript, veja [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) no diretório de amostras.

## Implementação de Exemplo: Python

O SDK Python oferece uma abordagem pythonica para implementação do MCP com integrações excelentes para frameworks de ML.

### Funcionalidades Principais

- Suporte a async/await com asyncio  
- Integração com Flask e FastAPI  
- Registro simples de ferramentas  
- Integração nativa com bibliotecas populares de ML  

Para um exemplo completo de implementação em Python, veja [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) no diretório de amostras.

## Gerenciamento de API

O Azure API Management é uma ótima solução para garantir a segurança dos servidores MCP. A ideia é colocar uma instância do Azure API Management na frente do seu servidor MCP e deixar que ele gerencie recursos que você provavelmente vai querer, como:

- limitação de taxa  
- gerenciamento de tokens  
- monitoramento  
- balanceamento de carga  
- segurança  

### Exemplo Azure

Aqui está um exemplo Azure que faz exatamente isso, ou seja, [criando um Servidor MCP e protegendo-o com Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Veja como o fluxo de autorização acontece na imagem abaixo:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na imagem acima, ocorre o seguinte:

- Autenticação/Autorização usando Microsoft Entra.  
- Azure API Management atua como gateway e usa políticas para direcionar e gerenciar o tráfego.  
- Azure Monitor registra todas as requisições para análise posterior.  

#### Fluxo de autorização

Vamos analisar o fluxo de autorização com mais detalhes:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Especificação de autorização MCP

Saiba mais sobre a [especificação de Autorização MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implantando o Servidor MCP Remoto no Azure

Vamos ver se conseguimos implantar o exemplo que mencionamos anteriormente:

1. Clone o repositório

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registre `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` e, após algum tempo, verifique se o registro foi concluído.

2. Execute este comando [azd](https://aka.ms/azd) para provisionar o serviço de gerenciamento de API, a function app (com código) e todos os outros recursos necessários no Azure

    ```shell
    azd up
    ```

    Este comando deve implantar todos os recursos na nuvem no Azure

### Testando seu servidor com MCP Inspector

1. Em uma **nova janela do terminal**, instale e execute o MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Você deve ver uma interface semelhante a:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.br.png) 

1. Clique com CTRL para carregar o app web MCP Inspector a partir da URL exibida pelo app (ex: http://127.0.0.1:6274/#resources)  
1. Defina o tipo de transporte para `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` e **Conecte-se**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listar Ferramentas**. Clique em uma ferramenta e **Execute a Ferramenta**.  

Se todos os passos funcionaram, você agora está conectado ao servidor MCP e conseguiu chamar uma ferramenta.

## Servidores MCP para Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Este conjunto de repositórios é um template rápido para construir e implantar servidores MCP remotos personalizados usando Azure Functions com Python, C# .NET ou Node/TypeScript.

As amostras fornecem uma solução completa que permite aos desenvolvedores:

- Construir e rodar localmente: Desenvolver e depurar um servidor MCP em uma máquina local  
- Implantar no Azure: Implantar facilmente na nuvem com um simples comando azd up  
- Conectar de clientes: Conectar ao servidor MCP de vários clientes, incluindo o modo agente Copilot do VS Code e a ferramenta MCP Inspector  

### Funcionalidades Principais:

- Segurança desde o design: O servidor MCP é protegido usando chaves e HTTPS  
- Opções de autenticação: Suporta OAuth usando autenticação embutida e/ou API Management  
- Isolamento de rede: Permite isolamento de rede usando Azure Virtual Networks (VNET)  
- Arquitetura serverless: Aproveita Azure Functions para execução escalável e orientada a eventos  
- Desenvolvimento local: Suporte completo para desenvolvimento e depuração local  
- Implantação simples: Processo simplificado para implantação no Azure  

O repositório inclui todos os arquivos de configuração necessários, código-fonte e definições de infraestrutura para começar rapidamente com uma implementação de servidor MCP pronta para produção.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementação de exemplo do MCP usando Azure Functions com Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementação de exemplo do MCP usando Azure Functions com C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementação de exemplo do MCP usando Azure Functions com Node/TypeScript.

## Principais Lições

- SDKs MCP oferecem ferramentas específicas para cada linguagem para implementar soluções MCP robustas  
- O processo de depuração e teste é fundamental para aplicações MCP confiáveis  
- Templates de prompt reutilizáveis garantem interações consistentes com a IA  
- Fluxos de trabalho bem desenhados podem orquestrar tarefas complexas usando múltiplas ferramentas  
- Implementar soluções MCP requer atenção à segurança, desempenho e tratamento de erros  

## Exercício

Projete um fluxo de trabalho MCP prático que resolva um problema do mundo real na sua área:

1. Identifique 3-4 ferramentas que seriam úteis para resolver esse problema  
2. Crie um diagrama de fluxo mostrando como essas ferramentas interagem  
3. Implemente uma versão básica de uma das ferramentas usando sua linguagem preferida  
4. Crie um template de prompt que ajude o modelo a usar sua ferramenta de forma eficaz  

## Recursos Adicionais


---

Próximo: [Tópicos Avançados](../05-AdvancedTopics/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional feita por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.