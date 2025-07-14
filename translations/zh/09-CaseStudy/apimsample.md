<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:26:33+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "zh"
}
-->
# 案例研究：在 API 管理中将 REST API 作为 MCP 服务器公开

Azure API Management 是一项在您的 API 端点之上提供网关服务的服务。它的工作原理是 Azure API Management 充当您 API 前端的代理，可以决定如何处理传入的请求。

通过使用它，您可以获得一系列功能，例如：

- **安全性**，您可以使用从 API 密钥、JWT 到托管身份的各种方式。
- **速率限制**，一个很棒的功能是能够决定在特定时间单位内允许多少调用通过。这有助于确保所有用户都能获得良好的体验，同时避免您的服务被请求淹没。
- **扩展与负载均衡**。您可以设置多个端点来分担负载，也可以决定如何进行“负载均衡”。
- **AI 功能，如语义缓存、令牌限制和令牌监控等**。这些功能不仅提升响应速度，还帮助您掌控令牌的使用情况。[详细阅读](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities)。

## 为什么选择 MCP + Azure API Management？

Model Context Protocol 正迅速成为智能代理 AI 应用的标准，用于以一致的方式公开工具和数据。当您需要“管理”API 时，Azure API Management 是一个自然的选择。MCP 服务器通常会集成其他 API 来处理对工具的请求。因此，将 Azure API Management 与 MCP 结合使用非常合理。

## 概述

在本具体用例中，我们将学习如何将 API 端点作为 MCP 服务器公开。通过这样做，我们可以轻松地将这些端点作为智能代理应用的一部分，同时利用 Azure API Management 的各种功能。

## 主要功能

- 您可以选择希望作为工具公开的端点方法。
- 您获得的附加功能取决于您在 API 的策略部分配置的内容。但这里我们将展示如何添加速率限制。

## 预备步骤：导入 API

如果您已经在 Azure API Management 中有 API，太好了，可以跳过此步骤。如果没有，请查看此链接，[将 API 导入 Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api)。

## 将 API 公开为 MCP 服务器

要公开 API 端点，请按照以下步骤操作：

1. 访问 Azure 门户，地址为 <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
   进入您的 API Management 实例。

1. 在左侧菜单中，选择 APIs > MCP Servers > + 创建新的 MCP 服务器。

1. 在 API 中，选择一个 REST API 作为 MCP 服务器公开。

1. 选择一个或多个 API 操作作为工具公开。您可以选择全部操作或仅特定操作。

    ![选择要公开的方法](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. 选择 **创建**。

1. 导航到菜单选项 **APIs** 和 **MCP Servers**，您应该会看到如下内容：

    ![在主面板中查看 MCP 服务器](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    MCP 服务器已创建，API 操作已作为工具公开。MCP 服务器会列在 MCP Servers 面板中。URL 列显示 MCP 服务器的端点，您可以用于测试或客户端应用调用。

## 可选：配置策略

Azure API Management 的核心概念是策略，您可以为端点设置不同规则，例如速率限制或语义缓存。这些策略以 XML 格式编写。

以下是如何为 MCP 服务器设置速率限制策略：

1. 在门户中，进入 APIs，选择 **MCP Servers**。

1. 选择您创建的 MCP 服务器。

1. 在左侧菜单中，MCP 下选择 **Policies**。

1. 在策略编辑器中，添加或编辑您想应用于 MCP 服务器工具的策略。策略以 XML 格式定义。例如，您可以添加一个策略，限制 MCP 服务器工具的调用次数（本例中为每个客户端 IP 地址每 30 秒最多 5 次调用）。以下 XML 会实现速率限制：

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    下面是策略编辑器的截图：

    ![策略编辑器](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## 试用

让我们确保 MCP 服务器按预期工作。

为此，我们将使用 Visual Studio Code 和 GitHub Copilot 的 Agent 模式。我们会将 MCP 服务器添加到 *mcp.json* 文件中。这样，Visual Studio Code 就能作为具有代理能力的客户端，最终用户可以输入提示并与该服务器交互。

下面演示如何在 Visual Studio Code 中添加 MCP 服务器：

1. 使用命令面板中的 MCP: **Add Server 命令**。

1. 提示时，选择服务器类型：**HTTP（HTTP 或 Server Sent Events）**。

1. 输入 API Management 中 MCP 服务器的 URL。例如：**https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse**（用于 SSE 端点）或 **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp**（用于 MCP 端点），注意两种传输方式的区别是 `/sse` 或 `/mcp`。

1. 输入您选择的服务器 ID。这个值不重要，但有助于您记住该服务器实例。

1. 选择将配置保存到工作区设置还是用户设置。

  - **工作区设置** - 服务器配置保存到当前工作区的 .vscode/mcp.json 文件中。

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    如果选择流式 HTTP 作为传输方式，配置会略有不同：

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **用户设置** - 服务器配置添加到全局 *settings.json* 文件中，适用于所有工作区。配置示例如下：

    ![用户设置](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. 您还需要添加配置头，确保正确认证到 Azure API Management。它使用名为 **Ocp-Apim-Subscription-Key** 的请求头。

    - 下面是如何将其添加到设置中的示例：

    ![添加认证头](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)，这会弹出提示，要求您输入 API 密钥值，您可以在 Azure 门户的 Azure API Management 实例中找到该密钥。

   - 如果要添加到 *mcp.json*，可以这样写：

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

### 使用 Agent 模式

现在无论是在设置中还是在 *.vscode/mcp.json* 中都已配置完成。让我们试试。

应该会有一个工具图标，显示您服务器公开的工具列表：

![服务器工具](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. 点击工具图标，您会看到如下工具列表：

    ![工具列表](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. 在聊天中输入提示以调用工具。例如，如果您选择了一个获取订单信息的工具，可以向代理询问订单。示例提示如下：

    ```text
    get information from order 2
    ```

    之后会出现工具图标，提示您是否继续调用工具。选择继续运行工具，您将看到如下输出：

    ![提示结果](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **上图显示的内容取决于您设置的工具，但核心思想是您会获得类似的文本响应。**


## 参考资料

您可以通过以下方式了解更多：

- [Azure API Management 和 MCP 教程](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [Python 示例：使用 Azure API Management 保护远程 MCP 服务器（实验性）](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [MCP 客户端授权实验](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [使用 Azure API Management VS Code 扩展导入和管理 API](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [在 Azure API Center 注册和发现远程 MCP 服务器](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [AI Gateway](https://github.com/Azure-Samples/AI-Gateway) 一个展示 Azure API Management 多种 AI 功能的优秀仓库
- [AI Gateway 研讨会](https://azure-samples.github.io/AI-Gateway/) 包含使用 Azure 门户的研讨会，是评估 AI 功能的绝佳起点

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。我们不对因使用本翻译而产生的任何误解或误释承担责任。