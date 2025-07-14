<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a05fb941810e539147fec53aaadbb6fd",
  "translation_date": "2025-07-14T06:37:11+00:00",
  "source_file": "09-CaseStudy/docs-mcp/solution/python/README.md",
  "language_code": "zh"
}
-->
# 使用 Chainlit 和 Microsoft Learn Docs MCP 的学习计划生成器

## 前提条件

- Python 3.8 或更高版本  
- pip（Python 包管理器）  
- 可连接到 Microsoft Learn Docs MCP 服务器的网络访问权限  

## 安装

1. 克隆此仓库或下载项目文件。  
2. 安装所需依赖：

   ```bash
   pip install -r requirements.txt
   ```

## 使用方法

### 场景 1：简单查询 Docs MCP  
一个命令行客户端，连接到 Docs MCP 服务器，发送查询并打印结果。

1. 运行脚本：  
   ```bash
   python scenario1.py
   ```  
2. 在提示符下输入你的文档问题。

### 场景 2：学习计划生成器（Chainlit Web 应用）  
基于网页的界面（使用 Chainlit），允许用户为任何技术主题生成个性化的逐周学习计划。

1. 启动 Chainlit 应用：  
   ```bash
   chainlit run scenario2.py
   ```  
2. 在浏览器中打开终端提供的本地 URL（例如 http://localhost:8000）。  
3. 在聊天窗口输入你的学习主题和计划学习的周数（例如，“AI-900 认证，8 周”）。  
4. 应用会返回逐周的学习计划，并附带相关的 Microsoft Learn 文档链接。

**所需环境变量：**

要使用场景 2（带 Azure OpenAI 的 Chainlit Web 应用），必须在 `python` 目录下的 `.env` 文件中设置以下环境变量：

```
AZURE_OPENAI_CHAT_DEPLOYMENT_NAME=
AZURE_OPENAI_API_KEY=
AZURE_OPENAI_ENDPOINT=
AZURE_OPENAI_API_VERSION=
```

在运行应用前，请填写你的 Azure OpenAI 资源详细信息。

> **提示：** 你可以使用 [Azure AI Foundry](https://ai.azure.com/) 轻松部署自己的模型。

### 场景 3：在 VS Code 中使用 MCP 服务器查看文档

无需切换浏览器标签页搜索文档，你可以直接在 VS Code 中通过 MCP 服务器访问 Microsoft Learn Docs。这样你可以：  
- 在 VS Code 内搜索和阅读文档，无需离开编码环境。  
- 直接引用文档并插入链接到 README 或课程文件中。  
- 将 GitHub Copilot 和 MCP 结合使用，实现无缝的 AI 驱动文档工作流程。

**示例用例：**  
- 在编写课程或项目文档时，快速添加参考链接到 README。  
- 使用 Copilot 生成代码，同时用 MCP 立即查找并引用相关文档。  
- 保持专注于编辑器，提高工作效率。

> [!IMPORTANT]  
> 确保你的工作区中有有效的 [`mcp.json`](../../../../../../09-CaseStudy/docs-mcp/solution/scenario3/mcp.json) 配置文件（位置为 `.vscode/mcp.json`）。

## 为什么选择 Chainlit 用于场景 2？

Chainlit 是一个现代开源框架，用于构建对话式网页应用。它让创建连接到后端服务（如 Microsoft Learn Docs MCP 服务器）的聊天界面变得简单。该项目利用 Chainlit 提供一种简单、交互式的方式，实时生成个性化学习计划。借助 Chainlit，你可以快速构建和部署基于聊天的工具，提升生产力和学习效果。

## 功能介绍

该应用允许用户通过输入主题和时长，创建个性化学习计划。应用会解析你的输入，向 Microsoft Learn Docs MCP 服务器查询相关内容，并将结果整理成结构化的逐周计划。每周的推荐内容会在聊天中显示，方便跟踪学习进度。集成确保你始终获得最新、最相关的学习资源。

## 示例查询

在聊天窗口尝试以下查询，看看应用如何响应：

- `AI-900 认证，8 周`  
- `学习 Azure Functions，4 周`  
- `Azure DevOps，6 周`  
- `Azure 数据工程，10 周`  
- `微软安全基础，5 周`  
- `Power Platform，7 周`  
- `Azure AI 服务，12 周`  
- `云架构，9 周`

这些示例展示了应用在不同学习目标和时间范围内的灵活性。

## 参考资料

- [Chainlit 文档](https://docs.chainlit.io/)  
- [MCP 文档](https://github.com/MicrosoftDocs/mcp)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。因使用本翻译而产生的任何误解或误释，我们概不负责。