<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:50:07+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "br"
}
-->
# Implementação Prática

A implementação prática é onde o poder do Model Context Protocol (MCP) se torna palpável. Embora entender a teoria e a arquitetura por trás do MCP seja importante, o verdadeiro valor surge quando você aplica esses conceitos para construir, testar e implantar soluções que resolvem problemas do mundo real. Este capítulo faz a ponte entre o conhecimento conceitual e o desenvolvimento prático, guiando você pelo processo de dar vida a aplicativos baseados em MCP.

Seja desenvolvendo assistentes inteligentes, integrando IA em fluxos de trabalho empresariais ou construindo ferramentas personalizadas para processamento de dados, o MCP fornece uma base flexível. Seu design independente de linguagem e SDKs oficiais para linguagens de programação populares o tornam acessível a uma ampla gama de desenvolvedores. Ao aproveitar esses SDKs, você pode rapidamente prototipar, iterar e escalar suas soluções em diferentes plataformas e ambientes.

Nas seções seguintes, você encontrará exemplos práticos, código de amostra e estratégias de implantação que demonstram como implementar o MCP em C#, Java, TypeScript, JavaScript e Python. Você também aprenderá como depurar e testar seus servidores MCP, gerenciar APIs e implantar soluções na nuvem usando Azure. Esses recursos práticos são projetados para acelerar seu aprendizado e ajudá-lo a construir com confiança aplicativos MCP robustos e prontos para produção.

## Visão Geral

Esta lição foca nos aspectos práticos da implementação do MCP em várias linguagens de programação. Vamos explorar como usar os SDKs do MCP em C#, Java, TypeScript, JavaScript e Python para construir aplicativos robustos, depurar e testar servidores MCP, e criar recursos, prompts e ferramentas reutilizáveis.

## Objetivos de Aprendizagem

Ao final desta lição, você será capaz de:
- Implementar soluções MCP usando SDKs oficiais em várias linguagens de programação
- Depurar e testar servidores MCP de forma sistemática
- Criar e usar recursos de servidor (Recursos, Prompts e Ferramentas)
- Projetar fluxos de trabalho MCP eficazes para tarefas complexas
- Otimizar implementações MCP para desempenho e confiabilidade

## Recursos Oficiais do SDK

O Model Context Protocol oferece SDKs oficiais para várias linguagens:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Trabalhando com SDKs MCP

Esta seção fornece exemplos práticos de implementação do MCP em várias linguagens de programação. Você pode encontrar código de amostra no diretório `samples` organizado por linguagem.

### Exemplos Disponíveis

O repositório inclui implementações de amostra nas seguintes linguagens:

- C#
- Java
- TypeScript
- JavaScript
- Python

Cada exemplo demonstra conceitos chave do MCP e padrões de implementação para aquela linguagem e ecossistema específicos.

## Recursos Principais do Servidor

Os servidores MCP podem implementar qualquer combinação desses recursos:

### Recursos
Os recursos fornecem contexto e dados para o usuário ou modelo de IA usar:
- Repositórios de documentos
- Bases de conhecimento
- Fontes de dados estruturadas
- Sistemas de arquivos

### Prompts
Os prompts são mensagens e fluxos de trabalho modelados para usuários:
- Modelos de conversa pré-definidos
- Padrões de interação guiada
- Estruturas de diálogo especializadas

### Ferramentas
As ferramentas são funções para o modelo de IA executar:
- Utilitários de processamento de dados
- Integrações de API externas
- Capacidades computacionais
- Funcionalidade de busca

## Implementações de Amostra: C#

O repositório oficial do SDK C# contém várias implementações de amostra demonstrando diferentes aspectos do MCP:

- **Cliente MCP Básico**: Exemplo simples mostrando como criar um cliente MCP e chamar ferramentas
- **Servidor MCP Básico**: Implementação mínima de servidor com registro básico de ferramentas
- **Servidor MCP Avançado**: Servidor completo com registro de ferramentas, autenticação e tratamento de erros
- **Integração ASP.NET**: Exemplos demonstrando integração com ASP.NET Core
- **Padrões de Implementação de Ferramentas**: Vários padrões para implementar ferramentas com diferentes níveis de complexidade

O SDK MCP C# está em prévia e as APIs podem mudar. Continuaremos atualizando este blog conforme o SDK evolui.

### Recursos Principais 
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construindo seu [primeiro Servidor MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para amostras completas de implementação em C#, visite o [repositório oficial de amostras do SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementação de amostra: Implementação Java

O SDK Java oferece opções robustas de implementação MCP com recursos de nível empresarial.

### Recursos Principais

- Integração com Spring Framework
- Forte segurança de tipo
- Suporte a programação reativa
- Tratamento de erros abrangente

Para uma amostra completa de implementação em Java, veja [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) no diretório de amostras.

## Implementação de amostra: Implementação JavaScript

O SDK JavaScript fornece uma abordagem leve e flexível para implementação MCP.

### Recursos Principais

- Suporte a Node.js e navegador
- API baseada em Promises
- Fácil integração com Express e outros frameworks
- Suporte a WebSocket para streaming

Para uma amostra completa de implementação em JavaScript, veja [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) no diretório de amostras.

## Implementação de amostra: Implementação Python

O SDK Python oferece uma abordagem Pythonic para implementação MCP com excelentes integrações de frameworks de ML.

### Recursos Principais

- Suporte a Async/await com asyncio
- Integração com Flask e FastAPI
- Registro simples de ferramentas
- Integração nativa com bibliotecas populares de ML

Para uma amostra completa de implementação em Python, veja [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) no diretório de amostras.

## Gerenciamento de API 

O Azure API Management é uma ótima resposta para como podemos proteger servidores MCP. A ideia é colocar uma instância do Azure API Management na frente do seu servidor MCP e deixar que ele lide com recursos que você provavelmente deseja, como:

- limitação de taxa
- gerenciamento de tokens
- monitoramento
- balanceamento de carga
- segurança

### Amostra Azure

Aqui está uma amostra do Azure fazendo exatamente isso, ou seja, [criando um servidor MCP e protegendo-o com Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Veja como o fluxo de autorização acontece na imagem abaixo:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na imagem anterior, ocorre o seguinte:

- Autenticação/Autorização ocorre usando o Microsoft Entra.
- O Azure API Management atua como um gateway e usa políticas para direcionar e gerenciar o tráfego.
- O Azure Monitor registra todas as solicitações para análise posterior.

#### Fluxo de autorização

Vamos olhar o fluxo de autorização com mais detalhes:

![Diagrama de Sequência](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Especificação de autorização MCP

Saiba mais sobre a [especificação de autorização MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implantar Servidor MCP Remoto no Azure

Vamos ver se podemos implantar a amostra que mencionamos anteriormente:

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

    ![Conectar ao inspetor Node](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.br.png)

1. CTRL clique para carregar o aplicativo web MCP Inspector a partir do URL exibido pelo aplicativo (por exemplo, http://127.0.0.1:6274/#resources)
1. Defina o tipo de transporte para `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` e **Conecte**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listar Ferramentas**. Clique em uma ferramenta e **Executar Ferramenta**.  

Se todos os passos funcionaram, você deve agora estar conectado ao servidor MCP e foi capaz de chamar uma ferramenta.

## Servidores MCP para Azure 

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Este conjunto de repositórios são modelos de início rápido para construir e implantar servidores MCP (Model Context Protocol) remotos personalizados usando Azure Functions com Python, C# .NET ou Node/TypeScript.

As amostras fornecem uma solução completa que permite aos desenvolvedores:

- Construir e executar localmente: Desenvolver e depurar um servidor MCP em uma máquina local
- Implantar no Azure: Facilmente implantar na nuvem com um simples comando azd up
- Conectar a partir de clientes: Conectar ao servidor MCP a partir de vários clientes, incluindo o modo de agente do Copilot do VS Code e a ferramenta MCP Inspector

### Recursos Principais:

- Segurança por design: O servidor MCP é protegido usando chaves e HTTPS
- Opções de autenticação: Suporta OAuth usando autenticação embutida e/ou Gerenciamento de API
- Isolamento de rede: Permite isolamento de rede usando Redes Virtuais do Azure (VNET)
- Arquitetura sem servidor: Aproveita o Azure Functions para execução escalável e orientada a eventos
- Desenvolvimento local: Suporte abrangente para desenvolvimento e depuração local
- Implantação simples: Processo de implantação simplificado para o Azure

O repositório inclui todos os arquivos de configuração necessários, código-fonte e definições de infraestrutura para começar rapidamente com uma implementação de servidor MCP pronta para produção.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementação de amostra do MCP usando Azure Functions com Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementação de amostra do MCP usando Azure Functions com C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementação de amostra do MCP usando Azure Functions com Node/TypeScript.

## Conclusões Principais

- Os SDKs MCP fornecem ferramentas específicas de linguagem para implementar soluções MCP robustas
- O processo de depuração e teste é crítico para aplicações MCP confiáveis
- Templates de prompts reutilizáveis permitem interações consistentes de IA
- Fluxos de trabalho bem projetados podem orquestrar tarefas complexas usando várias ferramentas
- Implementar soluções MCP requer consideração de segurança, desempenho e tratamento de erros

## Exercício

Projete um fluxo de trabalho MCP prático que aborde um problema do mundo real em seu domínio:

1. Identifique 3-4 ferramentas que seriam úteis para resolver este problema
2. Crie um diagrama de fluxo de trabalho mostrando como essas ferramentas interagem
3. Implemente uma versão básica de uma das ferramentas usando sua linguagem preferida
4. Crie um template de prompt que ajude o modelo a usar sua ferramenta de forma eficaz

## Recursos Adicionais

---

Próximo: [Tópicos Avançados](../05-AdvancedTopics/README.md)

**Aviso Legal**:  
Este documento foi traduzido usando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, é recomendada a tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações errôneas decorrentes do uso desta tradução.