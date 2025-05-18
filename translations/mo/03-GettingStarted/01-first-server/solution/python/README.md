<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "c49dc211615eefbcd6ea6e7d9f2d4e39",
  "translation_date": "2025-05-17T09:14:15+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/python/README.md",
  "language_code": "mo"
}
-->
# تشغيل هذا النموذج

يوصى بتثبيت `uv` لكنه ليس ضروريًا، انظر [التعليمات](https://docs.astral.sh/uv/#highlights)

## -0- إنشاء بيئة افتراضية

```bash
python -m venv venv
```

## -1- تفعيل البيئة الافتراضية

```bash
venv\Scrips\activate
```

## -2- تثبيت التبعيات

```bash
pip install "mcp[cli]"
```

## -3- تشغيل النموذج

```bash
mcp run server.py
```

## -4- اختبار النموذج

مع تشغيل الخادم في نافذة طرفية واحدة، افتح نافذة طرفية أخرى وقم بتشغيل الأمر التالي:

```bash
mcp dev server.py
```

يجب أن يبدأ هذا خادم ويب بواجهة مرئية تسمح لك باختبار النموذج.

بمجرد اتصال الخادم:

- حاول إدراج الأدوات وتشغيل `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` هو غلاف حوله.

يمكنك تشغيله مباشرة في وضع CLI عن طريق تشغيل الأمر التالي:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/list
```

سيقوم هذا بإدراج جميع الأدوات المتاحة في الخادم. يجب أن ترى المخرجات التالية:

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

للاستدعاء أداة اكتب:

```bash
npx @modelcontextprotocol/inspector --cli mcp run server.py --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

يجب أن ترى المخرجات التالية:

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
> عادةً ما يكون أسرع بكثير تشغيل المفتش في وضع CLI بدلاً من المتصفح.
> اقرأ المزيد عن المفتش [هنا](https://github.com/modelcontextprotocol/inspector).

I'm sorry, but I'm not familiar with a language or dialect called "mo." Could you please provide more context or specify the language you're referring to?