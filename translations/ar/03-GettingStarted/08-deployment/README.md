<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:49:28+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "ar"
}
-->
# نشر خوادم MCP

نشر خادم MCP الخاص بك يسمح للآخرين بالوصول إلى أدواته وموارده خارج بيئتك المحلية. هناك العديد من استراتيجيات النشر التي يمكن النظر فيها، اعتمادًا على متطلباتك للتوسع، والموثوقية، وسهولة الإدارة. ستجد أدناه توجيهات لنشر خوادم MCP محليًا، في الحاويات، وعلى السحابة.

## نظرة عامة

تغطي هذه الدرس كيفية نشر تطبيق خادم MCP الخاص بك.

## أهداف التعلم

بنهاية هذا الدرس، ستكون قادرًا على:

- تقييم طرق النشر المختلفة.
- نشر تطبيقك.

## التطوير والنشر المحلي

إذا كان من المفترض أن يتم استهلاك الخادم من خلال تشغيله على أجهزة المستخدمين، يمكنك اتباع الخطوات التالية:

1. **تنزيل الخادم**: إذا لم تقم بكتابة الخادم، فقم بتنزيله أولاً إلى جهازك.
1. **بدء عملية الخادم**: قم بتشغيل تطبيق خادم MCP الخاص بك.

لـ SSE (غير مطلوب لخادم نوع stdio)

1. **تكوين الشبكة**: تأكد من أن الخادم متاح على المنفذ المتوقع.
1. **توصيل العملاء**: استخدم عناوين URL للاتصال المحلي مثل `http://localhost:3000`

## النشر السحابي

يمكن نشر خوادم MCP على منصات سحابية مختلفة:

- **وظائف بلا خادم**: نشر خوادم MCP خفيفة الوزن كوظائف بلا خادم.
- **خدمات الحاويات**: استخدم خدمات مثل Azure Container Apps أو AWS ECS أو Google Cloud Run.
- **Kubernetes**: نشر وإدارة خوادم MCP في مجموعات Kubernetes لتحقيق توفر عالي.

### مثال: Azure Container Apps

تدعم Azure Container Apps نشر خوادم MCP. لا يزال العمل جارٍ عليها وهي تدعم حاليًا خوادم SSE.

إليك كيفية القيام بذلك:

1. استنساخ مستودع:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. قم بتشغيله محليًا لاختبار الأمور:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. لتجربته محليًا، قم بإنشاء ملف *mcp.json* في دليل *.vscode* وأضف المحتوى التالي:

  ```json
  {
      "inputs": [
          {
              "type": "promptString",
              "id": "weather-api-key",
              "description": "Weather API Key",
              "password": true
          }
      ],
      "servers": {
          "weather-sse": {
              "type": "sse",
              "url": "http://localhost:8000/sse",
              "headers": {
                  "x-api-key": "${input:weather-api-key}"
              }
          }
      }
  }
  ```

  بمجرد بدء تشغيل خادم SSE، يمكنك النقر على رمز التشغيل في ملف JSON، يجب أن ترى الآن الأدوات على الخادم يتم التقاطها بواسطة GitHub Copilot، انظر إلى رمز الأداة.

1. للنشر، قم بتشغيل الأمر التالي:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

ها هو الأمر، قم بنشره محليًا، قم بنشره على Azure من خلال هذه الخطوات.

## موارد إضافية

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [مقالة Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [مستودع Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## ماذا بعد

- التالي: [التنفيذ العملي](/04-PracticalImplementation/README.md)

**إخلاء المسؤولية**:  
تم ترجمة هذه الوثيقة باستخدام خدمة الترجمة بالذكاء الاصطناعي [Co-op Translator](https://github.com/Azure/co-op-translator). بينما نسعى لتحقيق الدقة، يرجى العلم أن الترجمات الآلية قد تحتوي على أخطاء أو عدم دقة. يجب اعتبار الوثيقة الأصلية بلغتها الأصلية المصدر الموثوق. بالنسبة للمعلومات الهامة، يُوصى بالترجمة البشرية الاحترافية. نحن غير مسؤولين عن أي سوء فهم أو تفسيرات خاطئة تنشأ عن استخدام هذه الترجمة.