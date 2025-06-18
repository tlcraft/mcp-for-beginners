<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T09:00:18+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "pt"
}
-->
# Implementação Prática

A implementação prática é onde o poder do Model Context Protocol (MCP) se torna tangível. Embora seja importante compreender a teoria e a arquitetura por trás do MCP, o verdadeiro valor surge quando aplicamos estes conceitos para construir, testar e implementar soluções que resolvam problemas do mundo real. Este capítulo faz a ponte entre o conhecimento conceptual e o desenvolvimento prático, guiando-o no processo de dar vida a aplicações baseadas em MCP.

Quer esteja a desenvolver assistentes inteligentes, a integrar IA em fluxos de trabalho empresariais ou a criar ferramentas personalizadas para processamento de dados, o MCP oferece uma base flexível. O seu design independente da linguagem e os SDKs oficiais para linguagens de programação populares tornam-no acessível a uma vasta gama de programadores. Ao tirar partido destes SDKs, pode prototipar, iterar e escalar rapidamente as suas soluções em diferentes plataformas e ambientes.

Nas secções seguintes, encontrará exemplos práticos, código de exemplo e estratégias de implementação que demonstram como implementar MCP em C#, Java, TypeScript, JavaScript e Python. Também aprenderá a depurar e testar os seus servidores MCP, gerir APIs e implementar soluções na cloud usando o Azure. Estes recursos práticos foram concebidos para acelerar a sua aprendizagem e ajudá-lo a construir com confiança aplicações MCP robustas e prontas para produção.

## Visão Geral

Esta lição foca-se nos aspetos práticos da implementação do MCP em várias linguagens de programação. Vamos explorar como usar os SDKs MCP em C#, Java, TypeScript, JavaScript e Python para construir aplicações robustas, depurar e testar servidores MCP, e criar recursos, prompts e ferramentas reutilizáveis.

## Objetivos de Aprendizagem

No final desta lição, será capaz de:
- Implementar soluções MCP usando os SDKs oficiais em várias linguagens de programação
- Depurar e testar servidores MCP de forma sistemática
- Criar e utilizar funcionalidades do servidor (Resources, Prompts e Tools)
- Desenhar fluxos de trabalho MCP eficazes para tarefas complexas
- Otimizar implementações MCP para desempenho e fiabilidade

## Recursos Oficiais dos SDKs

O Model Context Protocol oferece SDKs oficiais para várias linguagens:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## Trabalhar com os SDKs MCP

Esta secção fornece exemplos práticos de implementação do MCP em várias linguagens de programação. Pode encontrar código de exemplo na diretoria `samples` organizada por linguagem.

### Exemplos Disponíveis

O repositório inclui [implementações de exemplo](../../../04-PracticalImplementation/samples) nas seguintes linguagens:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

Cada exemplo demonstra conceitos chave do MCP e padrões de implementação para essa linguagem e ecossistema específicos.

## Funcionalidades Principais do Servidor

Os servidores MCP podem implementar qualquer combinação destas funcionalidades:

### Resources
Os Resources fornecem contexto e dados para o utilizador ou modelo de IA utilizar:
- Repositórios de documentos
- Bases de conhecimento
- Fontes de dados estruturados
- Sistemas de ficheiros

### Prompts
Os Prompts são mensagens e fluxos de trabalho modelados para os utilizadores:
- Modelos de conversação pré-definidos
- Padrões de interação guiada
- Estruturas de diálogo especializadas

### Tools
As Tools são funções para o modelo de IA executar:
- Utilitários de processamento de dados
- Integrações com APIs externas
- Capacidades computacionais
- Funcionalidade de pesquisa

## Implementações de Exemplo: C#

O repositório oficial do SDK C# contém várias implementações de exemplo que demonstram diferentes aspetos do MCP:

- **Basic MCP Client**: Exemplo simples que mostra como criar um cliente MCP e chamar ferramentas
- **Basic MCP Server**: Implementação mínima de servidor com registo básico de ferramentas
- **Advanced MCP Server**: Servidor completo com registo de ferramentas, autenticação e tratamento de erros
- **Integração ASP.NET**: Exemplos que demonstram integração com ASP.NET Core
- **Padrões de Implementação de Tools**: Vários padrões para implementar ferramentas com diferentes níveis de complexidade

O SDK MCP para C# está em pré-visualização e as APIs podem mudar. Vamos atualizar continuamente este blog à medida que o SDK evolui.

### Funcionalidades Principais
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- Construção do seu [primeiro Servidor MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

Para exemplos completos de implementação em C#, visite o [repositório oficial de exemplos do SDK C#](https://github.com/modelcontextprotocol/csharp-sdk)

## Implementação de Exemplo: Java

O SDK Java oferece opções robustas de implementação MCP com funcionalidades ao nível empresarial.

### Funcionalidades Principais

- Integração com Spring Framework
- Forte segurança de tipos
- Suporte a programação reativa
- Tratamento abrangente de erros

Para um exemplo completo de implementação em Java, veja [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) na diretoria de exemplos.

## Implementação de Exemplo: JavaScript

O SDK JavaScript oferece uma abordagem leve e flexível para a implementação MCP.

### Funcionalidades Principais

- Suporte para Node.js e browser
- API baseada em Promises
- Integração fácil com Express e outros frameworks
- Suporte a WebSocket para streaming

Para um exemplo completo de implementação em JavaScript, veja [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) na diretoria de exemplos.

## Implementação de Exemplo: Python

O SDK Python oferece uma abordagem pythonica para a implementação MCP com excelentes integrações em frameworks de ML.

### Funcionalidades Principais

- Suporte a async/await com asyncio
- Integração com Flask e FastAPI
- Registo simples de ferramentas
- Integração nativa com bibliotecas populares de ML

Para um exemplo completo de implementação em Python, veja [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) na diretoria de exemplos.

## Gestão de API

O Azure API Management é uma excelente solução para garantir a segurança dos servidores MCP. A ideia é colocar uma instância do Azure API Management à frente do seu servidor MCP e deixar que esta trate funcionalidades que provavelmente vai querer, como:

- limitação de taxa (rate limiting)
- gestão de tokens
- monitorização
- balanceamento de carga
- segurança

### Exemplo Azure

Aqui está um exemplo Azure que faz exatamente isso, ou seja, [criar um Servidor MCP e protegê-lo com Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

Veja como o fluxo de autorização acontece na imagem abaixo:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

Na imagem anterior, acontece o seguinte:

- A autenticação/autorização ocorre usando Microsoft Entra.
- O Azure API Management atua como gateway e usa políticas para direcionar e gerir o tráfego.
- O Azure Monitor regista todas as solicitações para análise posterior.

#### Fluxo de autorização

Vamos analisar o fluxo de autorização com mais detalhe:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### Especificação de autorização MCP

Saiba mais sobre a [especificação de Autorização MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## Implementar Servidor MCP Remoto no Azure

Vamos ver se conseguimos implementar o exemplo que mencionámos anteriormente:

1. Clone o repositório

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. Registe `Microsoft.App`  
   ` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `  
   `. Then run `Register-AzResourceProvider -ProviderNamespace Microsoft.App` after some time to check if the registration is complete.

2. Run this [azd](https://aka.ms/azd) command to provision the api management service, function app(with code) and all other required Azure resources

    `  
   Após algum tempo, verifique se o registo está completo com `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`.

3. Execute este comando [azd](https://aka.ms/azd) para provisionar o serviço de gestão de API, a função app (com código) e todos os outros recursos Azure necessários

    ```shell
    azd up
    ```

    Este comando deve implementar todos os recursos na cloud no Azure.

### Testar o seu servidor com MCP Inspector

1. Numa **nova janela de terminal**, instale e execute o MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    Deve ver uma interface semelhante a:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.pt.png) 

2. Clique com CTRL para carregar a aplicação web MCP Inspector a partir do URL exibido pela aplicação (ex. http://127.0.0.1:6274/#resources)
3. Defina o tipo de transporte para `SSE` `
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` and **Connect**:

    ` e clique em **Connect**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **Listar Tools**. Clique numa ferramenta e **Execute Tool**.

Se todos os passos correram bem, agora está ligado ao servidor MCP e conseguiu chamar uma ferramenta.

## Servidores MCP para Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): Este conjunto de repositórios são templates de arranque rápido para construir e implementar servidores MCP remotos personalizados usando Azure Functions com Python, C# .NET ou Node/TypeScript.

Os exemplos fornecem uma solução completa que permite aos programadores:

- Construir e executar localmente: desenvolver e depurar um servidor MCP numa máquina local
- Implementar no Azure: implementar facilmente na cloud com um simples comando azd up
- Ligar a partir de clientes: ligar ao servidor MCP a partir de vários clientes, incluindo o modo agente Copilot do VS Code e a ferramenta MCP Inspector

### Funcionalidades Principais:

- Segurança por design: o servidor MCP está protegido com chaves e HTTPS
- Opções de autenticação: suporta OAuth usando autenticação integrada e/ou API Management
- Isolamento de rede: permite isolamento de rede usando Azure Virtual Networks (VNET)
- Arquitetura serverless: utiliza Azure Functions para execução escalável e orientada a eventos
- Desenvolvimento local: suporte abrangente para desenvolvimento e depuração local
- Implementação simples: processo de implementação simplificado para o Azure

O repositório inclui todos os ficheiros de configuração necessários, código fonte e definições de infraestrutura para começar rapidamente com uma implementação de servidor MCP pronta para produção.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - Implementação de exemplo de MCP usando Azure Functions com Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - Implementação de exemplo de MCP usando Azure Functions com C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - Implementação de exemplo de MCP usando Azure Functions com Node/TypeScript.

## Principais Conclusões

- Os SDKs MCP fornecem ferramentas específicas para cada linguagem para implementar soluções MCP robustas
- O processo de depuração e teste é crítico para aplicações MCP fiáveis
- Templates de prompts reutilizáveis permitem interações consistentes com IA
- Fluxos de trabalho bem desenhados podem orquestrar tarefas complexas usando múltiplas ferramentas
- Implementar soluções MCP requer consideração de segurança, desempenho e tratamento de erros

## Exercício

Desenhe um fluxo de trabalho MCP prático que resolva um problema do mundo real na sua área:

1. Identifique 3-4 ferramentas que seriam úteis para resolver este problema
2. Crie um diagrama do fluxo de trabalho mostrando como essas ferramentas interagem
3. Implemente uma versão básica de uma das ferramentas usando a sua linguagem preferida
4. Crie um template de prompt que ajude o modelo a usar eficazmente a sua ferramenta

## Recursos Adicionais


---

Próximo: [Tópicos Avançados](../05-AdvancedTopics/README.md)

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações erradas decorrentes da utilização desta tradução.