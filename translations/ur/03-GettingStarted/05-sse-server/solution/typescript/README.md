<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-07-13T20:18:39+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

## -1- انحصاریات انسٹال کریں

```bash
npm install
```

## -3- نمونہ چلائیں

```bash
npm run build
```

## -4- نمونے کا ٹیسٹ کریں

جب سرور ایک ٹرمینل میں چل رہا ہو، تو دوسرا ٹرمینل کھولیں اور درج ذیل کمانڈ چلائیں:

```bash
npm run inspector
```

اس سے ایک ویب سرور شروع ہو جائے گا جس میں ایک بصری انٹرفیس ہوگا جو آپ کو نمونے کا ٹیسٹ کرنے کی اجازت دے گا۔

جب سرور کنیکٹ ہو جائے:

- ٹولز کی فہرست دیکھیں اور `add` چلائیں، دلائل کے طور پر 2 اور 4 دیں، آپ کو نتیجے میں 6 نظر آنا چاہیے۔
- resources اور resource template میں جائیں اور "greeting" کال کریں، کوئی نام ٹائپ کریں اور آپ کو وہ نام شامل کرتے ہوئے ایک سلام نظر آئے گا۔

### CLI موڈ میں ٹیسٹنگ

جو inspector آپ نے چلایا ہے وہ درحقیقت ایک Node.js ایپ ہے اور `mcp dev` اس کا ایک ریپر ہے۔

- سرور کو کمانڈ `npm run build` سے شروع کریں۔

- ایک الگ ٹرمینل میں درج ذیل کمانڈ چلائیں:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
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

- ٹول ٹائپ کو درج ذیل کمانڈ ٹائپ کر کے کال کریں:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

آپ کو درج ذیل آؤٹ پٹ نظر آئے گا:

    ```text
    {
        "content": [
        {
        "type": "text",
        "text": "3"
        }
        ]
    }
    ```

> ![!TIP]
> عام طور پر inspector کو CLI موڈ میں براؤزر کے مقابلے میں بہت تیزی سے چلایا جا سکتا ہے۔
> inspector کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**دستخطی دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا عدم درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کی ذمہ داری ہم پر عائد نہیں ہوتی۔