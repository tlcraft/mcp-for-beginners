<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "262e6e510f0c3fe1e36180eadcd67c33",
  "translation_date": "2025-06-02T17:18:25+00:00",
  "source_file": "03-GettingStarted/01-first-server/README.md",
  "language_code": "ar"
}
-->
### -2- إنشاء مشروع

الآن بعد أن قمت بتثبيت SDK، دعنا ننشئ مشروعًا في الخطوة التالية:

### -3- إنشاء ملفات المشروع

### -4- كتابة كود الخادم

### -5- إضافة أداة وموارد

أضف أداة وموارد بإضافة الكود التالي:

### -6- الكود النهائي

لنُضفِ الكود الأخير الذي نحتاجه لكي يبدأ الخادم بالعمل:

### -7- اختبار الخادم

ابدأ تشغيل الخادم باستخدام الأمر التالي:

### -8- التشغيل باستخدام المفتش

المفتش أداة رائعة يمكنها تشغيل الخادم الخاص بك وتتيح لك التفاعل معه حتى تتمكن من اختبار عمله. لنبدأ تشغيله:

> [!NOTE]
> قد يظهر مختلفًا في حقل "الأمر" لأنه يحتوي على الأمر الخاص بتشغيل الخادم مع بيئة التشغيل الخاصة بك

ينبغي أن ترى واجهة المستخدم التالية:

![Connect](../../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ar.png)

1. اتصل بالخادم بالضغط على زر Connect  
   بمجرد اتصالك بالخادم، سترى الآن ما يلي:

   ![Connected](../../../../translated_images/connected.73d1e042c24075d386cacdd4ee7cd748c16364c277d814e646ff2f7b5eefde85.ar.png)

2. اختر "Tools" ثم "listTools"، سترى ظهور "Add"، اختر "Add" واملأ قيم المعلمات.

   سترى الرد التالي، وهو نتيجة من أداة "add":

   ![Result of running add](../../../../translated_images/ran-tool.a5a6ee878c1369ec1e379b81053395252a441799dbf23416c36ddf288faf8249.ar.png)

تهانينا، لقد تمكنت من إنشاء وتشغيل خادمك الأول!

### SDKs الرسمية

يوفر MCP SDKs رسمية لعدة لغات:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - تُدار بالتعاون مع مايكروسوفت
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - تُدار بالتعاون مع Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - التنفيذ الرسمي لـ TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - التنفيذ الرسمي لـ Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - التنفيذ الرسمي لـ Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - تُدار بالتعاون مع Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - التنفيذ الرسمي لـ Rust

## النقاط الرئيسية

- إعداد بيئة تطوير MCP بسيط باستخدام SDKs الخاصة بكل لغة
- بناء خوادم MCP يتطلب إنشاء وتسجيل أدوات مع مخططات واضحة
- الاختبار وتصحيح الأخطاء ضروريان لضمان موثوقية تطبيقات MCP

## عينات

- [حاسبة جافا](../samples/java/calculator/README.md)
- [حاسبة .Net](../../../../03-GettingStarted/samples/csharp)
- [حاسبة جافا سكريبت](../samples/javascript/README.md)
- [حاسبة تايب سكريبت](../samples/typescript/README.md)
- [حاسبة بايثون](../../../../03-GettingStarted/samples/python)

## الواجب

أنشئ خادم MCP بسيط مع أداة من اختيارك:
1. نفذ الأداة باللغة التي تفضلها (.NET، Java، Python، أو JavaScript).
2. عرّف معلمات الإدخال وقيم الإرجاع.
3. شغّل أداة المفتش للتحقق من عمل الخادم كما هو متوقع.
4. اختبر التنفيذ مع مدخلات مختلفة.

## الحل

[الحل](./solution/README.md)

## موارد إضافية

- [بناء وكلاء باستخدام Model Context Protocol على Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP عن بعد باستخدام Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [وكيل .NET OpenAI MCP](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## الخطوة التالية

التالي: [البدء مع عملاء MCP](/03-GettingStarted/02-client/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر المعتمد. للمعلومات الحساسة أو الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.