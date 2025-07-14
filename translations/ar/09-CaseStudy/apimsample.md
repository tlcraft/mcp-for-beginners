<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "36de9fae488d6de554d969fe8e0801a8",
  "translation_date": "2025-07-14T05:20:27+00:00",
  "source_file": "09-CaseStudy/apimsample.md",
  "language_code": "ar"
}
-->
# دراسة حالة: كشف REST API في إدارة API كخادم MCP

تُعد Azure API Management خدمة توفر بوابة فوق نقاط نهاية API الخاصة بك. طريقة عملها هي أن Azure API Management تعمل كوكيل أمام واجهات برمجة التطبيقات الخاصة بك ويمكنها تحديد ما يجب فعله مع الطلبات الواردة.

باستخدامها، تضيف مجموعة كاملة من الميزات مثل:

- **الأمان**، يمكنك استخدام كل شيء من مفاتيح API، JWT إلى الهوية المُدارة.
- **تحديد المعدل**، ميزة رائعة تتيح لك تحديد عدد المكالمات التي تمر خلال وحدة زمنية معينة. هذا يساعد على ضمان تجربة ممتازة لجميع المستخدمين وأيضًا على عدم إرهاق خدمتك بالطلبات.
- **التحجيم وتوزيع الحمل**. يمكنك إعداد عدد من نقاط النهاية لتوزيع الحمل ويمكنك أيضًا تحديد كيفية "توزيع الحمل".
- **ميزات الذكاء الاصطناعي مثل التخزين المؤقت الدلالي**، حد الرموز ومراقبة الرموز والمزيد. هذه ميزات رائعة تحسن الاستجابة وتساعدك أيضًا على متابعة استهلاك الرموز. [اقرأ المزيد هنا](https://learn.microsoft.com/en-us/azure/api-management/genai-gateway-capabilities).

## لماذا MCP + Azure API Management؟

يصبح بروتوكول سياق النموذج (Model Context Protocol) بسرعة معيارًا لتطبيقات الذكاء الاصطناعي الوكيلة وكيفية كشف الأدوات والبيانات بطريقة متسقة. تُعد Azure API Management خيارًا طبيعيًا عندما تحتاج إلى "إدارة" واجهات برمجة التطبيقات. غالبًا ما تتكامل خوادم MCP مع واجهات برمجة تطبيقات أخرى لحل الطلبات إلى أداة على سبيل المثال. لذلك، يجمع دمج Azure API Management وMCP بين المنطقي.

## نظرة عامة

في هذه الحالة العملية المحددة، سنتعلم كيفية كشف نقاط نهاية API كخادم MCP. من خلال القيام بذلك، يمكننا بسهولة جعل هذه النقاط جزءًا من تطبيق وكيل مع الاستفادة أيضًا من ميزات Azure API Management.

## الميزات الرئيسية

- تختار طرق نقاط النهاية التي تريد كشفها كأدوات.
- الميزات الإضافية التي تحصل عليها تعتمد على ما تقوم بتكوينه في قسم السياسات لواجهة برمجة التطبيقات الخاصة بك. لكن هنا سنوضح لك كيفية إضافة تحديد المعدل.

## الخطوة التمهيدية: استيراد API

إذا كان لديك API في Azure API Management بالفعل، فهذا رائع، يمكنك تخطي هذه الخطوة. إذا لم يكن لديك، اطلع على هذا الرابط، [استيراد API إلى Azure API Management](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish#import-and-publish-a-backend-api).

## كشف API كخادم MCP

لكشف نقاط نهاية API، دعنا نتبع هذه الخطوات:

1. انتقل إلى بوابة Azure والعنوان التالي <https://portal.azure.com/?Microsoft_Azure_ApiManagement=mcp>  
انتقل إلى مثيل إدارة API الخاص بك.

1. في القائمة اليسرى، اختر APIs > MCP Servers > + إنشاء خادم MCP جديد.

1. في API، اختر REST API للكشف عنه كخادم MCP.

1. اختر عملية أو أكثر من عمليات API للكشف عنها كأدوات. يمكنك اختيار جميع العمليات أو عمليات محددة فقط.

    ![اختر الطرق للكشف](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/create-mcp-server-small.png)

1. اختر **إنشاء**.

1. انتقل إلى خيار القائمة **APIs** و**MCP Servers**، يجب أن ترى ما يلي:

    ![رؤية خادم MCP في اللوحة الرئيسية](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-list.png)

    تم إنشاء خادم MCP وتم كشف عمليات API كأدوات. يظهر خادم MCP في لوحة MCP Servers. يعرض عمود URL نقطة نهاية خادم MCP التي يمكنك الاتصال بها للاختبار أو ضمن تطبيق عميل.

## اختياري: تكوين السياسات

تحتوي Azure API Management على مفهوم أساسي وهو السياسات حيث تقوم بإعداد قواعد مختلفة لنقاط النهاية الخاصة بك مثل تحديد المعدل أو التخزين المؤقت الدلالي. تُكتب هذه السياسات بصيغة XML.

إليك كيفية إعداد سياسة لتحديد معدل خادم MCP الخاص بك:

1. في البوابة، ضمن APIs، اختر **MCP Servers**.

1. اختر خادم MCP الذي أنشأته.

1. في القائمة اليسرى، ضمن MCP، اختر **Policies**.

1. في محرر السياسات، أضف أو حرر السياسات التي تريد تطبيقها على أدوات خادم MCP. تُعرف السياسات بصيغة XML. على سبيل المثال، يمكنك إضافة سياسة لتحديد عدد المكالمات إلى أدوات خادم MCP (في هذا المثال، 5 مكالمات لكل 30 ثانية لكل عنوان IP عميل). هذا هو XML الذي سيؤدي إلى تحديد المعدل:

    ```xml
     <rate-limit-by-key calls="5" 
       renewal-period="30" 
       counter-key="@(context.Request.IpAddress)" 
       remaining-calls-variable-name="remainingCallsPerIP" 
    />
    ```

    هذه صورة لمحرر السياسات:

    ![محرر السياسات](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-policies-small.png)
 
## جربها

لنتأكد من أن خادم MCP يعمل كما هو مقصود.

لهذا، سنستخدم Visual Studio Code وGitHub Copilot ووضع الوكيل الخاص به. سنضيف خادم MCP إلى ملف *mcp.json*. من خلال القيام بذلك، سيعمل Visual Studio Code كعميل بقدرات وكيلة وسيتمكن المستخدمون النهائيون من كتابة موجه والتفاعل مع الخادم المذكور.

لنر كيف نضيف خادم MCP في Visual Studio Code:

1. استخدم أمر MCP: **Add Server من لوحة الأوامر**.

1. عند المطالبة، اختر نوع الخادم: **HTTP (HTTP أو Server Sent Events)**.

1. أدخل عنوان URL الخاص بخادم MCP في إدارة API. مثال: **https://<apim-service-name>.azure-api.net/<api-name>-mcp/sse** (لنقطة نهاية SSE) أو **https://<apim-service-name>.azure-api.net/<api-name>-mcp/mcp** (لنقطة نهاية MCP)، لاحظ الفرق بين وسائل النقل هو `/sse` أو `/mcp`.

1. أدخل معرف خادم من اختيارك. هذه قيمة غير مهمة لكنها ستساعدك على تذكر ما هو هذا المثيل من الخادم.

1. اختر ما إذا كنت تريد حفظ التكوين في إعدادات مساحة العمل أو إعدادات المستخدم.

  - **إعدادات مساحة العمل** - يتم حفظ تكوين الخادم في ملف .vscode/mcp.json المتاح فقط في مساحة العمل الحالية.

    *mcp.json*

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "sse",
            "url": "url-to-mcp-server/sse"
        }
    }
    ```

    أو إذا اخترت HTTP المتدفق كوسيلة نقل فسيكون مختلفًا قليلاً:

    ```json
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp"
        }
    }
    ```

  - **إعدادات المستخدم** - يتم إضافة تكوين الخادم إلى ملف *settings.json* العالمي الخاص بك وهو متاح في جميع مساحات العمل. يبدو التكوين مشابهًا لما يلي:

    ![إعداد المستخدم](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-servers-visual-studio-code.png)

1. تحتاج أيضًا إلى إضافة تكوين، رأس للتأكد من أنه يتم المصادقة بشكل صحيح تجاه Azure API Management. يستخدم رأسًا يسمى **Ocp-Apim-Subscription-Key**.

    - إليك كيفية إضافته إلى الإعدادات:

    ![إضافة رأس للمصادقة](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/mcp-server-with-header-visual-studio-code.png)، هذا سيؤدي إلى عرض موجه يطلب منك قيمة مفتاح API التي يمكنك العثور عليها في بوابة Azure لمثيل Azure API Management الخاص بك.

   - لإضافته إلى *mcp.json* بدلاً من ذلك، يمكنك إضافته كما يلي:

    ```json
    "inputs": [
      {
        "type": "promptString",
        "id": "apim_key",
        "description": "API Key for Azure API Management",
        "password": true
      }
    ]
    "servers": {
        "APIM petstore" : {
            "type": "http",
            "url": "url-to-mcp-server/mcp",
            "headers": {
                "Ocp-Apim-Subscription-Key": "Bearer ${input:apim_key}"
            }
        }
    }
    ```

### استخدام وضع الوكيل

الآن نحن جاهزون سواء في الإعدادات أو في *.vscode/mcp.json*. دعنا نجربها.

يجب أن يكون هناك أيقونة أدوات مثل هذه، حيث تُدرج الأدوات المكشوفة من خادمك:

![الأدوات من الخادم](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/tools-button-visual-studio-code.png)

1. انقر على أيقونة الأدوات ويجب أن ترى قائمة بالأدوات مثل هذه:

    ![الأدوات](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/select-tools-visual-studio-code.png)

1. أدخل موجهًا في الدردشة لاستدعاء الأداة. على سبيل المثال، إذا اخترت أداة للحصول على معلومات حول طلب، يمكنك سؤال الوكيل عن طلب. إليك مثال على الموجه:

    ```text
    get information from order 2
    ```

    ستظهر لك الآن أيقونة أدوات تطلب منك المتابعة لاستدعاء أداة. اختر المتابعة لتشغيل الأداة، يجب أن ترى الآن ناتجًا مثل هذا:

    ![النتيجة من الموجه](https://learn.microsoft.com/en-us/azure/api-management/media/export-rest-mcp-server/chat-results-visual-studio-code.png)

    **ما تراه أعلاه يعتمد على الأدوات التي قمت بإعدادها، لكن الفكرة هي أنك تحصل على استجابة نصية مثل المعروض أعلاه**

## المراجع

إليك كيفية معرفة المزيد:

- [دليل حول Azure API Management وMCP](https://learn.microsoft.com/en-us/azure/api-management/export-rest-mcp-server)
- [عينة بايثون: تأمين خوادم MCP البعيدة باستخدام Azure API Management (تجريبي)](https://github.com/Azure-Samples/remote-mcp-apim-functions-python)

- [مختبر تفويض عميل MCP](https://github.com/Azure-Samples/AI-Gateway/tree/main/labs/mcp-client-authorization)

- [استخدام امتداد Azure API Management لـ VS Code لاستيراد وإدارة APIs](https://learn.microsoft.com/en-us/azure/api-management/visual-studio-code-tutorial)

- [تسجيل واكتشاف خوادم MCP البعيدة في Azure API Center](https://learn.microsoft.com/en-us/azure/api-center/register-discover-mcp-server)
- [بوابة الذكاء الاصطناعي](https://github.com/Azure-Samples/AI-Gateway) مستودع رائع يعرض العديد من قدرات الذكاء الاصطناعي مع Azure API Management
- [ورش عمل بوابة الذكاء الاصطناعي](https://azure-samples.github.io/AI-Gateway/) تحتوي على ورش عمل باستخدام بوابة Azure، وهي طريقة رائعة لبدء تقييم قدرات الذكاء الاصطناعي.

**إخلاء المسؤولية**:  
تمت ترجمة هذا المستند باستخدام خدمة الترجمة الآلية [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار المستند الأصلي بلغته الأصلية المصدر الموثوق به. للمعلومات الهامة، يُنصح بالاعتماد على الترجمة البشرية المهنية. نحن غير مسؤولين عن أي سوء فهم أو تفسير ناتج عن استخدام هذه الترجمة.