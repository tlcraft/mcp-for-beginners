<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1980763f2a545ca6648363bf5757b5a",
  "translation_date": "2025-06-13T02:30:08+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "sl"
}
-->
# Consuming a server from the AI Toolkit extension for Visual Studio Code

When building an AI agent, it’s not just about generating smart replies; it’s also about giving your agent the ability to take action. That’s where the Model Context Protocol (MCP) comes in. MCP makes it simple for agents to access external tools and services in a consistent way. Think of it as plugging your agent into a toolbox it can *actually* use.

For example, if you connect an agent to your calculator MCP server, your agent can perform math operations just by receiving a prompt like “What’s 47 times 89?”—no need to hardcode logic or build custom APIs.

## Overview

This lesson shows how to connect a calculator MCP server to an agent using the [AI Toolkit](https://aka.ms/AIToolkit) extension in Visual Studio Code, allowing your agent to perform math operations like addition, subtraction, multiplication, and division through natural language.

AI Toolkit is a powerful Visual Studio Code extension that simplifies agent development. AI Engineers can easily build AI applications by developing and testing generative AI models—locally or in the cloud. The extension supports most popular generative models available today.

*Note*: The AI Toolkit currently supports Python and TypeScript.

## Learning Objectives

By the end of this lesson, you will be able to:

- Consume an MCP server via the AI Toolkit.
- Configure an agent to discover and use tools provided by the MCP server.
- Use MCP tools through natural language.

## Approach

Here’s the high-level approach:

- Create an agent and define its system prompt.
- Create an MCP server with calculator tools.
- Connect the Agent Builder to the MCP server.
- Test the agent's tool usage via natural language.

Great! Now that we understand the flow, let's configure an AI agent to leverage external tools through MCP, enhancing its capabilities!

## Prerequisites

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## Exercise: Consuming a server

In this exercise, you will build, run, and improve an AI agent with tools from an MCP server inside Visual Studio Code using the AI Toolkit.

### -0- Prestep, add the OpenAI GPT-4o model to My Models

This exercise uses the **GPT-4o** model. Add this model to **My Models** before creating the agent.

![Screenshot of a model selection interface in Visual Studio Code's AI Toolkit extension. The heading reads "Find the right model for your AI Solution" with a subtitle encouraging users to discover, test, and deploy AI models. Below, under “Popular Models,” six model cards are displayed: DeepSeek-R1 (GitHub-hosted), OpenAI GPT-4o, OpenAI GPT-4.1, OpenAI o1, Phi 4 Mini (CPU - Small, Fast), and DeepSeek-R1 (Ollama-hosted). Each card includes options to “Add” the model or “Try in Playground](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.sl.png)

1. Open the **AI Toolkit** extension from the **Activity Bar**.
2. In the **Catalog** section, select **Models** to open the **Model Catalog**. This opens the **Model Catalog** in a new editor tab.
3. In the **Model Catalog** search bar, type **OpenAI GPT-4o**.
4. Click **+ Add** to add the model to your **My Models** list. Make sure to select the model **Hosted by GitHub**.
5. In the **Activity Bar**, verify that the **OpenAI GPT-4o** model appears in the list.

### -1- Create an agent

The **Agent (Prompt) Builder** lets you create and customize your own AI-powered agents. Here, you’ll create a new agent and assign a model to power its conversation.

![Screenshot of the "Calculator Agent" builder interface in the AI Toolkit extension for Visual Studio Code. On the left panel, the model selected is "OpenAI GPT-4o (via GitHub)." A system prompt reads "You are a professor in university teaching math," and the user prompt says, "Explain to me the Fourier equation in simple terms." Additional options include buttons for adding tools, enabling MCP Server, and selecting structured output. A blue “Run” button is at the bottom. On the right panel, under "Get Started with Examples," three sample agents are listed: Web Developer (with MCP Server, Second-Grade Simplifier, and Dream Interpreter, each with brief descriptions of their functions.](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.sl.png)

1. Open the **AI Toolkit** extension from the **Activity Bar**.
2. In the **Tools** section, select **Agent (Prompt) Builder**. This opens the **Agent (Prompt) Builder** in a new editor tab.
3. Click the **+ New Agent** button. The extension will launch a setup wizard via the **Command Palette**.
4. Enter the name **Calculator Agent** and press **Enter**.
5. In the **Agent (Prompt) Builder**, for the **Model** field, select the **OpenAI GPT-4o (via GitHub)** model.

### -2- Create a system prompt for the agent

With the agent created, it’s time to define its personality and purpose. Here, you’ll use the **Generate system prompt** feature to describe the agent’s intended behavior—in this case, a calculator agent—and have the model generate the system prompt for you.

![Screenshot of the "Calculator Agent" interface in the AI Toolkit for Visual Studio Code with a modal window open titled "Generate a prompt." The modal explains that a prompt template can be generated by sharing basic details and includes a text box with the sample system prompt: "You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result." Below the text box are "Close" and "Generate" buttons. In the background, part of the agent configuration is visible, including the selected model "OpenAI GPT-4o (via GitHub)" and fields for system and user prompts.](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.sl.png)

1. In the **Prompts** section, click the **Generate system prompt** button. This opens the prompt builder, which uses AI to create a system prompt for the agent.
2. In the **Generate a prompt** window, enter the following: `You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. Click **Generate**. A notification will appear confirming the system prompt is being generated. When finished, the prompt will appear in the **System prompt** field of the **Agent (Prompt) Builder**.
4. Review the **System prompt** and adjust if needed.

### -3- Create a MCP server

Now that your agent’s system prompt is set—defining its behavior—it’s time to give the agent practical abilities. In this step, you’ll create a calculator MCP server with tools for addition, subtraction, multiplication, and division. This server will let your agent perform live math operations in response to natural language prompts.

!["Screenshot of the lower section of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. It shows expandable menus for “Tools” and “Structure output,” along with a dropdown menu labeled “Choose output format” set to “text.” To the right, there is a button labeled “+ MCP Server” for adding a Model Context Protocol server. An image icon placeholder is shown above the Tools section.](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.sl.png)

AI Toolkit includes templates to help you create your own MCP server. We’ll use the Python template to create the calculator MCP server.

*Note*: The AI Toolkit currently supports Python and TypeScript.

1. In the **Tools** section of the **Agent (Prompt) Builder**, click the **+ MCP Server** button. The extension will launch a setup wizard via the **Command Palette**.
2. Select **+ Add Server**.
3. Select **Create a New MCP Server**.
4. Select **python-weather** as the template.
5. Choose **Default folder** to save the MCP server template.
6. Enter the server name: **Calculator**
7. A new Visual Studio Code window will open. Select **Yes, I trust the authors**.
8. In the terminal (**Terminal** > **New Terminal**), create a virtual environment: `python -m venv .venv`
9. Activate the virtual environment in the terminal:
    - Windows - `.venv\Scripts\activate`
    - macOS/Linux - `source venv/bin/activate`
10. Install the dependencies: `pip install -e .[dev]`
11. In the **Explorer** view of the **Activity Bar**, expand the **src** directory and open **server.py**.
12. Replace the code in **server.py** with the following and save:

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

### -4- Run the agent with the calculator MCP server

Now that your agent has tools, it’s time to use them! Here, you’ll send prompts to the agent to check if it correctly uses the calculator MCP server’s tools.

![Screenshot of the Calculator Agent interface in the AI Toolkit extension for Visual Studio Code. On the left panel, under “Tools,” an MCP server named local-server-calculator_server is added, showing four available tools: add, subtract, multiply, and divide. A badge shows that four tools are active. Below is a collapsed “Structure output” section and a blue “Run” button. On the right panel, under “Model Response,” the agent invokes the multiply and subtract tools with inputs {"a": 3, "b": 25} and {"a": 75, "b": 20} respectively. The final “Tool Response” is shown as 75.0. A “View Code” button appears at the bottom.](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.sl.png)

You will run the calculator MCP server locally via the **Agent Builder**, which acts as the MCP client.

1. Press `F5` to start the server.
2. Enter a prompt like: `I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
    - The values for the **subtract** tool’s parameters `"a"` and `"b"` will be assigned accordingly.
    - Each tool’s response will be shown in the **Tool Response**.
    - The final answer will appear in the **Model Response**.
3. Submit more prompts to further test the agent. You can edit the prompt in the **User prompt** field by clicking it and typing a new prompt.
4. When finished testing, stop the server by pressing **CTRL/CMD+C** in the terminal.

## Assignment

Try adding another tool entry to your **server.py** file (for example, return the square root of a number). Then submit prompts that require the agent to use your new tool (or existing tools). Don’t forget to restart the server to load your changes.

## Solution

[Solution](./solution/README.md)

## Key Takeaways

Here’s what to remember from this chapter:

- The AI Toolkit extension is a great client for consuming MCP Servers and their tools.
- You can add new tools to MCP servers, expanding your agent’s capabilities as needed.
- The AI Toolkit provides templates (like Python MCP server templates) to simplify creating custom tools.

## Additional Resources

- [AI Toolkit docs](https://aka.ms/AIToolkit/doc)

## What's Next
- Next: [Testing & Debugging](/03-GettingStarted/08-testing/README.md)

**Omejitev odgovornosti**:  
Ta dokument je bil preveden z uporabo storitve za prevajanje z umetno inteligenco [Co-op Translator](https://github.com/Azure/co-op-translator). Čeprav si prizadevamo za natančnost, upoštevajte, da lahko avtomatizirani prevodi vsebujejo napake ali netočnosti. Izvirni dokument v njegovem izvirnem jeziku naj velja za avtoritativni vir. Za ključne informacije priporočamo strokovni človeški prevod. Za morebitna nesporazume ali napačne interpretacije, ki izhajajo iz uporabe tega prevoda, ne prevzemamo odgovornosti.