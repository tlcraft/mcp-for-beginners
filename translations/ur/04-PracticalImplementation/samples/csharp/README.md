<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0bc7bd48f55f1565f1d95ccb2c16f728",
  "translation_date": "2025-06-18T07:47:04+00:00",
  "source_file": "04-PracticalImplementation/samples/csharp/README.md",
  "language_code": "ur"
}
-->
# نمونہ

پچھلا مثال دکھاتا ہے کہ کیسے ایک مقامی .NET پروجیکٹ کو `stdio` قسم کے ساتھ استعمال کیا جائے۔ اور کیسے سرور کو لوکل کنٹینر میں چلایا جائے۔ یہ کئی حالات میں ایک اچھا حل ہے۔ تاہم، سرور کو دور سے چلانا بھی فائدہ مند ہو سکتا ہے، جیسے کہ کلاؤڈ ماحول میں۔ یہی وہ جگہ ہے جہاں `http` قسم کام آتی ہے۔

`04-PracticalImplementation` فولڈر میں حل کو دیکھ کر یہ پہلے سے زیادہ پیچیدہ لگ سکتا ہے۔ لیکن حقیقت میں ایسا نہیں ہے۔ اگر آپ پروجیکٹ `src/Calculator` کو غور سے دیکھیں، تو آپ دیکھیں گے کہ یہ زیادہ تر پچھلے مثال جیسا ہی کوڈ ہے۔ فرق صرف یہ ہے کہ ہم HTTP درخواستوں کو ہینڈل کرنے کے لیے مختلف لائبریری `ModelContextProtocol.AspNetCore` استعمال کر رہے ہیں۔ اور ہم طریقہ `IsPrime` کو پرائیویٹ بنا دیتے ہیں، صرف یہ دکھانے کے لیے کہ آپ اپنے کوڈ میں پرائیویٹ طریقے رکھ سکتے ہیں۔ باقی کوڈ پہلے جیسا ہی ہے۔

دیگر پروجیکٹس [.NET Aspire](https://learn.microsoft.com/dotnet/aspire/get-started/aspire-overview) سے ہیں۔ حل میں .NET Aspire شامل کرنے سے ڈویلپر کا تجربہ بہتر ہوتا ہے جب وہ ترقی اور ٹیسٹنگ کر رہا ہوتا ہے اور یہ آبزرویبیلٹی میں مدد دیتا ہے۔ سرور چلانے کے لیے یہ ضروری نہیں ہے، لیکن اسے حل میں رکھنا ایک اچھی عادت ہے۔

## سرور کو لوکل چلائیں

1. VS Code (C# DevKit ایکسٹینشن کے ساتھ) سے، `04-PracticalImplementation/samples/csharp` ڈائریکٹری میں جائیں۔
1. سرور شروع کرنے کے لیے درج ذیل کمانڈ چلائیں:

   ```bash
    dotnet watch run --project ./src/AppHost
   ```

1. جب کوئی ویب براؤزر .NET Aspire ڈیش بورڈ کھولے، تو `http` URL نوٹ کریں۔ یہ کچھ اس طرح ہونا چاہیے: `http://localhost:5058/`۔

   ![.NET Aspire Dashboard](../../../../../translated_images/dotnet-aspire-dashboard.0a7095710e9301e90df2efd867e1b675b3b9bc2ccd7feb1ebddc0751522bc37c.ur.png)

## MCP Inspector کے ساتھ Streamable HTTP کا ٹیسٹ کریں

اگر آپ کے پاس Node.js 22.7.5 یا اس سے جدید ورژن ہے، تو آپ MCP Inspector کا استعمال کر کے اپنے سرور کا ٹیسٹ کر سکتے ہیں۔

سرور شروع کریں اور ٹرمینل میں درج ذیل کمانڈ چلائیں:

```bash
npx @modelcontextprotocol/inspector http://localhost:5058
```

![MCP Inspector](../../../../../translated_images/mcp-inspector.c223422b9b494fb4a518a3b3911b3e708e6a5715069470f9163ee2ee8d5f1ba9.ur.png)

- `Streamable HTTP` as the Transport type.
- In the Url field, enter the URL of the server noted earlier, and append `/mcp` منتخب کریں۔ یہ `http` ہونا چاہیے (نہ کہ `https`) something like `http://localhost:5058/mcp`.
- select the Connect button.

A nice thing about the Inspector is that it provide a nice visibility on what is happening.

- Try listing the available tools
- Try some of them, it should works just like before.

## Test MCP Server with GitHub Copilot Chat in VS Code

To use the Streamable HTTP transport with GitHub Copilot Chat, change the configuration of the `calc-mcp` سرور جو پہلے بنایا گیا تھا، اس طرح نظر آنا چاہیے:

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "http://localhost:5058/mcp"
    }
  }
}
```

کچھ ٹیسٹ کریں:

- پوچھیں "6780 کے بعد کے 3 پرائم نمبرز"۔ دھیان دیں کہ Copilot نئے ٹولز `NextFivePrimeNumbers` استعمال کرے گا اور صرف پہلے 3 پرائم نمبرز واپس کرے گا۔
- پوچھیں "111 کے بعد کے 7 پرائم نمبرز"، دیکھیں کیا ہوتا ہے۔
- پوچھیں "جان کے پاس 24 لولی ہیں اور وہ انہیں اپنے 3 بچوں میں تقسیم کرنا چاہتا ہے۔ ہر بچے کے پاس کتنی لولی ہیں؟"، دیکھیں کیا ہوتا ہے۔

## سرور کو Azure پر تعینات کریں

آئیے سرور کو Azure پر تعینات کرتے ہیں تاکہ زیادہ لوگ اسے استعمال کر سکیں۔

ٹرمینل سے، `04-PracticalImplementation/samples/csharp` فولڈر میں جائیں اور درج ذیل کمانڈ چلائیں:

```bash
azd up
```

جب تعیناتی مکمل ہو جائے، تو آپ کو اس طرح کا پیغام نظر آئے گا:

![Azd deployment success](../../../../../translated_images/azd-deployment-success.bd42940493f1b834a5ce6251a6f88966546009b350df59d0cc4a8caabe94a4f1.ur.png)

URL حاصل کریں اور اسے MCP Inspector اور GitHub Copilot Chat میں استعمال کریں۔

```jsonc
// .vscode/mcp.json
{
  "servers": {
    "calc-mcp": {
      "type": "http",
      "url": "https://calc-mcp.gentleriver-3977fbcf.australiaeast.azurecontainerapps.io/mcp"
    }
  }
}
```

## آگے کیا؟

ہم مختلف ٹرانسپورٹ اقسام اور ٹیسٹنگ ٹولز آزما رہے ہیں۔ ہم آپ کے MCP سرور کو Azure پر بھی تعینات کرتے ہیں۔ لیکن اگر ہمارے سرور کو پرائیویٹ وسائل تک رسائی کی ضرورت ہو؟ مثلاً، کوئی ڈیٹا بیس یا پرائیویٹ API؟ اگلے باب میں، ہم دیکھیں گے کہ کس طرح ہم اپنے سرور کی سیکیورٹی کو بہتر بنا سکتے ہیں۔

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا بے دقتیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جائے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ تجویز کیا جاتا ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔