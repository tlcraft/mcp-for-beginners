<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:06:02+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tw"
}
-->
# 📖 MCP 核心概念：精通 AI 整合的模型上下文協定

模型上下文協定（MCP）是一個強大且標準化的框架，優化大型語言模型（LLM）與外部工具、應用程式及資料來源之間的溝通。這份經過 SEO 優化的指南將帶你了解 MCP 的核心概念，確保你掌握其客戶端-伺服器架構、主要組件、溝通機制及最佳實作方式。

## 概覽

本課程將探討構成模型上下文協定（MCP）生態系統的基本架構與組件。你將學習 MCP 的客戶端-伺服器架構、關鍵組件，以及驅動 MCP 互動的溝通機制。

## 👩‍🎓 主要學習目標

完成本課程後，你將能夠：

- 理解 MCP 的客戶端-伺服器架構。
- 辨識 Hosts、Clients 與 Servers 的角色與責任。
- 分析使 MCP 成為靈活整合層的核心特性。
- 了解資訊在 MCP 生態系統中的流動方式。
- 透過 .NET、Java、Python 與 JavaScript 的程式碼範例，獲得實務見解。

## 🔎 MCP 架構：深入探討

MCP 生態系統建立在客戶端-伺服器模型之上。這種模組化結構讓 AI 應用能有效地與工具、資料庫、API 及上下文資源互動。接下來我們將拆解此架構的核心組件。

### 1. Hosts

在模型上下文協定（MCP）中，Hosts 扮演主要介面角色，讓使用者能透過它與協定互動。Hosts 是啟動與 MCP 伺服器連線的應用程式或環境，以存取資料、工具及提示。Hosts 範例包含像 Visual Studio Code 這類整合開發環境（IDE）、Claude Desktop 等 AI 工具，或為特定任務量身打造的客製代理程式。

**Hosts** 是啟動連線的 LLM 應用程式。它們會：

- 執行或與 AI 模型互動以產生回應。
- 啟動與 MCP 伺服器的連線。
- 管理對話流程與使用者介面。
- 控制權限及安全限制。
- 處理使用者對資料分享及工具執行的同意。

### 2. Clients

Clients 是促進 Hosts 與 MCP 伺服器間互動的重要組件。Clients 扮演中介者角色，讓 Hosts 能存取並使用 MCP 伺服器提供的功能。它們確保 MCP 架構內的溝通順暢且資料交換有效率。

**Clients** 是主機應用內的連接器。它們會：

- 向伺服器發送帶有提示或指令的請求。
- 與伺服器協商功能。
- 管理模型發出的工具執行請求。
- 處理並顯示回應給使用者。

### 3. Servers

Servers 負責處理來自 MCP clients 的請求並提供適當回應。它們管理各種操作，如資料擷取、工具執行及提示產生。Servers 確保客戶端與 Hosts 間的溝通高效且可靠，維護互動過程的完整性。

**Servers** 是提供上下文與功能的服務。它們會：

- 註冊可用的功能（資源、提示、工具）。
- 接收並執行來自客戶端的工具呼叫。
- 提供上下文資訊以強化模型回應。
- 將輸出結果回傳給客戶端。
- 必要時維持互動狀態。

任何人都能開發伺服器，藉此擴展模型功能並加入專門的功能。

### 4. Server Features

MCP 伺服器提供基本建構模組，使客戶端、主機與語言模型間能進行豐富互動。這些功能設計用來強化 MCP，提供結構化的上下文、工具與提示。

MCP 伺服器可提供以下任一功能：

#### 📑 資源

模型上下文協定（MCP）中的資源包含各種上下文與資料，供使用者或 AI 模型使用，包括：

- **上下文資料**：使用者或 AI 模型可用來決策與執行任務的資訊與上下文。
- **知識庫與文件庫**：結構化或非結構化資料集合，如文章、手冊與研究報告，提供寶貴見解與資訊。
- **本地檔案與資料庫**：儲存在裝置或資料庫中的資料，可供處理與分析。
- **API 與網路服務**：外部介面與服務，提供額外資料與功能，實現與各種線上資源及工具的整合。

資源範例可以是資料庫架構或可透過以下方式存取的檔案：

```text
file://log.txt
database://schema
```

### 🤖 提示
模型上下文協定（MCP）中的提示包含各種預先定義的範本與互動模式，旨在簡化使用者工作流程並增進溝通效率，包括：

- **範本訊息與工作流程**：預先結構化的訊息與流程，引導使用者完成特定任務與互動。
- **預定義的互動模式**：標準化的動作與回應序列，促進一致且有效率的溝通。
- **專用對話範本**：為特定類型對話量身打造的可客製化範本，確保互動相關且符合上下文。

提示範本範例：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ 工具

模型上下文協定（MCP）中的工具是 AI 模型可執行以完成特定任務的函式。這些工具設計用來強化 AI 模型的能力，提供結構化且可靠的操作。主要特點包括：

- **供 AI 模型執行的函式**：工具是可被 AI 模型呼叫以執行各種任務的函式。
- **獨特名稱與說明**：每個工具都有明確名稱與詳細說明，解釋其目的與功能。
- **參數與輸出**：工具接受特定參數並回傳結構化輸出，確保結果一致且可預期。
- **獨立功能**：工具執行獨立任務，如網路搜尋、計算及資料庫查詢。

工具範例：

```typescript
server.tool(
  "GetProducts",
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## 客戶端功能

在模型上下文協定（MCP）中，客戶端向伺服器提供多項關鍵功能，增強協定內的整體互動性。其中一項重要功能是取樣（Sampling）。

### 👉 取樣

- **伺服器啟動的代理行為**：客戶端允許伺服器自主啟動特定行動或行為，提升系統的動態能力。
- **遞迴式 LLM 互動**：此功能支援與大型語言模型（LLM）進行遞迴互動，實現更複雜與反覆的任務處理。
- **請求額外模型完成**：伺服器可向模型請求額外的回應完成，確保回答完整且符合上下文。

## MCP 中的資訊流

模型上下文協定（MCP）定義了 Hosts、Clients、Servers 與模型間結構化的資訊流。理解此流程有助於釐清使用者請求的處理方式，以及外部工具和資料如何整合進模型回應。

- **Host 啟動連線**  
  主機應用程式（例如 IDE 或聊天介面）透過 STDIO、WebSocket 或其他支援的傳輸方式，與 MCP 伺服器建立連線。

- **功能協商**  
  客戶端（嵌入於主機）與伺服器交換彼此支援的功能、工具、資源與協定版本資訊，確保雙方了解本次會話可用的能力。

- **使用者請求**  
  使用者與主機互動（例如輸入提示或指令）。主機收集輸入並傳送給客戶端處理。

- **資源或工具使用**  
  - 客戶端可能向伺服器請求額外上下文或資源（如檔案、資料庫條目或知識庫文章），以豐富模型理解。
  - 若模型判斷需要工具（例如擷取資料、執行計算或呼叫 API），客戶端會向伺服器發送工具呼叫請求，指定工具名稱與參數。

- **伺服器執行**  
  伺服器接收資源或工具請求，執行必要操作（如執行函式、查詢資料庫或擷取檔案），並以結構化格式回傳結果給客戶端。

- **回應產生**  
  客戶端將伺服器的回應（資源資料、工具輸出等）整合進持續的模型互動中。模型利用這些資訊產生完整且符合上下文的回應。

- **結果呈現**  
  主機從客戶端接收最終輸出，並呈現給使用者，通常包含模型產生的文字及工具執行或資源查詢的結果。

此流程讓 MCP 能無縫連接模型與外部工具及資料來源，支援進階、互動且具上下文感知的 AI 應用。

## 協定細節

MCP（模型上下文協定）建立於 [JSON-RPC 2.0](https://www.jsonrpc.org/) 之上，提供標準化且語言無關的訊息格式，用於 Hosts、Clients 與 Servers 間的溝通。此基礎確保跨平台與多種程式語言間的可靠、結構化且可擴充的互動。

### 主要協定特性

MCP 擴充 JSON-RPC 2.0，增加工具呼叫、資源存取及提示管理的慣例。支援多種傳輸層（STDIO、WebSocket、SSE），並實現元件間安全、可擴充且語言無關的通訊。

#### 🧢 基本協定

- **JSON-RPC 訊息格式**：所有請求與回應均採用 JSON-RPC 2.0 規範，確保方法呼叫、參數、結果與錯誤處理結構一致。
- **有狀態連線**：MCP 會話可跨多個請求維持狀態，支援持續對話、上下文累積與資源管理。
- **功能協商**：連線建立時，客戶端與伺服器交換支援的功能、協定版本、可用工具與資源資訊，確保雙方理解彼此能力並適應對應。

#### ➕ 額外工具

以下是 MCP 提供的部分額外工具與協定擴充，以提升開發者體驗並支援進階場景：

- **設定選項**：MCP 允許動態設定會話參數，如工具權限、資源存取及模型設定，依互動需求調整。
- **進度追蹤**：長時間運作的操作可回報進度更新，提供更即時的使用者介面回饋與良好體驗。
- **請求取消**：客戶端可取消正在進行的請求，讓使用者能中斷不再需要或執行過久的操作。
- **錯誤回報**：標準化錯誤訊息與代碼，有助於診斷問題、優雅處理失敗，並提供可行的回饋給使用者與開發者。
- **日誌紀錄**：客戶端與伺服器皆可輸出結構化日誌，用於稽核、除錯及監控協定互動。

透過這些協定特性，MCP 確保語言模型與外部工具或資料來源間的溝通穩健、安全且靈活。

### 🔐 安全考量

MCP 實作應遵循數項關鍵安全原則，以確保互動安全且值得信賴：

- **使用者同意與控制**：使用者必須明確同意後，才能存取資料或執行操作。使用者應清楚掌控資料分享範圍與授權行為，且介面應直覺，方便檢視與批准活動。
- **資料隱私**：使用者資料僅能在明確同意下被揭露，並須以適當存取控制加以保護。MCP 實作必須防範未授權資料傳輸，確保隱私於所有互動中被維護。
- **工具安全**：執行任何工具前，需取得明確使用者同意。使用者應充分了解每個工具功能，且必須強制執行嚴格安全邊界，防止非預期或不安全的工具執行。

遵循這些原則，MCP 能在所有協定互動中維護使用者信任、隱私與安全。

## 程式碼範例：主要組件

以下展示多種流行程式語言的程式碼範例，說明如何實作 MCP 伺服器主要組件與工具。

### .NET 範例：建立簡單 MCP 伺服器與工具

這是一個實用的 .NET 範例，示範如何實作簡單 MCP 伺服器並註冊自訂工具。範例展示如何定義與註冊工具、處理請求，並使用模型上下文協定連接伺服器。

```csharp
using System;
using System.Threading.Tasks;
using ModelContextProtocol.Server;
using ModelContextProtocol.Server.Transport;
using ModelContextProtocol.Server.Tools;

public class WeatherServer
{
    public static async Task Main(string[] args)
    {
        // Create an MCP server
        var server = new McpServer(
            name: "Weather MCP Server",
            version: "1.0.0"
        );
        
        // Register our custom weather tool
        server.AddTool<string, WeatherData>("weatherTool", 
            description: "Gets current weather for a location",
            execute: async (location) => {
                // Call weather API (simplified)
                var weatherData = await GetWeatherDataAsync(location);
                return weatherData;
            });
        
        // Connect the server using stdio transport
        var transport = new StdioServerTransport();
        await server.ConnectAsync(transport);
        
        Console.WriteLine("Weather MCP Server started");
        
        // Keep the server running until process is terminated
        await Task.Delay(-1);
    }
    
    private static async Task<WeatherData> GetWeatherDataAsync(string location)
    {
        // This would normally call a weather API
        // Simplified for demonstration
        await Task.Delay(100); // Simulate API call
        return new WeatherData { 
            Temperature = 72.5,
            Conditions = "Sunny",
            Location = location
        };
    }
}

public class WeatherData
{
    public double Temperature { get; set; }
    public string Conditions { get; set; }
    public string Location { get; set; }
}
```

### Java 範例：MCP 伺服器組件

此範例展示與上述 .NET 範例相同的 MCP 伺服器與工具註冊，但使用 Java 實作。

```java
import io.modelcontextprotocol.server.McpServer;
import io.modelcontextprotocol.server.McpToolDefinition;
import io.modelcontextprotocol.server.transport.StdioServerTransport;
import io.modelcontextprotocol.server.tool.ToolExecutionContext;
import io.modelcontextprotocol.server.tool.ToolResponse;

public class WeatherMcpServer {
    public static void main(String[] args) throws Exception {
        // Create an MCP server
        McpServer server = McpServer.builder()
            .name("Weather MCP Server")
            .version("1.0.0")
            .build();
            
        // Register a weather tool
        server.registerTool(McpToolDefinition.builder("weatherTool")
            .description("Gets current weather for a location")
            .parameter("location", String.class)
            .execute((ToolExecutionContext ctx) -> {
                String location = ctx.getParameter("location", String.class);
                
                // Get weather data (simplified)
                WeatherData data = getWeatherData(location);
                
                // Return formatted response
                return ToolResponse.content(
                    String.format("Temperature: %.1f°F, Conditions: %s, Location: %s", 
                    data.getTemperature(), 
                    data.getConditions(), 
                    data.getLocation())
                );
            })
            .build());
        
        // Connect the server using stdio transport
        try (StdioServerTransport transport = new StdioServerTransport()) {
            server.connect(transport);
            System.out.println("Weather MCP Server started");
            // Keep server running until process is terminated
            Thread.currentThread().join();
        }
    }
    
    private static WeatherData getWeatherData(String location) {
        // Implementation would call a weather API
        // Simplified for example purposes
        return new WeatherData(72.5, "Sunny", location);
    }
}

class WeatherData {
    private double temperature;
    private String conditions;
    private String location;
    
    public WeatherData(double temperature, String conditions, String location) {
        this.temperature = temperature;
        this.conditions = conditions;
        this.location = location;
    }
    
    public double getTemperature() {
        return temperature;
    }
    
    public String getConditions() {
        return conditions;
    }
    
    public String getLocation() {
        return location;
    }
}
```

### Python 範例：建立 MCP 伺服器

本範例示範如何用 Python 建立 MCP 伺服器，並展示兩種建立工具的不同方法。

```python
#!/usr/bin/env python3
import asyncio
from mcp.server.fastmcp import FastMCP
from mcp.server.transports.stdio import serve_stdio

# Create a FastMCP server
mcp = FastMCP(
    name="Weather MCP Server",
    version="1.0.0"
)

@mcp.tool()
def get_weather(location: str) -> dict:
    """Gets current weather for a location."""
    # This would normally call a weather API
    # Simplified for demonstration
    return {
        "temperature": 72.5,
        "conditions": "Sunny",
        "location": location
    }

# Alternative approach using a class
class WeatherTools:
    @mcp.tool()
    def forecast(self, location: str, days: int = 1) -> dict:
        """Gets weather forecast for a location for the specified number of days."""
        # This would normally call a weather API forecast endpoint
        # Simplified for demonstration
        return {
            "location": location,
            "forecast": [
                {"day": i+1, "temperature": 70 + i, "conditions": "Partly Cloudy"}
                for i in range(days)
            ]
        }

# Instantiate the class to register its tools
weather_tools = WeatherTools()

# Start the server using stdio transport
if __name__ == "__main__":
    asyncio.run(serve_stdio(mcp))
```

### JavaScript 範例：建立 MCP 伺服器

此範例展示如何用 JavaScript 建立 MCP 伺服器，以及如何註冊兩個與天氣相關的工具。

```javascript
// Using the official Model Context Protocol SDK
import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod"; // For parameter validation

// Create an MCP server
const server = new McpServer({
  name: "Weather MCP Server",
  version: "1.0.0"
});

// Define a weather tool
server.tool(
  "weatherTool",
  {
    location: z.string().describe("The location to get weather for")
  },
  async ({ location }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const weatherData = await getWeatherData(location);
    
    return {
      content: [
        { 
          type: "text", 
          text: `Temperature: ${weatherData.temperature}°F, Conditions: ${weatherData.conditions}, Location: ${weatherData.location}` 
        }
      ]
    };
  }
);

// Define a forecast tool
server.tool(
  "forecastTool",
  {
    location: z.string(),
    days: z.number().default(3).describe("Number of days for forecast")
  },
  async ({ location, days }) => {
    // This would normally call a weather API
    // Simplified for demonstration
    const forecast = await getForecastData(location, days);
    
    return {
      content: [
        { 
          type: "text", 
          text: `${days}-day forecast for ${location}: ${JSON.stringify(forecast)}` 
        }
      ]
    };
  }
);

// Helper functions
async function getWeatherData(location) {
  // Simulate API call
  return {
    temperature: 72.5,
    conditions: "Sunny",
    location: location
  };
}

async function getForecastData(location, days) {
  // Simulate API call
  return Array.from({ length: days }, (_, i) => ({
    day: i + 1,
    temperature: 70 + Math.floor(Math.random() * 10),
    conditions: i % 2 === 0 ? "Sunny" : "Partly Cloudy"
  }));
}

// Connect the server using stdio transport
const transport = new StdioServerTransport();
server.connect(transport).catch(console.error);

console.log("Weather MCP Server started");
```

此 JavaScript 範例示範如何建立 MCP 客戶端，連接伺服器、發送提示，並處理回應，包括任何工具呼叫。

## 安全與授權

MCP 內建多項概念與機制，用於管理整個協定中的安全與授權：

1. **工具權限控制**  
  客戶端可指定模型在會話期間可使用的工具，確保僅能存取明確授權的工具，降低非預期或不安全操作風險。權限可根據使用者偏好、組織政策或互動上下文動態設定。

2. **身份驗證**  
  伺服器可要求身份驗證，方能存取工具、資源或敏感操作。可能採用 API 金鑰、OAuth 令牌或其他驗證機制。正確身份驗證確保僅受信任的客戶端與使用者能呼叫伺服器端功能。

3. **驗證**  
  所有工具呼叫皆強制參數驗證。每個工具定義參數的預期型別、格式與限制，伺服器依此驗證傳入請求。防止格式錯誤或惡意輸入進入工具實作，維護操作完整性。

4. **速率限制**  
  為防止濫用並確保伺服器資源公平使用，MCP 伺服器可對工具呼叫與資源存取實施速率限制。限制可依使用者、會話或全域設定，防範拒絕服務攻擊或過度資源消耗。

結合這些機制，MCP 為語言模型與外部工具及資料來源的整合提供安全基礎，並賦予使用者與開發者細緻的存取與使用控制。

## 協定訊息

MCP 通訊使用結構化 JSON 訊息，促進客戶端、伺服器與模型間清晰且可靠的互動。主要訊息類型包括：

- **客戶端請求**  
  由客戶端發送至伺服器，通常包含：
  - 使用者的提示或指令
  - 對話歷史以提供上下文
  - 工具設定與權限
  - 其他附加的元資料或會話資訊

- **模型回應**  
  由模型（透過客戶端）回傳，內容包含：
  - 根據提示與上下文產生的文字或完成結果
  - 若模型判斷

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們努力追求準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生之任何誤解或誤譯負責。