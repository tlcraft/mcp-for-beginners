<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:30:33+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "br"
}
-->
# Estudo de Caso: Expor REST API no API Management como um servidor MCP

Azure API Management é um serviço que fornece um Gateway sobre seus Endpoints de API. O funcionamento é que o Azure API Management atua como um proxy na frente das suas APIs e pode decidir o que fazer com as requisições recebidas.

Ao utilizá-lo, você adiciona uma série de recursos como:

- **Segurança**, você pode usar desde chaves de API, JWT até identidade gerenciada.
- **Limitação de taxa**, um recurso excelente que permite decidir quantas chamadas são permitidas por unidade de tempo. Isso ajuda a garantir que todos os usuários tenham uma ótima experiência e também que seu serviço não fique sobrecarregado com requisições.
- **Escalabilidade e balanceamento de carga**. Você pode configurar vários endpoints para distribuir a carga e também decidir como fazer o "balanceamento de carga".
- **Recursos de IA como cache semântico**, limite de tokens, monitoramento de tokens e mais. São funcionalidades que melhoram a responsividade e ajudam a controlar o consumo de tokens. [Leia mais aqui](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## Por que MCP + Azure API Management?

O Model Context Protocol está rapidamente se tornando um padrão para apps de IA agentiva e para expor ferramentas e dados de forma consistente. Azure API Management é uma escolha natural quando você precisa "gerenciar" APIs. Servidores MCP frequentemente se integram com outras APIs para resolver requisições para uma ferramenta, por exemplo. Portanto, combinar Azure API Management e MCP faz muito sentido.

## Visão Geral

Neste caso de uso específico, vamos aprender a expor endpoints de API como um Servidor MCP. Fazendo isso, podemos facilmente tornar esses endpoints parte de um app agentivo, aproveitando também os recursos do Azure API Management.

## Principais Recursos

- Você seleciona os métodos do endpoint que deseja expor como ferramentas.
- Os recursos adicionais que você obtém dependem do que configurar na seção de políticas para sua API. Aqui vamos mostrar como adicionar limitação de taxa.

## Passo prévio: importar uma API

Se você já tem uma API no Azure API Management, ótimo, pode pular esta etapa. Caso contrário, confira este link, [importando uma API para Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## Expor API como Servidor MCP

Para expor os endpoints da API, siga estes passos:

1. Acesse o Azure Portal no endereço <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
Navegue até sua instância do API Management.

1. No menu à esquerda, selecione APIs > MCP Servers > + Criar novo MCP Server.

1. Em API, selecione uma REST API para expor como servidor MCP.

1. Selecione uma ou mais Operações da API para expor como ferramentas. Você pode selecionar todas as operações ou apenas algumas específicas.

    ![Selecione os métodos para expor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. Selecione **Criar**.

1. Navegue até a opção de menu **APIs** e **MCP Servers**, você deverá ver o seguinte:

    ![Veja o MCP Server no painel principal](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    O servidor MCP foi criado e as operações da API estão expostas como ferramentas. O servidor MCP aparece listado no painel MCP Servers. A coluna URL mostra o endpoint do servidor MCP que você pode chamar para testes ou dentro de um aplicativo cliente.

## Opcional: Configurar políticas

Azure API Management tem o conceito central de políticas, onde você define regras para seus endpoints, como limitação de taxa ou cache semântico. Essas políticas são escritas em XML.

Veja como configurar uma política para limitar a taxa do seu Servidor MCP:

1. No portal, em APIs, selecione **MCP Servers**.

1. Selecione o servidor MCP que você criou.

1. No menu à esquerda, em MCP, selecione **Policies**.

1. No editor de políticas, adicione ou edite as políticas que deseja aplicar às ferramentas do servidor MCP. As políticas são definidas em formato XML. Por exemplo, você pode adicionar uma política para limitar chamadas às ferramentas do servidor MCP (neste exemplo, 5 chamadas a cada 30 segundos por endereço IP do cliente). Aqui está o XML que fará essa limitação:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    Aqui uma imagem do editor de políticas:

    ![Editor de políticas](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## Teste

Vamos garantir que nosso Servidor MCP está funcionando como esperado.

Para isso, usaremos o Visual Studio Code com o GitHub Copilot no modo Agent. Vamos adicionar o servidor MCP a um arquivo *mcp.json*. Assim, o Visual Studio Code atuará como um cliente com capacidades agentivas e os usuários poderão digitar um prompt e interagir com o servidor.

Veja como adicionar o servidor MCP no Visual Studio Code:

1. Use o comando MCP: **Add Server** no Command Palette.

1. Quando solicitado, selecione o tipo de servidor: **HTTP (HTTP ou Server Sent Events)**.

1. Insira a URL do servidor MCP no API Management. Exemplo: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (para endpoint SSE) ou **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (para endpoint MCP), note que a diferença entre os transportes é `/sse` ou `/mcp`.

1. Insira um ID para o servidor de sua escolha. Esse valor não é crítico, mas ajuda a lembrar qual instância do servidor é essa.

1. Escolha se deseja salvar a configuração nas configurações do workspace ou do usuário.

  - **Configurações do workspace** - A configuração do servidor é salva em um arquivo .vscode/mcp.json disponível apenas no workspace atual.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    ou, se escolher HTTP streaming como transporte, será um pouco diferente:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **Configurações do usuário** - A configuração do servidor é adicionada ao arquivo global *settings.json* e estará disponível em todos os workspaces. A configuração fica parecida com o seguinte:

    ![Configuração do usuário](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. Também é necessário adicionar uma configuração, um header para garantir a autenticação correta com o Azure API Management. Ele usa um header chamado **Ocp-Apim-Subscription-Key**.

    - Veja como adicioná-lo nas configurações:

    ![Adicionando header para autenticação](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png), isso fará com que um prompt seja exibido para você informar o valor da chave da API, que pode ser encontrada no Azure Portal para sua instância do Azure API Management.

   - Para adicioná-lo no *mcp.json*, você pode fazer assim:

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

### Usando o modo Agent

Agora que tudo está configurado, seja nas configurações ou no *.vscode/mcp.json*, vamos testar.

Deve aparecer um ícone de Ferramentas assim, onde as ferramentas expostas pelo seu servidor são listadas:

![Ferramentas do servidor](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. Clique no ícone de ferramentas e você verá uma lista de ferramentas assim:

    ![Ferramentas](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. Digite um prompt no chat para invocar a ferramenta. Por exemplo, se você selecionou uma ferramenta para obter informações sobre um pedido, pode perguntar ao agente sobre um pedido. Aqui está um exemplo de prompt:

    ```text
    get information from order 2
    ```

    Agora será exibido um ícone de ferramentas pedindo para você confirmar a chamada da ferramenta. Selecione para continuar executando a ferramenta, você deverá ver uma saída assim:

    ![Resultado do prompt](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **o que você vê acima depende das ferramentas que configurou, mas a ideia é que receba uma resposta textual como essa**

## Referências

Veja como aprender mais:

- [Tutorial sobre Azure API Management e MCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Exemplo em Python: Servidores MCP remotos seguros usando Azure API Management (experimental)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [Laboratório de autorização de cliente MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [Use a extensão Azure API Management para VS Code para importar e gerenciar APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [Registrar e descobrir servidores MCP remotos no Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) Excelente repositório que mostra várias capacidades de IA com Azure API Management
- [Workshops AI Gateway](https://azure-samples.github.io/AI-Gateway/) Contém workshops usando o Azure Portal, uma ótima forma de começar a avaliar capacidades de IA.

**Aviso Legal**:  
Este documento foi traduzido utilizando o serviço de tradução por IA [Co-op Translator](https://github.com/Azure/co-op-translator). Embora nos esforcemos para garantir a precisão, esteja ciente de que traduções automáticas podem conter erros ou imprecisões. O documento original em seu idioma nativo deve ser considerado a fonte autorizada. Para informações críticas, recomenda-se tradução profissional humana. Não nos responsabilizamos por quaisquer mal-entendidos ou interpretações incorretas decorrentes do uso desta tradução.