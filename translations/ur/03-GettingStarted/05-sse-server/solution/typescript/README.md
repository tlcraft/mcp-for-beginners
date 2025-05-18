<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:07:37+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "ur"
}
-->
# اس نمونے کو چلانا

## -1- انحصار کو انسٹال کریں

```bash
npm install
```

## -3- نمونے کو چلائیں

```bash
npm run build
```

## -4- نمونے کی جانچ کریں

جب سرور ایک ٹرمینل میں چل رہا ہو، تو دوسرا ٹرمینل کھولیں اور مندرجہ ذیل کمانڈ چلائیں:

```bash
npm run inspector
```

یہ ایک ویب سرور کو شروع کرے گا جس میں بصری انٹرفیس ہوگا جو آپ کو نمونے کی جانچ کرنے کی اجازت دے گا۔

جب سرور جڑ جائے:

- ٹولز کی فہرست بنانے کی کوشش کریں اور `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build` چلائیں۔

- ایک الگ ٹرمینل میں مندرجہ ذیل کمانڈ چلائیں:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    یہ سرور میں دستیاب تمام ٹولز کی فہرست بنائے گا۔ آپ کو مندرجہ ذیل آؤٹ پٹ دیکھنا چاہئے:

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

- ایک ٹول ٹائپ کو فعال کریں مندرجہ ذیل کمانڈ ٹائپ کر کے:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

آپ کو مندرجہ ذیل آؤٹ پٹ دیکھنا چاہئے:

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
> عام طور پر CLI موڈ میں انسپکٹر کو چلانا براؤزر کی نسبت زیادہ تیز ہوتا ہے۔
> انسپکٹر کے بارے میں مزید پڑھیں [یہاں](https://github.com/modelcontextprotocol/inspector)۔

**ڈسکلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ جبکہ ہم درستگی کے لئے کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستیاں ہوسکتی ہیں۔ اصل دستاویز کو اس کی اصل زبان میں معتبر ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لئے، پیشہ ور انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے لئے ہم ذمہ دار نہیں ہیں۔