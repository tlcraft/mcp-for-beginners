<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:30:16+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "pt"
}
-->
# Estudo de Caso: Expor REST API no API Management como um servidor MCP

O Azure API Management é um serviço que fornece um Gateway por cima dos seus Endpoints de API. O funcionamento baseia-se no Azure API Management atuar como um proxy à frente das suas APIs, podendo decidir o que fazer com os pedidos recebidos.

Ao utilizá-lo, adiciona uma série de funcionalidades como:

- **Segurança**, pode usar desde chaves de API, JWT até identidade gerida.
- **Limitação de taxa**, uma funcionalidade excelente que permite decidir quantas chamadas são permitidas por unidade de tempo. Isto ajuda a garantir que todos os utilizadores têm uma boa experiência e que o seu serviço não fica sobrecarregado com pedidos.
- **Escalabilidade e balanceamento de carga**. Pode configurar vários endpoints para distribuir a carga e também decidir como fazer o "balanceamento de carga".
- **Funcionalidades de IA como cache semântico**, limite de tokens, monitorização de tokens e mais. Estas são funcionalidades que melhoram a capacidade de resposta e ajudam a controlar o consumo de tokens. [Leia mais aqui](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Porquê MCP + Azure API Management?

O Model Context Protocol está rapidamente a tornar-se um padrão para aplicações de IA agentiva e para expor ferramentas e dados de forma consistente. O Azure API Management é uma escolha natural quando precisa de "gerir" APIs. Os servidores MCP frequentemente integram-se com outras APIs para resolver pedidos a uma ferramenta, por exemplo. Portanto, combinar o Azure API Management com MCP faz muito sentido.

## Visão Geral

Neste caso de uso específico, vamos aprender a expor endpoints de API como um Servidor MCP. Ao fazer isto, podemos facilmente tornar estes endpoints parte de uma aplicação agentiva, ao mesmo tempo que aproveitamos as funcionalidades do Azure API Management.

## Funcionalidades Principais

- Seleciona os métodos do endpoint que quer expor como ferramentas.
- As funcionalidades adicionais que obtém dependem do que configurar na secção de políticas para a sua API. Aqui vamos mostrar como adicionar limitação de taxa.

## Passo prévio: importar uma API

Se já tem uma API no Azure API Management, ótimo, pode saltar este passo. Caso contrário, consulte este link, [importar uma API para o Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Expor API como Servidor MCP

Para expor os endpoints da API, siga estes passos:

1. Navegue até ao Azure Portal e ao seguinte endereço <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   Aceda à sua instância do API Management.

1. No menu à esquerda, selecione APIs > MCP Servers > + Criar novo MCP Server.

1. Em API, selecione uma REST API para expor como servidor MCP.

1. Selecione uma ou mais Operações da API para expor como ferramentas. Pode selecionar todas as operações ou apenas operações específicas.

    ![Selecionar métodos para expor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Selecione **Criar**.

1. Navegue até à opção de menu **APIs** e **MCP Servers**, deverá ver o seguinte:

    ![Ver o MCP Server no painel principal](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    O servidor MCP foi criado e as operações da API estão expostas como ferramentas. O servidor MCP está listado no painel MCP Servers. A coluna URL mostra o endpoint do servidor MCP que pode usar para testes ou dentro de uma aplicação cliente.

## Opcional: Configurar políticas

O Azure API Management tem o conceito central de políticas, onde define regras diferentes para os seus endpoints, como por exemplo limitação de taxa ou cache semântico. Estas políticas são escritas em XML.

Aqui está como pode configurar uma política para limitar a taxa do seu Servidor MCP:

1. No portal, em APIs, selecione **MCP Servers**.

1. Selecione o servidor MCP que criou.

1. No menu à esquerda, em MCP, selecione **Policies**.

1. No editor de políticas, adicione ou edite as políticas que quer aplicar às ferramentas do servidor MCP. As políticas são definidas em formato XML. Por exemplo, pode adicionar uma política para limitar as chamadas às ferramentas do servidor MCP (neste exemplo, 5 chamadas por 30 segundos por endereço IP do cliente). Aqui está o XML que irá aplicar a limitação de taxa:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Aqui está uma imagem do editor de políticas:

    ![Editor de políticas](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Experimente

Vamos garantir que o nosso Servidor MCP está a funcionar como esperado.

Para isso, vamos usar o Visual Studio Code e o GitHub Copilot no modo Agent. Vamos adicionar o servidor MCP a um *mcp.json*. Ao fazer isto, o Visual Studio Code atuará como um cliente com capacidades agentivas e os utilizadores finais poderão escrever um prompt e interagir com esse servidor.

Vamos ver como adicionar o servidor MCP no Visual Studio Code:

1. Use o comando MCP: **Add Server** a partir da Command Palette.

1. Quando solicitado, selecione o tipo de servidor: **HTTP (HTTP ou Server Sent Events)**.

1. Introduza a URL do servidor MCP no API Management. Exemplo: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (para endpoint SSE) ou **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (para endpoint MCP), note que a diferença entre os transportes é `/sse` ou `/mcp`.

1. Introduza um ID para o servidor à sua escolha. Este valor não é importante, mas ajuda a lembrar qual é esta instância do servidor.

1. Selecione se quer guardar a configuração nas definições do espaço de trabalho ou nas definições do utilizador.

  - **Definições do espaço de trabalho** - A configuração do servidor é guardada num ficheiro .vscode/mcp.json disponível apenas no espaço de trabalho atual.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    ou, se escolher HTTP streaming como transporte, será ligeiramente diferente:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Definições do utilizador** - A configuração do servidor é adicionada ao seu ficheiro global *settings.json* e está disponível em todos os espaços de trabalho. A configuração é semelhante ao seguinte:

    ![Definições do utilizador](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Também precisa de adicionar uma configuração, um cabeçalho para garantir que a autenticação funciona corretamente com o Azure API Management. Usa um cabeçalho chamado **Ocp-Apim-Subscription-Key**.

    - Aqui está como pode adicioná-lo às definições:

    ![Adicionar cabeçalho para autenticação](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), isto fará aparecer um prompt a pedir o valor da chave API, que pode encontrar no Azure Portal para a sua instância do Azure API Management.

   - Para adicionar ao *mcp.json* em vez disso, pode fazê-lo assim:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### Usar o modo Agent

Agora que está tudo configurado, seja nas definições ou no *.vscode/mcp.json*, vamos experimentar.

Deve haver um ícone de Ferramentas assim, onde as ferramentas expostas pelo seu servidor são listadas:

![Ferramentas do servidor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Clique no ícone de ferramentas e deverá ver uma lista de ferramentas assim:

    ![Ferramentas](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Introduza um prompt no chat para invocar a ferramenta. Por exemplo, se selecionou uma ferramenta para obter informações sobre uma encomenda, pode perguntar ao agente sobre uma encomenda. Aqui está um exemplo de prompt:

    ```text
    get information from order 2
    ```

    Agora será apresentado um ícone de ferramentas a pedir para continuar a chamar uma ferramenta. Selecione para continuar a executar a ferramenta, deverá ver uma saída assim:

    ![Resultado do prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **o que vê acima depende das ferramentas que configurou, mas a ideia é que obtenha uma resposta textual como a mostrada**

## Referências

Aqui está como pode aprender mais:

- [Tutorial sobre Azure API Management e MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Exemplo em Python: Servidores MCP remotos seguros usando Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laboratório de autorização de cliente MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Use a extensão Azure API Management para VS Code para importar e gerir APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registar e descobrir servidores MCP remotos no Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Excelente repositório que mostra muitas capacidades de IA com Azure API Management
- [Workshops AI Gateway](https://azure-samples.github.io/AI-Gateway/) Contém workshops usando o Azure Portal, uma ótima forma de começar a avaliar capacidades de IA.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução automática [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos pela precisão, por favor tenha em conta que traduções automáticas podem conter erros ou imprecisões. O documento original na sua língua nativa deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes da utilização desta tradução.