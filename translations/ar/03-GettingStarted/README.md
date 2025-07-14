<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "860935ff95d05b006d1d3323e8e3f9e8",
  "translation_date": "2025-07-13T17:11:44+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ar"
}
-->
## البدء  

يتضمن هذا القسم عدة دروس:

- **1 خادمك الأول**، في هذا الدرس الأول، ستتعلم كيفية إنشاء خادمك الأول وفحصه باستخدام أداة الفاحص، وهي طريقة قيمة لاختبار وتصحيح الخادم، [إلى الدرس](01-first-server/README.md)

- **2 العميل**، في هذا الدرس، ستتعلم كيفية كتابة عميل يمكنه الاتصال بخادمك، [إلى الدرس](02-client/README.md)

- **3 العميل مع LLM**، طريقة أفضل لكتابة عميل هي بإضافة LLM إليه ليتمكن من "التفاوض" مع خادمك حول ما يجب فعله، [إلى الدرس](03-llm-client/README.md)

- **4 استهلاك خادم وضع وكيل GitHub Copilot في Visual Studio Code**. هنا، ننظر في تشغيل خادم MCP الخاص بنا من داخل Visual Studio Code، [إلى الدرس](04-vscode/README.md)

- **5 الاستهلاك من SSE (Server Sent Events)** SSE هو معيار للبث من الخادم إلى العميل، يسمح للخوادم بدفع تحديثات في الوقت الحقيقي إلى العملاء عبر HTTP [إلى الدرس](05-sse-server/README.md)

- **6 البث عبر HTTP مع MCP (HTTP قابل للبث)**. تعرّف على البث الحديث عبر HTTP، وإشعارات التقدم، وكيفية تنفيذ خوادم وعملاء MCP قابلة للتوسع وفي الوقت الحقيقي باستخدام HTTP القابل للبث. [إلى الدرس](06-http-streaming/README.md)

- **7 استخدام مجموعة أدوات AI لـ VSCode** لاستهلاك واختبار عملاء وخوادم MCP الخاصة بك [إلى الدرس](07-aitk/README.md)

- **8 الاختبار**. هنا سنركز بشكل خاص على كيفية اختبار خادمنا وعميلنا بطرق مختلفة، [إلى الدرس](08-testing/README.md)

- **9 النشر**. هذا الفصل سيناقش طرق مختلفة لنشر حلول MCP الخاصة بك، [إلى الدرس](09-deployment/README.md)


بروتوكول سياق النموذج (MCP) هو بروتوكول مفتوح يحدد طريقة موحدة لتوفير السياق للنماذج اللغوية الكبيرة (LLMs). فكر في MCP كمنفذ USB-C لتطبيقات الذكاء الاصطناعي - فهو يوفر طريقة موحدة لربط نماذج الذكاء الاصطناعي بمصادر بيانات وأدوات مختلفة.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- إعداد بيئات تطوير لـ MCP باستخدام C#، Java، Python، TypeScript، وJavaScript
- بناء ونشر خوادم MCP أساسية مع ميزات مخصصة (الموارد، المطالبات، والأدوات)
- إنشاء تطبيقات مضيفة تتصل بخوادم MCP
- اختبار وتصحيح تطبيقات MCP
- فهم التحديات الشائعة في الإعداد وحلولها
- ربط تطبيقات MCP الخاصة بك بخدمات LLM الشهيرة

## إعداد بيئة MCP الخاصة بك

قبل أن تبدأ العمل مع MCP، من المهم تجهيز بيئة التطوير وفهم سير العمل الأساسي. سيرشدك هذا القسم خلال خطوات الإعداد الأولية لضمان بداية سلسة مع MCP.

### المتطلبات الأساسية

قبل الغوص في تطوير MCP، تأكد من توفر:

- **بيئة تطوير**: للغة التي اخترتها (C#، Java، Python، TypeScript، أو JavaScript)
- **بيئة تطوير متكاملة/محرر**: Visual Studio، Visual Studio Code، IntelliJ، Eclipse، PyCharm، أو أي محرر كود حديث
- **مديرو الحزم**: NuGet، Maven/Gradle، pip، أو npm/yarn
- **مفاتيح API**: لأي خدمات ذكاء اصطناعي تخطط لاستخدامها في تطبيقاتك المضيفة


### SDKs الرسمية

في الفصول القادمة سترى حلولًا مبنية باستخدام Python، TypeScript، Java و .NET. هذه هي جميع SDKs المدعومة رسميًا.

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
- عملاء MCP يتصلون بالخوادم والنماذج للاستفادة من القدرات الموسعة
- الاختبار والتصحيح ضروريان لتطبيقات MCP موثوقة
- خيارات النشر تتراوح بين التطوير المحلي والحلول السحابية

## الممارسة

لدينا مجموعة من العينات التي تكمل التمارين التي سترىها في جميع الفصول في هذا القسم. بالإضافة إلى ذلك، يحتوي كل فصل على تمارينه ومهامه الخاصة.

- [حاسبة Java](./samples/java/calculator/README.md)
- [حاسبة .Net](../../../03-GettingStarted/samples/csharp)
- [حاسبة JavaScript](./samples/javascript/README.md)
- [حاسبة TypeScript](./samples/typescript/README.md)
- [حاسبة Python](../../../03-GettingStarted/samples/python)

## موارد إضافية

- [بناء وكلاء باستخدام Model Context Protocol على Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP عن بُعد مع Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [وكيل MCP لـ .NET OpenAI](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## ما التالي

التالي: [إنشاء خادم MCP الأول الخاص بك](01-first-server/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.