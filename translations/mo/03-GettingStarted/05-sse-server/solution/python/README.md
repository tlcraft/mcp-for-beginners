<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d700e180ce74b2675ce51a567a36c9e4",
  "translation_date": "2025-05-17T12:00:41+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/python/README.md",
  "language_code": "mo"
}
-->
# تشغيل هذا النموذج

يوصى بتثبيت `uv` ولكنه ليس ضروريًا، انظر [التعليمات](https://docs.astral.sh/uv/#highlights)

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

يجب أن يبدأ هذا خادم ويب بواجهة بصرية تتيح لك اختبار النموذج.

بمجرد الاتصال بالخادم:

- حاول سرد الأدوات وتشغيل `add`, with args 2 and 4, you should see 6 in the result.
- go to resources and resource template and call get_greeting, type in a name and you should see a greeting with the name you provided.

### Testing in ClI mode

The inspector you ran is actually a Node.js app and `mcp dev` هو غلاف حوله.

يمكنك تشغيله مباشرة في وضع CLI عن طريق تشغيل الأمر التالي:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/list
```

سيقوم ذلك بسرد جميع الأدوات المتاحة في الخادم. يجب أن ترى الناتج التالي:

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

لإطلاق أداة اكتب:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:8000/sse --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
```

يجب أن ترى الناتج التالي:

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
> عادةً ما يكون أسرع بكثير تشغيل المفتش في وضع CLI مقارنةً بالمتصفح.
> اقرأ المزيد عن المفتش [هنا](https://github.com/modelcontextprotocol/inspector).

The term "mo" is not a recognized language code or abbreviation for any specific language. If you meant to request a translation into a particular language, please specify the language name or code (such as "fr" for French, "es" for Spanish, etc.), and I'll be happy to assist you with the translation.