<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "d88dbf928fa0f159b82312e9a6757ba0",
  "translation_date": "2025-06-18T08:35:12+00:00",
  "source_file": "04-PracticalImplementation/README.md",
  "language_code": "ar"
}
-->
# التنفيذ العملي

التنفيذ العملي هو المكان الذي يصبح فيه بروتوكول سياق النموذج (MCP) ملموسًا وقويًا. بينما يعد فهم النظرية والهندسة المعمارية وراء MCP أمرًا مهمًا، تظهر القيمة الحقيقية عند تطبيق هذه المفاهيم لبناء واختبار ونشر حلول تحل مشاكل العالم الحقيقي. هذا الفصل يجسر الفجوة بين المعرفة المفاهيمية والتطوير العملي، موجهاً إياك خلال عملية إحياء تطبيقات تعتمد على MCP.

سواء كنت تطور مساعدين ذكيين، أو تدمج الذكاء الاصطناعي في سير عمل الأعمال، أو تبني أدوات مخصصة لمعالجة البيانات، يوفر MCP أساسًا مرنًا. تصميمه المستقل عن اللغة وSDKs الرسمية للغات البرمجة الشهيرة يجعله متاحًا لمجموعة واسعة من المطورين. من خلال الاستفادة من هذه SDKs، يمكنك بسرعة إنشاء نماذج أولية، وتكرارها، وتوسيع حلولك عبر منصات وبيئات مختلفة.

في الأقسام التالية، ستجد أمثلة عملية، وأكواد نموذجية، واستراتيجيات نشر توضح كيفية تنفيذ MCP في C#، Java، TypeScript، JavaScript، وPython. ستتعلم أيضًا كيفية تصحيح واختبار خوادم MCP، إدارة APIs، ونشر الحلول على السحابة باستخدام Azure. هذه الموارد العملية مصممة لتسريع تعلمك ومساعدتك على بناء تطبيقات MCP قوية وجاهزة للإنتاج بثقة.

## نظرة عامة

يركز هذا الدرس على الجوانب العملية لتنفيذ MCP عبر لغات برمجة متعددة. سنستعرض كيفية استخدام SDKs الخاصة بـ MCP في C#، Java، TypeScript، JavaScript، وPython لبناء تطبيقات قوية، وتصحيح واختبار خوادم MCP، وإنشاء موارد وقوالب وأدوات قابلة لإعادة الاستخدام.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:
- تنفيذ حلول MCP باستخدام SDKs الرسمية في لغات برمجة مختلفة
- تصحيح واختبار خوادم MCP بشكل منهجي
- إنشاء واستخدام ميزات الخادم (الموارد، القوالب، والأدوات)
- تصميم سير عمل MCP فعال للمهام المعقدة
- تحسين تنفيذات MCP من حيث الأداء والموثوقية

## موارد SDK الرسمية

يوفر بروتوكول سياق النموذج SDKs رسمية لعدة لغات:

- [C# SDK](https://github.com/modelcontextprotocol/csharp-sdk)
- [Java SDK](https://github.com/modelcontextprotocol/java-sdk) 
- [TypeScript SDK](https://github.com/modelcontextprotocol/typescript-sdk)
- [Python SDK](https://github.com/modelcontextprotocol/python-sdk)
- [Kotlin SDK](https://github.com/modelcontextprotocol/kotlin-sdk)

## العمل مع SDKs الخاصة بـ MCP

يوفر هذا القسم أمثلة عملية لتنفيذ MCP عبر عدة لغات برمجة. يمكنك العثور على أكواد نموذجية في مجلد `samples` منظم حسب اللغة.

### العينات المتاحة

يتضمن المستودع [تنفيذات نموذجية](../../../04-PracticalImplementation/samples) باللغات التالية:

- [C#](./samples/csharp/README.md)
- [Java](./samples/java/containerapp/README.md)
- [TypeScript](./samples/typescript/README.md)
- [JavaScript](./samples/javascript/README.md)
- [Python](./samples/python/README.md)

كل نموذج يعرض مفاهيم MCP الأساسية وأنماط التنفيذ الخاصة بتلك اللغة والنظام البيئي.

## الميزات الأساسية للخادم

يمكن لخوادم MCP تنفيذ أي مزيج من هذه الميزات:

### الموارد  
توفر الموارد السياق والبيانات للمستخدم أو نموذج الذكاء الاصطناعي لاستخدامها:
- مستودعات الوثائق
- قواعد المعرفة
- مصادر البيانات المهيكلة
- أنظمة الملفات

### القوالب  
القوالب هي رسائل وسير عمل مُعدة مسبقًا للمستخدمين:
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

- **عميل MCP الأساسي**: مثال بسيط يوضح كيفية إنشاء عميل MCP واستدعاء الأدوات
- **خادم MCP الأساسي**: تنفيذ خادم بسيط مع تسجيل أدوات أساسي
- **خادم MCP متقدم**: خادم كامل الميزات مع تسجيل الأدوات، المصادقة، ومعالجة الأخطاء
- **تكامل ASP.NET**: أمثلة توضح التكامل مع ASP.NET Core
- **أنماط تنفيذ الأدوات**: أنماط مختلفة لتنفيذ الأدوات بمستويات تعقيد مختلفة

SDK الخاص بـ MCP لـ C# في مرحلة المعاينة وقد تتغير APIs. سنستمر في تحديث هذا المدونة مع تطور SDK.

### الميزات الرئيسية  
- [C# MCP Nuget ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol)

- بناء [أول خادم MCP](https://devblogs.microsoft.com/dotnet/build-a-model-context-protocol-mcp-server-in-csharp/).

لعينات تنفيذ C# كاملة، قم بزيارة [مستودع عينات SDK الرسمي لـ C#](https://github.com/modelcontextprotocol/csharp-sdk)

## تنفيذ نموذجي: تنفيذ Java

يوفر SDK الخاص بـ Java خيارات تنفيذ MCP قوية مع ميزات بمستوى المؤسسات.

### الميزات الرئيسية

- تكامل مع Spring Framework
- أمان قوي للأنواع
- دعم البرمجة التفاعلية
- معالجة شاملة للأخطاء

لعينة تنفيذ Java كاملة، راجع [MCPSample.java](../../../04-PracticalImplementation/samples/java/MCPSample.java) في مجلد العينات.

## تنفيذ نموذجي: تنفيذ JavaScript

يوفر SDK الخاص بـ JavaScript نهجًا خفيف الوزن ومرنًا لتنفيذ MCP.

### الميزات الرئيسية

- دعم Node.js والمتصفح
- API مبني على الوعود (Promises)
- تكامل سهل مع Express وأطر عمل أخرى
- دعم WebSocket للبث المباشر

لعينة تنفيذ JavaScript كاملة، راجع [mcp_sample.js](../../../04-PracticalImplementation/samples/javascript/mcp_sample.js) في مجلد العينات.

## تنفيذ نموذجي: تنفيذ Python

يقدم SDK الخاص بـ Python نهجًا "بايثونيًا" لتنفيذ MCP مع تكامل ممتاز مع أطر التعلم الآلي.

### الميزات الرئيسية

- دعم async/await مع asyncio
- تكامل مع Flask وFastAPI
- تسجيل أدوات بسيط
- تكامل أصلي مع مكتبات ML الشهيرة

لعينة تنفيذ Python كاملة، راجع [mcp_sample.py](../../../04-PracticalImplementation/samples/python/mcp_sample.py) في مجلد العينات.

## إدارة API

يعد Azure API Management حلاً ممتازًا لكيفية تأمين خوادم MCP. الفكرة هي وضع مثيل Azure API Management أمام خادم MCP الخاص بك وتركه يتولى الميزات التي قد تحتاجها مثل:

- تحديد معدلات الاستخدام
- إدارة الرموز
- المراقبة
- موازنة الحمل
- الأمان

### مثال Azure

إليك مثال على Azure يقوم بذلك بالضبط، أي [إنشاء خادم MCP وتأمينه باستخدام Azure API Management](https://github.com/Azure-Samples/remote-mcp-apim-functions-python).

شاهد كيف يتم تدفق التفويض في الصورة أدناه:

![APIM-MCP](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/mcp-client-authorization.gif?raw=true) 

في الصورة السابقة، يحدث ما يلي:

- يتم المصادقة/التفويض باستخدام Microsoft Entra.
- يعمل Azure API Management كبوابة ويستخدم السياسات لتوجيه وإدارة الحركة.
- يقوم Azure Monitor بتسجيل جميع الطلبات للتحليل لاحقًا.

#### تدفق التفويض

لنلق نظرة أكثر تفصيلاً على تدفق التفويض:

![Sequence Diagram](https://github.com/Azure-Samples/remote-mcp-apim-functions-python/blob/main/infra/app/apim-oauth/diagrams/images/mcp-client-auth.png?raw=true)

#### مواصفات تفويض MCP

تعرف أكثر على [مواصفات تفويض MCP](https://modelcontextprotocol.io/specification/2025-03-26/basic/authorization#2-10-third-party-authorization-flow)

## نشر خادم MCP عن بُعد على Azure

لنرَ إذا كان بإمكاننا نشر العينة التي ذكرناها سابقًا:

1. استنساخ المستودع

    ```bash
    git clone https://github.com/Azure-Samples/remote-mcp-apim-functions-python.git
    cd remote-mcp-apim-functions-python
    ```

2. سجل موفر `Microsoft.App` باستخدام الأمر:

    `az provider register --namespace Microsoft.App --wait`  
    أو  
    `Register-AzResourceProvider -ProviderNamespace Microsoft.App`  
    ثم تحقق من حالة التسجيل باستخدام:  
    `(Get-AzResourceProvider -ProviderNamespace Microsoft.App).RegistrationState`

3. نفذ هذا الأمر [azd](https://aka.ms/azd) لتوفير خدمة إدارة API، وتطبيق الدوال (مع الكود)، وجميع الموارد الأخرى المطلوبة في Azure:

    ```shell
    azd up
    ```

    هذا الأمر يجب أن ينشر كل موارد السحابة على Azure

### اختبار الخادم باستخدام MCP Inspector

1. في **نافذة طرفية جديدة**، قم بتثبيت وتشغيل MCP Inspector

    ```shell
    npx @modelcontextprotocol/inspector
    ```

    يجب أن ترى واجهة مشابهة لـ:

    ![Connect to Node inspector](../../../translated_images/connect.141db0b2bd05f096fb1dd91273771fd8b2469d6507656c3b0c9df4b3c5473929.ar.png) 

2. اضغط مع CTRL لتحميل تطبيق MCP Inspector من العنوان الذي يعرضه التطبيق (مثلاً: http://127.0.0.1:6274/#resources)
3. اضبط نوع النقل إلى `SSE` ثم نفذ الأمر `azd up` و**اتصل**:

    ```shell
    https://<apim-servicename-from-azd-output>.azure-api.net/mcp/sse
    ```

5. **عرض الأدوات**. انقر على أداة ثم **تشغيل الأداة**.

إذا نجحت كل الخطوات، فأنت الآن متصل بخادم MCP وتمكنت من استدعاء أداة.

## خوادم MCP لـ Azure

[Remote-mcp-functions](https://github.com/Azure-Samples/remote-mcp-functions-dotnet): هذه المجموعة من المستودعات هي قالب بداية سريعة لبناء ونشر خوادم MCP عن بُعد مخصصة باستخدام Azure Functions مع Python، C# .NET أو Node/TypeScript.

توفر العينات حلاً كاملاً يتيح للمطورين:

- البناء والتشغيل محليًا: تطوير وتصحيح خادم MCP على جهاز محلي
- النشر إلى Azure: نشر سهل إلى السحابة بأمر بسيط `azd up`
- الاتصال من العملاء: الاتصال بخادم MCP من عملاء مختلفين بما في ذلك وضع وكيل Copilot في VS Code وأداة MCP Inspector

### الميزات الرئيسية:

- الأمان من التصميم: خادم MCP مؤمن باستخدام مفاتيح وHTTPS
- خيارات المصادقة: يدعم OAuth باستخدام المصادقة المدمجة و/أو إدارة API
- عزل الشبكة: يسمح بعزل الشبكة باستخدام شبكات Azure الافتراضية (VNET)
- بنية خالية من الخوادم: يستخدم Azure Functions للتنفيذ القابل للتوسع والمعتمد على الأحداث
- تطوير محلي شامل: دعم شامل للتطوير والتصحيح محليًا
- نشر بسيط: عملية نشر مبسطة إلى Azure

يحتوي المستودع على جميع ملفات التكوين الضرورية، وكود المصدر، وتعريفات البنية التحتية للبدء السريع بتنفيذ خادم MCP جاهز للإنتاج.

- [Azure Remote MCP Functions Python](https://github.com/Azure-Samples/remote-mcp-functions-python) - تنفيذ نموذجي لـ MCP باستخدام Azure Functions مع Python

- [Azure Remote MCP Functions .NET](https://github.com/Azure-Samples/remote-mcp-functions-dotnet) - تنفيذ نموذجي لـ MCP باستخدام Azure Functions مع C# .NET

- [Azure Remote MCP Functions Node/Typescript](https://github.com/Azure-Samples/remote-mcp-functions-typescript) - تنفيذ نموذجي لـ MCP باستخدام Azure Functions مع Node/TypeScript.

## النقاط الرئيسية المستفادة

- توفر SDKs الخاصة بـ MCP أدوات مخصصة لكل لغة لتنفيذ حلول MCP قوية
- عملية التصحيح والاختبار ضرورية لتطبيقات MCP موثوقة
- قوالب القوالب القابلة لإعادة الاستخدام تمكّن تفاعلات AI متسقة
- يمكن لسير العمل المصمم جيدًا تنسيق مهام معقدة باستخدام أدوات متعددة
- يتطلب تنفيذ حلول MCP مراعاة الأمان، الأداء، ومعالجة الأخطاء

## تمرين

صمم سير عمل MCP عملي يعالج مشكلة حقيقية في مجالك:

1. حدد 3-4 أدوات ستكون مفيدة لحل هذه المشكلة
2. أنشئ مخطط سير عمل يوضح كيفية تفاعل هذه الأدوات
3. نفذ نسخة أساسية من إحدى الأدوات باستخدام لغتك المفضلة
4. أنشئ قالبًا للنموذج يساعد النموذج على استخدام أداتك بفعالية

## موارد إضافية


---

التالي: [الموضوعات المتقدمة](../05-AdvancedTopics/README.md)

**إخلاء مسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الحساسة، يُنصح بالاعتماد على الترجمة المهنية البشرية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.