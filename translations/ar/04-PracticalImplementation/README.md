<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "5384bbb2a92d00d5d7e66274dbe0331d",
  "translation_date": "2025-07-13T22:44:50+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ar"
}
-->
# التنفيذ العملي

التنفيذ العملي هو المكان الذي يصبح فيه قوة بروتوكول سياق النموذج (MCP) ملموسة. بينما يعد فهم النظرية والهندسة المعمارية وراء MCP أمرًا مهمًا، تظهر القيمة الحقيقية عندما تطبق هذه المفاهيم لبناء واختبار ونشر حلول تحل مشاكل العالم الحقيقي. هذا الفصل يجسر الفجوة بين المعرفة النظرية والتطوير العملي، ويرشدك خلال عملية إحياء تطبيقات تعتمد على MCP.

سواء كنت تطور مساعدين ذكيين، أو تدمج الذكاء الاصطناعي في سير عمل الأعمال، أو تبني أدوات مخصصة لمعالجة البيانات، يوفر MCP أساسًا مرنًا. تصميمه المستقل عن اللغة وSDKs الرسمية للغات البرمجة الشائعة تجعله متاحًا لمجموعة واسعة من المطورين. من خلال الاستفادة من هذه SDKs، يمكنك بسرعة إنشاء نماذج أولية، والتكرار، وتوسيع حلولك عبر منصات وبيئات مختلفة.

في الأقسام التالية، ستجد أمثلة عملية، وأكواد نموذجية، واستراتيجيات نشر توضح كيفية تنفيذ MCP في C#، Java، TypeScript، JavaScript، وPython. ستتعلم أيضًا كيفية تصحيح واختبار خوادم MCP، وإدارة APIs، ونشر الحلول على السحابة باستخدام Azure. هذه الموارد العملية مصممة لتسريع تعلمك ومساعدتك على بناء تطبيقات MCP قوية وجاهزة للإنتاج بثقة.

## نظرة عامة

يركز هذا الدرس على الجوانب العملية لتنفيذ MCP عبر لغات برمجة متعددة. سنستعرض كيفية استخدام SDKs الخاصة بـ MCP في C#، Java، TypeScript، JavaScript، وPython لبناء تطبيقات قوية، وتصحيح واختبار خوادم MCP، وإنشاء موارد، ونماذج، وأدوات قابلة لإعادة الاستخدام.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:
- تنفيذ حلول MCP باستخدام SDKs الرسمية في لغات برمجة مختلفة
- تصحيح واختبار خوادم MCP بشكل منهجي
- إنشاء واستخدام ميزات الخادم (الموارد، النماذج، والأدوات)
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

يوفر هذا القسم أمثلة عملية لتنفيذ MCP عبر لغات برمجة متعددة. يمكنك العثور على أكواد نموذجية في مجلد `samples` المرتب حسب اللغة.

### العينات المتاحة

يحتوي المستودع على [تنفيذات نموذجية](../../../04-PracticalImplementation/samples) باللغات التالية:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

كل عينة توضح مفاهيم MCP الأساسية وأنماط التنفيذ الخاصة بتلك اللغة والنظام البيئي.

## الميزات الأساسية للخادم

يمكن لخوادم MCP تنفيذ أي تركيبة من هذه الميزات:

### الموارد  
توفر الموارد السياق والبيانات للمستخدم أو نموذج الذكاء الاصطناعي لاستخدامها:  
- مستودعات الوثائق  
- قواعد المعرفة  
- مصادر البيانات المنظمة  
- أنظمة الملفات  

### النماذج  
النماذج هي رسائل وقوالب سير عمل موجهة للمستخدمين:  
- قوالب محادثة محددة مسبقًا  
- أنماط تفاعل موجهة  
- هياكل حوار متخصصة  

### الأدوات  
الأدوات هي وظائف ينفذها نموذج الذكاء الاصطناعي:  
- أدوات معالجة البيانات  
- تكاملات API خارجية  
- قدرات حسابية  
- وظائف البحث  

## تنفيذات نموذجية: C#

يحتوي مستودع SDK الرسمي لـ C# على عدة تنفيذات نموذجية توضح جوانب مختلفة من MCP:

- **عميل MCP أساسي**: مثال بسيط يوضح كيفية إنشاء عميل MCP واستدعاء الأدوات  
- **خادم MCP أساسي**: تنفيذ خادم بسيط مع تسجيل أدوات أساسي  
- **خادم MCP متقدم**: خادم كامل الميزات مع تسجيل الأدوات، المصادقة، ومعالجة الأخطاء  
- **تكامل ASP.NET**: أمثلة توضح التكامل مع ASP.NET Core  
- **أنماط تنفيذ الأدوات**: أنماط مختلفة لتنفيذ الأدوات بمستويات تعقيد متنوعة  

SDK الخاص بـ MCP لـ C# في مرحلة المعاينة وقد تتغير واجهات برمجة التطبيقات. سنستمر في تحديث هذه المدونة مع تطور SDK.

### الميزات الرئيسية  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- بناء [أول خادم MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

للحصول على عينات تنفيذ كاملة لـ C#، قم بزيارة [مستودع عينات SDK الرسمي لـ C#](https://github.com/modelcontextprotocol/csharp-sdk)

## تنفيذ نموذجي: تنفيذ Java

يقدم SDK الخاص بـ Java خيارات تنفيذ MCP قوية مع ميزات على مستوى المؤسسات.

### الميزات الرئيسية

- تكامل مع Spring Framework  
- أمان نوعي قوي  
- دعم البرمجة التفاعلية  
- معالجة شاملة للأخطاء  

لعينة تنفيذ Java كاملة، راجع [عينة Java](samples/java/containerapp/README.md) في مجلد العينات.

## تنفيذ نموذجي: تنفيذ JavaScript

يوفر SDK الخاص بـ JavaScript نهجًا خفيف الوزن ومرنًا لتنفيذ MCP.

### الميزات الرئيسية

- دعم Node.js والمتصفح  
- API قائم على الوعود (Promises)  
- تكامل سهل مع Express وأطر عمل أخرى  
- دعم WebSocket للبث  

لعينة تنفيذ JavaScript كاملة، راجع [عينة JavaScript](samples/javascript/README.md) في مجلد العينات.

## تنفيذ نموذجي: تنفيذ Python

يقدم SDK الخاص بـ Python نهجًا بيثونيًا لتنفيذ MCP مع تكامل ممتاز مع أطر تعلم الآلة.

### الميزات الرئيسية

- دعم async/await مع asyncio  
- تكامل مع Flask وFastAPI  
- تسجيل أدوات بسيط  
- تكامل أصلي مع مكتبات تعلم الآلة الشهيرة  

لعينة تنفيذ Python كاملة، راجع [عينة Python](samples/python/README.md) في مجلد العينات.

## إدارة API

تعد Azure API Management حلاً ممتازًا لكيفية تأمين خوادم MCP. الفكرة هي وضع مثيل Azure API Management أمام خادم MCP الخاص بك وتركه يتولى ميزات قد تحتاجها مثل:

- تحديد معدلات الاستخدام  
- إدارة الرموز  
- المراقبة  
- موازنة التحميل  
- الأمان  

### عينة Azure

إليك عينة من Azure تقوم بذلك بالضبط، أي [إنشاء خادم MCP وتأمينه باستخدام Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

شاهد كيف يتم تدفق التفويض في الصورة أدناه:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

في الصورة السابقة، يحدث ما يلي:

- تتم المصادقة/التفويض باستخدام Microsoft Entra.  
- يعمل Azure API Management كبوابة ويستخدم السياسات لتوجيه وإدارة حركة المرور.  
- يقوم Azure Monitor بتسجيل جميع الطلبات للتحليل لاحقًا.  

#### تدفق التفويض

لنلق نظرة أكثر تفصيلًا على تدفق التفويض:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### مواصفة تفويض MCP

تعرف أكثر على [مواصفة تفويض MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## نشر خادم MCP عن بُعد على Azure

لنرَ إذا كان بإمكاننا نشر العينة التي ذكرناها سابقًا:

1. استنساخ المستودع

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

1. تسجيل مزود الموارد `Microsoft.App`.  
    * إذا كنت تستخدم Azure CLI، شغّل الأمر `az provider register --namespace Microsoft.App --wait`.  
    * إذا كنت تستخدم Azure PowerShell، شغّل `Register-AzResourceProvider -ProviderNamespace Microsoft.App`. ثم شغّل `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState` بعد فترة للتحقق من اكتمال التسجيل.  

2. شغّل هذا الأمر [azd](https://aka.ms/azd) لتوفير خدمة إدارة API، وتطبيق الوظائف (مع الكود)، وجميع موارد Azure المطلوبة الأخرى

    ```shell
    azd up
    ```

    يجب أن تنشر هذه الأوامر جميع موارد السحابة على Azure

### اختبار الخادم باستخدام MCP Inspector

1. في **نافذة طرفية جديدة**، قم بتثبيت وتشغيل MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    يجب أن ترى واجهة مشابهة لـ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ar.png) 

1. اضغط مع CTRL لتحميل تطبيق MCP Inspector من عنوان URL المعروض بواسطة التطبيق (مثلاً http://127.0.0.1:6274/#resources)  
1. اضبط نوع النقل إلى `SSE`  
1. اضبط عنوان URL إلى نقطة نهاية SSE الخاصة بإدارة API التي تعمل لديك والمعروضة بعد تنفيذ `azd up` ثم **اتصل**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **قائمة الأدوات**. انقر على أداة ثم **تشغيل الأداة**.  

إذا نجحت كل الخطوات، يجب أن تكون متصلًا الآن بخادم MCP وقد تمكنت من استدعاء أداة.

## خوادم MCP لـ Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): هذه المجموعة من المستودعات هي قالب بدء سريع لبناء ونشر خوادم MCP (بروتوكول سياق النموذج) عن بُعد مخصصة باستخدام Azure Functions مع Python، C# .NET أو Node/TypeScript.

توفر العينات حلاً كاملاً يسمح للمطورين بـ:

- البناء والتشغيل محليًا: تطوير وتصحيح خادم MCP على جهاز محلي  
- النشر على Azure: نشر سهل إلى السحابة بأمر azd up بسيط  
- الاتصال من العملاء: الاتصال بخادم MCP من عملاء مختلفين بما في ذلك وضع وكيل Copilot في VS Code وأداة MCP Inspector  

### الميزات الرئيسية:

- الأمان من التصميم: خادم MCP مؤمن باستخدام مفاتيح وHTTPS  
- خيارات المصادقة: يدعم OAuth باستخدام المصادقة المدمجة و/أو إدارة API  
- عزل الشبكة: يسمح بعزل الشبكة باستخدام شبكات Azure الافتراضية (VNET)  
- بنية بدون خادم: يستفيد من Azure Functions لتنفيذ قابل للتوسع وموجه بالأحداث  
- التطوير المحلي: دعم شامل للتطوير المحلي وتصحيح الأخطاء  
- النشر البسيط: عملية نشر مبسطة إلى Azure  

يحتوي المستودع على جميع ملفات التكوين الضرورية، وكود المصدر، وتعريفات البنية التحتية للبدء بسرعة في تنفيذ خادم MCP جاهز للإنتاج.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - تنفيذ نموذجي لـ MCP باستخدام Azure Functions مع Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - تنفيذ نموذجي لـ MCP باستخدام Azure Functions مع C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - تنفيذ نموذجي لـ MCP باستخدام Azure Functions مع Node/TypeScript.

## النقاط الرئيسية

- توفر SDKs الخاصة بـ MCP أدوات مخصصة لكل لغة لتنفيذ حلول MCP قوية  
- عملية التصحيح والاختبار حاسمة لتطبيقات MCP موثوقة  
- قوالب النماذج القابلة لإعادة الاستخدام تتيح تفاعلات AI متسقة  
- يمكن لسير العمل المصمم جيدًا تنسيق مهام معقدة باستخدام أدوات متعددة  
- يتطلب تنفيذ حلول MCP مراعاة الأمان، الأداء، ومعالجة الأخطاء  

## تمرين

صمم سير عمل MCP عملي يعالج مشكلة حقيقية في مجالك:

1. حدد 3-4 أدوات ستكون مفيدة لحل هذه المشكلة  
2. أنشئ مخطط سير عمل يوضح كيفية تفاعل هذه الأدوات  
3. نفذ نسخة أساسية من إحدى الأدوات باستخدام لغتك المفضلة  
4. أنشئ قالب نموذج يساعد النموذج على استخدام أداتك بفعالية  

## موارد إضافية


---

التالي: [مواضيع متقدمة](../05-AdvancedTopics/README.md)

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.