<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:49:23+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ur"
}
-->
# اس سیمپل کو چلانا

## -1- انحصاری پیکجز انسٹال کریں

```bash
dotnet restore
```

## -3- سیمپل چلائیں


```bash
dotnet run
```

## -4- سیمپل کی جانچ کریں

جب سرور ایک ٹرمینل میں چل رہا ہو، تو دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

یہ ایک ویب سرور شروع کرے گا جس میں ایک بصری انٹرفیس ہوگا جو آپ کو سیمپل کی جانچ کرنے کی اجازت دیتا ہے۔

جب سرور کنیکٹ ہو جائے: 

- ٹولز کی فہرست دیکھیں اور `add` کمانڈ چلائیں، دلائل 2 اور 4 کے ساتھ، آپ کو نتیجے میں 6 نظر آنا چاہیے۔
- resources اور resource template میں جائیں اور "greeting" کو کال کریں، کوئی نام ٹائپ کریں اور آپ کو وہی نام کے ساتھ ایک greeting نظر آئے گا جو آپ نے فراہم کیا ہے۔

### CLI موڈ میں جانچ

آپ اسے براہ راست CLI موڈ میں درج ذیل کمانڈ چلا کر شروع کر سکتے ہیں:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

یہ سرور میں دستیاب تمام ٹولز کی فہرست دکھائے گا۔ آپ کو درج ذیل آؤٹ پٹ نظر آنا چاہیے:

```text
{
  "tools": [
    {
      "name": "Add",
      "description": "Adds two numbers",
      "inputSchema": {
        "type": "object",
        "properties": {
          "a": {
            "type": "integer"
          },
          "b": {
            "type": "integer"
          }
        },
        "title": "Add",
        "description": "Adds two numbers",
        "required": [
          "a",
          "b"
        ]
      }
    }
  ]
}
```

کسی ٹول کو کال کرنے کے لیے ٹائپ کریں:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

آپ کو درج ذیل آؤٹ پٹ نظر آنا چاہیے:

```text
{
  "content": [
    {
      "type": "text",
      "text": "Sum 3"
    }
  ],
  "isError": false
}
```

> ![!TIP]
> CLI موڈ میں inspector کو چلانا عام طور پر براؤزر میں چلانے سے زیادہ تیز ہوتا ہے۔
> inspector کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**دستخطی اعلامیہ**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہِ کرم اس بات کا خیال رکھیں کہ خودکار ترجمے میں غلطیاں یا نواقص ہو سکتے ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جائے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔