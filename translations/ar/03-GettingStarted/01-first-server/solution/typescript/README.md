<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "ac67652abc453e2a7e2c75cd7a8897ae",
  "translation_date": "2025-07-13T18:03:24+00:00",
  "source_file": "03-GettingStarted/01-first-server/solution/typescript/README.md",
  "language_code": "ar"
}
-->
# تشغيل هذا المثال

يوصى بتثبيت `uv` لكنه ليس ضروريًا، راجع [التعليمات](https://docs.astral.sh/uv/#highlights)

## -1- تثبيت التبعيات

```bash
npm install
```

## -3- تشغيل المثال

```bash
npm run build
```

## -4- اختبار المثال

مع تشغيل الخادم في نافذة طرفية واحدة، افتح نافذة طرفية أخرى وقم بتشغيل الأمر التالي:

```bash
npm run inspector
```

يجب أن يبدأ هذا خادم ويب بواجهة بصرية تتيح لك اختبار المثال.

بمجرد اتصال الخادم:

- جرب عرض الأدوات وتشغيل `add` مع الوسيطات 2 و4، يجب أن ترى النتيجة 6.
- انتقل إلى الموارد وقالب الموارد واستدعِ "greeting"، اكتب اسمًا ويجب أن ترى تحية بالاسم الذي أدخلته.

### الاختبار في وضع CLI

المفتش الذي شغلته هو في الواقع تطبيق Node.js و`mcp dev` هو غلاف له.

يمكنك تشغيله مباشرة في وضع CLI عن طريق تنفيذ الأمر التالي:

```bash
npx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/list
```

سيعرض هذا جميع الأدوات المتاحة في الخادم. يجب أن ترى المخرجات التالية:

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

لاستدعاء أداة اكتب:

```bash
nnpx @modelcontextprotocol/inspector --cli node ./build/index.js --method tools/call --tool-name add --tool-arg a=1 --tool-arg b=2
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
> عادةً ما يكون تشغيل المفتش في وضع CLI أسرع بكثير من تشغيله في المتصفح.
> اقرأ المزيد عن المفتش [هنا](https://github.com/modelcontextprotocol/inspector).

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.