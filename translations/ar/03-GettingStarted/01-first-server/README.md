<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "e650db55873b456296a9c620069e2f71",
  "translation_date": "2025-06-02T11:01:18+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ar"
}
-->
### -2- إنشاء مشروع

الآن بعد أن قمت بتثبيت SDK الخاص بك، دعنا ننشئ مشروعًا في الخطوة التالية:

### -3- إنشاء ملفات المشروع

### -4- كتابة كود الخادم

### -5- إضافة أداة وموارد

أضف أداة وموارد من خلال إضافة الكود التالي:

### -6- الكود النهائي

لنضيف الكود الأخير الذي نحتاجه ليتمكن الخادم من البدء:

### -7- اختبار الخادم

ابدأ الخادم باستخدام الأمر التالي:

### -8- التشغيل باستخدام المفتش

المفتش أداة رائعة يمكنها تشغيل خادمك وتتيح لك التفاعل معه لاختبار عمله. دعنا نبدأ تشغيله:

> [!NOTE]
> قد يبدو مختلفًا في حقل "command" لأنه يحتوي على الأمر لتشغيل الخادم باستخدام بيئة التشغيل الخاصة بك.

يجب أن ترى واجهة المستخدم التالية:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ar.png)

1. اتصل بالخادم عن طريق اختيار زر الاتصال  
   بمجرد الاتصال بالخادم، يجب أن ترى ما يلي:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ar.png)

2. اختر "Tools" ثم "listTools"، يجب أن ترى خيار "Add" يظهر، اختر "Add" واملأ قيم المعاملات.

   يجب أن ترى الاستجابة التالية، أي نتيجة من أداة "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ar.png)

تهانينا، لقد تمكنت من إنشاء وتشغيل أول خادم لك!

### SDKs الرسمية

يوفر MCP SDKs رسمية لعدة لغات:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - يتم صيانته بالتعاون مع Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - يتم صيانته بالتعاون مع Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - التنفيذ الرسمي لـ TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - التنفيذ الرسمي لـ Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - التنفيذ الرسمي لـ Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - يتم صيانته بالتعاون مع Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - التنفيذ الرسمي لـ Rust

## النقاط الرئيسية

- إعداد بيئة تطوير MCP بسيط باستخدام SDKs الخاصة بكل لغة
- بناء خوادم MCP يتضمن إنشاء وتسجيل أدوات مع مخططات واضحة
- الاختبار وتصحيح الأخطاء ضروريان لضمان موثوقية تنفيذ MCP

## عينات

- [حاسبة Java](../samples/java/calculator/README.md)
- [حاسبة .Net](../../../../03-GettingStarted/samples/csharp)
- [حاسبة JavaScript](../samples/javascript/README.md)
- [حاسبة TypeScript](../samples/typescript/README.md)
- [حاسبة Python](../../../../03-GettingStarted/samples/python)

## التمرين

أنشئ خادم MCP بسيط مع أداة من اختيارك:
1. نفذ الأداة في اللغة التي تفضلها (.NET، Java، Python، أو JavaScript).
2. حدد معلمات الإدخال وقيم الإرجاع.
3. شغّل أداة المفتش للتأكد من عمل الخادم كما هو متوقع.
4. اختبر التنفيذ مع مدخلات مختلفة.

## الحل

[الحل](./solution/README.md)

## موارد إضافية

- [مستودع MCP على GitHub](https://github.com/microsoft/mcp-for-beginners)

## ما التالي

التالي: [البدء مع عملاء MCP](/03-GettingStarted/02-client/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى جاهدين للدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة المهنية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.