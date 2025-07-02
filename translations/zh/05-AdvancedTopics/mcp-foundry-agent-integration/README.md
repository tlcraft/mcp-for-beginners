<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0d29a939f59d34de10d14433125ea8f5",
  "translation_date": "2025-07-02T10:10:07+00:00",
  "source_file": "05-AdvancedTopics/mcp-foundry-agent-integration/README.md",
  "language_code": "zh"
}
-->
# Model Context Protocol (MCP) 与 Azure AI Foundry 集成

本指南演示如何将 Model Context Protocol (MCP) 服务器与 Azure AI Foundry 代理集成，实现强大的工具编排和企业级 AI 功能。

## 介绍

Model Context Protocol (MCP) 是一种开放标准，使 AI 应用能够安全地连接到外部数据源和工具。与 Azure AI Foundry 集成后，MCP 允许代理以标准化方式访问和交互各种外部服务、API 和数据源。

此集成结合了 MCP 工具生态的灵活性与 Azure AI Foundry 强大的代理框架，提供具备广泛定制能力的企业级 AI 解决方案。

**Note:** 如果您想在 Azure AI Foundry Agent Service 中使用 MCP，目前仅支持以下区域：westus、westus2、uaenorth、southindia 和 switzerlandnorth

## 学习目标

完成本指南后，您将能够：

- 了解 Model Context Protocol 及其优势
- 设置 MCP 服务器以供 Azure AI Foundry 代理使用
- 创建并配置集成 MCP 工具的代理
- 使用真实 MCP 服务器实现实用示例
- 处理代理对话中的工具响应和引用

## 前提条件

开始前，请确保您具备：

- 拥有 Azure 订阅且可访问 AI Foundry
- Python 3.10 及以上版本
- 已安装并配置 Azure CLI
- 具备创建 AI 资源的适当权限

## 什么是 Model Context Protocol (MCP)？

Model Context Protocol 是 AI 应用连接外部数据源和工具的标准化方式。主要优势包括：

- **标准化集成**：不同工具和服务之间接口一致
- **安全性**：安全的身份验证和授权机制
- **灵活性**：支持多种数据源、API 和自定义工具
- **可扩展性**：方便添加新功能和集成

## 在 Azure AI Foundry 中设置 MCP

### 1. 环境配置

首先，配置环境变量和依赖项：

```python
import os
import time
import json
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential


### 1. Initialize the AI Project Client

```python
project_client = AIProjectClient(
    endpoint="https://your-project-endpoint.services.ai.azure.com/api/projects/your-project",
    credential=DefaultAzureCredential(),
)
```

### 2. Create an Agent with MCP Tools

Configure an agent with MCP server integration:

```python
with project_client:
    agent = project_client.agents.create_agent(
        model="gpt-4.1-nano", 
        name="mcp_agent", 
        instructions="你是一个乐于助人的助手。使用提供的工具回答问题，务必引用你的信息来源。",
        tools=[
            {
                "type": "mcp",
                "server_label": "microsoft_docs",
                "server_url": "https://learn.microsoft.com/api/mcp",
                "require_approval": "never"
            }
        ],
        tool_resources=None
    )
    print(f"已创建代理，代理 ID: {agent.id}")
```

## MCP Tool Configuration Options

When configuring MCP tools for your agent, you can specify several important parameters:

### Configuration

```python
mcp_tool = {
    "type": "mcp",
    "server_label": "unique_server_name",      # MCP 服务器的标识符
    "server_url": "https://api.example.com/mcp", # MCP 服务器端点
    "require_approval": "never"                 # 审批策略：目前仅支持 "never"
}
```

## Complete Example: Using Microsoft Learn MCP Server

Here's a complete example that demonstrates creating an agent with MCP integration and processing a conversation:

```python
import time
import json
import os
from azure.ai.agents.models import MessageTextContent, ListSortOrder
from azure.ai.projects import AIProjectClient
from azure.identity import DefaultAzureCredential

def create_mcp_agent_example():

    project_client = AIProjectClient(
        endpoint="https://your-endpoint.services.ai.azure.com/api/projects/your-project",
        credential=DefaultAzureCredential(),
    )

    with project_client:
        # 创建带 MCP 工具的代理
        agent = project_client.agents.create_agent(
            model="gpt-4.1-nano", 
            name="documentation_assistant", 
            instructions="你是专注于微软文档的乐于助人的助手。使用 Microsoft Learn MCP 服务器搜索准确、最新的信息。始终引用你的信息来源。",
            tools=[
                {
                    "type": "mcp",
                    "server_label": "mslearn",
                    "server_url": "https://learn.microsoft.com/api/mcp",
                    "require_approval": "never"
                }
            ],
            tool_resources=None
        )
        print(f"已创建代理，代理 ID: {agent.id}")    
        
        # 创建对话线程
        thread = project_client.agents.threads.create()
        print(f"已创建线程，线程 ID: {thread.id}")

        # 发送消息
        message = project_client.agents.messages.create(
            thread_id=thread.id, 
            role="user", 
            content=".NET MAUI 是什么？它与 Xamarin.Forms 有何区别？",
        )
        print(f"已创建消息，消息 ID: {message.id}")

        # 运行代理
        run = project_client.agents.runs.create(thread_id=thread.id, agent_id=agent.id)
        
        # 轮询等待完成
        while run.status in ["queued", "in_progress", "requires_action"]:
            time.sleep(1)
            run = project_client.agents.runs.get(thread_id=thread.id, run_id=run.id)
            print(f"运行状态：{run.status}")

        # 检查运行步骤和工具调用
        run_steps = project_client.agents.run_steps.list(thread_id=thread.id, run_id=run.id)
        for step in run_steps:
            print(f"运行步骤：{step.id}，状态：{step.status}，类型：{step.type}")
            if step.type == "tool_calls":
                print("工具调用详情：")
                for tool_call in step.step_details.tool_calls:
                    print(json.dumps(tool_call.as_dict(), indent=2))

        # 显示对话内容
        messages = project_client.agents.messages.list(thread_id=thread.id, order=ListSortOrder.ASCENDING)
        for data_point in messages:
            last_message_content = data_point.content[-1]
            if isinstance(last_message_content, MessageTextContent):
                print(f"{data_point.role}: {last_message_content.text.value}")

        return agent.id, thread.id

if __name__ == "__main__":
    create_mcp_agent_example()
```

## 常见问题排查

### 1. 连接问题
- 确认 MCP 服务器 URL 可访问
- 检查身份验证凭据
- 确保网络连接正常

### 2. 工具调用失败
- 检查工具参数和格式
- 核实服务器特定要求
- 实现适当的错误处理

### 3. 性能问题
- 优化工具调用频率
- 适当时使用缓存
- 监控服务器响应时间

## 后续步骤

进一步提升您的 MCP 集成：

1. **探索自定义 MCP 服务器**：构建专有数据源的 MCP 服务器
2. **实现高级安全**：添加 OAuth2 或自定义身份验证机制
3. **监控与分析**：实现工具使用的日志记录和监控
4. **扩展解决方案**：考虑负载均衡和分布式 MCP 服务器架构

## 附加资源

- [Azure AI Foundry 文档](https://learn.microsoft.com/azure/ai-foundry/)
- [Model Context Protocol 示例](https://learn.microsoft.com/azure/ai-foundry/agents/how-to/tools/model-context-protocol-samples)
- [Azure AI Foundry 代理概览](https://learn.microsoft.com/azure/ai-foundry/agents/)
- [MCP 规范](https://spec.modelcontextprotocol.io/)

## 支持

如需更多支持和问题解答：
- 查阅 [Azure AI Foundry 文档](https://learn.microsoft.com/azure/ai-foundry/)
- 访问 [MCP 社区资源](https://modelcontextprotocol.io/)

## 接下来是什么

- [6. 社区贡献](../../06-CommunityContributions/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。