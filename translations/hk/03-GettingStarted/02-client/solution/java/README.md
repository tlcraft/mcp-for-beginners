<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:06:15+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "hk"
}
-->
# MCP Java Client - Calculator Demo

呢個項目示範點樣建立一個 Java client，連接同操作 MCP（Model Context Protocol）server。今次例子會連接第一章嘅計算機 server，做唔同嘅數學運算。

## 前置條件

喺運行呢個 client 之前，你需要：

1. **啟動第一章嘅 Calculator Server**：
   - 去計算機 server 嘅目錄：`03-GettingStarted/01-first-server/solution/java/`
   - 建構同運行計算機 server：
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - Server 應該係 `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The ``

SDKClient 係一個 Java 應用程式，示範點樣：
- 用 Server-Sent Events (SSE) 傳輸方式連接 MCP server
- 列出 server 上可用嘅工具
- 遠程調用唔同嘅計算機功能
- 處理回應同顯示結果

## 運作原理

呢個 client 用 Spring AI MCP framework 去：

1. **建立連接**：創建 WebFlux SSE client 傳輸，連接計算機 server
2. **初始化 Client**：設置 MCP client 同建立連接
3. **發現工具**：列出所有可用嘅計算機操作
4. **執行操作**：用示範數據調用唔同嘅數學功能
5. **顯示結果**：展示每次計算嘅結果

## 項目結構

```
src/
└── main/
    └── java/
        └── com/
            └── microsoft/
                └── mcp/
                    └── sample/
                        └── client/
                            └── SDKClient.java    # Main client implementation
```

## 主要依賴

呢個項目用咗以下主要依賴：

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

呢個依賴提供：
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - 用於 web 通訊嘅 SSE 傳輸
- MCP 協議嘅 schema 同請求/回應類型

## 編譯項目

用 Maven wrapper 編譯項目：

```cmd
.\mvnw clean install
```

## 運行 Client

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: 確保計算機 server 係 `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080` 運行緊

2. **列出工具** - 顯示所有可用嘅計算機操作
3. **執行計算**：
   - 加法: 5 + 3 = 8
   - 減法: 10 - 4 = 6
   - 乘法: 6 × 7 = 42
   - 除法: 20 ÷ 4 = 5
   - 次方: 2^8 = 256
   - 平方根: √16 = 4
   - 絕對值: |-5.5| = 5.5
   - 幫助: 顯示可用操作

## 預期輸出

```
Available Tools = ListToolsResult[tools=[Tool[name=add, description=Add two numbers together, ...], ...]]
Add Result = CallToolResult[content=[TextContent[text="5,00 + 3,00 = 8,00"]], isError=false]
Subtract Result = CallToolResult[content=[TextContent[text="10,00 - 4,00 = 6,00"]], isError=false]
Multiply Result = CallToolResult[content=[TextContent[text="6,00 * 7,00 = 42,00"]], isError=false]
Divide Result = CallToolResult[content=[TextContent[text="20,00 / 4,00 = 5,00"]], isError=false]
Power Result = CallToolResult[content=[TextContent[text="2,00 ^ 8,00 = 256,00"]], isError=false]
Square Root Result = CallToolResult[content=[TextContent[text="√16,00 = 4,00"]], isError=false]
Absolute Result = CallToolResult[content=[TextContent[text="|-5,50| = 5,50"]], isError=false]
Help = CallToolResult[content=[TextContent[text="Basic Calculator MCP Service\n\nAvailable operations:\n1. add(a, b) - Adds two numbers\n2. subtract(a, b) - Subtracts the second number from the first\n..."]], isError=false]
```

**Note**: 你可能會見到 Maven 喺最後出現關於 lingering threads 嘅警告，呢啲喺反應式應用程式中係正常嘅，唔係錯誤。

## 了解程式碼

### 1. 傳輸設置
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
呢段係建立一個 SSE（Server-Sent Events）傳輸，連接計算機 server。

### 2. 創建 Client
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
創建一個同步 MCP client 同初始化連接。

### 3. 調用工具
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
用參數 a=5.0 同 b=3.0 調用 “add” 工具。

## 故障排除

### Server 未運行
如果連接出錯，確保第一章嘅計算機 server 係運行緊：
```
Error: Connection refused
```
**解決方法**：先啟動計算機 server。

### 埠口已被使用
如果 8080 埠口被佔用：
```
Error: Address already in use
```
**解決方法**：停止其他使用 8080 埠口嘅應用程式，或者改用其他埠口。

### 編譯錯誤
如果遇到編譯錯誤：
```cmd
.\mvnw clean install -DskipTests
```

## 深入了解

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**免責聲明**：  
本文件係使用 AI 翻譯服務 [Co-op Translator](https://github.com/Azure/co-op-translator) 進行翻譯。雖然我哋致力於準確性，但請注意，自動翻譯可能包含錯誤或不準確之處。原文文件嘅母語版本應視為權威來源。對於重要資訊，建議採用專業人手翻譯。我哋對因使用此翻譯而引致嘅任何誤解或誤釋概不負責。