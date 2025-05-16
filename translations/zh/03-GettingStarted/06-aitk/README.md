<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-16T15:30:23+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "zh"
}
-->
# 在 Visual Studio Code 的 AI Toolkit 扩展中使用服务器

当你构建 AI 代理时，不仅仅是生成智能回复，更重要的是赋予代理执行操作的能力。这就是 Model Context Protocol (MCP) 的作用。MCP 让代理能够以一致的方式访问外部工具和服务。可以把它想象成给你的代理接入一个它*真正*能用的工具箱。

比如你将代理连接到计算器 MCP 服务器。这样，代理只需接收类似“47 乘以 89 等于多少？”的提示，就能进行数学运算——无需硬编码逻辑或构建自定义 API。

## 概述

本课介绍如何使用 Visual Studio Code 中的 [AI Toolkit](https://aka.ms/AIToolkit) 扩展，将计算器 MCP 服务器连接到代理，使代理能够通过自然语言执行加法、减法、乘法和除法等数学运算。

AI Toolkit 是 Visual Studio Code 的强大扩展，简化了代理开发。AI 工程师可以轻松构建 AI 应用，开发和测试生成式 AI 模型——无论是在本地还是云端。该扩展支持当前大多数主流生成式模型。

*注*：AI Toolkit 当前支持 Python 和 TypeScript。

## 学习目标

完成本课后，你将能够：

- 通过 AI Toolkit 使用 MCP 服务器。
- 配置代理，使其能够发现并利用 MCP 服务器提供的工具。
- 通过自然语言调用 MCP 工具。

## 方法

我们的大致步骤如下：

- 创建代理并定义其系统提示。
- 创建带有计算工具的 MCP 服务器。
- 将代理构建器连接到 MCP 服务器。
- 通过自然语言测试代理调用工具的能力。

很好，了解流程后，让我们配置一个 AI 代理，通过 MCP 利用外部工具，增强其功能！

## 先决条件

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code 的 AI Toolkit](https://aka.ms/AIToolkit)

## 练习：使用服务器

在本练习中，你将使用 AI Toolkit 在 Visual Studio Code 内构建、运行并增强一个带有 MCP 服务器工具的 AI 代理。

### -0- 预备步骤，将 OpenAI GPT-4o 模型添加到“我的模型”

本练习使用 **GPT-4o** 模型。请在创建代理前，将该模型添加到 **我的模型** 中。

![Visual Studio Code 的 AI Toolkit 扩展中模型选择界面截图。标题为“为你的 AI 解决方案找到合适的模型”，副标题鼓励用户发现、测试和部署 AI 模型。下方“热门模型”展示六个模型卡片：DeepSeek-R1（GitHub 托管）、OpenAI GPT-4o、OpenAI GPT-4.1、OpenAI o1、Phi 4 Mini（CPU - 小巧快速）和 DeepSeek-R1（Ollama 托管）。每个卡片包含“添加”或“在游乐场试用”按钮。](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.zh.png)

1. 从 **活动栏** 打开 **AI Toolkit** 扩展。
2. 在 **目录** 部分选择 **模型**，打开 **模型目录**。选择后，模型目录将在新的编辑器标签页中打开。
3. 在 **模型目录** 的搜索栏输入 **OpenAI GPT-4o**。
4. 点击 **+ 添加**，将该模型添加到你的 **我的模型** 列表。确认选择的是 **GitHub 托管** 的模型。
5. 在 **活动栏** 中确认 **OpenAI GPT-4o** 模型已出现在列表中。

### -1- 创建代理

**Agent (Prompt) Builder** 允许你创建并定制自己的 AI 代理。本节中，你将创建一个新代理并指定一个模型来驱动对话。

![Visual Studio Code 的 AI Toolkit 扩展中“Calculator Agent”构建界面截图。左侧面板选中模型为“OpenAI GPT-4o (via GitHub)”。系统提示为“你是一名大学数学教授”，用户提示为“用简单的语言向我解释傅里叶方程”。界面包含添加工具、启用 MCP 服务器、选择结构化输出等按钮。底部有蓝色“运行”按钮。右侧面板“示例入门”列出三个示例代理：Web Developer（带 MCP 服务器）、Second-Grade Simplifier 和 Dream Interpreter，均附简短功能描述。](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.zh.png)

1. 从 **活动栏** 打开 **AI Toolkit** 扩展。
2. 在 **工具** 部分选择 **Agent (Prompt) Builder**，该操作将在新编辑器标签页打开该构建器。
3. 点击 **+ 新建构建器** 按钮。扩展将通过 **命令面板** 启动设置向导。
4. 输入名称 **Calculator Agent**，按 **Enter**。
5. 在 **Agent (Prompt) Builder** 的 **模型** 字段中，选择 **OpenAI GPT-4o (via GitHub)** 模型。

### -2- 为代理创建系统提示

代理框架搭建完成后，接下来定义它的个性和目标。本节将使用 **生成系统提示** 功能描述代理的预期行为（这里是计算器代理），并让模型为你生成系统提示。

![Visual Studio Code 的 AI Toolkit 中“Calculator Agent”界面截图，弹出名为“生成提示”的模态窗口。窗口说明可以通过填写基本信息生成提示模板，文本框中示例系统提示为：“你是一个乐于助人且高效的数学助手。当遇到基本算术问题时，你会给出正确结果。”下方有“关闭”和“生成”按钮。背景中可见代理配置部分，包括已选模型“OpenAI GPT-4o (via GitHub)”及系统和用户提示字段。](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.zh.png)

1. 在 **提示** 部分，点击 **生成系统提示** 按钮。该按钮将打开提示生成器，利用 AI 为代理生成系统提示。
2. 在 **生成提示** 窗口中输入：`You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. 点击 **生成**。屏幕右下角会出现通知，确认系统提示正在生成。生成完成后，提示会显示在 **Agent (Prompt) Builder** 的 **系统提示** 字段中。
4. 审核 **系统提示**，如有需要可进行修改。

### -3- 创建 MCP 服务器

定义好代理的系统提示（指导其行为和回复）后，接下来为代理配备实用功能。本节将创建一个带有加、减、乘、除计算工具的计算器 MCP 服务器。该服务器使代理能够实时响应自然语言提示，执行数学运算。

![Visual Studio Code 的 AI Toolkit 扩展中“Calculator Agent”界面下方截图。显示“工具”和“结构化输出”可展开菜单，旁边有一个标签为“选择输出格式”的下拉菜单，当前选中“文本”。右侧有一个“+ MCP 服务器”按钮，用于添加 Model Context Protocol 服务器。工具区上方显示一个图片图标占位符。](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.zh.png)

AI Toolkit 提供模板，方便创建 MCP 服务器。这里我们使用 Python 模板创建计算器 MCP 服务器。

*注*：AI Toolkit 当前支持 Python 和 TypeScript。

1. 在 **Agent (Prompt) Builder)** 的 **工具** 部分，点击 **+ MCP 服务器** 按钮。扩展将通过 **命令面板** 启动设置向导。
2. 选择 **+ 添加服务器**。
3. 选择 **创建新的 MCP 服务器**。
4. 选择 **python-weather** 作为模板。
5. 选择 **默认文件夹** 保存 MCP 服务器模板。
6. 输入服务器名称：**Calculator**
7. 将打开一个新的 Visual Studio Code 窗口。选择 **是，我信任作者**。
8. 使用终端（**终端** > **新建终端**）创建虚拟环境：`python -m venv .venv`
9. 使用终端激活虚拟环境：
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. 使用终端安装依赖：`pip install -e .[dev]`
11. 在 **活动栏** 的 **资源管理器** 视图中，展开 **src** 目录，打开 **server.py** 文件。
12. 将 **server.py** 文件中的代码替换为以下内容并保存：

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

代理配备好工具后，就可以使用了！本节将向代理提交提示，测试并验证代理是否正确调用了计算器 MCP 服务器中的相应工具。

![Visual Studio Code 的 AI Toolkit 扩展中“Calculator Agent”界面截图。左侧“工具”下添加了名为 local-server-calculator_server 的 MCP 服务器，显示四个可用工具：add、subtract、multiply 和 divide，右侧显示四个工具均已激活的徽章。下方为折叠的“结构化输出”部分和蓝色“运行”按钮。右侧“模型响应”区域显示代理调用了 multiply 和 subtract 工具，输入分别为 {"a": 3, "b": 25} 和 {"a": 75, "b": 20}。最终“工具响应”为 75.0。底部有“查看代码”按钮。](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.zh.png)

你将通过 **Agent Builder** 作为 MCP 客户端，在本地开发机上运行计算器 MCP 服务器。

1. 按 `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `我买了3件商品，每件25美元，然后用了20美元的折扣。我实际支付了多少钱？`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b`，这些值被赋给了 **subtract** 工具。
    - 每个工具的响应显示在对应的 **工具响应** 中。
    - 模型的最终输出显示在最终的 **模型响应** 中。
2. 继续提交其他提示以进一步测试代理。你可以点击 **用户提示** 字段，修改并替换现有提示。
3. 测试完成后，可通过 **终端** 输入 **CTRL/CMD+C** 停止服务器。

## 任务

尝试在你的 **server.py** 文件中添加一个新的工具条目（例如：返回一个数字的平方根）。提交需要代理调用你新增工具（或现有工具）的提示。添加新工具后，记得重启服务器以加载新工具。

## 解决方案

[解决方案](./solution/README.md)

## 关键要点

本章的关键要点如下：

- AI Toolkit 扩展是一个优秀的客户端，支持你使用 MCP 服务器及其工具。
- 你可以向 MCP 服务器添加新工具，扩展代理的能力以满足不断变化的需求。
- AI Toolkit 包含模板（如 Python MCP 服务器模板），简化自定义工具的创建。

## 额外资源

- [AI Toolkit 文档](https://aka.ms/AIToolkit/doc)

## 下一步

下一课：[第4课 实践应用](/04-PracticalImplementation/README.md)

**免责声明**：  
本文件由AI翻译服务[Co-op Translator](https://github.com/Azure/co-op-translator)翻译而成。尽管我们力求准确，但请注意，自动翻译可能存在错误或不准确之处。原始文件的原文版本应被视为权威来源。对于关键信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。