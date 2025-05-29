<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-29T20:25:41+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "br"
}
-->
# Implementação Prática

A implementação prática é onde o poder do Model Context Protocol (MCP) se torna palpável. Embora entender a teoria e a arquitetura por trás do MCP seja importante, o verdadeiro valor surge quando você aplica esses conceitos para construir, testar e implantar soluções que resolvem problemas do mundo real. Este capítulo faz a ponte entre o conhecimento conceitual e o desenvolvimento prático, guiando você pelo processo de dar vida a aplicações baseadas em MCP.

Seja desenvolvendo assistentes inteligentes, integrando IA em fluxos de trabalho empresariais ou criando ferramentas personalizadas para processamento de dados, o MCP oferece uma base flexível. Seu design independente de linguagem e SDKs oficiais para linguagens populares tornam-no acessível a uma ampla gama de desenvolvedores. Aproveitando esses SDKs, você pode prototipar rapidamente, iterar e escalar suas soluções em diferentes plataformas e ambientes.

Nas próximas seções, você encontrará exemplos práticos, códigos de exemplo e estratégias de implantação que demonstram como implementar MCP em C#, Java, TypeScript, JavaScript e Python. Também aprenderá como depurar e testar seus servidores MCP, gerenciar APIs e implantar soluções na nuvem usando Azure. Esses recursos práticos foram criados para acelerar seu aprendizado e ajudar você a construir com confiança aplicações MCP robustas e prontas para produção.

## Visão Geral

Esta lição foca nos aspectos práticos da implementação do MCP em várias linguagens de programação. Vamos explorar como usar os SDKs do MCP em C#, Java, TypeScript, JavaScript e Python para construir aplicações robustas, depurar e testar servidores MCP, além de criar recursos, prompts e ferramentas reutilizáveis.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:
- Implementar soluções MCP usando os SDKs oficiais em várias linguagens de programação
- Depurar e testar servidores MCP de forma sistemática
- Criar e utilizar funcionalidades do servidor (Resources, Prompts e Tools)
- Projetar fluxos de trabalho MCP eficazes para tarefas complexas
- Otimizar implementações MCP para desempenho e confiabilidade

## Recursos Oficiais dos SDKs

O Model Context Protocol oferece SDKs oficiais para várias linguagens:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Trabalhando com os SDKs do MCP

Esta seção traz exemplos práticos de implementação do MCP em várias linguagens de programação. Você pode encontrar códigos de exemplo no diretório `samples` organizados por linguagem.

### Exemplos Disponíveis

O repositório inclui implementações de exemplo nas seguintes linguagens:

- C#
- Java
- TypeScript
- JavaScript
- Python

Cada exemplo demonstra conceitos-chave do MCP e padrões de implementação para aquela linguagem e ecossistema específicos.

## Funcionalidades Principais do Servidor

Servidores MCP podem implementar qualquer combinação destas funcionalidades:

### Resources
Resources fornecem contexto e dados para o usuário ou modelo de IA utilizar:
- Repositórios de documentos
- Bases de conhecimento
- Fontes de dados estruturadas
- Sistemas de arquivos

### Prompts
Prompts são mensagens e fluxos de trabalho templated para os usuários:
- Modelos de conversação pré-definidos
- Padrões de interação guiada
- Estruturas de diálogo especializadas

### Tools
Tools são funções que o modelo de IA pode executar:
- Utilitários para processamento de dados
- Integrações com APIs externas
- Capacidades computacionais
- Funcionalidade de busca

## Exemplos de Implementação: C#

O repositório oficial do SDK C# contém várias implementações de exemplo que demonstram diferentes aspectos do MCP:

- **Basic MCP Client**: Exemplo simples mostrando como criar um cliente MCP e chamar ferramentas
- **Basic MCP Server**: Implementação mínima de servidor com registro básico de ferramentas
- **Advanced MCP Server**: Servidor completo com registro de ferramentas, autenticação e tratamento de erros
- **Integração com ASP.NET**: Exemplos demonstrando integração com ASP.NET Core
- **Padrões de Implementação de Tools**: Vários padrões para implementar ferramentas com diferentes níveis de complexidade

O SDK MCP para C# está em preview e as APIs podem mudar. Continuaremos atualizando este blog conforme o SDK evolui.

### Funcionalidades Principais
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construindo seu [primeiro MCP Server](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para exemplos completos de implementação em C#, visite o [repositório oficial de exemplos do SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Exemplo de implementação: Java

O SDK Java oferece opções robustas para implementação MCP com recursos de nível empresarial.

### Funcionalidades Principais

- Integração com Spring Framework
- Forte tipagem estática
- Suporte a programação reativa
- Tratamento de erros abrangente

Para um exemplo completo de implementação Java, veja [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) no diretório de exemplos.

## Exemplo de implementação: JavaScript

O SDK JavaScript oferece uma abordagem leve e flexível para implementação MCP.

### Funcionalidades Principais

- Suporte para Node.js e navegador
- API baseada em Promises
- Integração fácil com Express e outros frameworks
- Suporte a WebSocket para streaming

Para um exemplo completo de implementação JavaScript, veja [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) no diretório de exemplos.

## Exemplo de implementação: Python

O SDK Python oferece uma abordagem pythonica para implementação MCP com excelente integração a frameworks de ML.

### Funcionalidades Principais

- Suporte a async/await com asyncio
- Integração com Flask e FastAPI
- Registro simples de ferramentas
- Integração nativa com bibliotecas populares de ML

Para um exemplo completo de implementação Python, veja [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) no diretório de exemplos.

## Gerenciamento de API

O Azure API Management é uma ótima solução para garantir a segurança dos servidores MCP. A ideia é colocar uma instância do Azure API Management na frente do seu servidor MCP e deixar que ela gerencie recursos que você provavelmente vai querer, como:

- limitação de taxa
- gerenciamento de tokens
- monitoramento
- balanceamento de carga
- segurança

### Exemplo Azure

Aqui está um exemplo Azure que faz exatamente isso, ou seja, [criando um MCP Server e protegendo-o com Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Veja como o fluxo de autorização acontece na imagem abaixo:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na imagem acima, ocorre o seguinte:

- A autenticação/autorização é feita usando Microsoft Entra.
- O Azure API Management atua como um gateway e usa políticas para direcionar e gerenciar o tráfego.
- O Azure Monitor registra todas as requisições para análise posterior.

#### Fluxo de autorização

Vamos analisar o fluxo de autorização com mais detalhes:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Especificação de autorização MCP

Saiba mais sobre a [especificação de autorização MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implantando Servidor MCP Remoto no Azure

Vamos ver se conseguimos implantar o exemplo mencionado anteriormente:

1. Clone o repositório

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registre `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` e aguarde um tempo para verificar se o registro foi concluído.

3. Execute este comando [azd](https://aka.ms/azd) para provisionar o serviço de gerenciamento de API, o function app (com código) e todos os demais recursos Azure necessários

    ```shell
    azd up
    ```

    Este comando deve implantar todos os recursos na nuvem no Azure

### Testando seu servidor com MCP Inspector

1. Em uma **nova janela de terminal**, instale e execute o MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Você deverá ver uma interface semelhante a:

    ![Connect to Node inspector](../../../translated_images/connect.9f4ccffc595d24b85ce22579ddf26016b5f21d941d544568c1b9752a51d0a4b1.br.png)

2. CTRL clique para carregar o aplicativo web MCP Inspector a partir da URL exibida pelo app (ex: http://127.0.0.1:6274/#resources)
3. Defina o tipo de transporte para `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` e **Conectar**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listar Tools**. Clique em uma ferramenta e **Executar Tool**.

Se todos os passos funcionaram, agora você está conectado ao servidor MCP e conseguiu chamar uma ferramenta.

## Servidores MCP para Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Este conjunto de repositórios é um template quickstart para construir e implantar servidores MCP remotos personalizados usando Azure Functions com Python, C# .NET ou Node/TypeScript.

Os exemplos fornecem uma solução completa que permite aos desenvolvedores:

- Construir e rodar localmente: Desenvolver e depurar um servidor MCP em uma máquina local
- Implantar no Azure: Implantar facilmente na nuvem com um simples comando azd up
- Conectar de clientes: Conectar ao servidor MCP de vários clientes, incluindo o modo agente Copilot do VS Code e a ferramenta MCP Inspector

### Funcionalidades Principais:

- Segurança desde o design: O servidor MCP é protegido usando chaves e HTTPS
- Opções de autenticação: Suporta OAuth usando autenticação integrada e/ou API Management
- Isolamento de rede: Permite isolamento de rede usando Azure Virtual Networks (VNET)
- Arquitetura serverless: Aproveita Azure Functions para execução escalável e orientada a eventos
- Desenvolvimento local: Suporte abrangente para desenvolvimento e depuração local
- Implantação simples: Processo simplificado para implantar no Azure

O repositório inclui todos os arquivos de configuração necessários, código-fonte e definições de infraestrutura para começar rapidamente com uma implementação MCP pronta para produção.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementação de exemplo do MCP usando Azure Functions com Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementação de exemplo do MCP usando Azure Functions com C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementação de exemplo do MCP usando Azure Functions com Node/TypeScript.

## Principais Aprendizados

- SDKs MCP fornecem ferramentas específicas para cada linguagem para implementar soluções MCP robustas
- O processo de depuração e teste é crítico para aplicações MCP confiáveis
- Templates de prompts reutilizáveis permitem interações consistentes com IA
- Fluxos de trabalho bem desenhados podem orquestrar tarefas complexas usando múltiplas ferramentas
- Implementar soluções MCP requer atenção a segurança, desempenho e tratamento de erros

## Exercício

Projete um fluxo de trabalho MCP prático que resolva um problema real na sua área:

1. Identifique 3-4 ferramentas que seriam úteis para resolver esse problema
2. Crie um diagrama de fluxo mostrando como essas ferramentas interagem
3. Implemente uma versão básica de uma das ferramentas usando sua linguagem preferida
4. Crie um template de prompt que ajude o modelo a usar sua ferramenta de forma eficaz

## Recursos Adicionais


---

Próximo: [Tópicos Avançados](../05-AdvancedTopics/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se a tradução profissional realizada por humanos. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.