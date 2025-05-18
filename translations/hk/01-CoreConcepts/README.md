<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-17T06:18:55+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "hk"
}
-->
# 📖 MCP核心概念：掌握AI集成的模型上下文协议

模型上下文协议（MCP）是一个强大的标准化框架，优化了大型语言模型（LLM）与外部工具、应用程序和数据源之间的通信。这篇SEO优化指南将引导你了解MCP的核心概念，确保你理解其客户端-服务器架构、基本组件、通信机制和实施最佳实践。

## 概述

这节课探讨了组成模型上下文协议（MCP）生态系统的基本架构和组件。你将了解客户端-服务器架构、关键组件以及驱动MCP交互的通信机制。

## 👩‍🎓 关键学习目标

在本课结束时，你将能够：

- 理解MCP客户端-服务器架构。
- 识别主机、客户端和服务器的角色和责任。
- 分析使MCP成为灵活集成层的核心功能。
- 学习信息在MCP生态系统中的流动。
- 通过.NET、Java、Python和JavaScript中的代码示例获得实用见解。

## 🔎 MCP架构：深入探讨

MCP生态系统建立在客户端-服务器模型上。这种模块化结构使AI应用能够高效地与工具、数据库、API和上下文资源进行交互。让我们将这种架构分解为其核心组件。

### 1. 主机

在模型上下文协议（MCP）中，主机作为用户与协议交互的主要界面发挥着关键作用。主机是启动与MCP服务器连接以访问数据、工具和提示的应用程序或环境。主机的例子包括集成开发环境（IDE）如Visual Studio Code、AI工具如Claude Desktop，或为特定任务设计的定制代理。

**主机**是启动连接的LLM应用程序。它们：

- 执行或与AI模型交互以生成响应。
- 启动与MCP服务器的连接。
- 管理对话流和用户界面。
- 控制权限和安全约束。
- 处理用户对数据共享和工具执行的同意。

### 2. 客户端

客户端是促进主机与MCP服务器之间交互的关键组件。客户端作为中介，帮助主机访问和利用MCP服务器提供的功能。它们在确保顺畅通信和高效数据交换方面发挥着关键作用。

**客户端**是主机应用程序中的连接器。它们：

- 向服务器发送带有提示/指令的请求。
- 与服务器协商功能。
- 管理来自模型的工具执行请求。
- 处理并向用户显示响应。

### 3. 服务器

服务器负责处理来自MCP客户端的请求并提供适当的响应。它们管理各种操作，如数据检索、工具执行和提示生成。服务器确保客户端与主机之间的通信高效可靠，维护交互过程的完整性。

**服务器**是提供上下文和功能的服务。它们：

- 注册可用的功能（资源、提示、工具）。
- 接收并执行来自客户端的工具调用。
- 提供上下文信息以增强模型响应。
- 将输出返回给客户端。
- 在需要时维护跨交互的状态。

任何人都可以开发服务器，以扩展模型功能并实现专业功能。

### 4. 服务器功能

模型上下文协议（MCP）中的服务器提供了基本构建块，使客户端、主机和语言模型之间能够进行丰富的交互。这些功能旨在通过提供结构化的上下文、工具和提示来增强MCP的能力。

MCP服务器可以提供以下任何功能：

#### 📑 资源

模型上下文协议（MCP）中的资源包含用户或AI模型可以利用的各种类型的上下文和数据，包括：

- **上下文数据**：用户或AI模型可以利用的信息和上下文，用于决策和任务执行。
- **知识库和文档库**：结构化和非结构化数据的集合，如文章、手册和研究论文，提供有价值的见解和信息。
- **本地文件和数据库**：存储在设备上或数据库中的数据，可用于处理和分析。
- **API和Web服务**：提供额外数据和功能的外部接口和服务，使能够与各种在线资源和工具集成。

资源的一个例子可以是一个数据库模式或一个文件，可以这样访问：

```text
file://log.txt
database://schema
```

### 🤖 提示

模型上下文协议（MCP）中的提示包括各种预定义的模板和交互模式，旨在简化用户工作流程并增强沟通。这些包括：

- **模板化消息和工作流程**：引导用户完成特定任务和交互的预结构化消息和流程。
- **预定义的交互模式**：标准化的动作和响应序列，促进一致和高效的沟通。
- **专业化的对话模板**：为特定类型的对话量身定制的可定制模板，确保相关和适当的交互。

提示模板可以这样看：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ 工具

模型上下文协议（MCP）中的工具是AI模型可以执行以完成特定任务的功能。这些工具旨在通过提供结构化和可靠的操作来增强AI模型的能力。关键方面包括：

- **AI模型执行的功能**：工具是AI模型可以调用以执行各种任务的可执行功能。
- **独特的名称和描述**：每个工具都有一个独特的名称和详细描述，解释其目的和功能。
- **参数和输出**：工具接受特定参数并返回结构化输出，确保结果一致和可预测。
- **离散功能**：工具执行离散功能，如网络搜索、计算和数据库查询。

一个工具的例子可以这样看：

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

## 客户端功能

在模型上下文协议（MCP）中，客户端向服务器提供几个关键功能，增强协议内的整体功能和交互。其中一个显著的功能是采样。

### 👉 采样

- **服务器启动的代理行为**：客户端使服务器能够自主启动特定动作或行为，增强系统的动态能力。
- **递归LLM交互**：此功能允许与大型语言模型（LLM）进行递归交互，使任务的处理更加复杂和迭代。
- **请求额外的模型完成**：服务器可以请求模型的额外完成，确保响应全面和上下文相关。

## MCP中的信息流

模型上下文协议（MCP）定义了主机、客户端、服务器和模型之间的信息流。理解这种流动有助于明确用户请求的处理方式，以及如何将外部工具和数据集成到模型响应中。

- **主机启动连接**  
  主机应用程序（如IDE或聊天界面）建立与MCP服务器的连接，通常通过STDIO、WebSocket或其他支持的传输。

- **功能协商**  
  嵌入在主机中的客户端和服务器交换关于其支持的功能、工具、资源和协议版本的信息。这确保双方理解会话中可用的功能。

- **用户请求**  
  用户与主机交互（例如输入提示或命令）。主机收集此输入并将其传递给客户端进行处理。

- **资源或工具使用**  
  - 客户端可能会请求服务器提供额外的上下文或资源（如文件、数据库条目或知识库文章），以丰富模型的理解。
  - 如果模型确定需要工具（例如获取数据、执行计算或调用API），客户端会向服务器发送工具调用请求，指定工具名称和参数。

- **服务器执行**  
  服务器接收资源或工具请求，执行必要的操作（如运行函数、查询数据库或检索文件），并以结构化格式将结果返回给客户端。

- **响应生成**  
  客户端将服务器的响应（资源数据、工具输出等）整合到正在进行的模型交互中。模型使用这些信息生成全面且上下文相关的响应。

- **结果呈现**  
  主机从客户端接收最终输出并呈现给用户，通常包括模型生成的文本以及工具执行或资源查找的任何结果。

这种流动使MCP能够支持先进的、互动的和上下文感知的AI应用程序，通过无缝连接模型与外部工具和数据源。

## 协议细节

MCP（模型上下文协议）建立在[JSON-RPC 2.0](https://www.jsonrpc.org/)之上，提供了一个标准化的、与语言无关的消息格式，用于主机、客户端和服务器之间的通信。这一基础使得跨不同平台和编程语言的交互可靠、结构化和可扩展。

### 关键协议功能

MCP扩展了JSON-RPC 2.0，增加了工具调用、资源访问和提示管理的附加约定。它支持多种传输层（STDIO、WebSocket、SSE），并在组件之间实现安全、可扩展和与语言无关的通信。

#### 🧢 基础协议

- **JSON-RPC消息格式**：所有请求和响应使用JSON-RPC 2.0规范，确保方法调用、参数、结果和错误处理的一致结构。
- **有状态连接**：MCP会话在多个请求中保持状态，支持持续对话、上下文积累和资源管理。
- **功能协商**：在连接设置期间，客户端和服务器交换关于支持的功能、协议版本、可用工具和资源的信息。这确保双方理解彼此的能力并能够相应地适应。

#### ➕ 附加工具

以下是MCP提供的一些附加工具和协议扩展，以增强开发者体验并实现高级场景：

- **配置选项**：MCP允许动态配置会话参数，如工具权限、资源访问和模型设置，针对每次交互进行调整。
- **进度跟踪**：长期运行的操作可以报告进度更新，在复杂任务期间提供响应的用户界面和更好的用户体验。
- **请求取消**：客户端可以取消正在进行的请求，允许用户中断不再需要或耗时过长的操作。
- **错误报告**：标准化的错误消息和代码有助于诊断问题、优雅地处理失败，并为用户和开发者提供可操作的反馈。
- **日志记录**：客户端和服务器都可以发出结构化日志，用于审计、调试和监控协议交互。

通过利用这些协议功能，MCP确保语言模型与外部工具或数据源之间的通信稳健、安全和灵活。

### 🔐 安全考虑

MCP实现应遵循几个关键的安全原则，以确保安全和可信的交互：

- **用户同意和控制**：用户必须在任何数据被访问或操作被执行之前提供明确同意。他们应该对共享的数据和授权的操作有明确控制，支持直观的用户界面来审核和批准活动。

- **数据隐私**：用户数据只有在明确同意的情况下才会被暴露，并且必须通过适当的访问控制进行保护。MCP实现必须防止未经授权的数据传输，并确保在所有交互中维护隐私。

- **工具安全**：在调用任何工具之前，需要明确的用户同意。用户应该清楚了解每个工具的功能，并且必须实施强大的安全边界，以防止意外或不安全的工具执行。

通过遵循这些原则，MCP确保用户信任、隐私和安全在所有协议交互中得到维护。

## 代码示例：关键组件

以下是几个流行编程语言中的代码示例，展示如何实现关键MCP服务器组件和工具。

### .NET示例：创建一个带工具的简单MCP服务器

这是一个实用的.NET代码示例，展示如何使用模型上下文协议实现一个简单的MCP服务器并添加自定义工具。此示例展示了如何定义和注册工具、处理请求以及连接服务器。

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

### Java示例：MCP服务器组件

这个示例演示了与上面.NET示例相同的MCP服务器和工具注册，但用Java实现。

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

### Python示例：构建MCP服务器

在这个示例中，我们展示如何在Python中构建MCP服务器。你还将看到两种不同的创建工具的方法。

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

### JavaScript示例：创建MCP服务器

这个示例展示了如何在JavaScript中创建MCP服务器，并展示了如何注册两个与天气相关的工具。

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

这个JavaScript示例展示了如何创建一个MCP客户端，该客户端连接到服务器，发送提示，并处理包括任何工具调用在内的响应。

## 安全和授权

MCP包含几个内置概念和机制，用于在整个协议中管理安全和授权：

1. **工具权限控制**：  
  客户端可以指定模型在会话期间允许使用哪些工具。这确保只有明确授权的工具是可访问的，降低了意外或不安全操作的风险。权限可以根据用户偏好、组织政策或交互上下文动态配置。

2. **身份验证**：  
  服务器可以在授予工具、资源或敏感操作访问权限之前要求身份验证。这可能涉及API密钥、OAuth令牌或其他身份验证方案。适当的身份验证确保只有可信的客户端和用户可以调用服务器端功能。

3. **验证**：  
  所有工具调用都强制执行参数验证。每个工具定义其参数的预期类型、格式和约束，服务器根据工具的架构验证传入请求。这防止了错误或恶意输入到达工具实现，并有助于维护操作的完整性。

4. **速率限制**：  
  为了防止滥用并确保公平使用服务器资源，MCP服务器可以对工具调用和资源访问实施速率限制。速率限制可以按用户、按会话或全局应用，有助于防止拒绝服务攻击或过度资源消耗。

通过结合这些机制，MCP为将语言模型与外部工具和数据源集成提供了一个安全基础，同时为用户和开发者提供了对访问和使用的细粒度控制。

## 协议消息

MCP通信使用结构化JSON消息，以促进客户端、服务器和模型之间清晰和可靠的交互。主要消息类型包括：

- **客户端请求**  
  从客户端发送到服务器的消息，通常包括：
  - 用户的提示或命令
  - 上下文的对话历史
  - 工具配置和权限
  - 任何额外的元数据或会话信息

- **模型响应**  
  由模型（通过客户端）返回的消息，包含：
  - 根据提示和上下文生成的文本或完成
  - 如果模型确定应调用工具，则可选的工具调用指令
  - 根据需要的资源或额外上下文的引用

- **工具请求**  
  当需要执行工具时，从客户端发送到服务器的消息。此消息包括：
  - 要调用的工具名称
  - 工具所需的参数（根据工具的架构验证）
  - 用于跟踪请求的上下文信息或标识符

- **工具响应**  
  服务器执行工具后返回的消息。此消息提供：
  - 工具执行的结果（结构化数据或内容）
  - 如果工具调用失败的任何错误或状态信息
  - 可选的，与执行相关的额外元数据或日志

这些结构化消息确保MCP工作流程中的每个步骤都是明确的、可追踪的和可扩展的，支持高级场景如多轮对话、工具链和稳健的错误处理。

## 关键要点

- MCP使用客户端-服务器架构将模型与外部功能连接
- 生态系统由客户端、主机、服务器、工具和数据源组成
- 通信可以通过STDIO、SSE或WebSockets进行
- 工具是向模型公开的基本功能单元
- 结构化通信协议确保一致的交互

## 练习

设计一个在你领域中有用的简单MCP工具。定义：
1. 工具的名称
2. 它接受的参数
3. 它返回的输出
4. 模型如何使用这个工具来解决用户问题

---

## 下一步

下一步：[第二章：安全](/02-Security/readme.md)

**免責聲明**：

此文件已使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。儘管我們努力確保準確性，但請注意，自動翻譯可能會包含錯誤或不準確之處。應將原始文件的母語版本視為權威來源。對於關鍵信息，建議尋求專業人工翻譯。我們不對使用此翻譯所產生的任何誤解或誤釋承擔責任。