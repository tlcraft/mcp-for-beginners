<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "a3cbadbf632058aa59a523ac659aa1df",
  "translation_date": "2025-05-17T12:16:48+00:00",
  "source_file": "03-GettingStarted/06-aitk/README.md",
  "language_code": "hk"
}
-->
# 使用 Visual Studio Code 的 AI Toolkit 擴展來消耗伺服器

當你正在構建 AI 代理時，不僅僅是生成智能回應；還需要賦予你的代理採取行動的能力。這就是模型上下文協議（MCP）發揮作用的地方。MCP 使代理能夠以一致的方式訪問外部工具和服務。想像一下，將你的代理連接到一個它能真正使用的工具箱。

假設你將代理連接到你的計算器 MCP 伺服器。突然間，你的代理可以通過接收像“47 乘以 89 是多少？”這樣的提示來執行數學運算——不需要硬編碼邏輯或構建自定義 API。

## 概述

本課程介紹如何使用 Visual Studio Code 中的 [AI Toolkit](https://aka.ms/AIToolkit) 擴展將計算器 MCP 伺服器連接到代理，從而使你的代理能夠通過自然語言執行加法、減法、乘法和除法等數學運算。

AI Toolkit 是一個強大的 Visual Studio Code 擴展，簡化了代理的開發。AI 工程師可以輕鬆構建 AI 應用程序，通過開發和測試生成式 AI 模型——無論是在本地還是在雲端。該擴展支持當今大多數主要的生成模型。

*注意*：AI Toolkit 目前支持 Python 和 TypeScript。

## 學習目標

完成本課程後，你將能夠：

- 通過 AI Toolkit 消耗 MCP 伺服器。
- 配置代理配置以使其能夠發現和利用 MCP 伺服器提供的工具。
- 通過自然語言利用 MCP 工具。

## 方法

這是我們需要在高層次上採取的方法：

- 創建代理並定義其系統提示。
- 創建具有計算器工具的 MCP 伺服器。
- 將代理構建器連接到 MCP 伺服器。
- 通過自然語言測試代理的工具調用。

很好，現在我們了解了流程，讓我們配置一個 AI 代理以通過 MCP 利用外部工具，增強其能力！

## 先決條件

- [Visual Studio Code](https://code.visualstudio.com/)
- [Visual Studio Code 的 AI Toolkit](https://aka.ms/AIToolkit)

## 練習：消耗伺服器

在此練習中，你將使用 AI Toolkit 在 Visual Studio Code 中構建、運行和增強具有 MCP 伺服器工具的 AI 代理。

### -0- 預備步驟，將 OpenAI GPT-4o 模型添加到我的模型中

練習利用 **GPT-4o** 模型。模型應在創建代理之前添加到 **我的模型** 中。

1. 從 **活動欄** 打開 **AI Toolkit** 擴展。
1. 在 **目錄** 部分中，選擇 **模型** 以打開 **模型目錄**。選擇 **模型** 將在新的編輯器選項卡中打開 **模型目錄**。
1. 在 **模型目錄** 搜索欄中輸入 **OpenAI GPT-4o**。
1. 點擊 **+ 添加** 將模型添加到你的 **我的模型** 列表中。確保你已選擇由 **GitHub 托管** 的模型。
1. 在 **活動欄** 中，確認 **OpenAI GPT-4o** 模型出現在列表中。

### -1- 創建代理

**代理（提示）構建器** 使你能夠創建和自定義自己的 AI 驅動代理。在本節中，你將創建一個新代理並分配一個模型來推動對話。

1. 從 **活動欄** 打開 **AI Toolkit** 擴展。
1. 在 **工具** 部分中，選擇 **代理（提示）構建器**。選擇 **代理（提示）構建器** 將在新的編輯器選項卡中打開 **代理（提示）構建器**。
1. 點擊 **+ 新構建器** 按鈕。擴展將通過 **命令面板** 啟動設置向導。
1. 輸入名稱 **計算器代理** 並按 **Enter**。
1. 在 **代理（提示）構建器** 中，對於 **模型** 欄位，選擇 **OpenAI GPT-4o（通過 GitHub）** 模型。

### -2- 為代理創建系統提示

有了代理的框架，現在是定義其個性和目的的時候了。在本節中，你將使用 **生成系統提示** 功能來描述代理的預期行為——在這種情況下是一個計算器代理——並讓模型為你編寫系統提示。

1. 對於 **提示** 部分，點擊 **生成系統提示** 按鈕。此按鈕在提示構建器中打開，利用 AI 為代理生成系統提示。
1. 在 **生成提示** 窗口中，輸入以下內容：`You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
1. 點擊 **生成** 按鈕。右下角會出現通知，確認正在生成系統提示。提示生成完成後，提示將顯示在 **代理（提示）構建器** 的 **系統提示** 欄位中。
1. 查看 **系統提示** 並在必要時進行修改。

### -3- 創建 MCP 伺服器

現在你已經定義了代理的系統提示——引導其行為和回應——是時候賦予代理實際能力了。在本節中，你將創建一個具有加法、減法、乘法和除法計算工具的計算器 MCP 伺服器。此伺服器將使你的代理能夠響應自然語言提示進行實時數學運算。

AI Toolkit 配備了創建自己的 MCP 伺服器的模板。我們將使用 Python 模板創建計算器 MCP 伺服器。

*注意*：AI Toolkit 目前支持 Python 和 TypeScript。

1. 在 **代理（提示）構建器** 的 **工具** 部分中，點擊 **+ MCP 伺服器** 按鈕。擴展將通過 **命令面板** 啟動設置向導。
1. 選擇 **+ 添加伺服器**。
1. 選擇 **創建新的 MCP 伺服器**。
1. 選擇 **python-weather** 作為模板。
1. 選擇 **默認文件夾** 保存 MCP 伺服器模板。
1. 輸入以下伺服器名稱：**計算器**
1. 將打開新的 Visual Studio Code 窗口。選擇 **是，我信任作者**。
1. 使用終端（**終端** > **新終端**），創建虛擬環境：`python -m venv .venv`
1. 使用終端，激活虛擬環境：
    1. Windows - `.venv\Scripts\activate`
    1. macOS/Linux - `source venv/bin/activate`
1. 使用終端，安裝依賴項：`pip install -e .[dev]`
1. 在 **活動欄** 的 **資源管理器** 視圖中，展開 **src** 目錄並選擇 **server.py** 以在編輯器中打開文件。
1. 用以下內容替換 **server.py** 文件中的代碼並保存：

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

現在你的代理有工具了，是時候使用它們了！在本節中，你將向代理提交提示以測試和驗證代理是否利用了計算器 MCP 伺服器中的適當工具。

你將在本地開發機器上通過 **代理構建器** 作為 MCP 客戶端運行計算器 MCP 伺服器。

1. 按 `F5` 來啟動代理並運行 MCP 伺服器。
1. 在 **代理（提示）構建器** 中，確認計算器 MCP 伺服器的工具已被添加。
1. 在 **用戶提示** 欄位中輸入以下內容：` to start debugging the MCP server. The **Agent (Prompt) Builder** will open in a new editor tab. The status of the server is visible in the terminal.
1. In the **User prompt** field of the **Agent (Prompt) Builder**, enter the following prompt: `
1. 確認代理調用了計算器 MCP 伺服器中的適當工具。工具輸入和工具回應將顯示在 **工具回應** 欄位中。
1. 提交額外的提示以進一步測試代理。你可以通過點擊欄位並替換現有提示來修改 **用戶提示** 欄位中的現有提示。
1. 完成代理測試後，你可以通過在 **終端** 中輸入 **CTRL/CMD+C** 來退出伺服器。

## 作業

嘗試向你的 **server.py** 文件添加額外的工具項（例如：返回一個數字的平方根）。提交需要代理利用你的新工具（或現有工具）的額外提示。請務必重啟伺服器以加載新添加的工具。

## 解決方案

[解決方案](./solution/README.md)

## 關鍵要點

本章的要點如下：

- AI Toolkit 擴展是一個很好的客戶端，可以讓你消耗 MCP 伺服器及其工具。
- 你可以向 MCP 伺服器添加新工具，擴展代理的能力以滿足不斷變化的需求。
- AI Toolkit 包括模板（例如：Python MCP 伺服器模板）以簡化自定義工具的創建。

## 其他資源

- [AI Toolkit 文檔](https://aka.ms/AIToolkit/doc)

## 下一步

下一步：[第4課 實際應用](/04-PracticalImplementation/README.md)

**免責聲明**：
此文件已使用AI翻譯服務[Co-op Translator](https://github.com/Azure/co-op-translator)進行翻譯。我們努力確保翻譯的準確性，但請注意，自動翻譯可能會包含錯誤或不準確之處。原文件的母語版本應被視為權威來源。對於重要信息，建議使用專業的人類翻譯。我們對因使用此翻譯而引起的任何誤解或誤釋不承擔責任。