<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "788eb17750e970a0bc3b5e7f2e99975b",
  "translation_date": "2025-05-18T14:59:39+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hk"
}
-->
# 📖 MCP 核心概念：掌握模型上下文協議以實現 AI 整合

模型上下文協議（Model Context Protocol，MCP）是一個強大且標準化的框架，優化大型語言模型（LLMs）與外部工具、應用程式及數據源之間的溝通。這份經過 SEO 優化的指南將帶你了解 MCP 的核心概念，確保你掌握其客戶端-伺服器架構、主要組件、溝通機制及最佳實踐。

## 概覽

本課程探討構成模型上下文協議（MCP）生態系統的基本架構與組件。你將學習 MCP 的客戶端-伺服器架構、主要組件及驅動 MCP 互動的溝通機制。

## 👩‍🎓 主要學習目標

完成本課程後，你將能夠：

- 了解 MCP 的客戶端-伺服器架構。
- 辨識 Hosts、Clients 和 Servers 的角色與職責。
- 分析 MCP 作為彈性整合層的核心功能。
- 掌握資訊在 MCP 生態系統中的流動方式。
- 透過 .NET、Java、Python 及 JavaScript 範例獲得實務見解。

## 🔎 MCP 架構：深入解析

MCP 生態系統建立於客戶端-伺服器模型。這種模組化結構讓 AI 應用能高效地與工具、資料庫、API 及上下文資源互動。以下將拆解此架構的核心組件。

### 1. Hosts

在模型上下文協議（MCP）中，Hosts 是使用者與協議互動的主要介面，扮演關鍵角色。Hosts 是啟動與 MCP 伺服器連線以存取資料、工具和提示的應用程式或環境。常見的 Hosts 包括像 Visual Studio Code 這類整合開發環境（IDE）、Claude Desktop 這類 AI 工具，或為特定任務設計的自訂代理。

**Hosts** 是啟動連線的 LLM 應用程式。它們：

- 執行或與 AI 模型互動以產生回應。
- 啟動與 MCP 伺服器的連線。
- 管理對話流程及使用者介面。
- 控制權限及安全限制。
- 處理使用者對資料共享及工具執行的同意。

### 2. Clients

Clients 是促進 Hosts 與 MCP 伺服器之間互動的重要組件。Clients 作為中介，讓 Hosts 能夠存取並利用 MCP 伺服器提供的功能，確保 MCP 架構內的溝通順暢且資料交換高效。

**Clients** 是 Host 應用程式內的連接器。它們：

- 向伺服器傳送帶有提示或指令的請求。
- 與伺服器協商功能。
- 管理模型發出的工具執行請求。
- 處理並顯示回應給使用者。

### 3. Servers

Servers 負責處理來自 MCP clients 的請求並提供適當回應。它們管理資料擷取、工具執行及提示生成等多種操作。Servers 確保 clients 與 Hosts 之間的溝通高效且可靠，維持互動過程的完整性。

**Servers** 是提供上下文與功能的服務。它們：

- 註冊可用功能（資源、提示、工具）
- 接收並執行來自 client 的工具呼叫
- 提供上下文資訊以強化模型回應
- 將結果回傳給 client
- 在需要時維持互動狀態

任何人都可以開發 Servers，以專門功能擴展模型能力。

### 4. Server Features

MCP 的 Servers 提供基本構建模組，使 clients、hosts 與語言模型間能有豐富互動。這些功能設計用以透過結構化上下文、工具及提示強化 MCP 的能力。

MCP 伺服器可提供以下功能：

#### 📑 資源

MCP 中的資源涵蓋多種上下文與數據，供使用者或 AI 模型利用。包括：

- **上下文資料**：使用者或 AI 模型可用於決策及任務執行的資訊與背景。
- **知識庫及文件庫**：結構化或非結構化資料集合，如文章、手冊和研究報告，提供有價值的見解。
- **本地檔案及資料庫**：存放於裝置本地或資料庫中的資料，可供處理與分析。
- **API 與網路服務**：外部介面及服務，提供額外資料與功能，方便整合各種線上資源及工具。

資源範例可以是資料庫架構或可透過以下方式存取的檔案：

```text
file://log.txt
database://schema
```

### 🤖 提示 (Prompts)

MCP 中的提示包含多種預先定義的模板及互動模式，設計用來簡化使用者工作流程並提升溝通效率。包括：

- **模板化訊息與工作流程**：預先結構化的訊息與流程，引導使用者完成特定任務及互動。
- **預設互動模式**：標準化的動作與回應序列，促進一致且高效的溝通。
- **專用對話模板**：為特定對話類型量身打造的可客製化模板，確保互動具相關性及上下文適切。

提示模板範例如下：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ 工具 (Tools)

MCP 的工具是 AI 模型可執行以完成特定任務的功能。這些工具旨在透過結構化且可靠的操作，提升 AI 模型的能力。重點包括：

- **供 AI 模型執行的函式**：工具是可被 AI 模型調用以執行各種任務的函式。
- **獨特名稱與描述**：每個工具都有明確名稱及詳細說明其用途與功能。
- **參數與輸出**：工具接受特定參數並回傳結構化輸出，確保結果一致且可預測。
- **獨立功能**：工具執行獨立任務，如網路搜尋、計算及資料庫查詢。

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

## Client 功能

在 MCP 中，clients 向伺服器提供多項關鍵功能，提升協議內的整體互動與功能。其中一項重要功能是 Sampling。

### 👉 Sampling

- **伺服器主導的自主行為**：clients 允許伺服器自主啟動特定動作或行為，增強系統的動態能力。
- **遞迴式 LLM 互動**：此功能支援與大型語言模型的遞迴互動，使任務處理更複雜且具迭代性。
- **請求額外模型補全**：伺服器可向模型請求額外的補全，確保回應完整且具上下文相關性。

## MCP 中的資訊流

模型上下文協議（MCP）定義了 hosts、clients、servers 與模型間的結構化資訊流。理解此流程有助釐清使用者請求如何被處理，以及外部工具和數據如何整合入模型回應。

- **Host 啟動連線**  
  Host 應用程式（例如 IDE 或聊天介面）建立與 MCP 伺服器的連線，通常透過 STDIO、WebSocket 或其他支援的傳輸方式。

- **功能協商**  
  客戶端（嵌入於 host）與伺服器交換彼此支援的功能、工具、資源及協議版本資訊，確保雙方清楚會話中可用的能力。

- **使用者請求**  
  使用者與 host 互動（例如輸入提示或指令）。host 收集輸入並傳給 client 處理。

- **資源或工具使用**  
  - client 可能向伺服器請求額外上下文或資源（如檔案、資料庫條目或知識庫文章），以豐富模型理解。
  - 若模型判斷需要工具（例如擷取資料、執行計算或呼叫 API），client 會向伺服器發送工具調用請求，指定工具名稱及參數。

- **伺服器執行**  
  伺服器接收資源或工具請求，執行必要操作（如執行函式、查詢資料庫或擷取檔案），並以結構化格式回傳結果給 client。

- **回應生成**  
  client 將伺服器回應（資源資料、工具輸出等）整合入持續的模型互動中。模型利用這些資訊生成全面且具上下文相關性的回應。

- **結果呈現**  
  host 從 client 收到最終輸出並展示給使用者，通常包含模型生成的文字及工具執行或資源查詢的結果。

此流程讓 MCP 能支援先進、互動且具上下文感知的 AI 應用，無縫連接模型與外部工具及數據源。

## 協議細節

MCP 建構於 [JSON-RPC 2.0](https://www.jsonrpc.org/) 之上，提供標準化、語言無關的訊息格式，促進 hosts、clients 與 servers 間的通訊。此基礎確保跨多平台及程式語言的可靠、結構化且可擴展的互動。

### 主要協議功能

MCP 擴展 JSON-RPC 2.0，加入工具調用、資源存取及提示管理的額外約定。支援多種傳輸層（STDIO、WebSocket、SSE），並促進元件間安全、可擴充及語言無關的通訊。

#### 🧢 基礎協議

- **JSON-RPC 訊息格式**：所有請求與回應均遵循 JSON-RPC 2.0 規範，確保方法呼叫、參數、結果與錯誤處理結構一致。
- **有狀態連線**：MCP 會話在多個請求間維持狀態，支援持續對話、上下文累積及資源管理。
- **功能協商**：連線建立時，clients 與 servers 交換支援功能、協議版本、可用工具及資源資訊，確保雙方理解彼此能力並能相應調整。

#### ➕ 額外工具

以下為 MCP 提供的其他工具與協議擴展，提升開發體驗及支援進階場景：

- **配置選項**：MCP 支援動態設定會話參數，如工具權限、資源存取及模型設定，依互動需求調整。
- **進度追蹤**：長時間運作可回報進度更新，讓使用者介面更具反應性，提升複雜任務的體驗。
- **請求取消**：clients 可取消正在執行的請求，讓使用者中斷不再需要或耗時過久的操作。
- **錯誤回報**：標準化錯誤訊息與代碼，有助診斷問題、優雅處理失敗並提供可行反饋給使用者與開發者。
- **日誌紀錄**：clients 與 servers 均可輸出結構化日誌，用於稽核、除錯及監控協議互動。

透過這些協議功能，MCP 確保語言模型與外部工具及數據源間的通訊穩健、安全且具彈性。

### 🔐 安全考量

MCP 實作應遵守多項關鍵安全原則，確保互動安全可信：

- **使用者同意與控制**：任何資料存取或操作前，必須取得使用者明確同意。使用者應清楚掌控共享資料範圍及授權行為，並透過直覺式介面審核與批准活動。
- **資料隱私**：使用者資料僅在明確同意下暴露，並須透過適當存取控管保護。MCP 實作必須防範未授權資料傳輸，確保整個互動過程隱私獲得維護。
- **工具安全**：執行任何工具前需取得使用者明確同意。使用者應充分理解每個工具功能，並實施嚴格安全邊界，防止非預期或不安全的工具執行。

遵循上述原則，MCP 能維護使用者信任、隱私與安全，涵蓋所有協議互動。

## 程式碼範例：主要組件

以下為數種熱門程式語言的範例，展示如何實作 MCP 伺服器主要組件及工具。

### .NET 範例：建立簡單 MCP 伺服器與工具

此實務 .NET 範例展示如何實作簡單 MCP 伺服器並自訂工具，示範工具定義與註冊、請求處理及透過模型上下文協議連接伺服器。

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

本範例示範如何在 Python 中建立 MCP 伺服器，並展示兩種不同的工具建立方式。

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

此範例展示如何使用 JavaScript 建立 MCP 伺服器，並註冊兩個與天氣相關的工具。

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

本 JavaScript 範例示範如何建立 MCP client，連接伺服器、傳送提示，並處理包含任何工具呼叫的回應。

## 安全與授權

MCP 內建多項概念與機制，管理整個協議的安全與授權：

1. **工具權限控制**  
  clients 可指定模型在會話中允許使用的工具，確保只有明確授權的工具可用，降低非預期或不安全操作風險。權限可依使用者偏好、組織政策或互動上下文動態設定。

2. **身份驗證**  
  伺服器可要求身份驗證，才能存取工具、資源或敏感操作。可能包含 API 金鑰、OAuth 令牌或其他驗證機制。適當驗證確保只有受信任的 clients 與使用者能調用伺服器端功能。

3. **參數驗證**  
  所有工具調用均強制參數驗證。每個工具定義參數的預期類型、格式與限制，伺服器依此驗證請求，防止錯誤或惡意輸入影響工具實作，維護操作完整性。

4. **速率限制**  
  為防止濫用並確保伺服器資源公平使用，MCP 伺服器可對工具呼叫及資源存取實施速率限制。限制可依使用者、會話或全域設定，有助防範拒絕服務攻擊或過度資源消耗。

結合這些機制，MCP 提供安全基礎，讓語言模型與外部工具及數據源整合，同時賦予使用者與開發者細緻的存取與使用控制。

## 協議訊息

MCP 通訊使用結構化 JSON 訊息，促進 clients、servers 與模型間清晰且可靠的互動。主要訊息類型包括：

- **Client 請求**  
  由 client 傳送至伺服器，通常包含：
  - 使用者的提示或指令
  - 對話歷史以提供上下文
  - 工具配置與權限
  - 其他元資料或會話資訊

- **模型回應**  
  由模型（經 client）回傳，包含：
  - 根據提示及上下文生成的文字或補全
  - 若模型判斷需調用工具，則包含工具呼叫指令
  - 參考資源或額外上下文（如需）

- **工具請求**  
  當需執行工具時，由 client 傳送至伺服器，包含：
  - 要調用的工具名稱
  - 工具所需參數（經工具定義的結構驗證）
  - 用於追蹤請求的上下文資訊或識別碼

- **工具回應**  
  伺服器執行工具後回傳，包含：
  - 工具執行結果（結構化資料或內容）
  - 若呼叫失敗，包含錯誤或狀態

**免責聲明**：  
本文件使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我們努力確保準確性，但請注意自動翻譯可能包含錯誤或不準確之處。原始文件的母語版本應視為權威來源。對於重要資訊，建議使用專業人工翻譯。我們不對因使用本翻譯而引起的任何誤解或誤釋負責。