<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-12T22:24:31+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "fa"
}
-->
## آزمایش و اشکال‌زدایی

قبل از شروع آزمایش سرور MCP خود، مهم است که ابزارهای موجود و بهترین روش‌ها برای اشکال‌زدایی را بشناسید. آزمایش مؤثر تضمین می‌کند که سرور شما همانطور که انتظار می‌رود عمل می‌کند و به شما کمک می‌کند مشکلات را سریع‌تر شناسایی و برطرف کنید. بخش زیر روش‌های پیشنهادی برای اعتبارسنجی پیاده‌سازی MCP شما را توضیح می‌دهد.

## مرور کلی

این درس نحوه انتخاب روش مناسب آزمایش و مؤثرترین ابزار آزمایش را پوشش می‌دهد.

## اهداف یادگیری

در پایان این درس، شما قادر خواهید بود:

- روش‌های مختلف آزمایش را توصیف کنید.
- از ابزارهای مختلف برای آزمایش مؤثر کد خود استفاده کنید.

## آزمایش سرورهای MCP

MCP ابزارهایی برای کمک به آزمایش و اشکال‌زدایی سرورهای شما فراهم می‌کند:

- **MCP Inspector**: ابزاری خط فرمان که هم به صورت CLI و هم به صورت ابزار بصری قابل اجرا است.
- **آزمایش دستی**: می‌توانید از ابزاری مانند curl برای ارسال درخواست‌های وب استفاده کنید، اما هر ابزاری که بتواند HTTP را اجرا کند مناسب است.
- **آزمایش واحد**: امکان استفاده از چارچوب آزمایش مورد علاقه خود برای آزمایش ویژگی‌های هر دو سرور و کلاینت وجود دارد.

### استفاده از MCP Inspector

ما در درس‌های قبلی نحوه استفاده از این ابزار را توضیح داده‌ایم، اما اجازه دهید کمی به صورت کلی درباره آن صحبت کنیم. این ابزار با Node.js ساخته شده و می‌توانید با اجرای فایل اجرایی `npx` از آن استفاده کنید که به طور موقت ابزار را دانلود و نصب می‌کند و پس از اتمام اجرای درخواست شما، خود را پاک‌سازی می‌کند.

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) به شما کمک می‌کند:

- **کشف قابلیت‌های سرور**: به صورت خودکار منابع، ابزارها و پرامپت‌های موجود را شناسایی کند
- **آزمایش اجرای ابزار**: پارامترهای مختلف را امتحان کرده و پاسخ‌ها را به صورت زنده مشاهده کنید
- **مشاهده متادیتای سرور**: اطلاعات سرور، اسکیم‌ها و پیکربندی‌ها را بررسی کنید

اجرای معمول این ابزار به شکل زیر است:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

دستور بالا یک MCP و رابط بصری آن را راه‌اندازی کرده و یک رابط وب محلی در مرورگر شما باز می‌کند. انتظار می‌رود داشبوردی را ببینید که سرورهای MCP ثبت شده شما، ابزارها، منابع و پرامپت‌های موجود آن‌ها را نمایش می‌دهد. این رابط به شما امکان می‌دهد اجرای ابزارها را به صورت تعاملی آزمایش کنید، متادیتای سرور را بررسی کرده و پاسخ‌های زنده را مشاهده کنید که اعتبارسنجی و اشکال‌زدایی پیاده‌سازی‌های سرور MCP شما را آسان‌تر می‌کند.

نمایی از آن به این صورت است: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.fa.png)

همچنین می‌توانید این ابزار را در حالت CLI اجرا کنید که در این صورت باید صفت `--cli` را اضافه کنید. در اینجا مثالی از اجرای ابزار در حالت "CLI" که تمام ابزارهای موجود روی سرور را لیست می‌کند آورده شده است:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### آزمایش دستی

علاوه بر اجرای ابزار inspector برای آزمایش قابلیت‌های سرور، روش مشابه دیگر اجرای کلاینتی است که بتواند از HTTP استفاده کند، مانند curl.

با curl می‌توانید سرورهای MCP را مستقیماً با درخواست‌های HTTP آزمایش کنید:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

همانطور که در مثال بالا با curl مشاهده می‌کنید، از یک درخواست POST برای فراخوانی ابزار با استفاده از یک payload شامل نام ابزار و پارامترهای آن استفاده می‌کنید. روشی را انتخاب کنید که برای شما مناسب‌تر است. ابزارهای CLI معمولاً سریع‌تر هستند و قابلیت اسکریپت‌نویسی دارند که در محیط‌های CI/CD بسیار مفید است.

### آزمایش واحد

برای ابزارها و منابع خود تست‌های واحد ایجاد کنید تا مطمئن شوید به درستی کار می‌کنند. در اینجا نمونه‌ای از کد آزمایشی آورده شده است.

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

کد بالا موارد زیر را انجام می‌دهد:

- از چارچوب pytest استفاده می‌کند که به شما اجازه می‌دهد تست‌ها را به صورت توابع بنویسید و از دستورات assert استفاده کنید.
- یک MCP Server با دو ابزار مختلف ایجاد می‌کند.
- با استفاده از دستور `assert` بررسی می‌کند که شرایط مشخصی برآورده شده باشند.

می‌توانید فایل کامل را در [اینجا](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py) مشاهده کنید.

با استفاده از این فایل می‌توانید سرور خود را آزمایش کنید تا مطمئن شوید قابلیت‌ها به درستی ایجاد شده‌اند.

تمام SDKهای اصلی بخش‌های آزمایشی مشابهی دارند که می‌توانید بر اساس محیط اجرایی انتخابی خود آن‌ها را تنظیم کنید.

## نمونه‌ها

- [ماشین‌حساب Java](../samples/java/calculator/README.md)
- [ماشین‌حساب .Net](../../../../03-GettingStarted/samples/csharp)
- [ماشین‌حساب JavaScript](../samples/javascript/README.md)
- [ماشین‌حساب TypeScript](../samples/typescript/README.md)
- [ماشین‌حساب Python](../../../../03-GettingStarted/samples/python)

## منابع اضافی

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## مرحله بعد

- بعدی: [Deployment](/03-GettingStarted/09-deployment/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما در تلاش برای دقت هستیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است حاوی خطاها یا نادرستی‌هایی باشند. سند اصلی به زبان بومی خود باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ‌گونه سوء تفاهم یا برداشت نادرستی که از استفاده این ترجمه ناشی شود، نیستیم.