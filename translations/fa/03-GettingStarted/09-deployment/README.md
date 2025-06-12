<!--
CO_OP_TRANSLATOR_METADATA:
{
  "original_hash": "7816cc28f7ab9a54e31f9246429ffcd9",
  "translation_date": "2025-06-12T22:12:00+00:00",
  "source_file": "03-GettingStarted/09-deployment/README.md",
  "language_code": "fa"
}
-->
# استقرار سرورهای MCP

استقرار سرور MCP شما به دیگران این امکان را می‌دهد که به ابزارها و منابع آن فراتر از محیط محلی شما دسترسی پیدا کنند. بسته به نیازهای شما برای مقیاس‌پذیری، قابلیت اطمینان و سهولت مدیریت، چندین استراتژی استقرار وجود دارد. در ادامه راهنمایی‌هایی برای استقرار سرورهای MCP به صورت محلی، در کانتینرها و در فضای ابری خواهید یافت.

## مرور کلی

این درس نحوه استقرار برنامه سرور MCP شما را پوشش می‌دهد.

## اهداف یادگیری

تا پایان این درس، قادر خواهید بود:

- رویکردهای مختلف استقرار را ارزیابی کنید.
- برنامه خود را مستقر کنید.

## توسعه و استقرار محلی

اگر سرور شما قرار است روی دستگاه کاربران اجرا شود، می‌توانید مراحل زیر را دنبال کنید:

1. **دانلود سرور**. اگر سرور را خودتان ننوشته‌اید، ابتدا آن را روی دستگاه خود دانلود کنید.
1. **راه‌اندازی فرآیند سرور**: برنامه سرور MCP خود را اجرا کنید.

برای SSE (که برای سرورهای نوع stdio لازم نیست)

1. **پیکربندی شبکه**: اطمینان حاصل کنید سرور روی پورت مورد انتظار قابل دسترسی است.
1. **اتصال کلاینت‌ها**: از URLهای اتصال محلی مانند `http://localhost:3000` استفاده کنید.

## استقرار در فضای ابری

سرورهای MCP را می‌توان در پلتفرم‌های ابری مختلف مستقر کرد:

- **توابع بدون سرور**: سرورهای سبک MCP را به صورت توابع بدون سرور مستقر کنید.
- **خدمات کانتینر**: از خدماتی مانند Azure Container Apps، AWS ECS یا Google Cloud Run استفاده کنید.
- **کوبِرنِتس**: سرورهای MCP را در کلاسترهای کوبِرنِتس برای دسترسی بالا مستقر و مدیریت کنید.

### مثال: Azure Container Apps

Azure Container Apps از استقرار سرورهای MCP پشتیبانی می‌کند. این قابلیت هنوز در حال توسعه است و در حال حاضر از سرورهای SSE پشتیبانی می‌کند.

مراحل کار به این صورت است:

1. یک مخزن را کلون کنید:

  ```sh
  git clone https://github.com/anthonychu/azure-container-apps-mcp-sample.git
  ```

1. برای آزمایش، آن را به صورت محلی اجرا کنید:

  ```sh
  uv venv
  uv sync

  # linux/macOS
  export API_KEYS=<AN_API_KEY>
  # windows
  set API_KEYS=<AN_API_KEY>

  uv run fastapi dev main.py
  ```

1. برای آزمایش محلی، یک فایل *mcp.json* در دایرکتوری *.vscode* بسازید و محتوای زیر را اضافه کنید:

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

  پس از راه‌اندازی سرور SSE، می‌توانید روی آیکون پخش در فایل JSON کلیک کنید، حالا باید ابزارهای سرور توسط GitHub Copilot شناسایی شوند، آیکون ابزار را ببینید.

1. برای استقرار، دستور زیر را اجرا کنید:

  ```sh
  az containerapp up -g <RESOURCE_GROUP_NAME> -n weather-mcp --environment mcp -l westus --env-vars API_KEYS=<AN_API_KEY> --source .
  ```

به همین سادگی، آن را به صورت محلی مستقر کنید یا از طریق این مراحل در Azure استقرار دهید.

## منابع اضافی

- [Azure Functions + MCP](https://learn.microsoft.com/en-us/samples/azure-samples/remote-mcp-functions-dotnet/remote-mcp-functions-dotnet/)
- [مقاله Azure Container Apps](https://techcommunity.microsoft.com/blog/appsonazureblog/host-remote-mcp-servers-in-azure-container-apps/4403550)
- [مخزن Azure Container Apps MCP](https://github.com/anthonychu/azure-container-apps-mcp-sample)

## مرحله بعد

- مرحله بعد: [پیاده‌سازی عملی](/04-PracticalImplementation/README.md)

**سلب مسئولیت**:  
این سند با استفاده از سرویس ترجمه هوش مصنوعی [Co-op Translator](https://github.com/Azure/co-op-translator) ترجمه شده است. در حالی که ما تلاش می‌کنیم دقت را حفظ کنیم، لطفاً توجه داشته باشید که ترجمه‌های خودکار ممکن است شامل خطاها یا نواقصی باشند. سند اصلی به زبان بومی آن باید به عنوان منبع معتبر در نظر گرفته شود. برای اطلاعات حیاتی، ترجمه حرفه‌ای انسانی توصیه می‌شود. ما مسئول هیچ گونه سوءتفاهم یا تفسیر نادرستی که ناشی از استفاده از این ترجمه باشد، نیستیم.