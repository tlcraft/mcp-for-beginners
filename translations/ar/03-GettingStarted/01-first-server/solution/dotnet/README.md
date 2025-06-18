<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1d6ed68c1dd1584c2d8eb599fa601c0b",
  "translation_date": "2025-06-18T05:48:03+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/dotnet/README.md",
  "language_code": "ar"
}
-->
# تشغيل هذا المثال

## -1- تثبيت التبعيات

```bash
dotnet restore
```

## -3- تشغيل المثال


```bash
dotnet run
```

## -4- اختبار المثال

مع تشغيل الخادم في نافذة طرفية واحدة، افتح نافذة طرفية أخرى وقم بتشغيل الأمر التالي:

```bash
npx @modelcontextprotocol/inspector dotnet run
```

هذا يجب أن يبدأ خادم ويب مع واجهة بصرية تتيح لك اختبار المثال.

بمجرد اتصال الخادم:

- جرب عرض الأدوات وتشغيل `add` مع الوسيطين 2 و 4، يجب أن ترى النتيجة 6.
- انتقل إلى الموارد وقالب المورد واطلب "greeting"، اكتب اسمًا وسترى تحية بالاسم الذي أدخلته.

### الاختبار في وضع CLI

يمكنك تشغيله مباشرة في وضع CLI عن طريق تنفيذ الأمر التالي:

```bash
npx @modelcontextprotocol/inspector --cli dotnet run --method tools/list
```

سيعرض هذا جميع الأدوات المتاحة في الخادم. يجب أن ترى الإخراج التالي:

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
> عادةً ما يكون تشغيل الـ inspector في وضع CLI أسرع بكثير من تشغيله في المتصفح.
> اقرأ المزيد عن الـ inspector [هنا](https://github.com/modelcontextprotocol/inspector).

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاستعانة بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة ناتجة عن استخدام هذه الترجمة.