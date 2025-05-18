<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "0e1385a3fadf16bacd2f863757bcf5e0",
  "translation_date": "2025-05-17T13:41:56+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ar"
}
-->
# التنفيذ العملي

التنفيذ العملي هو المكان الذي يصبح فيه بروتوكول سياق النموذج (MCP) ملموسًا. بينما يعتبر فهم النظرية والهندسة المعمارية وراء MCP أمرًا مهمًا، فإن القيمة الحقيقية تظهر عندما تطبق هذه المفاهيم لبناء واختبار ونشر حلول تحل مشاكل العالم الحقيقي. هذا الفصل يجسر الفجوة بين المعرفة النظرية والتطوير العملي، ويوجهك خلال عملية تحويل التطبيقات المبنية على MCP إلى واقع.

سواء كنت تطور مساعدين أذكياء، تدمج الذكاء الاصطناعي في سير العمل التجاري، أو تبني أدوات مخصصة لمعالجة البيانات، يوفر MCP أساسًا مرنًا. تصميمه المحايد للغة ووجود SDKs الرسمية للغات البرمجة الشهيرة يجعله متاحًا لمجموعة واسعة من المطورين. من خلال الاستفادة من هذه SDKs، يمكنك بسرعة إنشاء النماذج الأولية، التكرار، وتوسيع حلولك عبر مختلف المنصات والبيئات.

في الأقسام التالية، ستجد أمثلة عملية، كود عينة، واستراتيجيات نشر توضح كيفية تنفيذ MCP في C#، Java، TypeScript، JavaScript، وPython. ستتعلم أيضًا كيفية تصحيح واختبار خوادم MCP، إدارة واجهات برمجة التطبيقات، ونشر الحلول إلى السحابة باستخدام Azure. هذه الموارد العملية مصممة لتسريع تعلمك ومساعدتك على بناء تطبيقات MCP قوية جاهزة للإنتاج بثقة.

## نظرة عامة

تركز هذه الدرس على الجوانب العملية لتنفيذ MCP عبر لغات البرمجة المتعددة. سنستكشف كيفية استخدام SDKs الخاصة بـ MCP في C#، Java، TypeScript، JavaScript، وPython لبناء تطبيقات قوية، تصحيح واختبار خوادم MCP، وإنشاء موارد، مطالبات، وأدوات قابلة لإعادة الاستخدام.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:
- تنفيذ حلول MCP باستخدام SDKs الرسمية في لغات البرمجة المختلفة
- تصحيح واختبار خوادم MCP بشكل منهجي
- إنشاء واستخدام ميزات الخادم (الموارد، المطالبات، والأدوات)
- تصميم سير عمل MCP فعال للمهام المعقدة
- تحسين تنفيذات MCP للأداء والموثوقية

## موارد SDK الرسمية

يقدم بروتوكول سياق النموذج SDKs الرسمية للغات متعددة:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## العمل مع SDKs الخاصة بـ MCP

يوفر هذا القسم أمثلة عملية لتنفيذ MCP عبر لغات البرمجة المتعددة. يمكنك العثور على كود العينة في دليل `samples` المنظم حسب اللغة.

### العينات المتاحة

يتضمن المستودع عينات تنفيذ في اللغات التالية:

- C#
- Java
- TypeScript
- JavaScript
- Python

كل عينة توضح مفاهيم MCP الرئيسية وأنماط التنفيذ لتلك اللغة والنظام البيئي المحدد.

## ميزات الخادم الأساسية

يمكن لخوادم MCP تنفيذ أي مجموعة من هذه الميزات:

### الموارد
توفر الموارد سياقًا وبيانات للاستخدام من قبل المستخدم أو نموذج الذكاء الاصطناعي:
- مستودعات الوثائق
- قواعد المعرفة
- مصادر البيانات المنظمة
- أنظمة الملفات

### المطالبات
المطالبات هي رسائل وأنماط سير عمل مؤطرة للمستخدمين:
- قوالب المحادثة المحددة مسبقًا
- أنماط التفاعل الموجهة
- هياكل الحوار المتخصصة

### الأدوات
الأدوات هي وظائف لتنفيذها من قبل نموذج الذكاء الاصطناعي:
- أدوات معالجة البيانات
- تكاملات API الخارجية
- القدرات الحسابية
- وظائف البحث

## تنفيذات عينة: C#

يتضمن مستودع SDK الرسمي لـ C# عدة تنفيذات عينة توضح الجوانب المختلفة لـ MCP:

- **عميل MCP الأساسي**: مثال بسيط يوضح كيفية إنشاء عميل MCP واستدعاء الأدوات
- **خادم MCP الأساسي**: تنفيذ خادم بسيط مع تسجيل الأدوات الأساسية
- **خادم MCP المتقدم**: خادم كامل الميزات مع تسجيل الأدوات، المصادقة، ومعالجة الأخطاء
- **تكامل ASP.NET**: أمثلة توضح التكامل مع ASP.NET Core
- **أنماط تنفيذ الأدوات**: أنماط مختلفة لتنفيذ الأدوات بمستويات تعقيد مختلفة

SDK الخاص بـ MCP في C# هو في مرحلة المعاينة وقد تتغير واجهات برمجة التطبيقات. سنقوم بتحديث هذه المدونة باستمرار مع تطور SDK.

### الميزات الرئيسية
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- بناء [أول خادم MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

للحصول على عينات تنفيذ كاملة في C#، قم بزيارة [المستودع الرسمي لعينات SDK في C#](https://github.com/modelcontextprotocol/csharp-sdk)

## تنفيذ عينة: تنفيذ Java

يقدم SDK الخاص بـ Java خيارات تنفيذ MCP قوية مع ميزات على مستوى المؤسسة.

### الميزات الرئيسية

- تكامل إطار العمل Spring
- أمان نوع قوي
- دعم البرمجة التفاعلية
- معالجة شاملة للأخطاء

للحصول على عينة تنفيذ كاملة في Java، انظر [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) في دليل العينات.

## تنفيذ عينة: تنفيذ JavaScript

يقدم SDK الخاص بـ JavaScript نهجًا خفيف الوزن ومرنًا لتنفيذ MCP.

### الميزات الرئيسية

- دعم Node.js والمتصفح
- واجهة برمجة تطبيقات تعتمد على الوعود
- تكامل سهل مع Express وأطر عمل أخرى
- دعم WebSocket للبث

للحصول على عينة تنفيذ كاملة في JavaScript، انظر [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) في دليل العينات.

## تنفيذ عينة: تنفيذ Python

يقدم SDK الخاص بـ Python نهجًا Pythonic لتنفيذ MCP مع تكاملات ممتازة لأطر ML.

### الميزات الرئيسية

- دعم Async/await مع asyncio
- تكامل Flask وFastAPI
- تسجيل أدوات بسيط
- تكامل أصلي مع مكتبات ML الشهيرة

للحصول على عينة تنفيذ كاملة في Python، انظر [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) في دليل العينات.

## إدارة API

تعد إدارة API في Azure إجابة رائعة لكيفية تأمين خوادم MCP. الفكرة هي وضع مثيل إدارة API في Azure أمام خادم MCP الخاص بك وتركه يتعامل مع الميزات التي من المرجح أن ترغب فيها مثل:

- تحديد المعدل
- إدارة الرموز
- المراقبة
- موازنة التحميل
- الأمان

### عينة Azure

إليك عينة Azure تقوم بالضبط بذلك، أي [إنشاء خادم MCP وتأمينه بإدارة API في Azure](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

انظر كيف يحدث تدفق التفويض في الصورة أدناه:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

في الصورة السابقة، يحدث ما يلي:

- تتم المصادقة/التفويض باستخدام Microsoft Entra.
- تعمل إدارة API في Azure كبوابة وتستخدم السياسات لتوجيه وإدارة حركة المرور.
- يقوم Azure Monitor بتسجيل جميع الطلبات لتحليل إضافي.

#### تدفق التفويض

لنلقي نظرة على تدفق التفويض بمزيد من التفصيل:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### مواصفات تفويض MCP

تعرف على المزيد حول [مواصفات تفويض MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## نشر خادم MCP عن بُعد إلى Azure

لنرى إذا كان بإمكاننا نشر العينة التي ذكرناها سابقًا:

1. استنساخ المستودع

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. تسجيل `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` بعد مرور بعض الوقت للتحقق مما إذا كان التسجيل مكتملًا.

2. قم بتشغيل هذا الأمر [azd](https://aka.ms/azd) لتوفير خدمة إدارة API، تطبيق الوظيفة (مع الكود) وجميع الموارد المطلوبة في Azure

    ```shell
    azd up
    ```

    يجب أن يقوم هذا الأمر بنشر جميع الموارد السحابية على Azure

### اختبار الخادم الخاص بك باستخدام MCP Inspector

1. في **نافذة طرفية جديدة**، قم بتثبيت وتشغيل MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    يجب أن ترى واجهة مشابهة لـ:

    ![Connect to Node inspector](../../../translated_images/connect.126df3a6deef0d2e0850b1a5cf0547c8fc4e2e9e0b354238d0a9dbe7893726fa.ar.png)

1. انقر بزر الفأرة الأيمن لتحميل تطبيق الويب MCP Inspector من عنوان URL المعروض بواسطة التطبيق (مثل http://127.0.0.1:6274/#resources)
1. ضبط نوع النقل إلى `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` و**الاتصال**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **قائمة الأدوات**. انقر على أداة و**تشغيل الأداة**.

إذا نجحت جميع الخطوات، يجب أن تكون الآن متصلًا بخادم MCP وقد تمكنت من استدعاء أداة.

## خوادم MCP لـ Azure

[وظائف MCP عن بُعد](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): هذه المجموعة من المستودعات هي نموذج بدء سريع لبناء ونشر خوادم MCP (بروتوكول سياق النموذج) المخصصة عن بُعد باستخدام وظائف Azure مع Python، C# .NET أو Node/TypeScript.

توفر العينات حلاً كاملاً يتيح للمطورين:

- البناء والتشغيل محليًا: تطوير وتصحيح خادم MCP على جهاز محلي
- النشر إلى Azure: النشر بسهولة إلى السحابة بأمر azd up بسيط
- الاتصال من العملاء: الاتصال بخادم MCP من عملاء مختلفين بما في ذلك وضع الوكيل في VS Code وأداة MCP Inspector

### الميزات الرئيسية:

- الأمان من خلال التصميم: يتم تأمين خادم MCP باستخدام المفاتيح وHTTPS
- خيارات المصادقة: يدعم OAuth باستخدام المصادقة المدمجة و/أو إدارة API
- عزل الشبكة: يتيح عزل الشبكة باستخدام شبكات Azure الافتراضية (VNET)
- بنية بدون خادم: تستفيد من وظائف Azure للتنفيذ القابل للتوسيع والمدفوع بالأحداث
- التطوير المحلي: دعم شامل للتطوير المحلي والتصحيح
- عملية نشر بسيطة: عملية نشر مبسطة إلى Azure

يتضمن المستودع جميع ملفات التكوين الضرورية، الكود المصدري، وتعريفات البنية التحتية للبدء السريع مع تنفيذ خادم MCP جاهز للإنتاج.

- [وظائف MCP عن بُعد في Azure Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - تنفيذ عينة لـ MCP باستخدام وظائف Azure مع Python

- [وظائف MCP عن بُعد في Azure .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - تنفيذ عينة لـ MCP باستخدام وظائف Azure مع C# .NET

- [وظائف MCP عن بُعد في Azure Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - تنفيذ عينة لـ MCP باستخدام وظائف Azure مع Node/TypeScript.

## النقاط الرئيسية

- توفر SDKs الخاصة بـ MCP أدوات خاصة باللغة لتنفيذ حلول MCP قوية
- عملية التصحيح والاختبار مهمة للتطبيقات الموثوقة لـ MCP
- تمكّن قوالب المطالبات القابلة لإعادة الاستخدام من تفاعلات الذكاء الاصطناعي المتسقة
- يمكن لسير العمل المصمم جيدًا تنسيق المهام المعقدة باستخدام أدوات متعددة
- يتطلب تنفيذ حلول MCP النظر في الأمان، الأداء، ومعالجة الأخطاء

## تمرين

صمم سير عمل MCP عملي يعالج مشكلة واقعية في مجالك:

1. حدد 3-4 أدوات ستكون مفيدة لحل هذه المشكلة
2. أنشئ مخطط سير عمل يوضح كيفية تفاعل هذه الأدوات
3. نفذ نسخة أساسية من إحدى الأدوات باستخدام لغتك المفضلة
4. أنشئ قالب مطالبة يساعد النموذج في استخدام أداتك بفعالية

## موارد إضافية

---

التالي: [مواضيع متقدمة](../05-AdvancedTopics/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذه الوثيقة باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يُرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار الوثيقة الأصلية بلغتها الأصلية المصدر الموثوق. للحصول على معلومات حاسمة، يُوصى بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة ناتجة عن استخدام هذه الترجمة.