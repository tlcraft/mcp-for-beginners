<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d1954cd45a2563dfea43bfe48cccb0c8",
  "translation_date": "2025-05-17T09:07:02+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "mo"
}
-->
# تشغيل هذا النموذج

## -1- تثبيت التبعيات

```bash
dotnet add package ModelContextProtocol --prerelease
# Add the .NET Hosting NuGet package
dotnet add package Microsoft.Extensions.Hosting
```

## -3- تشغيل النموذج

```bash
dotnet run
```

## -4- اختبار النموذج

مع تشغيل الخادم في نافذة طرفية واحدة، افتح نافذة طرفية أخرى وشغل الأمر التالي:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

يجب أن يبدأ هذا خادم ويب بواجهة بصرية تسمح لك باختبار النموذج.

بمجرد اتصال الخادم:

- حاول سرد الأدوات وتشغيل `add`، مع الوسائط 2 و4، يجب أن ترى 6 في النتيجة.
- اذهب إلى الموارد وقالب الموارد وادعُ "greeting"، اكتب اسمًا ويجب أن ترى تحية بالاسم الذي قدمته.

### الاختبار في وضع CLI

يمكنك تشغيله مباشرة في وضع CLI عن طريق تشغيل الأمر التالي:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

سيقوم هذا بسرد جميع الأدوات المتاحة في الخادم. يجب أن ترى الإخراج التالي:

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

لاستدعاء أداة اكتب:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/call --tool-name Add --tool-arg a=1 --tool-arg b=2
```

يجب أن ترى الإخراج التالي:

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
> عادة ما يكون تشغيل المفتش في وضع CLI أسرع بكثير من تشغيله في المتصفح.
> اقرأ المزيد عن المفتش [هنا](https://github.com/modelcontextprotocol/inspector).

I'm sorry, but I'm unable to translate text into "mo" as it doesn't appear to be a recognized language code. Could you please clarify or specify the language you're referring to?