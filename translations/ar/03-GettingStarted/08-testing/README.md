<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:05:40+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "ar"
}
-->
## الاختبار وتصحيح الأخطاء

قبل أن تبدأ في اختبار خادم MCP الخاص بك، من المهم أن تفهم الأدوات المتاحة وأفضل الممارسات لتصحيح الأخطاء. يضمن الاختبار الفعال أن يتصرف الخادم كما هو متوقع ويساعدك على تحديد المشكلات وحلها بسرعة. القسم التالي يوضح الطرق الموصى بها للتحقق من صحة تنفيذ MCP الخاص بك.

## نظرة عامة

يغطي هذا الدرس كيفية اختيار النهج الصحيح للاختبار وأداة الاختبار الأكثر فاعلية.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- وصف الطرق المختلفة للاختبار.
- استخدام أدوات متنوعة لاختبار الكود بفعالية.

## اختبار خوادم MCP

يوفر MCP أدوات لمساعدتك في اختبار وتصحيح خوادمك:

- **MCP Inspector**: أداة سطر أوامر يمكن تشغيلها كأداة CLI وأيضًا كأداة بصرية.
- **الاختبار اليدوي**: يمكنك استخدام أداة مثل curl لتنفيذ طلبات الويب، ولكن أي أداة تدعم HTTP ستفي بالغرض.
- **اختبار الوحدة**: من الممكن استخدام إطار الاختبار المفضل لديك لاختبار ميزات كل من الخادم والعميل.

### استخدام MCP Inspector

لقد شرحنا استخدام هذه الأداة في دروس سابقة، لكن دعونا نتحدث عنها بإيجاز على مستوى عالٍ. هذه أداة مبنية على Node.js ويمكنك استخدامها عن طريق استدعاء الملف التنفيذي `npx` الذي سيقوم بتنزيل الأداة وتثبيتها مؤقتًا، ثم ينظف نفسه بعد الانتهاء من تشغيل طلبك.

تساعدك [MCP Inspector](https://github.com/modelcontextprotocol/inspector) على:

- **اكتشاف قدرات الخادم**: اكتشاف الموارد والأدوات والمطالبات المتاحة تلقائيًا
- **اختبار تنفيذ الأدوات**: تجربة معلمات مختلفة ورؤية الاستجابات في الوقت الحقيقي
- **عرض بيانات تعريف الخادم**: فحص معلومات الخادم، المخططات، والتكوينات

تشغيل الأداة النموذجي يكون كالتالي:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

الأمر أعلاه يبدأ MCP وواجهة المستخدم الرسومية الخاصة به ويطلق واجهة ويب محلية في متصفحك. يمكنك توقع رؤية لوحة تحكم تعرض خوادم MCP المسجلة لديك، الأدوات، الموارد، والمطالبات المتاحة. تتيح الواجهة لك اختبار تنفيذ الأدوات بشكل تفاعلي، فحص بيانات تعريف الخادم، ورؤية الاستجابات في الوقت الفعلي، مما يسهل التحقق من صحة وتنقيح تطبيقات خادم MCP الخاصة بك.

هذا ما قد تبدو عليه الواجهة: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ar.png)

يمكنك أيضًا تشغيل هذه الأداة في وضع CLI، حيث تضيف السمة `--cli`. إليك مثالًا على تشغيل الأداة في وضع "CLI" الذي يعرض جميع الأدوات على الخادم:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### الاختبار اليدوي

بعيدًا عن تشغيل أداة inspector لاختبار قدرات الخادم، هناك نهج مشابه آخر وهو تشغيل عميل قادر على استخدام HTTP مثل curl.

مع curl، يمكنك اختبار خوادم MCP مباشرة باستخدام طلبات HTTP:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

كما ترى من الاستخدام أعلاه لـ curl، تستخدم طلب POST لاستدعاء أداة باستخدام حمولة تتكون من اسم الأداة ومعلماتها. استخدم النهج الذي يناسبك. أدوات CLI عمومًا أسرع في الاستخدام وتميل إلى أن تكون قابلة للبرمجة النصية، مما قد يكون مفيدًا في بيئة CI/CD.

### اختبار الوحدة

قم بإنشاء اختبارات وحدة لأدواتك ومواردك لضمان عملها كما هو متوقع. إليك مثال على كود اختبار.

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

يقوم الكود السابق بما يلي:

- يستفيد من إطار pytest الذي يتيح لك إنشاء اختبارات كدوال واستخدام عبارات assert.
- ينشئ خادم MCP مع أداتين مختلفتين.
- يستخدم عبارة `assert` للتحقق من استيفاء شروط معينة.

اطلع على [الملف الكامل هنا](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

مع وجود الملف أعلاه، يمكنك اختبار خادمك الخاص لضمان إنشاء القدرات كما ينبغي.

جميع SDKs الرئيسية تحتوي على أقسام اختبار مشابهة بحيث يمكنك التكيف مع بيئة التشغيل التي تختارها.

## عينات

- [حاسبة جافا](../samples/java/calculator/README.md)
- [حاسبة .Net](../../../../03-GettingStarted/samples/csharp)
- [حاسبة جافا سكريبت](../samples/javascript/README.md)
- [حاسبة تايب سكريبت](../samples/typescript/README.md)
- [حاسبة بايثون](../../../../03-GettingStarted/samples/python)

## موارد إضافية

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## ماذا بعد

- التالي: [النشر](/03-GettingStarted/09-deployment/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الحساسة، يُنصح بالترجمة الاحترافية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.