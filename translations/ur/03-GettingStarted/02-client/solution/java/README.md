<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:05:06+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "ur"
}
-->
# MCP Java Client - Calculator Demo

یہ پروجیکٹ دکھاتا ہے کہ کیسے ایک Java کلائنٹ بنایا جائے جو MCP (Model Context Protocol) سرور سے جڑتا ہے اور اس کے ساتھ تعامل کرتا ہے۔ اس مثال میں، ہم چپٹر 01 کے کیلکولیٹر سرور سے جڑیں گے اور مختلف ریاضیاتی آپریشنز انجام دیں گے۔

## Prerequisites

اس کلائنٹ کو چلانے سے پہلے، آپ کو یہ کرنا ہوگا:

1. **چپٹر 01 سے کیلکولیٹر سرور شروع کریں**:
   - کیلکولیٹر سرور ڈائریکٹری میں جائیں: `03-GettingStarted/01-first-server/solution/java/`
   - کیلکولیٹر سرور کو بنائیں اور چلائیں:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - سرور `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `` پر چل رہا ہونا چاہیے

`SDKClient` ایک Java ایپلیکیشن ہے جو دکھاتی ہے کہ کیسے:
- Server-Sent Events (SSE) ٹرانسپورٹ کے ذریعے MCP سرور سے جڑا جائے
- سرور سے دستیاب ٹولز کی فہرست حاصل کی جائے
- مختلف کیلکولیٹر فنکشنز کو ریموٹلی کال کیا جائے
- جوابات کو ہینڈل کیا جائے اور نتائج دکھائے جائیں

## How It Works

کلائنٹ Spring AI MCP فریم ورک استعمال کرتا ہے تاکہ:

1. **کنکشن قائم کرے**: WebFlux SSE کلائنٹ ٹرانسپورٹ بناتا ہے جو کیلکولیٹر سرور سے جڑتا ہے  
2. **کلائنٹ کو انیشیالائز کرے**: MCP کلائنٹ سیٹ اپ کرتا ہے اور کنکشن قائم کرتا ہے  
3. **ٹولز دریافت کرے**: تمام دستیاب کیلکولیٹر آپریشنز کی فہرست دکھاتا ہے  
4. **آپریشنز انجام دے**: مختلف ریاضیاتی فنکشنز کو سیمپل ڈیٹا کے ساتھ کال کرتا ہے  
5. **نتائج دکھائے**: ہر کیلکولیشن کے نتائج دکھاتا ہے  

## Project Structure

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

## Key Dependencies

پروجیکٹ درج ذیل اہم dependencies استعمال کرتا ہے:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

یہ dependency فراہم کرتی ہے:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - ویب پر مبنی کمیونیکیشن کے لیے SSE ٹرانسپورٹ  
- MCP پروٹوکول اسکیماز اور درخواست/جواب کی اقسام  

## Building the Project

Maven wrapper استعمال کرتے ہوئے پروجیکٹ بنائیں:

```cmd
.\mvnw clean install
```

## Running the Client

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**Note**: یقینی بنائیں کہ کیلکولیٹر سرور `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080` پر چل رہا ہے  
2. **ٹولز کی فہرست دکھائیں** - تمام دستیاب کیلکولیٹر آپریشنز دکھاتا ہے  
3. **کیلکولیشنز کریں**:  
   - جمع: 5 + 3 = 8  
   - تفریق: 10 - 4 = 6  
   - ضرب: 6 × 7 = 42  
   - تقسیم: 20 ÷ 4 = 5  
   - طاقت: 2^8 = 256  
   - مربع جذر: √16 = 4  
   - مطلق قیمت: |-5.5| = 5.5  
   - مدد: دستیاب آپریشنز دکھاتا ہے  

## Expected Output

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

**Note**: آپ Maven وارننگز دیکھ سکتے ہیں جو تھریڈز کے باقی رہنے کے بارے میں ہیں - یہ reactive applications کے لیے معمول کی بات ہے اور یہ کوئی ایرر نہیں ہے۔

## Understanding the Code

### 1. Transport Setup  
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```  
یہ ایک SSE (Server-Sent Events) ٹرانسپورٹ بناتا ہے جو کیلکولیٹر سرور سے جڑتا ہے۔

### 2. Client Creation  
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```  
ایک synchronous MCP کلائنٹ بناتا ہے اور کنکشن کو انیشیالائز کرتا ہے۔

### 3. Calling Tools  
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```  
"add" ٹول کو a=5.0 اور b=3.0 پیرامیٹرز کے ساتھ کال کرتا ہے۔

## Troubleshooting

### Server Not Running  
اگر کنکشن ایررز آئیں، تو یقینی بنائیں کہ چپٹر 01 کا کیلکولیٹر سرور چل رہا ہے:  
```
Error: Connection refused
```  
**Solution**: پہلے کیلکولیٹر سرور شروع کریں۔

### Port Already in Use  
اگر پورٹ 8080 مصروف ہے:  
```
Error: Address already in use
```  
**Solution**: دوسرے ایپلیکیشنز جو پورٹ 8080 استعمال کر رہے ہیں بند کریں یا سرور کو کسی اور پورٹ پر چلائیں۔

### Build Errors  
اگر بلڈ ایررز آئیں:  
```cmd
.\mvnw clean install -DskipTests
```

## Learn More

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)  
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)  
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**ڈس کلیمر**:  
اس دستاویز کا ترجمہ AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے کیا گیا ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مادری زبان میں معتبر ماخذ سمجھا جانا چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لیے ہم ذمہ دار نہیں ہیں۔