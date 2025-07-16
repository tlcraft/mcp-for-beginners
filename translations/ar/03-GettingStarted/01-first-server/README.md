<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "4d5b044c0924d393af3066e03d7d89c5",
  "translation_date": "2025-07-16T09:35:30+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ar"
}
-->
### -2- إنشاء المشروع

الآن بعد أن قمت بتثبيت SDK، دعنا ننتقل لإنشاء مشروع جديد:

### -3- إنشاء ملفات المشروع

### -4- كتابة كود الخادم

### -5- إضافة أداة وموارد

أضف أداة وموارد من خلال إضافة الكود التالي:

### -6- الكود النهائي

لنضيف الكود الأخير الذي نحتاجه لكي يبدأ الخادم بالعمل:

### -7- اختبار الخادم

ابدأ تشغيل الخادم باستخدام الأمر التالي:

### -8- التشغيل باستخدام أداة المفتش

أداة المفتش هي أداة رائعة تتيح لك تشغيل الخادم والتفاعل معه لاختبار عمله. لنبدأ تشغيلها:
> [!NOTE]
> قد يبدو مختلفًا في حقل "command" لأنه يحتوي على الأمر لتشغيل خادم باستخدام بيئة التشغيل الخاصة بك/
يجب أن ترى واجهة المستخدم التالية:

![Connect](/03-GettingStarted/01-first-server/assets/connect.png)

1. اتصل بالخادم عن طريق اختيار زر Connect  
   بمجرد الاتصال بالخادم، يجب أن ترى ما يلي:

   ![Connected](/03-GettingStarted/01-first-server/assets/connected.png)

1. اختر "Tools" ثم "listTools"، يجب أن يظهر "Add"، اختر "Add" واملأ قيم المعلمات.

   يجب أن ترى الاستجابة التالية، أي نتيجة من أداة "add":

   ![Result of running add](/03-GettingStarted/01-first-server/assets/ran-tool.png)

تهانينا، لقد تمكنت من إنشاء وتشغيل خادمك الأول!

### SDKs الرسمية

يوفر MCP SDKs رسمية لعدة لغات:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - تتم صيانته بالتعاون مع Microsoft  
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - تتم صيانته بالتعاون مع Spring AI  
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - التنفيذ الرسمي لـ TypeScript  
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - التنفيذ الرسمي لـ Python  
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - التنفيذ الرسمي لـ Kotlin  
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - تتم صيانته بالتعاون مع Loopwork AI  
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - التنفيذ الرسمي لـ Rust  

## النقاط الرئيسية

- إعداد بيئة تطوير MCP سهل باستخدام SDKs الخاصة بكل لغة  
- بناء خوادم MCP يتطلب إنشاء وتسجيل أدوات مع مخططات واضحة  
- الاختبار وتصحيح الأخطاء ضروريان لضمان تنفيذ MCP موثوق  

## عينات

- [حاسبة Java](../samples/java/calculator/README.md)  
- [حاسبة .Net](../../../../03-GettingStarted/samples/csharp)  
- [حاسبة JavaScript](../samples/javascript/README.md)  
- [حاسبة TypeScript](../samples/typescript/README.md)  
- [حاسبة Python](../../../../03-GettingStarted/samples/python)  

## المهمة

أنشئ خادم MCP بسيط مع أداة من اختيارك:

1. نفذ الأداة باللغة التي تفضلها (.NET، Java، Python، أو JavaScript).  
2. عرّف معلمات الإدخال وقيم الإرجاع.  
3. شغّل أداة الفاحص للتأكد من أن الخادم يعمل كما هو متوقع.  
4. اختبر التنفيذ مع مدخلات مختلفة.  

## الحل

[الحل](./solution/README.md)

## موارد إضافية

- [بناء وكلاء باستخدام Model Context Protocol على Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [MCP عن بُعد مع Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [وكيل .NET OpenAI MCP](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## ما التالي

التالي: [البدء مع عملاء MCP](../02-client/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.