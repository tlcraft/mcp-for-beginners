<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T15:00:09+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "tw"
}
-->
# 📖 MCP 核心概念：掌握用於 AI 整合的模型上下文協議

模型上下文協議（Model Context Protocol，MCP）是一個強大且標準化的框架，優化大型語言模型（LLMs）與外部工具、應用程式及資料來源之間的溝通。這份 SEO 優化的指南將帶你深入了解 MCP 的核心概念，確保你掌握其客戶端-伺服器架構、關鍵組件、通訊機制與實作最佳實踐。

## 概覽

本課程探討構成模型上下文協議（MCP）生態系統的基本架構與組件。你將了解客戶端-伺服器架構、主要組件以及推動 MCP 互動的通訊機制。

## 👩‍🎓 主要學習目標

課程結束後，你將能夠：

- 理解 MCP 的客戶端-伺服器架構。
- 辨識 Hosts、Clients 與 Servers 的角色與職責。
- 分析使 MCP 成為彈性整合層的核心特性。
- 學會 MCP 生態系統中資訊的流動方式。
- 透過 .NET、Java、Python 和 JavaScript 的程式碼範例，獲得實務見解。

## 🔎 MCP 架構：深入剖析

MCP 生態系統建立在客戶端-伺服器模型上。這種模組化結構讓 AI 應用能有效地與工具、資料庫、API 及上下文資源互動。接下來我們將架構拆解為核心組件。

### 1. Hosts

在模型上下文協議（MCP）中，Hosts 扮演使用者與協議互動的主要介面。Hosts 是啟動與 MCP 伺服器連線以存取資料、工具和提示的應用程式或環境。Hosts 範例包含整合開發環境（IDE）如 Visual Studio Code、AI 工具如 Claude Desktop，或為特定任務打造的自訂代理程式。

**Hosts** 是啟動連線的 LLM 應用程式。他們會：

- 執行或與 AI 模型互動以產生回應。
- 啟動與 MCP 伺服器的連線。
- 管理對話流程與使用者介面。
- 控制權限與安全限制。
- 處理使用者對資料分享與工具執行的同意。

### 2. Clients

Clients 是促進 Hosts 與 MCP 伺服器互動的關鍵組件。Clients 作為中介，讓 Hosts 能夠存取並使用 MCP 伺服器提供的功能。它們在確保 MCP 架構內通訊順暢及資料交換效率上扮演重要角色。

**Clients** 是 Host 應用內的連接器。他們會：

- 向伺服器傳送帶有提示或指令的請求。
- 與伺服器協商功能。
- 管理模型發出的工具執行請求。
- 處理並顯示回應給使用者。

### 3. Servers

Servers 負責處理 MCP clients 的請求並提供適當的回應。他們管理資料擷取、工具執行及提示產生等各種操作。Servers 確保客戶端與 Hosts 之間的通訊高效且可靠，維護互動流程的完整性。

**Servers** 是提供上下文與功能的服務。他們會：

- 註冊可用功能（資源、提示、工具）
- 接收並執行來自客戶端的工具呼叫
- 提供上下文資訊以強化模型回應
- 將輸出結果回傳給客戶端
- 必要時維護跨互動的狀態

任何人都可以開發 Servers，藉此擴充模型的專業功能。

### 4. Server Features

MCP 的伺服器提供基本構建模組，促進 clients、hosts 與語言模型間的豐富互動。這些功能設計用來強化 MCP 的能力，透過結構化的上下文、工具與提示來實現。

MCP 伺服器可以提供以下任一功能：

#### 📑 資源

MCP 中的資源涵蓋多種可被使用者或 AI 模型利用的上下文與資料，包括：

- **上下文資料**：使用者或 AI 模型可用於決策與任務執行的資訊與背景。
- **知識庫與文件庫**：結構化與非結構化資料集合，如文章、手冊、研究論文，提供寶貴見解與資訊。
- **本地檔案與資料庫**：儲存在裝置或資料庫中的資料，可供處理與分析。
- **API 與網路服務**：提供額外資料與功能的外部介面與服務，促進與各種線上資源及工具整合。

資源範例可以是資料庫架構或可用以下方式存取的檔案：

```text
file://log.txt
database://schema
```

### 🤖 提示 (Prompts)

MCP 中的提示包含多種預先定義的範本與互動模式，旨在簡化使用者工作流程並提升溝通效率，包括：

- **範本訊息與工作流程**：預先結構化的訊息與流程，引導使用者完成特定任務與互動。
- **預設互動模式**：標準化的動作與回應序列，促進一致且有效的溝通。
- **專門化對話範本**：針對特定對話類型客製化的範本，確保互動具相關性且符合上下文。

提示範本範例如下：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ 工具 (Tools)

MCP 中的工具是 AI 模型可執行以完成特定任務的函式。這些工具設計來增強 AI 模型的能力，提供結構化且可靠的操作。主要特點包括：

- **供 AI 模型執行的函式**：工具是模型可呼叫以執行各種任務的可執行函式。
- **獨特名稱與說明**：每個工具都有明確名稱及詳細說明，解釋其用途與功能。
- **參數與輸出**：工具接受特定參數並回傳結構化輸出，確保結果一致且可預期。
- **獨立功能**：工具執行離散功能，如網路搜尋、計算、資料庫查詢。

工具範例如下：

```typescript
server.tool(
  "GetProducts"
  {
    pageSize: z.string().optional(),
    pageCount: z.string().optional()
  }, () => {
    // return results from API
  }
)
```

## Client Features

在 MCP 中，Clients 向 Servers 提供多項關鍵功能，提升整體協議的互動與效能。其中一個重要功能是 Sampling。

### 👉 Sampling

- **伺服器主導的代理行為**：Clients 允許伺服器自主啟動特定行動或行為，增強系統的動態能力。
- **遞迴式 LLM 互動**：此功能支持與大型語言模型的遞迴互動，使任務處理更複雜且可迭代。
- **請求額外模型完成**：伺服器可向模型請求額外的完成內容，確保回應詳盡且符合上下文。

## MCP 中的資訊流

模型上下文協議（MCP）定義了 Hosts、Clients、Servers 與模型之間的結構化資訊流。了解此流程有助於釐清使用者請求如何被處理，以及外部工具和資料如何整合進模型回應。

- **Host 啟動連線**  
  Host 應用程式（如 IDE 或聊天介面）透過 STDIO、WebSocket 或其他支援的傳輸方式，建立與 MCP 伺服器的連線。

- **能力協商**  
  嵌入 Host 的 Client 與 Server 交換彼此支援的功能、工具、資源及協議版本資訊，確保雙方對本次會話可用能力有共識。

- **使用者請求**  
  使用者與 Host 互動（例如輸入提示或指令），Host 收集輸入並傳給 Client 處理。

- **資源或工具使用**  
  - Client 可能向 Server 請求額外上下文或資源（如檔案、資料庫條目、知識庫文章），以豐富模型理解。
  - 若模型判斷需要工具（例如抓取資料、計算、呼叫 API），Client 會送出工具調用請求給 Server，指定工具名稱與參數。

- **伺服器執行**  
  Server 接收資源或工具請求，執行必要操作（如執行函式、查詢資料庫、擷取檔案），並以結構化格式回傳結果給 Client。

- **回應產生**  
  Client 將 Server 回應（資源資料、工具輸出等）整合進持續的模型互動，模型利用這些資訊產生完整且符合上下文的回應。

- **結果呈現**  
  Host 從 Client 收到最終輸出並呈現給使用者，通常包含模型產生的文字及任何工具執行或資源查詢的結果。

此流程讓 MCP 能支持先進、互動且具上下文感知的 AI 應用，無縫連結模型與外部工具及資料來源。

## 協議細節

MCP（模型上下文協議）建立在 [JSON-RPC 2.0](https://www.jsonrpc.org/) 之上，提供標準化、語言無關的訊息格式，用於 Hosts、Clients 與 Servers 之間的通訊。此基礎確保跨多元平台與程式語言的可靠、結構化且可擴充互動。

### 主要協議功能

MCP 擴充 JSON-RPC 2.0，加入工具調用、資源存取及提示管理的額外慣例。支援多種傳輸層（STDIO、WebSocket、SSE），並促成安全、可擴展且語言無關的元件間通訊。

#### 🧢 基本協議

- **JSON-RPC 訊息格式**：所有請求與回應皆遵循 JSON-RPC 2.0 規範，確保方法呼叫、參數、結果與錯誤處理結構一致。
- **有狀態連線**：MCP 會話可跨多次請求維持狀態，支持持續對話、上下文累積與資源管理。
- **能力協商**：連線建立時，Clients 與 Servers 交換支援的功能、協議版本、可用工具與資源資訊，確保雙方理解彼此能力並能相應調整。

#### ➕ 額外工具

以下是 MCP 提供的其他工具與協議擴充，提升開發者體驗並支持進階場景：

- **配置選項**：MCP 允許動態設定會話參數，如工具權限、資源存取及模型設定，依互動需求調整。
- **進度追蹤**：長時間運行的操作可回報進度更新，促成回應迅速的使用者介面與更佳體驗。
- **請求取消**：Clients 可取消進行中的請求，讓使用者中斷不再需要或執行過久的操作。
- **錯誤回報**：標準化錯誤訊息與代碼協助診斷問題、優雅處理失敗，並提供使用者及開發者可行的回饋。
- **日誌記錄**：Clients 與 Servers 可發出結構化日誌，用於稽核、除錯及監控協議互動。

透過這些協議功能，MCP 確保語言模型與外部工具或資料來源間的通訊穩健、安全且靈活。

### 🔐 安全考量

MCP 實作應遵守數項關鍵安全原則，確保互動安全且值得信賴：

- **使用者同意與控制**：在存取資料或執行操作前，必須取得使用者明確同意。使用者應能清楚掌控資料分享範圍與授權行動，並透過直覺式介面審查及批准活動。

- **資料隱私**：使用者資料僅在明確同意下揭露，並須透過適當存取控管保護。MCP 實作必須防止未授權資料傳輸，確保整個互動過程隱私得到維護。

- **工具安全**：在呼叫任何工具前，需取得使用者明確同意。使用者應充分了解每項工具功能，並強制執行嚴格安全邊界，避免工具誤用或不安全執行。

遵循這些原則，MCP 確保所有協議互動中使用者信任、隱私與安全得以維護。

## 程式碼範例：核心組件

以下為多種流行程式語言的範例，展示如何實作 MCP 伺服器核心組件與工具。

### .NET 範例：建立簡易 MCP 伺服器與工具

此實作範例示範如何用 .NET 建立簡單 MCP 伺服器並註冊自訂工具，展示工具定義、請求處理與伺服器連線等流程。

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

本範例示範與上述 .NET 範例相同的 MCP 伺服器與工具註冊，但以 Java 實作。

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

### Python 範例：建構 MCP 伺服器

本範例示範如何用 Python 建立 MCP 伺服器，並展示兩種不同方式建立工具。

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

本範例展示如何用 JavaScript 建立 MCP 伺服器，並註冊兩個與天氣相關的工具。

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

此 JavaScript 範例示範如何建立 MCP 客戶端，連接伺服器、發送提示，並處理回應與工具呼叫。

## 安全與授權

MCP 包含多項內建概念與機制，管理協議全程的安全與授權：

1. **工具權限控管**  
  Clients 可指定模型在會話中允許使用哪些工具，確保僅授權工具可用，降低誤用或不安全操作風險。權限可依使用者偏好、組織政策或互動上下文動態配置。

2. **身份驗證**  
  Servers 可要求驗證後才授權存取工具、資源或敏感操作。可能使用 API 金鑰、OAuth 令牌或其他驗證機制。正確驗證確保只有受信任的客戶端與使用者可呼叫伺服器端功能。

3. **參數驗證**  
  所有工具調用均強制參數驗證。每個工具定義其參數的預期型別、格式與限制，伺服器依此驗證請求，避免錯誤或惡意輸入影響工具執行並維護操作完整性。

4. **速率限制**  
  為防止濫用並確保公平使用伺服器資源，MCP 伺服器可對工具呼叫與資源存取實施速率限制。限制可依使用者、會話或全域設定，有助抵禦拒絕服務攻擊或過度資源消耗。

結合這些機制，MCP 為語言模型與外部工具及資料來源整合提供安全基礎，同時賦予使用者與開發者細緻的存取與使用控制。

## 協議訊息

MCP 通訊使用結構化 JSON 訊息，促進 Clients、Servers 與模型間清晰且可靠的互動。主要訊息類型包括：

- **客戶端請求**  
  由 Client 傳送給 Server，通常包含：  
  - 使用者的提示或指令  
  - 對話歷史作為上下文  
  - 工具設定與權限  
  - 其他附加的元資料或會話資訊

- **模型回應**  
  由模型（透過 Client）回傳，內容包含：  
  - 根據提示與上下文產生的文字或完成內容  
  - 若模型判定需要呼叫工具，則包含工具呼叫指令  
  - 參考資源或其他必要上下文

- **工具請求**  
  當需執行工具時，Client 傳送給 Server 的訊息，包含：  
  - 要呼叫的工具名稱  
  - 工具所需參數（已依工具架構驗證）  
  - 用於追蹤請求的上下文資訊或識別碼

- **工具回應**  
  Server 執行工具後回傳的訊息，包含：  
  - 工具執行結果（結構化資料或內容）  
 

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 所翻譯。雖然我們力求準確，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議採用專業人工翻譯。我們不對因使用本翻譯而產生的任何誤解或誤譯負責。