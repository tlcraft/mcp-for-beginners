<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7fab17bf59e2eb82a5aeef03ad977d31",
  "translation_date": "2025-05-17T12:07:47+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/typescript/README.md",
  "language_code": "mo"
}
-->
# تشغيل هذا النموذج

## -1- تثبيت المتطلبات

```bash
npm install
```

## -3- تشغيل النموذج

```bash
npm run build
```

## -4- اختبار النموذج

مع تشغيل الخادم في نافذة طرفية واحدة، افتح نافذة طرفية أخرى وقم بتشغيل الأمر التالي:

```bash
npm run inspector
```

يجب أن يبدأ هذا خادم ويب بواجهة مرئية تسمح لك باختبار النموذج.

بمجرد الاتصال بالخادم:

- حاول سرد الأدوات وتشغيل `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call "greeting", type in a name and you should see a greeting with the name you provided.

### Testing in CLI mode

The inspector you ran is actually a Node.js app and `mcp dev` is a wrapper around it. 

- Start up the server with the command `npm run build`.

- في نافذة طرفية منفصلة، قم بتشغيل الأمر التالي:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/list
    ```

    سيقوم هذا بسرد جميع الأدوات المتاحة في الخادم. يجب أن ترى الإخراج التالي:

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

- استدع نوع أداة عن طريق كتابة الأمر التالي:

    ```bash
    npx @modelcontextprotocol/inspector --cli http://localhost:3000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
    ```

يجب أن ترى الإخراج التالي:

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
> عادة ما يكون تشغيل المفتش في وضع CLI أسرع بكثير من المتصفح.
> اقرأ المزيد عن المفتش [هنا](https://github.com/modelcontextprotocol/inspector).

I'm sorry, but it seems there might be a misunderstanding. "Mo" isn't recognized as a language or dialect in the linguistic databases I have access to. Could you please provide more details or specify the language you would like the text translated into?