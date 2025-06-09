<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-27T16:23:27+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "cs"
}
-->
## Testing and Debugging

قبل أن تبدأ في اختبار خادم MCP الخاص بك، من المهم أن تفهم الأدوات المتاحة وأفضل الممارسات في عملية التصحيح. يضمن الاختبار الفعّال أن يعمل الخادم كما هو متوقع ويساعدك على تحديد المشكلات وحلها بسرعة. يوضح القسم التالي الطرق الموصى بها للتحقق من تنفيذ MCP الخاص بك.

## Overview

تغطي هذه الدرس كيفية اختيار النهج الصحيح للاختبار وأفضل الأدوات المستخدمة في ذلك.

## Learning Objectives

بنهاية هذا الدرس، ستكون قادرًا على:

- وصف مختلف الأساليب للاختبار.
- استخدام أدوات مختلفة لاختبار الكود بفعالية.

## Testing MCP Servers

يوفر MCP أدوات تساعدك على اختبار وتصحيح خوادمك:

- **MCP Inspector**: أداة سطر أوامر يمكن تشغيلها كأداة CLI وأيضًا كأداة بصرية.
- **الاختبار اليدوي**: يمكنك استخدام أداة مثل curl لإجراء طلبات ويب، لكن أي أداة تدعم HTTP مناسبة.
- **الاختبار الوحدوي**: يمكنك استخدام إطار الاختبار المفضل لديك لاختبار ميزات كل من الخادم والعميل.

### Using MCP Inspector

لقد وصفنا استخدام هذه الأداة في الدروس السابقة، ولكن دعنا نتحدث عنها بشكل عام. هي أداة مبنية على Node.js ويمكنك استخدامها عن طريق استدعاء الملف التنفيذي `npx` الذي سيقوم بتحميل الأداة وتثبيتها مؤقتًا ثم ينظف نفسه بعد الانتهاء من تنفيذ طلبك.

يساعدك [MCP Inspector](https://github.com/modelcontextprotocol/inspector) في:

- **اكتشاف قدرات الخادم**: الكشف التلقائي عن الموارد المتاحة، الأدوات، والتعليمات
- **اختبار تنفيذ الأدوات**: تجربة معلمات مختلفة ورؤية الردود في الوقت الفعلي
- **عرض بيانات الخادم التعريفية**: فحص معلومات الخادم، المخططات، والإعدادات

تشغيل نموذجي للأداة يبدو كالتالي:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

الأمر أعلاه يبدأ MCP وواجهته البصرية ويطلق واجهة ويب محلية في متصفحك. يمكنك توقع رؤية لوحة تحكم تعرض خوادم MCP المسجلة، الأدوات المتاحة، الموارد، والتعليمات. تتيح الواجهة اختبار تنفيذ الأدوات بشكل تفاعلي، فحص بيانات الخادم التعريفية، ومشاهدة الردود في الوقت الحقيقي، مما يسهل التحقق من صحة وتنقيح تنفيذات خادم MCP الخاص بك.

إليك كيف قد تبدو: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.cs.png)

يمكنك أيضًا تشغيل هذه الأداة في وضع CLI حيث تضيف السمة `--cli`. إليك مثالًا لتشغيل الأداة في وضع "CLI" الذي يعرض جميع الأدوات على الخادم:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### Manual Testing

بجانب تشغيل أداة المفتش لاختبار قدرات الخادم، هناك طريقة مشابهة وهي تشغيل عميل قادر على استخدام HTTP مثل curl.

باستخدام curl، يمكنك اختبار خوادم MCP مباشرةً عبر طلبات HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

كما ترى في المثال أعلاه لاستخدام curl، تستخدم طلب POST لاستدعاء أداة مع حمولة تتضمن اسم الأداة ومعلماتها. استخدم الطريقة التي تناسبك. أدوات CLI عادةً ما تكون أسرع في الاستخدام وتميل لأن تُستخدم في السكريبتات، وهو ما يكون مفيدًا في بيئة CI/CD.

### Unit Testing

أنشئ اختبارات وحدوية لأدواتك ومواردك لضمان عملها كما هو متوقع. إليك مثال على كود اختبار.

```python
import pytest

from mcp.server.fastmcp import FastMCP
from mcp.shared.memory import (
    create_connected_server_and_client_session as create_session,
)

# Mark the whole module for async tests
pytestmark = pytest.mark.anyio


async def test_list_tools_cursor_parameter():
    """Test that the cursor parameter is accepted for list_tools.

    Note: FastMCP doesn't currently implement pagination, so this test
    only verifies that the cursor parameter is accepted by the client.
    """

 server = FastMCP("test")

    # Create a couple of test tools
    @server.tool(name="test_tool_1")
    async def test_tool_1() -> str:
        """First test tool"""
        return "Result 1"

    @server.tool(name="test_tool_2")
    async def test_tool_2() -> str:
        """Second test tool"""
        return "Result 2"

    async with create_session(server._mcp_server) as client_session:
        # Test without cursor parameter (omitted)
        result1 = await client_session.list_tools()
        assert len(result1.tools) == 2

        # Test with cursor=None
        result2 = await client_session.list_tools(cursor=None)
        assert len(result2.tools) == 2

        # Test with cursor as string
        result3 = await client_session.list_tools(cursor="some_cursor_value")
        assert len(result3.tools) == 2

        # Test with empty string cursor
        result4 = await client_session.list_tools(cursor="")
        assert len(result4.tools) == 2
    
```

الكود السابق يقوم بما يلي:

- يستخدم إطار عمل pytest الذي يتيح إنشاء اختبارات كدوال واستخدام عبارات assert.
- ينشئ خادم MCP يحتوي على أداتين مختلفتين.
- يستخدم عبارة `assert` للتحقق من تحقق شروط معينة.

اطلع على [الملف الكامل هنا](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

استنادًا إلى الملف أعلاه، يمكنك اختبار خادمك الخاص لضمان إنشاء القدرات كما ينبغي.

جميع حزم SDK الرئيسية تحتوي على أقسام اختبار مماثلة، لذا يمكنك التكيف مع بيئة التشغيل التي تختارها.

## Samples 

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python) 

## Additional Resources

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## What's Next

- التالي: [Deployment](/03-GettingStarted/08-deployment/README.md)

**Prohlášení o vyloučení odpovědnosti**:  
Tento dokument byl přeložen pomocí AI překladatelské služby [Co-op Translator](https://github.com/Azure/co-op-translator). Přestože usilujeme o přesnost, mějte prosím na paměti, že automatické překlady mohou obsahovat chyby nebo nepřesnosti. Původní dokument v jeho mateřském jazyce by měl být považován za autoritativní zdroj. Pro důležité informace se doporučuje profesionální lidský překlad. Nejsme odpovědní za jakékoli nedorozumění nebo mylné výklady vyplývající z použití tohoto překladu.