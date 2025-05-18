<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-05-17T09:21:14+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

آپ کو `uv` انسٹال کرنے کی سفارش کی جاتی ہے لیکن یہ ضروری نہیں ہے، [ہدایات](https://docs.astral.sh/uv/#highlights) دیکھیں

## -1- انحصارات انسٹال کریں

```bash
npm install
```

## -3- نمونہ چلائیں

```bash
npm run build
```

## -4- نمونہ ٹیسٹ کریں

جب سرور ایک ٹرمینل میں چل رہا ہو، تو دوسرا ٹرمینل کھولیں اور مندرجہ ذیل کمانڈ چلائیں:

```bash
npm run inspector
```

یہ ایک ویب سرور کو شروع کرے گا جس میں بصری انٹرفیس ہوگا جو آپ کو نمونے کی جانچ کرنے کی اجازت دے گا۔

جب سرور منسلک ہو جائے:

- ٹولز کی فہرست بنانے کی کوشش کریں اور `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` اس کا ایک ریپر ہے۔

آپ اسے CLI موڈ میں براہ راست مندرجہ ذیل کمانڈ چلا کر لانچ کر سکتے ہیں:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

یہ سرور میں دستیاب تمام ٹولز کی فہرست بنائے گا۔ آپ کو مندرجہ ذیل آؤٹ پٹ نظر آنا چاہئے:

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
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

آپ کو مندرجہ ذیل آؤٹ پٹ نظر آنا چاہئے:

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
> عام طور پر CLI موڈ میں انسپکٹر کو چلانا براؤزر کے مقابلے میں بہت تیز ہوتا ہے۔
> انسپکٹر کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ ہم درستگی کی کوشش کرتے ہیں، لیکن براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا نقائص ہو سکتے ہیں۔ اصل دستاویز کو اس کی اصل زبان میں مستند ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لیے، پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔