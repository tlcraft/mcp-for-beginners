<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-05-17T12:49:54+00:00",
  "source_file": "03-GettingStarted/08-deployment/README.md",
  "language_code": "ur"
}
-->
# MCP سرورز کو تعینات کرنا

اپنے MCP سرور کو تعینات کرنے سے دوسروں کو اس کے ٹولز اور وسائل تک آپ کے مقامی ماحول سے باہر رسائی حاصل ہوتی ہے۔ آپ کی پیمائش، اعتبار اور انتظام کی آسانی کی ضروریات پر منحصر مختلف تعیناتی حکمت عملیوں پر غور کیا جا سکتا ہے۔ نیچے آپ کو MCP سرورز کو مقامی طور پر، کنٹینرز میں، اور کلاؤڈ پر تعینات کرنے کے لیے رہنمائی ملے گی۔

## جائزہ

یہ سبق آپ کے MCP سرور ایپ کو تعینات کرنے کے طریقے کا احاطہ کرتا ہے۔

## سیکھنے کے مقاصد

اس سبق کے اختتام تک، آپ قابل ہوں گے:

- مختلف تعیناتی طریقوں کا جائزہ لیں۔
- اپنی ایپ کو تعینات کریں۔

## مقامی ترقی اور تعیناتی

اگر آپ کا سرور صارفین کی مشین پر چلانے کے لیے بنایا گیا ہے، تو آپ درج ذیل مراحل کی پیروی کر سکتے ہیں:

1. **سرور ڈاؤن لوڈ کریں**۔ اگر آپ نے سرور نہیں لکھا ہے، تو پہلے اسے اپنی مشین پر ڈاؤن لوڈ کریں۔
1. **سرور عمل شروع کریں**: اپنی MCP سرور ایپلیکیشن چلائیں

SSE کے لیے (stdio قسم کے سرور کے لیے ضروری نہیں)

1. **نیٹ ورکنگ کو ترتیب دیں**: یقینی بنائیں کہ سرور متوقع پورٹ پر قابل رسائی ہے
1. **کلائنٹس کو جوڑیں**: مقامی کنکشن URLs جیسے `http://localhost:3000` استعمال کریں

## کلاؤڈ تعیناتی

MCP سرورز کو مختلف کلاؤڈ پلیٹ فارمز پر تعینات کیا جا سکتا ہے:

- **سرور لیس فنکشنز**: ہلکے وزن کے MCP سرورز کو سرور لیس فنکشنز کے طور پر تعینات کریں
- **کنٹینر سروسز**: Azure Container Apps، AWS ECS، یا Google Cloud Run جیسے سروسز استعمال کریں
- **کبرنیٹیز**: اعلی دستیابی کے لیے کبرنیٹیز کلسٹرز میں MCP سرورز کو تعینات اور منظم کریں

### مثال: Azure Container Apps

Azure Container Apps MCP سرورز کی تعیناتی کی حمایت کرتا ہے۔ یہ ابھی تک کام میں ہے اور فی الحال SSE سرورز کی حمایت کرتا ہے۔

یہاں آپ اسے کیسے کر سکتے ہیں:

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

1. اسے مقامی طور پر آزمانے کے لیے، ایک *mcp.json* فائل *.vscode* ڈائریکٹری میں بنائیں اور درج ذیل مواد شامل کریں:

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

  ایک بار جب SSE سرور شروع ہو جائے، آپ JSON فائل میں پلے آئیکن پر کلک کر سکتے ہیں، آپ کو اب GitHub Copilot کے ذریعے سرور پر ٹولز کو اٹھایا ہوا دیکھنا چاہیے، ٹول آئیکن دیکھیں۔

1. تعینات کرنے کے لیے، درج ذیل کمانڈ چلائیں:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

یہاں آپ کے پاس ہے، اسے مقامی طور پر تعینات کریں، ان مراحل کے ذریعے Azure میں تعینات کریں۔

## اضافی وسائل

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [Azure Container Apps مضمون](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [Azure Container Apps MCP ریپو](https://github.com/anthonychu/azure-container-apps-mcp-sample)


## آگے کیا ہے

- اگلا: [عملی نفاذ](/04-PracticalImplementation/README.md)

**دستبرداری**:  
یہ دستاویز AI ترجمہ سروس [Co-op Translator](https://github.com/Azure/co-op-translator) کا استعمال کرتے ہوئے ترجمہ کی گئی ہے۔ اگرچہ ہم درستگی کی کوشش کرتے ہیں، براہ کرم آگاہ رہیں کہ خودکار ترجمے میں غلطیاں یا غیر درستیاں ہو سکتی ہیں۔ اصل دستاویز کو اس کی مادری زبان میں مستند ذریعہ سمجھا جانا چاہیے۔ اہم معلومات کے لئے، پیشہ ورانہ انسانی ترجمہ کی سفارش کی جاتی ہے۔ اس ترجمے کے استعمال سے پیدا ہونے والے کسی بھی غلط فہمی یا غلط تشریح کے لئے ہم ذمہ دار نہیں ہیں۔