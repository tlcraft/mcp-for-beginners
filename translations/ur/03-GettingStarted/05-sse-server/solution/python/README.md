<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-07-13T20:13:22+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

آپ کو `uv` انسٹال کرنے کی سفارش کی جاتی ہے لیکن یہ ضروری نہیں، مزید معلومات کے لیے [ہدایات](https://docs.astral.sh/uv/#highlights) دیکھیں۔

## -0- ایک ورچوئل ماحول بنائیں

```bash
python -m venv venv
```

## -1- ورچوئل ماحول کو فعال کریں

```bash
venv\Scrips\activate
```

## -2- انحصار انسٹال کریں

```bash
pip install "mcp[cli]"
```

## -3- نمونہ چلائیں

```bash
mcp run server.py
```

## -4- نمونے کا ٹیسٹ کریں

جب سرور ایک ٹرمینل میں چل رہا ہو، تو دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
mcp dev server.py
```

اس سے ایک ویب سرور شروع ہو جائے گا جس کا ایک بصری انٹرفیس ہوگا جو آپ کو نمونے کا ٹیسٹ کرنے کی اجازت دے گا۔

جب سرور کنیکٹ ہو جائے:

- ٹولز کی فہرست دیکھنے کی کوشش کریں اور `add` چلائیں، دلائل 2 اور 4 کے ساتھ، آپ کو نتیجے میں 6 نظر آنا چاہیے۔
- resources اور resource template پر جائیں اور get_greeting کال کریں، ایک نام ٹائپ کریں اور آپ کو وہی نام کے ساتھ ایک سلامی نظر آئے گی جو آپ نے فراہم کی ہے۔

### CLI موڈ میں ٹیسٹنگ

جو inspector آپ نے چلایا ہے وہ درحقیقت ایک Node.js ایپ ہے اور `mcp dev` اس کا ایک ریپر ہے۔

آپ اسے براہ راست CLI موڈ میں درج ذیل کمانڈ چلا کر لانچ کر سکتے ہیں:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

یہ سرور میں دستیاب تمام ٹولز کی فہرست دکھائے گا۔ آپ کو درج ذیل آؤٹ پٹ نظر آئے گا:

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
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

آپ کو درج ذیل آؤٹ پٹ نظر آئے گا:

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
> عام طور پر inspector کو CLI موڈ میں براؤزر کے مقابلے میں بہت تیزی سے چلایا جا سکتا ہے۔
> inspector کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**دستخطی دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔