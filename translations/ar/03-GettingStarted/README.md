<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "f77fa364511cb670d6262d119d56f562",
  "translation_date": "2025-06-11T09:00:04+00:00",
  "source_file": "03-GettingStarted/README.md",
  "language_code": "ar"
}
-->
## البدء  

يتكون هذا القسم من عدة دروس:

- **1 الخادم الأول الخاص بك**، في هذا الدرس الأول، ستتعلم كيفية إنشاء خادمك الأول وفحصه باستخدام أداة المفتش، وهي طريقة قيمة لاختبار وتصحيح الخادم الخاص بك، [إلى الدرس](/03-GettingStarted/01-first-server/README.md)

- **2 العميل**، في هذا الدرس، ستتعلم كيفية كتابة عميل يمكنه الاتصال بالخادم الخاص بك، [إلى الدرس](/03-GettingStarted/02-client/README.md)

- **3 العميل مع LLM**، طريقة أفضل لكتابة عميل هي بإضافة LLM إليه ليتمكن من "التفاوض" مع الخادم الخاص بك حول ما يجب القيام به، [إلى الدرس](/03-GettingStarted/03-llm-client/README.md)

- **4 استهلاك وضع GitHub Copilot Agent في Visual Studio Code**. هنا، ننظر إلى تشغيل MCP Server الخاص بنا من داخل Visual Studio Code، [إلى الدرس](/03-GettingStarted/04-vscode/README.md)

- **5 الاستهلاك من SSE (Server Sent Events)** SSE هو معيار لبث الخادم إلى العميل، يسمح للخوادم بدفع التحديثات في الوقت الحقيقي إلى العملاء عبر HTTP [إلى الدرس](/03-GettingStarted/05-sse-server/README.md)

- **6 استخدام AI Toolkit لـ VSCode** لاستهلاك واختبار عملاء وخوادم MCP الخاصة بك [إلى الدرس](/03-GettingStarted/06-aitk/README.md)

- **7 الاختبار**. هنا سنركز بشكل خاص على كيفية اختبار الخادم والعميل بطرق مختلفة، [إلى الدرس](/03-GettingStarted/07-testing/README.md)

- **8 النشر**. ستتناول هذه الفصل طرقًا مختلفة لنشر حلول MCP الخاصة بك، [إلى الدرس](/03-GettingStarted/08-deployment/README.md)


بروتوكول سياق النموذج (MCP) هو بروتوكول مفتوح يوحد طريقة تقديم التطبيقات للسياق إلى LLMs. فكر في MCP كمنفذ USB-C لتطبيقات الذكاء الاصطناعي - حيث يوفر طريقة موحدة لربط نماذج الذكاء الاصطناعي بمصادر البيانات والأدوات المختلفة.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- إعداد بيئات التطوير لـ MCP باستخدام C#، Java، Python، TypeScript، وJavaScript  
- بناء ونشر خوادم MCP أساسية مع ميزات مخصصة (الموارد، المطالبات، والأدوات)  
- إنشاء تطبيقات مضيفة تتصل بخوادم MCP  
- اختبار وتصحيح تنفيذات MCP  
- فهم التحديات الشائعة في الإعداد وحلولها  
- ربط تنفيذات MCP الخاصة بك بخدمات LLM الشهيرة  

## إعداد بيئة MCP الخاصة بك

قبل أن تبدأ بالعمل مع MCP، من المهم تجهيز بيئة التطوير وفهم سير العمل الأساسي. سيرشدك هذا القسم خلال خطوات الإعداد الأولية لضمان بداية سلسة مع MCP.

### المتطلبات الأساسية

قبل الغوص في تطوير MCP، تأكد من توفر لديك:

- **بيئة التطوير**: للغة التي اخترتها (C#، Java، Python، TypeScript، أو JavaScript)  
- **IDE/المحرر**: Visual Studio، Visual Studio Code، IntelliJ، Eclipse، PyCharm، أو أي محرر أكواد حديث  
- **مديرو الحزم**: NuGet، Maven/Gradle، pip، أو npm/yarn  
- **مفاتيح API**: لأي خدمات ذكاء اصطناعي تخطط لاستخدامها في تطبيقاتك المضيفة  

### SDKs الرسمية

في الفصول القادمة سترى حلولًا مبنية باستخدام Python، TypeScript، Java و.NET. فيما يلي جميع SDKs المدعومة رسميًا.

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
- بناء خوادم MCP يتضمن إنشاء وتسجيل أدوات مع مخططات واضحة  
- عملاء MCP يتصلون بالخوادم والنماذج للاستفادة من القدرات الموسعة  
- الاختبار والتصحيح ضروريان لتنفيذات MCP موثوقة  
- خيارات النشر تتراوح بين التطوير المحلي والحلول السحابية  

## الممارسة

لدينا مجموعة من العينات التي تكمل التمارين التي سترىها في جميع الفصول في هذا القسم. بالإضافة إلى ذلك، يحتوي كل فصل أيضًا على تمارينه ومهامه الخاصة.

- [حاسبة Java](./samples/java/calculator/README.md)  
- [حاسبة .Net](../../../03-GettingStarted/samples/csharp)  
- [حاسبة JavaScript](./samples/javascript/README.md)  
- [حاسبة TypeScript](./samples/typescript/README.md)  
- [حاسبة Python](../../../03-GettingStarted/samples/python)  

## موارد إضافية

- [بناء وكلاء باستخدام Model Context Protocol على Azure](https://learn.microsoft.com/azure/developer/ai/intro-agents-mcp)  
- [MCP عن بُعد مع Azure Container Apps (Node.js/TypeScript/JavaScript)](https://learn.microsoft.com/samples/azure-samples/mcp-container-ts/mcp-container-ts/)  
- [.NET OpenAI MCP Agent](https://learn.microsoft.com/samples/azure-samples/openai-mcp-agent-dotnet/openai-mcp-agent-dotnet/)  

## ما هو التالي

التالي: [إنشاء أول MCP Server خاص بك](/03-GettingStarted/01-first-server/README.md)

**إخلاء مسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الحساسة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.