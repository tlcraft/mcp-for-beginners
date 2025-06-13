<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:28:10+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "mo"
}
-->
# نشر خوادم MCP

نشر خادم MCP الخاص بك يسمح للآخرين بالوصول إلى أدواته وموارده خارج بيئتك المحلية. هناك عدة استراتيجيات للنشر يجب مراعاتها، حسب متطلباتك من حيث القابلية للتوسع، والموثوقية، وسهولة الإدارة. أدناه ستجد إرشادات لنشر خوادم MCP محليًا، في الحاويات، وعلى السحابة.

## نظرة عامة

يغطي هذا الدرس كيفية نشر تطبيق MCP Server الخاص بك.

## أهداف التعلم

بحلول نهاية هذا الدرس، ستكون قادرًا على:

- تقييم طرق النشر المختلفة.
- نشر تطبيقك.

## التطوير والنشر المحلي

إذا كان من المفترض أن يستخدم الخادم على جهاز المستخدم، يمكنك اتباع الخطوات التالية:

1. **تحميل الخادم**. إذا لم تقم بكتابة الخادم، فقم أولاً بتحميله إلى جهازك.
1. **تشغيل عملية الخادم**: شغل تطبيق MCP server الخاص بك.

بالنسبة لـ SSE (غير مطلوب لخادم نوع stdio)

1. **تهيئة الشبكة**: تأكد من أن الخادم متاح على المنفذ المتوقع.
1. **اتصال العملاء**: استخدم عناوين الاتصال المحلية مثل `http://localhost:3000`.

## النشر على السحابة

يمكن نشر خوادم MCP على منصات سحابية متعددة:

- **الدوال بدون خادم**: نشر خوادم MCP خفيفة الوزن كدوال بدون خادم.
- **خدمات الحاويات**: استخدم خدمات مثل Azure Container Apps، AWS ECS، أو Google Cloud Run.
- **Kubernetes**: نشر وإدارة خوادم MCP في مجموعات Kubernetes لتحقيق توافر عالي.

### مثال: Azure Container Apps

تدعم Azure Container Apps نشر خوادم MCP. لا يزال هذا العمل قيد التطوير ويدعم حاليًا خوادم SSE.

إليك كيفية القيام بذلك:

1. استنساخ المستودع:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. تشغيله محليًا لاختبار الأمور:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. لتجربته محليًا، أنشئ ملف *mcp.json* في مجلد *.vscode* وأضف المحتوى التالي:

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

  بمجرد بدء تشغيل خادم SSE، يمكنك النقر على أيقونة التشغيل في ملف JSON، يجب أن ترى الآن الأدوات على الخادم يتم التقاطها بواسطة GitHub Copilot، انظر إلى أيقونة الأداة.

1. للنشر، شغل الأمر التالي:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

ها قد انتهيت، انشره محليًا أو انشره على Azure من خلال هذه الخطوات.

## موارد إضافية

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [مقال Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [مستودع Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## ما التالي

- التالي: [التنفيذ العملي](/04-PracticalImplementation/README.md)

**Disclaimer**:  
This document has been translated using AI translation service [Co-op Translator](https://github.com/Azure/co-op-translator). While we strive for accuracy, please be aware that automated translations may contain errors or inaccuracies. The original document in its native language should be considered the authoritative source. For critical information, professional human translation is recommended. We are not liable for any misunderstandings or misinterpretations arising from the use of this translation.