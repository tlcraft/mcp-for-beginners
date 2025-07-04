<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8248e3491f5245ee6ab48ef724a4f65a",
  "translation_date": "2025-07-04T16:06:34+00:00",
  "source_file": "03-GettingStarted/07-aitk/README.md",
  "language_code": "hk"
}
-->
# 從 Visual Studio Code 的 AI Toolkit 擴充功能使用伺服器

當你在建立 AI 代理時，不只是要產生聰明的回應，更重要的是讓代理能夠採取行動。這時候就用到 Model Context Protocol (MCP)。MCP 讓代理能以一致的方式存取外部工具和服務。可以把它想像成把你的代理接上了一個它*真正*能用的工具箱。

假設你把代理連接到計算機 MCP 伺服器，代理就能透過像「47 乘以 89 是多少？」這樣的提示來執行數學運算，無需硬編碼邏輯或建立自訂 API。

## 概覽

本課程說明如何使用 Visual Studio Code 中的 [AI Toolkit](https://aka.ms/AIToolkit) 擴充功能，將計算機 MCP 伺服器連接到代理，讓代理能透過自然語言執行加、減、乘、除等數學運算。

AI Toolkit 是 Visual Studio Code 的強大擴充功能，簡化了代理開發流程。AI 工程師可以輕鬆地開發和測試生成式 AI 模型，無論是在本地還是雲端。此擴充功能支援目前大多數主流的生成式模型。

*注意*：AI Toolkit 目前支援 Python 和 TypeScript。

## 學習目標

完成本課程後，你將能夠：

- 透過 AI Toolkit 使用 MCP 伺服器。
- 配置代理設定，使其能發現並使用 MCP 伺服器提供的工具。
- 透過自然語言使用 MCP 工具。

## 方法

我們需要從高層次來看整個流程：

- 建立代理並定義其系統提示。
- 建立帶有計算工具的 MCP 伺服器。
- 將 Agent Builder 連接到 MCP 伺服器。
- 透過自然語言測試代理的工具調用。

很好，了解流程後，讓我們配置 AI 代理，透過 MCP 利用外部工具，提升其功能！

## 先決條件

- [Visual Studio Code](https://code.visualstudio.com/)
- [AI Toolkit for Visual Studio Code](https://aka.ms/AIToolkit)

## 練習：使用伺服器

在本練習中，你將使用 AI Toolkit 在 Visual Studio Code 內建立、執行並強化一個帶有 MCP 伺服器工具的 AI 代理。

### -0- 預備步驟，將 OpenAI GPT-4o 模型加入「我的模型」

本練習使用 **GPT-4o** 模型。請在建立代理前，先將此模型加入「我的模型」。

![Visual Studio Code AI Toolkit 擴充功能中模型選擇介面的截圖。標題為「找到適合你的 AI 解決方案的模型」，副標題鼓勵用戶探索、測試和部署 AI 模型。下方「熱門模型」區域顯示六個模型卡片：DeepSeek-R1（GitHub 托管）、OpenAI GPT-4o、OpenAI GPT-4.1、OpenAI o1、Phi 4 Mini（CPU - 小型、快速）和 DeepSeek-R1（Ollama 托管）。每張卡片包含「新增」和「在 Playground 試用」選項。](../../../../translated_images/aitk-model-catalog.2acd38953bb9c119aa629fe74ef34cc56e4eed35e7f5acba7cd0a59e614ab335.hk.png)

1. 從 **活動列** 開啟 **AI Toolkit** 擴充功能。
2. 在 **目錄** 區段選擇 **Models**，打開 **模型目錄**。選擇 **Models** 會在新編輯器分頁中開啟模型目錄。
3. 在模型目錄的搜尋欄輸入 **OpenAI GPT-4o**。
4. 點擊 **+ Add** 將模型加入「我的模型」清單。請確認選擇的是 **GitHub 托管** 的模型。
5. 在 **活動列** 確認 **OpenAI GPT-4o** 模型已出現在清單中。

### -1- 建立代理

**Agent (Prompt) Builder** 讓你建立並自訂自己的 AI 代理。在本節中，你將建立一個新代理並指定模型來驅動對話。

![Visual Studio Code AI Toolkit 擴充功能中「Calculator Agent」建構介面的截圖。左側面板選擇的模型為「OpenAI GPT-4o (via GitHub)」。系統提示為「你是一位大學數學教授」，使用者提示為「用簡單的方式解釋傅立葉方程」。其他選項包括新增工具、啟用 MCP Server 和選擇結構化輸出。底部有藍色「執行」按鈕。右側面板「開始使用範例」列出三個範例代理：Web Developer（含 MCP Server、二年級簡化器和夢境解讀器，每個附簡短功能說明）。](../../../../translated_images/aitk-agent-builder.901e3a2960c3e4774b29a23024ff5bec2d4232f57fae2a418b2aaae80f81c05f.hk.png)

1. 從 **活動列** 開啟 **AI Toolkit** 擴充功能。
2. 在 **工具** 區段選擇 **Agent (Prompt) Builder**，會在新編輯器分頁中開啟。
3. 點擊 **+ New Agent** 按鈕，擴充功能會透過 **命令面板** 啟動設定精靈。
4. 輸入名稱 **Calculator Agent**，按下 **Enter**。
5. 在 **Agent (Prompt) Builder** 的 **Model** 欄位，選擇 **OpenAI GPT-4o (via GitHub)** 模型。

### -2- 為代理建立系統提示

代理架構完成後，接著定義其個性和目的。本節將使用 **Generate system prompt** 功能，描述代理的預期行為（此處為計算機代理），並由模型幫你撰寫系統提示。

![Visual Studio Code AI Toolkit 中「Calculator Agent」介面的截圖，顯示一個名為「Generate a prompt」的彈出視窗。視窗說明可透過提供基本資訊產生提示範本，並包含一個文字框，範例系統提示為：「你是一位樂於助人且高效率的數學助理。當遇到基本算術問題時，你會回應正確結果。」視窗下方有「關閉」和「產生」按鈕。背景可見部分代理設定，包括選擇的模型「OpenAI GPT-4o (via GitHub)」及系統和使用者提示欄位。](../../../../translated_images/aitk-generate-prompt.ba9e69d3d2bbe2a26444d0c78775540b14196061eee32c2054e9ee68c4f51f3a.hk.png)

1. 在 **Prompts** 區段，點擊 **Generate system prompt** 按鈕。此按鈕會開啟提示建構器，利用 AI 生成系統提示。
2. 在 **Generate a prompt** 視窗中，輸入：`You are a helpful and efficient math assistant. When given a problem involving basic arithmetic, you respond with the correct result.`
3. 點擊 **Generate** 按鈕。右下角會出現通知，確認系統提示正在生成。生成完成後，提示會出現在 **Agent (Prompt) Builder** 的 **System prompt** 欄位。
4. 檢視系統提示，必要時可進行修改。

### -3- 建立 MCP 伺服器

既然已定義代理的系統提示，指導其行為與回應，接下來要為代理配備實用功能。本節將建立一個計算機 MCP 伺服器，內含執行加、減、乘、除運算的工具。此伺服器讓代理能即時回應自然語言提示並執行數學運算。

![Visual Studio Code AI Toolkit 擴充功能中 Calculator Agent 介面下方截圖，顯示可展開的「Tools」和「Structure output」選單，以及一個標示為「Choose output format」且設定為「text」的下拉選單。右側有一個「+ MCP Server」按鈕用於新增 Model Context Protocol 伺服器。工具區上方有一個圖片圖示佔位符。](../../../../translated_images/aitk-add-mcp-server.9742cfddfe808353c0caf9cc0a7ed3e80e13abf4d2ebde315c81c3cb02a2a449.hk.png)

AI Toolkit 提供範本，方便你建立自己的 MCP 伺服器。我們將使用 Python 範本來建立計算機 MCP 伺服器。

*注意*：AI Toolkit 目前支援 Python 和 TypeScript。

1. 在 **Agent (Prompt) Builder** 的 **Tools** 區段，點擊 **+ MCP Server** 按鈕。擴充功能會透過 **命令面板** 啟動設定精靈。
2. 選擇 **+ Add Server**。
3. 選擇 **Create a New MCP Server**。
4. 選擇 **python-weather** 範本。
5. 選擇 **Default folder** 以儲存 MCP 伺服器範本。
6. 輸入伺服器名稱：**Calculator**
7. 會開啟一個新的 Visual Studio Code 視窗，選擇 **Yes, I trust the authors**。
8. 使用終端機（**Terminal** > **New Terminal**）建立虛擬環境：`python -m venv .venv`
9. 啟動虛擬環境：
    1. Windows - `.venv\Scripts\activate`
    2. macOS/Linux - `source venv/bin/activate`
10. 安裝相依套件：`pip install -e .[dev]`
11. 在 **活動列** 的 **Explorer** 視圖中，展開 **src** 目錄並開啟 **server.py** 檔案。
12. 將 **server.py** 中的程式碼替換為以下內容並儲存：

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

### -4- 使用計算機 MCP 伺服器執行代理

既然代理已具備工具，現在就來使用它們！本節將提交提示給代理，測試並驗證代理是否能使用計算機 MCP 伺服器的適當工具。

![Visual Studio Code AI Toolkit 擴充功能中 Calculator Agent 介面截圖。左側「Tools」區段新增了一個名為 local-server-calculator_server 的 MCP 伺服器，顯示四個可用工具：add、subtract、multiply 和 divide。標示有四個工具已啟用。下方為收合的「Structure output」區段和藍色「Run」按鈕。右側「Model Response」面板中，代理分別以輸入 {"a": 3, "b": 25} 和 {"a": 75, "b": 20} 呼叫 multiply 和 subtract 工具。最終「Tool Response」顯示為 75.0。底部有「View Code」按鈕。](../../../../translated_images/aitk-agent-response-with-tools.e7c781869dc8041a25f9903ed4f7e8e0c7e13d7d94f6786a6c51b1e172f56866.hk.png)

你將在本地開發機器上透過 **Agent Builder** 作為 MCP 用戶端執行計算機 MCP 伺服器。

1. 按下 `F5` 開始除錯 MCP 伺服器。**Agent (Prompt) Builder** 會在新編輯器分頁中開啟。終端機中可見伺服器狀態。
2. 在 **Agent (Prompt) Builder** 的 **User prompt** 欄位輸入：`I bought 3 items priced at $25 each, and then used a $20 discount. How much did I pay?`
3. 點擊 **Run** 按鈕產生代理回應。
4. 檢視代理輸出。模型應該會得出你付了 **$55**。
5. 以下是應該發生的流程：
    - 代理選擇使用 **multiply** 和 **subtract** 工具協助計算。
    - 為 **multiply** 工具分配相應的 `a` 和 `b` 值。
    - 為 **subtract** 工具分配相應的 `a` 和 `b` 值。
    - 各工具的回應會顯示在相應的 **Tool Response**。
    - 模型的最終輸出會顯示在 **Model Response**。
6. 提交更多提示以進一步測試代理。你可以點擊 **User prompt** 欄位，修改現有提示。
7. 測試完成後，可在終端機按 **CTRL/CMD+C** 停止伺服器。

## 作業

嘗試在你的 **server.py** 檔案中新增一個工具（例如：回傳數字的平方根）。提交需要代理使用你新增工具（或現有工具）的提示。記得重新啟動伺服器以載入新工具。

## 解答

[解答](./solution/README.md)

## 重要重點

本章重點如下：

- AI Toolkit 擴充功能是很棒的用戶端，讓你能使用 MCP 伺服器及其工具。
- 你可以為 MCP 伺服器新增工具，擴展代理的功能以符合不斷變化的需求。
- AI Toolkit 包含範本（例如 Python MCP 伺服器範本），簡化自訂工具的建立。

## 其他資源

- [AI Toolkit 文件](https://aka.ms/AIToolkit/doc)

## 下一步
- 下一步：[測試與除錯](../08-testing/README.md)

**免責聲明**：  
本文件由 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們致力於確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋承擔責任。