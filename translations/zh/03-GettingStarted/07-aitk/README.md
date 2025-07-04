<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T15:57:13+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "zh"
}
-->
# 在 Visual Studio Code 的 AI Toolkit 扩展中使用服务器

当你构建 AI 代理时，不仅仅是生成智能回复，更重要的是赋予代理执行操作的能力。这就是 Model Context Protocol (MCP) 的作用。MCP 让代理能够以一致的方式访问外部工具和服务。可以把它想象成给你的代理接入了一个真正能用的工具箱。

比如，你将代理连接到计算器 MCP 服务器。这样，代理只需接收类似“47 乘以 89 等于多少？”的提示，就能执行数学运算——无需硬编码逻辑或构建自定义 API。

## 概述

本课将介绍如何通过 Visual Studio Code 中的 [AI Toolkit](https://aka.ms/AIToolkit) 扩展，将计算器 MCP 服务器连接到代理，使代理能够通过自然语言执行加法、减法、乘法和除法等数学运算。

AI Toolkit 是 Visual Studio Code 的强大扩展，简化了代理开发流程。AI 工程师可以轻松地开发和测试生成式 AI 模型，无论是在本地还是云端。该扩展支持目前大多数主流生成式模型。

*注意*：AI Toolkit 目前支持 Python 和 TypeScript。

## 学习目标

完成本课后，你将能够：

- 通过 AI Toolkit 使用 MCP 服务器。
- 配置代理，使其能够发现并使用 MCP 服务器提供的工具。
- 通过自然语言调用 MCP 工具。

## 方法

我们需要从整体上这样进行：

- 创建代理并定义其系统提示。
- 创建带有计算器工具的 MCP 服务器。
- 将 Agent Builder 连接到 MCP 服务器。
- 通过自然语言测试代理调用工具。

很好，了解了流程后，让我们配置一个 AI 代理，通过 MCP 利用外部工具，提升其能力！

## 前提条件

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code 的 AI Toolkit](https://aka.ms/AIToolkit)

## 练习：使用服务器

在本练习中，你将使用 AI Toolkit 在 Visual Studio Code 内构建、运行并增强一个带有 MCP 服务器工具的 AI 代理。

### -0- 预备步骤，将 OpenAI GPT-4o 模型添加到 My Models

本练习使用 **GPT-4o** 模型。创建代理前，应先将该模型添加到 **My Models**。

![Visual Studio Code AI Toolkit 扩展中模型选择界面截图。标题为“Find the right model for your AI Solution”，副标题鼓励用户发现、测试和部署 AI 模型。下方“Popular Models”展示六个模型卡片：DeepSeek-R1（GitHub 托管）、OpenAI GPT-4o、OpenAI GPT-4.1、OpenAI o1、Phi 4 Mini（CPU - 小型，快速）和 DeepSeek-R1（Ollama 托管）。每个卡片包含“Add”添加模型和“Try in Playground”试用选项。](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.zh.png)

1. 从 **Activity Bar** 打开 **AI Toolkit** 扩展。
2. 在 **Catalog** 部分选择 **Models**，打开 **Model Catalog**。选择 **Models** 会在新编辑器标签页打开 **Model Catalog**。
3. 在 **Model Catalog** 的搜索栏输入 **OpenAI GPT-4o**。
4. 点击 **+ Add** 将模型添加到你的 **My Models** 列表。确保选择的是 **GitHub 托管** 的模型。
5. 在 **Activity Bar** 中确认 **OpenAI GPT-4o** 模型已出现在列表中。

### -1- 创建代理

**Agent (Prompt) Builder** 让你创建并定制自己的 AI 代理。本节将创建一个新代理，并为其分配模型以驱动对话。

![Visual Studio Code AI Toolkit 扩展中“Calculator Agent”构建界面截图。左侧面板选中模型为“OpenAI GPT-4o (via GitHub)”。系统提示为“你是一名大学数学教授”，用户提示为“用简单的语言向我解释傅里叶方程”。还有添加工具、启用 MCP Server 和选择结构化输出的按钮。底部有蓝色“Run”按钮。右侧面板“Get Started with Examples”列出三个示例代理：Web Developer（带 MCP Server）、Second-Grade Simplifier 和 Dream Interpreter，均附简短功能描述。](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.zh.png)

1. 从 **Activity Bar** 打开 **AI Toolkit** 扩展。
2. 在 **Tools** 部分选择 **Agent (Prompt) Builder**，会在新编辑器标签页打开该工具。
3. 点击 **+ New Agent** 按钮。扩展会通过 **Command Palette** 启动设置向导。
4. 输入名称 **Calculator Agent**，按回车确认。
5. 在 **Agent (Prompt) Builder** 中，**Model** 字段选择 **OpenAI GPT-4o (via GitHub)** 模型。

### -2- 为代理创建系统提示

代理搭建完成后，接下来定义其个性和用途。本节将使用 **Generate system prompt** 功能，描述代理的预期行为（这里是计算器代理），并让模型帮你生成系统提示。

![Visual Studio Code AI Toolkit 中“Calculator Agent”界面截图，弹出“Generate a prompt”窗口。窗口说明可通过填写基本信息生成提示模板，文本框内示例系统提示为：“你是一个乐于助人且高效的数学助手。当遇到基本算术问题时，你会给出正确答案。”下方有“Close”和“Generate”按钮。背景中可见代理配置，包括选中的模型“OpenAI GPT-4o (via GitHub)”及系统和用户提示字段。](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.zh.png)

1. 在 **Prompts** 部分，点击 **Generate system prompt** 按钮。该按钮会打开提示生成器，利用 AI 生成系统提示。
2. 在 **Generate a prompt** 窗口中输入：`You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. 点击 **Generate** 按钮。右下角会弹出通知，确认系统提示正在生成。生成完成后，提示会显示在 **Agent (Prompt) Builder** 的 **System prompt** 字段中。
4. 审核系统提示，必要时进行修改。

### -3- 创建 MCP 服务器

定义好代理的系统提示后，接下来为代理配备实用功能。本节将创建一个带有加、减、乘、除计算工具的计算器 MCP 服务器。该服务器使代理能够根据自然语言提示实时执行数学运算。

![Visual Studio Code AI Toolkit 扩展中 Calculator Agent 界面下方截图，显示“Tools”和“Structure output”可展开菜单，旁边有“Choose output format”下拉菜单，选中“text”。右侧有“+ MCP Server”按钮用于添加 Model Context Protocol 服务器。工具部分上方有图片图标占位符。](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.zh.png)

AI Toolkit 提供了模板，方便你创建 MCP 服务器。这里我们使用 Python 模板创建计算器 MCP 服务器。

*注意*：AI Toolkit 目前支持 Python 和 TypeScript。

1. 在 **Agent (Prompt) Builder** 的 **Tools** 部分，点击 **+ MCP Server** 按钮。扩展会通过 **Command Palette** 启动设置向导。
2. 选择 **+ Add Server**。
3. 选择 **Create a New MCP Server**。
4. 选择 **python-weather** 模板。
5. 选择 **Default folder** 保存 MCP 服务器模板。
6. 输入服务器名称：**Calculator**
7. 会打开一个新的 Visual Studio Code 窗口，选择 **Yes, I trust the authors**。
8. 在终端（**Terminal** > **New Terminal**）创建虚拟环境：`python -m venv .venv`
9. 激活虚拟环境：
    - Windows - `.venv\Scripts\activate`
    - macOS/Linux - `source venv/bin/activate`
10. 安装依赖：`pip install -e .[dev]`
11. 在 **Activity Bar** 的 **Explorer** 视图中，展开 **src** 目录，打开 **server.py** 文件。
12. 用以下代码替换 **server.py** 中的内容并保存：

    ```python
    """
    Sample MCP Calculator Server implementation in Python.

    
    This module demonstrates how to create a simple MCP server with calculator tools
    that can perform basic arithmetic operations (add, subtract, multiply, divide).
    """
    
    from mcp.server.fastmcp import FastMCP
    
    server = FastMCP("calculator")
    
    @server.tool()
    def add(a: float, b: float) -> float:
        """Add two numbers together and return the result."""
        return a + b
    
    @server.tool()
    def subtract(a: float, b: float) -> float:
        """Subtract b from a and return the result."""
        return a - b
    
    @server.tool()
    def multiply(a: float, b: float) -> float:
        """Multiply two numbers together and return the result."""
        return a * b
    
    @server.tool()
    def divide(a: float, b: float) -> float:
        """
        Divide a by b and return the result.
        
        Raises:
            ValueError: If b is zero
        """
        if b == 0:
            raise ValueError("Cannot divide by zero")
        return a / b
    ```

### -4- 使用计算器 MCP 服务器运行代理

代理拥有工具后，就可以使用它们了！本节将向代理提交提示，测试并验证代理是否调用了计算器 MCP 服务器中的合适工具。

![Visual Studio Code AI Toolkit 扩展中 Calculator Agent 界面截图。左侧“Tools”部分添加了名为 local-server-calculator_server 的 MCP 服务器，显示四个可用工具：add、subtract、multiply 和 divide。徽章显示四个工具已激活。下方是折叠的“Structure output”部分和蓝色“Run”按钮。右侧“Model Response”面板显示代理调用 multiply 和 subtract 工具，输入分别为 {"a": 3, "b": 25} 和 {"a": 75, "b": 20}。最终“Tool Response”为 75.0。底部有“View Code”按钮。](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.zh.png)

你将通过 **Agent Builder** 作为 MCP 客户端，在本地开发机上运行计算器 MCP 服务器。

1. 按 `F5` 启动 MCP 服务器调试。**Agent (Prompt) Builder** 会在新编辑器标签页打开。服务器状态可在终端查看。
2. 在 **Agent (Prompt) Builder** 的 **User prompt** 字段输入：`I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. 点击 **Run** 按钮生成代理回复。
4. 查看代理输出。模型应得出你支付了 **$55**。
5. 过程解析：
    - 代理选择了 **multiply** 和 **subtract** 工具辅助计算。
    - 为 **multiply** 工具分配了相应的 `a` 和 `b` 值。
    - 为 **subtract** 工具分配了相应的 `a` 和 `b` 值。
    - 各工具的响应显示在对应的 **Tool Response** 中。
    - 模型的最终输出显示在 **Model Response** 中。
6. 你可以提交更多提示继续测试代理。点击 **User prompt** 字段，替换现有提示即可。
7. 测试完成后，可在终端通过 **CTRL/CMD+C** 停止服务器。

## 任务

尝试在你的 **server.py** 文件中添加一个新工具（例如：返回数字的平方根）。提交需要代理调用你新工具（或现有工具）的额外提示。记得重启服务器以加载新增工具。

## 解决方案

[解决方案](./solution/README.md)

## 关键要点

本章的关键要点如下：

- AI Toolkit 扩展是一个优秀的客户端，支持你使用 MCP 服务器及其工具。
- 你可以向 MCP 服务器添加新工具，扩展代理能力以满足不断变化的需求。
- AI Toolkit 包含模板（如 Python MCP 服务器模板），简化自定义工具的创建。

## 额外资源

- [AI Toolkit 文档](https://aka.ms/AIToolkit/doc)

## 后续内容
- 下一步：[测试与调试](../08-testing/README.md)

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能包含错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们不承担任何责任。