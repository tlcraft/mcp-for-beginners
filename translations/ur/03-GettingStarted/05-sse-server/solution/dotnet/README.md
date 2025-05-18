<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:53:22+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

## -1- انحصارات کو انسٹال کریں

```bash
dotnet run
```

## -2- نمونے کو چلائیں

```bash
dotnet run
```

## -3- نمونے کی جانچ کریں

نیچے دی گئی کمانڈ کو چلانے سے پہلے ایک علیحدہ ٹرمینل شروع کریں (یقینی بنائیں کہ سرور ابھی بھی چل رہا ہے)۔

ایک ٹرمینل میں سرور چلانے کے ساتھ، دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

یہ ایک ویب سرور کو بصری انٹرفیس کے ساتھ شروع کرے گا جو آپ کو نمونے کی جانچ کرنے کی اجازت دے گا۔

جب سرور جڑ جائے:

- ٹولز کی فہرست بنانے کی کوشش کریں اور `add` کو چلائیں، دلائل 2 اور 4 کے ساتھ، آپ کو نتیجے میں 6 نظر آنا چاہئے۔
- وسائل اور وسائل کے سانچے پر جائیں اور "greeting" کو کال کریں، ایک نام درج کریں اور آپ کو دیئے گئے نام کے ساتھ ایک خیرمقدم پیغام نظر آنا چاہئے۔

### CLI موڈ میں جانچ

آپ درج ذیل کمانڈ چلا کر اسے براہ راست CLI موڈ میں لانچ کر سکتے ہیں:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

یہ سرور میں دستیاب تمام ٹولز کی فہرست بنائے گا۔ آپ کو درج ذیل آؤٹ پٹ نظر آنا چاہئے:

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

کسی ٹول کو چلانے کے لئے ٹائپ کریں:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
```

آپ کو درج ذیل آؤٹ پٹ نظر آنا چاہئے:

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
> عام طور پر CLI موڈ میں انسپیکٹر کو چلانا براؤزر کے مقابلے میں زیادہ تیز ہوتا ہے۔
> انسپیکٹر کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**ڈسکلیمر**:
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کے لئے کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مقامی زبان میں مستند ذریعہ سمجھا جانا چاہئے۔ اہم معلومات کے لئے، پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔