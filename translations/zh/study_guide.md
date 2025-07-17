<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5f321ea583cf087a94e47ee74c62b504",
  "translation_date": "2025-07-17T09:41:06+00:00",
  "source_file": "study_guide.md",
  "language_code": "zh"
}
-->
# Model Context Protocol (MCP) 初学者学习指南

本学习指南概述了“Model Context Protocol (MCP) 初学者”课程的仓库结构和内容。请使用本指南高效浏览仓库，充分利用现有资源。

## 仓库概览

Model Context Protocol (MCP) 是一个用于 AI 模型与客户端应用交互的标准化框架。最初由 Anthropic 创建，现由更广泛的 MCP 社区通过官方 GitHub 组织维护。本仓库提供了涵盖 C#、Java、JavaScript、Python 和 TypeScript 的实战代码示例的完整课程，面向 AI 开发者、系统架构师和软件工程师。

## 课程视觉地图

```mermaid
mindmap
  root((MCP for Beginners))
    00. Introduction
      ::icon(fa fa-book)
      (Protocol Overview)
      (Standardization)
      (Use Cases)
    01. Core Concepts
      ::icon(fa fa-puzzle-piece)
      (Client-Server Architecture)
      (Protocol Components)
      (Messaging Patterns)
    02. Security
      ::icon(fa fa-shield)
      (Threat Models)
      (Best Practices)
      (Auth Strategies)
    03. Getting Started
      ::icon(fa fa-rocket)
      (First Server)
      (Client)
      (LLM Client)
      (VS Code Integration)
      (SSE Server)
      (HTTP Streaming)
      (AI Toolkit)
      (Testing)
      (Deployment)
    04. Practical Implementation
      ::icon(fa fa-code)
      (SDKs)
      (Testing/Debugging)
      (Prompt Templates)
      (Sample Projects)
    05. Advanced Topics
      ::icon(fa fa-graduation-cap)
      (Context Engineering)
      (Foundry Integration)
      (Multi-modal AI)
      (OAuth2 Demo)
      (Real-time Search)
      (Streaming)
      (Root Contexts)
      (Routing)
      (Sampling)
      (Scaling)
      (Security)
      (Entra ID)
      (Web Search)
      
    06. Community
      ::icon(fa fa-users)
      (Code Contributions)
      (Documentation)
      (MCP Clients)
      (MCP Servers)
      (Image Generation)
    07. Early Adoption
      ::icon(fa fa-lightbulb)
      (Real-world Examples)
      (Deployment Stories)
      (Future Roadmap)
    08. Best Practices
      ::icon(fa fa-check)
      (Performance)
      (Fault Tolerance)
      (Resilience)
    09. Case Studies
      ::icon(fa fa-file-text)
      (API Management)
      (Travel Agent)
      (Azure DevOps)
      (Documentation MCP)
    10. Hands-on Workshop
      ::icon(fa fa-laptop)
      (AI Toolkit Integration)
      (Custom Server Development)
      (Production Deployment)
```

## 仓库结构

仓库分为十个主要部分，每部分聚焦 MCP 的不同方面：

1. **介绍 (00-Introduction/)**
   - Model Context Protocol 概述
   - AI 流水线中标准化的重要性
   - 实际应用场景与优势

2. **核心概念 (01-CoreConcepts/)**
   - 客户端-服务器架构
   - 关键协议组件
   - MCP 中的消息传递模式

3. **安全 (02-Security/)**
   - 基于 MCP 系统的安全威胁
   - 安全实现的最佳实践
   - 认证与授权策略

4. **入门指南 (03-GettingStarted/)**
   - 环境搭建与配置
   - 创建基础 MCP 服务器和客户端
   - 与现有应用集成
   - 包含以下章节：
     - 第一个服务器实现
     - 客户端开发
     - LLM 客户端集成
     - VS Code 集成
     - 服务器推送事件 (SSE) 服务器
     - HTTP 流式传输
     - AI 工具包集成
     - 测试策略
     - 部署指南

5. **实战实现 (04-PracticalImplementation/)**
   - 跨语言 SDK 使用
   - 调试、测试与验证技巧
   - 设计可复用的提示模板和工作流
   - 示例项目及实现案例

6. **高级主题 (05-AdvancedTopics/)**
   - 上下文工程技术
   - Foundry 代理集成
   - 多模态 AI 工作流
   - OAuth2 认证演示
   - 实时搜索功能
   - 实时流式传输
   - 根上下文实现
   - 路由策略
   - 采样技术
   - 扩展方案
   - 安全考量
   - Entra ID 安全集成
   - 网络搜索集成

7. **社区贡献 (06-CommunityContributions/)**
   - 如何贡献代码和文档
   - 通过 GitHub 协作
   - 社区驱动的改进与反馈
   - 使用多种 MCP 客户端（Claude Desktop、Cline、VSCode）
   - 使用流行的 MCP 服务器，包括图像生成

8. **早期采用经验 (07-LessonsfromEarlyAdoption/)**
   - 真实案例与成功故事
   - MCP 解决方案的构建与部署
   - 发展趋势与未来路线图

9. **最佳实践 (08-BestPractices/)**
   - 性能调优与优化
   - 设计容错的 MCP 系统
   - 测试与弹性策略

10. **案例研究 (09-CaseStudy/)**
    - 案例研究：Azure API 管理集成
    - 案例研究：旅行代理实现
    - 案例研究：Azure DevOps 与 YouTube 集成
    - 详细文档的实现示例

11. **实操工作坊 (10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/)**
    - 结合 MCP 与 AI 工具包的综合实操工作坊
    - 构建连接 AI 模型与现实工具的智能应用
    - 涵盖基础知识、自定义服务器开发及生产部署策略的实用模块
    - 基于实验室的学习方式，提供逐步指导

## 额外资源

仓库还包含支持资源：

- **Images 文件夹**：课程中使用的图表和插图
- **翻译**：多语言支持，包含文档的自动翻译
- **官方 MCP 资源**：
  - [MCP Documentation](https://modelcontextprotocol.io/)
  - [MCP Specification](https://spec.modelcontextprotocol.io/)
  - [MCP GitHub Repository](https://github.com/modelcontextprotocol)

## 如何使用本仓库

1. **按顺序学习**：依次阅读章节（00 到 10），获得系统化学习体验。
2. **语言专项**：如果关注特定编程语言，可浏览对应语言的示例目录。
3. **实战入门**：从“入门指南”开始，搭建环境并创建第一个 MCP 服务器和客户端。
4. **深入探索**：掌握基础后，深入高级主题，拓展知识面。
5. **社区互动**：通过 GitHub 讨论和 Discord 频道加入 MCP 社区，连接专家和开发者。

## MCP 客户端和工具

课程涵盖多种 MCP 客户端和工具：

1. **官方客户端**：
   - Visual Studio Code
   - MCP 在 Visual Studio Code 中的集成
   - Claude Desktop
   - Claude 在 VSCode 中的集成
   - Claude API

2. **社区客户端**：
   - Cline（终端版）
   - Cursor（代码编辑器）
   - ChatMCP
   - Windsurf

3. **MCP 管理工具**：
   - MCP CLI
   - MCP Manager
   - MCP Linker
   - MCP Router

## 流行的 MCP 服务器

仓库介绍了多种 MCP 服务器，包括：

1. **官方参考服务器**：
   - Filesystem
   - Fetch
   - Memory
   - Sequential Thinking

2. **图像生成**：
   - Azure OpenAI DALL-E 3
   - Stable Diffusion WebUI
   - Replicate

3. **开发工具**：
   - Git MCP
   - Terminal Control
   - Code Assistant

4. **专用服务器**：
   - Salesforce
   - Microsoft Teams
   - Jira & Confluence

## 贡献指南

欢迎社区贡献代码和文档。请参阅社区贡献章节，了解如何有效参与 MCP 生态系统。

## 更新日志

| 日期 | 变更内容 |
|------|---------|
| 2025年7月16日 | - 更新仓库结构以反映当前内容<br>- 新增 MCP 客户端和工具章节<br>- 新增流行 MCP 服务器章节<br>- 更新视觉课程地图，涵盖所有当前主题<br>- 丰富高级主题章节，涵盖所有专业领域<br>- 更新案例研究，反映实际示例<br>- 明确 MCP 由 Anthropic 创建 |
| 2025年6月11日 | - 学习指南初版创建<br>- 添加视觉课程地图<br>- 概述仓库结构<br>- 包含示例项目和额外资源 |

---

*本学习指南于 2025 年 7 月 16 日更新，内容反映该日期的仓库概况。仓库内容可能在此日期之后有所变动。*

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始语言的文档应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。