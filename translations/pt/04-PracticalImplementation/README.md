<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:49:31+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pt"
}
-->
# Implementação Prática

A implementação prática é onde o poder do Model Context Protocol (MCP) se torna tangível. Embora entender a teoria e a arquitetura por trás do MCP seja importante, o verdadeiro valor surge quando você aplica esses conceitos para construir, testar e implantar soluções que resolvem problemas do mundo real. Este capítulo faz a ponte entre o conhecimento conceitual e o desenvolvimento prático, guiando você através do processo de dar vida a aplicações baseadas em MCP.

Seja você desenvolvendo assistentes inteligentes, integrando IA em fluxos de trabalho empresariais ou criando ferramentas personalizadas para processamento de dados, o MCP oferece uma base flexível. Seu design independente de linguagem e os SDKs oficiais para linguagens de programação populares o tornam acessível a uma ampla gama de desenvolvedores. Ao aproveitar esses SDKs, você pode rapidamente prototipar, iterar e escalar suas soluções em diferentes plataformas e ambientes.

Nas seções a seguir, você encontrará exemplos práticos, códigos de exemplo e estratégias de implantação que demonstram como implementar o MCP em C#, Java, TypeScript, JavaScript e Python. Você também aprenderá a depurar e testar seus servidores MCP, gerenciar APIs e implantar soluções na nuvem usando Azure. Esses recursos práticos são projetados para acelerar seu aprendizado e ajudá-lo a construir com confiança aplicações MCP robustas e prontas para produção.

## Visão Geral

Esta lição foca nos aspectos práticos da implementação do MCP em várias linguagens de programação. Exploraremos como usar os SDKs do MCP em C#, Java, TypeScript, JavaScript e Python para construir aplicações robustas, depurar e testar servidores MCP, e criar recursos, prompts e ferramentas reutilizáveis.

## Objetivos de Aprendizado

Ao final desta lição, você será capaz de:
- Implementar soluções MCP usando SDKs oficiais em várias linguagens de programação
- Depurar e testar servidores MCP de forma sistemática
- Criar e usar recursos de servidor (Recursos, Prompts e Ferramentas)
- Projetar fluxos de trabalho MCP eficazes para tarefas complexas
- Otimizar implementações MCP para desempenho e confiabilidade

## Recursos Oficiais de SDK

O Model Context Protocol oferece SDKs oficiais para várias linguagens:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Trabalhando com SDKs do MCP

Esta seção fornece exemplos práticos de implementação do MCP em várias linguagens de programação. Você pode encontrar códigos de exemplo no diretório `samples` organizado por linguagem.

### Exemplos Disponíveis

O repositório inclui implementações de exemplo nas seguintes linguagens:

- C#
- Java
- TypeScript
- JavaScript
- Python

Cada exemplo demonstra conceitos chave do MCP e padrões de implementação para aquela linguagem e ecossistema específicos.

## Recursos Principais do Servidor

Os servidores MCP podem implementar qualquer combinação desses recursos:

### Recursos
Recursos fornecem contexto e dados para o usuário ou modelo de IA usar:
- Repositórios de documentos
- Bases de conhecimento
- Fontes de dados estruturadas
- Sistemas de arquivos

### Prompts
Prompts são mensagens e fluxos de trabalho modelados para usuários:
- Modelos de conversa predefinidos
- Padrões de interação guiada
- Estruturas de diálogo especializadas

### Ferramentas
Ferramentas são funções para o modelo de IA executar:
- Utilitários de processamento de dados
- Integrações de APIs externas
- Capacidades computacionais
- Funcionalidade de busca

## Implementações de Exemplo: C#

O repositório oficial do SDK C# contém várias implementações de exemplo demonstrando diferentes aspectos do MCP:

- **Cliente MCP Básico**: Exemplo simples mostrando como criar um cliente MCP e chamar ferramentas
- **Servidor MCP Básico**: Implementação mínima de servidor com registro básico de ferramentas
- **Servidor MCP Avançado**: Servidor completo com registro de ferramentas, autenticação e tratamento de erros
- **Integração ASP.NET**: Exemplos demonstrando integração com ASP.NET Core
- **Padrões de Implementação de Ferramentas**: Vários padrões para implementar ferramentas com diferentes níveis de complexidade

O SDK C# do MCP está em pré-visualização e as APIs podem mudar. Continuaremos a atualizar este blog conforme o SDK evolui.

### Características Principais 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construindo seu [primeiro Servidor MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para exemplos completos de implementação em C#, visite o [repositório oficial de exemplos do SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementação de Exemplo: Implementação em Java

O SDK Java oferece opções robustas de implementação MCP com recursos de nível empresarial.

### Características Principais

- Integração com o Spring Framework
- Forte segurança de tipos
- Suporte a programação reativa
- Tratamento abrangente de erros

Para um exemplo completo de implementação em Java, veja [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) no diretório de exemplos.

## Implementação de Exemplo: Implementação em JavaScript

O SDK JavaScript fornece uma abordagem leve e flexível para a implementação do MCP.

### Características Principais

- Suporte a Node.js e navegador
- API baseada em Promises
- Fácil integração com Express e outros frameworks
- Suporte a WebSocket para streaming

Para um exemplo completo de implementação em JavaScript, veja [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) no diretório de exemplos.

## Implementação de Exemplo: Implementação em Python

O SDK Python oferece uma abordagem Pythonica para a implementação do MCP com excelentes integrações de frameworks de ML.

### Características Principais

- Suporte a Async/await com asyncio
- Integração com Flask e FastAPI
- Registro simples de ferramentas
- Integração nativa com bibliotecas populares de ML

Para um exemplo completo de implementação em Python, veja [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) no diretório de exemplos.

## Gestão de API 

O Azure API Management é uma ótima resposta para como podemos proteger servidores MCP. A ideia é colocar uma instância do Azure API Management na frente do seu Servidor MCP e deixá-la lidar com recursos que você provavelmente vai querer, como:

- limitação de taxa
- gerenciamento de tokens
- monitoramento
- balanceamento de carga
- segurança

### Exemplo Azure

Aqui está um Exemplo Azure fazendo exatamente isso, ou seja, [criando um Servidor MCP e protegendo-o com Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Veja como o fluxo de autorização acontece na imagem abaixo:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na imagem anterior, ocorre o seguinte:

- Autenticação/Autorização ocorre usando Microsoft Entra.
- O Azure API Management atua como um gateway e usa políticas para direcionar e gerenciar o tráfego.
- O Azure Monitor registra todas as solicitações para análise posterior.

#### Fluxo de autorização

Vamos dar uma olhada no fluxo de autorização com mais detalhes:

![Diagrama de Sequência](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Especificação de autorização do MCP

Saiba mais sobre a [Especificação de Autorização do MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implantar Servidor MCP Remoto no Azure

Vamos ver se podemos implantar o exemplo que mencionamos anteriormente:

1. Clone o repositório

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. Registre `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` após algum tempo para verificar se o registro está completo.

2. Execute este comando [azd](https://aka.ms/azd) para provisionar o serviço de gerenciamento de API, aplicativo de função (com código) e todos os outros recursos necessários do Azure

    ```shell
    azd up
    ```

    Este comando deve implantar todos os recursos na nuvem no Azure

### Testando seu servidor com MCP Inspector

1. Em uma **nova janela de terminal**, instale e execute o MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Você deve ver uma interface semelhante a:

    ![Conectar ao Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.pt.png)

1. CTRL clique para carregar o aplicativo web do MCP Inspector a partir da URL exibida pelo aplicativo (ex. http://127.0.0.1:6274/#resources)
1. Defina o tipo de transporte para `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` e **Conectar**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listar Ferramentas**. Clique em uma ferramenta e **Executar Ferramenta**.  

Se todos os passos funcionaram, você agora deve estar conectado ao servidor MCP e conseguiu chamar uma ferramenta.

## Servidores MCP para Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Este conjunto de repositórios é um modelo de início rápido para construir e implantar servidores MCP (Model Context Protocol) remotos personalizados usando Azure Functions com Python, C# .NET ou Node/TypeScript. 

Os Exemplos fornecem uma solução completa que permite aos desenvolvedores:

- Construir e executar localmente: Desenvolver e depurar um servidor MCP em uma máquina local
- Implantar no Azure: Implantar facilmente na nuvem com um simples comando azd up
- Conectar a partir de clientes: Conectar ao servidor MCP a partir de vários clientes, incluindo o modo de agente do Copilot do VS Code e a ferramenta MCP Inspector

### Características Principais:

- Segurança por design: O servidor MCP é protegido usando chaves e HTTPS
- Opções de autenticação: Suporta OAuth usando autenticação embutida e/ou Gerenciamento de API
- Isolamento de rede: Permite isolamento de rede usando Redes Virtuais do Azure (VNET)
- Arquitetura serverless: Aproveita Azure Functions para execução escalável e orientada por eventos
- Desenvolvimento local: Suporte abrangente para desenvolvimento e depuração local
- Implantação simples: Processo de implantação simplificado para o Azure

O repositório inclui todos os arquivos de configuração necessários, código-fonte e definições de infraestrutura para começar rapidamente com uma implementação de servidor MCP pronta para produção.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementação de exemplo do MCP usando Azure Functions com Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementação de exemplo do MCP usando Azure Functions com C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementação de exemplo do MCP usando Azure Functions com Node/TypeScript.

## Conclusões

- Os SDKs do MCP fornecem ferramentas específicas para cada linguagem para implementar soluções MCP robustas
- O processo de depuração e teste é crítico para aplicações MCP confiáveis
- Modelos de prompts reutilizáveis permitem interações consistentes de IA
- Fluxos de trabalho bem projetados podem orquestrar tarefas complexas usando várias ferramentas
- Implementar soluções MCP requer consideração de segurança, desempenho e tratamento de erros

## Exercício

Projete um fluxo de trabalho MCP prático que resolva um problema real em seu domínio:

1. Identifique 3-4 ferramentas que seriam úteis para resolver esse problema
2. Crie um diagrama de fluxo de trabalho mostrando como essas ferramentas interagem
3. Implemente uma versão básica de uma das ferramentas usando sua linguagem preferida
4. Crie um modelo de prompt que ajude o modelo a usar sua ferramenta de forma eficaz

## Recursos Adicionais

---

Próximo: [Tópicos Avançados](../05-AdvancedTopics/README.md)

**Aviso Legal**:
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autoritária. Para informações críticas, é recomendada a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.