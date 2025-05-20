<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "154c00dc3b2c792102e4845c19fbd166",
  "translation_date": "2025-05-20T16:01:05+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "zh"
}
-->
# 📖 MCP 核心概念：掌握用于 AI 集成的模型上下文协议

模型上下文协议（MCP）是一个强大且标准化的框架，优化了大型语言模型（LLMs）与外部工具、应用程序及数据源之间的通信。本文是一个经过 SEO 优化的指南，将带你深入理解 MCP 的核心概念，确保你掌握其客户端-服务器架构、关键组件、通信机制及最佳实践。

## 概述

本课将探讨构成模型上下文协议（MCP）生态系统的基础架构和组件。你将了解客户端-服务器架构、关键组件以及驱动 MCP 交互的通信机制。

## 👩‍🎓 主要学习目标

完成本课后，你将能够：

- 理解 MCP 的客户端-服务器架构。
- 明确 Hosts、Clients 和 Servers 的角色与职责。
- 分析 MCP 作为灵活集成层的核心特性。
- 了解信息在 MCP 生态系统中的流动方式。
- 通过 .NET、Java、Python 和 JavaScript 的代码示例获得实战经验。

## 🔎 MCP 架构：深入解析

MCP 生态系统基于客户端-服务器模型构建。该模块化结构使 AI 应用能够高效地与工具、数据库、API 及上下文资源交互。下面我们将拆解这一架构的核心组件。

### 1. Hosts

在模型上下文协议（MCP）中，Hosts 扮演着用户与协议交互的主要界面角色。Hosts 是启动与 MCP 服务器连接以访问数据、工具和提示的应用或环境。Host 的例子包括集成开发环境（IDE）如 Visual Studio Code、AI 工具如 Claude Desktop，或为特定任务定制的代理程序。

**Hosts** 是发起连接的 LLM 应用程序，它们：

- 执行或与 AI 模型交互以生成响应。
- 发起与 MCP 服务器的连接。
- 管理对话流程和用户界面。
- 控制权限和安全限制。
- 处理用户对数据共享和工具执行的同意。

### 2. Clients

Clients 是促进 Hosts 与 MCP 服务器交互的关键组件。Clients 作为中介，使 Hosts 能够访问和利用 MCP 服务器提供的功能。它们在确保 MCP 架构内的顺畅通信和高效数据交换中发挥重要作用。

**Clients** 是宿主应用内的连接器，它们：

- 向服务器发送带有提示/指令的请求。
- 与服务器协商功能能力。
- 管理模型发起的工具执行请求。
- 处理并向用户展示响应。

### 3. Servers

Servers 负责处理 MCP 客户端的请求并提供相应的响应。它们管理各种操作，如数据检索、工具执行和提示生成。Servers 确保客户端与 Hosts 之间的通信高效且可靠，维护交互过程的完整性。

**Servers** 是提供上下文和功能的服务，它们：

- 注册可用功能（资源、提示、工具）
- 接收并执行客户端的工具调用
- 提供上下文信息以增强模型响应
- 返回输出给客户端
- 在需要时维护交互状态

任何人都可以开发服务器，以通过专门功能扩展模型能力。

### 4. 服务器功能

模型上下文协议（MCP）中的服务器提供了基本构建模块，支持客户端、Hosts 和语言模型之间的丰富交互。这些功能旨在通过结构化的上下文、工具和提示增强 MCP 的能力。

MCP 服务器可以提供以下任意功能：

#### 📑 资源

MCP 中的资源涵盖各种可被用户或 AI 模型利用的上下文和数据类型，包括：

- **上下文数据**：用户或 AI 模型可用于决策和任务执行的信息和背景。
- **知识库和文档库**：结构化和非结构化数据集合，如文章、手册和研究论文，提供宝贵见解。
- **本地文件和数据库**：存储在设备或数据库中的数据，可供处理和分析。
- **API 和 Web 服务**：外部接口和服务，提供额外数据和功能，实现与各种在线资源和工具的集成。

资源示例可以是数据库模式或可通过如下方式访问的文件：

```text
file://log.txt
database://schema
```

### 🤖 提示
MCP 中的提示包括各种预定义模板和交互模式，旨在简化用户工作流程并提升沟通效率，包括：

- **模板化消息和工作流**：预先结构化的消息和流程，引导用户完成特定任务和交互。
- **预定义交互模式**：标准化的动作和响应序列，促进一致且高效的沟通。
- **专用会话模板**：针对特定类型对话定制的模板，确保相关且符合上下文的交互。

一个提示模板示例如下：

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ 工具

MCP 中的工具是 AI 模型可执行的函数，用于完成特定任务。这些工具旨在通过提供结构化且可靠的操作来增强 AI 模型的能力。关键点包括：

- **供 AI 模型执行的函数**：工具是可被 AI 模型调用执行的函数。
- **唯一名称和描述**：每个工具都有独特的名称和详细说明其用途和功能。
- **参数和输出**：工具接受特定参数并返回结构化输出，确保结果一致且可预测。
- **独立功能**：工具执行诸如网页搜索、计算和数据库查询等独立功能。

工具示例可参考如下：

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

## 客户端功能

在 MCP 中，客户端向服务器提供若干关键功能，增强协议内的整体功能和交互。其中一个重要功能是采样（Sampling）。

### 👉 采样

- **服务器发起的代理行为**：客户端使服务器能够自主发起特定操作或行为，增强系统的动态能力。
- **递归 LLM 交互**：该功能支持与大型语言模型的递归交互，实现更复杂和迭代的任务处理。
- **请求额外的模型补全**：服务器可以请求模型生成更多补全，确保响应全面且符合上下文。

## MCP 中的信息流

模型上下文协议（MCP）定义了 Hosts、Clients、Servers 和模型之间的结构化信息流。理解这一流程有助于明确用户请求如何被处理，以及外部工具和数据如何被集成到模型响应中。

- **Host 发起连接**  
  Host 应用（如 IDE 或聊天界面）通过 STDIO、WebSocket 或其他支持的传输方式建立与 MCP 服务器的连接。

- **能力协商**  
  嵌入在 Host 中的客户端与服务器交换支持的功能、工具、资源及协议版本信息，确保双方了解本次会话可用的能力。

- **用户请求**  
  用户与 Host 交互（例如输入提示或命令）。Host 收集输入并传递给客户端处理。

- **资源或工具使用**  
  - 客户端可能向服务器请求额外上下文或资源（如文件、数据库条目或知识库文章），以丰富模型理解。
  - 如果模型判断需要工具（例如获取数据、执行计算或调用 API），客户端会向服务器发送工具调用请求，指定工具名称和参数。

- **服务器执行**  
  服务器接收资源或工具请求，执行所需操作（如运行函数、查询数据库或检索文件），并以结构化格式将结果返回给客户端。

- **响应生成**  
  客户端将服务器响应（资源数据、工具输出等）整合进模型交互，模型据此生成全面且符合上下文的回复。

- **结果呈现**  
  Host 接收客户端的最终输出，并向用户展示，通常包括模型生成的文本及工具执行或资源查询的结果。

此流程使 MCP 能够支持先进、交互式且具上下文感知的 AI 应用，轻松连接模型与外部工具和数据源。

## 协议详情

MCP（模型上下文协议）基于 [JSON-RPC 2.0](https://www.jsonrpc.org/) 构建，提供一种标准化、语言无关的消息格式，用于 Hosts、Clients 和 Servers 之间的通信。该基础确保跨不同平台和编程语言的可靠、结构化且可扩展的交互。

### 关键协议特性

MCP 在 JSON-RPC 2.0 之上扩展了工具调用、资源访问和提示管理的约定。支持多种传输层（STDIO、WebSocket、SSE），实现组件间安全、可扩展且语言无关的通信。

#### 🧢 基础协议

- **JSON-RPC 消息格式**：所有请求和响应均采用 JSON-RPC 2.0 规范，确保方法调用、参数、结果和错误处理结构一致。
- **有状态连接**：MCP 会话在多个请求间维护状态，支持持续对话、上下文积累和资源管理。
- **能力协商**：连接建立时，客户端和服务器交换支持的功能、协议版本、可用工具和资源，确保双方理解彼此能力并作出相应调整。

#### ➕ 附加工具

以下是 MCP 提供的部分附加工具和协议扩展，用于提升开发体验和支持高级场景：

- **配置选项**：MCP 允许动态配置会话参数，如工具权限、资源访问和模型设置，针对每次交互进行定制。
- **进度跟踪**：长时间运行的操作可报告进度更新，支持响应式用户界面和更佳用户体验。
- **请求取消**：客户端可取消正在进行的请求，允许用户中断不再需要或耗时过长的操作。
- **错误报告**：标准化的错误消息和代码有助于诊断问题、优雅处理失败，并为用户和开发者提供可操作反馈。
- **日志记录**：客户端和服务器均可生成结构化日志，用于审计、调试和监控协议交互。

通过利用这些协议特性，MCP 确保语言模型与外部工具或数据源之间的通信稳健、安全且灵活。

### 🔐 安全考虑

MCP 实现应遵循若干关键安全原则，确保交互安全可信：

- **用户同意与控制**：在访问任何数据或执行操作前，必须获得用户明确同意。用户应能清晰控制共享的数据及授权的行为，并通过直观的用户界面审查和批准活动。

- **数据隐私**：用户数据仅在明确同意下暴露，且必须通过适当的访问控制保护。MCP 实现需防止未经授权的数据传输，确保在所有交互中隐私得到保障。

- **工具安全**：调用任何工具前需获得明确用户同意。用户应清楚了解每个工具的功能，且必须执行严格的安全边界，防止工具被误用或执行不安全操作。

遵循这些原则，MCP 能确保用户信任、隐私和安全在所有协议交互中得到维护。

## 代码示例：关键组件

以下是几个流行编程语言中的代码示例，展示如何实现 MCP 服务器的关键组件和工具。

### .NET 示例：创建带工具的简单 MCP 服务器

以下是一个实用的 .NET 代码示例，演示如何实现带自定义工具的简单 MCP 服务器。示例展示了如何定义和注册工具、处理请求以及使用模型上下文协议连接服务器。

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

### Java 示例：MCP 服务器组件

本示例展示了与上述 .NET 示例相同的 MCP 服务器及工具注册，但用 Java 实现。

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

### Python 示例：构建 MCP 服务器

本示例展示如何用 Python 构建 MCP 服务器，并介绍两种不同的工具创建方式。

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

### JavaScript 示例：创建 MCP 服务器

该示例展示了如何用 JavaScript 创建 MCP 服务器，并注册两个与天气相关的工具。

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

此 JavaScript 示例还演示了如何创建 MCP 客户端，连接服务器、发送提示并处理响应，包括所调用的工具。

## 安全与授权

MCP 包含若干内置概念和机制，用于管理协议中的安全和授权：

1. **工具权限控制**  
  客户端可指定模型在会话期间允许使用的工具，确保仅访问明确授权的工具，降低误用或不安全操作风险。权限可根据用户偏好、组织政策或交互上下文动态配置。

2. **身份验证**  
  服务器可要求身份验证，方可访问工具、资源或敏感操作，可能涉及 API 密钥、OAuth 令牌或其他身份验证方案。妥善的身份验证确保仅受信任的客户端和用户能调用服务器端功能。

3. **参数验证**  
  所有工具调用均强制参数验证。每个工具定义参数的预期类型、格式和约束，服务器据此验证传入请求，防止格式错误或恶意输入影响工具实现，维护操作完整性。

4. **速率限制**  
  为防止滥用并确保服务器资源公平使用，MCP 服务器可对工具调用和资源访问实施速率限制。限制可针对用户、会话或全局应用，保护系统免受拒绝服务攻击或资源过度消耗。

通过结合这些机制，MCP 为语言模型与外部工具和数据源集成提供了安全基础，同时赋予用户和开发者对访问和使用的细粒度控制。

## 协议消息

MCP 通信使用结构化 JSON 消息，促进客户端、服务器和模型之间清晰可靠的交互。主要消息类型包括：

- **客户端请求**  
  由客户端发送至服务器，通常包含：
  - 用户的提示或命令
  - 用于上下文的对话历史
  - 工具配置和权限
  - 任何附加元数据或会话信息

- **模型响应**  
  由模型（通过客户端）返回，包含：
  - 基于提示和上下文生成的文本或补全
  - 如果模型判断需调用工具，则附带工具调用指令
  - 需要时的资源或额外上下文引用

- **工具请求**  
  当需要执行工具时，由客户端发送至服务器，包含：
  - 要调用的工具名称
  - 工具所需参数（依据工具模式验证）
  - 用于跟踪请求的上下文信息或标识符

- **工具响应**  
  服务器执行工具后返回，提供：
  - 工具执行结果（结构化数据或内容）
  - 如果工具调用失败，包含错误或状态信息
  - 可选的附加元数据或执行日志

这些结构化消息确保 MCP 工作流的每一步都明确、可追踪且可扩展，支持多轮对话、工具链和健壮的错误处理等高级场景。

## 关键要点

- MCP 采用客户端-服务器架构，将模型与外部能力连接
- 生态系统由客户端、Hosts、服务器、工具和数据源组成
- 通信可通过 STDIO、SSE 或 WebSockets 实现
- 工具是向模型暴露的基本功能单元
- 结构化通信协议确保交互一致性

## 练习

设计一个适合你领域的简单 MCP 工具，定义：

1. 工具名称
2. 接受的参数
3. 返回的输出
4. 模型如何利用此工具解决用户问题

---

## 接下来

下一章：[第2章：安全](/02-Security/readme.md)

**免责声明**：  
本文件由 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。虽然我们力求准确，但请注意，自动翻译可能存在错误或不准确之处。原始文件的母语版本应被视为权威来源。对于重要信息，建议使用专业人工翻译。对于因使用本翻译而产生的任何误解或误释，我们概不负责。