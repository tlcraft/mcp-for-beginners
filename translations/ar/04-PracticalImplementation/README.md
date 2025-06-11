<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7919ce2e537f0c435c7c23fa6775b613",
  "translation_date": "2025-06-11T17:57:55+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ar"
}
-->
# التنفيذ العملي

التنفيذ العملي هو المكان الذي يصبح فيه بروتوكول سياق النموذج (MCP) ملموسًا. بينما يعد فهم النظرية والهندسة المعمارية وراء MCP أمرًا مهمًا، تظهر القيمة الحقيقية عندما تطبق هذه المفاهيم لبناء واختبار ونشر حلول تحل مشاكل العالم الحقيقي. هذا الفصل يجسر الفجوة بين المعرفة النظرية والتطوير العملي، ويرشدك خلال عملية إحياء تطبيقات تعتمد على MCP.

سواء كنت تطور مساعدين ذكيين، أو تدمج الذكاء الاصطناعي في سير العمل التجاري، أو تبني أدوات مخصصة لمعالجة البيانات، يوفر MCP أساسًا مرنًا. تصميمه غير المعتمد على لغة معينة وSDKs الرسمية للغات البرمجة الشهيرة تجعله في متناول مجموعة واسعة من المطورين. من خلال الاستفادة من هذه SDKs، يمكنك بسرعة إنشاء نماذج أولية، والتكرار، وتوسيع حلولك عبر منصات وبيئات مختلفة.

في الأقسام التالية، ستجد أمثلة عملية، وشفرات نموذجية، واستراتيجيات نشر توضح كيفية تنفيذ MCP في C#، Java، TypeScript، JavaScript، وPython. ستتعلم أيضًا كيفية تصحيح الأخطاء واختبار خوادم MCP، وإدارة واجهات برمجة التطبيقات، ونشر الحلول على السحابة باستخدام Azure. هذه الموارد العملية مصممة لتسريع تعلمك ومساعدتك على بناء تطبيقات MCP قوية وجاهزة للإنتاج بثقة.

## نظرة عامة

يركز هذا الدرس على الجوانب العملية لتنفيذ MCP عبر لغات برمجة متعددة. سنستكشف كيفية استخدام SDKs الخاصة بـ MCP في C#، Java، TypeScript، JavaScript، وPython لبناء تطبيقات قوية، وتصحيح واختبار خوادم MCP، وإنشاء موارد، ومطالبات، وأدوات قابلة لإعادة الاستخدام.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:
- تنفيذ حلول MCP باستخدام SDKs الرسمية بلغات برمجة مختلفة
- تصحيح واختبار خوادم MCP بشكل منهجي
- إنشاء واستخدام ميزات الخادم (الموارد، المطالبات، والأدوات)
- تصميم سير عمل MCP فعال للمهام المعقدة
- تحسين تنفيذات MCP من حيث الأداء والموثوقية

## موارد SDK الرسمية

يقدم بروتوكول سياق النموذج SDKs رسمية لعدة لغات:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk)
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## العمل مع SDKs الخاصة بـ MCP

يوفر هذا القسم أمثلة عملية لتنفيذ MCP عبر لغات برمجة متعددة. يمكنك العثور على شفرات نموذجية في دليل `samples` مرتبة حسب اللغة.

### العينات المتاحة

يحتوي المستودع على تطبيقات نموذجية في اللغات التالية:

- C#
- Java
- TypeScript
- JavaScript
- Python

كل عينة توضح مفاهيم MCP الأساسية وأنماط التنفيذ الخاصة بتلك اللغة والبيئة.

## ميزات الخادم الأساسية

يمكن لخوادم MCP تنفيذ أي مزيج من هذه الميزات:

### الموارد  
توفر الموارد السياق والبيانات للمستخدم أو نموذج الذكاء الاصطناعي لاستخدامها:  
- مستودعات الوثائق  
- قواعد المعرفة  
- مصادر البيانات المنظمة  
- أنظمة الملفات  

### المطالبات  
المطالبات هي رسائل ونماذج سير عمل جاهزة للمستخدمين:  
- قوالب محادثة محددة مسبقًا  
- أنماط تفاعل موجهة  
- هياكل حوار متخصصة  

### الأدوات  
الأدوات هي وظائف يمكن لنموذج الذكاء الاصطناعي تنفيذها:  
- أدوات معالجة البيانات  
- تكاملات API خارجية  
- قدرات حسابية  
- وظائف البحث  

## تطبيقات نموذجية: C#

يحتوي مستودع SDK الرسمي لـ C# على عدة تطبيقات نموذجية توضح جوانب مختلفة من MCP:

- **عميل MCP أساسي**: مثال بسيط يوضح كيفية إنشاء عميل MCP واستدعاء الأدوات  
- **خادم MCP أساسي**: تنفيذ خادم بسيط مع تسجيل أدوات أساسي  
- **خادم MCP متقدم**: خادم كامل الميزات مع تسجيل أدوات، مصادقة، ومعالجة الأخطاء  
- **تكامل ASP.NET**: أمثلة توضح التكامل مع ASP.NET Core  
- **أنماط تنفيذ الأدوات**: أنماط مختلفة لتنفيذ الأدوات بمستويات تعقيد متنوعة  

SDK الخاص بـ MCP لـ C# في مرحلة المعاينة وقد تتغير واجهات برمجة التطبيقات. سنستمر في تحديث هذا المدونة مع تطور SDK.

### الميزات الرئيسية  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- بناء [أول خادم MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

للحصول على عينات تنفيذ كاملة لـ C#، قم بزيارة [مستودع عينات SDK الرسمي لـ C#](https://github.com/modelcontextprotocol/csharp-sdk)

## تطبيق نموذجي: تنفيذ Java

يقدم SDK الخاص بـ Java خيارات تنفيذ MCP قوية مع ميزات من الدرجة المؤسسية.

### الميزات الرئيسية

- تكامل مع Spring Framework  
- أمان نوع قوي  
- دعم البرمجة التفاعلية  
- معالجة شاملة للأخطاء  

لعينة تنفيذ Java كاملة، انظر [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) في دليل العينات.

## تطبيق نموذجي: تنفيذ JavaScript

يوفر SDK الخاص بـ JavaScript نهجًا خفيف الوزن ومرنًا لتنفيذ MCP.

### الميزات الرئيسية

- دعم Node.js والمتصفح  
- واجهة برمجة تطبيقات معتمدة على الوعود  
- تكامل سهل مع Express وأطر أخرى  
- دعم WebSocket للبث  

لعينة تنفيذ JavaScript كاملة، انظر [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) في دليل العينات.

## تطبيق نموذجي: تنفيذ Python

يقدم SDK الخاص بـ Python نهجًا بايثونيًا لتنفيذ MCP مع تكاملات ممتازة لأطر تعلم الآلة.

### الميزات الرئيسية

- دعم async/await مع asyncio  
- تكامل مع Flask وFastAPI  
- تسجيل أدوات بسيط  
- تكامل أصلي مع مكتبات تعلم الآلة الشهيرة  

لعينة تنفيذ Python كاملة، انظر [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) في دليل العينات.

## إدارة API

يعد Azure API Management حلاً ممتازًا لكيفية تأمين خوادم MCP. الفكرة هي وضع مثيل Azure API Management أمام خادم MCP الخاص بك وتركه يتولى الميزات التي قد تحتاجها مثل:

- تحديد معدلات الاستخدام  
- إدارة الرموز  
- المراقبة  
- موازنة الأحمال  
- الأمان  

### عينة Azure

إليك عينة من Azure تقوم بذلك بالضبط، أي [إنشاء خادم MCP وتأمينه باستخدام Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

انظر كيف تتم عملية التفويض في الصورة أدناه:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true)

في الصورة السابقة، تحدث الأمور التالية:

- تتم المصادقة/التفويض باستخدام Microsoft Entra.  
- يعمل Azure API Management كبوابة ويستخدم السياسات لتوجيه وإدارة المرور.  
- يسجل Azure Monitor جميع الطلبات للتحليل المستقبلي.  

#### تدفق التفويض

لنلق نظرة أكثر تفصيلاً على تدفق التفويض:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### مواصفات تفويض MCP

تعرف أكثر على [مواصفات تفويض MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## نشر خادم MCP بعيد على Azure

لنرَ إذا كان بإمكاننا نشر العينة التي ذكرناها سابقًا:

1. استنساخ المستودع

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. سجل `Microsoft.App` resource provider.
    * If you are using Azure CLI, run `az provider register --namespace Microsoft.App --wait`.
    * If you are using Azure PowerShell, run `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. Then run `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` بعد بعض الوقت للتحقق مما إذا كانت التسجيل مكتملًا.

2. شغّل هذا الأمر [azd](https://aka.ms/azd) لتوفير خدمة إدارة API، وتطبيق الوظائف (مع الشفرة)، وكل الموارد الأخرى المطلوبة في Azure

    ```shell
    azd up
    ```

    يجب أن تنشر هذه الأوامر جميع الموارد السحابية على Azure

### اختبار خادمك باستخدام MCP Inspector

1. في **نافذة طرفية جديدة**، قم بتثبيت وتشغيل MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    يجب أن ترى واجهة مشابهة لـ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ar.png)

1. اضغط CTRL لتحميل تطبيق MCP Inspector من عنوان URL المعروض بواسطة التطبيق (مثل http://127.0.0.1:6274/#resources)  
1. اضبط نوع النقل إلى `SSE`
1. Set the URL to your running API Management SSE endpoint displayed after `azd up` و**اتصل**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **عرض الأدوات**. انقر على أداة و**شغّل الأداة**.

إذا نجحت كل الخطوات، ستكون متصلاً الآن بخادم MCP وقد تمكنت من استدعاء أداة.

## خوادم MCP لـ Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): هذه المجموعة من المستودعات هي قالب بدء سريع لبناء ونشر خوادم MCP مخصصة بعيدة باستخدام Azure Functions مع Python، C# .NET أو Node/TypeScript.

توفر العينات حلاً كاملاً يسمح للمطورين بـ:

- البناء والتشغيل محليًا: تطوير وتصحيح خادم MCP على جهاز محلي  
- النشر إلى Azure: نشر سهل على السحابة باستخدام أمر azd up بسيط  
- الاتصال من العملاء: الاتصال بخادم MCP من عملاء مختلفين بما في ذلك وضع وكيل Copilot في VS Code وأداة MCP Inspector  

### الميزات الرئيسية:

- الأمان حسب التصميم: يتم تأمين خادم MCP باستخدام مفاتيح وHTTPS  
- خيارات المصادقة: يدعم OAuth باستخدام المصادقة المدمجة و/أو إدارة API  
- عزل الشبكة: يسمح بالعزل الشبكي باستخدام شبكات Azure الافتراضية (VNET)  
- بنية بدون خادم: يستخدم Azure Functions للتنفيذ القابل للتوسع والمدفوع بالأحداث  
- تطوير محلي: دعم شامل للتطوير المحلي وتصحيح الأخطاء  
- نشر بسيط: عملية نشر مبسطة إلى Azure  

يتضمن المستودع جميع ملفات التكوين اللازمة، شفرة المصدر، وتعريفات البنية التحتية للبدء السريع في تنفيذ خادم MCP جاهز للإنتاج.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - عينة تنفيذ MCP باستخدام Azure Functions مع Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - عينة تنفيذ MCP باستخدام Azure Functions مع C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - عينة تنفيذ MCP باستخدام Azure Functions مع Node/TypeScript.

## النقاط الرئيسية

- توفر SDKs الخاصة بـ MCP أدوات خاصة بكل لغة لتنفيذ حلول MCP قوية  
- عملية تصحيح الأخطاء والاختبار حاسمة لتطبيقات MCP موثوقة  
- قوالب المطالبات القابلة لإعادة الاستخدام تمكّن تفاعلات ذكاء اصطناعي متسقة  
- يمكن لسير العمل المصمم جيدًا تنظيم مهام معقدة باستخدام أدوات متعددة  
- يتطلب تنفيذ حلول MCP مراعاة الأمان، الأداء، ومعالجة الأخطاء  

## التمرين

صمم سير عمل MCP عملي يعالج مشكلة حقيقية في مجالك:

1. حدد 3-4 أدوات ستكون مفيدة لحل هذه المشكلة  
2. أنشئ مخطط سير عمل يوضح كيفية تفاعل هذه الأدوات  
3. نفذ نسخة أساسية من إحدى الأدوات باستخدام لغتك المفضلة  
4. أنشئ قالب مطالبة يساعد النموذج على استخدام أداتك بفعالية  

## موارد إضافية


---

التالي: [مواضيع متقدمة](../05-AdvancedTopics/README.md)

**تنويه**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر المعتمد. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة المهنية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.