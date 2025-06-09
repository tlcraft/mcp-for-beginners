<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "b547c992c056d4296d641ed8ec2cc4cb",
  "translation_date": "2025-06-02T17:17:55+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ar"
}
-->
## البدء  

يتكون هذا القسم من عدة دروس:

- **-1- الخادم الأول الخاص بك**، في هذا الدرس الأول، ستتعلم كيفية إنشاء خادمك الأول وفحصه باستخدام أداة المفتش، وهي طريقة قيمة لاختبار وتصحيح الخادم، [إلى الدرس](/03-GettingStarted/01-first-server/README.md)

- **-2- العميل**، في هذا الدرس، ستتعلم كيفية كتابة عميل يمكنه الاتصال بخادمك، [إلى الدرس](/03-GettingStarted/02-client/README.md)

- **-3- العميل مع LLM**، طريقة أفضل لكتابة عميل هي بإضافة LLM إليه بحيث يمكنه "التفاوض" مع خادمك حول ما يجب فعله، [إلى الدرس](/03-GettingStarted/03-llm-client/README.md)

- **-4- استهلاك وضع وكيل GitHub Copilot في Visual Studio Code**. هنا، ننظر في تشغيل خادم MCP الخاص بنا من داخل Visual Studio Code، [إلى الدرس](/03-GettingStarted/04-vscode/README.md)

- **-5- الاستهلاك من SSE (Server Sent Events)** SSE هو معيار للبث من الخادم إلى العميل، يسمح للخوادم بدفع التحديثات في الوقت الحقيقي إلى العملاء عبر HTTP [إلى الدرس](/03-GettingStarted/05-sse-server/README.md)

- **-6- استخدام مجموعة أدوات AI لـ VSCode** لاستهلاك واختبار عملاء وخوادم MCP الخاصة بك [إلى الدرس](/03-GettingStarted/06-aitk/README.md)

- **-7- الاختبار**. هنا سنركز بشكل خاص على كيفية اختبار خادمنا وعميلنا بطرق مختلفة، [إلى الدرس](/03-GettingStarted/07-testing/README.md)

- **-8- النشر**. ستتناول هذه الفصل طرقًا مختلفة لنشر حلول MCP الخاصة بك، [إلى الدرس](/03-GettingStarted/08-deployment/README.md)


بروتوكول سياق النموذج (MCP) هو بروتوكول مفتوح يوحد الطريقة التي توفر بها التطبيقات السياق لـ LLMs. فكر في MCP كمنفذ USB-C لتطبيقات الذكاء الاصطناعي - حيث يوفر طريقة موحدة لربط نماذج الذكاء الاصطناعي بمصادر بيانات وأدوات مختلفة.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- إعداد بيئات تطوير لـ MCP في C# وJava وPython وTypeScript وJavaScript
- بناء ونشر خوادم MCP أساسية مع ميزات مخصصة (الموارد، المطالبات، والأدوات)
- إنشاء تطبيقات مضيفة تتصل بخوادم MCP
- اختبار وتصحيح تنفيذات MCP
- فهم تحديات الإعداد الشائعة وحلولها
- ربط تنفيذات MCP الخاصة بك بخدمات LLM الشهيرة

## إعداد بيئة MCP الخاصة بك

قبل أن تبدأ العمل مع MCP، من المهم تحضير بيئة التطوير الخاصة بك وفهم سير العمل الأساسي. سيرشدك هذا القسم خلال خطوات الإعداد الأولية لضمان بداية سلسة مع MCP.

### المتطلبات الأساسية

قبل الغوص في تطوير MCP، تأكد من أن لديك:

- **بيئة تطوير**: للغة التي تختارها (C#، Java، Python، TypeScript، أو JavaScript)
- **IDE/محرر**: Visual Studio، Visual Studio Code، IntelliJ، Eclipse، PyCharm، أو أي محرر كود حديث
- **مدراء الحزم**: NuGet، Maven/Gradle، pip، أو npm/yarn
- **مفاتيح API**: لأي خدمات ذكاء اصطناعي تخطط لاستخدامها في تطبيقات المضيف الخاصة بك


### SDKs الرسمية

في الفصول القادمة سترى حلولًا مبنية باستخدام Python وTypeScript وJava و.NET. إليك جميع SDKs المدعومة رسميًا.

يوفر MCP SDKs رسمية لعدة لغات:
- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk) - مدعوم بالتعاون مع Microsoft
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) - مدعوم بالتعاون مع Spring AI
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk) - التنفيذ الرسمي لـ TypeScript
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk) - التنفيذ الرسمي لـ Python
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk) - التنفيذ الرسمي لـ Kotlin
- [Swift SDK](https://github.com/modelcontextprotocol/swift-sdk) - مدعوم بالتعاون مع Loopwork AI
- [Rust SDK](https://github.com/modelcontextprotocol/rust-sdk) - التنفيذ الرسمي لـ Rust

## النقاط الرئيسية

- إعداد بيئة تطوير MCP سهل باستخدام SDKs الخاصة بكل لغة
- بناء خوادم MCP يتطلب إنشاء وتسجيل أدوات مع مخططات واضحة
- عملاء MCP يتصلون بالخوادم والنماذج للاستفادة من القدرات الموسعة
- الاختبار والتصحيح ضروريان لتنفيذات MCP موثوقة
- خيارات النشر تتراوح من التطوير المحلي إلى الحلول السحابية

## الممارسة

لدينا مجموعة من العينات التي تكمل التمارين التي سترىها في جميع الفصول في هذا القسم. بالإضافة إلى ذلك، يحتوي كل فصل أيضًا على تمارينه ومهامه الخاصة.

- [حاسبة Java](./samples/java/calculator/README.md)
- [حاسبة .Net](../../../03-GettingStarted/samples/csharp)
- [حاسبة JavaScript](./samples/javascript/README.md)
- [حاسبة TypeScript](./samples/typescript/README.md)
- [حاسبة Python](../../../03-GettingStarted/samples/python)

## موارد إضافية

- [بناء الوكلاء باستخدام بروتوكول سياق النموذج على Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)
- [MCP عن بُعد مع Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)
- [وكيل .NET OpenAI MCP](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)

## ما هو التالي

التالي: [إنشاء أول خادم MCP خاص بك](/03-GettingStarted/01-first-server/README.md)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاستعانة بترجمة بشرية محترفة. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.