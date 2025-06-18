<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "2a58caa6e11faa09470b7f81e6729652",
  "translation_date": "2025-06-18T05:49:30+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ur"
}
-->
# اس سیمپل کو چلانا

## -1- ضروری لائبریریز انسٹال کریں

```bash
dotnet restore
```

## -2- سیمپل چلائیں

```bash
dotnet run
```

## -3- سیمپل کی جانچ کریں

نیچے دی گئی کمانڈ چلانے سے پہلے ایک الگ ٹرمینل کھولیں (یقینی بنائیں کہ سرور ابھی بھی چل رہا ہے)۔

جب ایک ٹرمینل میں سرور چل رہا ہو، تو دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

اس سے ایک ویب سرور شروع ہوگا جس کا ایک بصری انٹرفیس ہوگا جو آپ کو سیمپل کی جانچ کرنے کی اجازت دے گا۔

> یقینی بنائیں کہ **SSE** کو ٹرانسپورٹ ٹائپ کے طور پر منتخب کیا گیا ہے، اور URL `http://localhost:3001/sse`.

Once the server is connected: 

- try listing tools and run `add` ہے، اور دلائل 2 اور 4 ہیں، آپ نتیجہ میں 6 دیکھیں گے۔
- resources اور resource template پر جائیں اور "greeting" کال کریں، ایک نام ٹائپ کریں اور آپ کو وہ نام شامل کر کے ایک سلام دیکھنا چاہیے۔

### CLI موڈ میں جانچ

آپ اسے براہ راست CLI موڈ میں درج ذیل کمانڈ چلا کر شروع کر سکتے ہیں:

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
> عام طور پر inspector کو CLI موڈ میں براؤزر کی نسبت زیادہ تیزی سے چلایا جا سکتا ہے۔
> inspector کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**دستخطی وضاحت**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں مستند ذریعہ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر نہیں ہوگی۔