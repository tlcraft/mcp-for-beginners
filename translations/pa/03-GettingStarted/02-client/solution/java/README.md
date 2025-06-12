<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:09:06+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "pa"
}
-->
# MCP Java Client - ਕੈਲਕੂਲੇਟਰ ਡੈਮੋ

ਇਹ ਪ੍ਰੋਜੈਕਟ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ ਕਿਵੇਂ ਇੱਕ Java ਕਲਾਇੰਟ ਬਣਾਇਆ ਜਾ ਸਕਦਾ ਹੈ ਜੋ MCP (Model Context Protocol) ਸਰਵਰ ਨਾਲ ਜੁੜਦਾ ਹੈ ਅਤੇ ਇਸ ਨਾਲ ਇੰਟਰੈਕਟ ਕਰਦਾ ਹੈ। ਇਸ ਉਦਾਹਰਨ ਵਿੱਚ, ਅਸੀਂ ਚੈਪਟਰ 01 ਦੇ ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ ਨਾਲ ਜੁੜ ਕੇ ਵੱਖ-ਵੱਖ ਗਣਿਤੀ ਕਾਰਜ ਕਰਾਂਗੇ।

## ਲੋੜੀਂਦੇ ਪੂਰਵ-ਸ਼ਰਤਾਂ

ਇਸ ਕਲਾਇੰਟ ਨੂੰ ਚਲਾਉਣ ਤੋਂ ਪਹਿਲਾਂ ਤੁਹਾਨੂੰ:

1. **ਚੈਪਟਰ 01 ਤੋਂ ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰੋ**:
   - ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ ਡਾਇਰੈਕਟਰੀ ਵਿੱਚ ਜਾਓ: `03-GettingStarted/01-first-server/solution/java/`
   - ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ ਬਣਾਓ ਅਤੇ ਚਲਾਓ:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - ਸਰਵਰ `http://localhost:8080` 'ਤੇ ਚੱਲ ਰਿਹਾ ਹੋਣਾ ਚਾਹੀਦਾ ਹੈ

`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient ਇੱਕ Java ਐਪਲੀਕੇਸ਼ਨ ਹੈ ਜੋ ਦਿਖਾਉਂਦਾ ਹੈ ਕਿ ਕਿਵੇਂ:
- Server-Sent Events (SSE) ਟਰਾਂਸਪੋਰਟ ਦੀ ਵਰਤੋਂ ਕਰਕੇ MCP ਸਰਵਰ ਨਾਲ ਜੁੜਿਆ ਜਾਵੇ
- ਸਰਵਰ ਤੋਂ ਉਪਲਬਧ ਟੂਲਾਂ ਦੀ ਸੂਚੀ ਪ੍ਰਾਪਤ ਕੀਤੀ ਜਾਵੇ
- ਵੱਖ-ਵੱਖ ਕੈਲਕੂਲੇਟਰ ਫੰਕਸ਼ਨਾਂ ਨੂੰ ਦੂਰੇ ਤੌਰ 'ਤੇ ਕਾਲ ਕੀਤਾ ਜਾਵੇ
- ਜਵਾਬਾਂ ਨੂੰ ਹੈਂਡਲ ਕਰਕੇ ਨਤੀਜੇ ਦਿਖਾਏ ਜਾਣ

## ਇਹ ਕਿਵੇਂ ਕੰਮ ਕਰਦਾ ਹੈ

ਕਲਾਇੰਟ Spring AI MCP ਫਰੇਮਵਰਕ ਦੀ ਵਰਤੋਂ ਕਰਦਾ ਹੈ:

1. **ਕਨੈਕਸ਼ਨ ਸਥਾਪਿਤ ਕਰਨਾ**: ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ ਨਾਲ ਜੁੜਨ ਲਈ WebFlux SSE ਕਲਾਇੰਟ ਟਰਾਂਸਪੋਰਟ ਬਣਾਉਂਦਾ ਹੈ
2. **ਕਲਾਇੰਟ ਸ਼ੁਰੂ ਕਰਨਾ**: MCP ਕਲਾਇੰਟ ਸੈੱਟਅਪ ਕਰਦਾ ਹੈ ਅਤੇ ਕਨੈਕਸ਼ਨ ਸਥਾਪਿਤ ਕਰਦਾ ਹੈ
3. **ਟੂਲਾਂ ਦੀ ਖੋਜ**: ਸਾਰੇ ਉਪਲਬਧ ਕੈਲਕੂਲੇਟਰ ਆਪਰੇਸ਼ਨਾਂ ਦੀ ਸੂਚੀ ਦਿਖਾਉਂਦਾ ਹੈ
4. **ਕਾਰਜ ਕਰਵਾਉਣਾ**: ਉਦਾਹਰਨ ਲਈ ਵੱਖ-ਵੱਖ ਗਣਿਤੀ ਫੰਕਸ਼ਨਾਂ ਨੂੰ ਕਾਲ ਕਰਦਾ ਹੈ
5. **ਨਤੀਜੇ ਦਿਖਾਉਣਾ**: ਹਰ ਗਣਨਾ ਦੇ ਨਤੀਜੇ ਵੇਖਾਉਂਦਾ ਹੈ

## ਪ੍ਰੋਜੈਕਟ ਸਟਰੱਕਚਰ

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

## ਮੁੱਖ Dependencies

ਪ੍ਰੋਜੈਕਟ ਵਿੱਚ ਹੇਠਾਂ ਦਿੱਤੇ ਮੁੱਖ dependencies ਹਨ:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

ਇਹ dependency ਮੁਹੱਈਆ ਕਰਦਾ ਹੈ:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - ਵੈੱਬ-ਅਧਾਰਿਤ ਸੰਚਾਰ ਲਈ SSE ਟਰਾਂਸਪੋਰਟ
- MCP ਪ੍ਰੋਟੋਕੋਲ schemas ਅਤੇ request/response ਕਿਸਮਾਂ

## ਪ੍ਰੋਜੈਕਟ ਬਣਾਉਣਾ

Maven wrapper ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਪ੍ਰੋਜੈਕਟ ਬਣਾਓ:

```cmd
.\mvnw clean install
```

## ਕਲਾਇੰਟ ਚਲਾਉਣਾ

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ `http://localhost:8080` 'ਤੇ ਚੱਲ ਰਿਹਾ ਹੈ

2. **ਟੂਲਾਂ ਦੀ ਸੂਚੀ** - ਸਾਰੇ ਉਪਲਬਧ ਕੈਲਕੂਲੇਟਰ ਆਪਰੇਸ਼ਨਾਂ ਨੂੰ ਦਿਖਾਉਂਦਾ ਹੈ  
3. **ਗਣਨਾਵਾਂ ਕਰਵਾਉਣਾ**:  
   - ਜੋੜ: 5 + 3 = 8  
   - ਘਟਾਓ: 10 - 4 = 6  
   - ਗੁਣਾ: 6 × 7 = 42  
   - ਭਾਗ: 20 ÷ 4 = 5  
   - ਘਾਤ: 2^8 = 256  
   - ਵਰਗਮੂਲ: √16 = 4  
   - ਪਰਮਾਣੂ ਮੁੱਲ: |-5.5| = 5.5  
   - ਮਦਦ: ਉਪਲਬਧ ਕਾਰਜ ਦਿਖਾਉਂਦਾ ਹੈ

## ਉਮੀਦ ਕੀਤੀ ਨਤੀਜਾ

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

**Note**: Maven ਚਲਾਉਂਦੇ ਸਮੇਂ ਅੰਤ ਵਿੱਚ ਕੁਝ lingering threads ਬਾਰੇ ਵਾਰਨਿੰਗ ਆ ਸਕਦੀ ਹੈ - ਇਹ reactive ਐਪਲੀਕੇਸ਼ਨਾਂ ਲਈ ਸਧਾਰਣ ਗੱਲ ਹੈ ਅਤੇ ਕੋਈ ਗਲਤੀ ਨਹੀਂ ਹੈ।

## ਕੋਡ ਨੂੰ ਸਮਝਣਾ

### 1. ਟਰਾਂਸਪੋਰਟ ਸੈਟਅਪ  
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```  
ਇਹ ਇੱਕ SSE (Server-Sent Events) ਟਰਾਂਸਪੋਰਟ ਬਣਾਉਂਦਾ ਹੈ ਜੋ ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ ਨਾਲ ਜੁੜਦਾ ਹੈ।

### 2. ਕਲਾਇੰਟ ਬਣਾਉਣਾ  
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```  
ਇੱਕ synchronous MCP ਕਲਾਇੰਟ ਬਣਾਉਂਦਾ ਹੈ ਅਤੇ ਕਨੈਕਸ਼ਨ ਸੈੱਟਅਪ ਕਰਦਾ ਹੈ।

### 3. ਟੂਲਾਂ ਨੂੰ ਕਾਲ ਕਰਨਾ  
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```  
"add" ਟੂਲ ਨੂੰ ਪੈਰਾਮੀਟਰ a=5.0 ਅਤੇ b=3.0 ਨਾਲ ਕਾਲ ਕਰਦਾ ਹੈ।

## ਸਮੱਸਿਆ ਹੱਲ

### ਸਰਵਰ ਚੱਲ ਨਹੀਂ ਰਿਹਾ  
ਜੇ ਤੁਸੀਂ ਕਨੈਕਸ਼ਨ ਵਿੱਚ ਗਲਤੀ ਪਾਉਂਦੇ ਹੋ, ਤਾਂ ਯਕੀਨੀ ਬਣਾਓ ਕਿ ਚੈਪਟਰ 01 ਤੋਂ ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ ਚੱਲ ਰਿਹਾ ਹੈ:  
```
Error: Connection refused
```  
**Solution**: ਪਹਿਲਾਂ ਕੈਲਕੂਲੇਟਰ ਸਰਵਰ ਸ਼ੁਰੂ ਕਰੋ।

### ਪੋਰਟ ਪਹਿਲਾਂ ਹੀ ਵਰਤਿਆ ਜਾ ਰਿਹਾ ਹੈ  
ਜੇ ਪੋਰਟ 8080 ਬਿਜੀ ਹੈ:  
```
Error: Address already in use
```  
**Solution**: 8080 ਪੋਰਟ ਵਰਤ ਰਹੀਆਂ ਹੋਰ ਐਪਲੀਕੇਸ਼ਨਾਂ ਨੂੰ ਬੰਦ ਕਰੋ ਜਾਂ ਸਰਵਰ ਨੂੰ ਵੱਖਰਾ ਪੋਰਟ ਵਰਤਣ ਲਈ ਬਦਲੋ।

### ਬਣਾਉਣ ਵਿੱਚ ਗਲਤੀਆਂ  
ਜੇ ਤੁਹਾਨੂੰ ਬਣਾਉਣ ਵਿੱਚ ਗਲਤੀਆਂ ਮਿਲਦੀਆਂ ਹਨ:  
```cmd
.\mvnw clean install -DskipTests
```

## ਹੋਰ ਜਾਣਕਾਰੀ ਲਈ

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**ਇਸ ਗੱਲ ਦੀ ਸੂਚਨਾ**:  
ਇਹ ਦਸਤਾਵੇਜ਼ AI ਅਨੁਵਾਦ ਸੇਵਾ [Co-op Translator](https://github.com/Azure/co-op-translator) ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਅਨੁਵਾਦ ਕੀਤਾ ਗਿਆ ਹੈ। ਜਦੋਂ ਕਿ ਅਸੀਂ ਸਹੀਤਾ ਲਈ ਕੋਸ਼ਿਸ਼ ਕਰਦੇ ਹਾਂ, ਕਿਰਪਾ ਕਰਕੇ ਜਾਣੋ ਕਿ ਸਵੈਚਲਿਤ ਅਨੁਵਾਦਾਂ ਵਿੱਚ ਗਲਤੀਆਂ ਜਾਂ ਅਸਮਰੱਥਤਾਵਾਂ ਹੋ ਸਕਦੀਆਂ ਹਨ। ਮੂਲ ਦਸਤਾਵੇਜ਼ ਆਪਣੇ ਮੂਲ ਭਾਸ਼ਾ ਵਿੱਚ ਹੀ ਪ੍ਰਮਾਣਿਕ ਸਰੋਤ ਮੰਨਿਆ ਜਾਣਾ ਚਾਹੀਦਾ ਹੈ। ਮਹੱਤਵਪੂਰਨ ਜਾਣਕਾਰੀ ਲਈ, ਪੇਸ਼ੇਵਰ ਮਨੁੱਖੀ ਅਨੁਵਾਦ ਦੀ ਸਿਫਾਰਸ਼ ਕੀਤੀ ਜਾਂਦੀ ਹੈ। ਅਸੀਂ ਇਸ ਅਨੁਵਾਦ ਦੀ ਵਰਤੋਂ ਕਰਕੇ ਹੋਣ ਵਾਲੀਆਂ ਕਿਸੇ ਵੀ ਗਲਤਫਹਿਮੀਆਂ ਜਾਂ ਗਲਤ ਵਿਆਖਿਆਵਾਂ ਲਈ ਜ਼ਿੰਮੇਵਾਰ ਨਹੀਂ ਹਾਂ।