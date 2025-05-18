<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b97c5e77cede68533d7a92d0ce89bc0a",
  "translation_date": "2025-05-17T11:53:08+00:00",
  "source_file": "03-GettingStarted/05-sse-server/solution/dotnet/README.md",
  "language_code": "ar"
}
-->
# تشغيل هذا النموذج

## -1- تثبيت التبعيات

```bash
dotnet run
```

## -2- تشغيل النموذج

```bash
dotnet run
```

## -3- اختبار النموذج

ابدأ نافذة طرفية منفصلة قبل تشغيل ما يلي (تأكد من أن الخادم لا يزال يعمل).

مع تشغيل الخادم في نافذة طرفية، افتح نافذة طرفية أخرى وشغل الأمر التالي:

```bash
npx @modelcontextprotocol/inspector http://localhost:3001
```

يجب أن يبدأ هذا تشغيل خادم ويب بواجهة مرئية تتيح لك اختبار النموذج.

بمجرد الاتصال بالخادم:

- حاول إدراج الأدوات وتشغيل `add` مع الوسائط 2 و 4، يجب أن ترى 6 في النتيجة.
- انتقل إلى الموارد وقالب الموارد وادعُ "greeting"، اكتب اسمًا ويجب أن ترى تحية بالاسم الذي قدمته.

### الاختبار في وضع CLI

يمكنك تشغيله مباشرة في وضع CLI عن طريق تشغيل الأمر التالي:

```bash 
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/list
```

سيقوم ذلك بإدراج جميع الأدوات المتاحة في الخادم. يجب أن ترى المخرجات التالية:

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

لاستدعاء أداة اكتب:

```bash
npx @modelcontextprotocol/inspector --cli http://localhost:3001 --method tools/call --tool-name AddNumbers --tool-arg a=1 --tool-arg b=2
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
> عادة ما يكون أسرع بكثير تشغيل المفتش في وضع CLI بدلاً من المتصفح.
> اقرأ المزيد عن المفتش [هنا](https://github.com/modelcontextprotocol/inspector).

**إخلاء المسؤولية**:  
تم ترجمة هذه الوثيقة باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار الوثيقة الأصلية بلغتها الأصلية المصدر الموثوق. للمعلومات الحيوية، يوصى بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ينشأ عن استخدام هذه الترجمة.