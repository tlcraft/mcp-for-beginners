<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "787440926586cd064b0899fd1c514f52",
  "translation_date": "2025-07-14T07:00:53+00:00",
  "source_file": "10-StreamliningAIWorkflowsBuildingAnMCPServerWithAIToolkit/README.md",
  "language_code": "zh"
}
-->
# 精简AI工作流程：使用AI Toolkit构建MCP服务器

[![MCP Version](https://img.shields.io/badge/MCP-1.9.3-blue.svg)](https://modelcontextprotocol.io/)
[![Python](https://img.shields.io/badge/Python-3.10+-green.svg)](https://python.org)
[![VS Code](https://img.shields.io/badge/VS%20Code-Latest-orange.svg)](https://code.visualstudio.com/)

![logo](../../../translated_images/logo.ec93918ec338dadde1715c8aaf118079e0ed0502e9efdfcc84d6a0f4a9a70ae8.zh.png)

## 🎯 概览

欢迎参加**Model Context Protocol (MCP) 研讨会**！本次全面的实操研讨会结合了两项前沿技术，助力革新AI应用开发：

- **🔗 Model Context Protocol (MCP)**：实现AI工具无缝集成的开放标准
- **🛠️ AI Toolkit for Visual Studio Code (AITK)**：微软强大的AI开发扩展

### 🎓 你将学到什么

完成本研讨会后，你将掌握构建智能应用的技巧，实现AI模型与现实工具和服务的桥接。从自动化测试到定制API集成，你将获得解决复杂业务难题的实用技能。

## 🏗️ 技术栈

### 🔌 Model Context Protocol (MCP)

MCP是AI领域的“USB-C”——连接AI模型与外部工具和数据源的通用标准。

**✨ 主要特点：**
- 🔄 **标准化集成**：AI工具连接的统一接口
- 🏛️ **灵活架构**：支持本地和远程服务器，通过stdio/SSE传输
- 🧰 **丰富生态**：协议内集成工具、提示和资源
- 🔒 **企业级保障**：内置安全性和可靠性

**🎯 MCP的重要性：**
正如USB-C解决了线缆混乱，MCP简化了AI集成的复杂性。一个协议，无限可能。

### 🤖 AI Toolkit for Visual Studio Code (AITK)

微软旗舰级AI开发扩展，将VS Code打造成AI开发利器。

**🚀 核心功能：**
- 📦 **模型目录**：访问Azure AI、GitHub、Hugging Face、Ollama等模型
- ⚡ **本地推理**：ONNX优化的CPU/GPU/NPU执行
- 🏗️ **Agent Builder**：可视化AI代理开发，支持MCP集成
- 🎭 **多模态支持**：文本、视觉及结构化输出

**💡 开发优势：**
- 零配置模型部署
- 可视化提示工程
- 实时测试沙盒
- 无缝集成MCP服务器

## 📚 学习路径

### [🚀 模块1：AI Toolkit基础](./lab1/README.md)
**时长**：15分钟
- 🛠️ 安装并配置VS Code的AI Toolkit
- 🗂️ 探索模型目录（涵盖GitHub、ONNX、OpenAI、Anthropic、Google的100+模型）
- 🎮 掌握交互式沙盒，实现实时模型测试
- 🤖 使用Agent Builder构建你的第一个AI代理
- 📊 利用内置指标评估模型性能（F1、相关性、相似度、一致性）
- ⚡ 学习批处理和多模态支持功能

**🎯 学习成果**：创建功能完善的AI代理，全面理解AITK能力

### [🌐 模块2：MCP与AI Toolkit基础](./lab2/README.md)
**时长**：20分钟
- 🧠 掌握Model Context Protocol (MCP)架构与概念
- 🌐 探索微软的MCP服务器生态系统
- 🤖 使用Playwright MCP服务器构建浏览器自动化代理
- 🔧 将MCP服务器集成到AI Toolkit Agent Builder中
- 📊 配置并测试代理中的MCP工具
- 🚀 导出并部署基于MCP的代理用于生产环境

**🎯 学习成果**：部署一个通过MCP连接外部工具的AI代理

### [🔧 模块3：AI Toolkit高级MCP开发](./lab3/README.md)
**时长**：20分钟
- 💻 使用AI Toolkit创建自定义MCP服务器
- 🐍 配置并使用最新的MCP Python SDK（v1.9.3）
- 🔍 设置并使用MCP Inspector进行调试
- 🛠️ 构建具备专业调试流程的天气MCP服务器
- 🧪 在Agent Builder和Inspector环境中调试MCP服务器

**🎯 学习成果**：使用现代工具开发并调试自定义MCP服务器

### [🐙 模块4：实战MCP开发 - 自定义GitHub克隆服务器](./lab4/README.md)
**时长**：30分钟
- 🏗️ 构建面向开发流程的真实GitHub克隆MCP服务器
- 🔄 实现智能仓库克隆，包含校验和错误处理
- 📁 创建智能目录管理及VS Code集成
- 🤖 使用GitHub Copilot代理模式结合自定义MCP工具
- 🛡️ 应用生产级可靠性和跨平台兼容性

**🎯 学习成果**：部署生产级MCP服务器，优化真实开发流程

## 💡 真实应用与影响

### 🏢 企业应用场景

#### 🔄 DevOps自动化
用智能自动化改造开发流程：
- **智能仓库管理**：AI驱动的代码审查与合并决策
- **智能CI/CD**：基于代码变更的自动化流水线优化
- **问题分流**：自动化缺陷分类与指派

#### 🧪 质量保障革新
用AI提升测试效率：
- **智能测试生成**：自动创建全面测试套件
- **视觉回归测试**：AI驱动的UI变更检测
- **性能监控**：主动识别并解决问题

#### 📊 数据管道智能化
构建更智能的数据处理流程：
- **自适应ETL流程**：自动优化数据转换
- **异常检测**：实时监控数据质量
- **智能路由**：智能管理数据流向

#### 🎧 客户体验提升
打造卓越客户互动：
- **上下文感知支持**：AI代理访问客户历史
- **主动问题解决**：预测性客户服务
- **多渠道整合**：跨平台统一AI体验

## 🛠️ 前提条件与环境搭建

### 💻 系统要求

| 组件 | 要求 | 备注 |
|-----------|-------------|-------|
| **操作系统** | Windows 10+，macOS 10.15+，Linux | 任何现代操作系统 |
| **Visual Studio Code** | 最新稳定版 | AITK必备 |
| **Node.js** | v18.0+及npm | 用于MCP服务器开发 |
| **Python** | 3.10+ | 可选，用于Python MCP服务器 |
| **内存** | 最少8GB RAM | 本地模型推荐16GB |

### 🔧 开发环境

#### 推荐VS Code扩展
- **AI Toolkit** (ms-windows-ai-studio.windows-ai-studio)
- **Python** (ms-python.python)
- **Python Debugger** (ms-python.debugpy)
- **GitHub Copilot** (GitHub.copilot) - 可选但有帮助

#### 可选工具
- **uv**：现代Python包管理器
- **MCP Inspector**：MCP服务器的可视化调试工具
- **Playwright**：用于网页自动化示例

## 🎖️ 学习成果与认证路径

### 🏆 技能掌握清单

完成本研讨会后，你将掌握：

#### 🎯 核心能力
- [ ] **MCP协议精通**：深入理解架构与实现模式
- [ ] **AITK熟练使用**：快速开发的专家级技能
- [ ] **自定义服务器开发**：构建、部署及维护生产级MCP服务器
- [ ] **工具集成能力**：无缝连接AI与现有开发流程
- [ ] **问题解决应用**：将所学技能应用于实际业务挑战

#### 🔧 技术技能
- [ ] 在VS Code中安装配置AI Toolkit
- [ ] 设计并实现自定义MCP服务器
- [ ] 将GitHub模型集成到MCP架构
- [ ] 使用Playwright构建自动化测试流程
- [ ] 部署生产环境AI代理
- [ ] 调试并优化MCP服务器性能

#### 🚀 高级能力
- [ ] 架构企业级AI集成方案
- [ ] 实施AI应用安全最佳实践
- [ ] 设计可扩展的MCP服务器架构
- [ ] 创建特定领域的定制工具链
- [ ] 指导他人进行AI原生开发

## 📖 额外资源
- [MCP规范](https://modelcontextprotocol.io/docs)
- [AI Toolkit GitHub仓库](https://github.com/microsoft/vscode-ai-toolkit)
- [MCP服务器示例合集](https://github.com/modelcontextprotocol/servers)
- [最佳实践指南](https://modelcontextprotocol.io/docs/best-practices)

---

**🚀 准备好革新你的AI开发流程了吗？**

让我们携手用MCP和AI Toolkit共创智能应用的未来！

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。