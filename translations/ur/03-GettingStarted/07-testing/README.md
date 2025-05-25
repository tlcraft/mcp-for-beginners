<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "717f34718a773f6cf52d8445e40a96bf",
  "translation_date": "2025-05-17T12:40:04+00:00",
  "source_file": "03-GettingStarted/07-testing/README.md",
  "language_code": "ur"
}
-->
## ٹیسٹنگ اور ڈیبگنگ

اپنے MCP سرور کی جانچ شروع کرنے سے پہلے، دستیاب ٹولز اور ڈیبگنگ کے بہترین طریقوں کو سمجھنا ضروری ہے۔ مؤثر ٹیسٹنگ اس بات کو یقینی بناتی ہے کہ آپ کا سرور توقع کے مطابق کام کرے اور مسائل کی جلد شناخت اور حل کرنے میں مدد کرے۔ اگلا حصہ آپ کے MCP نفاذ کی توثیق کے لیے تجویز کردہ طریقوں کا خاکہ پیش کرتا ہے۔

## جائزہ

یہ سبق صحیح ٹیسٹنگ طریقہ کار اور مؤثر ترین ٹیسٹنگ ٹول کو منتخب کرنے کا احاطہ کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:

- ٹیسٹنگ کے مختلف طریقوں کی وضاحت کریں۔
- اپنے کوڈ کو مؤثر طریقے سے ٹیسٹ کرنے کے لیے مختلف ٹولز کا استعمال کریں۔

## MCP سرورز کی ٹیسٹنگ

MCP آپ کو اپنے سرورز کی جانچ اور ڈیبگ کرنے میں مدد کے لیے ٹولز فراہم کرتا ہے:

- **MCP انسپکٹر**: ایک کمانڈ لائن ٹول جو CLI ٹول اور بصری ٹول دونوں کے طور پر چلایا جا سکتا ہے۔
- **دستی جانچ**: آپ ویب درخواستیں چلانے کے لیے curl جیسے ٹول کا استعمال کر سکتے ہیں، لیکن کوئی بھی ٹول جو HTTP چلانے کی صلاحیت رکھتا ہو، کام کرے گا۔
- **یونٹ ٹیسٹنگ**: یہ ممکن ہے کہ آپ اپنے پسندیدہ ٹیسٹنگ فریم ورک کا استعمال کرکے سرور اور کلائنٹ دونوں کی خصوصیات کو جانچ سکیں۔

### MCP انسپکٹر کا استعمال

ہم نے اس ٹول کے استعمال کو پچھلے اسباق میں بیان کیا ہے لیکن آئیے اس پر تھوڑا سا اعلی سطح پر بات کرتے ہیں۔ یہ ایک ٹول ہے جو Node.js میں بنایا گیا ہے اور آپ اسے `npx` ایکزیکیوٹیبل کو کال کرکے استعمال کر سکتے ہیں جو خود ٹول کو عارضی طور پر ڈاؤن لوڈ اور انسٹال کرے گا اور آپ کی درخواست چلانے کے بعد خود کو صاف کر لے گا۔

[MCP انسپکٹر](https://github.com/modelcontextprotocol/inspector) آپ کی مدد کرتا ہے:

- **سرور کی صلاحیتیں دریافت کریں**: دستیاب وسائل، ٹولز، اور پرامپٹس کو خود بخود پتہ لگائیں
- **ٹول ایگزیکیوشن کی جانچ کریں**: مختلف پیرامیٹرز آزمائیں اور حقیقی وقت میں جوابات دیکھیں
- **سرور میٹا ڈیٹا دیکھیں**: سرور کی معلومات، اسکیمے، اور تشکیلات کا جائزہ لیں

ٹول کا ایک عام استعمال کچھ اس طرح نظر آتا ہے:

```bash
npx @modelcontextprotocol/inspector node build/index.js
```

اوپر دیا گیا کمانڈ MCP اور اس کا بصری انٹرفیس شروع کرتا ہے اور آپ کے براؤزر میں ایک مقامی ویب انٹرفیس لانچ کرتا ہے۔ آپ توقع کر سکتے ہیں کہ آپ کے رجسٹرڈ MCP سرورز، ان کے دستیاب ٹولز، وسائل، اور پرامپٹس کو دکھانے والا ایک ڈیش بورڈ نظر آئے گا۔ انٹرفیس آپ کو ٹول ایگزیکیوشن کو انٹرایکٹیو طور پر جانچنے، سرور میٹا ڈیٹا کا معائنہ کرنے، اور حقیقی وقت کے جوابات دیکھنے کی اجازت دیتا ہے، جس سے آپ کے MCP سرور نفاذ کی توثیق اور ڈیبگ کرنا آسان ہو جاتا ہے۔

یہ کچھ اس طرح نظر آ سکتا ہے: ![انسپکٹر](../../../../translated_images/connect.e0d648e6ecb359d05b60bba83261a6e6e73feb05290c47543a9994ca02e78886.ur.png)

آپ اس ٹول کو CLI موڈ میں بھی چلا سکتے ہیں جس صورت میں آپ `--cli` ایٹریبیوٹ شامل کرتے ہیں۔ یہاں "CLI" موڈ میں ٹول چلانے کی ایک مثال ہے جو سرور پر موجود تمام ٹولز کی فہرست بناتی ہے:

```sh
npx @modelcontextprotocol/inspector --cli node build/index.js --method tools/list
```

### دستی جانچ

سرور کی صلاحیتوں کی جانچ کے لیے انسپکٹر ٹول چلانے کے علاوہ، ایک اور اسی طرح کا طریقہ یہ ہے کہ HTTP استعمال کرنے کی صلاحیت رکھنے والے کلائنٹ کو چلایا جائے جیسے کہ مثال کے طور پر curl۔

curl کے ساتھ، آپ HTTP درخواستوں کا استعمال کرتے ہوئے MCP سرورز کو براہ راست جانچ سکتے ہیں:

```bash
# Example: Test server metadata
curl http://localhost:3000/v1/metadata

# Example: Execute a tool
curl -X POST http://localhost:3000/v1/tools/execute \
  -H "Content-Type: application/json" \
  -d '{"name": "calculator", "parameters": {"expression": "2+2"}}'
```

جیسا کہ آپ curl کے اوپر کے استعمال سے دیکھ سکتے ہیں، آپ ٹول کو اس کے نام اور پیرامیٹرز پر مشتمل پیلوڈ کا استعمال کرتے ہوئے POST درخواست کے ذریعے انویک کرتے ہیں۔ وہ طریقہ استعمال کریں جو آپ کے لیے سب سے بہتر ہو۔ عام طور پر CLI ٹولز استعمال کرنے میں تیز ہوتے ہیں اور انہیں اسکرپٹ کیا جا سکتا ہے جو CI/CD ماحول میں مفید ہو سکتا ہے۔

### یونٹ ٹیسٹنگ

اپنے ٹولز اور وسائل کے لیے یونٹ ٹیسٹ بنائیں تاکہ یہ یقینی بنایا جا سکے کہ وہ توقع کے مطابق کام کرتے ہیں۔ یہاں کچھ مثال کے طور پر ٹیسٹنگ کوڈ ہے۔

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

پیش کردہ کوڈ مندرجہ ذیل کام کرتا ہے:

- pytest فریم ورک کو فائدہ اٹھاتا ہے جو آپ کو فنکشنز کے طور پر ٹیسٹ بنانے اور assert بیانات استعمال کرنے دیتا ہے۔
- دو مختلف ٹولز کے ساتھ ایک MCP سرور بناتا ہے۔
- اس بات کو یقینی بنانے کے لیے `assert` بیان کا استعمال کرتا ہے کہ کچھ شرائط پوری ہوں۔

[مکمل فائل یہاں دیکھیں](https://github.com/modelcontextprotocol/python-sdk/blob/main/tests/client/test_list_methods_cursor.py)

اوپر دی گئی فائل کو دیکھتے ہوئے، آپ اپنے سرور کو جانچ سکتے ہیں تاکہ یہ یقینی بنایا جا سکے کہ صلاحیتیں جیسا کہ انہیں بنانا چاہیے، بنائی گئی ہیں۔

تمام بڑے SDKs کے پاس اسی طرح کے ٹیسٹنگ سیکشنز ہیں تاکہ آپ اپنے منتخب کردہ رن ٹائم کے مطابق ایڈجسٹ کر سکیں۔

## نمونے 

- [جاوا کیلکولیٹر](../samples/java/calculator/README.md)
- [.Net کیلکولیٹر](../../../../03-GettingStarted/samples/csharp)
- [جاوا اسکرپٹ کیلکولیٹر](../samples/javascript/README.md)
- [ٹائپ اسکرپٹ کیلکولیٹر](../samples/typescript/README.md)
- [پائتھن کیلکولیٹر](../../../../03-GettingStarted/samples/python) 

## اضافی وسائل

- [پائتھن SDK](https://github.com/modelcontextprotocol/python-sdk)

## اگلا کیا ہے

- اگلا: [تعیناتی](/03-GettingStarted/08-deployment/README.md)

**ڈس کلیمر**:
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا عدم درستگیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں مستند ماخذ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لیے ہم ذمہ دار نہیں ہیں۔