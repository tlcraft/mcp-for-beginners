<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "8fdd5786214b32ad33d8b5cf9012a0f7",
  "translation_date": "2025-05-17T08:05:01+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ar"
}
-->
## البدء

يتكون هذا القسم من عدة دروس:

- **-1- أول خادم لك**، في هذا الدرس الأول، ستتعلم كيفية إنشاء أول خادم لك وفحصه باستخدام أداة الفحص، وهي طريقة قيمة لاختبار وتصحيح الخادم الخاص بك، [إلى الدرس](/03-GettingStarted/01-first-server/README.md)

- **-2- العميل**، في هذا الدرس، ستتعلم كيفية كتابة عميل يمكنه الاتصال بالخادم الخاص بك، [إلى الدرس](/03-GettingStarted/02-client/README.md)

- **-3- عميل مع LLM**، طريقة أفضل لكتابة عميل هي بإضافة LLM إليه حتى يتمكن من "التفاوض" مع الخادم الخاص بك حول ما يجب القيام به، [إلى الدرس](/03-GettingStarted/03-llm-client/README.md)

- **-4- استهلاك خادم في وضع وكيل GitHub Copilot في Visual Studio Code**. هنا، ننظر إلى تشغيل خادم MCP الخاص بنا من داخل Visual Studio Code، [إلى الدرس](/03-GettingStarted/04-vscode/README.md)

- **-5- الاستهلاك من SSE (أحداث الخادم المرسلة)** SSE هو معيار للبث من الخادم إلى العميل، مما يسمح للخوادم بإرسال تحديثات في الوقت الحقيقي للعملاء عبر HTTP [إلى الدرس](/03-GettingStarted/05-sse-server/README.md)

- **-6- استخدام أدوات الذكاء الاصطناعي لـ VSCode** لاستهلاك واختبار عملاء وخوادم MCP الخاصة بك [إلى الدرس](/03-GettingStarted/06-aitk/README.md)

- **-7 الاختبار**. هنا سنركز بشكل خاص على كيفية اختبار الخادم والعميل بطرق مختلفة، [إلى الدرس](/03-GettingStarted/07-testing/README.md)

- **-8- النشر**. سينظر هذا الفصل في طرق مختلفة لنشر حلول MCP الخاصة بك، [إلى الدرس](/03-GettingStarted/08-deployment/README.md)

بروتوكول سياق النموذج (MCP) هو بروتوكول مفتوح يحدد كيفية تقديم التطبيقات للسياق إلى LLMs. فكر في MCP مثل منفذ USB-C لتطبيقات الذكاء الاصطناعي - فهو يوفر طريقة موحدة لتوصيل نماذج الذكاء الاصطناعي بمصادر البيانات والأدوات المختلفة.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- إعداد بيئات التطوير لـ MCP في C#، Java، Python، TypeScript، وJavaScript
- بناء ونشر خوادم MCP الأساسية مع ميزات مخصصة (الموارد، التعليمات، والأدوات)
- إنشاء تطبيقات مضيفة تتصل بخوادم MCP
- اختبار وتصحيح تطبيقات MCP
- فهم تحديات الإعداد الشائعة وحلولها
- توصيل تطبيقات MCP الخاصة بك بخدمات LLM الشهيرة

## إعداد بيئة MCP الخاصة بك

قبل البدء في العمل مع MCP، من المهم إعداد بيئة التطوير الخاصة بك وفهم سير العمل الأساسي. سيوجهك هذا القسم خلال خطوات الإعداد الأولية لضمان بداية سلسة مع MCP.

### المتطلبات الأساسية

قبل الغوص في تطوير MCP، تأكد من أنك تمتلك:

- **بيئة تطوير**: للغة التي اخترتها (C#، Java، Python، TypeScript، أو JavaScript)
- **IDE/محرر**: Visual Studio، Visual Studio Code، IntelliJ، Eclipse، PyCharm، أو أي محرر كود حديث
- **مدراء الحزم**: NuGet، Maven/Gradle، pip، أو npm/yarn
- **مفاتيح API**: لأي خدمات ذكاء اصطناعي تخطط لاستخدامها في تطبيقاتك المضيفة

### SDKs الرسمية

في الفصول القادمة ستشاهد حلول مبنية باستخدام Python، TypeScript، Java و .NET. هنا جميع SDKs المدعومة رسميًا.

MCP يوفر SDKs رسمية لعدة لغات:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - يتم صيانته بالتعاون مع Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - يتم صيانته بالتعاون مع Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - التنفيذ الرسمي لـ TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - التنفيذ الرسمي لـ Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - التنفيذ الرسمي لـ Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - يتم صيانته بالتعاون مع Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - التنفيذ الرسمي لـ Rust

## النقاط الرئيسية

- إعداد بيئة تطوير MCP بسيط باستخدام SDKs الخاصة باللغة
- بناء خوادم MCP يتضمن إنشاء وتسجيل أدوات مع مخططات واضحة
- يتصل عملاء MCP بالخوادم والنماذج للاستفادة من القدرات الممتدة
- الاختبار والتصحيح ضروريان لتطبيقات MCP الموثوقة
- خيارات النشر تتراوح من التطوير المحلي إلى الحلول السحابية

## الممارسة

لدينا مجموعة من العينات التي تكمل التمارين التي ستشاهدها في جميع الفصول في هذا القسم. بالإضافة إلى ذلك، يحتوي كل فصل أيضًا على تمارين ومهام خاصة به.

- [Java Calculator](./samples/java/calculator/README.md)
- [.Net Calculator](../../../03-GettingStarted/samples/csharp)
- [JavaScript Calculator](./samples/javascript/README.md)
- [TypeScript Calculator](./samples/typescript/README.md)
- [Python Calculator](../../../03-GettingStarted/samples/python)

## موارد إضافية

- [مستودع MCP على GitHub](https://github.com/microsoft/mcp-for-beginners)

## ما التالي

التالي: [إنشاء أول خادم MCP لك](/03-GettingStarted/01-first-server/README.md)

**إخلاء المسؤولية**:  
تم ترجمة هذه الوثيقة باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يُرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار الوثيقة الأصلية بلغتها الأصلية المصدر الموثوق به. للحصول على معلومات حاسمة، يُوصى بالترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير خاطئ ناتج عن استخدام هذه الترجمة.