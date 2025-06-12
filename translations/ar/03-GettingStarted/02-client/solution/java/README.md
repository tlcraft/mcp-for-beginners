<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7074b9f4c8cd147c1c10f569d8508c82",
  "translation_date": "2025-06-11T13:04:27+00:00",
  "source_file": "03-GettingStarted/02-client/solution/java/README.md",
  "language_code": "ar"
}
-->
# MCP Java Client - مثال الحاسبة

يُظهر هذا المشروع كيفية إنشاء عميل Java يتصل ويتفاعل مع خادم MCP (بروتوكول سياق النموذج). في هذا المثال، سنتصل بخادم الحاسبة من الفصل 01 وننفذ عمليات رياضية متنوعة.

## المتطلبات الأساسية

قبل تشغيل هذا العميل، تحتاج إلى:

1. **تشغيل خادم الحاسبة** من الفصل 01:
   - انتقل إلى دليل خادم الحاسبة: `03-GettingStarted/01-first-server/solution/java/`
   - بناء وتشغيل خادم الحاسبة:
     ```cmd
     cd ..\01-first-server\solution\java
     .\mvnw clean install -DskipTests
     java -jar target\calculator-server-0.0.1-SNAPSHOT.jar
     ```
   - يجب أن يكون الخادم قيد التشغيل على `http://localhost:8080`

2. **Java 21 or higher** installed on your system
3. **Maven** (included via Maven Wrapper)

## What is the SDKClient?

The `SDKClient` هو تطبيق Java يوضح كيفية:
- الاتصال بخادم MCP باستخدام نقل Server-Sent Events (SSE)
- عرض الأدوات المتاحة من الخادم
- استدعاء وظائف الحاسبة المختلفة عن بُعد
- معالجة الردود وعرض النتائج

## كيف يعمل

يستخدم العميل إطار عمل Spring AI MCP لـ:

1. **إنشاء الاتصال**: ينشئ عميل WebFlux SSE للاتصال بخادم الحاسبة
2. **تهيئة العميل**: يضبط عميل MCP وينشئ الاتصال
3. **اكتشاف الأدوات**: يعرض جميع عمليات الحاسبة المتاحة
4. **تنفيذ العمليات**: يستدعي وظائف رياضية مختلفة ببيانات تجريبية
5. **عرض النتائج**: يعرض نتائج كل عملية حسابية

## هيكل المشروع

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

## التبعيات الأساسية

يستخدم المشروع التبعيات الأساسية التالية:

```xml
<dependency>
    <groupId>org.springframework.ai</groupId>
    <artifactId>spring-ai-starter-mcp-server-webflux</artifactId>
</dependency>
```

توفر هذه التبعية:
- `McpClient` - The main client interface
- `WebFluxSseClientTransport` - نقل SSE للاتصال عبر الويب
- مخططات بروتوكول MCP وأنواع الطلب/الرد

## بناء المشروع

قم ببناء المشروع باستخدام ملف Maven المساعد:

```cmd
.\mvnw clean install
```

## تشغيل العميل

```cmd
java -jar .\target\calculator-client-0.0.1-SNAPSHOT.jar
```

**ملاحظة**: تأكد من تشغيل خادم الحاسبة على `http://localhost:8080` before executing any of these commands.

## What the Client Does

When you run the client, it will:

1. **Connect** to the calculator server at `http://localhost:8080`
2. **عرض الأدوات** - يعرض جميع عمليات الحاسبة المتاحة
3. **إجراء الحسابات**:
   - الجمع: 5 + 3 = 8
   - الطرح: 10 - 4 = 6
   - الضرب: 6 × 7 = 42
   - القسمة: 20 ÷ 4 = 5
   - الأس: 2^8 = 256
   - الجذر التربيعي: √16 = 4
   - القيمة المطلقة: |-5.5| = 5.5
   - المساعدة: يعرض العمليات المتاحة

## النتيجة المتوقعة

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

**ملاحظة**: قد ترى تحذيرات Maven حول وجود خيوط متبقية في النهاية - هذا أمر طبيعي لتطبيقات التفاعل ولا يشير إلى وجود خطأ.

## فهم الكود

### 1. إعداد النقل
```java
var transport = new WebFluxSseClientTransport(WebClient.builder().baseUrl("http://localhost:8080"));
```
هذا ينشئ نقل SSE (Server-Sent Events) الذي يتصل بخادم الحاسبة.

### 2. إنشاء العميل
```java
var client = McpClient.sync(this.transport).build();
client.initialize();
```
ينشئ عميل MCP متزامن ويهيئ الاتصال.

### 3. استدعاء الأدوات
```java
CallToolResult resultAdd = client.callTool(new CallToolRequest("add", Map.of("a", 5.0, "b", 3.0)));
```
يستدعي أداة "add" بالمعاملات a=5.0 و b=3.0.

## استكشاف الأخطاء وإصلاحها

### الخادم غير قيد التشغيل
إذا واجهت أخطاء في الاتصال، تأكد من تشغيل خادم الحاسبة من الفصل 01:
```
Error: Connection refused
```
**الحل**: ابدأ تشغيل خادم الحاسبة أولاً.

### المنفذ مستخدم بالفعل
إذا كان المنفذ 8080 مشغولاً:
```
Error: Address already in use
```
**الحل**: أوقف التطبيقات الأخرى التي تستخدم المنفذ 8080 أو قم بتعديل الخادم لاستخدام منفذ مختلف.

### أخطاء البناء
إذا واجهت أخطاء في البناء:
```cmd
.\mvnw clean install -DskipTests
```

## تعلّم المزيد

- [Spring AI MCP Documentation](https://docs.spring.io/spring-ai/reference/api/mcp/)
- [Model Context Protocol Specification](https://modelcontextprotocol.io/)
- [Spring WebFlux Documentation](https://docs.spring.io/spring-framework/docs/current/reference/html/web-reactive.html)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر المعتمد. للمعلومات الهامة، يُنصح بالاستعانة بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة ناتجة عن استخدام هذه الترجمة.