<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e25bc265a51244a7a2d93b3761543a1f",
  "translation_date": "2025-06-13T02:05:55+00:00",
  "source_file": "03-GettingStarted/08-testing/README.md",
  "language_code": "ur"
}
-->
## ٹیسٹنگ اور ڈیبگنگ

اپنا MCP سرور ٹیسٹ کرنے سے پہلے، دستیاب ٹولز اور ڈیبگنگ کی بہترین طریقوں کو سمجھنا ضروری ہے۔ مؤثر ٹیسٹنگ یقینی بناتی ہے کہ آپ کا سرور توقع کے مطابق کام کرے اور آپ کو مسائل کو جلدی شناخت اور حل کرنے میں مدد دیتی ہے۔ درج ذیل سیکشن آپ کے MCP امپلیمنٹیشن کی تصدیق کے لیے سفارش کردہ طریقے بیان کرتا ہے۔

## جائزہ

یہ سبق صحیح ٹیسٹنگ طریقہ کار منتخب کرنے اور سب سے مؤثر ٹیسٹنگ ٹول کے استعمال پر مشتمل ہے۔

## سیکھنے کے مقاصد

اس سبق کے آخر تک، آپ قابل ہوں گے کہ:

- مختلف ٹیسٹنگ کے طریقوں کی وضاحت کریں۔
- اپنے کوڈ کو مؤثر طریقے سے ٹیسٹ کرنے کے لیے مختلف ٹولز استعمال کریں۔

## MCP سرورز کی ٹیسٹنگ

MCP آپ کے سرورز کو ٹیسٹ اور ڈیبگ کرنے کے لیے ٹولز فراہم کرتا ہے:

- **MCP Inspector**: ایک کمانڈ لائن ٹول جو CLI اور بصری دونوں طریقوں سے چلایا جا سکتا ہے۔
- **مینول ٹیسٹنگ**: آپ curl جیسے ٹول کا استعمال کرتے ہوئے ویب درخواستیں چلا سکتے ہیں، لیکن کوئی بھی HTTP چلانے والا ٹول کام کرے گا۔
- **یونٹ ٹیسٹنگ**: آپ اپنے پسندیدہ ٹیسٹنگ فریم ورک کا استعمال کر کے سرور اور کلائنٹ دونوں کی خصوصیات کو ٹیسٹ کر سکتے ہیں۔

### MCP Inspector کا استعمال

ہم نے اس ٹول کے استعمال کو پچھلے اسباق میں بیان کیا ہے لیکن یہاں اس پر مختصر بات کرتے ہیں۔ یہ ایک Node.js میں بنایا گیا ٹول ہے اور آپ اسے `npx` executable کو کال کر کے استعمال کر سکتے ہیں جو عارضی طور پر ٹول کو ڈاؤن لوڈ اور انسٹال کرے گا اور درخواست مکمل ہونے کے بعد خود کو صاف کر دے گا۔

[MCP Inspector](https://github.com/modelcontextprotocol/inspector) آپ کی مدد کرتا ہے:

- **سرور کی صلاحیتوں کا پتہ لگانا**: دستیاب وسائل، ٹولز، اور پرامپٹس خودکار طور پر دریافت کریں
- **ٹول کی عمل کاری کی جانچ**: مختلف پیرامیٹرز آزما کر حقیقی وقت میں جوابات دیکھیں
- **سرور میٹا ڈیٹا دیکھیں**: سرور کی معلومات، اسکیمے، اور کنفیگریشنز کا معائنہ کریں

ٹول کا ایک عام استعمال اس طرح دکھائی دیتا ہے:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

مندرجہ بالا کمانڈ ایک MCP اور اس کا بصری انٹرفیس شروع کرتی ہے اور آپ کے براؤزر میں ایک مقامی ویب انٹرفیس کھولتی ہے۔ آپ کو ایک ڈیش بورڈ نظر آئے گا جو آپ کے رجسٹرڈ MCP سرورز، ان کے دستیاب ٹولز، وسائل، اور پرامپٹس دکھاتا ہے۔ انٹرفیس آپ کو ٹول کی عمل کاری کو انٹرایکٹو طریقے سے ٹیسٹ کرنے، سرور میٹا ڈیٹا کو انسپیکٹ کرنے، اور حقیقی وقت کے جوابات دیکھنے کی اجازت دیتا ہے، جس سے آپ کے MCP سرور امپلیمنٹیشنز کی تصدیق اور ڈیبگنگ آسان ہو جاتی ہے۔

یہ کچھ اس طرح نظر آ سکتا ہے: ![Inspector](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ur.png)

آپ اس ٹول کو CLI موڈ میں بھی چلا سکتے ہیں، اس صورت میں آپ `--cli` خصوصیت شامل کریں۔ یہاں ایک مثال ہے جہاں ٹول کو "CLI" موڈ میں چلایا گیا ہے جو سرور پر تمام ٹولز کی فہرست دیتا ہے:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### مینول ٹیسٹنگ

انسپیکٹر ٹول کے ذریعے سرور کی صلاحیتوں کی جانچ کے علاوہ، ایک اور مشابہ طریقہ یہ ہے کہ کوئی ایسا کلائنٹ چلایا جائے جو HTTP استعمال کر سکے، جیسے curl۔

curl کے ذریعے آپ MCP سرورز کو براہ راست HTTP درخواستوں سے ٹیسٹ کر سکتے ہیں:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

جیسا کہ curl کے اوپر دیے گئے استعمال سے ظاہر ہے، آپ ایک POST درخواست کا استعمال کرتے ہوئے ٹول کو اس کے نام اور پیرامیٹرز کے ساتھ payload بھیج کر فعال کرتے ہیں۔ وہ طریقہ استعمال کریں جو آپ کے لیے سب سے بہتر ہو۔ CLI ٹولز عام طور پر تیزی سے استعمال ہوتے ہیں اور انہیں اسکرپٹ میں استعمال کیا جا سکتا ہے جو CI/CD ماحول میں مفید ہوتا ہے۔

### یونٹ ٹیسٹنگ

اپنے ٹولز اور وسائل کے لیے یونٹ ٹیسٹ بنائیں تاکہ یہ یقینی بنایا جا سکے کہ وہ توقع کے مطابق کام کر رہے ہیں۔ یہاں کچھ مثال کے طور پر ٹیسٹنگ کوڈ دیا گیا ہے۔

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

مندرجہ بالا کوڈ درج ذیل کام کرتا ہے:

- pytest فریم ورک کا استعمال کرتا ہے جو آپ کو فنکشنز کی شکل میں ٹیسٹ بنانے اور assert بیانات استعمال کرنے دیتا ہے۔
- دو مختلف ٹولز کے ساتھ ایک MCP سرور بناتا ہے۔
- certain conditions کی تکمیل کی جانچ کے لیے `assert` بیان استعمال کرتا ہے۔

[full file here](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py) پر نظر ڈالیں۔

مندرجہ بالا فائل کی بنیاد پر، آپ اپنے سرور کو ٹیسٹ کر سکتے ہیں تاکہ صلاحیتوں کی تخلیق کی تصدیق کی جا سکے جیسا کہ ہونا چاہیے۔

تمام بڑے SDKs میں اسی طرح کے ٹیسٹنگ سیکشنز ہوتے ہیں تاکہ آپ اپنے منتخب کردہ runtime کے مطابق ایڈجسٹ کر سکیں۔

## نمونے

- [Java Calculator](../samples/java/calculator/README.md)
- [.Net Calculator](../../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](../samples/javascript/README.md)
- [TypeScript Calculator](../samples/typescript/README.md)
- [Python Calculator](../../../../03-GettingStarted/samples/python)

## اضافی وسائل

- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)

## اگلا کیا ہے

- اگلا: [Deployment](/03-GettingStarted/09-deployment/README.md)

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں مستند ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تعبیر کی ذمہ داری ہم پر عائد نہیں ہوتی۔