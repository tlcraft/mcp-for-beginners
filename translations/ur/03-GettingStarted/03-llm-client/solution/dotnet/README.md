<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "24b8b80f2e64a0ee05d1fc394c158638",
  "translation_date": "2025-05-17T10:38:57+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/dotnet/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلائیں

> [!NOTE]
> یہ نمونہ فرض کرتا ہے کہ آپ GitHub Codespaces مثال استعمال کر رہے ہیں۔ اگر آپ اسے مقامی طور پر چلانا چاہتے ہیں، تو آپ کو GitHub پر ایک ذاتی رسائی ٹوکن ترتیب دینا ہوگا۔

## لائبریریاں انسٹال کریں

```sh
dotnet restore
```

درج ذیل لائبریریاں انسٹال ہونی چاہئیں: Azure AI Inference، Azure Identity، Microsoft.Extension، Model.Hosting، ModelContextProtocol

## چلائیں

```sh 
dotnet run
```

آپ کو ایک آؤٹ پٹ نظر آنا چاہیے جو اس سے ملتا جلتا ہو:

```text
Setting up stdio transport
Listing tools
Connected to server with tools: Add
Tool description: Adds two numbers
Tool parameters: {"title":"Add","description":"Adds two numbers","type":"object","properties":{"a":{"type":"integer"},"b":{"type":"integer"}},"required":["a","b"]}
Tool definition: Azure.AI.Inference.ChatCompletionsToolDefinition
Properties: {"a":{"type":"integer"},"b":{"type":"integer"}}
MCP Tools def: 0: Azure.AI.Inference.ChatCompletionsToolDefinition
Tool call 0: Add with arguments {"a":2,"b":4}
Sum 6
```

آؤٹ پٹ کا زیادہ تر حصہ صرف ڈیبگنگ ہے لیکن جو اہم ہے وہ یہ ہے کہ آپ MCP سرور سے ٹولز کی فہرست دے رہے ہیں، انہیں LLM ٹولز میں تبدیل کریں اور آپ کو ایک MCP کلائنٹ جواب "Sum 6" ملتا ہے۔

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لئے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا نقائص ہو سکتے ہیں۔ اصل دستاویز کو اس کی اصل زبان میں معتبر ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لئے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لئے ہم ذمہ دار نہیں ہیں۔