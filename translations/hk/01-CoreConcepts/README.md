<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f00defb149ee1ac4a799e44a9783c7fc",
  "translation_date": "2025-06-06T18:04:30+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hk"
}
-->
# 📖 MCP 核心概念：掌握模型上下文協議以實現 AI 整合

模型上下文協議（MCP）是一個強大且標準化的框架，優化大型語言模型（LLMs）與外部工具、應用程式及數據源之間的通訊。這份經過 SEO 優化的指南將帶你了解 MCP 的核心概念，確保你掌握其客戶端-伺服器架構、基本組件、通訊機制及最佳實踐。

## 概覽

本課程探討構成模型上下文協議（MCP）生態系統的基本架構與組件。你將了解客戶端-伺服器架構、關鍵組件及驅動 MCP 互動的通訊機制。

## 👩‍🎓 主要學習目標

完成本課後，你將能夠：

- 理解 MCP 的客戶端-伺服器架構。
- 辨識 Hosts、Clients 與 Servers 的角色與職責。
- 分析 MCP 作為靈活整合層的核心特性。
- 學習 MCP 生態系統中資訊的流動方式。
- 透過 .NET、Java、Python 及 JavaScript 的程式碼範例獲得實務洞見。

## 🔎 MCP 架構：深入剖析

MCP 生態系統建立在客戶端-伺服器模型上。這種模組化結構使 AI 應用能有效地與工具、資料庫、API 及上下文資源互動。以下將架構拆解為核心組件。

### 1. Hosts

在模型上下文協議（MCP）中，Hosts 扮演用戶與協議互動的主要介面角色。Hosts 是啟動與 MCP 伺服器連線以存取資料、工具及提示的應用程式或環境。Hosts 範例包括像 Visual Studio Code 這類整合開發環境（IDE）、Claude Desktop 等 AI 工具，或為特定任務打造的客製代理程式。

**Hosts** 是啟動連線的 LLM 應用程式。它們會：

- 執行或與 AI 模型互動以產生回應。
- 啟動與 MCP 伺服器的連線。
- 管理對話流程與用戶介面。
- 控制權限及安全限制。
- 處理用戶對資料共享與工具執行的同意。

### 2. Clients

Clients 是促進 Hosts 與 MCP 伺服器間互動的重要組件。Clients 作為中介，使 Hosts 能夠存取並使用 MCP 伺服器提供的功能。它們在確保通訊順暢及資料交換效率方面扮演關鍵角色。

**Clients** 是 Host 應用中的連接器。它們會：

- 向伺服器發送帶有提示或指令的請求。
- 與伺服器協商功能能力。
- 管理模型發出的工具執行請求。
- 處理並顯示回應給用戶。

### 3. Servers

Servers 負責處理 MCP clients 的請求並提供適當回應。它們管理各種操作，如資料檢索、工具執行及提示產生。Servers 確保 clients 與 Hosts 之間的通訊有效且可靠，維護互動過程的完整性。

**Servers** 是提供上下文與功能的服務。它們會：

- 註冊可用的功能（資源、提示、工具）
- 接收並執行來自客戶端的工具呼叫
- 提供上下文資訊以強化模型回應
- 將結果回傳給客戶端
- 必要時維持互動狀態

任何人都可以開發 Servers 來擴展模型功能，加入專門的功能。

### 4. Server Features

MCP 的 Servers 提供基本建構模組，使 clients、hosts 與語言模型間能進行豐富互動。這些功能設計用來增強 MCP 的能力，提供結構化的上下文、工具及提示。

MCP 伺服器可提供以下任一功能：

#### 📑 資源

MCP 中的資源涵蓋多種上下文與資料，供用戶或 AI 模型使用，包括：

- **上下文資料**：用戶或 AI 模型可用於決策與任務執行的資訊與上下文。
- **知識庫與文件庫**：結構化及非結構化資料集合，如文章、手冊及研究報告，提供寶貴見解。
- **本地檔案與資料庫**：存放於裝置或資料庫中的資料，可供處理與分析。
- **API 與網路服務**：提供額外資料與功能的外部介面與服務，支援與各種線上資源及工具整合。

資源範例可為資料庫架構或檔案，存取方式如下：

```text
file://log.txt
database://schema
```

### 🤖 提示

MCP 中的提示包括多種預先定義的範本與互動模式，旨在簡化用戶工作流程並提升溝通效率，包括：

- **範本訊息與工作流程**：預先結構化的訊息及流程，引導用戶完成特定任務與互動。
- **預設互動模式**：標準化的動作與回應序列，促進一致且高效的溝通。
- **專用對話範本**：為特定類型對話量身定做的可自訂範本，確保相關且符合上下文的互動。

提示範本範例如下：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ 工具

MCP 中的工具是 AI 模型可執行以完成特定任務的函式。這些工具設計用來提升 AI 模型的能力，提供結構化且可靠的操作。重點包括：

- **模型可執行的函式**：工具是模型可調用以執行多種任務的函式。
- **獨特名稱與描述**：每個工具都有明確名稱及詳細說明其用途與功能。
- **參數與輸出**：工具接受特定參數並回傳結構化結果，確保一致且可預測。
- **獨立功能**：工具執行獨立功能，如網路搜尋、計算、資料庫查詢等。

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

## 客戶端功能

在 MCP 中，Clients 提供多項關鍵功能給 Servers，增強協議的整體功能與互動。其中一項重要功能是取樣（Sampling）。

### 👉 取樣

- **伺服器主導的自主行為**：Clients 允許伺服器自主啟動特定動作或行為，提升系統動態能力。
- **遞迴式 LLM 互動**：此功能支援與大型語言模型的遞迴互動，實現更複雜且迭代的任務處理。
- **請求額外模型完成**：伺服器可要求模型提供更多完成結果，確保回應全面且符合上下文。

## MCP 中的資訊流

模型上下文協議（MCP）定義了 Hosts、Clients、Servers 與模型間的結構化資訊流。理解此流程有助於釐清用戶請求如何被處理，以及外部工具與資料如何整合進模型回應。

- **Host 啟動連線**  
  Host 應用程式（如 IDE 或聊天介面）透過 STDIO、WebSocket 或其他支援的傳輸方式建立與 MCP 伺服器的連線。

- **能力協商**  
  嵌入 Host 的 Client 與 Server 交換彼此支援的功能、工具、資源及協議版本，確保雙方了解會話可用的能力。

- **用戶請求**  
  用戶與 Host 互動（例如輸入提示或指令），Host 收集輸入並交由 Client 處理。

- **資源或工具使用**  
  - Client 可能向 Server 請求額外上下文或資源（如檔案、資料庫條目或知識庫文章），以豐富模型理解。
  - 若模型判定需要工具（如取得資料、執行計算或呼叫 API），Client 會發送工具呼叫請求給 Server，指定工具名稱與參數。

- **伺服器執行**  
  Server 接收資源或工具請求，執行必要操作（如執行函式、查詢資料庫或擷取檔案），並以結構化格式將結果回傳給 Client。

- **回應生成**  
  Client 將 Server 的回應（資源資料、工具輸出等）整合至模型互動過程，模型利用這些資訊產生完整且符合上下文的回應。

- **結果呈現**  
  Host 從 Client 收到最終輸出並展示給用戶，通常包含模型生成的文字及工具執行或資源查詢的結果。

此流程讓 MCP 能無縫連結模型與外部工具及資料源，支援先進、互動且具上下文感知的 AI 應用。

## 協議細節

MCP 建構於 [JSON-RPC 2.0](https://www.jsonrpc.org/) 之上，提供標準化、語言無關的訊息格式，用於 Hosts、Clients 與 Servers 間的通訊。這基礎確保跨平台及程式語言的可靠、結構化及可擴展互動。

### 主要協議功能

MCP 在 JSON-RPC 2.0 上擴充了工具呼叫、資源存取及提示管理的慣例。支援多種傳輸層（STDIO、WebSocket、SSE），並實現安全、可擴充且語言無關的組件通訊。

#### 🧢 基本協議

- **JSON-RPC 訊息格式**：所有請求與回應均遵循 JSON-RPC 2.0 規範，確保方法呼叫、參數、結果及錯誤處理結構一致。
- **有狀態連線**：MCP 會話在多次請求間維持狀態，支援持續對話、上下文累積及資源管理。
- **能力協商**：連線建立時，Clients 與 Servers 交換支援功能、協議版本、可用工具及資源，確保雙方理解彼此能力並可相應調整。

#### ➕ 額外工具

以下是 MCP 提供以提升開發者體驗與支援進階場景的額外工具與協議擴充：

- **設定選項**：MCP 允許動態配置會話參數，如工具權限、資源存取及模型設定，針對每次互動調整。
- **進度追蹤**：長時間運作可回報進度更新，提升用戶介面回應性與複雜任務的使用體驗。
- **請求取消**：Clients 可取消進行中的請求，讓用戶能中斷不再需要或耗時過久的操作。
- **錯誤回報**：標準化錯誤訊息與代碼協助診斷問題、優雅處理失敗，並提供可行的反饋給用戶及開發者。
- **日誌紀錄**：Clients 與 Servers 均可產生結構化日誌，用於審計、除錯及監控協議互動。

透過這些協議功能，MCP 確保語言模型與外部工具及資料源間的通訊穩健、安全且靈活。

### 🔐 安全考量

MCP 實作應遵守多項安全原則，確保互動安全且值得信賴：

- **用戶同意與控制**：用戶必須明確同意後，才會存取資料或執行操作。用戶應清楚掌握資料分享範圍與授權行為，並透過直觀介面審核與批准活動。

- **資料隱私**：用戶資料僅在明確同意下曝光，且必須受到適當存取控制保護。MCP 實作須防止未授權資料傳輸，確保整個互動過程中隱私獲得維護。

- **工具安全**：呼叫任何工具前需用戶明確同意。用戶應充分了解每個工具的功能，且必須嚴格執行安全邊界，避免非預期或不安全的工具執行。

遵循這些原則，MCP 確保用戶信任、隱私與安全在所有協議互動中得到保障。

## 程式碼範例：關鍵組件

以下展示多種熱門程式語言的範例，說明如何實作 MCP 伺服器核心組件與工具。

### .NET 範例：建立簡單 MCP 伺服器與工具

這是一個實用的 .NET 範例，示範如何實作簡單的 MCP 伺服器並註冊自訂工具。範例展示工具定義與註冊、請求處理及透過模型上下文協議連線伺服器。

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

### Python 範例：建構 MCP 伺服器

此範例示範如何使用 Python 建立 MCP 伺服器，並展示兩種不同建立工具的方式。

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

此範例展示如何在 JavaScript 中建立 MCP 伺服器，並註冊兩個與天氣相關的工具。

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

此 JavaScript 範例示範如何建立 MCP 客戶端，連接伺服器、發送提示並處理回應，包括任何工具呼叫。

## 安全與授權

MCP 內建多項概念與機制，管理整個協議的安全性與授權：

1. **工具權限控制**：  
  Clients 可指定模型在會話中允許使用的工具，確保只有明確授權的工具可用，降低非預期或不安全操作風險。權限可根據用戶偏好、組織政策或互動上下文動態配置。

2. **身份驗證**：  
  Servers 可要求身份驗證後才授權存取工具、資源或敏感操作，可能採用 API 金鑰、OAuth 令牌或其他驗證機制。妥善身份驗證確保僅可信客戶端與用戶能調用伺服器端功能。

3. **驗證**：  
  所有工具呼叫均強制參數驗證。每個工具定義參數的類型、格式及限制，伺服器依此驗證進來請求，避免格式錯誤或惡意輸入影響工具執行，維護操作完整性。

4. **速率限制**：  
  為防止濫用並確保伺服器資源公平使用，MCP 伺服器可對工具呼叫與資源存取實施速率限制。限制可依用戶、會話或全局設定，防範拒絕服務攻擊或過度資源消耗。

結合這些機制，MCP 為語言模型與外部工具及資料源整合提供安全基礎，同時讓用戶與開發者對存取與使用擁有細緻控制。

## 協議訊息

MCP 通訊使用結構化 JSON 訊息，促進 clients、servers 與模型間清晰且可靠的互動。主要訊息類型包括：

- **客戶端請求**  
  由客戶端發送給伺服器，通常包含：
  - 用戶的提示或指令
  - 對話歷史以提供上下文
  - 工具設定與權限
  - 其他元資料或會話資訊

- **模型回應**  
  由模型（透過客戶端）回傳，包含：
  - 根據提示與上下文產生的文字或完成結果
  - 若模型判定需呼叫工具，包含工具呼叫指令
  - 必要時附帶資源參考或額外上下文

- **工具請求**  
  當需執行工具時，客戶端發送給伺服器的訊息，包含：
  - 要呼叫的工具名稱
  - 工具所需參數（依工具結構驗證）
  - 用於追蹤請求的上下文資訊或識別碼

- **工具回應**  
  工具執行後由伺服器回傳，包含：
  - 工具執行結果（結構化資料或內容）
  - 若呼叫失敗，包含錯誤或狀態資訊
  - 選擇性附加

**免責聲明**：  
本文件係用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 翻譯而成。雖然我哋致力確保準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原文文件嘅母語版本應視為權威來源。對於重要資料，建議採用專業人工翻譯。本公司對因使用本翻譯而引致嘅任何誤解或誤釋概不負責。