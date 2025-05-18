<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:00:33+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

آپ کو `uv` انسٹال کرنے کی سفارش کی جاتی ہے، لیکن یہ ضروری نہیں ہے، مزید معلومات کے لیے [ہدایات](https://docs.astral.sh/uv/#highlights) دیکھیں۔

## -0- ایک ورچوئل ماحول بنائیں

```bash
python -m venv venv
```

## -1- ورچوئل ماحول کو فعال کریں

```bash
venv\Scrips\activate
```

## -2- ضروریات انسٹال کریں

```bash
pip install "mcp[cli]"
```

## -3- نمونے کو چلائیں

```bash
mcp run server.py
```

## -4- نمونے کی جانچ کریں

جب سرور ایک ٹرمینل میں چل رہا ہو، تو دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
mcp dev server.py
```

یہ ایک ویب سرور شروع کرے گا جس میں بصری انٹرفیس ہوگا جو آپ کو نمونے کی جانچ کرنے کی اجازت دیتا ہے۔

جب سرور کنیکٹ ہو جائے:

- ٹولز کی فہرست بنانے کی کوشش کریں اور `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` اس کے ارد گرد ایک لفافہ ہے۔

آپ اسے CLI موڈ میں براہ راست درج ذیل کمانڈ چلا کر لانچ کر سکتے ہیں:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

یہ سرور میں دستیاب تمام ٹولز کی فہرست بنائے گا۔ آپ کو درج ذیل آؤٹ پٹ نظر آنا چاہیے:

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

کسی ٹول کو چلانے کے لیے درج کریں:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

آپ کو درج ذیل آؤٹ پٹ نظر آنا چاہیے:

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
> عام طور پر CLI موڈ میں انسپیکٹر کو چلانا براؤزر میں چلانے سے کہیں زیادہ تیز ہوتا ہے۔
> انسپیکٹر کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**ڈس کلیمر**:
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لیے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غلطیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں مستند ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔