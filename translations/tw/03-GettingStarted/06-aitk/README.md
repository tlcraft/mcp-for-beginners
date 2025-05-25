<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:17:12+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "tw"
}
-->
# 使用 Visual Studio Code 的 AI Toolkit 擴展來消耗伺服器

當您在構建 AI 代理時，不僅僅是生成智能響應；還需要賦予代理採取行動的能力。這就是模型上下文協議 (MCP) 的作用。MCP 使代理能夠以一致的方式訪問外部工具和服務。可以將其視為將您的代理插入到它可以*真正*使用的工具箱中。

假設您將代理連接到計算器 MCP 伺服器。突然間，您的代理可以通過接收像“47乘以89是多少？”這樣的提示來執行數學運算——無需硬編碼邏輯或構建自定義 API。

## 概述

本課程涵蓋如何在 Visual Studio Code 中使用 [AI Toolkit](https://aka.ms/AIToolkit) 擴展將計算器 MCP 伺服器連接到代理，使您的代理能夠通過自然語言執行加法、減法、乘法和除法等數學運算。

AI Toolkit 是 Visual Studio Code 的一個強大擴展，簡化了代理開發。AI 工程師可以通過開發和測試生成式 AI 模型——無論是在本地還是在雲端——輕鬆構建 AI 應用。該擴展支持當今大多數主要的生成模型。

*注意*: AI Toolkit 目前支持 Python 和 TypeScript。

## 學習目標

完成本課程後，您將能夠：

- 通過 AI Toolkit 消耗 MCP 伺服器。
- 配置代理設置，使其能夠發現和利用 MCP 伺服器提供的工具。
- 通過自然語言使用 MCP 工具。

## 方法

以下是我們需要如何在高層次上進行的方法：

- 創建代理並定義其系統提示。
- 創建具有計算器工具的 MCP 伺服器。
- 將 Agent Builder 連接到 MCP 伺服器。
- 通過自然語言測試代理的工具調用。

很好，現在我們了解了流程，讓我們配置 AI 代理以通過 MCP 利用外部工具，增強其能力！

## 先決條件

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code 的 AI Toolkit](https://aka.ms/AIToolkit)

## 練習：消耗伺服器

在此練習中，您將使用 AI Toolkit 在 Visual Studio Code 中構建、運行並增強具有 MCP 伺服器工具的 AI 代理。

### -0- 前置步驟，將 OpenAI GPT-4o 模型添加到我的模型

練習利用 **GPT-4o** 模型。應在創建代理之前將模型添加到 **我的模型** 中。

1. 從 **活動欄** 打開 **AI Toolkit** 擴展。
1. 在 **目錄** 部分，選擇 **模型** 以打開 **模型目錄**。選擇 **模型** 會在新的編輯器選項卡中打開 **模型目錄**。
1. 在 **模型目錄** 搜索欄中輸入 **OpenAI GPT-4o**。
1. 點擊 **+ 添加** 將模型添加到您的 **我的模型** 列表中。確保您選擇了 **由 GitHub 託管** 的模型。
1. 在 **活動欄** 中，確認 **OpenAI GPT-4o** 模型出現在列表中。

### -1- 創建代理

**Agent (Prompt) Builder** 使您能夠創建和自定義自己的 AI 驅動代理。在本節中，您將創建一個新代理並分配模型以驅動對話。

1. 從 **活動欄** 打開 **AI Toolkit** 擴展。
1. 在 **工具** 部分，選擇 **Agent (Prompt) Builder**。選擇 **Agent (Prompt) Builder** 會在新的編輯器選項卡中打開 **Agent (Prompt) Builder**。
1. 點擊 **+ 新建生成器** 按鈕。擴展將通過 **命令調色板** 啟動設置向導。
1. 輸入名稱 **計算器代理** 並按 **Enter**。
1. 在 **Agent (Prompt) Builder** 中，對於 **模型** 字段，選擇 **OpenAI GPT-4o (via GitHub)** 模型。

### -2- 為代理創建系統提示

隨著代理的框架建立，是時候定義其個性和目的了。在本節中，您將使用 **生成系統提示** 功能來描述代理的預期行為——在這種情況下，是一個計算器代理——並讓模型為您撰寫系統提示。

1. 在 **提示** 部分，點擊 **生成系統提示** 按鈕。此按鈕在提示生成器中打開，利用 AI 為代理生成系統提示。
1. 在 **生成提示** 窗口中，輸入以下內容：`You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. 點擊 **生成** 按鈕。右下角會出現通知，確認正在生成系統提示。提示生成完成後，提示將出現在 **Agent (Prompt) Builder** 的 **系統提示** 字段中。
1. 查看 **系統提示** 並在必要時進行修改。

### -3- 創建 MCP 伺服器

現在您已經定義了代理的系統提示——指導其行為和響應——是時候賦予代理實際能力了。在本節中，您將創建一個計算器 MCP 伺服器，提供執行加法、減法、乘法和除法計算的工具。該伺服器將使您的代理能夠在自然語言提示下執行實時數學運算。

AI Toolkit 配備了模板以便於創建自己的 MCP 伺服器。我們將使用 Python 模板來創建計算器 MCP 伺服器。

*注意*: AI Toolkit 目前支持 Python 和 TypeScript。

1. 在 **Agent (Prompt) Builder** 的 **工具** 部分，點擊 **+ MCP 伺服器** 按鈕。擴展將通過 **命令調色板** 啟動設置向導。
1. 選擇 **+ 添加伺服器**。
1. 選擇 **創建新的 MCP 伺服器**。
1. 選擇 **python-weather** 作為模板。
1. 選擇 **默認文件夾** 保存 MCP 伺服器模板。
1. 為伺服器輸入以下名稱：**計算器**
1. 新的 Visual Studio Code 窗口將打開。選擇 **是，我信任作者**。
1. 使用終端 (**終端** > **新終端**)，創建虛擬環境：`python -m venv .venv`
1. 使用終端，激活虛擬環境：
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. 使用終端，安裝依賴項：`pip install -e .[dev]`
1. 在 **活動欄** 的 **資源管理器** 視圖中，展開 **src** 目錄並選擇 **server.py** 以在編輯器中打開文件。
1. 用以下代碼替換 **server.py** 文件中的代碼並保存：

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

### -4- 使用計算器 MCP 伺服器運行代理

現在您的代理有工具了，是時候使用它們了！在本節中，您將向代理提交提示以測試和驗證代理是否利用了計算器 MCP 伺服器中的適當工具。

您將通過 **Agent Builder** 作為 MCP 客戶端在本地開發機器上運行計算器 MCP 伺服器。

1. 按 `F5` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `我買了3件商品，每件價格25美元，然後使用了20美元的折扣。我支付了多少？`
1. Click the **Run** button to generate the agent's response.
1. Review the agent output. The model should conclude that you paid **$55**.
1. Here's a breakdown of what should occur:
    - The agent selects the **multiply** and **substract** tools to aid in the calculation.
    - The respective `a` and `b` values are assigned for the **multiply** tool.
    - The respective `a` and `b` 值被分配給 **subtract** 工具。
    - 每個工具的響應在各自的 **工具響應** 中提供。
    - 模型的最終輸出在最終 **模型響應** 中提供。
1. 提交額外的提示以進一步測試代理。您可以通過點擊 **用戶提示** 字段並替換現有提示來修改現有提示。
1. 完成代理測試後，您可以通過在 **終端** 中輸入 **CTRL/CMD+C** 來停止伺服器。

## 作業

嘗試向您的 **server.py** 文件添加額外的工具項目（例如：返回數字的平方根）。提交額外的提示，要求代理利用您的新工具（或現有工具）。請確保重新啟動伺服器以加載新添加的工具。

## 解決方案

[解決方案](./solution/README.md)

## 關鍵要點

本章的要點如下：

- AI Toolkit 擴展是一個很好的客戶端，可以讓您消耗 MCP 伺服器及其工具。
- 您可以向 MCP 伺服器添加新工具，擴展代理的能力以滿足不斷變化的需求。
- AI Toolkit 包含模板（例如 Python MCP 伺服器模板），以簡化自定義工具的創建。

## 其他資源

- [AI Toolkit 文檔](https://aka.ms/AIToolkit/doc)

## 下一步

下一步：[第4課 實際應用](/04-PracticalImplementation/README.md)

**免責聲明**：
本文件使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保準確性，但請注意，自動翻譯可能包含錯誤或不精確之處。應將原始語言的文件視為權威來源。對於關鍵信息，建議進行專業人工翻譯。我們對因使用本翻譯而產生的任何誤解或誤讀不承擔責任。