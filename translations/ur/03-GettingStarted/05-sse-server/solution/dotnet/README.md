<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-07-13T20:08:11+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

## -1- انحصار انسٹال کریں

```bash
dotnet restore
```

## -2- نمونہ چلائیں

```bash
dotnet run
```

## -3- نمونے کا ٹیسٹ کریں

نیچے دیے گئے کمانڈ کو چلانے سے پہلے ایک الگ ٹرمینل کھولیں (یقینی بنائیں کہ سرور ابھی بھی چل رہا ہے)۔

جب ایک ٹرمینل میں سرور چل رہا ہو، تو دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

یہ ایک ویب سرور شروع کرے گا جس میں ایک بصری انٹرفیس ہوگا جو آپ کو نمونے کا ٹیسٹ کرنے کی اجازت دے گا۔

> یقینی بنائیں کہ **SSE** کو ٹرانسپورٹ ٹائپ کے طور پر منتخب کیا گیا ہے، اور URL `http://localhost:3001/sse` ہے۔

جب سرور کنیکٹ ہو جائے:

- ٹولز کی فہرست بنانے کی کوشش کریں اور `add` چلائیں، دلائل 2 اور 4 کے ساتھ، آپ کو نتیجے میں 6 نظر آنا چاہیے۔
- resources اور resource template پر جائیں اور "greeting" کال کریں، ایک نام ٹائپ کریں اور آپ کو وہی نام کے ساتھ ایک سلام نظر آئے گا جو آپ نے فراہم کیا ہے۔

### CLI موڈ میں ٹیسٹنگ

آپ اسے براہ راست CLI موڈ میں درج ذیل کمانڈ چلانے سے شروع کر سکتے ہیں:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

یہ سرور میں دستیاب تمام ٹولز کی فہرست دکھائے گا۔ آپ کو درج ذیل آؤٹ پٹ نظر آئے گا:

```text
{
  "tools": [
    {
      "name": "AddNumbers",
      "description": "Add two numbers together.",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "description": "The first number",
            "type": "integer"
          },
          "b": {
            "description": "The second number",
            "type": "integer"
          }
        },
        "title": "AddNumbers",
        "description": "Add two numbers together.",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

کسی ٹول کو چلانے کے لیے ٹائپ کریں:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> عام طور پر CLI موڈ میں inspector کو براؤزر کے مقابلے میں چلانا زیادہ تیز ہوتا ہے۔
> inspector کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**دستخطی نوٹ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔