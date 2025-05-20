<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T16:08:44+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hk"
}
-->
# 📖 MCP 核心概念：掌握用於 AI 整合的模型上下文協議

模型上下文協議（MCP）是一個強大且標準化的框架，優化大型語言模型（LLM）與外部工具、應用程式及資料來源之間的溝通。這份經過 SEO 優化的指南將帶你了解 MCP 的核心概念，確保你掌握其客戶端-伺服器架構、基本組件、溝通機制及實作最佳實務。

## 概覽

本課程探討構成模型上下文協議（MCP）生態系的基本架構與組件。你將了解客戶端-伺服器架構、關鍵組件，以及驅動 MCP 互動的通訊機制。

## 👩‍🎓 主要學習目標

完成本課程後，你將能夠：

- 理解 MCP 的客戶端-伺服器架構。
- 辨識 Hosts、Clients 和 Servers 的角色與職責。
- 分析使 MCP 成為靈活整合層的核心特性。
- 了解資訊在 MCP 生態系中的流動方式。
- 透過 .NET、Java、Python 和 JavaScript 的程式碼範例獲得實務見解。

## 🔎 MCP 架構：深入解析

MCP 生態系建立於客戶端-伺服器模型之上。這種模組化結構讓 AI 應用能有效與工具、資料庫、API 及上下文資源互動。以下將架構拆解為核心組件。

### 1. Hosts

在模型上下文協議（MCP）中，Hosts 扮演主要介面角色，使用者透過 Hosts 與協議互動。Hosts 是啟動與 MCP 伺服器連線以存取資料、工具和提示的應用程式或環境。Hosts 範例包括整合開發環境（IDE）如 Visual Studio Code、AI 工具如 Claude Desktop，或為特定任務打造的自訂代理程式。

**Hosts** 是啟動連線的 LLM 應用程式。他們會：

- 執行或與 AI 模型互動以產生回應。
- 發起與 MCP 伺服器的連線。
- 管理對話流程與使用者介面。
- 控制權限與安全限制。
- 處理使用者對資料分享及工具執行的同意。

### 2. Clients

Clients 是促進 Hosts 與 MCP 伺服器互動的關鍵組件。Clients 作為中介，讓 Hosts 能存取並利用 MCP 伺服器提供的功能。它們在確保 MCP 架構內順暢溝通與高效資料交換中扮演重要角色。

**Clients** 是宿主應用程式內的連接器。他們會：

- 向伺服器發送帶有提示或指令的請求。
- 與伺服器協商功能。
- 管理模型發出的工具執行請求。
- 處理並展示回應給使用者。

### 3. Servers

Servers 負責處理 MCP clients 的請求並提供適當回應。它們管理資料檢索、工具執行及提示產生等各種操作。Servers 確保客戶端與 Hosts 間的溝通有效且可靠，維護互動過程的完整性。

**Servers** 是提供上下文與功能的服務。他們會：

- 註冊可用功能（資源、提示、工具）
- 接收並執行來自客戶端的工具呼叫
- 提供上下文資訊以增強模型回應
- 將輸出回傳給客戶端
- 必要時維持互動間的狀態

任何人都可以開發 Servers，以專門功能擴充模型能力。

### 4. Server Features

模型上下文協議（MCP）中的 Servers 提供基本建構模組，使 Clients、Hosts 和語言模型之間能有豐富的互動。這些功能設計用來透過結構化的上下文、工具和提示增強 MCP 的能力。

MCP 伺服器可提供以下功能：

#### 📑 資源

MCP 中的資源涵蓋可供使用者或 AI 模型利用的各種上下文和資料類型，包括：

- **上下文資料**：供使用者或 AI 模型用於決策與任務執行的資訊與背景。
- **知識庫及文件庫**：結構化與非結構化資料的集合，如文章、手冊和研究報告，提供有價值的洞見與資訊。
- **本地檔案與資料庫**：儲存在裝置本地或資料庫中的資料，可供處理與分析。
- **API 與網路服務**：提供額外資料與功能的外部介面與服務，支援與各種線上資源及工具整合。

資源範例可為資料庫結構或可存取的檔案，如下：

```text
file://log.txt
database://schema
```

### 🤖 提示

MCP 中的提示包含多種預設範本和互動模式，設計用以簡化使用者工作流程並提升溝通效率，包括：

- **範本訊息與工作流程**：預先結構化的訊息和流程，引導使用者完成特定任務與互動。
- **預設互動模式**：標準化的動作與回應序列，促進一致且有效率的溝通。
- **專用對話範本**：為特定對話類型量身打造的可自訂範本，確保相關且符合上下文的互動。

提示範本示例如下：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ 工具

MCP 中的工具是 AI 模型可執行以完成特定任務的函式。這些工具設計用來透過提供結構化且可靠的操作，提升 AI 模型的能力。主要特點包括：

- **供 AI 模型執行的函式**：工具是可被模型調用以執行各種任務的函式。
- **獨特名稱與描述**：每個工具都有明確名稱及詳細描述其用途與功能。
- **參數與輸出**：工具接受特定參數並回傳結構化輸出，確保結果一致且可預期。
- **獨立功能**：工具執行獨立任務，如網頁搜尋、計算及資料庫查詢。

工具範例如下：

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

## Client 功能

在 MCP 中，Clients 向 Servers 提供多項關鍵功能，提升協議的整體效能與互動體驗。其中一個重要功能是 Sampling。

### 👉 Sampling

- **伺服器主導的自主行為**：Clients 讓伺服器能自動發起特定行動或行為，增強系統的動態能力。
- **遞迴式 LLM 互動**：此功能允許與大型語言模型進行遞迴互動，實現更複雜及反覆的任務處理。
- **請求額外模型補全**：伺服器可要求模型提供更多補全，確保回應完整且符合上下文。

## MCP 中的資訊流動

模型上下文協議（MCP）定義了 Hosts、Clients、Servers 與模型間的結構化資訊流。理解此流程有助於釐清使用者請求如何被處理，以及外部工具與資料如何整合進模型回應。

- **Host 發起連線**  
  Host 應用程式（如 IDE 或聊天介面）與 MCP 伺服器建立連線，通常透過 STDIO、WebSocket 或其他支援的傳輸方式。

- **功能協商**  
  嵌入 Host 的 Client 與 Server 交換支援功能、工具、資源及協議版本資訊，確保雙方了解本次會話可用的功能。

- **使用者請求**  
  使用者透過 Host 輸入提示或指令，Host 收集輸入並傳給 Client 處理。

- **使用資源或工具**  
  - Client 可能向 Server 請求額外上下文或資源（如檔案、資料庫條目或知識庫文章），以豐富模型理解。
  - 若模型判定需要工具（如取得資料、執行計算或呼叫 API），Client 將發送工具呼叫請求給 Server，指定工具名稱及參數。

- **伺服器執行**  
  Server 收到資源或工具請求後，執行所需操作（如執行函式、查詢資料庫或取得檔案），並以結構化格式回傳結果給 Client。

- **回應產生**  
  Client 將 Server 回應（資源資料、工具輸出等）整合進模型互動中，模型利用這些資訊產生完整且符合上下文的回應。

- **結果呈現**  
  Host 從 Client 接收最終輸出並呈現給使用者，通常包含模型產生的文字及工具執行或資源查詢的結果。

此流程讓 MCP 能支援進階、互動且具上下文感知的 AI 應用，無縫連結模型與外部工具及資料來源。

## 協議細節

MCP（模型上下文協議）基於 [JSON-RPC 2.0](https://www.jsonrpc.org/) 構建，提供一種標準化且語言無關的訊息格式，用於 Hosts、Clients 與 Servers 之間的通訊。此基礎確保跨平台及程式語言的可靠、結構化及可擴充互動。

### 主要協議特性

MCP 在 JSON-RPC 2.0 基礎上擴充工具呼叫、資源存取與提示管理的慣例。它支援多種傳輸層（STDIO、WebSocket、SSE），並促進安全、可擴充且語言無關的組件間通訊。

#### 🧢 基本協議

- **JSON-RPC 訊息格式**：所有請求與回應均遵循 JSON-RPC 2.0 規範，確保方法呼叫、參數、結果與錯誤處理結構一致。
- **有狀態連線**：MCP 會話跨多次請求維持狀態，支援持續對話、上下文累積及資源管理。
- **功能協商**：連線建立時，Clients 與 Servers 交換支援功能、協議版本、可用工具與資源資訊，確保雙方理解彼此能力並能相應調整。

#### ➕ 額外工具

以下為 MCP 提供的其他工具與協議擴充，以提升開發者體驗及支援進階場景：

- **設定選項**：MCP 允許動態設定會話參數，如工具權限、資源存取及模型設定，依互動需求調整。
- **進度追蹤**：長時間運行的操作可回報進度更新，促使使用者介面回應更即時，提升使用體驗。
- **請求取消**：Clients 可取消正在進行的請求，允許使用者中斷不再需要或耗時過長的操作。
- **錯誤回報**：標準化錯誤訊息與代碼有助於診斷問題、優雅處理失敗，並為使用者及開發者提供可行回饋。
- **日誌記錄**：Clients 與 Servers 均可產生結構化日誌，用於稽核、除錯與監控協議互動。

透過這些協議特性，MCP 確保語言模型與外部工具或資料來源間的通訊穩健、安全且靈活。

### 🔐 安全考量

MCP 實作應遵守多項安全原則，以確保互動安全可信：

- **使用者同意與控制**：任何資料存取或操作執行前，必須取得使用者明確同意。使用者應清楚掌握分享資料與授權行動範圍，並透過直觀介面審核及批准活動。
- **資料隱私**：使用者資料僅在明確同意下暴露，並須透過適當存取控制保護。MCP 實作必須防止未授權資料傳輸，確保整個互動過程維持隱私。
- **工具安全**：呼叫任何工具前，須取得使用者明確同意。使用者應充分理解各工具功能，並執行嚴格安全邊界，防止意外或不安全的工具執行。

遵守上述原則，MCP 可在所有協議互動中維護使用者信任、隱私與安全。

## 程式碼範例：關鍵組件

以下為多種流行程式語言的程式碼範例，展示如何實作 MCP 伺服器關鍵組件與工具。

### .NET 範例：建立簡單 MCP 伺服器與工具

以下為實用的 .NET 程式碼範例，示範如何實作帶自訂工具的簡單 MCP 伺服器。範例展示如何定義與註冊工具、處理請求，以及使用模型上下文協議連接伺服器。

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

本範例示範如何在 Python 中建立 MCP 伺服器，並展示兩種不同方式創建工具。

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

# Initialize class for its methods to be registered as tools
weather_tools = WeatherTools()

if __name__ == "__main__":
    # Start the server with stdio transport
    print("Weather MCP Server starting...")
    asyncio.run(serve_stdio(mcp))
```

### JavaScript 範例：建立 MCP 伺服器

此範例展示如何用 JavaScript 建立 MCP 伺服器，並註冊兩個與天氣相關的工具。

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

這個 JavaScript 範例示範如何建立 MCP 客戶端，連接伺服器、發送提示，並處理包括任何工具呼叫在內的回應。

## 安全與授權

MCP 包含多項內建概念與機制，管理整個協議的安全與授權：

1. **工具權限控制**  
  Clients 可指定模型在會話期間可使用的工具，確保僅授權的工具可用，降低意外或不安全操作風險。權限可依使用者偏好、組織政策或互動上下文動態設定。

2. **身份驗證**  
  Servers 可要求身份驗證以授權存取工具、資源或敏感操作，可能使用 API 金鑰、OAuth 令牌或其他驗證機制。正確驗證確保只有可信客戶端與使用者能調用伺服器端功能。

3. **參數驗證**  
  所有工具呼叫均強制參數驗證。每個工具定義參數的預期類型、格式與限制，伺服器據此驗證進入請求，防止錯誤或惡意輸入影響工具實作，維護操作完整性。

4. **速率限制**  
  為防止濫用並確保伺服器資源公平使用，MCP 伺服器可對工具呼叫與資源存取實施速率限制。限制可依使用者、會話或全域設定，有效抵禦拒絕服務攻擊或過度資源消耗。

結合這些機制，MCP 為語言模型與外部工具及資料來源整合提供安全基礎，同時讓使用者與開發者對存取與使用擁有細緻控制。

## 協議訊息

MCP 通訊使用結構化 JSON 訊息，促進 Clients、Servers 與模型間清晰可靠的互動。主要訊息類型包括：

- **Client 請求**  
  由 Client 傳送給 Server，通常包含：
  - 使用者的提示或指令
  - 對話歷史作為上下文
  - 工具設定與權限
  - 其他附加的元資料或會話資訊

- **模型回應**  
  模型（透過 Client）回傳的訊息，包含：
  - 根據提示與上下文產生的文字或補全
  - 若模型判定需要呼叫工具，則包含工具呼叫指令
  - 參考資源或額外上下文（如有）

- **工具請求**  
  當需要執行工具時，由 Client 傳送給 Server 的訊息，包含：
  - 要呼叫的工具名稱
  - 工具所需參數（依工具定義驗證）
  - 用於追蹤請求的上下文資訊或識別碼

- **工具回應**  
  Server 執行工具後回傳的訊息，提供：
  - 工具執行結果（結構化資料或內容）
  - 若工具呼叫失敗，則包含錯誤或狀態資訊
 

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力保持準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應視為權威來源。對於重要資料，建議採用專業人工翻譯。我哋對因使用此翻譯而引致嘅任何誤解或誤釋概不負責。