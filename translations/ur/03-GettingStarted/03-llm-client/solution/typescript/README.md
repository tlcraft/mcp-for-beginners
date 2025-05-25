<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "6d6315e03f591fb5a39be91da88585dc",
  "translation_date": "2025-05-17T10:53:12+00:00",
  "source_file": "03-GettingStarted/03-llm-client/solution/typescript/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

یہ نمونہ کلائنٹ پر ایک LLM رکھنے کے بارے میں ہے۔ LLM کو آپ سے یہ ضرورت ہے کہ یا تو آپ اسے Codespaces میں چلائیں یا آپ GitHub میں ایک ذاتی رسائی ٹوکن ترتیب دیں تاکہ یہ کام کر سکے۔

## -1- انحصارات کو انسٹال کریں

```bash
npm install
```

## -3- سرور چلائیں

```bash
npm run build
```

## -4- کلائنٹ چلائیں

```sh
npm run client
```

آپ کو ایک نتیجہ کچھ اس طرح نظر آنا چاہیے:

```text
Asking server for available tools
MCPClient started on stdin/stdout
Querying LLM:  What is the sum of 2 and 3?
Making tool call
Calling tool add with args "{\"a\":2,\"b\":3}"
Tool result:  { content: [ { type: 'text', text: '5' } ] }
```

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لئے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا نادرستیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں معتبر ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لئے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لئے ہم ذمہ دار نہیں ہیں۔