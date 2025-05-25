<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:06:53+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

## -1- ضروریات کو انسٹال کریں

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- نمونہ چلائیں

```bash
dotnet run
```

## -4- نمونہ ٹیسٹ کریں

ایک ٹرمینل میں سرور چل رہا ہو تو، دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

یہ ایک ویب سرور شروع کرے گا جس میں بصری انٹرفیس ہوگا جو آپ کو نمونے کو ٹیسٹ کرنے کی اجازت دے گا۔

جب سرور منسلک ہو جائے:

- ٹولز کی فہرست بنانے کی کوشش کریں اور `add` چلائیں، دلائل 2 اور 4 کے ساتھ، آپ کو نتیجے میں 6 نظر آنا چاہیے۔
- وسائل اور وسائل کے سانچے پر جائیں اور "greeting" کو کال کریں، ایک نام درج کریں اور آپ کو آپ کے فراہم کردہ نام کے ساتھ ایک سلام نظر آنا چاہیے۔

### CLI موڈ میں ٹیسٹنگ

آپ درج ذیل کمانڈ چلا کر اسے براہ راست CLI موڈ میں شروع کر سکتے ہیں:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

یہ سرور میں دستیاب تمام ٹولز کی فہرست بنائے گا۔ آپ کو درج ذیل آؤٹ پٹ نظر آنا چاہیے:

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

کسی ٹول کو چلانے کے لیے ٹائپ کریں:

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
> عام طور پر CLI موڈ میں انسپکٹر کو چلانا براؤزر کی نسبت بہت تیز ہوتا ہے۔
> انسپکٹر کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**ڈس کلیمر**:
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لئے کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار تراجم میں غلطیاں یا نادانستہ تبدیلیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی اصل زبان میں مستند ماخذ سمجھا جانا چاہئے۔ اہم معلومات کے لئے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمہ کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔