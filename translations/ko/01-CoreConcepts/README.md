<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "056918462dca9b8f75901709fb8f470c",
  "translation_date": "2025-05-16T15:48:13+00:00",
  "source_file": "01-CoreConcepts/README.md",
  "language_code": "ko"
}
-->
# 📖 MCP 핵심 개념: AI 통합을 위한 모델 컨텍스트 프로토콜 마스터하기

Model Context Protocol(MCP)은 대형 언어 모델(LLM)과 외부 도구, 애플리케이션, 데이터 소스 간의 통신을 최적화하는 강력하고 표준화된 프레임워크입니다. 이 SEO 최적화 가이드에서는 MCP의 클라이언트-서버 아키텍처, 핵심 구성 요소, 통신 메커니즘, 구현 모범 사례를 이해할 수 있도록 안내합니다.

## 개요

이 강의에서는 MCP 생태계를 구성하는 기본 아키텍처와 구성 요소를 살펴봅니다. MCP 상호작용을 구동하는 클라이언트-서버 아키텍처, 주요 구성 요소, 통신 메커니즘에 대해 배우게 됩니다.

## 👩‍🎓 주요 학습 목표

이 강의를 마치면 다음을 할 수 있습니다:

- MCP 클라이언트-서버 아키텍처 이해
- Hosts, Clients, Servers의 역할과 책임 파악
- MCP를 유연한 통합 계층으로 만드는 핵심 기능 분석
- MCP 생태계 내 정보 흐름 이해
- .NET, Java, Python, JavaScript 코드 예제를 통한 실용적 인사이트 획득

## 🔎 MCP 아키텍처: 자세히 들여다보기

MCP 생태계는 클라이언트-서버 모델을 기반으로 합니다. 이 모듈식 구조는 AI 애플리케이션이 도구, 데이터베이스, API, 컨텍스트 리소스와 효율적으로 상호작용할 수 있도록 합니다. 이제 이 아키텍처의 핵심 구성 요소를 살펴보겠습니다.

### 1. Hosts

Model Context Protocol(MCP)에서 Hosts는 사용자가 프로토콜과 상호작용하는 주요 인터페이스 역할을 합니다. Hosts는 MCP 서버와 연결을 시작하여 데이터, 도구, 프롬프트에 접근하는 애플리케이션 또는 환경입니다. 예로는 Visual Studio Code 같은 통합 개발 환경(IDE), Claude Desktop 같은 AI 도구, 특정 작업을 위해 설계된 맞춤형 에이전트가 있습니다.

**Hosts**는 LLM 애플리케이션으로서 연결을 시작합니다. 이들은:

- AI 모델과 상호작용하거나 실행하여 응답을 생성
- MCP 서버와 연결을 시작
- 대화 흐름과 사용자 인터페이스 관리
- 권한 및 보안 제어
- 데이터 공유 및 도구 실행에 대한 사용자 동의 처리

### 2. Clients

Clients는 Hosts와 MCP 서버 간 상호작용을 원활하게 하는 필수 구성 요소입니다. Clients는 중개자 역할을 하며 Hosts가 MCP 서버가 제공하는 기능을 이용할 수 있도록 지원합니다. MCP 아키텍처 내에서 원활한 통신과 효율적인 데이터 교환을 보장하는 중요한 역할을 수행합니다.

**Clients**는 호스트 애플리케이션 내의 커넥터입니다. 이들은:

- 서버에 프롬프트/명령어와 함께 요청 전송
- 서버와 기능 협상 수행
- 모델로부터의 도구 실행 요청 관리
- 사용자에게 응답 처리 및 표시

### 3. Servers

Servers는 MCP 클라이언트의 요청을 처리하고 적절한 응답을 제공하는 역할을 합니다. 데이터 검색, 도구 실행, 프롬프트 생성 등의 다양한 작업을 관리합니다. 서버는 클라이언트와 Hosts 간 통신이 효율적이고 신뢰할 수 있도록 하며 상호작용 과정의 무결성을 유지합니다.

**Servers**는 컨텍스트와 기능을 제공하는 서비스입니다. 이들은:

- 사용 가능한 기능(리소스, 프롬프트, 도구) 등록
- 클라이언트의 도구 호출 수신 및 실행
- 모델 응답을 향상시키기 위한 컨텍스트 정보 제공
- 결과를 클라이언트에 반환
- 필요 시 상호작용 간 상태 유지

서버는 누구나 특화된 기능으로 모델 역량을 확장하기 위해 개발할 수 있습니다.

### 4. Server Features

MCP의 서버는 클라이언트, 호스트, 언어 모델 간 풍부한 상호작용을 가능하게 하는 기본 빌딩 블록을 제공합니다. 이 기능들은 구조화된 컨텍스트, 도구, 프롬프트를 제공하여 MCP의 역량을 강화하도록 설계되었습니다.

MCP 서버는 다음과 같은 기능을 제공할 수 있습니다:

#### 📑 Resources

MCP에서 Resources는 사용자나 AI 모델이 활용할 수 있는 다양한 유형의 컨텍스트와 데이터를 포함합니다. 예를 들어:

- **컨텍스트 데이터**: 의사결정과 작업 수행에 활용 가능한 정보 및 컨텍스트
- **지식 기반 및 문서 저장소**: 기사, 매뉴얼, 연구 논문 등 구조화 및 비구조화된 데이터 모음
- **로컬 파일 및 데이터베이스**: 장치나 데이터베이스에 로컬 저장된 데이터로 처리 및 분석 가능
- **API 및 웹 서비스**: 다양한 온라인 리소스 및 도구와 통합할 수 있는 외부 인터페이스 및 서비스

리소스의 예시는 데이터베이스 스키마나 다음과 같이 접근 가능한 파일입니다:

```text
file://log.txt
database://schema
```

### 🤖 Prompts

MCP의 Prompts는 사용자 워크플로우를 간소화하고 커뮤니케이션을 향상시키기 위해 설계된 다양한 사전 정의된 템플릿과 상호작용 패턴을 포함합니다. 예를 들어:

- **템플릿화된 메시지 및 워크플로우**: 특정 작업과 상호작용을 안내하는 사전 구조화된 메시지 및 프로세스
- **사전 정의된 상호작용 패턴**: 일관되고 효율적인 커뮤니케이션을 위한 표준화된 행동 및 응답 순서
- **특화된 대화 템플릿**: 특정 유형의 대화에 맞춘 맞춤형 템플릿으로 적절하고 상황에 맞는 상호작용 보장

프롬프트 템플릿 예시는 다음과 같습니다:

```markdown
Generate a product slogan based on the following {{product}} with the following {{keywords}}
```

#### ⛏️ Tools

MCP의 Tools는 AI 모델이 특정 작업을 수행하기 위해 실행할 수 있는 함수들입니다. 이 도구들은 구조화되고 신뢰할 수 있는 작업을 제공하여 AI 모델의 역량을 향상시킵니다. 주요 특징은 다음과 같습니다:

- **AI 모델이 실행할 함수**: 도구는 AI 모델이 호출해 다양한 작업을 수행할 수 있는 실행 가능한 함수입니다.
- **고유 이름과 설명**: 각 도구는 목적과 기능을 설명하는 고유 이름과 상세 설명을 가집니다.
- **매개변수와 출력**: 도구는 특정 매개변수를 받고 구조화된 출력을 반환하여 일관되고 예측 가능한 결과 보장
- **독립적인 기능 수행**: 웹 검색, 계산, 데이터베이스 쿼리 등 독립적 기능 수행

도구 예시는 다음과 같습니다:

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

MCP에서 클라이언트는 서버에 여러 핵심 기능을 제공하여 프로토콜 내 상호작용과 기능을 강화합니다. 그중 하나가 Sampling입니다.

### 👉 Sampling

- **서버 주도 에이전틱 행동**: 클라이언트는 서버가 특정 행동이나 작업을 자율적으로 시작할 수 있게 하여 시스템의 동적 기능 강화
- **재귀적 LLM 상호작용**: 이 기능은 대형 언어 모델과의 반복적 상호작용을 가능하게 하여 더 복잡하고 반복적인 작업 처리 지원
- **추가 모델 완성 요청**: 서버는 모델에 추가 완성을 요청하여 응답이 충분하고 상황에 맞도록 보장

## MCP 내 정보 흐름

MCP는 Hosts, Clients, Servers, Models 간 정보 흐름을 구조화하여 사용자 요청 처리 및 외부 도구와 데이터 통합 방식을 명확히 합니다.

- **Host가 연결 시작**  
  IDE나 채팅 인터페이스 같은 호스트 애플리케이션이 보통 STDIO, WebSocket 등 지원되는 전송 방식을 통해 MCP 서버와 연결을 설정합니다.

- **기능 협상**  
  호스트 내 클라이언트와 서버는 지원하는 기능, 도구, 리소스, 프로토콜 버전에 대해 정보를 교환하여 세션에 사용 가능한 기능을 상호 이해합니다.

- **사용자 요청**  
  사용자가 호스트와 상호작용(예: 프롬프트나 명령 입력)하면, 호스트가 입력을 수집해 클라이언트에 전달합니다.

- **리소스 또는 도구 사용**  
  - 클라이언트는 모델 이해를 돕기 위해 서버에 추가 컨텍스트나 리소스(파일, 데이터베이스 항목, 지식 기반 문서 등)를 요청할 수 있습니다.  
  - 모델이 도구 사용이 필요하다고 판단하면(예: 데이터 조회, 계산, API 호출), 클라이언트는 도구 이름과 매개변수를 명시해 서버에 도구 호출 요청을 보냅니다.

- **서버 실행**  
  서버는 리소스나 도구 요청을 받아 필요한 작업(함수 실행, 데이터베이스 쿼리, 파일 조회 등)을 수행하고 결과를 구조화된 형식으로 클라이언트에 반환합니다.

- **응답 생성**  
  클라이언트는 서버 응답(리소스 데이터, 도구 출력 등)을 현재 모델 상호작용에 통합합니다. 모델은 이를 활용해 포괄적이고 상황에 적합한 응답을 생성합니다.

- **결과 표시**  
  호스트는 클라이언트로부터 최종 출력을 받아 사용자에게 보여줍니다. 여기에는 모델이 생성한 텍스트와 도구 실행 또는 리소스 조회 결과가 포함될 수 있습니다.

이 흐름 덕분에 MCP는 모델과 외부 도구 및 데이터 소스를 원활하게 연결해 고급, 상호작용적, 상황 인지 AI 애플리케이션을 지원합니다.

## 프로토콜 세부 사항

MCP(Model Context Protocol)는 [JSON-RPC 2.0](https://www.jsonrpc.org/) 위에 구축되어 호스트, 클라이언트, 서버 간 통신을 위한 표준화되고 언어에 구애받지 않는 메시지 형식을 제공합니다. 이를 통해 다양한 플랫폼과 프로그래밍 언어에서 신뢰할 수 있고 구조화된 확장 가능한 상호작용이 가능합니다.

### 주요 프로토콜 기능

MCP는 도구 호출, 리소스 접근, 프롬프트 관리를 위한 추가 규칙을 JSON-RPC 2.0에 확장합니다. STDIO, WebSocket, SSE 등 다양한 전송 계층을 지원하며, 컴포넌트 간 안전하고 확장 가능하며 언어 독립적인 통신을 가능하게 합니다.

#### 🧢 기본 프로토콜

- **JSON-RPC 메시지 형식**: 모든 요청과 응답은 JSON-RPC 2.0 명세를 따르며, 메서드 호출, 매개변수, 결과, 오류 처리의 일관된 구조를 보장합니다.
- **상태 유지 연결**: MCP 세션은 여러 요청에 걸쳐 상태를 유지하며, 지속적인 대화, 컨텍스트 누적, 리소스 관리를 지원합니다.
- **기능 협상**: 연결 설정 시 클라이언트와 서버는 지원 기능, 프로토콜 버전, 사용 가능한 도구 및 리소스 정보를 교환하여 서로의 역량을 이해하고 적응할 수 있습니다.

#### ➕ 추가 유틸리티

다음은 MCP가 개발자 경험을 향상하고 고급 시나리오를 지원하기 위해 제공하는 몇 가지 추가 기능과 프로토콜 확장입니다:

- **구성 옵션**: MCP는 세션 매개변수(도구 권한, 리소스 접근, 모델 설정 등)를 동적으로 구성할 수 있어 각 상호작용에 맞게 조정 가능합니다.
- **진행 상황 추적**: 장기 실행 작업은 진행 상황 업데이트를 보고할 수 있어 복잡한 작업 중 사용자 인터페이스의 반응성과 사용자 경험을 향상합니다.
- **요청 취소**: 클라이언트는 진행 중인 요청을 취소할 수 있어, 더 이상 필요 없거나 오래 걸리는 작업을 중단할 수 있습니다.
- **오류 보고**: 표준화된 오류 메시지와 코드는 문제 진단, 실패 처리, 사용자 및 개발자에게 실행 가능한 피드백 제공에 도움을 줍니다.
- **로깅**: 클라이언트와 서버 모두 감사, 디버깅, 프로토콜 상호작용 모니터링을 위한 구조화된 로그를 생성할 수 있습니다.

이러한 프로토콜 기능을 활용해 MCP는 언어 모델과 외부 도구 및 데이터 소스 간의 견고하고 안전하며 유연한 통신을 보장합니다.

### 🔐 보안 고려사항

MCP 구현은 안전하고 신뢰할 수 있는 상호작용을 위해 다음 주요 보안 원칙을 준수해야 합니다:

- **사용자 동의 및 제어**: 데이터 접근이나 작업 수행 전 명시적 사용자 동의를 받아야 하며, 사용자는 어떤 데이터가 공유되고 어떤 작업이 승인되는지 명확히 제어할 수 있어야 합니다. 직관적인 사용자 인터페이스를 통해 활동을 검토하고 승인할 수 있어야 합니다.

- **데이터 프라이버시**: 사용자 데이터는 명확한 동의 하에만 노출되어야 하며 적절한 접근 제어로 보호되어야 합니다. MCP 구현은 무단 데이터 전송을 방지하고 모든 상호작용에서 프라이버시를 유지해야 합니다.

- **도구 안전성**: 도구 호출 전 명확한 사용자 동의가 필요합니다. 사용자는 각 도구의 기능을 명확히 이해해야 하며, 의도치 않거나 위험한 도구 실행을 막기 위한 견고한 보안 경계가 적용되어야 합니다.

이 원칙들을 따르면 MCP는 프로토콜 상호작용 전반에 걸쳐 사용자 신뢰, 프라이버시, 안전을 보장합니다.

## 코드 예제: 핵심 구성 요소

다음은 여러 인기 프로그래밍 언어로 작성된 코드 예제로, 주요 MCP 서버 구성 요소와 도구 구현 방법을 보여줍니다.

### .NET 예제: 도구가 포함된 간단한 MCP 서버 생성

아래 .NET 코드 예제는 맞춤 도구를 포함한 간단한 MCP 서버 구현 방법을 보여줍니다. 도구 정의 및 등록, 요청 처리, MCP 프로토콜을 통한 서버 연결 방식을 시연합니다.

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

### Java 예제: MCP 서버 구성 요소

이 예제는 위 .NET 예제와 동일한 MCP 서버 및 도구 등록을 Java로 구현한 것입니다.

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

### Python 예제: MCP 서버 구축

이 예제에서는 Python으로 MCP 서버를 구축하는 방법을 보여줍니다. 또한 두 가지 다른 도구 생성 방법도 함께 설명합니다.

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

### JavaScript 예제: MCP 서버 생성

이 예제는 JavaScript로 MCP 서버를 생성하고, 날씨 관련 두 도구를 등록하는 방법을 보여줍니다.

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

이 JavaScript 예제는 서버에 연결하고 프롬프트를 전송하며, 도구 호출이 포함된 응답을 처리하는 MCP 클라이언트 생성 방법도 시연합니다.

## 보안 및 권한 부여

MCP는 프로토콜 전반에 걸쳐 보안과 권한 관리를 위한 여러 내장 개념과 메커니즘을 포함합니다:

1. **도구 권한 제어**  
  클라이언트는 세션 중 모델이 사용할 수 있는 도구를 지정할 수 있습니다. 이를 통해 명시적으로 허가된 도구만 접근 가능하게 하여 의도치 않거나 위험한 작업 위험을 줄입니다. 권한은 사용자 선호도, 조직 정책, 상호작용 컨텍스트에 따라 동적으로 설정할 수 있습니다.

2. **인증**  
  서버는 도구, 리소스, 민감한 작업 접근 전에 인증을 요구할 수 있습니다. API 키, OAuth 토큰, 기타 인증 방식이 사용될 수 있으며, 적절한 인증은 신뢰할 수 있는 클라이언트와 사용자만 서버 기능을 호출하도록 보장합니다.

3. **검증**  
  모든 도구 호출에 대해 매개변수 검증이 시행됩니다. 각 도구는 예상 타입, 형식, 제약 조건을 정의하며, 서버는 들어오는 요청을 이에 따라 검증합니다. 이는 잘못되거나 악의적인 입력이 도구 구현에 도달하는 것을 방지하고 작업 무결성을 유지하는 데 도움을 줍니다.

4. **요율 제한**  
  서버 자원 남용을 막고 공정한 사용을 보장하기 위해 MCP 서버는 도구 호출과 리소스 접근에 대해 요율 제한을 구현할 수 있습니다. 요율 제한은 사용자별, 세션별, 전역적으로 적용 가능하며 서비스 거부 공격이나 과도한 자원 사용으로부터 보호합니다.

이 메커니즘들을 결합해 MCP는 언어 모델과 외부 도구 및 데이터 소스 통합을 위한 안전한 기반을 제공하며, 사용자와 개발자에게 세밀한 접근 및 사용 제어 권한을 부여합니다.

## 프로토콜 메시지

MCP 통신은 클라이언트, 서버, 모델 간 명확하고 신뢰할 수 있는 상호작용을 위한 구조화된 JSON 메시지를 사용합니다. 주요 메시지 유형은 다음과 같습니다:

- **클라이언트 요청**  
  클라이언트가 서버에 보내는 메시지로, 일반적으로 다음을 포함합니다:  
  - 사용자의 프롬프트 또는 명령  
  - 컨텍스트를 위한 대화 기록  
  - 도구 구성 및 권한  
  - 추가 메타데이터나 세션 정보

- **모델 응답**  
  모델(클라이언트를 통해)에서 반환하는 메시지로, 다음을 포함합니다:  
  - 프롬프트와 컨텍스트에 기반한 생성 텍스트 또는 완성  
  - 모델이 도구 호출이 필요하다고 판단할 경우 선택적 도구 호출 지침  
  - 필요에

**면책 조항**:  
이 문서는 AI 번역 서비스 [Co-op Translator](https://github.com/Azure/co-op-translator)를 사용하여 번역되었습니다. 정확성을 위해 최선을 다하고 있으나, 자동 번역에는 오류나 부정확한 부분이 있을 수 있음을 유의하시기 바랍니다. 원본 문서의 원어 버전이 권위 있는 출처로 간주되어야 합니다. 중요한 정보의 경우 전문적인 인간 번역을 권장합니다. 본 번역 사용으로 인해 발생하는 오해나 잘못된 해석에 대해서는 당사가 책임지지 않습니다.