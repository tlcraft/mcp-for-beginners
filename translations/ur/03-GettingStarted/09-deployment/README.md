<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-13T01:28:00+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "ur"
}
-->
# سرورز MCP کی تعیناتی

آپ کے MCP سرور کی تعیناتی دوسروں کو اس کے اوزار اور وسائل تک آپ کے مقامی ماحول سے باہر رسائی فراہم کرتی ہے۔ آپ کی ضرورت کے مطابق، جیسے کہ وسعت پذیری، اعتمادیت، اور آسان انتظام، مختلف تعیناتی حکمت عملیوں پر غور کرنا ضروری ہے۔ نیچے آپ کو MCP سرورز کو مقامی، کنٹینرز میں، اور کلاؤڈ پر تعینات کرنے کی رہنمائی ملے گی۔

## جائزہ

یہ سبق آپ کے MCP Server ایپ کو تعینات کرنے کا طریقہ بیان کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:

- مختلف تعیناتی طریقوں کا جائزہ لینا۔
- اپنی ایپ کو تعینات کرنا۔

## مقامی ترقی اور تعیناتی

اگر آپ کا سرور صارفین کے کمپیوٹر پر چلانے کے لیے ہے، تو آپ درج ذیل مراحل پر عمل کر سکتے ہیں:

1. **سرور ڈاؤن لوڈ کریں**۔ اگر آپ نے سرور نہیں لکھا، تو پہلے اسے اپنے کمپیوٹر پر ڈاؤن لوڈ کریں۔
1. **سرور کا عمل شروع کریں**: اپنی MCP سرور ایپلیکیشن چلائیں۔

SSE کے لیے (stdio قسم کے سرور کے لیے ضروری نہیں)

1. **نیٹ ورکنگ ترتیب دیں**: یقینی بنائیں کہ سرور متوقع پورٹ پر قابل رسائی ہے۔
1. **کلائنٹس کو جوڑیں**: مقامی کنکشن URLs جیسے `http://localhost:3000` استعمال کریں۔

## کلاؤڈ تعیناتی

MCP سرورز مختلف کلاؤڈ پلیٹ فارمز پر تعینات کیے جا سکتے ہیں:

- **سرور لیس فنکشنز**: ہلکے پھلکے MCP سرورز کو سرور لیس فنکشنز کے طور پر تعینات کریں۔
- **کنٹینر سروسز**: Azure Container Apps، AWS ECS، یا Google Cloud Run جیسی سروسز استعمال کریں۔
- **کوبیرنیٹیز**: اعلی دستیابی کے لیے MCP سرورز کو کوبیرنیٹیز کلسٹرز میں تعینات اور منظم کریں۔

### مثال: Azure Container Apps

Azure Container Apps MCP سرورز کی تعیناتی کی حمایت کرتا ہے۔ یہ ابھی ترقی کے مراحل میں ہے اور اس وقت SSE سرورز کی حمایت کرتا ہے۔

آپ اس طرح آگے بڑھ سکتے ہیں:

1. ایک ریپو کلون کریں:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. چیزوں کو آزمانے کے لیے اسے مقامی طور پر چلائیں:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. مقامی طور پر آزمانے کے لیے، *.vscode* ڈائریکٹری میں *mcp.json* فائل بنائیں اور درج ذیل مواد شامل کریں:

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

  جب SSE سرور شروع ہو جائے، تو آپ JSON فائل میں پلے آئیکن پر کلک کر سکتے ہیں، اب آپ کو GitHub Copilot کے ذریعے سرور کے اوزار نظر آئیں گے، ٹول آئیکن دیکھیں۔

1. تعینات کرنے کے لیے، درج ذیل کمانڈ چلائیں:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

یہ لو، اسے مقامی طور پر تعینات کریں، Azure پر ان مراحل کے ذریعے تعینات کریں۔

## اضافی وسائل

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps article](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP repo](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## آگے کیا ہے

- اگلا: [عملی نفاذ](/04-PracticalImplementation/README.md)

**ڈس کلیمر**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کے ذریعے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کے لیے کوشاں ہیں، براہ کرم اس بات سے آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز اپنی مادری زبان میں ہی معتبر ماخذ سمجھی جانی چاہیے۔ اہم معلومات کے لیے پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ ہم اس ترجمے کے استعمال سے پیدا ہونے والی کسی بھی غلط فہمی یا غلط تشریح کے ذمہ دار نہیں ہیں۔