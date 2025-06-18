<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "acd4010e430da00946a154f62847a169",
  "translation_date": "2025-06-18T09:44:08+00:00",
  "source_file": "03-GettingStarted/06-http-streaming/solution/java/README.md",
  "language_code": "zh"
}
-->
# Calculator HTTP Streaming Demo

本项目演示了使用 Spring Boot WebFlux 通过 Server-Sent Events (SSE) 实现的 HTTP 流式传输。它包含两个应用：

- **Calculator Server**：一个响应式 Web 服务，执行计算并通过 SSE 流式传输结果
- **Calculator Client**：一个客户端应用，消费流式传输的端点

## 前提条件

- Java 17 或更高版本
- Maven 3.6 或更高版本

## 项目结构

```
java/
├── calculator-server/     # Spring Boot server with SSE endpoint
│   ├── src/main/java/com/example/calculatorserver/
│   │   ├── CalculatorServerApplication.java
│   │   └── CalculatorController.java
│   └── pom.xml
├── calculator-client/     # Spring Boot client application
│   ├── src/main/java/com/example/calculatorclient/
│   │   └── CalculatorClientApplication.java
│   └── pom.xml
└── README.md
```

## 工作原理

1. **Calculator Server** 暴露 `/calculate` endpoint that:
   - Accepts query parameters: `a` (number), `b` (number), `op` (operation)
   - Supported operations: `add`, `sub`, `mul`, `div`
   - Returns Server-Sent Events with calculation progress and result

2. The **Calculator Client** connects to the server and:
   - Makes a request to calculate `7 * 5`
   - 消费流式响应
   - 将每个事件打印到控制台

## 运行应用程序

### 选项 1：使用 Maven（推荐）

#### 1. 启动 Calculator Server

打开终端并切换到服务器目录：

```bash
cd calculator-server
mvn clean package
mvn spring-boot:run
```

服务器将在 `http://localhost:8080` 启动

你会看到类似如下输出：
```
Started CalculatorServerApplication in X.XXX seconds
Netty started on port 8080 (http)
```

#### 2. 运行 Calculator Client

打开一个**新终端**并切换到客户端目录：

```bash
cd calculator-client
mvn clean package
mvn spring-boot:run
```

客户端将连接服务器，执行计算，并显示流式结果。

### 选项 2：直接使用 Java

#### 1. 编译并运行服务器：

```bash
cd calculator-server
mvn clean package
java -jar target/calculator-server-0.0.1-SNAPSHOT.jar
```

#### 2. 编译并运行客户端：

```bash
cd calculator-client
mvn clean package
java -jar target/calculator-client-0.0.1-SNAPSHOT.jar
```

## 手动测试服务器

你也可以使用浏览器或 curl 测试服务器：

### 使用浏览器：
访问：`http://localhost:8080/calculate?a=10&b=5&op=add`

### 使用 curl：
```bash
curl "http://localhost:8080/calculate?a=10&b=5&op=add" -H "Accept: text/event-stream"
```

## 预期输出

运行客户端时，你应看到类似如下的流式输出：

```
event:info
data:Calculating: 7.0 mul 5.0

event:result
data:35.0
```

## 支持的操作

- `add` - Addition (a + b)
- `sub` - Subtraction (a - b)
- `mul` - Multiplication (a * b)
- `div` - Division (a / b, returns NaN if b = 0)

## API Reference

### GET /calculate

**Parameters:**
- `a` (required): First number (double)
- `b` (required): Second number (double)
- `op` (required): Operation (`add`, `sub`, `mul`, `div`)

**Response:**
- Content-Type: `text/event-stream`
- 返回包含计算进度和结果的 Server-Sent Events

**示例请求：**
```
GET /calculate?a=7&b=5&op=mul HTTP/1.1
Host: localhost:8080
Accept: text/event-stream
```

**示例响应：**
```
event: info
data: Calculating: 7.0 mul 5.0

event: result
data: 35.0
```

## 故障排除

### 常见问题

1. **端口 8080 已被占用**
   - 停止占用端口 8080 的其他应用
   - 或修改 `calculator-server/src/main/resources/application.yml`

2. **Connection refused**
   - Make sure the server is running before starting the client
   - Check that the server started successfully on port 8080

3. **Parameter name issues**
   - This project includes Maven compiler configuration with `-parameters` flag
   - If you encounter parameter binding issues, ensure the project is built with this configuration

### Stopping the Applications

- Press `Ctrl+C` in the terminal where each application is running
- Or use `mvn spring-boot:stop` 中的服务器端口（如果作为后台进程运行）

## 技术栈

- **Spring Boot 3.3.1** - 应用框架
- **Spring WebFlux** - 响应式 Web 框架
- **Project Reactor** - 响应式流库
- **Netty** - 非阻塞 I/O 服务器
- **Maven** - 构建工具
- **Java 17+** - 编程语言

## 后续步骤

尝试修改代码以实现：
- 添加更多数学运算
- 为无效操作添加错误处理
- 添加请求/响应日志
- 实现身份验证
- 添加单元测试

**免责声明**：  
本文件使用 AI 翻译服务 [Co-op Translator](https://github.com/Azure/co-op-translator) 进行翻译。尽管我们力求准确，但请注意自动翻译可能包含错误或不准确之处。原始语言的文档应被视为权威来源。对于重要信息，建议采用专业人工翻译。对于因使用本翻译而产生的任何误解或曲解，我们概不负责。