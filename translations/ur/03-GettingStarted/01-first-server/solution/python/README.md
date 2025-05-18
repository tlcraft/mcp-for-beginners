<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:14:07+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

آپ کو `uv` انسٹال کرنے کی سفارش کی جاتی ہے لیکن یہ لازمی نہیں ہے، [ہدایات](https://docs.astral.sh/uv/#highlights) دیکھیں

## -0- ایک ورچوئل ماحول بنائیں

```bash
python -m venv venv
```

## -1- ورچوئل ماحول کو فعال کریں

```bash
venv\Scrips\activate
```

## -2- ضروریات کو انسٹال کریں

```bash
pip install "mcp[cli]"
```

## -3- نمونے کو چلائیں

```bash
mcp run server.py
```

## -4- نمونے کو آزمائیں

ایک ٹرمینل میں سرور چلانے کے ساتھ، دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
mcp dev server.py
```

یہ ایک ویب سرور کو بصری انٹرفیس کے ساتھ شروع کرے گا جو آپ کو نمونے کو آزمانے کی اجازت دیتا ہے۔

جب سرور منسلک ہو جائے:

- ٹولز کی فہرست بنانے کی کوشش کریں اور `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` کو چلائیں، یہ اس کے گرد ایک ریپر ہے۔

آپ اسے CLI موڈ میں براہ راست چلانے کے لیے درج ذیل کمانڈ چلا سکتے ہیں:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

یہ سرور میں دستیاب تمام ٹولز کی فہرست بنائے گا۔ آپ کو درج ذیل نتائج دیکھنے چاہئیں:

```text
{
  "tools": [
    {
      "name": "add",
      "description": "Add two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "title": "A",
            "type": "integer"
          },
          "b": {
            "title": "B",
            "type": "integer"
          }
        },
        "required": [
          "a",
          "b"
        ],
        "title": "addArguments"
      }
    }
  ]
}
```

کسی ٹول کو چلانے کے لیے ٹائپ کریں:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

آپ کو درج ذیل نتائج دیکھنے چاہئیں:

```text
{
  "content": [
    {
      "type": "text",
      "text": "3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> عام طور پر CLI موڈ میں انسپکٹر کو چلانا براؤزر کی نسبت بہت تیز ہوتا ہے۔
> انسپکٹر کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لیے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا نقائص ہو سکتے ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں مستند ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔