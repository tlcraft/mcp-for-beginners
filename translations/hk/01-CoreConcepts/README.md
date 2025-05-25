<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4bf553c18e7e226c3d76ab0cde627d26",
  "translation_date": "2025-05-20T20:39:52+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hk"
}
-->
# 📖 MCP 核心概念：掌握用於 AI 整合的 Model Context Protocol

Model Context Protocol（MCP）是一個強大且標準化的框架，優化大型語言模型（LLM）與外部工具、應用程式及數據來源之間的溝通。這份經過 SEO 優化的指南會帶你了解 MCP 的核心概念，確保你掌握其客戶端-伺服器架構、主要組件、通訊機制及實作最佳實務。

## 概覽

本課程探討構成 Model Context Protocol（MCP）生態系統的基本架構與組件。你會學習客戶端-伺服器架構、主要組件及推動 MCP 互動的通訊機制。

## 👩‍🎓 主要學習目標

完成本課後，你將能：

- 了解 MCP 的客戶端-伺服器架構。
- 辨識 Hosts、Clients 和 Servers 的角色與責任。
- 分析讓 MCP 成為靈活整合層的核心特性。
- 理解 MCP 生態系統中的資訊流動。
- 透過 .NET、Java、Python 和 JavaScript 範例，獲得實務見解。

## 🔎 MCP 架構：深入探討

MCP 生態系統建立在客戶端-伺服器模型上。這種模組化結構讓 AI 應用能有效地與工具、資料庫、API 及情境資源互動。以下將架構拆解為主要組件。

### 1. Hosts

在 Model Context Protocol（MCP）中，Hosts 是使用者與協議互動的主要介面，扮演重要角色。Hosts 是啟動與 MCP 伺服器連線以存取資料、工具和提示的應用程式或環境。Hosts 範例包括 Visual Studio Code 這類整合開發環境（IDE）、Claude Desktop 等 AI 工具，或為特定任務設計的客製化代理程式。

**Hosts** 是啟動連線的 LLM 應用，它們會：

- 執行或與 AI 模型互動以產生回應。
- 啟動與 MCP 伺服器的連線。
- 管理對話流程與使用者介面。
- 控制權限與安全限制。
- 處理使用者對資料分享及工具執行的同意。

### 2. Clients

Clients 是促進 Hosts 與 MCP 伺服器互動的重要組件。Clients 扮演中介者角色，使 Hosts 能夠存取並使用 MCP 伺服器提供的功能，確保 MCP 架構內溝通順暢及資料交換效率。

**Clients** 是 Host 應用程式中的連接器，它們會：

- 向伺服器發送帶有提示或指令的請求。
- 與伺服器協商功能能力。
- 管理模型的工具執行請求。
- 處理並向使用者顯示回應。

### 3. Servers

Servers 負責處理 MCP clients 的請求並提供相應回應。它們管理資料檢索、工具執行及提示生成等各種操作。Servers 確保 clients 與 Hosts 之間的通訊高效且可靠，維持互動過程的完整性。

**Servers** 是提供情境與功能的服務，它們會：

- 註冊可用功能（資源、提示、工具）
- 接收並執行 client 發出的工具呼叫
- 提供情境資訊以增強模型回應
- 將結果回傳給 client
- 必要時維持跨互動的狀態

任何人都可以開發 Servers，以專門功能擴展模型能力。

### 4. Server Features

MCP 中的 Servers 提供基本組件，促進 clients、hosts 和語言模型之間豐富的互動。這些功能旨在透過結構化的情境、工具和提示，提升 MCP 的能力。

MCP 伺服器可提供以下任一功能：

#### 📑 Resources 

Model Context Protocol（MCP）中的資源涵蓋可供使用者或 AI 模型利用的各種情境與資料類型，包括：

- **情境資料**：使用者或 AI 模型可用於決策和任務執行的資訊與背景。
- **知識庫與文件庫**：結構化及非結構化資料集合，如文章、手冊及研究報告，提供寶貴洞見與資訊。
- **本地檔案與資料庫**：儲存在裝置或資料庫中的資料，可供處理與分析。
- **API 與網路服務**：外部介面與服務，提供額外資料與功能，方便整合各種線上資源和工具。

資源範例可以是資料庫結構或可這樣存取的檔案：

```text
file://log.txt
database://schema
```

### 🤖 Prompts

Model Context Protocol（MCP）中的提示包含各種預先定義的範本和互動模式，旨在簡化使用者工作流程並提升溝通效率，包括：

- **範本訊息與工作流程**：預先結構化的訊息與流程，引導使用者完成特定任務與互動。
- **預設互動模式**：標準化的動作與回應序列，促進一致且高效的溝通。
- **專用對話範本**：針對特定類型對話量身訂製的範本，確保互動具相關性與情境適切性。

提示範本範例如下：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

Model Context Protocol（MCP）中的工具是 AI 模型可執行以完成特定任務的函式。這些工具設計來提升 AI 模型的能力，提供結構化且可靠的操作。重點包括：

- **供 AI 模型執行的函式**：工具是可由 AI 模型調用以執行各種任務的函式。
- **獨特名稱與描述**：每個工具都有明確的名稱和詳細說明其用途與功能。
- **參數與輸出**：工具接受特定參數並回傳結構化輸出，確保結果一致且可預期。
- **獨立功能**：工具執行獨立任務，如網頁搜尋、計算和資料庫查詢。

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

## Client Features

在 Model Context Protocol（MCP）中，clients 向 servers 提供多項關鍵功能，提升整體協議的互動與功能。其中一項重要功能是 Sampling。

### 👉 Sampling

- **伺服器主導的代理行為**：clients 允許伺服器自主啟動特定行動或行為，增強系統動態能力。
- **遞迴 LLM 互動**：此功能支援與大型語言模型的遞迴互動，促成更複雜且反覆的任務處理。
- **請求額外模型完成**：伺服器可向模型請求額外的完成結果，確保回應完整且具情境相關性。

## MCP 中的資訊流

Model Context Protocol（MCP）定義了 hosts、clients、servers 與模型間結構化的資訊流。理解此流程有助釐清使用者請求如何被處理，以及外部工具和資料如何整合進模型回應。

- **Host 啟動連線**  
  Host 應用程式（例如 IDE 或聊天介面）與 MCP 伺服器建立連線，通常透過 STDIO、WebSocket 或其他支援的傳輸方式。

- **功能協商**  
  嵌入 host 的 client 與伺服器交換彼此支援的功能、工具、資源及協議版本，確保雙方了解可用能力。

- **使用者請求**  
  使用者與 host 互動（例如輸入提示或指令），host 收集輸入並傳給 client 處理。

- **資源或工具使用**  
  - client 可能向伺服器請求額外情境或資源（如檔案、資料庫項目或知識庫文章），以豐富模型理解。
  - 若模型判斷需要使用工具（例如擷取資料、執行計算或呼叫 API），client 會發送工具調用請求給伺服器，指定工具名稱與參數。

- **伺服器執行**  
  伺服器接收資源或工具請求，執行必要操作（如執行函式、查詢資料庫或取得檔案），並以結構化格式回傳結果給 client。

- **回應產生**  
  client 將伺服器回應（資源資料、工具輸出等）整合進持續的模型互動中，模型利用這些資訊產生完整且具情境相關的回應。

- **結果呈現**  
  host 從 client 收到最終輸出，並呈現給使用者，通常包括模型產生的文字及工具執行或資源查詢的結果。

此流程讓 MCP 能無縫連結模型與外部工具及資料來源，支援進階、互動且具情境感知的 AI 應用。

## 協議細節

MCP（Model Context Protocol）建立在 [JSON-RPC 2.0](https://www.jsonrpc.org/) 之上，提供標準化、語言無關的訊息格式，促進 hosts、clients 和 servers 間的通訊。此基礎確保跨平台及多種程式語言間的可靠、結構化及可擴充互動。

### 主要協議特性

MCP 在 JSON-RPC 2.0 基礎上，新增工具調用、資源存取與提示管理的慣例。支援多種傳輸層（STDIO、WebSocket、SSE），並實現安全、可擴充及語言無關的元件通訊。

#### 🧢 基本協議

- **JSON-RPC 訊息格式**：所有請求與回應均遵循 JSON-RPC 2.0 規範，確保方法呼叫、參數、結果及錯誤處理結構一致。
- **有狀態連線**：MCP 會話維持多次請求間的狀態，支援持續對話、情境累積及資源管理。
- **功能協商**：連線建立時，clients 與 servers 交換支援功能、協議版本、可用工具與資源，確保雙方理解彼此能力並適應。

#### ➕ 額外工具

以下為 MCP 提供的部分額外工具與協議擴展，提升開發者體驗及支援進階場景：

- **配置選項**：MCP 允許動態設定會話參數，如工具權限、資源存取及模型設定，依互動需求調整。
- **進度追蹤**：長時間執行的操作可回報進度更新，讓使用者介面更具回應性，提升複雜任務體驗。
- **請求取消**：clients 可取消正在執行的請求，讓使用者中斷不再需要或耗時過長的操作。
- **錯誤回報**：標準化錯誤訊息與代碼，有助診斷問題、優雅處理失敗，並提供使用者與開發者可行的回饋。
- **日誌記錄**：clients 與 servers 均可產生結構化日誌，用於審計、除錯及監控協議互動。

藉由這些協議特性，MCP 確保語言模型與外部工具或資料來源間的通訊穩健、安全且靈活。

### 🔐 安全考量

MCP 實作應遵守多項關鍵安全原則，確保互動安全可信：

- **使用者同意與控制**：使用者必須明確同意才可存取資料或執行操作，且應清楚掌控資料分享與授權行為，並有直觀介面審核及批准活動。
- **資料隱私**：使用者資料僅於明確同意下揭露，並須受適當存取控制保護。MCP 實作必須防範未授權資料傳輸，確保互動全程隱私維護。
- **工具安全**：呼叫工具前須取得明確使用者同意。使用者應充分了解每個工具功能，並強制執行嚴格安全邊界，避免非預期或不安全的工具執行。

遵循這些原則，MCP 確保使用者信任、隱私與安全在所有協議互動中獲得保障。

## 程式碼範例：主要組件

以下展示多種流行程式語言的範例，說明如何實作 MCP 伺服器主要組件與工具。

### .NET 範例：建立簡單 MCP 伺服器與工具

這是一個實用的 .NET 程式碼範例，展示如何實作簡單 MCP 伺服器並註冊自訂工具。範例說明工具定義、請求處理及透過 Model Context Protocol 連接伺服器。

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

此範例展示與上述 .NET 範例相同的 MCP 伺服器與工具註冊，但以 Java 實作。

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

本範例展示如何用 Python 建立 MCP 伺服器，並示範兩種建立工具的方式。

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

此 JavaScript 範例示範如何建立 MCP client，連接伺服器、發送提示並處理回應，包括任何工具呼叫。

## 安全與授權

MCP 包含多項內建概念與機制，管理整個協議的安全與授權：

1. **工具權限控制**  
  clients 可指定模型在會話期間可使用哪些工具，確保僅授權工具可用，降低非預期或不安全操作風險。權限可根據使用者偏好、組織政策或互動情境動態設定。

2. **身份驗證**  
  servers 可要求身份驗證，才能存取工具、資源或敏感操作，可能包括 API 金鑰、OAuth 令牌或其他驗證機制。妥善身份驗證確保僅受信任的 clients 與使用者能調用伺服器功能。

3. **參數驗證**  
  所有工具調用均強制參數驗證。每個工具定義參數的類型、格式及限制，伺服器會驗證請求是否符合，防止不良或惡意輸入影響工具實作，維護操作完整性。

4. **速率限制**  
  為防止濫用並確保伺服器資源公平使用，MCP servers 可對工具呼叫與資源存取實施速率限制。限制可依使用者、會話或全域設定，有助防範拒絕服務攻擊或過度資源消耗。

結合這些機制，MCP 提供安全基礎，整合語言模型與外部工具及資料來源，同時讓使用者與開發者對存取與使用有細緻控管。

## 協議訊息

MCP 通訊使用結構化 JSON 訊息，促進 clients、servers 與模型間清晰且可靠的互動。主要訊息類型包括：

- **Client 請求**  
  從 client 發送至 server，通常包含：
  - 使用者的提示或指令
  - 對話歷史以提供情境
  - 工具設定與權限
  - 任何額外的元資料或會話資訊

- **模型回應**  
  由模型（透過 client）回傳，包含：
  - 根據提示與情境產生的文字或完成結果
  - 若模型判斷需調用工具，則包含工具呼叫指令
  - 參考資源或額外情境資料（如有）

- **工具請求**  
  當需執行工具時，client 發送至 server 的訊息，包含：
  - 要調用的工具名稱
  - 工具所需參數（依工具架構驗證）
  - 用於追蹤請求的情境資訊或識別碼

- **工具回應**  
  工具執行後由 server 回傳，提供：
  - 工具執行結果（結構化資料或內容）
  - 若工具呼叫失敗，則含錯誤或狀態資訊
  - 選擇性提供與執行相關的元資料或日誌

這些結構化訊息確保 MCP 工作流程每

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋努力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原始文件嘅母語版本應被視為權威來源。對於重要資訊，建議採用專業人工翻譯。我哋對因使用此翻譯而引致嘅任何誤解或誤釋概不負責。