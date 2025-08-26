<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "1197b6dbde36773e04a5ae826557fdb9",
  "translation_date": "2025-08-26T17:08:22+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ar"
}
-->
## البدء  

[![بناء أول خادم MCP](../../../translated_images/04.0ea920069efd979a0b2dad51e72c1df7ead9c57b3305796068a6cee1f0dd6674.ar.png)](https://youtu.be/sNDZO9N4m9Y)

_(اضغط على الصورة أعلاه لمشاهدة فيديو هذا الدرس)_

تتكون هذه القسم من عدة دروس:

- **1 خادمك الأول**، في هذا الدرس الأول، ستتعلم كيفية إنشاء أول خادم لك وفحصه باستخدام أداة الفحص، وهي طريقة قيمة لاختبار وتصحيح خادمك، [إلى الدرس](01-first-server/README.md)

- **2 العميل**، في هذا الدرس، ستتعلم كيفية كتابة عميل يمكنه الاتصال بخادمك، [إلى الدرس](02-client/README.md)

- **3 عميل مع LLM**، طريقة أفضل لكتابة عميل هي بإضافة LLM إليه ليتمكن من "التفاوض" مع خادمك حول ما يجب فعله، [إلى الدرس](03-llm-client/README.md)

- **4 استهلاك خادم في وضع GitHub Copilot Agent في Visual Studio Code**. هنا، سنلقي نظرة على تشغيل خادم MCP الخاص بنا من داخل Visual Studio Code، [إلى الدرس](04-vscode/README.md)

- **5 خادم النقل stdio** النقل عبر stdio هو المعيار الموصى به للتواصل بين خادم MCP والعميل في المواصفات الحالية، حيث يوفر تواصلًا آمنًا يعتمد على العمليات الفرعية، [إلى الدرس](05-stdio-server/README.md)

- **6 البث عبر HTTP مع MCP (HTTP القابل للبث)**. تعرف على البث الحديث عبر HTTP، إشعارات التقدم، وكيفية تنفيذ خوادم وعملاء MCP قابلة للتوسع في الوقت الفعلي باستخدام HTTP القابل للبث. [إلى الدرس](06-http-streaming/README.md)

- **7 استخدام أدوات الذكاء الاصطناعي لـ VSCode** لاستهلاك واختبار عملاء وخوادم MCP الخاصة بك [إلى الدرس](07-aitk/README.md)

- **8 الاختبار**. هنا سنركز بشكل خاص على كيفية اختبار خادمك وعميلك بطرق مختلفة، [إلى الدرس](08-testing/README.md)

- **9 النشر**. سيتناول هذا الفصل طرقًا مختلفة لنشر حلول MCP الخاصة بك، [إلى الدرس](09-deployment/README.md)

بروتوكول سياق النموذج (MCP) هو بروتوكول مفتوح يحدد كيفية تقديم التطبيقات للسياق إلى LLMs. فكر في MCP كأنه منفذ USB-C لتطبيقات الذكاء الاصطناعي - فهو يوفر طريقة موحدة لتوصيل نماذج الذكاء الاصطناعي بمصادر البيانات والأدوات المختلفة.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- إعداد بيئات التطوير لـ MCP باستخدام C#، Java، Python، TypeScript، و JavaScript
- بناء ونشر خوادم MCP أساسية بميزات مخصصة (الموارد، المطالبات، والأدوات)
- إنشاء تطبيقات مضيفة تتصل بخوادم MCP
- اختبار وتصحيح تنفيذات MCP
- فهم التحديات الشائعة في الإعداد وحلولها
- توصيل تنفيذات MCP الخاصة بك بخدمات LLM الشهيرة

## إعداد بيئة MCP الخاصة بك

قبل أن تبدأ العمل مع MCP، من المهم إعداد بيئة التطوير الخاصة بك وفهم سير العمل الأساسي. ستوجهك هذه القسم خلال خطوات الإعداد الأولية لضمان بداية سلسة مع MCP.

### المتطلبات الأساسية

قبل الغوص في تطوير MCP، تأكد من أن لديك:

- **بيئة تطوير**: للغة التي اخترتها (C#، Java، Python، TypeScript، أو JavaScript)
- **IDE/محرر**: Visual Studio، Visual Studio Code، IntelliJ، Eclipse، PyCharm، أو أي محرر حديث
- **مديري الحزم**: NuGet، Maven/Gradle، pip، أو npm/yarn
- **مفاتيح API**: لأي خدمات ذكاء اصطناعي تخطط لاستخدامها في تطبيقاتك المضيفة

### SDKs الرسمية

في الفصول القادمة، سترى حلولًا مبنية باستخدام Python، TypeScript، Java و .NET. إليك جميع SDKs المدعومة رسميًا.

يوفر MCP SDKs رسمية لعدة لغات:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - يتم صيانته بالتعاون مع Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - يتم صيانته بالتعاون مع Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - التنفيذ الرسمي لـ TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - التنفيذ الرسمي لـ Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - التنفيذ الرسمي لـ Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - يتم صيانته بالتعاون مع Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - التنفيذ الرسمي لـ Rust

## النقاط الرئيسية

- إعداد بيئة تطوير MCP أمر بسيط باستخدام SDKs الخاصة بكل لغة
- بناء خوادم MCP يتضمن إنشاء وتسجيل أدوات بمخططات واضحة
- عملاء MCP يتصلون بالخوادم والنماذج للاستفادة من القدرات الموسعة
- الاختبار والتصحيح ضروريان لتنفيذات MCP الموثوقة
- خيارات النشر تتراوح بين التطوير المحلي والحلول السحابية

## الممارسة

لدينا مجموعة من الأمثلة التي تكمل التمارين التي ستراها في جميع الفصول في هذا القسم. بالإضافة إلى ذلك، يحتوي كل فصل على تمارينه ومهامه الخاصة.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## موارد إضافية

- [بناء وكلاء باستخدام بروتوكول سياق النموذج على Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP عن بُعد مع Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## ما التالي

التالي: [إنشاء أول خادم MCP](01-first-server/README.md)

---

**إخلاء المسؤولية**:  
تم ترجمة هذا المستند باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو معلومات غير دقيقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق. للحصول على معلومات حاسمة، يُوصى بالاستعانة بترجمة بشرية احترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة تنشأ عن استخدام هذه الترجمة.