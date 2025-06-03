<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "af6cee6052e751674c1d9022a4b204e6",
  "translation_date": "2025-06-03T14:27:41+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "hk"
}
-->
# 從 Visual Studio Code 嘅 AI Toolkit 擴充功能使用伺服器

當你建立 AI 代理時，唔只係要產生智能回應，仲要令代理有能力執行行動。Model Context Protocol (MCP) 就係用嚟做呢件事嘅。MCP 令代理可以用統一嘅方式去存取外部工具同服務。可以想像成將代理插入一個佢真係可以用嘅工具箱。

例如你連接代理去你嘅計算機 MCP 伺服器，咁代理就可以直接透過收到「47 乘 89 幾多？」呢啲提示嚟做數學運算，唔使自己寫死邏輯或者整自訂 API。

## 概覽

本課程會教你點樣用 Visual Studio Code 嘅 [AI Toolkit](https://aka.ms/AIToolkit) 擴充功能，將計算機 MCP 伺服器連接到代理，令代理可以用自然語言執行加、減、乘、除等數學運算。

AI Toolkit 係一個強大嘅 Visual Studio Code 擴充功能，簡化咗代理開發。AI 工程師可以輕鬆喺本地或雲端開發同測試生成式 AI 模型。呢個擴充功能支援市面上大部分主流生成模型。

*備註*：AI Toolkit 目前支援 Python 同 TypeScript。

## 學習目標

完成本課程後，你將可以：

- 用 AI Toolkit 消費 MCP 伺服器。
- 配置代理設定，令佢可以發現同使用 MCP 伺服器提供嘅工具。
- 透過自然語言使用 MCP 工具。

## 方法

我哋嘅大致做法係：

- 建立代理並定義系統提示。
- 建立帶有計算工具嘅 MCP 伺服器。
- 將 Agent Builder 連接到 MCP 伺服器。
- 用自然語言測試代理調用工具。

好啦，明白咗流程後，開始配置 AI 代理，透過 MCP 使用外部工具，提升佢嘅能力！

## 先決條件

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## 練習：使用伺服器

呢個練習會教你喺 Visual Studio Code 用 AI Toolkit 建立、執行同增強一個帶有 MCP 伺服器工具嘅 AI 代理。

### -0- 預備步驟，將 OpenAI GPT-4o 模型加到 My Models

練習用嘅係 **GPT-4o** 模型。你要先將模型加到 **My Models**，先可以建立代理。

![Visual Studio Code AI Toolkit 擴充功能嘅模型選擇介面截圖。標題係「搵啱你 AI 解決方案嘅模型」，副標題鼓勵用戶發掘、測試同部署 AI 模型。下方「熱門模型」顯示六個模型卡：DeepSeek-R1 (GitHub-hosted)、OpenAI GPT-4o、OpenAI GPT-4.1、OpenAI o1、Phi 4 Mini (CPU - 細、快)、DeepSeek-R1 (Ollama-hosted)。每張卡都有「Add」同「Try in Playground」選項。](../../../../translated_images/aitk-model-catalog.c0c66f0d9ac0ee73c1d21b9207db99e914ef9dd52fced6f226c2b1f537e2c447.hk.png)

1. 喺 **Activity Bar** 開啟 **AI Toolkit** 擴充功能。
1. 喺 **Catalog** 區域揀 **Models**，會喺新嘅編輯器分頁打開 **Model Catalog**。
1. 喺 **Model Catalog** 嘅搜尋欄輸入 **OpenAI GPT-4o**。
1. 按 **+ Add** 將模型加到你嘅 **My Models** 清單。記住揀 GitHub 托管嘅模型。
1. 喺 **Activity Bar** 確認清單有顯示 **OpenAI GPT-4o**。

### -1- 建立代理

**Agent (Prompt) Builder** 令你可以建立同自訂你嘅 AI 代理。呢部分會建立新代理，並指定一個模型做對話引擎。

![Visual Studio Code AI Toolkit 擴充功能嘅「Calculator Agent」建構介面截圖。左側面板揀咗「OpenAI GPT-4o (via GitHub)」模型。系統提示寫住「你係大學教授，教數學」，用戶提示係「用簡單嘅方式解釋傅立葉方程」。另外有新增工具、啟用 MCP Server、選擇結構化輸出嘅按鈕。底部有藍色「Run」按鈕。右側面板列出三個範例代理：Web Developer（帶 MCP Server）、Second-Grade Simplifier、Dream Interpreter，各有簡短功能描述。](../../../../translated_images/aitk-agent-builder.fb7df60f7923b4d8ba839662bf6d7647e843c01b57256e1e9adecb46a64d3408.hk.png)

1. 喺 **Activity Bar** 開啟 **AI Toolkit** 擴充功能。
1. 喺 **Tools** 區域揀 **Agent (Prompt) Builder**，會喺新分頁開啟。
1. 按 **+ New Agent** 按鈕。擴充功能會喺 **Command Palette** 開啟設定精靈。
1. 輸入名稱 **Calculator Agent**，按 **Enter**。
1. 喺 **Agent (Prompt) Builder** 嘅 **Model** 欄揀 **OpenAI GPT-4o (via GitHub)**。

### -2- 為代理建立系統提示

代理架構好之後，要定義佢嘅個性同目標。呢部分用 **Generate system prompt** 功能，描述代理行為（今次係計算機代理），由模型幫你寫系統提示。

![Visual Studio Code AI Toolkit 嘅「Calculator Agent」介面截圖，開咗一個叫「Generate a prompt」嘅視窗。視窗解釋可以透過分享基本資料產生提示模板，並有一個文字框示範系統提示：「你係一個有用同高效嘅數學助手。當收到基本算術問題時，你會回應正確結果。」底下有「Close」同「Generate」按鈕。背景可見代理設定，包括揀咗嘅模型「OpenAI GPT-4o (via GitHub)」同系統提示、用戶提示欄。](../../../../translated_images/aitk-generate-prompt.0d4292407c15282bf714e327f5d3d833389324004135727ef28adc22dbbb4e8f.hk.png)

1. 喺 **Prompts** 部分，按 **Generate system prompt** 按鈕。會打開提示建構器，利用 AI 幫你產生系統提示。
1. 喺 **Generate a prompt** 視窗入面，輸入以下：`You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. 按 **Generate**。畫面右下會有通知話系統提示緊生成。生成完成後，系統提示會出現喺 **Agent (Prompt) Builder** 嘅 **System prompt** 欄。
1. 檢查系統提示，必要時修改。

### -3- 建立 MCP 伺服器

定義咗代理嘅系統提示（指引佢嘅行為同回應）之後，就可以畀代理實際嘅功能。呢部分會建立一個計算機 MCP 伺服器，帶有加、減、乘、除工具，令代理可以即時用自然語言做數學運算。

![Visual Studio Code AI Toolkit 擴充功能「Calculator Agent」介面下方截圖。顯示可展開嘅「Tools」同「Structure output」選單，旁邊有「Choose output format」下拉選單設為「text」。右邊有「+ MCP Server」按鈕用來新增 Model Context Protocol 伺服器。工具區上方有圖像佔位符。](../../../../translated_images/aitk-add-mcp-server.9b158809336d87e8076eb5954846040a7370c88046639a09e766398c8855c3d3.hk.png)

AI Toolkit 內建模板，方便你建立 MCP 伺服器。今次用 Python 模板建立計算機 MCP 伺服器。

*備註*：AI Toolkit 目前支援 Python 同 TypeScript。

1. 喺 **Agent (Prompt) Builder** 嘅 **Tools** 區，按 **+ MCP Server**。擴充功能會喺 **Command Palette** 開啟設定精靈。
1. 揀 **+ Add Server**。
1. 揀 **Create a New MCP Server**。
1. 揀 **python-weather** 模板。
1. 揀 **Default folder** 儲存 MCP 伺服器模板。
1. 輸入伺服器名稱：**Calculator**
1. 會開新嘅 Visual Studio Code 視窗。揀 **Yes, I trust the authors**。
1. 用終端機（**Terminal** > **New Terminal**）建立虛擬環境：`python -m venv .venv`
1. 用終端機啟動虛擬環境：
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. 用終端機安裝依賴：`pip install -e .[dev]`
1. 喺 **Activity Bar** 嘅 **Explorer** 視圖展開 **src** 目錄，揀開 **server.py**。
1. 將 **server.py** 嘅程式碼換成以下內容，並儲存：

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

### -4- 用計算機 MCP 伺服器執行代理

代理有咗工具，就可以用佢哋啦！呢部分會提交提示測試代理，驗證佢係咪會用計算機 MCP 伺服器嘅合適工具。

![Visual Studio Code AI Toolkit 擴充功能「Calculator Agent」介面截圖。左側「Tools」顯示新增咗一個叫 local-server-calculator_server 嘅 MCP 伺服器，有四個可用工具：add、subtract、multiply、divide。標籤顯示四個工具啟用中。下方有收合嘅「Structure output」區域同藍色「Run」按鈕。右側「Model Response」面板顯示代理調用 multiply 同 subtract 工具，輸入分別係 {"a": 3, "b": 25} 同 {"a": 75, "b": 20}。最終「Tool Response」結果係 75.0。底部有「View Code」按鈕。](../../../../translated_images/aitk-agent-response-with-tools.0f0da2c6eef5eb3f5b7592d6d056449aa8aaa42a3ab0b0c2f14269b3049cfdb5.hk.png)

你會喺本地開發機用 **Agent Builder** 作為 MCP 客戶端，執行計算機 MCP 伺服器。

1. 按 `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `我買咗 3 件貨，每件 $25，然後用咗 $20 折扣。我實際付咗幾多錢？`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b`，呢啲係分配畀 **subtract** 工具嘅值。
    - 每個工具嘅回應會顯示喺相應嘅 **Tool Response**。
    - 模型嘅最終輸出會顯示喺最終嘅 **Model Response**。
1. 你可以提交更多提示嚟進一步測試代理。可以喺 **User prompt** 欄點入，再改寫現有提示。
1. 測試完成後，可以喺 **terminal** 入 **CTRL/CMD+C** 停止伺服器。

## 作業

試喺你嘅 **server.py** 文件加入額外嘅工具（例如：返回數字嘅平方根）。提交需要代理用到你新增工具（或現有工具）嘅提示。記得重啟伺服器，先會載入新增工具。

## 解答

[Solution](./solution/README.md)

## 重要重點

本章嘅重點係：

- AI Toolkit 擴充功能係一個好用嘅客戶端，令你可以使用 MCP 伺服器同佢嘅工具。
- 你可以新增工具到 MCP 伺服器，擴充代理功能，滿足不斷變化嘅需求。
- AI Toolkit 包含模板（例如 Python MCP 伺服器模板），簡化自訂工具嘅建立。

## 額外資源

- [AI Toolkit 文件](https://aka.ms/AIToolkit/doc)

## 下一步

下一課：[Lesson 4 Practical Implementation](/04-PracticalImplementation/README.md)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應被視為權威來源。對於重要資料，建議使用專業人工翻譯。我哋對因使用本翻譯而引致嘅任何誤解或誤釋概不負責。