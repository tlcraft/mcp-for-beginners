<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "37563349cd6894fe00489bf3b4d488ae",
  "translation_date": "2025-06-02T10:26:47+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ar"
}
-->
### -2- إنشاء مشروع

الآن بعد أن قمت بتثبيت SDK الخاص بك، دعنا ننتقل لإنشاء مشروع جديد:

### -3- إنشاء ملفات المشروع

### -4- كتابة كود الخادم

### -5- إضافة أداة وموارد

أضف أداة وموارد عبر إضافة الكود التالي:

### -6- الكود النهائي

دعنا نضيف الكود الأخير الذي نحتاجه حتى يتمكن الخادم من البدء:

### -7- اختبار الخادم

ابدأ الخادم باستخدام الأمر التالي:

### -8- التشغيل باستخدام أداة المفتش

أداة المفتش هي أداة رائعة تتيح لك تشغيل الخادم والتفاعل معه لاختبار عمله. لنبدأ تشغيلها:

> [!NOTE]
> قد يبدو مختلفًا في حقل "الأمر" لأنه يحتوي على الأمر لتشغيل الخادم باستخدام بيئة التشغيل الخاصة بك.

يجب أن ترى واجهة المستخدم التالية:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ar.png)

1. اتصل بالخادم عن طريق الضغط على زر Connect  
   بمجرد الاتصال بالخادم، يجب أن ترى ما يلي:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ar.png)

2. اختر "Tools" ثم "listTools"، يجب أن ترى خيار "Add" يظهر، اختر "Add" واملأ قيم المعلمات.

   سترى الاستجابة التالية، وهي نتيجة من أداة "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ar.png)

تهانينا، لقد تمكنت من إنشاء وتشغيل خادمك الأول!

### SDKs الرسمية

يوفر MCP SDKs رسمية للغات متعددة:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - تتم صيانته بالتعاون مع Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - تتم صيانته بالتعاون مع Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - التنفيذ الرسمي لـ TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - التنفيذ الرسمي لـ Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - التنفيذ الرسمي لـ Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - تتم صيانته بالتعاون مع Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - التنفيذ الرسمي لـ Rust

## النقاط الرئيسية

- إعداد بيئة تطوير MCP بسيط باستخدام SDKs الخاصة بكل لغة
- بناء خوادم MCP يتطلب إنشاء وتسجيل أدوات مع مخططات واضحة
- الاختبار وتصحيح الأخطاء ضروريان لضمان تنفيذ MCP موثوق

## عينات

- [آلة حاسبة Java](../samples/java/calculator/README.md)
- [آلة حاسبة .Net](../../../../03-GettingStarted/samples/csharp)
- [آلة حاسبة JavaScript](../samples/javascript/README.md)
- [آلة حاسبة TypeScript](../samples/typescript/README.md)
- [آلة حاسبة Python](../../../../03-GettingStarted/samples/python)

## المهمة

أنشئ خادم MCP بسيط مع أداة من اختيارك:
1. نفذ الأداة بلغتك المفضلة (.NET، Java، Python، أو JavaScript).
2. حدد معلمات الإدخال وقيم الإرجاع.
3. شغل أداة المفتش للتأكد من أن الخادم يعمل كما هو متوقع.
4. اختبر التنفيذ مع مدخلات متنوعة.

## الحل

[الحل](./solution/README.md)

## موارد إضافية

- [مستودع MCP على GitHub](https://github.com/microsoft/mcp-for-beginners)

## ما التالي

التالي: [البدء مع عملاء MCP](/03-GettingStarted/02-client/README.md)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالترجمة المهنية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.