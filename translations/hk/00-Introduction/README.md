<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "02301140adbd807ecf0f17720fa307bc",
  "translation_date": "2025-05-17T05:55:07+00:00",
  "source_file": "00-Introduction/README.md",
  "language_code": "hk"
}
-->
# 模型上下文协议 (MCP) 简介：为何它对可扩展 AI 应用至关重要

生成式 AI 应用是一个很大的进步，因为它们通常允许用户使用自然语言提示与应用互动。然而，随着更多时间和资源被投入到这些应用中，你会希望确保能够轻松整合功能和资源，以便于扩展，使你的应用能够支持多种模型及其复杂性。简而言之，构建生成式 AI 应用很容易开始，但随着其增长和变得复杂，你需要开始定义一个架构，并很可能需要依赖一个标准来确保你的应用以一致的方式构建。这就是 MCP 出现的原因，提供一个标准来组织事情。

---

## **🔍 什么是模型上下文协议 (MCP)?**

**模型上下文协议 (MCP)** 是一个**开放、标准化的接口**，允许大型语言模型 (LLMs) 与外部工具、API 和数据源无缝互动。它提供了一种一致的架构，增强 AI 模型在其训练数据之外的功能，使其更智能、可扩展和响应更快。

---

## **🎯 标准化在 AI 中为何重要**

随着生成式 AI 应用变得更复杂，采用确保**可扩展性、扩展性**和**可维护性**的标准至关重要。MCP 通过以下方式满足这些需求：

- 统一模型与工具的集成
- 减少脆弱的、一次性定制解决方案
- 允许多个模型在一个生态系统中共存

---

## **📚 学习目标**

阅读本文后，你将能够：

- 定义**模型上下文协议 (MCP)**及其用例
- 理解 MCP 如何标准化模型与工具的通信
- 识别 MCP 架构的核心组件
- 探索 MCP 在企业和开发环境中的实际应用

---

## **💡 为什么模型上下文协议 (MCP) 是一个游戏改变者**

### **🔗 MCP 解决了 AI 互动中的碎片化问题**

在 MCP 之前，集成模型与工具需要：

- 每对工具模型的定制代码
- 每个供应商的非标准化 API
- 因更新导致的频繁中断
- 随着工具增加而导致的差劲的可扩展性

### **✅ MCP 标准化的好处**

| **好处**                  | **描述**                                                                        |
|--------------------------|--------------------------------------------------------------------------------|
| 互操作性                 | LLMs 能够无缝地与不同供应商的工具协作                                           |
| 一致性                   | 在平台和工具之间实现统一的行为                                                   |
| 可重用性                 | 一次构建的工具可以在多个项目和系统中使用                                         |
| 加速开发                 | 通过使用标准化的即插即用接口减少开发时间                                        |

---

## **🧱 MCP 高级架构概述**

MCP 遵循一个**客户端-服务器模型**，其中：

- **MCP 主机**运行 AI 模型
- **MCP 客户端**发起请求
- **MCP 服务器**提供上下文、工具和能力

### **关键组件：**

- **资源** – 模型的静态或动态数据  
- **提示** – 预定义的工作流程用于指导生成  
- **工具** – 可执行功能如搜索、计算  
- **采样** – 通过递归互动实现代理行为

---

## MCP 服务器如何工作

MCP 服务器的操作方式如下：

- **请求流程**： 
    1. MCP 客户端向在 MCP 主机中运行的 AI 模型发送请求。
    2. AI 模型识别何时需要外部工具或数据。
    3. 模型使用标准化协议与 MCP 服务器通信。

- **MCP 服务器功能**：
    - 工具注册：维护可用工具及其功能的目录。
    - 认证：验证工具访问权限。
    - 请求处理器：处理来自模型的工具请求。
    - 响应格式化器：以模型可理解的格式构建工具输出。

- **工具执行**： 
    - 服务器将请求路由到适当的外部工具
    - 工具执行其专门功能（搜索、计算、数据库查询等）
    - 结果以一致的格式返回给模型。

- **响应完成**： 
    - AI 模型将工具输出整合到其响应中。
    - 最终响应发送回客户端应用。

```mermaid
graph TD
    A[AI Model in MCP Host] <-->|MCP Protocol| B[MCP Server]
    B <-->|Tool Interface| C[Tool 1: Web Search]
    B <-->|Tool Interface| D[Tool 2: Calculator]
    B <-->|Tool Interface| E[Tool 3: Database Access]
    B <-->|Tool Interface| F[Tool 4: File System]
    
    Client[MCP Client/Application] -->|Sends Request| A
    A -->|Returns Response| Client
    
    subgraph "MCP Server Components"
        B
        G[Tool Registry]
        H[Authentication]
        I[Request Handler]
        J[Response Formatter]
    end
    
    B <--> G
    B <--> H
    B <--> I
    B <--> J
    
    style A fill:#f9d5e5,stroke:#333,stroke-width:2px
    style B fill:#eeeeee,stroke:#333,stroke-width:2px
    style Client fill:#d5e8f9,stroke:#333,stroke-width:2px
    style C fill:#c2f0c2,stroke:#333,stroke-width:1px
    style D fill:#c2f0c2,stroke:#333,stroke-width:1px
    style E fill:#c2f0c2,stroke:#333,stroke-width:1px
    style F fill:#c2f0c2,stroke:#333,stroke-width:1px    
```

## 👨‍💻 如何构建 MCP 服务器（附示例）

MCP 服务器允许你通过提供数据和功能来扩展 LLM 的能力。

准备好尝试了吗？以下是用不同语言创建简单 MCP 服务器的示例：

- **Python 示例**: https://github.com/modelcontextprotocol/python-sdk

- **TypeScript 示例**: https://github.com/modelcontextprotocol/typescript-sdk

- **Java 示例**: https://github.com/modelcontextprotocol/java-sdk

- **C#/.NET 示例**: https://github.com/modelcontextprotocol/csharp-sdk

## 🌍 MCP 的实际应用案例

MCP 通过扩展 AI 能力启用广泛的应用：

| **应用**                    | **描述**                                                                        |
|----------------------------|--------------------------------------------------------------------------------|
| 企业数据集成               | 将 LLMs 连接到数据库、CRM 或内部工具                                            |
| 代理 AI 系统               | 通过工具访问和决策工作流程启用自主代理                                          |
| 多模态应用                 | 在单一统一 AI 应用中结合文本、图像和音频工具                                   |
| 实时数据集成               | 将实时数据引入 AI 互动以获得更准确、当前的输出                                  |

### 🧠 MCP = AI 互动的通用标准

模型上下文协议 (MCP) 作为 AI 互动的通用标准，就像 USB-C 标准化设备的物理连接一样。在 AI 世界中，MCP 提供了一致的接口，允许模型（客户端）与外部工具和数据提供者（服务器）无缝集成。这消除了为每个 API 或数据源制定不同、定制协议的需求。

在 MCP 下，符合 MCP 的工具（称为 MCP 服务器）遵循统一标准。这些服务器可以列出它们提供的工具或动作，并在 AI 代理请求时执行这些动作。支持 MCP 的 AI 代理平台能够通过此标准协议发现服务器提供的工具并调用它们。

### 💡 促进知识访问

除了提供工具，MCP 还促进了知识访问。它使应用能够通过将大型语言模型 (LLMs) 链接到各种数据源来提供上下文。例如，MCP 服务器可能代表公司的文档库，允许代理按需检索相关信息。另一个服务器可以处理特定动作，如发送电子邮件或更新记录。从代理的角度来看，这些只是它可以使用的工具——一些工具返回数据（知识上下文），而其他工具执行动作。MCP 有效地管理这两者。

连接到 MCP 服务器的代理通过标准格式自动学习服务器的可用能力和可访问的数据。这种标准化实现了动态工具的可用性。例如，将新的 MCP 服务器添加到代理的系统中，使其功能立即可用，而无需进一步定制代理的指令。

这种简化的集成与美人鱼图中描绘的流程一致，服务器提供工具和知识，确保跨系统的无缝协作。

### 👉 示例：可扩展的代理解决方案

```mermaid
graph TD
    User -->|Prompt| LLM
    LLM -->|Response| User
    LLM -->|MCP| ServerA
    LLM -->|MCP| ServerB
    ServerA -->|Universal connector| ServerB
    ServerA --> KnowledgeA
    ServerA --> ToolsA
    ServerB --> KnowledgeB
    ServerB --> ToolsB

    subgraph Server A
        KnowledgeA[Knowledge]
        ToolsA[Tools]
    end

    subgraph Server B
        KnowledgeB[Knowledge]
        ToolsB[Tools]
    end
```

## 🔐 MCP 的实际好处

使用 MCP 的一些实际好处：

- **新鲜度**：模型可以访问其训练数据之外的最新信息
- **能力扩展**：模型可以利用专门工具来完成其未训练的任务
- **减少幻觉**：外部数据源提供事实基础
- **隐私**：敏感数据可以保持在安全环境中，而不是嵌入在提示中

## 📌 关键要点

以下是使用 MCP 的关键要点：

- **MCP** 标准化了 AI 模型与工具和数据的互动方式
- 促进**扩展性、一致性和互操作性**
- MCP 帮助**减少开发时间、提高可靠性和扩展模型能力**
- 客户端-服务器架构**启用灵活、可扩展的 AI 应用**

## 🧠 练习

考虑一个你感兴趣构建的 AI 应用。

- 哪些**外部工具或数据**可以增强其能力？
- MCP 如何使集成**更简单和更可靠？**

## 其他资源

- [MCP GitHub 仓库](https://github.com/modelcontextprotocol)

## 接下来

下一步：[第一章：核心概念](/01-CoreConcepts/README.md)

**免責聲明**：

此文件是使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)翻譯的。雖然我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。應以原始語言的文件為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們對使用此翻譯引起的任何誤解或誤讀不承擔責任。