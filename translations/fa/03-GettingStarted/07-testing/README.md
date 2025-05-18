<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:39:49+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "fa"
}
-->
## آزمایش و دیباگینگ

پیش از آغاز آزمایش سرور MCP خود، مهم است که ابزارهای موجود و بهترین روش‌های دیباگینگ را بشناسید. آزمایش مؤثر اطمینان می‌دهد که سرور شما همان‌طور که انتظار می‌رود رفتار می‌کند و به شما کمک می‌کند تا مشکلات را سریعاً شناسایی و حل کنید. بخش زیر روش‌های پیشنهادی برای اعتبارسنجی اجرای MCP شما را شرح می‌دهد.

## مرور کلی

این درس نحوه انتخاب روش آزمایش مناسب و مؤثرترین ابزار آزمایش را پوشش می‌دهد.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- روش‌های مختلف آزمایش را توصیف کنید.
- از ابزارهای مختلف برای آزمایش مؤثر کد خود استفاده کنید.

## آزمایش سرورهای MCP

MCP ابزارهایی ارائه می‌دهد که به شما در آزمایش و دیباگینگ سرورهایتان کمک می‌کند:

- **MCP Inspector**: یک ابزار خط فرمان که می‌تواند به صورت یک ابزار CLI و به عنوان یک ابزار بصری اجرا شود.
- **آزمایش دستی**: شما می‌توانید از ابزاری مانند curl برای اجرای درخواست‌های وب استفاده کنید، اما هر ابزار دیگری که قادر به اجرای HTTP باشد نیز مناسب است.
- **آزمایش واحد**: می‌توانید از چارچوب آزمایش دلخواه خود برای آزمایش ویژگی‌های سرور و کلاینت استفاده کنید.

### استفاده از MCP Inspector

ما در درس‌های قبلی نحوه استفاده از این ابزار را توضیح داده‌ایم اما بیایید به‌طور کلی درباره آن صحبت کنیم. این ابزاری است که در Node.js ساخته شده و شما می‌توانید با فراخوانی `npx` اجرایی از آن استفاده کنید که ابزار را به‌طور موقت دانلود و نصب می‌کند و پس از اجرای درخواست شما خود را پاک می‌کند.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) به شما کمک می‌کند:

- **کشف قابلیت‌های سرور**: به‌طور خودکار منابع، ابزارها و درخواست‌های موجود را شناسایی کنید.
- **آزمایش اجرای ابزار**: پارامترهای مختلف را امتحان کنید و پاسخ‌ها را به‌صورت لحظه‌ای ببینید.
- **مشاهده متادیتای سرور**: اطلاعات سرور، اسکیماها و تنظیمات را بررسی کنید.

اجرای معمولی این ابزار به صورت زیر است:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

دستور فوق MCP و رابط بصری آن را راه‌اندازی کرده و یک رابط وب محلی در مرورگر شما باز می‌کند. شما می‌توانید داشبوردی را مشاهده کنید که سرورهای MCP ثبت‌شده شما، ابزارها، منابع و درخواست‌های موجود را نمایش می‌دهد. این رابط به شما اجازه می‌دهد تا اجرای ابزار را به‌صورت تعاملی آزمایش کنید، متادیتای سرور را بررسی کنید و پاسخ‌های لحظه‌ای را مشاهده کنید، که اعتبارسنجی و دیباگینگ اجرای سرور MCP شما را آسان‌تر می‌کند.

این چیزی است که ممکن است به نظر برسد: ![Inspector](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.fa.png)

شما همچنین می‌توانید این ابزار را در حالت CLI اجرا کنید که در این صورت باید ویژگی `--cli` را اضافه کنید. در اینجا مثالی از اجرای ابزار در حالت "CLI" که تمام ابزارهای موجود در سرور را لیست می‌کند:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### آزمایش دستی

علاوه بر اجرای ابزار inspector برای آزمایش قابلیت‌های سرور، روش مشابه دیگر این است که یک کلاینت که قادر به استفاده از HTTP است مانند curl را اجرا کنید.

با curl، شما می‌توانید سرورهای MCP را مستقیماً با استفاده از درخواست‌های HTTP آزمایش کنید:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

همان‌طور که از استفاده فوق از curl مشاهده می‌کنید، شما از درخواست POST برای فراخوانی یک ابزار با استفاده از یک payload شامل نام ابزار و پارامترهای آن استفاده می‌کنید. از روشی که برای شما مناسب‌تر است استفاده کنید. ابزارهای CLI به‌طور کلی سریع‌تر برای استفاده هستند و امکان اسکریپت‌نویسی دارند که می‌تواند در محیط CI/CD مفید باشد.

### آزمایش واحد

آزمایش‌های واحد برای ابزارها و منابع خود ایجاد کنید تا اطمینان حاصل کنید که همان‌طور که انتظار می‌رود کار می‌کنند. در اینجا برخی از کدهای آزمایش نمونه آورده شده است.

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

کد پیشین کارهای زیر را انجام می‌دهد:

- از چارچوب pytest استفاده می‌کند که به شما اجازه می‌دهد آزمایش‌ها را به‌عنوان توابع ایجاد کنید و از دستورات assert استفاده کنید.
- یک سرور MCP با دو ابزار مختلف ایجاد می‌کند.
- از دستور `assert` برای بررسی اینکه شرایط خاصی برآورده شده‌اند استفاده می‌کند.

نگاهی به [فایل کامل اینجا](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py) بیندازید.

با توجه به فایل فوق، شما می‌توانید سرور خود را آزمایش کنید تا اطمینان حاصل کنید که قابلیت‌ها همان‌طور که باید ایجاد شده‌اند.

تمام SDK‌های اصلی بخش‌های آزمایش مشابهی دارند، بنابراین می‌توانید با محیط اجرایی انتخابی خود تنظیم کنید.

## نمونه‌ها

- [ماشین‌حساب جاوا](../samples/java/calculator/README.md)
- [ماشین‌حساب .Net](../../../../03-GettingStarted/samples/csharp)
- [ماشین‌حساب جاوااسکریپت](../samples/javascript/README.md)
- [ماشین‌حساب تایپ‌اسکریپت](../samples/typescript/README.md)
- [ماشین‌حساب پایتون](../../../../03-GettingStarted/samples/python)

## منابع اضافی

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## مرحله بعدی

- بعدی: [استقرار](/03-GettingStarted/08-deployment/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما برای دقت تلاش می‌کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل اشتباهات یا نادرستی‌ها باشند. سند اصلی به زبان مادری باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئولیتی در قبال سوء تفاهم یا تفسیرهای نادرست ناشی از استفاده از این ترجمه نداریم.