<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e22bdd25c14c3c213fb0ca70973f1000",
  "translation_date": "2025-08-26T19:18:57+00:00",
  "source_file": "03-GettingStarted/05-stdio-server/README.md",
  "language_code": "ar"
}
-->
# خادم MCP باستخدام نقل stdio

> **⚠️ تحديث مهم**: اعتبارًا من مواصفات MCP بتاريخ 2025-06-18، تم **إيقاف** استخدام النقل المستقل SSE (Server-Sent Events) واستبداله بنقل "HTTP القابل للبث". تحدد مواصفات MCP الحالية نوعين رئيسيين من آليات النقل:
> 1. **stdio** - الإدخال/الإخراج القياسي (موصى به للخوادم المحلية)
> 2. **Streamable HTTP** - للخوادم البعيدة التي قد تستخدم SSE داخليًا
>
> تم تحديث هذا الدرس للتركيز على **نقل stdio**، وهو النهج الموصى به لمعظم تطبيقات خادم MCP.

يسمح نقل stdio لخوادم MCP بالتواصل مع العملاء عبر تدفقات الإدخال والإخراج القياسية. يُعتبر هذا النوع من النقل الأكثر استخدامًا والأكثر توصية في مواصفات MCP الحالية، حيث يوفر طريقة بسيطة وفعالة لبناء خوادم MCP يمكن دمجها بسهولة مع تطبيقات العملاء المختلفة.

## نظرة عامة

يغطي هذا الدرس كيفية بناء واستهلاك خوادم MCP باستخدام نقل stdio.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- بناء خادم MCP باستخدام نقل stdio.
- تصحيح أخطاء خادم MCP باستخدام أداة Inspector.
- استهلاك خادم MCP باستخدام Visual Studio Code.
- فهم آليات النقل الحالية لـ MCP ولماذا يُوصى باستخدام stdio.

## نقل stdio - كيف يعمل

نقل stdio هو أحد نوعي النقل المدعومين في مواصفات MCP الحالية (2025-06-18). إليك كيف يعمل:

- **تواصل بسيط**: يقرأ الخادم رسائل JSON-RPC من الإدخال القياسي (`stdin`) ويرسل الرسائل إلى الإخراج القياسي (`stdout`).
- **قائم على العمليات**: يقوم العميل بتشغيل خادم MCP كعملية فرعية.
- **تنسيق الرسائل**: الرسائل هي طلبات JSON-RPC فردية أو إشعارات أو ردود، مفصولة بأسطر جديدة.
- **التسجيل**: يمكن للخادم كتابة سلاسل UTF-8 إلى الخطأ القياسي (`stderr`) لأغراض التسجيل.

### المتطلبات الرئيسية:
- يجب أن تكون الرسائل مفصولة بأسطر جديدة ويجب ألا تحتوي على أسطر جديدة مضمنة.
- يجب ألا يكتب الخادم أي شيء إلى `stdout` ليس رسالة MCP صالحة.
- يجب ألا يكتب العميل أي شيء إلى `stdin` الخاص بالخادم ليس رسالة MCP صالحة.

### TypeScript

```typescript
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = new Server(
  {
    name: "example-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);
```

في الكود السابق:

- نقوم باستيراد الفئة `Server` و`StdioServerTransport` من MCP SDK.
- نقوم بإنشاء مثيل للخادم مع إعدادات وقدرات أساسية.

### Python

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Create server instance
server = Server("example-server")

@server.tool()
def add(a: int, b: int) -> int:
    """Add two numbers"""
    return a + b

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

في الكود السابق:

- نقوم بإنشاء مثيل للخادم باستخدام MCP SDK.
- نحدد الأدوات باستخدام الزخارف (decorators).
- نستخدم مدير السياق stdio_server للتعامل مع النقل.

### .NET

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

builder.Services.AddLogging(logging => logging.AddConsole());

var app = builder.Build();
await app.RunAsync();
```

الفرق الرئيسي عن SSE هو أن خوادم stdio:

- لا تتطلب إعداد خادم ويب أو نقاط نهاية HTTP.
- يتم تشغيلها كعمليات فرعية بواسطة العميل.
- تتواصل عبر تدفقات stdin/stdout.
- أسهل في التنفيذ والتصحيح.

## تمرين: إنشاء خادم stdio

لإنشاء خادمنا، يجب أن نأخذ في الاعتبار أمرين:

- نحتاج إلى استخدام خادم ويب لعرض نقاط النهاية للاتصال والرسائل.

## مختبر: إنشاء خادم MCP stdio بسيط

في هذا المختبر، سنقوم بإنشاء خادم MCP بسيط باستخدام نقل stdio الموصى به. سيعرض هذا الخادم أدوات يمكن للعملاء استدعاؤها باستخدام بروتوكول Model Context القياسي.

### المتطلبات الأساسية

- Python 3.8 أو أحدث
- MCP Python SDK: `pip install mcp`
- فهم أساسي للبرمجة غير المتزامنة

لنبدأ بإنشاء أول خادم MCP stdio:

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server
from mcp import types

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool() 
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    # Use stdio transport
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

## الفروقات الرئيسية عن نهج SSE الموقوف

**نقل stdio (المعيار الحالي):**
- نموذج العملية الفرعية البسيط - يقوم العميل بتشغيل الخادم كعملية فرعية.
- التواصل عبر stdin/stdout باستخدام رسائل JSON-RPC.
- لا يتطلب إعداد خادم HTTP.
- أداء وأمان أفضل.
- أسهل في التصحيح والتطوير.

**نقل SSE (تم إيقافه اعتبارًا من MCP 2025-06-18):**
- يتطلب خادم HTTP مع نقاط نهاية SSE.
- إعداد أكثر تعقيدًا مع بنية خادم ويب.
- اعتبارات أمان إضافية لنقاط نهاية HTTP.
- تم استبداله الآن بـ Streamable HTTP للسيناريوهات القائمة على الويب.

### إنشاء خادم باستخدام نقل stdio

لإنشاء خادم stdio، نحتاج إلى:

1. **استيراد المكتبات المطلوبة** - نحتاج إلى مكونات خادم MCP ونقل stdio.
2. **إنشاء مثيل للخادم** - تعريف الخادم بقدراته.
3. **تعريف الأدوات** - إضافة الوظائف التي نريد عرضها.
4. **إعداد النقل** - تكوين التواصل عبر stdio.
5. **تشغيل الخادم** - بدء تشغيل الخادم ومعالجة الرسائل.

لنقم ببناء هذا خطوة بخطوة:

### الخطوة 1: إنشاء خادم stdio أساسي

```python
import asyncio
import logging
from mcp.server import Server
from mcp.server.stdio import stdio_server

# Configure logging
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

# Create the server
server = Server("example-stdio-server")

@server.tool()
def get_greeting(name: str) -> str:
    """Generate a personalized greeting"""
    return f"Hello, {name}! Welcome to MCP stdio server."

async def main():
    async with stdio_server(server) as (read_stream, write_stream):
        await server.run(
            read_stream,
            write_stream,
            server.create_initialization_options()
        )

if __name__ == "__main__":
    asyncio.run(main())
```

### الخطوة 2: إضافة المزيد من الأدوات

```python
@server.tool()
def calculate_sum(a: int, b: int) -> int:
    """Calculate the sum of two numbers"""
    return a + b

@server.tool()
def calculate_product(a: int, b: int) -> int:
    """Calculate the product of two numbers"""
    return a * b

@server.tool()
def get_server_info() -> dict:
    """Get information about this MCP server"""
    return {
        "server_name": "example-stdio-server",
        "version": "1.0.0",
        "transport": "stdio",
        "capabilities": ["tools"]
    }
```

### الخطوة 3: تشغيل الخادم

احفظ الكود باسم `server.py` وقم بتشغيله من سطر الأوامر:

```bash
python server.py
```

سيبدأ الخادم وينتظر الإدخال من stdin. يتواصل باستخدام رسائل JSON-RPC عبر نقل stdio.

### الخطوة 4: الاختبار باستخدام أداة Inspector

يمكنك اختبار خادمك باستخدام MCP Inspector:

1. قم بتثبيت Inspector: `npx @modelcontextprotocol/inspector`
2. قم بتشغيل Inspector وأشر إلى خادمك.
3. اختبر الأدوات التي قمت بإنشائها.

### .NET

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddMcpServer();

## Debugging your stdio server

### Using the MCP Inspector

The MCP Inspector is a valuable tool for debugging and testing MCP servers. Here's how to use it with your stdio server:

1. **Install the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector
   ```

2. **Run the Inspector**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

3. **Test your server**: The Inspector provides a web interface where you can:
   - View server capabilities
   - Test tools with different parameters
   - Monitor JSON-RPC messages
   - Debug connection issues

### Using VS Code

You can also debug your MCP server directly in VS Code:

1. Create a launch configuration in `.vscode/launch.json`:
   ```json
   {
     "version": "0.2.0",
     "configurations": [
       {
         "name": "Debug MCP Server",
         "type": "python",
         "request": "launch",
         "program": "server.py",
         "console": "integratedTerminal"
       }
     ]
   }
   ```

2. Set breakpoints in your server code
3. Run the debugger and test with the Inspector

### Common debugging tips

- Use `stderr` for logging - never write to `stdout` as it's reserved for MCP messages
- Ensure all JSON-RPC messages are newline-delimited
- Test with simple tools first before adding complex functionality
- Use the Inspector to verify message formats

## Consuming your stdio server in VS Code

Once you've built your MCP stdio server, you can integrate it with VS Code to use it with Claude or other MCP-compatible clients.

### Configuration

1. **Create an MCP configuration file** at `%APPDATA%\Claude\claude_desktop_config.json` (Windows) or `~/Library/Application Support/Claude/claude_desktop_config.json` (Mac):

   ```json
   {
     "mcpServers": {
       "example-stdio-server": {
         "command": "python",
         "args": ["path/to/your/server.py"]
       }
     }
   }
   ```

2. **Restart Claude**: Close and reopen Claude to load the new server configuration.

3. **Test the connection**: Start a conversation with Claude and try using your server's tools:
   - "Can you greet me using the greeting tool?"
   - "Calculate the sum of 15 and 27"
   - "What's the server info?"

### TypeScript stdio server example

Here's a complete TypeScript example for reference:

```typescript
#!/usr/bin/env node
import { Server } from "@modelcontextprotocol/sdk/server/index.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { CallToolRequestSchema, ListToolsRequestSchema } from "@modelcontextprotocol/sdk/types.js";

const server = new Server(
  {
    name: "example-stdio-server",
    version: "1.0.0",
  },
  {
    capabilities: {
      tools: {},
    },
  }
);

// Add tools
server.setRequestHandler(ListToolsRequestSchema, async () => {
  return {
    tools: [
      {
        name: "get_greeting",
        description: "Get a personalized greeting",
        inputSchema: {
          type: "object",
          properties: {
            name: {
              type: "string",
              description: "Name of the person to greet",
            },
          },
          required: ["name"],
        },
      },
    ],
  };
});

server.setRequestHandler(CallToolRequestSchema, async (request) => {
  if (request.params.name === "get_greeting") {
    return {
      content: [
        {
          type: "text",
          text: `Hello, ${request.params.arguments?.name}! Welcome to MCP stdio server.`,
        },
      ],
    };
  } else {
    throw new Error(`Unknown tool: ${request.params.name}`);
  }
});

async function runServer() {
  const transport = new StdioServerTransport();
  await server.connect(transport);
}

runServer().catch(console.error);
```

### .NET stdio server example

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddMcpServer()
    .WithStdioTransport()
    .WithTools<Tools>();

var app = builder.Build();
await app.RunAsync();

public class Tools
{
    [Description("Get a personalized greeting")]
    public string GetGreeting(string name)
    {
        return $"Hello, {name}! Welcome to MCP stdio server.";
    }

    [Description("Calculate the sum of two numbers")]
    public int CalculateSum(int a, int b)
    {
        return a + b;
    }
}
```

## Summary

In this updated lesson, you learned how to:

- Build MCP servers using the current **stdio transport** (recommended approach)
- Understand why SSE transport was deprecated in favor of stdio and Streamable HTTP
- Create tools that can be called by MCP clients
- Debug your server using the MCP Inspector
- Integrate your stdio server with VS Code and Claude

The stdio transport provides a simpler, more secure, and more performant way to build MCP servers compared to the deprecated SSE approach. It's the recommended transport for most MCP server implementations as of the 2025-06-18 specification.
```

### .NET

1. لنقم بإنشاء بعض الأدوات أولاً، لهذا سنقوم بإنشاء ملف *Tools.cs* بالمحتوى التالي:

  ```csharp
  using System.ComponentModel;
  using System.Text.Json;
  using ModelContextProtocol.Server;

## Exercise: Testing your stdio server

Now that you've built your stdio server, let's test it to make sure it works correctly.

### Prerequisites

1. Ensure you have the MCP Inspector installed:
   ```bash
   npm install -g @modelcontextprotocol/inspector
   ```

2. Your server code should be saved (e.g., as `server.py`)

### Testing with the Inspector

1. **Start the Inspector with your server**:
   ```bash
   npx @modelcontextprotocol/inspector python server.py
   ```

2. **افتح واجهة الويب**: ستفتح أداة Inspector نافذة متصفح تعرض قدرات خادمك.

3. **اختبر الأدوات**: 
   - جرب أداة `get_greeting` بأسماء مختلفة.
   - اختبر أداة `calculate_sum` بأرقام متنوعة.
   - استدعِ أداة `get_server_info` لرؤية بيانات الخادم.

4. **راقب التواصل**: تعرض أداة Inspector رسائل JSON-RPC التي يتم تبادلها بين العميل والخادم.

### ما يجب أن تراه

عندما يبدأ خادمك بشكل صحيح، يجب أن ترى:
- قدرات الخادم مدرجة في أداة Inspector.
- الأدوات متاحة للاختبار.
- تبادل ناجح لرسائل JSON-RPC.
- ردود الأدوات معروضة في الواجهة.

### المشاكل الشائعة والحلول

**الخادم لا يبدأ:**
- تحقق من تثبيت جميع التبعيات: `pip install mcp`.
- تأكد من صحة بناء جملة Python والمسافة البادئة.
- ابحث عن رسائل الخطأ في وحدة التحكم.

**الأدوات لا تظهر:**
- تأكد من وجود الزخارف `@server.tool()`.
- تحقق من تعريف وظائف الأدوات قبل `main()`.
- تأكد من تكوين الخادم بشكل صحيح.

**مشاكل الاتصال:**
- تأكد من أن الخادم يستخدم نقل stdio بشكل صحيح.
- تحقق من عدم تدخل عمليات أخرى.
- تحقق من بناء جملة أمر Inspector.

## المهمة

حاول بناء خادمك بمزيد من القدرات. راجع [هذه الصفحة](https://api.chucknorris.io/) لإضافة أداة تستدعي واجهة برمجة تطبيقات، على سبيل المثال. قرر كيف يجب أن يبدو الخادم. استمتع :)

## الحل

[الحل](./solution/README.md) إليك حل ممكن مع كود يعمل.

## النقاط الرئيسية

النقاط الرئيسية من هذا الفصل هي:

- نقل stdio هو الآلية الموصى بها للخوادم المحلية لـ MCP.
- يسمح نقل stdio بالتواصل السلس بين خوادم MCP والعملاء باستخدام تدفقات الإدخال والإخراج القياسية.
- يمكنك استخدام كل من Inspector وVisual Studio Code لاستهلاك خوادم stdio مباشرة، مما يجعل التصحيح والتكامل بسيطًا.

## أمثلة 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## موارد إضافية

- [SSE](https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events)

## ماذا بعد

## الخطوات التالية

الآن بعد أن تعلمت كيفية بناء خوادم MCP باستخدام نقل stdio، يمكنك استكشاف مواضيع أكثر تقدمًا:

- **التالي**: [HTTP Streaming مع MCP (Streamable HTTP)](../06-http-streaming/README.md) - تعلم عن آلية النقل الأخرى المدعومة للخوادم البعيدة.
- **متقدم**: [أفضل ممارسات أمان MCP](../../02-Security/README.md) - تنفيذ الأمان في خوادم MCP.
- **الإنتاج**: [استراتيجيات النشر](../09-deployment/README.md) - نشر خوادمك للاستخدام الإنتاجي.

## موارد إضافية

- [مواصفات MCP 2025-06-18](https://spec.modelcontextprotocol.io/specification/) - المواصفات الرسمية.
- [وثائق MCP SDK](https://github.com/modelcontextprotocol/sdk) - مراجع SDK لجميع اللغات.
- [أمثلة المجتمع](../../06-CommunityContributions/README.md) - المزيد من أمثلة الخوادم من المجتمع.

---

**إخلاء المسؤولية**:  
تم ترجمة هذا المستند باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو معلومات غير دقيقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الرسمي. للحصول على معلومات حاسمة، يُوصى بالاستعانة بترجمة بشرية احترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة ناتجة عن استخدام هذه الترجمة.